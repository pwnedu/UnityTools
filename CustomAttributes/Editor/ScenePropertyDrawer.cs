// NOTE: Put in a Editor folder. //

using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class ScenePropertyDrawer : PropertyDrawer
    {
        private readonly string nameColour = "#ffbd00";
        private readonly string indexColour = "#9577ea";

        SceneAttribute SceneSelectAttribute { get { return (SceneAttribute)attribute; } }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Property Drawer Overrides

            if (property == null) { return; }

            string[] scenePaths = GetScenePaths();

            if (scenePaths.Length == 0) { return; }

            string[] sceneNames = GetSceneNames(scenePaths);

            using (new EditorGUI.PropertyScope(position, label, property))
            {
                using (EditorGUI.ChangeCheckScope changeCheck = new EditorGUI.ChangeCheckScope())
                {
                    switch (property.propertyType)
                    {
                        case SerializedPropertyType.String:
                            DrawStringProperty(position, property, label, scenePaths, sceneNames);
                            break;
                        case SerializedPropertyType.Integer:
                            DrawIntProperty(position, property, label, sceneNames);
                            break;
                        default:
                            Debug.LogError($"{nameof(SceneAttribute)} supports only string and int fields.");
                            break;
                    }

                    if (changeCheck.changed)
                    {
                        property.serializedObject?.ApplyModifiedProperties();
                    }
                }
            }

            #endregion
        }

        private string[] GetScenePaths()
        {
            #region Get Scenes Paths

            var sceneList = new List<string>();

            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (!string.IsNullOrEmpty(scene.path))
                {
                    sceneList.Add(scene.path);
                }
            }

            return sceneList.ToArray();

            #endregion
        }

        private string[] GetSceneNames(string[] scenes)
        {
            #region Get Scene Names

            var nameList = new List<string>();

            foreach (var scene in scenes)
            {
                if (!string.IsNullOrEmpty(scene))
                {
                    string path = scene;
                    path = path.Remove(0, path.LastIndexOf('/') + 1);
                    path = path.Replace(".unity", "");
                    nameList.Add(path);
                }
            }

            return nameList.ToArray();

            #endregion
        }

        private void DrawStringProperty(Rect rect, SerializedProperty property, GUIContent label, string[] scenePaths, string[] sceneNames)
        {
            #region Draw String Properties

            int index = Mathf.Clamp(Array.IndexOf(scenePaths, property.stringValue), 0, scenePaths.Length);
            int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, sceneNames);
            string newScene = scenePaths[newIndex];

            if (property.stringValue?.Equals(newScene, StringComparison.Ordinal) == false)
            {
                property.stringValue = scenePaths[newIndex];
                if (SceneSelectAttribute.debug)
                {
                    Debug.Log($"Scene Name: <color={nameColour}>{sceneNames[newIndex]}</color> Scene Path: {scenePaths[newIndex]}");
                }
            }

            #endregion
        }

        private void DrawIntProperty(Rect rect, SerializedProperty property, GUIContent label, string[] sceneNames)
        {
            #region Draw Int Properties

            int index = property.intValue;
            int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, sceneNames);

            if (property.intValue != newIndex)
            {
                property.intValue = newIndex;
                if (SceneSelectAttribute.debug)
                {
                    Debug.Log($"Scene Index: <color={indexColour}>{newIndex}</color> Scene Name: {sceneNames[newIndex]}");
                }
            }

            #endregion
        }
    }
}