using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using AdressBook_WPF.ViewModel;
using System.Windows.Controls;

namespace AdressBook_WPF.Views
{
    public partial class EditContactView : Page
    {
        public EditContactView(AddressBookService addressBookService, Contact contactToEdit)
        {
            InitializeComponent();

            // Skapa ViewModel och sätt som DataContext
            var viewModel = new EditContactViewModel(addressBookService, contactToEdit);
            this.DataContext = viewModel;

            // Hantera stängning av sidan
            viewModel.CloseAction = () => {
                if (this.NavigationService != null && this.NavigationService.CanGoBack)
                {
                    this.NavigationService.GoBack();
                }
            };
        }
    }
}
