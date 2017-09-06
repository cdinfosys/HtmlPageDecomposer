using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Base class for view model classes
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        ///     This event is fired when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion // Events

        #region Private data members

        /// <summary>
        ///     Stores a reference to the program's Unity container object.
        /// </summary>
        private IUnityContainer unityContainer;

        /// <summary>
        ///     Reference to the event aggregator object.
        /// </summary>
        private IEventAggregator eventAggregator;

        #endregion // Private data members

        #region Construction

        /// <summary>
        ///     Construct a view model with a reference to a Unity container and an event aggregator
        /// </summary>
        /// <param name="unityContainer">Unity container object</param>
        /// <param name="eventAggregator">Unity event aggregator</param>
        protected ViewModelBase(IEventAggregator eventAggregator, IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            this.eventAggregator = eventAggregator;
        }
        #endregion Construction

        #region Protected properties

        /// <summary>
        ///     Gets a reference to the unity container object.
        /// </summary>
        protected IUnityContainer UnityContainer => this.unityContainer;

        /// <summary>
        ///     Gets a reference to the Unity event aggregator object.
        /// </summary>
        protected IEventAggregator EventAggregator => this.eventAggregator;

        #endregion Protected properties

        #region Protected helper methods

        /// <summary>
        ///     Fire the PropertyChanged event for a specific property
        /// </summary>
        /// <param name="propertyName">
        ///     Name of the property that changed.
        /// </param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Protected helper methods
    } // class ViewModelBase
} // namespace HtmlPageDecomposer
