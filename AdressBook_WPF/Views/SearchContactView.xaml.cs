using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AdressBook_WPF.ViewModel;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;

namespace AdressBook_WPF.Views
{
    public partial class SearchContactView : Page
    {
        public SearchContactView()
        {
            InitializeComponent();

            // Definiera åtgärder
            Action<Contact> navigateToContactDetails = (contact) =>
            {
                // Kod för att navigera till kontaktdetaljer
            };

            Action navigateToMain = () =>
            {
                // Kod för att navigera tillbaka till huvudvyn
                if (this.NavigationService != null && this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
            };

            // Skapa en instans av SearchContactViewModel med de definierade åtgärderna
            var viewModel = new SearchContactViewModel(new AddressBookService(), navigateToContactDetails, navigateToMain);
            this.DataContext = viewModel;
        }
    }
}
