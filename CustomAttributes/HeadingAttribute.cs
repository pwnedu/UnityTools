// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this property attribute to create a customisable header in the inspector: </para>
    /// <code>[Heading("colourString", fontSize, boldBool, italicBool, centeredBool, order = 1)]</code>
    /// <para>Available Colours: </para>
    /// <code> "red", "green", "blue", "yellow", "magenta", "cyan", "white", "grey", "black", "clear"</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Heading colour green, font size 18, font style bold, left justified </para>
    /// <code>[Heading("green", "The Heading", 18, true)]</code>
    ///     </item>
    ///     <item>
    /// <para>Heading colour cyan, font size 16, font style bold, italic, centered </para> 
    /// <code>[Heading("cyan", "The Heading", 16, true, true, true)]</code>
    ///     </item>
    ///     <item>
    /// <para>Heading orange, size 16, bold style, centered, order 1 and sub heading yellow, size 14, normal style, centered, order 2: </para>
    /// <code>[Heading("orange", "The Heading", 18, true, false, true, order = 1)]</code>
    /// <code>[Heading("yellow", "The Sub Heading", 14, false, false, true, order = 2)]</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class HeadingAttribute : PropertyAttribute
    {
        public string colour;
        public string header;
        public int size;
        public bool bold;
        public bool italic;
        public bool center;

        public HeadingAttribute(string headingText)
        {
            colour = null;
            header = headingText;
            size = 0;
            bold = true;
            italic = false;
            center = false;
        }

        public HeadingAttribute(string headingColour, string headingText)
        {
            colour = headingColour;
            header = headingText;
            size = 0;
            bold = true;
            italic = false;
            center = false;
        }

        public HeadingAttribute(string headingColour, string headingText, int fontSize)
        {
            colour = headingColour;
            header = headingText;
            size = fontSize;
            bold = true;
            italic = false;
            center = false;
        }

        public HeadingAttribute(string headingColour, string headingText, int fontSize, bool boldText)
        {
            colour = headingColour;
            header = headingText;
            size = fontSize;
            bold = boldText;
            italic = false;
            center = false;
        }

        public HeadingAttribute(string headingColour, string headingText, int fontSize, bool boldText, bool italicText)
        {
            colour = headingColour;
            header = headingText;
            size = fontSize;
            bold = boldText;
            italic = italicText;
            center = false;
        }

        public HeadingAttribute(string headingColour, string headingText, int fontSize, bool boldText, bool italicText, bool centerText)
        {
            colour = headingColour;
            header = headingText;
            size = fontSize;
            bold = boldText;
            italic = italicText;
            center = centerText;
        }
    }
}