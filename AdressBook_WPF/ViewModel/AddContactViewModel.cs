using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System.Windows;

public partial class AddContactViewModel : ObservableObject
{
    private readonly AddressBookService _addressBookService;
    public Action CloseAction { get; set; } // En action för att stänga fönstret

    public AddContactViewModel(AddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
    }

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

    [RelayCommand]
    private void Save()
    {
        var newContact = new Contact
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            PhoneNumber = this.PhoneNumber,
            StreetName = this.StreetName,
            PostalCode = this.PostalCode,
            City = this.City
        };

        _addressBookService.AddContact(newContact);
        CloseAction?.Invoke(); // Stänger fönstret efter att ha sparat kontakten
    }

    [RelayCommand]
    private void Cancel()
    {
        CloseAction?.Invoke(); // Stänger fönstret utan att spara
    }
}
