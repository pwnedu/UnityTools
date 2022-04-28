// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Display a note in the inspector: </para>
    /// <code>[Note("messageString", MessageLabelType, order = 1)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Display note with info icon: </para>
    /// <code>[Note("This is an informative message!", MessageLabel.Info)]</code>
    ///     </item>
    ///     <item>
    /// <para>Display note with warning icon: </para>
    /// <code>[Note("This is a warning message!", MessageLabel.Warning)]</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class NoteAttribute : PropertyAttribute
    {
        public string Text = string.Empty;
        public MessageLabel Message = MessageLabel.None;

        public NoteAttribute(string text)
        {
            Text = text;
        }

        public NoteAttribute(string text, MessageLabel message)
        {
            Text = text;
            Message = message;
        }
    }

    public enum MessageLabel
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3
    }
}