// NOTE: put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
    [CustomEditor(typeof(FormatStyles))]
    public class FormatStylesEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var guiStyle = new GUIStyle()
            {
                normal = new GUIStyleState()
                {
                    textColor = new Color32(100, 150, 200, 255)
                },
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                fixedHeight = 40f,
                richText = true,
                fontSize = 18,
            };

            GUILayout.Label("Format Attribute Colour Styles", guiStyle);

            GUILayout.BeginVertical("Box");
            DrawDefaultInspector();
            GUILayout.EndVertical();
        }
    }
}