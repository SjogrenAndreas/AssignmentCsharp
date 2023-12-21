using Xunit;
using AdressBook_Console.Models; 

public class ContactTests
{
    [Fact]
    public void ContactConstructor_InitializeProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "John";
        var lastName = "Doe";
        var email = "john@example.com";
        var phoneNumber = "555-1234";
        var streetName = "123 Main St";
        var postalCode = "12345";
        var city = "Sample City";

        // Act
        var contact = new Contact
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            StreetName = streetName,
            PostalCode = postalCode,
            City = city
        };

        // Assert
        Assert.Equal(id, contact.Id);
        Assert.Equal(firstName, contact.FirstName);
        Assert.Equal(lastName, contact.LastName);
        Assert.Equal(email, contact.Email);
        Assert.Equal(phoneNumber, contact.PhoneNumber);
        Assert.Equal(streetName, contact.StreetName);
        Assert.Equal(postalCode, contact.PostalCode);
        Assert.Equal(city, contact.City);
    }
}
