using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdressBook_WPF.Models;
using AdressBook_WPF.Services;

namespace AdressBook_WPF.Views
{
    /// <summary>
    /// Interaction logic for EditContactView.xaml
    /// </summary>
    public partial class EditContactView : Window
    {
        public EditContactView(AddressBookService addressBookService, Contact contactToEdit)
        {
            InitializeComponent();

            var viewModel = new EditContactViewModel(addressBookService, contactToEdit);
            viewModel.CloseAction = new Action(this.Close);
            DataContext = viewModel;
        }
    }
}
