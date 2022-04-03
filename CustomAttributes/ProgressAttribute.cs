// NOTE: DON'T put in a Editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this PropertyAttribute to display a progress bar in the inspector: </para>
    /// <code>[Progress("progressColour", "backgroundColour", minValue, maxValue, height)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Display a progress bar with default blue bar, default grey background, default minimum value 0, default maximum value 1, default height 18: </para>
    /// <code>[Progress] private float myProgress;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a progress bar with blue bar, yellow background, default minimum value 0, default maximum value 1, default height 18: </para>
    /// <code>[Progress("blue", "yellow")] private float myProgress;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a progress bar with purple bar, pink background, minimum value 0, maximum value 50, height 24: </para>
    /// <code>[Progress("purple", "pink", 0, 50, 24)] private float myProgress;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class ProgressAttribute : PropertyAttribute
    {
        public string barColour;
        public string bgColour;

        public float min;
        public float max;

        public float height;

        public ProgressAttribute()
        {
            barColour = "blue";
            bgColour = "grey";
            min = 0;
            max = 1;
            height = 18;
        }

        public ProgressAttribute(float maximumValue)
        {
            barColour = "blue";
            bgColour = "grey";
            min = 0;
            max = maximumValue;
            height = 18;
        }

        public ProgressAttribute(float minimumValue, float maximumValue)
        {
            barColour = "blue";
            bgColour = "grey";
            min = minimumValue;
            max = maximumValue;
            height = 18;
        }

        public ProgressAttribute(float minimumValue, float maximumValue, float progressHeight)
        {
            barColour = "blue";
            bgColour = "grey";
            min = minimumValue;
            max = maximumValue;
            height = progressHeight;
        }

        public ProgressAttribute(string progressColour, float maximumValue)
        {
            barColour = progressColour;
            bgColour = "grey";
            min = 0;
            max = maximumValue;
            height = 18;
        }

        public ProgressAttribute(string progressColour, float minimumValue, float maximumValue)
        {
            barColour = progressColour;
            bgColour = "grey";
            min = minimumValue;
            max = maximumValue;
            height = 18;
        }

        public ProgressAttribute(string progressColour, float minimumValue, float maximumValue, float progressHeight)
        {
            barColour = progressColour;
            bgColour = "grey";
            min = minimumValue;
            max = maximumValue;
            height = progressHeight;
        }

        public ProgressAttribute(string progressColour, string backgroundColour, float maximumValue)
        {
            barColour = progressColour;
            bgColour = backgroundColour;
            min = 0;
            max = maximumValue;
            height = 18;
        }

        public ProgressAttribute(string progressColour, string backgroundColour, float minimumValue, float maximumValue)
        {
            barColour = progressColour;
            bgColour = backgroundColour;
            min = minimumValue;
            max = maximumValue;
            height = 18;
        }

        public ProgressAttribute(string progressColour, string backgroundColour, float minimumValue, float maximumValue, float progressHeight)
        {
            barColour = progressColour;
            bgColour = backgroundColour;
            min = minimumValue;
            max = maximumValue;
            height = progressHeight;
        }
    }
}