using CustomExtensions;
using UnityEditor;
using UnityEngine;

namespace CustomHierarchy
{
    [InitializeOnLoad]
    public class CustomHierarchy : MonoBehaviour
    {
        private static CustomHierarchyStyles styleData;

        private static readonly int IgnoreLayer = LayerMask.NameToLayer("Default");
        private static readonly string IgnoreTag = "Untagged";
        private static readonly string EditorTag = "EditorOnly";

        private static readonly string IdLabel = "ID";
        private static readonly string DynamicLabel = "Dynamic";
        private static readonly string ChildrenLabel = "Children";
        private static readonly string ObjectsLabel = "Objects";
        private static readonly string ActiveLabel = "Enabled";
        private static readonly string InactiveLabel = "Disabled";
        private static readonly string StaticLabel = "Static";

        private static float displayHeight;
        public static float DisplayHeight { get { return displayHeight; } }

        static CustomHierarchy()
        {
            FindStyleData();
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject && styleData != null)
            {
                if (styleData.styles.Length > 0)
                {
                    foreach (var style in styleData.styles)
                    {
                        DrawAndApplyStyle(gameObject, style, selectionRect);
                    }
                }

                if (selectionRect.width > styleData.widthToShowLabels)
                {
                    switch (styleData.displayLabelType)
                    {
                        case ObjectInfoDisplay.None:
                            break;
                        case ObjectInfoDisplay.ID:
                            DrawAndApplyID(gameObject, instanceID, selectionRect);
                            break;
                        case ObjectInfoDisplay.Layers:
                            DrawAndApplyLayers(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Tags:
                            DrawAndApplyTags(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Direction:
                            DrawAndApplyDirection(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Position:
                            DrawAndApplyPosition(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Rotation:
                            DrawAndApplyRotation(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Quaternion:
                            DrawAndApplyQuaternion(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Scale:
                            DrawAndApplyScale(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Children:
                            DrawAndApplyChildCount(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Objects:
                            DrawAndApplyObjectCount(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.State:
                            DrawAndApplyState(gameObject, selectionRect);
                            break;
                        case ObjectInfoDisplay.Static:
                            DrawAndApplyStatic(gameObject, selectionRect);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void DrawAndApplyStyle(GameObject gameObj, StyleData style, Rect selection)
        {
            if (style.headerTag == string.Empty) { return; }
            if (gameObj.name.Contains(style.headerTag))
            {
                if (style.useCaseScenario == UseCase.ForEditorUseOnly && !gameObj.CompareTag(EditorTag))
                {
                    gameObj.tag = EditorTag;
                }

                var offsetRect = GUIExtension.CalculateRect(selection, style.leftOffset, style.rightOffset, style.backgroundHeight);
                displayHeight = offsetRect.height;

                EditorGUI.DrawRect(offsetRect, style.BackgroundColor);
                EditorGUI.LabelField(offsetRect, gameObj.name.Replace(style.headerTag, ""), style.TextStyle);

                if (style.iconType != Icon.None && selection.width > style.widthToShowIcons)
                {
                    GUIExtension.DrawIconStyle(style.iconType, selection, style.IconStyle);
                }
            }
        }

        private static void DrawAndApplyID(GameObject gameObject, int id, Rect selection)
        {
            if (styleData.excludeDefault && gameObject.transform.parent) { return; }
            AddLabel($"{IdLabel} {id}", selection);
        }

        private static void DrawAndApplyLayers(GameObject gameObject, Rect selection)
        {
            var layer = gameObject.layer;
            if (styleData.excludeDefault && layer == IgnoreLayer) { return; }
            AddLabel(LayerMask.LayerToName(layer), selection);
        }

        private static void DrawAndApplyTags(GameObject gameObject, Rect selection)
        {
            if (styleData.excludeDefault && gameObject.CompareTag(IgnoreTag)) { return; }
            AddLabel(gameObject.tag, selection);
        }

        private static void DrawAndApplyDirection(GameObject gameObject, Rect selection)
        {
            var direction = gameObject.transform.forward;
            if (styleData.excludeDefault && direction == Vector3.forward) { return; }
            AddLabel($"D{direction}", selection);
        }

        private static void DrawAndApplyPosition(GameObject gameObject, Rect selection)
        {
            var position = gameObject.transform.localPosition;
            if (styleData.excludeDefault && position == Vector3.zero) { return; }
            AddLabel($"P{position}", selection);
        }

        private static void DrawAndApplyRotation(GameObject gameObject, Rect selection)
        {
            var rotation = gameObject.transform.rotation.eulerAngles;
            if (styleData.excludeDefault && rotation == Vector3.zero) { return; }
            AddLabel($"R{rotation}", selection);
        }

        private static void DrawAndApplyQuaternion(GameObject gameObject, Rect selection)
        {
            var rotation = gameObject.transform.rotation;
            if (styleData.excludeDefault && rotation == Quaternion.identity) { return; }
            AddLabel($"Q{rotation}", selection);
        }

        private static void DrawAndApplyScale(GameObject gameObject, Rect selection)
        {
            var scale = gameObject.transform.localScale;
            if (styleData.excludeDefault && scale == Vector3.one) { return; }
            AddLabel($"S{scale}", selection);
        }

        private static void DrawAndApplyChildCount(GameObject gameObject, Rect selection)
        {
            var count = gameObject.transform.childCount;
            if (styleData.excludeDefault && count == 0) { return; }
            AddLabel($"{ChildrenLabel} {count}", selection);
        }

        private static void DrawAndApplyObjectCount(GameObject gameObject, Rect selection)
        {
            if (gameObject.transform.parent) { return; }
            var count = gameObject.transform.hierarchyCount;
            if (styleData.excludeDefault && count == 1) { return; }
            AddLabel($"{ObjectsLabel} {count}", selection);
        }

        private static void DrawAndApplyState(GameObject gameObject, Rect selection)
        {
            var active = gameObject.activeSelf;
            if (styleData.excludeDefault && active) { return; }
            if (active) { AddLabel(ActiveLabel, selection); }
            else { AddLabel(InactiveLabel, selection); }
        }

        private static void DrawAndApplyStatic(GameObject gameObject, Rect selection)
        {
            var staticState = gameObject.isStatic;
            if (styleData.excludeDefault && !staticState) { return; }
            if (staticState) { AddLabel(StaticLabel, selection); }
            else { AddLabel(DynamicLabel, selection); }
        }

        private static void AddLabel(string label, Rect selection)
        {
            GUIExtension.DrawLabelStyle(label, selection, styleData.LabelStyle);
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