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

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                HtmlPageDecomposer.Properties.Settings.Default.Save();
            }
            catch
            {
                // Don't do anything.
            }

            base.OnExit(e);
        }
    } // class App
} // namespace HtmlPageDecomposer
