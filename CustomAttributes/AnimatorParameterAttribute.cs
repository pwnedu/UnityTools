// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this Animator Paramater Attribute to display a list of the animator's parameter strings. </para>
    /// <code>[AnimatorParameter(showParameterType, logChangesToConsole, ParameterType.type)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Select animation parameter by name with string result: </para>
    /// <code>[AnimatorParameter] public string animatorParameter;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class AnimatorParameterAttribute : PropertyAttribute
    {
        public ParameterType parameterType;
        public bool displayType;
        public bool debug;

        public AnimatorParameterAttribute()
        {
            parameterType = ParameterType.All;
            displayType = true;
            debug = false;
        }

        public AnimatorParameterAttribute(bool showType)
        {
            parameterType = ParameterType.All;
            displayType = showType;
            debug = false;
        }

        public AnimatorParameterAttribute(bool showType, bool logToConsole)
        {
            parameterType = ParameterType.All;
            displayType = showType;
            debug = logToConsole;
        }

        public AnimatorParameterAttribute(bool showType, bool logToConsole, ParameterType parameterSelect)
        {
            parameterType = parameterSelect;
            displayType = showType;
            debug = logToConsole;
        }
    }

    public enum ParameterType
    {
        //
        // Summary:
        //     No parameter type.
        All = 0,
        //
        // Summary:
        //     Float type parameter.
        Float = 1,
        //
        // Summary:
        //     Int type parameter.
        Int = 3,
        //
        // Summary:
        //     Boolean type parameter.
        Bool = 4,
        //
        // Summary:
        //     Trigger type parameter.
        Trigger = 9
        //
        // Summary:
        //     No parameter type.
        //None = 999
    }
}