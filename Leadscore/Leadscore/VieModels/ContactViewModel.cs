using System;
using System.Diagnostics;
using System.Linq;

using ReactiveUI.Fody.Helpers;

using Leadscore.Models;

namespace Leadscore.ViewModels
{
    public class ContactViewModel : BasePageViewModel
    {
        [Reactive] public string DisplayName { get; private set; }

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

                DisplayName = string.Format("{0} {1} {2}", result.FirstName, result.MiddleName, result.LastName);

                Email = result?.Emails
                              ?.FirstOrDefault(em => em.Primary == true)
                              ?.EmailEmail;

                Birthday = result.Birthday;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return response;
        }
    }
}