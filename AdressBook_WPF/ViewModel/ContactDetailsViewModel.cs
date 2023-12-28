using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.ViewModel;
using AdressBook_WPF.Services;
using System;


public partial class ContactDetailsViewModel : ObservableObject
{
    public ContactDetailsViewModel(Contact contact)
    {
        Contact = contact;
    }

    [ObservableProperty]
    private Contact _contact;

    [ICommand]
    private void GoBack()
    {
        CloseAction?.Invoke(); // Stänger fönstret och går tillbaka
    }

    public Action CloseAction { get; set; } // En action för att stänga fönstret
}
