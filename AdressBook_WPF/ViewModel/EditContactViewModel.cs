using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System;

public partial class EditContactViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    private Contact _contact; // Referens till den kontakt som redigeras

    public Action CloseAction { get; set; } // En action för att stänga fönstret

    [ObservableProperty]
    private string firstName;
    [ObservableProperty]
    private string lastName;
    [ObservableProperty]
    private string email;
    [ObservableProperty]
    private string phoneNumber;
    [ObservableProperty]
    private string streetName;
    [ObservableProperty]
    private string postalCode;
    [ObservableProperty]
    private string city;

    public EditContactViewModel(AddressBookService addressBookService, Contact contactToEdit)
    {
        _addressBookService = addressBookService;
        _contact = contactToEdit; // Sätt referensen till den befintliga kontakten

        // Initialisera egenskaper med värden från den befintliga kontakten
        FirstName = contactToEdit.FirstName;
        LastName = contactToEdit.LastName;
        Email = contactToEdit.Email;
        PhoneNumber = contactToEdit.PhoneNumber;
        StreetName = contactToEdit.StreetName;
        PostalCode = contactToEdit.PostalCode;
        City = contactToEdit.City;
    }

    [RelayCommand]
    private void SaveEdit()
    {
        // Skapa ett uppdaterat Contact-objekt
        var updatedContact = new Contact
        {
            Id = _contact.Id, // Behåll samma ID
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            StreetName = StreetName,
            PostalCode = PostalCode,
            City = City
        };

        // Uppdatera kontakten via service
        _addressBookService.UpdateContact(updatedContact);
        CloseAction?.Invoke(); // Stänger fönstret
    }

    [RelayCommand]
    private void RemoveContact()
    {
        _addressBookService.DeleteContact(_contact); // Ta bort den aktuella kontakten
        CloseAction?.Invoke(); // Stänger fönstret
    }

    [RelayCommand]
    private void Cancel()
    {
        CloseAction?.Invoke(); // Stänger fönstret utan att spara
    }
}
