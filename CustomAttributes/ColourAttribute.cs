// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// Specified colour label [Colour(R, G, B, A)]
    /// White label [Colour]
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
