// NOTE: Put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Property Drawer Overrides

            if (property == null) { return; }

            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogError($"{nameof(TagAttribute)} supports only string fields.");
            }

            GUIContent content = new GUIContent("x", "clear selection");

            GUIStyle style = EditorStyles.miniButtonRight;
            style.fixedWidth = 18;
            style.fixedHeight = 18;
            style.contentOffset = new Vector2(0f, -1f);
            style.alignment = TextAnchor.MiddleCenter;

            Rect buttonRect = new Rect(position.width, position.y, position.width, position.height);
            Rect positionRect = new Rect(position.x, position.y, position.width - 22, position.height);

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
                {
                    property.stringValue = EditorGUI.TagField(positionRect, label, property.stringValue);
                    if (GUI.Button(buttonRect, content, style))
                    {
                        property.stringValue = null;
                    }
                    if (changeCheck.changed)
                    {
                        property.serializedObject?.ApplyModifiedProperties();
                    }
                }
            }

            #endregion
        }
    }
}