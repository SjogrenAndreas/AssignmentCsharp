using AdressBook_WPF.Services;
using System;
using System.Windows.Controls;

namespace AdressBook_WPF.Views
{
    public partial class AddContactView : Page
    {
        public AddContactView()
        {
            InitializeComponent();
            var addressBookService = new AddressBookService();
            var viewModel = new AddContactViewModel(addressBookService);
            viewModel.CloseAction = new Action(() => {
                // NavigationService för att navigera tillbaka eller till en annan sida
                if (this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
                
            });
            DataContext = viewModel;
        }
    }
}
