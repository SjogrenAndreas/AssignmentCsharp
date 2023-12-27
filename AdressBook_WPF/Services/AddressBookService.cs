using AdressBook_WPF.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdressBook_WPF.Services
{
    public class AddressBookService
    {
        private readonly string _filePath;
        private List<Contact> _contacts;

        public AddressBookService()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _filePath = Path.Combine(desktopPath, "addressbook.json");
            _contacts = new List<Contact>();

            LoadContactsFromFile();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            SaveContactsToFile();
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = _contacts.Find(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                _contacts[_contacts.IndexOf(existingContact)] = contact;
                SaveContactsToFile();
            }
        }

        public void DeleteContact(Contact contact)
        {
            _contacts.Remove(contact);
            SaveContactsToFile();
        }

        private void LoadContactsFromFile()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
            }
        }

        private void SaveContactsToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_contacts, options);
            File.WriteAllText(_filePath, json);
        }
    }
}
