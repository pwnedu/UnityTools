// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// Highlight field with colour block [Highlight(R, G, B, A)]
    /// Highlight field with grey block [Highlight]
    /// </summary>
    public class HighlightAttribute : PropertyAttribute
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public HighlightAttribute()
        {
            r = g = b = a = 0.5f;
        }

        public HighlightAttribute(float red, float green, float blue, float alpha)
        {
            r = red / 255;
            g = green / 255;
            b = blue / 255;
            a = alpha / 255;
        }

        public Color Colour { get { return new Color(r, g, b, a); } }
    }
}