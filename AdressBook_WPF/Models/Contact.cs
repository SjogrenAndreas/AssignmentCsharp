using System;

namespace AdressBook_WPF.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        // Fullständigt namn, består av förnamn och efternamn
        public string FullName => $"{FirstName} {LastName}";
    }
}
