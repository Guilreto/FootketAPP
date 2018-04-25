using System;

using FootketAPP.Services;
using FootketAPP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FootketAPP.Views
{
    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel
        {
            get { return DataContext as ShellViewModel; }
        }

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame);
        }
    }
}
