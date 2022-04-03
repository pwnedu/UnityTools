// NOTE: Put in an editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(PreviewAttribute))]
    public class PreviewPropertyDrawer : PropertyDrawer
    {
        PreviewAttribute imageAttribute;
        private float height;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            #region Get Property Settings

            imageAttribute = attribute as PreviewAttribute;
            height = imageAttribute.height;
            return height;

            #endregion
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  Get Property Overrides

            if (property == null) { return; }

            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                Debug.LogError($"{nameof(PreviewAttribute)} supports only Texture2D and Sprite fields.");
            }

            if (imageAttribute.type == TextureType.Texture2D)
            {
                property.objectReferenceValue = (Texture2D)EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Texture2D), false);
            }
            else if (imageAttribute.type == TextureType.Sprite)
            {
                property.objectReferenceValue = (Sprite)EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Sprite), false);
            }

            #endregion
        }
    }
}