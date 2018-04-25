using System;

using FootketAPP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FootketAPP.Views
{
    public sealed partial class LoginPagePage : Page
    {
        private LoginPageViewModel ViewModel
        {
            get { return DataContext as LoginPageViewModel; }
        }

        public LoginPagePage()
        {
            InitializeComponent();
        }
    }
}
