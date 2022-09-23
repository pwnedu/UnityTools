using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomHierarchy
{
    public class CustomHierarchyMenu
    {
        const string menuItem = "Tools/Custom Tools/Custom Hierarchy/";
        const string toolPath = "Packages/com.kiltec.unitytools/Editor/CustomHierarchy/";

        [MenuItem(menuItem + "Hierarchy Settings", priority = 21)]
        private static void HierarchySettings()
        {
            var path = $"{toolPath}Default Hierarchy Styles.asset";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }

        [MenuItem(menuItem + "Hierarchy Help", priority = 22)]
        private static void HierarchyHelp()
        {
            var path = $"{toolPath}README.md";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }
    }
}