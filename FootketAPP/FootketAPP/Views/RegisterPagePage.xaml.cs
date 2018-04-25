

namespace FootketAPP.Views
{
    using System;
    using FootketAPP.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Helpers;
    using Models;
    using Windows.UI.Popups;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Core;

    public sealed partial class RegisterPagePage : Page
    {
        Database db;

        private RegisterPageViewModel ViewModel
        {
            get { return DataContext as RegisterPageViewModel; }
        }

        public RegisterPagePage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().BackRequested += RegisterPagePage_BackRequested;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= RegisterPagePage_BackRequested;

        }

        private void RegisterPagePage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private async void BtnRegister_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            int code = db.Register(new UserModel()
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Password.Trim(),
                Email = txtEmail.Text.Trim()
            });
            if (code == -1)
            {
                var message = new MessageDialog("Registro Erroneo");
                await message.ShowAsync();
            } else
            {
                var message = new MessageDialog("Registro Correcto");
                await message.ShowAsync();
            }
        }
    }
}
