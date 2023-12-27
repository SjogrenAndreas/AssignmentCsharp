using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls; // Används för att hantera Frame-navigering
using System; // För EventHandler

namespace AdressBook_WPF.ViewModel
{
    // MainViewModel ärver från ObservableObject för att stödja data bindning
    public partial class MainViewModel : ObservableObject
    {
        // Property för Frame som kommer att användas för navigering
        public Frame MainFrame { get; set; }

        // Konstruktor
        public MainViewModel()
        {
            // Initiera commands här om det behövs
        }

        // Command för att öppna AddContactView
        [ICommand]
        private void OpenAddContactView()
        {
            var view = new AddContactView(); // Ersätt med din faktiska vy
            view.DataContext = new AddContactViewModel(); // Ersätt med din faktiska ViewModel
            MainFrame.Navigate(view); // Navigerar till den angivna vyn
        }

        // Command för att öppna ViewAllContactsView
        [ICommand]
        private void OpenViewAllContactsView()
        {
            var view = new ViewAllContactsView(); // Ersätt med din faktiska vy
            view.DataContext = new ViewAllContactsViewModel(); // Ersätt med din faktiska ViewModel
            MainFrame.Navigate(view); // Navigerar till den angivna vyn
        }

        // Command för att öppna SearchContactView
        [ICommand]
        private void OpenSearchContactView()
        {
            var view = new SearchContactView(); // Ersätt med din faktiska vy
            view.DataContext = new SearchContactViewModel(); // Ersätt med din faktiska ViewModel
            MainFrame.Navigate(view); // Navigerar till den angivna vyn
        }
    }
}
