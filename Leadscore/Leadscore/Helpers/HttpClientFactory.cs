using System;
using System.Net.Http;

namespace Leadscore.Helpers
{
    public static class HttpClientFactory
    {
        public static HttpClient Create(string baseAddress, int seconds = 5) => new HttpClient
        {
            BaseAddress = new Uri(baseAddress),
            Timeout = TimeSpan.FromSeconds(seconds),
        };
    }
}