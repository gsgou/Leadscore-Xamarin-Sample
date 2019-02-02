using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Splat;

using Leadscore.Helpers;
using Leadscore.Interfaces;
using Leadscore.Interfaces.Api;
using Leadscore.Models;

namespace Leadscore.Services
{
    public class ContactsService
    {
        readonly IContactsApi _restService;

        public ContactsService()
        {
            _restService = Locator.Current.GetService<IRestPoolService>().ContactsApi;
        }

        public async Task<IEnumerable<Contact>> FindFilteredContact(string authToken)
        {
            var filters = new Filter[] {
                new Filter { Field = "contactType", Op = "eq", Value = "COMPANY" },
                new Filter { Field = "contactType", Op = "eq", Value = "PERSON" }
            }.AsEnumerable();

            var request = new FindFilteredContactsRequest()
            {
                DefaultOperator = "OR",
                Filters = filters
            };

            var result = Enumerable.Empty<Contact>();
            await ApiHelpers.RunSafe(async () =>
            {
                result = await ApiHelpers.RetryPolicy(async () =>
                {
                    var filteredContacts = await _restService.FindFilteredContacts(request, authToken);
                    return filteredContacts?.Data;
                });
            });
            return result;
        }
    }
}