using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System;
using System.Windows;

public partial class EditContactViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    public Action CloseAction { get; set; } // En action för att stänga fönstret

    public EditContactViewModel(AddressBookService addressBookService, Contact contactToEdit)
    {
        _addressBookService = addressBookService;
        Contact = contactToEdit;
    }

    [ObservableProperty]
    private Contact _contact;

    [ICommand]
    private void SaveEdit()
    {
        _addressBookService.UpdateContact(Contact);
        CloseAction?.Invoke(); // Stänger fönstret
    }

    [ICommand]
    private void RemoveContact()
    {
        _addressBookService.DeleteContact(Contact);
        CloseAction?.Invoke(); // Stänger fönstret
    }

    [ICommand]
    private void Cancel()
    {
        CloseAction?.Invoke(); // Stänger fönstret utan att spara
    }
}
