// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(HighlightAttribute))]
    public class HighlightPropertyDrawer : PropertyDrawer
    {
        private GUIStyle styleData;
        private Color32 backgroundColour;

        HighlightAttribute ColourAttribute { get { return (HighlightAttribute)attribute; } }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  PropertyDrawer Overrides

            // Start Property Field
            EditorGUI.BeginProperty(position, label, property);

            // Create Custom Style
            styleData = new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = Color.white },
                fontStyle = FontStyle.Normal,
                alignment = TextAnchor.MiddleLeft
            };

            // Draw Background
            backgroundColour = ColourAttribute.Colour;
            var pos = new Rect(position.x - 2f, position.y, position.width, position.height);
            EditorGUI.DrawRect(pos, backgroundColour);
            GUI.backgroundColor = new Color32(backgroundColour.r, backgroundColour.g, backgroundColour.b, 127);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label, styleData);

            // Draw field
            EditorGUI.PropertyField(position, property, GUIContent.none);

            // End Property Field
            EditorGUI.EndProperty();

            #endregion
        }
    }
}