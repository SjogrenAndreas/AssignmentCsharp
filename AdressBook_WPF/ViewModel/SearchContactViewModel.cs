using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System;
using System.Linq;
using System.Windows;

public partial class SearchContactViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    private readonly Action<Contact> _navigateToContactDetails;
    private readonly Action _navigateToMain;

    public SearchContactViewModel(AddressBookService addressBookService,
                                  Action<Contact> navigateToContactDetails,
                                  Action navigateToMain)
    {
        _addressBookService = addressBookService;
        _navigateToContactDetails = navigateToContactDetails;
        _navigateToMain = navigateToMain;
    }

    [ObservableProperty]
    private string _emailToSearch;

    [RelayCommand]
    private void Search()
    {
        var foundContact = _addressBookService.GetAllContacts()
                            .FirstOrDefault(c => c.Email.Equals(EmailToSearch, StringComparison.OrdinalIgnoreCase));
        if (foundContact != null)
        {
            _navigateToContactDetails?.Invoke(foundContact);
        }
        else
        {
            MessageBox.Show("Could not find a contact with that email address", "Search Result", MessageBoxButton.OK);
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        _navigateToMain?.Invoke();
    }
}
