// NOTE: Put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(ProgressAttribute))]
    public class ProgressPropertyDrawer : PropertyDrawer
    {
        ProgressAttribute progressAttribute;

        private readonly float offset = 4;
        private readonly float lineHeight = GUI.skin.textField.lineHeight + 3;
        private float height;

        Rect fieldRect;
        Rect sliderRect;
        Rect borderRect;
        Rect bgRect;
        Rect progressRect;
        Rect labelRect;

        Texture2D borderTex;
        Texture2D bgTex;
        Texture2D progressTex;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            progressAttribute = attribute as ProgressAttribute;

            height = progressAttribute.height;

            return base.GetPropertyHeight(property, label) + height + (lineHeight * 3);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Property Drawer Overrides

            if (property == null) { return; }

            if (property.propertyType != SerializedPropertyType.Float)
            {
                Debug.LogError($"{nameof(ProgressAttribute)} supports only Float fields.");
            }

            EditorGUI.BeginProperty(position, label, property);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float progressValue = property.floatValue;

            if (progressValue <= progressAttribute.min) { progressValue = progressAttribute.min; property.floatValue = progressAttribute.min; }
            if (progressValue >= progressAttribute.max) { progressValue = progressAttribute.max; property.floatValue = progressAttribute.max; }

            float progressPercentage = progressValue / progressAttribute.max;
            float progressX = (position.width - offset) * progressPercentage;
            float sliderPos = position.y + lineHeight + 2;
            float borderPos = position.y + sliderRect.height + fieldRect.height + 8;
            float half = offset * 0.5f; ;

            fieldRect = new Rect(position.x, position.y, position.width, lineHeight);
            sliderRect = new Rect(position.x, sliderPos, position.width, lineHeight);
            borderRect = new Rect(position.x, borderPos, position.width, height);
            bgRect = new Rect(position.x + half, borderRect.y + half, position.width - offset, height - offset);
            progressRect = new Rect(bgRect.x, bgRect.y, progressX, bgRect.height);
            labelRect = new Rect(progressRect.width * 0.9f + 15, borderRect.y + height, 75, lineHeight);

            GUI.Label(fieldRect, label.text);
            property.floatValue = EditorGUI.Slider(sliderRect, property.floatValue, progressAttribute.min, progressAttribute.max);

            if (!borderTex)
            {
                borderTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                borderTex.SetPixel(0, 0, Color.black);
                borderTex.Apply();
            }

            GUI.DrawTexture(borderRect, borderTex);

            if (!bgTex)
            {
                bgTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                bgTex.SetPixel(0, 0, BGColour);
                bgTex.Apply();
            }

            GUI.DrawTexture(bgRect, bgTex);

            if (!progressTex)
            {
                progressTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                progressTex.SetPixel(0, 0, ProgressColour);
                progressTex.Apply();
            }

            GUI.DrawTexture(progressRect, progressTex);
            GUI.Label(labelRect, $"{progressPercentage * 100:0.00} %");

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();

            #endregion
        }

        private Color ProgressColour
        {
            get { return FormatStringColour.Colour(progressAttribute.barColour); }
        }

        private Color BGColour
        {
            get { return FormatStringColour.Colour(progressAttribute.bgColour); }
        }
    }
}