// NOTE: Put in an editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(DisplayImageAttribute))]
    public class DisplayImageDecoratorDrawer : DecoratorDrawer
    {
        Texture2D texture;
        DisplayImageAttribute imageAtrribute;

        public override float GetHeight()
        {
            imageAtrribute = attribute as DisplayImageAttribute;

            return imageAtrribute.height + 3;
        }

        public override void OnGUI(Rect position)
        {
            #region Decorator Drawer Overrides

            if (!texture)
            {
                texture = Resources.Load<Texture2D>(imageAtrribute.texture);
            }

            if (!texture)
            {
                return;
            }

            if (!imageAtrribute.stretch)
            {
                position.width = imageAtrribute.width;
            }

            position.height = imageAtrribute.height;

            GUI.DrawTexture(position, texture);

            #endregion
        }
    }
}