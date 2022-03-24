// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Disable a field from being edited in the inspector</para>
    /// <code>[Disable]</code>
    /// </summary>
    public class DisableAttribute : PropertyAttribute { }
}