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
                // Exponential back-off plus some jitter
                // To overcome peaks of similar retries coming from many clients in case of partial outages,
                // a good workaround is to add a jitter strategy to the retry algorithm/policy.
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
                // handle validation here by using validationException.Content, 
                // which is type of ProblemDetails according to RFC 7807
                string errorMessage = string.Format("{0} in {1}(...): {2}\r\n{3}", nameof(ValidationApiException), methodName, ex.Message, ex);
                Debug.Write(errorMessage);
            }
            catch (ApiException ex)
            {
                string errorMessage = string.Format("{0} in {1}(...): {2}\r\n{3}", nameof(ApiException), methodName, ex.Message, ex);
                Debug.Write(errorMessage);
            }
            catch (JsonReaderException ex)
            {
                string errorMessage = string.Format("{0} in {1}(...): {2}\r\n{3}", nameof(JsonReaderException), methodName, ex.Message, ex);
                Debug.Write(errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format("{0} in {1}(...): {2}\r\n{3}", nameof(Exception), methodName, ex.Message, ex);
                Debug.Write(errorMessage);
            }
        }
    }
}