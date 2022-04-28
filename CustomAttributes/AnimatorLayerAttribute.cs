// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this Animator Layer Attribute to display a list of the animator's layer strings. </para>
    /// <code>[AnimatorLayer(logChangesToConsole)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Select animation parameter by name with string result: </para>
    /// <code>[AnimatorLayer] public string animatorParameter;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class AnimatorLayerAttribute : PropertyAttribute
    {
        public bool debug;

        public AnimatorLayerAttribute()
        {
            debug = false;
        }

        public AnimatorLayerAttribute(bool logToConsole)
        {
            debug = logToConsole;
        }
    }
}