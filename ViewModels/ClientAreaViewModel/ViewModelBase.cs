using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HtmlPageDecomposer
{
    /// <summary>
    ///     Base class for view model classes
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        ///     This event is fired when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
    } // class ViewModelBase
} // namespace HtmlPageDecomposer
