using Leadscore.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamvvm;

namespace Leadscore.Views
{
    public partial class LoginPage : ContentPage, IBasePageRxUI<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPageViewModel ViewModel { get; set; }
        object IViewFor.ViewModel { get; set; }
    }
}