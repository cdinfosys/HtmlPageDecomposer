using System;

namespace HtmlPageDecomposer
{
    // Identifiers for attribute types
    public enum AttributeTypeIdentifier
    {
        Unknown = 0,
        Generic,
        href,
        rel
    }

    /// <summary>
    ///     Interface for classes that represent HTML element attributes.
    /// </summary>
    public interface IHtmlAttribute
    {
        /// <summary>
        ///     Get a value that identifies the attribute type
        /// </summary>
        AttributeTypeIdentifier AttributeType { get; }
    } // interface IHtmlAttribute
} // namespace HtmlPageDecomposer
