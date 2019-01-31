using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Xamvvm;

using Leadscore.Services;

namespace Leadscore.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel
    {
        static string _client = "LeadscoreApp";
        AuthenticationService _authenticationService = new AuthenticationService();
        CacheService _cacheService = new CacheService();

        [Reactive]
        public string Email { get; set; } = string.Empty;

        [Reactive]
        public string Password { get; set; } = string.Empty;

        [Reactive]
        public string ErrorMessage { get; set; } = "Please try again";

        [ObservableAsProperty]
        public bool CanLogin { get; private set; }

        readonly ReactiveCommand<Unit, Unit> loginCommand;
        public ReactiveCommand<Unit, Unit> LoginCommand => this.loginCommand;

        public LoginPageViewModel()
        {
            var canLoginObservable = this
                .WhenAnyValue(
                    x => x.Email,
                    x => x.Password,
                    (Email, Password) =>
                        // Validate our Email
                        (
                            !string.IsNullOrEmpty(Email) &&
                            Regex.Matches(Email, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").Count == 1
                        )
                        &&
                        // Validate our Password
                        // At least 8 characters, 1 uppercase, 1 lowercase, 1 number and 1 special character
                        (
                            !string.IsNullOrEmpty(Password) &&
                            Regex.Matches(Password, "^(?=\\S*[a-z])(?=\\S*[A-Z])(?=\\S*\\d)(?=\\S*[^\\w\\s])\\S{8,}$").Count == 1
                        ));

            canLoginObservable
                .Do(_ => Debug.WriteLine($"{Email},{Password},{CanLogin.ToString()}"))
                .ToPropertyEx(this, x => x.CanLogin);

            this.loginCommand = ReactiveCommand.CreateFromObservable(
                () =>
                    Observable
                        .StartAsync(this.LoginAsync),
                canLoginObservable);

            canLoginObservable
                .Subscribe()
                .DisposeWith(this.DeactivateWith);
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            Email = await _cacheService.GetObject<string>("Email");
        }

        async Task LoginAsync()
        {
            var loginRequest = new Dictionary<string, object> {
                { "username", Email },
                { "password", Password },
                { "client", _client }
            };
            var authToken = await _authenticationService.Login(loginRequest);
            if (authToken != null)
            {
                await _cacheService.InsertObject("AuthToken", authToken);
                await _cacheService.InsertObject("Email", Email);
                await NavToContacts();
            }
        }

        async Task<bool> NavToContacts()
        {
            try
            {
                return await this.PushPageAsNewInstanceAsync<ContactsPageViewModel>();
            }
            catch (Exception ex)
            {
                await Observable.Throw<Unit>(ex);
                return false;
            }
        }
    }
}