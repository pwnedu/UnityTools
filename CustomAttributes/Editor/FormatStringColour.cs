// NOTE: Put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
	[InitializeOnLoad]
	public class FormatStringColour
	{
		private static FormatStyles colourData;

		static FormatStringColour()
		{
			FindStyleData();
		}

		public static Color Colour(string colour)
		{
            #region Get Colour Settings

            Color color = Color.grey * 1.5f;

			if (colourData != null && colourData.colours.Length > 0)
			{
				var length = colourData.colours.Length;
				for (int i = 0; i < length; i++)
				{
					if (colourData.colours[i].colourName == colour)
					{
						color = colourData.colours[i].textColour;
						break;
					}
				}
			}
			else
			{
				switch (colour)
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