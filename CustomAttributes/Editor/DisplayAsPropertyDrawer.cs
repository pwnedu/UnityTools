// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
	[CustomPropertyDrawer(typeof(DisplayAsAttribute))]
	public class DisplayAsPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			#region  Property Drawer Overrides

			// Start Property Field
			EditorGUI.BeginProperty(position, label, property);

			// Create Label
			label.text = (attribute as DisplayAsAttribute)?.attributeName;

			// Draw label
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label, EditorStyles.label);

			// Draw field
			EditorGUI.PropertyField(position, property, GUIContent.none);

			// End Property Field
			EditorGUI.EndProperty();

			#endregion
		}
	}
}