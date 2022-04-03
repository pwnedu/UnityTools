// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
	[CustomPropertyDrawer(typeof(FormatAttribute))]
	public class FormatPropertyDrawer : PropertyDrawer
	{
        private FormatAttribute format;
		private GUIStyle styleData;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			#region  Property Drawer Overrides

			// Start Property Field
			EditorGUI.BeginProperty(position, label, property);

			format = attribute as FormatAttribute;

			// Set GUI field colour
			var prevCol = GUI.backgroundColor;
			GUI.backgroundColor = BGColour;

			// Create Custom Font Style
			styleData = new GUIStyle()
			{
				normal = new GUIStyleState() { textColor = Colour },
				fontStyle = Style,
				alignment = Alignment
			};

			// Draw label
			label.text = $"{label.text}  ";
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label, styleData);

			// Draw field
			EditorGUI.PropertyField(position, property, GUIContent.none);

			// Revert GUI field colour
			GUI.backgroundColor = prevCol;

			// End Property Field
			EditorGUI.EndProperty();

			#endregion
		}

		private Color Colour
		{
			get { return FormatStringColour.Colour(format.colour); }
		}

		private Color BGColour
		{
			get { return FormatStringColour.Colour(format.bgColour); }
		}

		private FontStyle Style
		{
			#region Get Font Style Settings

			get
			{
				FontStyle font;

				if (format.bold && !format.italic) { font = FontStyle.Bold; }
				else if (!format.bold && format.italic) { font = FontStyle.Italic; }
				else if (format.bold && format.italic) { font = FontStyle.BoldAndItalic; }
				else { font = FontStyle.Normal; }

				return font;
			}

			#endregion
		}

		private TextAnchor Alignment
		{
			#region Get Text Alignment Settings

			get
			{
				TextAnchor alignment;

				if (format.indent) { alignment = TextAnchor.MiddleRight; }
				else { alignment = TextAnchor.MiddleLeft; }

				return alignment;
			}

			#endregion
		}
	}
}