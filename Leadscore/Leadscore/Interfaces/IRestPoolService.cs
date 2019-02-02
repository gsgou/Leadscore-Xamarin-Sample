using Leadscore.Interfaces.Api;

namespace Leadscore.Interfaces
{
    public interface IRestPoolService
    {
        IAuthenticationApi AuthenticationApi { get; }

        IContactsApi ContactsApi { get; }

        void UpdateApiUrl(string newApiUrl);
    }
}