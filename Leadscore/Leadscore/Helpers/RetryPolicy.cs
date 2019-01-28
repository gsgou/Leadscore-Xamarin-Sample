using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

using Polly;
using Refit;

namespace Leadscore.Helpers
{
    public static class Policies
    {
        public static async Task<TResult> RetryPolicy<TResult>(Func<Task<TResult>> action)
        {
            Random jitterer = new Random();

            return await Policy
            .Handle<ApiException>(ex => ex.StatusCode != HttpStatusCode.NotFound && ex.StatusCode != HttpStatusCode.NotModified)
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
    }
}