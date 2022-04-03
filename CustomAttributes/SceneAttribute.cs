// NOTE: DON'T put in a Editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this PropertyAttribute to display a scene list in the inspector: </para>
    /// <code>[Scene(logToConsoleBool)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Scene select by name with string result: </para>
    /// <code>[Scene] public string selectSceneByName;</code>
    ///     </item>
    ///     <item>
    /// <para>Scene select by name with int result: </para>
    /// <code>[Scene] public int selectSceneByIndex;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class SceneAttribute : PropertyAttribute
    {
        public bool debug;

        public SceneAttribute()
        {
            debug = false;
        }

        public SceneAttribute(bool logToConsole)
        {
            debug = logToConsole;
        }
    }
}