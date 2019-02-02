using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Splat;

using Leadscore.Helpers;
using Leadscore.Interfaces;
using Leadscore.Interfaces.Api;
using Leadscore.Models;
using Refit;

namespace Leadscore.Services
{
    public class AuthenticationService
    {
        readonly IAuthenticationApi _restService;

        public AuthenticationService()
        {
            _restService = Locator.Current.GetService<IRestPoolService>().AuthenticationApi;
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