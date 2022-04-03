// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this PropertyAttribute to change the field name shown in the inspector</para>
    /// <code>[DisplayAs("New Name")]</code>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class DisplayAsAttribute : PropertyAttribute
    {
        public readonly string attributeName;

        public DisplayAsAttribute(string attributeName)
        {
            this.attributeName = attributeName;
        }
    }
}