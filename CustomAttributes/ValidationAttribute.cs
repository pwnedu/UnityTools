// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// <para>Use this PropertyAttribute for string validation by Regular Expression: </para>
    /// <para>For more information on Regular Expressions: <seealso href="https://regexlib.com/Search.aspx">Regex Library</seealso></para>
    /// <code>[Validation(RegexStringMatch, "InvalidEntryErrorString")]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Specified IP Address Field: </para>
    /// <code>[Validation(@"^(?:\d{1,3}\.){3}\d{1,3}$", "Invalid IP address!\nExample: '127.0.0.1'")] private string myIP;</code>
    ///     </item>
    ///     <item>
    /// <para>Specified Email Address Field: </para>
    /// <code>[Validation(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", "Invalid email address!\nExample: 'mail@domain.tld'")] private string myEmail;</code>
    ///     </item>
    ///     <item>
    /// <para>Specified Email Address Field: </para>
    /// <code>[Validation(@"^\+?([0-9]{2,3})\)?[-. ]?([0-9]{2,4})[-. ]?([0-9]{4,6})$", "Invalid phone number!\nExample: '+123 1234 123456'")] private string myPhone;</code>
    ///     </item>
    ///     <item>
    /// <para>Specified Letters Only Field: </para>
    /// <code>[Validation(@"^([a-zA-Z]+)$", "Field must contain only letters!")] private string myAlphabetString;</code>
    ///     </item>
    ///     <item>
    /// <para>Specified Numbers Only Field: </para>
    /// <code>[Validation(@"^([0-9]+)$", "Field must contain only letters!")] private string myNumericString;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class ValidationAttribute : PropertyAttribute
    {
        public string pattern;
        public string message;
        public float height;

        public ValidationAttribute(string regexPattern, string helpMessage)
        {
            pattern = regexPattern;
            message = helpMessage;
            height = 60;
        }

        public ValidationAttribute(string regexPattern, string helpMessage, float messageHeight)
        {
            pattern = regexPattern;
            message = helpMessage;
            height = messageHeight;
        }
    }
}