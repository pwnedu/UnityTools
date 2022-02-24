using UnityEngine;
using UnityEditor;

namespace CustomHierarchy 
{
    [CustomEditor(typeof(CustomHierarchyStyles))] 
    public class CustomHierarchyStylesEditor : Editor
    {
        // Controller
        private SerializedObject styleController;

        // Extensions
        private SerializedProperty displayLabelInfo;
        private SerializedProperty excludeDefault;
        private SerializedProperty widthProperty;
        private SerializedProperty rightOffset;
        private SerializedProperty textSize;
        private SerializedProperty textAlign;
        private SerializedProperty textStyle;
        private SerializedProperty textColor;
        private SerializedProperty randomProperty;

        // Styles
        private SerializedProperty styleProperty;

        // Editor Properties
        GUIStyle headerStyle;

        private Color headingColor = new Color32(225, 205, 140, 255);
        private Color subHeadingColor = new Color32(225, 155, 155, 255);

        private void OnEnable()
        {
            // Initialise Controller
            styleController = new SerializedObject(target);

            // Find Properties
            displayLabelInfo = styleController.FindProperty("displayLabelType");
            excludeDefault = styleController.FindProperty("excludeDefault");
            widthProperty = styleController.FindProperty("widthToShowLabels");
            rightOffset = styleController.FindProperty("rightOffset");
            textSize = styleController.FindProperty("textSize");
            textAlign = styleController.FindProperty("textAlign");
            textStyle = styleController.FindProperty("textStyle");
            textColor = styleController.FindProperty("textColor");
            randomProperty = styleController.FindProperty("randomTextColor");

            styleProperty = styleController.FindProperty("styles");

            // Create Header GUI Style
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
                alignment = TextAnchor.LowerCenter,
                fixedHeight = 30f,
                richText = true,
                fontSize = 18,
            };
        }

        public override void OnInspectorGUI()
        {
            var previousColour = GUI.contentColor;

            // Scriptable Title
            GUILayout.Label("Custom Hierarchy Styling", headerStyle);
            GUILayout.Label(target.name, EditorStyles.centeredGreyMiniLabel);
            GUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            // Area Heading
            GUI.contentColor = subHeadingColor;
            EditorGUILayout.LabelField("Object Information Label Style", EditorStyles.largeLabel);
            GUI.contentColor = previousColour;
            GUILayout.Space(5);

            // File Information Label Styling
            GUILayout.BeginVertical("Box");
            EditorGUILayout.PropertyField(displayLabelInfo);
            EditorGUILayout.PropertyField(excludeDefault);
            EditorGUILayout.PropertyField(widthProperty);
            EditorGUILayout.PropertyField(rightOffset);
            EditorGUILayout.PropertyField(textSize);
            EditorGUILayout.PropertyField(textAlign);
            EditorGUILayout.PropertyField(textStyle);
            EditorGUILayout.PropertyField(textColor);
            EditorGUILayout.PropertyField(randomProperty);
            GUILayout.EndVertical();
            GUILayout.Space(10);

            // Area Heading
            GUI.contentColor = subHeadingColor;
            EditorGUILayout.LabelField("Custom Hierarchy Style Data", EditorStyles.largeLabel);
            GUI.contentColor = previousColour;
            GUILayout.Space(5);

            // Custom Project View Styling
            EditorGUILayout.PropertyField(styleProperty);
            
            if (EditorGUI.EndChangeCheck())
            {
                styleController.ApplyModifiedProperties();
            }
        }
    }
}