// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
	[InitializeOnLoad]
	[CustomPropertyDrawer(typeof(FormatAttribute))]
	public class FormatPropertyDrawer : PropertyDrawer
	{
		private static FormatStyles colourData;

		private FormatAttribute format;
		private GUIStyle styleData;

		static FormatPropertyDrawer()
		{
			FindStyleData();
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			#region  PropertyDrawer Overrides

			// Start Property Field
			EditorGUI.BeginProperty(position, label, property);

			format = (FormatAttribute)attribute;

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

			// End Property Field
			EditorGUI.EndProperty();

			#endregion
		}

		private Color Colour
		{
			#region Colour Attribute Retrieval
			
			get
			{
				Color color = Color.grey * 1.5f;

				if (colourData != null && colourData.colours.Length > 0)
				{
					var length = colourData.colours.Length;
					for (int i = 0; i < length; i++)
					{
						if (colourData.colours[i].colourName == format.colour)
						{
							color = colourData.colours[i].textColour;
							break;
						}
					}
				}
				else
				{
					switch (format.colour)
					{
						case "red": color = Color.red; break;
						case "green": color = Color.green; break;
						case "blue": color = Color.blue; break;
						case "yellow": color = Color.yellow; break;
						case "cyan": color = Color.cyan; break;
						case "magenta": color = Color.magenta; break;
						case "white": color = Color.white; break;
						case "grey": color = Color.grey; break;
						case "black": color = Color.black; break;
						case "clear": color = Color.clear; break;
						default: break;
					}
				}

				return color;
			}

			#endregion
		}

		private FontStyle Style
		{
			#region Style Attribute Retrieval

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
			#region Alignment Attribute Retrieval

			get
			{
				TextAnchor alignment;

				if (format.indent) { alignment = TextAnchor.MiddleRight; }
				else { alignment = TextAnchor.MiddleLeft; }

				return alignment;
			}

			#endregion
		}

		private static void FindStyleData()
		{
			var guids = AssetDatabase.FindAssets($"t:{typeof(FormatStyles)}");
			if (guids.Length > 0)
			{
				var path = AssetDatabase.GUIDToAssetPath(guids[0]);
				colourData = AssetDatabase.LoadAssetAtPath<FormatStyles>(path);
			}
		}
	}
}