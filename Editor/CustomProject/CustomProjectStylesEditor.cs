using UnityEngine;
using UnityEditor;

namespace CustomProjectView
{
    [CustomEditor(typeof(CustomProjectStyles))]
    public class CustomProjectStylesEditor : Editor
    {
        private SerializedObject styleController;

        // Extensions
        private SerializedProperty showProperty;
        private SerializedProperty widthProperty;
        private SerializedProperty colorProperty;
        private SerializedProperty randomProperty;

        // Styles
        private SerializedProperty styleProperty;

        GUIStyle headerStyle;

        private void OnEnable()
        {
            styleController = new SerializedObject(target);

            showProperty = styleController.FindProperty("showFileExtensions");
            widthProperty = styleController.FindProperty("widthToShowExtensions");
            colorProperty = styleController.FindProperty("textColor");
            randomProperty = styleController.FindProperty("randomTextColor");

            styleProperty = styleController.FindProperty("styles");

            SetHeaderStyle();
        }

        private void SetHeaderStyle()
        {
            headerStyle = new GUIStyle()
            {
                normal = new GUIStyleState()
                {
                    textColor = new Color32(100, 150, 200, 255)
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
            GUILayout.Label("Custom Project View Styling", headerStyle);
            GUILayout.Label(target.name, EditorStyles.centeredGreyMiniLabel);
            GUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Extensions Style Data", EditorStyles.largeLabel);
            GUILayout.BeginVertical("Box");
            var previousColour = GUI.contentColor;
            GUI.contentColor = new Color32(100, 150, 200, 255);
            EditorGUILayout.PropertyField(showProperty);
            GUI.contentColor = previousColour;
            EditorGUILayout.PropertyField(widthProperty);
            EditorGUILayout.PropertyField(colorProperty);
            EditorGUILayout.PropertyField(randomProperty);
            GUILayout.EndVertical();

            GUILayout.Space(10);
            EditorGUILayout.LabelField("Custom Style Data", EditorStyles.largeLabel);
            EditorGUILayout.PropertyField(styleProperty);

            if (EditorGUI.EndChangeCheck())
            {
                styleController.ApplyModifiedProperties();
            }
        }
    }
}