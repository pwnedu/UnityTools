using UnityEditor;
using UnityEngine;

namespace CustomHierarchy
{
    [InitializeOnLoad]
    public class CustomHierarchy : MonoBehaviour
    {
        private static CustomHierarchyStyles styleData;

        static CustomHierarchy()
        {
            FindStyleData();
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject gameObj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObj != null && styleData != null)
            {
                if (styleData.styles.Length > 0)
                {
                    foreach (var style in styleData.styles)
                    {
                        DrawAndApplyStyle(gameObj, style, selectionRect);
                    }
                }
            }
        }

        private static void DrawAndApplyStyle(GameObject gameObj, StyleData style, Rect selection)
        {
            if (style.headerTag == string.Empty) return;
            if (gameObj.name.Contains(style.headerTag))
            {
                if (!gameObj.CompareTag("EditorOnly")) gameObj.tag = "EditorOnly";
                var size = new Vector2(selection.size.x * style.BackgroundWidth, selection.size.y * style.BackgroundHeight);
                Rect offsetRect = new Rect(selection.position, size);
                EditorGUI.DrawRect(new Rect(selection.position, size), style.BackgroundColor);
                EditorGUI.LabelField(offsetRect, gameObj.name.Replace(style.headerTag, ""), style.TextStyle);
            }
        }

        private static void FindStyleData()
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(CustomHierarchyStyles)}");
            if (guids.Length > 0)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[0]);
                styleData = AssetDatabase.LoadAssetAtPath<CustomHierarchyStyles>(path);
            }
        }
    }
}
