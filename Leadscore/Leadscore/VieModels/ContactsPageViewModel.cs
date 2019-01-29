using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        ContactsService _contactsService = new ContactsService();
        CacheService _cacheService = new CacheService();

        public ObservableRangeCollection<ContactViewModel> Contacts { get; } = new ObservableRangeCollection<ContactViewModel>();

        [Reactive] public bool IsRefreshing { get; set; } = false;

        readonly ReactiveCommand<Unit, Unit> logoutCommand;
        public ReactiveCommand<Unit, Unit> LogoutCommand => this.logoutCommand;

        readonly ReactiveCommand<Unit, Unit> findFilteredContactsCommand;
        public ReactiveCommand<Unit, Unit> FindFilteredContactsCommand => this.findFilteredContactsCommand;

        public ContactsPageViewModel()
        {
            this.logoutCommand = ReactiveCommand.CreateFromObservable(
                () =>
                    Observable
                        .StartAsync(this.LogoutAsync));

            this.findFilteredContactsCommand = ReactiveCommand.CreateFromObservable(
                () =>
                    Observable
                        .StartAsync(this.FindFilteredContactsAsync));
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            this.findFilteredContactsCommand.Execute();
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

        async Task FindFilteredContactsAsync()
        {
            this.IsRefreshing = true;

            string authToken = await _cacheService.GetObject<string>("AuthToken");
            if (authToken != null)
            {
                var contacts = await _contactsService.FindFilteredContact(authToken);
                if (contacts.Any())
                {
                    var list = new List<ContactViewModel>();
                    foreach (var result in contacts)
                    {
                        var contact = this.Contacts
                                          .FirstOrDefault(x => x.Id.Equals(result.Id));

                        if (contact != null)
                        {
                            contact.TrySet(result);
                        }
                        else
                        {
                            contact = new ContactViewModel();
                            contact.TrySet(result);
                            this.Contacts.Add(contact);
                        }
                    }
                    if (list.Any())
                    {
                        this.Contacts.AddRange(list);
                    }
                }
            }

            this.IsRefreshing = false;
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