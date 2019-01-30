using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Leadscore.Helpers;
using Leadscore.Interfaces;
using Leadscore.Models;
using Refit;

namespace Leadscore.Services
{
    public class AuthenticationService
    {
        readonly HttpClient _httpClient;
        readonly HttpClientHandler _httpClientHandler;
        readonly IAuthentication _restService;

        const string ApiBaseUrl = "https://internal-api-staging-lb.interact.io/v2";

        public AuthenticationService()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClient = new HttpClient(_httpClientHandler)
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };

            _restService = RestService.For<IAuthentication>(_httpClient);
        }

        public async Task<string> Login(Dictionary<string, object> request)
        {
            LoginResult loginResult = null;
            await ApiHelpers.RunSafe(async () =>
            {
                loginResult = await ApiHelpers.RetryPolicy(async () =>
                {
                    return await _restService.Login(request);
                });
            });

            var authToken = (loginResult as LoginResult)?.Token?.AuthToken;
            return authToken;
        }

        public async Task<bool> Logout(Dictionary<string, object> request)
        {
            ApiResponse<HttpContent> apiResponse = null;
            await ApiHelpers.RunSafe(async () =>
            {
                apiResponse = await ApiHelpers.RetryPolicy(async () =>
                {
                    return await _restService.Logout(request);
                });
            });

            return apiResponse?.IsSuccessStatusCode ?? false;
        }
    }
}