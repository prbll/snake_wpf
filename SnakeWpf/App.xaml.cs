using System.Windows;
using Model;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using RestSharp;
using SnakeWpf.ViewModels;
using SnakeWpf.Views;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace SnakeWpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private const string _uri = "http://safeboard.northeurope.cloudapp.azure.com";
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var container = containerRegistry.GetContainer();
            container.RegisterType<Service>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRestRequest, RestRequest>(new ContainerControlledLifetimeManager(),new InjectionConstructor(Method.GET));
            container.RegisterType<IRestClient, RestClient>(new ContainerControlledLifetimeManager(),new InjectionConstructor(_uri));
            container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MainWindow, MainWindowVm>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
