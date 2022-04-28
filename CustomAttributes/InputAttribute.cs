// NOTE: DON'T put in an editor folder. //

// Originally created by Denis Rizov
// Modified by kiltec

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Display a list of input axes in the inspector: </para>
    /// <code>[Input]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Input select by name with string result: </para>
    /// <code>[Input] public string selectInput;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class InputAttribute : PropertyAttribute
    {

    }
}