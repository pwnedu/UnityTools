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
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null && styleData != null)
            {
                if (styleData.styles.Length > 0)
                {
                    foreach (var style in styleData.styles)
                    {
                        DrawAndApplyStyle(gameObject, style, selectionRect);
                    }
                }
            }
        }

        private static void DrawAndApplyStyle(GameObject gameObj, StyleData style, Rect selection)
        {
            if (style.headerTag == string.Empty) return;
            if (gameObj.name.Contains(style.headerTag))
            {
                if (style.useCaseScenario == UseCase.ForEditorUseOnly && !gameObj.CompareTag("EditorOnly"))
                {
                    gameObj.tag = "EditorOnly";
                }
                var size = new Vector2(selection.size.x * style.backgroundWidth, selection.size.y * style.backgroundHeight);
                var offsetRect = new Rect(selection.position, size);
                EditorGUI.DrawRect(offsetRect, style.BackgroundColor);
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
