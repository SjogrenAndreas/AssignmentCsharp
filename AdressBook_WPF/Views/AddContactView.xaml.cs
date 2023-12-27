using AdressBook_WPF.Services;
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

namespace AdressBook_WPF.Views
{
    /// <summary>
    /// Interaction logic for AddContactView.xaml
    /// </summary>
    public partial class AddContactView : Window
    {
        public AddContactView()
        {
            InitializeComponent();
            var viewModel = new AddContactViewModel(addressBookService);
            viewModel.CloseAction = new Action(this.Close); // Ställer in CloseAction
            DataContext = viewModel;
        }
    }
}
