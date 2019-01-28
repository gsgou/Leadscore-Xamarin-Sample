using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Leadscore.Helpers;
using Leadscore.Interfaces;
using Leadscore.Models;
using Refit;

namespace Leadscore.Services
{
    public class ContactsService
    {
        readonly HttpClient _httpClient;
        readonly HttpClientHandler _httpClientHandler;
        readonly IContacts _restService;

        const string ApiBaseUrl = "https://internal-api-staging-lb.interact.io/v2";

        public ContactsService()
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClient = new HttpClient(_httpClientHandler)
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };

            _restService = RestService.For<IContacts>(_httpClient);
        }

        public async Task<IEnumerable<Contact>> FindFilteredContact(string authToken)
        {
            return await Policies.RetryPolicy(async () =>
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

                var result = (await _restService.FindFilteredContacts(request, authToken))?.Data;
                return result;
            });
        }
    }
}