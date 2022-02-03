using UnityEngine;
using UnityEditor;
using System.IO;

namespace CustomProjectView
{
    [InitializeOnLoad]
    public class CustomProjectView : MonoBehaviour
    {
        private static CustomProjectStyles styleData;

        private static readonly string bullet = "●";
        private static readonly string diamond = "◆";
        private static readonly string heart = "♥︎";
        private static readonly string triangle = "◀";

        static CustomProjectView()
        {
            FindStyleData();
            EditorApplication.projectWindowItemOnGUI += HandleProjectWindowItemOnGUI;
        }

        private static void HandleProjectWindowItemOnGUI(string guid, Rect selectionRect)
        {
            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var assetObject = AssetDatabase.LoadAssetAtPath<Object>(assetPath);

            bool noStyling = selectionRect.height > 20;
            if (noStyling || !assetObject) { return; }

            if (styleData != null)
            {
                if (styleData.styles.Length > 0)
                {
                    foreach (var style in styleData.styles)
                    {
                        DrawAndApplyStyles(assetObject, style, selectionRect);
                    }
                }

                if (styleData.showFileExtensions && selectionRect.width > styleData.widthToShowExtensions)
                {
                    DrawAndApplyExtensions(assetPath, selectionRect);
                }
            }
        }

        private static void DrawAndApplyStyles(Object obj, StyleData style, Rect selection)
        {
            if (style.folderOrFileName == string.Empty) return;
            if (obj.name == style.folderOrFileName)
            {
                var size = new Vector2(selection.size.x * style.backgroundWidth, selection.size.y * style.backgroundHeight);
                var position = new Vector2(selection.position.x + 18, selection.y);
                var offsetRect = new Rect(position, size);
                
                EditorGUI.DrawRect(offsetRect, style.BackgroundColor);
                EditorGUI.LabelField(offsetRect, obj.name, style.TextStyle);

                if (style.useIcons && selection.width > style.widthToShowIcons)
                {
                    GUIStyle iconStyle = new GUIStyle(EditorStyles.label);

                    Rect iconRect = selection;
                    iconRect.x += iconRect.width - 20;
                    iconRect.width = selection.width;

                    Color previousGuiColor = GUI.color;
                    GUI.color = style.IconColor;
                    switch (style.iconType)
                    {
                        case Icon.Bullet:
                            GUI.Label(iconRect, bullet, iconStyle);
                            break;
                        case Icon.Diamond:
                            GUI.Label(iconRect, diamond, iconStyle);
                            break;
                        case Icon.Heart:
                            GUI.Label(iconRect, heart, iconStyle);
                            break;
                        case Icon.Triangle:
                            GUI.Label(iconRect, triangle, iconStyle);
                            break;
                    }
                    GUI.color = previousGuiColor;
                }
            }
        }

        private static void DrawAndApplyExtensions(string assetPath, Rect selection)
        {
            string extension = Path.GetExtension(assetPath);

            GUIStyle labelStyle = new GUIStyle(EditorStyles.label);
            Vector2 labelSize = labelStyle.CalcSize(new GUIContent(extension));

            Rect extensionRect = selection;
            extensionRect.width += selection.x;
            extensionRect.x = extensionRect.width - labelSize.x - 4;

            Color previousGuiColor = GUI.color;
            GUI.color = styleData.TextColor;
            GUI.Label(extensionRect, extension, labelStyle);
            GUI.color = previousGuiColor;
        }

        private static void FindStyleData()
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(CustomProjectStyles)}");
            if (guids.Length > 0)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[0]);
                styleData = AssetDatabase.LoadAssetAtPath<CustomProjectStyles>(path);
            }
        }
    }
}