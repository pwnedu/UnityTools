// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Change the format and colour of text in the inspector</para>
    /// <code>[Format("colourString", boldBool, italicBool, indentBool)]</code>
    /// <para>Default Colours:</para>
    /// <code> "red", "green", "blue", "yellow", "cyan", "magenta", "white", "grey", "black", "clear"</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Text colour cyan, bold weight, italic style, right justified: </para> 
    /// <code>[Format("cyan", true, true, true)] public string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Text colour yellow, normal weight, italic style, left justified: </para>
    /// <code>[Format("yellow", false, true)] public string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Text colour grey, bold weight, plain style, left justified: </para>
    /// <code>[Format("grey", true)] public string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Text colour normal, bold weight, italic style, right justified: </para>
    /// <code>[Format(true, true, true)] public string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Text colour normal, bold weight, italic style, left justified: </para>
    /// <code>[Format(true, true)] public string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Text colour normal, bold weight, plain style, left justified: </para>
    /// <code>[Format(true)] public string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Text invisible: </para>
    /// <code>[Format("clear")] public string myString;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class FormatAttribute : PropertyAttribute
    {
        public string colour;
        public bool bold;
        public bool italic;
        public bool indent;

        public FormatAttribute()
        {
            colour = null;
            bold = false;
            italic = false;
            indent = false;
        }

        public FormatAttribute(bool boldText)
        {
            colour = null;
            bold = boldText;
            italic = false;
            indent = false;
        }

        public FormatAttribute(bool boldText, bool italicText)
        {
            colour = null;
            bold = boldText;
            italic = italicText;
            indent = false;
        }

        public FormatAttribute(bool boldText, bool italicText, bool indentText)
        {
            colour = null;
            bold = boldText;
            italic = italicText;
            indent = indentText;
        }

        public FormatAttribute(string textColour)
        {
            colour = textColour;
            bold = false;
            italic = false;
            indent = false;
        }

        public FormatAttribute(string textColour, bool boldText)
        {
            colour = textColour;
            bold = boldText;
            italic = false;
            indent = false;
        }

        public FormatAttribute(string textColour, bool boldText, bool italicText)
        {
            colour = textColour;
            bold = boldText;
            italic = italicText;
            indent = false;
        }

        public FormatAttribute(string textColour, bool boldText, bool italicText, bool indentText)
        {
            colour = textColour;
            bold = boldText;
            italic = italicText;
            indent = indentText;
        }
    }
}