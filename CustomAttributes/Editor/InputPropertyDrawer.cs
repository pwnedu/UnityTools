// NOTE: Put in an editor folder. //

// Originally created by Denis Rizov
// Modified by kiltec

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(InputAttribute))]
    public class InputPropertyDrawer : PropertyDrawer
    {
        private static readonly string AssetPath = Path.Combine("ProjectSettings", "InputManager.asset");
        private readonly string AxesProperty = "m_Axes";
        private readonly string NameProperty = "m_Name";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null)
            {
                return;
            }

            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogError($"{nameof(InputAttribute)} supports only string fields.");
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            var inputManagerAsset = AssetDatabase.LoadAssetAtPath(AssetPath, typeof(object));
            var inputManager = new SerializedObject(inputManagerAsset);

            var axesProperty = inputManager.FindProperty(AxesProperty);
            var axesSet = new List<string>();
            axesSet.Add("(Not Selected)");

            for (var i = 0; i < axesProperty.arraySize; i++)
            {
                var axis = axesProperty.GetArrayElementAtIndex(i).FindPropertyRelative(NameProperty).stringValue;
                axesSet.Add(axis);
            }

            var axes = axesSet.ToArray();

            string propertyString = property.stringValue;
            int index = 0;

            // If index not 0 check selection matches entry and get the index.
            for (int i = 1; i < axes.Length; i++)
            {
                if (axes[i].Equals(propertyString, System.StringComparison.Ordinal))
                {
                    index = i;
                    break;
                }
            }

            // Draw the popup box with the current selected index
            int newIndex = EditorGUI.Popup(position, label.text, index, axes);

            // Adjust the actual string value of the property based on the selection
            string newValue = newIndex > 0 ? axes[newIndex] : string.Empty;

            if (!property.stringValue.Equals(newValue, System.StringComparison.Ordinal))
            {
                property.stringValue = newValue;
            }
        }
    }
}