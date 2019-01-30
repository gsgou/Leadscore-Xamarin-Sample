using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using Leadscore.Models;

namespace Leadscore.ViewModels
{
    public class ContactViewModel : BasePageViewModel
    {
        public string Id { get; private set; }

        public string DisplayName { get; private set; }

        public string PhoneNumber { get; private set; }

        //public string Email { get; private set; }

        public string Birthday { get; private set; }

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

                //Email = result.Emails
                //?.FirstOrDefault(em => em.Primary == true)
                //?.EmailEmail
                //?? string.Empty;

                DateTime birthday;
                Birthday = result.Birthday != null && DateTime.TryParse(result.Birthday, out birthday) ?
                               birthday.ToString("dd.MM", CultureInfo.InvariantCulture) :
                               string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return response;
        }
    }
}