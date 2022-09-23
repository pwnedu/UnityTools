using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(SelectionAttribute))]
    public class SelectionPropertyDrawer : PropertyDrawer
    {
        SelectionAttribute SelectionAttribute { get { return (SelectionAttribute)attribute; } }

        private readonly string indexColour = "#00d1ff";
        private readonly string nameColour = "#ffbd00";

        private string listName;
        private System.Reflection.PropertyInfo myPropertyInfo;
        private System.Type type;
        private Object target;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Property Drawer Overrides

            if (property == null) { return; }

            if (property.propertyType != SerializedPropertyType.Integer)
            {
                base.OnGUI(position, property, label);
                Debug.LogError($"{nameof(SelectionAttribute)} supports only int fields.");
                return;
            }

            // Get Property Information
            if (target == null)
            {
                target = property.serializedObject.targetObject;
            }

            if (string.IsNullOrEmpty(listName))
            {
                listName = SelectionAttribute.ListName;
            }

            if (type == null)
            {
                type = target.GetType();
            }

            if (myPropertyInfo == null)
            {
                myPropertyInfo = type.GetProperty(listName);
            }

            if (myPropertyInfo == null)
            {
                Debug.LogWarning($"{nameof(SelectionAttribute)} cannot find target selection property!", target);
                return;
            }

            // Handle Specific Array Types
            if (myPropertyInfo.PropertyType == typeof(string[]))
            {
                string[] values = myPropertyInfo.GetValue(target) as string[];
                string[] names = GetValuesAsName(values);
                DrawIntProperty(position, property, label, names);
                return;
            }

            if (myPropertyInfo.PropertyType == typeof(int[]))
            {
                int[] values = myPropertyInfo.GetValue(target) as int[];
                string[] names = GetValuesAsName(values);
                DrawIntProperty(position, property, label, names);
                return;
            }

            if (myPropertyInfo.PropertyType == typeof(TextAsset[]))
            {
                TextAsset[] values = myPropertyInfo.GetValue(target) as TextAsset[];
                string[] names = GetObjectNames(values);
                DrawIntProperty(position, property, label, names);
                return;
            }

            // Handle Specific List Types
            if (myPropertyInfo.PropertyType == typeof(List<string>))
            {
                List<string> values = myPropertyInfo.GetValue(target) as List<string>;
                string[] names = GetValuesAsName(values.ToArray());
                DrawIntProperty(position, property, label, names);
                return;
            }

            if (myPropertyInfo.PropertyType == typeof(List<int>))
            {
                List<int> values = myPropertyInfo.GetValue(target) as List<int>;
                string[] names = GetValuesAsName(values.ToArray());
                DrawIntProperty(position, property, label, names);
                return;
            }

            if (myPropertyInfo.PropertyType == typeof(List<TextAsset>))
            {
                List<TextAsset> values = myPropertyInfo.GetValue(target) as List<TextAsset>;
                string[] names = GetObjectNames(values.ToArray());
                DrawIntProperty(position, property, label, names);
                return;
            }

            // Handle Array and List Types for various objects.
            if (myPropertyInfo.PropertyType.Name.Contains("[]") || myPropertyInfo.PropertyType.Name.Contains("List"))
            {
                string[] names = ListObjectValuesToNameArray((IList)myPropertyInfo.GetValue(target));
                DrawIntProperty(position, property, label, names);
                return;
            }

            EditorGUI.PropertyField(position, property);
            return;

            #endregion
        }

        private string[] ListObjectValuesToNameArray(IList list)
        {
            #region Values List To Name String Array

            var count = list.Count;
            string[] names = new string[count];

            for (int i = 0; i < count; i++)
            {
                if (SelectionAttribute.addElement)
                {
                    names[i] = $"{i}. {list[i]}";
                }
                else
                {
                    names[i] = list[i].ToString();
                }
            }

            return names;

            #endregion
        }

        private string[] GetValuesAsName<T>(T[] values)
        {
            #region Values Array To Name String Array

            int length = values.Length;
            string[] names = new string[length];

            if (names == null) { return null; }

            for (int i = 0; i < length; i++)
            {
                if (SelectionAttribute.addElement) { names[i] = $"{i}. {values[i]}"; }
                else { names[i] = values[i].ToString(); }
            }

            return names;

            #endregion
        }

        private string[] GetObjectNames(Object[] values)
        {
            #region Object Array Names To String Array

            int length = values.Length;
            string[] names = new string[length];

            if (names == null) { return null; }

            for (int i = 0; i < length; i++)
            {
                if (SelectionAttribute.addElement) { names[i] = $"{i}. "; }

                if (values[i] == null) { names[i] += "null"; }
                else { names[i] += values[i].name; }
            }

            return names;

            #endregion
        }

        private void DrawIntProperty(Rect rect, SerializedProperty property, GUIContent label, string[] selectionNames)
        {
            #region Draw Int Properties

            if (selectionNames == null) { return; }


            int index = property.intValue;
            int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, selectionNames);

            if (property.intValue != newIndex)
            {
                property.intValue = newIndex;
                if (SelectionAttribute.debug)
                {
                    Debug.Log($"Selected Element: <color={indexColour}>{newIndex}</color> Selection Name: <color={nameColour}>{selectionNames[newIndex]}</color>");
                }
            }

            #endregion
        }
    }
}