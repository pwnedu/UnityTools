// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(ColourAttribute))]
    public class ColourPropertyDrawer : PropertyDrawer
    {
        private GUIStyle styleData;
        private Color32 fontColour;

        ColourAttribute ColourAttribute { get { return (ColourAttribute)attribute; } }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  PropertyDrawer Overrides

            // Start Property Field
            EditorGUI.BeginProperty(position, label, property);

            // Create Custom Font Style
            fontColour = ColourAttribute.Colour;

            styleData = new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = fontColour },
                fontStyle = FontStyle.Normal,
                alignment = TextAnchor.MiddleLeft
            };

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