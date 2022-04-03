// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
    [CustomEditor(typeof(FormatStyles))]
    public class FormatStylesEditor : Editor
    {
        // Controller
        private SerializedObject styleController;

        // Extensions
        private SerializedProperty styleProperty;

        // Editor Properties
        GUIStyle headerStyle;

        private Color headingColor = new Color32(225, 205, 140, 255);
        private Color subHeadingColor = new Color32(225, 155, 155, 255);

        private void OnEnable()
        {
            // Initialise Controller
            styleController = new SerializedObject(target);

            // Find Property
            styleProperty = styleController.FindProperty("colours");

            // Creaete Header GUI Style
            SetHeaderStyle();
        }

        private void SetHeaderStyle()
        {
            headerStyle = new GUIStyle()
            {
                normal = new GUIStyleState()
                {
                    textColor = headingColor
                },
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                fixedHeight = 40f,
                richText = true,
                fontSize = 18,
            };
        }

        public override void OnInspectorGUI()
        {
            var previousColour = GUI.contentColor;

            // Scriptable Title
            GUILayout.Label("Format Attribute Colour Styles", headerStyle);
            GUILayout.Label(target.name, EditorStyles.centeredGreyMiniLabel);
            GUILayout.Space(10);

            // Area Heading
            GUI.contentColor = subHeadingColor;
            EditorGUILayout.LabelField("Custom Format Colour Data", EditorStyles.largeLabel);
            GUI.contentColor = previousColour;
            GUILayout.Space(5);

            EditorGUI.BeginChangeCheck();

            // Custom Project View Styling
            EditorGUILayout.PropertyField(styleProperty);

            if (EditorGUI.EndChangeCheck())
            {
                styleController.ApplyModifiedProperties();
            }
        }
    }
}