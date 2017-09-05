using System;
using System.Windows;
using Microsoft.Practices.Unity;

namespace HtmlPageDecomposer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            base.OnStartup(eventArgs);
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    } // class App
} // namespace HtmlPageDecomposer
