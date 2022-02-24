using CustomExtensions;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace CustomProjectView
{
    [InitializeOnLoad]
    public class CustomProjectView : MonoBehaviour
    {
        private static CustomProjectStyles styleData;

        private static float displayHeight;
        public static float DisplayHeight { get { return displayHeight; } }

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

                if (selectionRect.width > styleData.widthToShowExtensions)
                {
                    switch (styleData.fileLabelType)
                    {
                        case FileInfoDisplay.None:
                            break;
                        case FileInfoDisplay.Extension:
                            DrawAndApplyExtensions(assetPath, selectionRect);
                            break;
                        case FileInfoDisplay.Size:
                            DrawAndApplyFileSize(assetPath, selectionRect);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void DrawAndApplyStyles(Object obj, StyleData style, Rect selection)
        {
            if (style.folderOrFileName == string.Empty) return;
            if (obj.name == style.folderOrFileName)
            {
                var offsetRect = GUIExtension.CalculateRect(selection, 18, style.rightOffset, style.backgroundHeight);
                displayHeight = offsetRect.height;

                EditorGUI.DrawRect(offsetRect, style.BackgroundColor);
                EditorGUI.LabelField(offsetRect, obj.name, style.TextStyle);

                if (style.iconType != Icon.None && selection.width > style.widthToShowIcons)
                {
                    GUIExtension.DrawIconStyle(style.iconType, selection, style.IconStyle);
                }
            }
        }

        private static void DrawAndApplyExtensions(string assetPath, Rect selection)
        {
            string extension = Path.GetExtension(assetPath);
            GUIExtension.DrawLabelStyle(extension, selection, styleData.LabelStyle);
        }

        private static void DrawAndApplyFileSize(string assetPath, Rect selection)
        {
            var isFile = File.Exists(assetPath);
            if (!isFile) { return; }

            long size = new FileInfo(assetPath).Length;

            string metric;
            if (size < 1000) { metric = $"{size} bytes"; }
            else if (size >= 1000 && size < 1000000) { metric = $"{(float)size / 1024:0.00} KB"; }
            else { metric = $"{(float)size / 1048576:0.00} MB"; }

            GUIExtension.DrawLabelStyle(metric, selection, styleData.LabelStyle);
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