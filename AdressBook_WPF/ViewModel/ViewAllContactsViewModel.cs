using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System.Collections.ObjectModel;
using System;

public partial class ViewAllContactsViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    private readonly Action<Contact> _navigateToShowDetails;
    private readonly Action _goBackToMain;

    public ViewAllContactsViewModel(AddressBookService addressBookService,
                                    Action<Contact> navigateToShowDetails,
                                    Action goBackToMain)
    {
        _addressBookService = addressBookService;
        _navigateToShowDetails = navigateToShowDetails;
        _goBackToMain = goBackToMain;
        Contacts = new ObservableCollection<Contact>(_addressBookService.GetAllContacts());
    }

    public ObservableCollection<Contact> Contacts { get; }

    [ICommand]
    private void ShowDetails(Contact contact)
    {
        _navigateToShowDetails?.Invoke(contact);
    }

    [ICommand]
    private void GoBackToMain()
    {
        _goBackToMain?.Invoke();
    }
}
