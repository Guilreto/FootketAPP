using System;
using FootketAPP.ViewModels;
using Windows.UI.Xaml.Controls;
using FootketAPP.Models;
using FootketAPP.Helpers;
using Windows.UI.Popups;

namespace FootketAPP.Views
{
    public sealed partial class LoginPagePage : Page
    {
        Database db;

        private LoginPageViewModel ViewModel
        {
            get { return DataContext as LoginPageViewModel; }
        }

        public LoginPagePage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private async void btnLogin_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(db.Login(txtUser.Text, txtPassword.Password))
            {
                var message = new MessageDialog("Login Correcto");
                await message.ShowAsync();
            } else
            {
                var message = new MessageDialog("Login Incorrecto");
                await message.ShowAsync();
            }
        }

        private void btnRegister_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPagePage));
        }
    }
}
