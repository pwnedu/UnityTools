﻿// NOTE: Put in a Editor folder. //

using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(StringValidateAttribute))]
    public class StringValidateDrawer : PropertyDrawer
    {
        // These constants describe the height of the help box and the text field.
        readonly float textHeight = GUI.skin.textField.lineHeight + 3;
        float helpHeight;

        // Provide easy access to the RegexAttribute for reading information from it.
        StringValidateAttribute ValidationAttribute { get { return (StringValidateAttribute)attribute; } }

        // Here you must define the height of your property drawer. Called by Unity.
        public override float GetPropertyHeight(SerializedProperty prop, GUIContent label)
        {
            if (IsValid(prop))
            {
                return base.GetPropertyHeight(prop, label);
            }
            else
            {
                GUIStyle style = EditorStyles.helpBox;
                style.alignment = TextAnchor.MiddleLeft;
                style.clipping = TextClipping.Clip;
                style.wordWrap = true;
                style.padding = new RectOffset(10, 10, 10, 10);
                style.margin = new RectOffset(0, 5, 0, 5);
                style.fontSize = 12;

                GUIContent content = new GUIContent(ValidationAttribute.message + "\n\n");
                helpHeight = style.CalcHeight(content, Screen.width);

                return base.GetPropertyHeight(prop, label) + helpHeight;
            }
        }

        // Here you can define the GUI for your property drawer. Called by Unity.
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Property Drawer Overrides

            // Adjust height of the text field
            Rect textFieldPosition = position;
            textFieldPosition.height = textHeight;
            DrawTextField(textFieldPosition, property, label);

            // Adjust the help box position to appear indented underneath the text field.
            Rect helpPosition = EditorGUI.IndentedRect(position);
            helpPosition.y += textHeight + 5;
            helpPosition.height = helpHeight - 10;
            DrawHelpBox(helpPosition, property);

            #endregion
        }

        void DrawTextField(Rect position, SerializedProperty prop, GUIContent label)
        {
            // Draw the text field control GUI.
            EditorGUI.BeginChangeCheck();
            string value = EditorGUI.TextField(position, label, prop.stringValue);
            if (EditorGUI.EndChangeCheck())
                prop.stringValue = value;
        }

        void DrawHelpBox(Rect position, SerializedProperty prop)
        {
            // No need for a help box if the pattern is valid.
            if (IsValid(prop))
                return;

            EditorGUI.HelpBox(position, ValidationAttribute.message, MessageType.Error);
        }

        // Test if the propertys string value matches the regex pattern.
        bool IsValid(SerializedProperty prop)
        {
            return Regex.IsMatch(prop.stringValue, ValidationAttribute.pattern);
        }
    }
}