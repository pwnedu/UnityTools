// NOTE: put in a Editor folder. //

using System;
using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
    public class ShowOnlyPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  Property Drawer Overrides

            string valueStr;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    valueStr = property.intValue.ToString();
                    break;
                case SerializedPropertyType.Boolean:
                    valueStr = property.boolValue.ToString();
                    break;
                case SerializedPropertyType.Float:
                    valueStr = property.floatValue.ToString();
                    break;
                case SerializedPropertyType.String:
                    valueStr = property.stringValue;
                    break;
                case SerializedPropertyType.Vector2:
                    valueStr = property.vector2Value.ToString();
                    break;
                case SerializedPropertyType.Vector3:
                    valueStr = property.vector3Value.ToString();
                    break;
                case SerializedPropertyType.Vector4:
                    valueStr = property.vector4Value.ToString();
                    break;
                case SerializedPropertyType.Quaternion:
                    valueStr = property.quaternionValue.ToString();
                    break;
                case SerializedPropertyType.Enum:
                    valueStr = property.enumNames[property.enumValueIndex];
                    break;
                case SerializedPropertyType.Rect:
                    valueStr = property.rectValue.ToString();
                    break;
                case SerializedPropertyType.ObjectReference:
                    try
                    {
                        valueStr = property.objectReferenceValue.ToString();
                    }
                    catch (NullReferenceException)
                    {
                        valueStr = "None (Game Object)";
                    }
                    break;
                default:
                    valueStr = "(not supported)";
                    break;
            }

            EditorGUI.LabelField(position, label.text, valueStr);

            #endregion
        }
    }
}