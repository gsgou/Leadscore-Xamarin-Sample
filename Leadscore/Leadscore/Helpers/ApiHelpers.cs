using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Polly;
using Refit;

namespace Leadscore.Helpers
{
    public static class ApiHelpers
    {
        static HttpStatusCode[] httpStatusCodesWorthRetrying = {
            HttpStatusCode.RequestTimeout,      // 408
            HttpStatusCode.InternalServerError, // 500
            HttpStatusCode.BadGateway,          // 502
            HttpStatusCode.ServiceUnavailable,  // 503
            HttpStatusCode.GatewayTimeout       // 504
        };

        static Random jitterer = new Random();

        // Exponential back-off plus some jitter.
        // To overcome peaks of similar retries coming from many clients in case of partial outages,
        // a good workaround is to add a jitter strategy to the retry algorithm/policy.
        public static async Task<TResult> RetryPolicy<TResult>(Func<Task<TResult>> action)
        {
            return await Policy
            .Handle<ApiException>(ex => httpStatusCodesWorthRetrying.Contains(ex.StatusCode))
            .WaitAndRetryAsync
            (
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                                     + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)),
                onRetry: (ex, time) =>
                {
                    Debug.WriteLine($"Something went wrong: {ex.Message}, retrying...");
                }
            )
            .ExecuteAsync(async () =>
            {
                Debug.WriteLine($"Trying to send data...");

                return await action();
            });
        }

        public static async Task RunSafe(Func<Task> del, [CallerMemberName] string methodName = "")
        {
            try
            {
                await del();
            }
            catch (ValidationApiException ex)
            {
                // Handle validation here by using ValidationException.Content, 
                // which is type of ProblemDetails according to RFC 7807
                HandleException(methodName, ex);
            }
            catch (ApiException ex)
            {
                HandleException(methodName, ex);
            }
            catch (JsonReaderException ex)
            {
                HandleException(methodName, ex);
            }
            catch (Exception ex)
            {
                HandleException(methodName, ex);
            }
        }

        static void HandleException<TException>(string methodName, TException ex)
        {
            var exception = ex as Exception;
            Debug.Write(
                $"{ex.GetType().Name} in {methodName}():\r\n" +
                $"{exception?.Message}\r\n" + 
                $"{exception?.StackTrace}\r\n");
        }
    }
}