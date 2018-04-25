using System;

using CommonServiceLocator;

using FootketAPP.Services;
using FootketAPP.Views;

using GalaSoft.MvvmLight.Ioc;

namespace FootketAPP.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<LoginPageViewModel, LoginPagePage>();
            Register<RegisterPageViewModel, RegisterPagePage>();
        }

        public RegisterPageViewModel RegisterPageViewModel => ServiceLocator.Current.GetInstance<RegisterPageViewModel>();

        public LoginPageViewModel LoginPageViewModel => ServiceLocator.Current.GetInstance<LoginPageViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
