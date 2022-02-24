using UnityEngine;
using UnityEditor;

namespace CustomExtensions 
{
    public class GUIExtension
    {
        private static readonly string bullet = "●";
        private static readonly string diamond = "◆";
        private static readonly string heart = "♥︎";
        private static readonly string triangle = "◀";

        public static Rect CalculateRect(Rect selection, float leftOffset, float rightOffset, float backgroundHeight)
        {
            var position = new Vector2(selection.position.x + leftOffset, selection.position.y);
            var size = new Vector2(selection.size.x + rightOffset - leftOffset, selection.size.y * backgroundHeight);
            return new Rect(position, size);
        }

        public static void DrawLabelStyle(string label, Rect selection, LabelStyle labelStyle)
        {
            var style = new GUIStyle(labelStyle.guiStyle);
            style.alignment = AnchorPosition(labelStyle.anchor);
            Vector2 labelSize = style.CalcSize(new GUIContent(label));
        
            Rect textRect = selection;
            textRect.width += selection.x;
            textRect.x = textRect.width - labelSize.x - 4 + labelStyle.xAdjust;

            EditorGUI.LabelField(textRect, label, style);
        }

        public static void DrawIconStyle(Icon icon, Rect selection, LabelStyle iconStyle)
        {
            var style = new GUIStyle(iconStyle.guiStyle);
            style.alignment = AnchorPosition(iconStyle.anchor);

            Rect iconRect = selection;
            iconRect.x += iconRect.width - 20 + iconStyle.xAdjust;
            iconRect.width = selection.width;

            switch (icon)
            {
                case Icon.Bullet:
                    GUI.Label(iconRect, bullet, style);
                    break;
                case Icon.Diamond:
                    GUI.Label(iconRect, diamond, style);
                    break;
                case Icon.Heart:
                    GUI.Label(iconRect, heart, style);
                    break;
                case Icon.Triangle:
                    GUI.Label(iconRect, triangle, style);
                    break;
                default:
                    break;
            }
        }

        public static TextAnchor AnchorPosition(InfoAnchor anchor)
        {
            if (anchor == InfoAnchor.Middle) { return TextAnchor.MiddleLeft; }
            else if (anchor == InfoAnchor.Bottom) { return TextAnchor.LowerLeft; }
            else return TextAnchor.UpperLeft;
        }
    }

    public class LabelStyle
    {
        public GUIStyle guiStyle;
        public InfoAnchor anchor;
        public float xAdjust;
    }

    public enum InfoAnchor { Top, Middle, Bottom }
    public enum Icon { None, Bullet, Diamond, Heart, Triangle }
}