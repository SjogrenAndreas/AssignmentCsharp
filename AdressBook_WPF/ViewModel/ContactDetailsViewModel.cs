using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using System;
using System.Windows;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly Action<Contact> _navigateToEditContact;
    public Action CloseAction { get; set; } // En action för att stänga fönstret

    public ContactDetailsViewModel(Contact contact, Action<Contact> navigateToEditContact)
    {
        Contact = contact;
        _navigateToEditContact = navigateToEditContact;
    }

    [ObservableProperty]
    private Contact _contact;

    [ICommand]
    private void GoBack()
    {
        CloseAction?.Invoke(); // Stänger fönstret och går tillbaka
    }

    [ICommand]
    private void EditContact()
    {
        _navigateToEditContact?.Invoke(Contact); // Navigerar till EditContactView med den nuvarande kontakten
        CloseAction?.Invoke(); // Stänger ContactDetailsView
    }
}
