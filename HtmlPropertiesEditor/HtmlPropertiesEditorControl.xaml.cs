using System;
using System.Windows;
using System.Windows.Controls;

namespace HtmlPropertiesEditor
{
    /// <summary>
    ///     Composite control to edit the properties of an HTML element.
    /// </summary>
    public partial class HtmlPropertiesEditorControl : UserControl
    {
        #region Dependency property registration
            /// <summary>
            ///     Dependency property for the ElementContent property.
            /// </summary>
            public static readonly DependencyProperty ElementContentProperty =
                DependencyProperty.Register
                (
                    "ElementContent", 
                    typeof(String), 
                    typeof(HtmlPropertiesEditorControl),
                    new PropertyMetadata(String.Empty/*, OnElementContentChanged*/)
                );
        #endregion Dependency property registration

        #region Private data members
        #endregion // Private data members

        #region Construction
            /// <summary>
            ///     Default constructor.
            /// </summary>
            public HtmlPropertiesEditorControl()
            {
                InitializeComponent();
                this.DataContext = this;
            }
        #endregion Construction

        #region Properties
            /// <summary>
            ///     Gets or sets the content of the HTML element.
            /// </summary>
            public String ElementContent
            {
                get
                {
                    return (String)GetValue(ElementContentProperty);
                }
                set
                {
                    SetValue(ElementContentProperty, value);
                }
            }
        #endregion // Properties

        #region Private static methods
            /// <summary>
            ///     Called when the ElementContent property changes.
            /// </summary>
            /// <param name="eventArgs">
            ///     Information about the property that changed.
            /// </param>
            private static void OnElementContentChanged
            (
                DependencyObject dependencyObject,
                DependencyPropertyChangedEventArgs eventArgs
            )
            {
            }
        #endregion // Private static methods
    } // class HtmlPropertiesEditorControl
} // namespace HtmlPropertiesEditor
