// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// <para>Use this PropertyAttribute to specify a coloured label (0 - 255)</para> 
    /// <code>[Colour(R, G, B, A)]</code>
    /// <para>White label</para> 
    /// <code>[Colour]</code>
    /// </summary>
    public class ColourAttribute : PropertyAttribute
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public ColourAttribute()
        {
            r = g = b = a = 1f;
        }

        public ColourAttribute(float red, float green, float blue, float alpha)
        {
            r = red / 255;
            g = green / 255;
            b = blue / 255;
            a = alpha / 255;
        }

        public Color Colour { get { return new Color(r, g, b, a); } }
    }
}
