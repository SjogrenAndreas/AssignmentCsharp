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

            
            Action<Contact> navigateToContactDetails = (contact) =>
            {
              
            };

            Action navigateToMain = () =>
            {
                
                if (this.NavigationService != null && this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
            };

           
            var viewModel = new SearchContactViewModel(new AddressBookService(), navigateToContactDetails, navigateToMain);
            this.DataContext = viewModel;
        }
    }
}
