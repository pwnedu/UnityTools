// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(DisableAttribute))]
    public class DisablePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  Property Drawer Overrides

            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);
            GUI.enabled = true;

            #endregion
        }
    }
}