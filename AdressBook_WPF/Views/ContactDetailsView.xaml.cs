using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using AdressBook_WPF.ViewModel;
using System;
using System.Windows.Controls;

namespace AdressBook_WPF.Views
{
    public partial class ContactDetailsView : Page
    {
        public ContactDetailsView(Contact contact, AddressBookService addressBookService)
        {
            InitializeComponent();
            var viewModel = new ContactDetailsViewModel(contact, addressBookService, NavigateToEditContact);
            this.DataContext = viewModel;

            viewModel.CloseAction = () =>
            {
                if (NavigationService != null && NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            };
        }

        private void NavigateToEditContact(Contact contact, AddressBookService addressBookService)
        {
            var editView = new EditContactView(addressBookService, contact);
            NavigationService.Navigate(editView);
        }
    }
}
