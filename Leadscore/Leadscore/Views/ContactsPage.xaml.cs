using Leadscore.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamvvm;

namespace Leadscore.Views
{
    public partial class ContactsPage : ContentPage, IBasePageRxUI<ContactsPageViewModel>
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        public ContactsPageViewModel ViewModel { get; set; }
        object IViewFor.ViewModel { get; set; }
    }
}