// NOTE: DON'T put in a Editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// <para>Use this PropertyAttribute to display a tag list in the inspector: </para>
    /// <code>[Tag]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Tag select by name with string result: </para>
    /// <code>[Tag] public string selectTag;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class TagAttribute : PropertyAttribute
    {

    }
}