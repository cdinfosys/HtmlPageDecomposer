using System;
using System.Windows;
using System.Windows.Input;
using Prism.Events;

namespace HtmlPageDecomposer
{
    internal static class UserInterfaceCommands
    {
        /// <summary>
        ///     Event for the About menu item
        /// </summary>
        public static RoutedUICommand About = new RoutedUICommand();

        //public static RoutedCommand 
        static UserInterfaceCommands()
        {
            ApplicationCommands.SaveAs.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
        }
    } // class UserInterfaceCommands

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowView
    {
        private IEventAggregator eventAggregator;

        public MainWindow(IEventAggregator eventAggregator, IMainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            DataContext = viewModel;

            this.eventAggregator.GetEvent<ReportExceptionEvent>().Subscribe(ReportException);
        }

        private void ReportException(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SaveAsCommandHandler(Object sender, ExecutedRoutedEventArgs eventArgs)
        {
            MessageBox.Show(this, "Not implemented", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ExitCommandHandler(Object sender, ExecutedRoutedEventArgs eventArgs)
        {
            this.Close();
        }

        private void AboutCommandHandler(Object sender, ExecutedRoutedEventArgs eventArgs)
        {
            MessageBox.Show(this, "Not implemented", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
