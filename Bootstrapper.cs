using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace HtmlPageDecomposer
{
    public class Bootstrapper : UnityBootstrapper 
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Register the data store
            this.Container.RegisterType<IDataStore, DataStore>(new ContainerControlledLifetimeManager());

            RegisterViews();
            RegisterViewModels();
        }

        private void RegisterViews()
        {
            this.Container.RegisterType<IMainWindowView, MainWindow>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IClientAreaView, ClientAreaView>(new ContainerControlledLifetimeManager());
        }

        private void RegisterViewModels()
        {
            this.Container.RegisterType<IMainWindowViewModel, MainWindowViewModel>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IClientAreaViewModel, ClientAreaViewModel>(new ContainerControlledLifetimeManager());
        }
    }
}
