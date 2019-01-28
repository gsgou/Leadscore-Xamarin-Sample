using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using Leadscore.Models;
using Leadscore.Services;

namespace Leadscore.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel
    {
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
                .Do(_ => Debug.WriteLine(string.Format("{0},{1},{2}", Email, Password, CanLogin.ToString())))
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

        async Task LoginAsync()
        {
            var loginRequest = new LoginRequest()
            {
                Username = Email,
                Password = Password,
                Client = "LeadscoreApp"
            };
            var authToken = await _authenticationService.Login(loginRequest);

            await _cacheService.InsertObject("AuthToken", authToken);
            //var token = await _cacheService.GetObject<string>("AuthToken");
        }
    }
}