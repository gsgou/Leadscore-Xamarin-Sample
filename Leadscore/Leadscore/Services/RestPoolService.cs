using Refit;

using Leadscore.Helpers;
using Leadscore.Interfaces;
using Leadscore.Interfaces.Api;

namespace Leadscore.Services
{
    public class RestPoolService : IRestPoolService
    {
        const string BaseApiUrl = "https://internal-api-staging-lb.interact.io/v2";

        public IAuthenticationApi AuthenticationApi { get; private set; }

        public IContactsApi ContactsApi { get; private set; }

        public RestPoolService()
        {
            UpdateApiUrl(BaseApiUrl);
        }

        public void UpdateApiUrl(string newApiUrl)
        {
            var defaultHttpClient = HttpClientFactory.Create(newApiUrl);
            AuthenticationApi = RestService.For<IAuthenticationApi>(defaultHttpClient);
            ContactsApi = RestService.For<IContactsApi>(defaultHttpClient);
        }
    }
}