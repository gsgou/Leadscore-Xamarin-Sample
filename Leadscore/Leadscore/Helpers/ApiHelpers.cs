using System;
using System.Diagnostics;
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
        // Exponential back-off plus some jitter.
        // To overcome peaks of similar retries coming from many clients in case of partial outages,
        // a good workaround is to add a jitter strategy to the retry algorithm/policy.
        public static async Task<TResult> RetryPolicy<TResult>(Func<Task<TResult>> action)
        {
            Random jitterer = new Random();

            return await Policy
            .Handle<ApiException>(ex =>
                ex.StatusCode != HttpStatusCode.NotFound &&
                ex.StatusCode != HttpStatusCode.NotModified)
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
            string errorMessage = string.Format("{0} in {1}():\r\n{2}\r\n",
                ex.GetType().Name,
                methodName,
                (ex as Exception).Message);
            Debug.Write(errorMessage);
        }
    }
}