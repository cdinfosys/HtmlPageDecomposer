using System;
using System.IO;
using System.Net;
using System.Windows.Input;
using HtmlAgilityPack;
using Microsoft.Practices.Unity;
using Prism.Commands;
using System.Windows;
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
            ///     Stores a reference to the program's Unity container object.
            /// </summary>
            private IUnityContainer unityContainer;

            /// <summary>
            ///     Storage for the <c>DocumentURL</c> property
            /// </summary>
            private String documentURL;

            /// <summary>
            ///     Backing variable for the <c>IsReloadButtonEnabled</c> property
            /// </summary>
            private Boolean isReloadButtonEnabled = false;

            /// <summary>
            ///     Reference to the event aggregator object.
            /// </summary>
            private IEventAggregator eventAggregator;
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Construct a view model object for the main window.
            /// </summary>
            /// <param name="container">
            ///     Reference to a Unity container object.
            /// </param>
            public MainWindowViewModel(IEventAggregator eventAggregator, IUnityContainer container)
            {
                this.unityContainer = container;
                this.eventAggregator = eventAggregator;
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
                    return this.unityContainer.Resolve<IClientAreaView>(); 
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
                try
                {
                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.CreateHttp(DocumentURL);
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (Stream htmlStream = httpResponse.GetResponseStream())
                            {
                                HtmlDocument document = new HtmlDocument();
                                document.Load(htmlStream);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.eventAggregator.GetEvent<ReportExceptionEvent>().Publish(ex);
                }
            }
        #endregion // Private helper methods
    } // class MainWindowViewModel
} // namespace HtmlPageDecomposer
