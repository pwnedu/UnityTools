// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// <code>[Format("lineColour", "backgroundColour", height, curvePresets, curveValues, wideLayout, showLabel)]</code>
    /// <para>Available Colours: </para>
    /// <code> "red", "green", "blue", "yellow", "magenta", "cyan", "white", "grey", "black", "clear"</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Line colour cyan, background colour pink, curve display height 60, show curve presets, show curve values, wide layout, show label, curve default value override: </para> 
    /// <code>[Curve("cyan", "pink", 60, true, true, true, true, start = 0.2f, end = 0.8f, min = 0.2f, max = 0.8f)] private AnimationCurve myCurve;</code>
    ///     </item>
    ///     <item>
    /// <para>Line colour cyan, background colour pink, curve display height 60, show curve presets, show curve values, wide layout, show label: </para>
    /// <code>[Curve("cyan", "pink", 60, true, true, true, true)] private string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Line colour cyan, background colour pink, curve display height 60, show curve presets, hide curve values, normal layout, show label: </para>
    /// <code>[Curve("cyan", "pink", 60, true, false)] private string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Line colour cyan, background colour pink, curve display height 60, hide curve presets, hide curve values, wide layout, hide label: </para>
    /// <code>[Curve("cyan", "pink", 60, false, false, true, false)] private string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Line colour cyan, background colour pink, curve display height 60, hide curve presets, hide curve values, normal layout, show label: </para>
    /// <code>[Curve("cyan", "pink", 60)] private string myString;</code>
    ///     </item>
    ///     <item>
    /// <para>Line colour cyan, default background colour, curve display height default, hide curve presets, hide curve values, normal layout, show label: </para>
    /// <code>[Curve("cyan")] private string myString;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class CurveAttribute : PropertyAttribute
    {
        public string lineColour;
        public string bgColour;
        public float height;
        public bool presets;
        public bool values;
        public bool wide;
        public bool label;

        public float start;
        public float end;
        public float min;
        public float max;

        public CurveAttribute()
        {
            lineColour = "green";
            bgColour = "white";
            height = 0;
            presets = false;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(float curveHeight)
        {
            lineColour = "green";
            bgColour = "white";
            height = curveHeight;
            presets = false;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(float curveHeight, bool curvePresets)
        {
            lineColour = "green";
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(float curveHeight, bool curvePresets, bool curveValues)
        {
            lineColour = "green";
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(float curveHeight, bool curvePresets, bool curveValues, bool wideLayout)
        {
            lineColour = "green";
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = wideLayout;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(float curveHeight, bool curvePresets, bool curveValues, bool wideLayout, bool showLabel)
        {
            lineColour = "green";
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = wideLayout;
            label = showLabel;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour)
        {
            lineColour = curveColour;
            bgColour = "white";
            height = 0;
            presets = false;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, float curveHeight)
        {
            lineColour = curveColour;
            bgColour = "white";
            height = curveHeight;
            presets = false;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, float curveHeight, bool curvePresets)
        {
            lineColour = curveColour;
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, float curveHeight, bool curvePresets, bool curveValues)
        {
            lineColour = curveColour;
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, float curveHeight, bool curvePresets, bool curveValues, bool wideLayout)
        {
            lineColour = curveColour;
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = wideLayout;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, float curveHeight, bool curvePresets, bool curveValues, bool wideLayout, bool showLabel)
        {
            lineColour = curveColour;
            bgColour = "white";
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = wideLayout;
            label = showLabel;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, string backgroundColor)
        {
            lineColour = curveColour;
            bgColour = backgroundColor;
            height = 0;
            presets = false;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, string backgroundColor, float curveHeight)
        {
            lineColour = curveColour;
            bgColour = backgroundColor;
            height = curveHeight;
            presets = false;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, string backgroundColor, float curveHeight, bool curvePresets)
        {
            lineColour = curveColour;
            bgColour = backgroundColor;
            height = curveHeight;
            presets = curvePresets;
            values = false;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, string backgroundColor, float curveHeight, bool curvePresets, bool curveValues)
        {
            lineColour = curveColour;
            bgColour = backgroundColor;
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = false;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, string backgroundColor, float curveHeight, bool curvePresets, bool curveValues, bool wideLayout)
        {
            lineColour = curveColour;
            bgColour = backgroundColor;
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = wideLayout;
            label = true;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }

        public CurveAttribute(string curveColour, string backgroundColor, float curveHeight, bool curvePresets, bool curveValues, bool wideLayout, bool showLabel)
        {
            lineColour = curveColour;
            bgColour = backgroundColor;
            height = curveHeight;
            presets = curvePresets;
            values = curveValues;
            wide = wideLayout;
            label = showLabel;

            start = 0;
            end = 1;
            min = 0;
            max = 1;
        }
    }
}