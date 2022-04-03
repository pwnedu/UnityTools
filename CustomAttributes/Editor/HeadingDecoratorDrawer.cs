// NOTE: Put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
	[CustomPropertyDrawer(typeof(HeadingAttribute))]
	public class HeadingDecoratorDrawer : DecoratorDrawer
	{
		HeadingAttribute headingAttribute;
		private GUIStyle styleData;

		public override float GetHeight()
		{
			headingAttribute = attribute as HeadingAttribute;
			return base.GetHeight() * 2.5f;
		}

		public override void OnGUI(Rect position)
		{
			#region Decorator Property Overrides

			position.yMin += EditorGUIUtility.singleLineHeight * 0.5f;
			position = EditorGUI.IndentedRect(position);

			// Create Custom Font Style
			styleData = new GUIStyle()
			{
				normal = new GUIStyleState() { textColor = Colour },
				fontSize = headingAttribute.size,
				fontStyle = Style,
				alignment = Alignment
			};

			GUI.Label(position, headingAttribute.header, styleData);

			#endregion
		}

		private Color Colour
		{
			get { return FormatStringColour.Colour(headingAttribute.colour); }
		}

		private FontStyle Style
		{
            #region Get Font Style Settings

            get
            {
				FontStyle font;

				if (headingAttribute.bold && !headingAttribute.italic) { font = FontStyle.Bold; }
				else if (!headingAttribute.bold && headingAttribute.italic) { font = FontStyle.Italic; }
				else if (headingAttribute.bold && headingAttribute.italic) { font = FontStyle.BoldAndItalic; }
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

				if (headingAttribute.center) { alignment = TextAnchor.MiddleCenter; }
				else { alignment = TextAnchor.MiddleLeft; }

				return alignment;
			}

            #endregion
        }
    }
}