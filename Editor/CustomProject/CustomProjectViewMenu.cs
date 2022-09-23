using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomProjectView
{
    public class CustomProjectViewMenu
    {
        const string menuItem = "Tools/Custom Tools/Custom Project View/";
        const string toolPath = "Packages/com.kiltec.unitytools/Editor/CustomProject/";

        [MenuItem(menuItem + "Project View Settings", priority = 31)]
        private static void ProjectViewSettings()
        {
            var path = $"{toolPath}Default Project Styles.asset";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }

        [MenuItem(menuItem + "Project View Help", priority = 32)]
        private static void ProjectViewHelp()
        {
            var path = $"{toolPath}README.md";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }
    }
}