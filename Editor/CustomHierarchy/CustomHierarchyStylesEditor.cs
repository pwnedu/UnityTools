using UnityEngine;
using UnityEditor;

namespace CustomHierarchy 
{
    [CustomEditor(typeof(CustomHierarchyStyles))] 
    public class CustomHierarchyStylesEditor : Editor
    {
        private SerializedObject styleController; 
        private SerializedProperty styleProperty;

        GUIStyle headerStyle;

        private void OnEnable()
        {
            styleController = new SerializedObject(target);
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
            GUILayout.Label("Custom Hierarchy Styling", headerStyle);
            GUILayout.Label(target.name, EditorStyles.centeredGreyMiniLabel);
            GUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("Custom Style Data", EditorStyles.largeLabel);           
            EditorGUILayout.PropertyField(styleProperty);
            
            if (EditorGUI.EndChangeCheck())
            {
                styleController.ApplyModifiedProperties();
            }
        }
    }
}