using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AdressBook_WPF.Views
{
    /// <summary>
    /// Interaction logic for SearchContactView.xaml
    /// </summary>
    public partial class SearchContactView : Page
    {
        public SearchContactView()
        {
            InitializeComponent();
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Enter Email to Search")
            {
                textBox.Text = "";
                textBox.FontStyle = FontStyles.Normal;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter Email to Search";
                textBox.FontStyle = FontStyles.Italic;
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}
