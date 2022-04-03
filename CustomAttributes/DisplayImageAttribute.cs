// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes 
{
    /// <summary>
    /// <para>Display a png texture from the resources folder in inspector: </para>
    /// <code>[DisplayImage("fileName", imageWidth, imageHeight, stretchImageWidth, order = 1)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Display a 300 pixel wide x 200 pixel high image: </para>
    /// <code>[DisplayImage("fileName", 300, 200, order = 1)]</code>
    ///     </item>
    ///     <item>
    /// <para>Display a 150 pixel high image, stretch width to fit inspector: </para>
    /// <code>[DisplayImage("fileName", 150, true)]</code>
    ///     </item>
    ///     <item>
    /// <para>Display a 100 x 100 pixel image: </para>
    /// <code>[DisplayImage("fileName")]</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class DisplayImageAttribute : PropertyAttribute
    {
        public string texture;
        public int width;
        public int height;
        public bool stretch;

        public DisplayImageAttribute()
        {
            texture = "default";
            width = 100;
            height = 100;
            stretch = false;
        }

        public DisplayImageAttribute(int imageHeight)
        {
            texture = "default";
            width = 100;
            height = imageHeight;
            stretch = false;
        }

        public DisplayImageAttribute(int imageWidth, int imageHeight)
        {
            texture = "default";
            width = imageWidth;
            height = imageHeight;
            stretch = false;
        }

        public DisplayImageAttribute(int imageHeight, bool stretchImage)
        {
            texture = "default";
            width = 100;
            height = imageHeight;
            stretch = stretchImage;
        }

        public DisplayImageAttribute(int imageWidth, int imageHeight, bool stretchImage)
        {
            texture = "default";
            width = imageWidth;
            height = imageHeight;
            stretch = stretchImage;
        }

        public DisplayImageAttribute(string imageName)
        {
            texture = imageName;
            width = 100;
            height = 100;
            stretch = false;
        }

        public DisplayImageAttribute(string imageName, int imageHeight)
        {
            texture = imageName;
            width = 100;
            height = imageHeight;
            stretch = false;
        }

        public DisplayImageAttribute(string imageName, int imageWidth, int imageHeight)
        {
            texture = imageName;
            width = imageWidth;
            height = imageHeight;
            stretch = false;
        }

        public DisplayImageAttribute(string imageName, bool stretchImage)
        {
            texture = imageName;
            width = 100;
            height = 100;
            stretch = stretchImage;
        }

        public DisplayImageAttribute(string imageName, int imageHeight, bool stretchImage)
        {
            texture = imageName;
            width = 100;
            height = imageHeight;
            stretch = stretchImage;
        }

        public DisplayImageAttribute(string imageName, int imageWidth, int imageHeight, bool stretchImage)
        {
            texture = imageName;
            width = imageWidth;
            height = imageHeight;
            stretch = stretchImage;
        }
    }
}