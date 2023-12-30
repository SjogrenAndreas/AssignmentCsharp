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
        // Kontrollera först om sökfältet är tomt
        if (string.IsNullOrWhiteSpace(EmailToSearch))
        {
            MessageBox.Show("Please enter an email address to search.", "Search Error", MessageBoxButton.OK);
            return;
        }

        // Försök hämta kontaktlistan
        try
        {
            var contacts = _addressBookService.GetAllContacts();
            if (contacts == null || !contacts.Any())
            {
                MessageBox.Show("No contacts available to search.", "Search Error", MessageBoxButton.OK);
                return;
            }

            // Sök efter kontakten
            var foundContact = contacts.FirstOrDefault(c => c != null && c.Email != null && c.Email.ToLower() == EmailToSearch.ToLower());

            if (foundContact != null)
            {
                _navigateToContactDetails?.Invoke(foundContact);
            }
            else
            {
                MessageBox.Show("Could not find a contact with that email address", "Search Result", MessageBoxButton.OK);
            }
        }
        catch (Exception ex)
        {
            
            MessageBox.Show($"An error occurred while searching: {ex.Message}", "Search Error", MessageBoxButton.OK);
        }
    }


    [RelayCommand]
    private void Cancel()
    {
        _navigateToMain?.Invoke();
    }
}

