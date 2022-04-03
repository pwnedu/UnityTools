// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this property attribute to create a horizontal line break in the inspector: </para>
    /// <code>[LineBreak("lineColour", lineThickness, verticalPadding)]</code>
    /// <para>Available Colours: </para>
    /// <code> "red", "green", "blue", "yellow", "magenta", "cyan", "white", "grey", "black", "clear"</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Line colour violet, line thickness 5, vertical padding 10, attribute order 2: </para>
    /// <code>[LineBreak(colour = "violet", 5f, 10f, order = 2)]</code>
    ///     </item>
    ///     <item>
    /// <para>Line colour cyan, line thickness 10, default padding 20 </para> 
    /// <code>[LineBreak(colour = "cyan", 10f)]</code>
    ///     </item>
    ///     <item>
    /// <para>Double line break, colour orange, line thickness 10, vertical padding 20, attribute order 2 and 3: </para>
    /// <code>[LineBreak(colour = "orange", thickness = 5f, padding = 10f, order = 2)]</code>
    /// <code>[LineBreak(colour = "orange", thickness = 5f, padding = 10f, order = 3)]</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class LineBreakAttribute : PropertyAttribute
    {
        public string colour;
        public float thickness;
        public float padding;

        public LineBreakAttribute()
        {
            colour = null;
            thickness = 5;
            padding = 20f;
        }

        public LineBreakAttribute(float lineThickness)
        {
            colour = null;
            thickness = lineThickness;
            padding = lineThickness * 4;
        }

        public LineBreakAttribute(float lineThickness, float rectPadding)
        {
            colour = null;
            thickness = lineThickness;
            padding = rectPadding;
        }

        public LineBreakAttribute(string colourString)
        {
            colour = colourString;
            thickness = 5;
            padding = 20f;
        }

        public LineBreakAttribute(string colourString, float lineThickness)
        {
            colour = colourString;
            thickness = lineThickness;
            padding = lineThickness * 4;
        }

        public LineBreakAttribute(string colourString, float lineThickness, float rectPadding)
        {
            colour = colourString;
            thickness = lineThickness;
            padding = rectPadding;
        }
    }
}