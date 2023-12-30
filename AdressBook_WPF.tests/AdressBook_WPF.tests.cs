using Xunit;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;
using System;
using System.Linq;

public class AddressBookServiceTests
{
    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        // Arrange
        var service = new AddressBookService(); 
        var testContact = new Contact
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test@example.com"
            
        };

        // Act
        service.AddContact(testContact);

        // Assert
        var result = service.GetAllContacts().Any(c => c.Email == "test@example.com");
        Assert.True(result);
    }

    
}
