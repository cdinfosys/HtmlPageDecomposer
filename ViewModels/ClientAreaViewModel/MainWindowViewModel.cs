using System;
using System.IO;
using System.Net;
using System.Windows.Input;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     View model class for the main view of the program.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Private data members
            /// <summary>
            ///     Storage for the <c>DocumentURL</c> property
            /// </summary>
            private String documentURL;

            /// <summary>
            ///     Backing variable for the <c>IsReloadButtonEnabled</c> property
            /// </summary>
            private Boolean isReloadButtonEnabled = false;

            /// <summary>
            ///     Reference to the data store object.
            /// </summary>
            private IDataStore dataStore;
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Construct a view model object for the main window.
            /// </summary>
            /// <param name="eventAggregator">
            ///     Reference to a Unity event aggregator object.
            /// </param>
            /// <param name="container">
            ///     Reference to a Unity container object.
            /// </param>
            public MainWindowViewModel(IEventAggregator eventAggregator, IUnityContainer container)
                :   base(eventAggregator, container)
            {
                dataStore = container.Resolve<IDataStore>();
                DocumentURL = Properties.Settings.Default.LastUsedURL;
            }
        #endregion // Construction

        #region Public properties
            /// <summary>
            ///     Gets the view object for the client area (HTML editor and friends).
            /// </summary>
            public IClientAreaView ClientAreaContainerView
            {
                get 
                { 
                    return this.UnityContainer.Resolve<IClientAreaView>(); 
                }
            }

            /// <summary>
            ///     Gets the <c>DelegateCommand</c> object that handles click events on the Reload URL button.
            /// </summary>
            public ICommand ReloadHtmlFromURLCommand
            {
                get
                {
                    return new DelegateCommand(ReloadHtmlFromURLCommandHandler);
                }
            }

            /// <summary>
            ///     Gets or sets the URL to the HTML document
            /// </summary>
            public String DocumentURL
            {
                get
                {
                    return this.documentURL;
                }
                set
                {
                    this.documentURL = value.Trim();
                    IsReloadButtonEnabled = (!String.IsNullOrWhiteSpace(this.documentURL));
                    Properties.Settings.Default.LastUsedURL = documentURL;
                    RaisePropertyChanged();
                }
            }

            /// <summary>
            ///     Gets or sets a flag that controls the enabled state of the Reload URL button.
            /// </summary>
            public Boolean IsReloadButtonEnabled
            {
                get
                {
                    return this.isReloadButtonEnabled;
                }
                private set
                {
                    this.isReloadButtonEnabled = value;
                    RaisePropertyChanged();
                }
            }
        #endregion // Public properties

        #region Private helper methods
            /// <summary>
            ///     Event handler for the click event of the Reload URL button
            /// </summary>
            private void ReloadHtmlFromURLCommandHandler()
            {
                // Store the current enabled state of the reload button
                Boolean reloadButtonEnabled = this.IsReloadButtonEnabled;

                // Disable the reload button while the document is loading.
                this.IsReloadButtonEnabled = false;
                try
                {
                    this.dataStore.LoadHtmlFromURL(this.DocumentURL);
                    this.EventAggregator.GetEvent<HtmlDocumentLoadedEvent>().Publish();
                }
                catch (Exception ex)
                {
                    // Report the exception
                    this.EventAggregator.GetEvent<ReportExceptionEvent>().Publish(ex);
                }
                finally
                {
                    // Restore the button to its previous enabled state
                    this.IsReloadButtonEnabled = reloadButtonEnabled;
                }
            }
        #endregion // Private helper methods
    } // class MainWindowViewModel
} // namespace HtmlPageDecomposer
