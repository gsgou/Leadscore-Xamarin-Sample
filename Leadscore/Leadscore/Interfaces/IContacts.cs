using System.Threading.Tasks;
using Leadscore.Models;
using Refit;

namespace Leadscore.Interfaces
{
    public interface IContacts
    { 
        [Headers("Content-Type: application/json", "Accept: application/json")]
        [Post("/contacts/filter?offset=0&limit=100")]
        Task<FindFilteredContactsResult> FindFilteredContacts([Body(BodySerializationMethod.Json)] FindFilteredContactsRequest request, [Header("authToken")] string authToken);
    }
}