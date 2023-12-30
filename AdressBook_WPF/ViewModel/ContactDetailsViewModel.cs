using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly Action<Contact, AddressBookService> _navigateToEditContact;
    private readonly AddressBookService _addressBookService;
    public Action CloseAction { get; set; } // En action för att stänga fönstret

    public ContactDetailsViewModel(Contact contact, AddressBookService addressBookService, Action<Contact, AddressBookService> navigateToEditContact)
    {
        Contact = contact;
        _addressBookService = addressBookService;
        _navigateToEditContact = navigateToEditContact;
    }

    [ObservableProperty]
    private Contact _contact;

    [RelayCommand]
    private void GoBack()
    {
        CloseAction?.Invoke(); // Stänger fönstret och går tillbaka
    }

    [RelayCommand]
    private void EditContact()
    {
        _navigateToEditContact?.Invoke(Contact, _addressBookService);
    }
}
