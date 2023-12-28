using AdressBook_WPF.ViewModel;
using AdressBook_WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AdressBook_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost? builder;

        public App()
        {
            builder = Host.CreateDefaultBuilder()
                .ConfigureServices (services =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<AddContactView>();
                    services.AddSingleton<AddContactViewModel>();
                    services.AddSingleton<ContactDetailsView>();
                    services.AddSingleton<ContactDetailsViewModel>();
                    services.AddSingleton<EditContactView>();
                    services.AddSingleton<EditContactViewModel>();
                    services.AddSingleton<SearchContactView>();
                    services.AddSingleton<SearchContactViewModel>();
                    services.AddSingleton<ViewAllContactsView>();
                    services.AddSingleton<ViewAllContactsViewModel>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
           builder!.Start();

            var mainWindow = builder!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
