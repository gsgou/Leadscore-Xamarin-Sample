using System;
using System.Diagnostics;
using System.Linq;

using ReactiveUI.Fody.Helpers;

using Leadscore.Models;

namespace Leadscore.ViewModels
{
    public class ContactViewModel : BasePageViewModel
    {
        [Reactive] public string Id { get; private set; }

        [Reactive] public string DisplayName { get; private set; }

        [Reactive] public string PhoneNumber { get; private set; }

        [Reactive] public string Email { get; private set; }

        [Reactive] public string Birthday { get; private set; }

        public bool TrySet(Contact result)
        {
            var response = false;

            if (result == null)
            {
                return response;
            }

            try
            {
                response = true;

                Id = result.Id;

                DisplayName = result.DisplayName;

                PhoneNumber = result.PhoneNumbers
                                    ?.FirstOrDefault(pn => pn.Primary == true)
                                    ?.Number
                                    ?? result.PhoneNumbers?.FirstOrDefault()?.Number;

                Email = result.Emails
                              ?.FirstOrDefault(em => em.Primary == true)
                              ?.EmailEmail
                              ?? string.Empty;

                Birthday = string.Empty; //result.Birthday ?? string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return response;
        }
    }
}