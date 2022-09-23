using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomAttributes 
{
    public class CustomAttributesMenu
    {
        const string menuItem = "Tools/Custom Tools/Custom Attributes/";
        const string toolPath = "Packages/com.kiltec.unitytools/CustomAttributes/";

        [MenuItem(menuItem + "Attribute Settings", priority = 11)]
        private static void AttributeSettings()
        {
            var path = $"{toolPath}Editor/Styles/Format Styles Default Colours.asset";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }

        [MenuItem(menuItem + "Attribute Help", priority = 12)]
        private static void AttributeHelp()
        {
            var path = $"{toolPath}README.md";

            if (!File.Exists(path)) { return; }

            var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }
    }
}