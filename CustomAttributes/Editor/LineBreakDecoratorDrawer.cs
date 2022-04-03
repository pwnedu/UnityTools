// NOTE: Put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(LineBreakAttribute))]
    public class LineBreakDecoratorDrawer : DecoratorDrawer
    {
        LineBreakAttribute lineAttrib;

        public override float GetHeight()
        {
            lineAttrib = attribute as LineBreakAttribute;
            return lineAttrib.thickness + lineAttrib.padding;
        }

        public override void OnGUI(Rect position)
        {
            #region Decorator Drawer Overrides

            position.height = lineAttrib.thickness;
            position.y += (lineAttrib.padding * 0.5f) - (lineAttrib.thickness * 0.5f);

            EditorGUI.DrawRect(position, Colour);

            #endregion
        }

        private Color Colour
        {
            get { return FormatStringColour.Colour(lineAttrib.colour); }
        }
    }
}