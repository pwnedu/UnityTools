// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this PropertyAttribute to change the format and colour of text in the inspector</para>
    /// <code>[Format("textColour", "fieldColour", boldBool, italicBool, indentBool)]</code>
    /// <para>Default Colours:</para>
    /// <code> "red", "green", "blue", "yellow", "cyan", "magenta", "white", "grey", "black", "clear"</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Text colour cyan, background colour blue, bold weight, italic style, right justified: </para> 
    /// <code>[Format("cyan", "blue", true, true, true)] public string myString;</code>
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
    /// <para>Text invisible, background red: </para>
    /// <code>[Format("clear", "red")] public string myString;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class FormatAttribute : PropertyAttribute
    {
        public string colour;
        public string bgColour;
        public bool bold;
        public bool italic;
        public bool indent;

        public FormatAttribute()
        {
            colour = null;
            bgColour = null;
            bold = false;
            italic = false;
            indent = false;
        }

        public FormatAttribute(bool boldText)
        {
            colour = null;
            bgColour = null;
            bold = boldText;
            italic = false;
            indent = false;
        }

        public FormatAttribute(bool boldText, bool italicText)
        {
            colour = null;
            bgColour = null;
            bold = boldText;
            italic = italicText;
            indent = false;
        }

        public FormatAttribute(bool boldText, bool italicText, bool indentText)
        {
            colour = null;
            bgColour = null;
            bold = boldText;
            italic = italicText;
            indent = indentText;
        }

        public FormatAttribute(string textColour)
        {
            colour = textColour;
            bgColour = null;
            bold = false;
            italic = false;
            indent = false;
        }

        public FormatAttribute(string textColour, bool boldText)
        {
            colour = textColour;
            bgColour = null;
            bold = boldText;
            italic = false;
            indent = false;
        }

        public FormatAttribute(string textColour, bool boldText, bool italicText)
        {
            colour = textColour;
            bgColour = null;
            bold = boldText;
            italic = italicText;
            indent = false;
        }

        public FormatAttribute(string textColour, bool boldText, bool italicText, bool indentText)
        {
            colour = textColour;
            bgColour = null;
            bold = boldText;
            italic = italicText;
            indent = indentText;
        }

        public FormatAttribute(string textColour, string backgroundColour)
        {
            colour = textColour;
            bgColour = backgroundColour;
            bold = false;
            italic = false;
            indent = false;
        }

        public FormatAttribute(string textColour, string backgroundColour, bool boldText)
        {
            colour = textColour;
            bgColour = backgroundColour;
            bold = boldText;
            italic = false;
            indent = false;
        }

        public FormatAttribute(string textColour, string backgroundColour, bool boldText, bool italicText)
        {
            colour = textColour;
            bgColour = backgroundColour;
            bold = boldText;
            italic = italicText;
            indent = false;
        }

        public FormatAttribute(string textColour, string backgroundColour, bool boldText, bool italicText, bool indentText)
        {
            colour = textColour;
            bgColour = backgroundColour;
            bold = boldText;
            italic = italicText;
            indent = indentText;
        }
    }
}