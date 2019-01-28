using System;
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

        public async Task<string> Login(LoginRequest request)
        {
            return await Policies.RetryPolicy(async () =>
            {
                var loginResult = await _restService.Login(request);
                var authToken = (loginResult as LoginResult)?.Token?.AuthToken;
                return authToken;
            });
        }

        public async Task<bool> Logout(LogoutRequest request)
        {
            return await Policies.RetryPolicy(async () =>
            {
                var apiResponse = await _restService.Logout(request);
                return apiResponse?.IsSuccessStatusCode ?? false;
            });
        }
    }
}