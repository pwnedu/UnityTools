// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// Specified colour label [Highlight(R, G, B, A)]
    /// White label [Highlight]
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

        public ColourAttribute(float aR, float aG, float aB, float aA)
        {
            r = aR / 255;
            g = aG / 255;
            b = aB / 255;
            a = aA / 255;
        }

        public Color Colour { get { return new Color(r, g, b, a); } }
    }
}