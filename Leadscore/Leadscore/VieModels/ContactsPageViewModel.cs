using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Xamvvm;

using Leadscore.Models;
using Leadscore.Services;

namespace Leadscore.ViewModels
{
    public class ContactsPageViewModel : BasePageViewModel
    {
        AuthenticationService _authenticationService = new AuthenticationService();
        CacheService _cacheService = new CacheService();

        public ObservableCollection<ContactViewModel> Contacts { get; } = new ObservableCollection<ContactViewModel>();

        [Reactive] public bool IsRefreshing { get; set; } = false;

        readonly ReactiveCommand<Unit, Unit> logoutCommand;
        public ReactiveCommand<Unit, Unit> LogoutCommand => this.logoutCommand;

        public ContactsPageViewModel()
        {
            var c = new Contact()
            {
                FirstName = "Giorgos",
                LastName = "Sgouridis",
                Birthday = "16.01.1980"
            };
            var cvm = new ContactViewModel();
            cvm.TrySet(c);
            Contacts.Add(cvm);

            this.logoutCommand = ReactiveCommand.CreateFromObservable(
                () =>
                    Observable
                        .StartAsync(this.LogoutAsync));
        }

        async Task LogoutAsync()
        {
            string authToken = await _cacheService.GetObject<string>("AuthToken");
            if (authToken != null)
            {
                var logoutRequest = new Dictionary<string, object> {
                    { "authToken", authToken }
                };
                bool hasLogout = await _authenticationService.Logout(logoutRequest);
                if (hasLogout)
                {
                    await NavToLogin();
                }
            }
        }

        async Task<bool> NavToLogin()
        {
            try
            {
                return await this.PushPageAsNewInstanceAsync<LoginPageViewModel>();
            }
            catch (Exception ex)
            {
                await Observable.Throw<Unit>(ex);
                return false;
            }
        }
    }
}