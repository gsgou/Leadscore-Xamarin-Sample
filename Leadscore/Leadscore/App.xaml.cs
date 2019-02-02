using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;

using Leadscore.Interfaces;
using Leadscore.Services;
using Leadscore.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Leadscore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterServicesAndProviders();

            MainPage = new NavigationPage(this.GetPageFromCache<LoginPageViewModel>() as Page);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        void RegisterServicesAndProviders()
        {
            Locator.CurrentMutable.RegisterConstant(
                new RestPoolService(), typeof(IRestPoolService));

            var factory = new XamvvmFormsRxUIFactory(this);
            XamvvmCore.SetCurrentFactory(factory);
        }
    }
}