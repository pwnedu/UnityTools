// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this PropertyAttribute to display a sprite or texture preview in the inspector: </para>
    /// <code>[Preview(size, TextureType)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Display a 100x100 texture preview in the inspector: </para>
    /// <code>[Preview(100, TextureType.Texture2D)] public Texture2D texture2D;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a 75x75 sprite preview in the inspector: </para>
    /// <code>[Preview(75, TextureType.Sprite)] public Sprite sprite;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class PreviewAttribute : PropertyAttribute
    {
        public float height;
        public TextureType type;

        public PreviewAttribute()
        {
            height = 50;
            type = TextureType.Texture2D;
        }

        public PreviewAttribute(float imageHeight)
        {
            height = imageHeight;
            type = TextureType.Texture2D;
        }
        public PreviewAttribute(float imageHeight, TextureType textureType)
        {
            height = imageHeight;
            type = textureType;
        }
    }

    public enum TextureType
    {
        Sprite = 0,
        Texture2D = 1
    }
}