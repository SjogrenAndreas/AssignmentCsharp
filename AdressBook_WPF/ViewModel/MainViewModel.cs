using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Views;
using AdressBook_WPF.Services;
using System.Windows.Controls;
using System;

namespace AdressBook_WPF.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly AddressBookService _addressBookService;

        public Frame MainFrame { get; set; }

        public MainViewModel()
        {
            _addressBookService = new AddressBookService();
        }

        [RelayCommand]
        private void OpenAddContactView()
        {
            var view = new AddContactView();
            view.DataContext = new AddContactViewModel(_addressBookService);
            MainFrame.Navigate(view);
        }

        [RelayCommand]
        private void OpenViewAllContactsView()
        {
            var view = new ViewAllContactsView();
            view.DataContext = new ViewAllContactsViewModel(_addressBookService, NavigateToShowDetails, NavigateToMain);
            MainFrame.Navigate(view);
        }

        [RelayCommand]
        private void OpenSearchContactView()
        {
            var view = new SearchContactView();
            view.DataContext = new SearchContactViewModel(_addressBookService, NavigateToShowDetails, NavigateToMain);
            MainFrame.Navigate(view);
        }

        private void NavigateToShowDetails(Contact contact)
        {
            var view = new ContactDetailsView(contact, _addressBookService);
            MainFrame.Navigate(view);
        }

        private void NavigateToMain()
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}
