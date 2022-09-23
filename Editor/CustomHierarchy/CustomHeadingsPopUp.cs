using UnityEngine;
using UnityEditor;

namespace CustomHierarchy
{
    public class CustomHeadingsPopUp : EditorWindow
    {
        public static CustomHeadingsPopUp renameWindow;

        Texture2D iconTexture;
        Texture2D borderTexture;
        Texture2D bgTexture;

        Rect iconSection;
        Rect closeSection;
        Rect borderSection;
        Rect bgSection;

        Color borderColour = new Color32(150, 150, 150, 255);
        Color backgroundColor = new Color32(75, 75, 75, 255);

        readonly float windowWidth = 400f;
        readonly float windowHeight = 175f;
        readonly float iconSize = 36f;
        readonly float layout = 115f;
        readonly float inputStart = 90f;
        readonly float inputWidth = 160f;
        readonly float inputHeight = 18f;
        readonly float buttonWidth = 100f;
        readonly float verticalGap = 20f;

        string renameOne;
        string renameTwo;
        string renameThree;
        string renameFour;

        public static void Initialise()
        {
            if (renameWindow == null)
            {
                renameWindow = CreateInstance<CustomHeadingsPopUp>();
            }

            var resolution = Screen.currentResolution;
            var width = renameWindow.windowWidth;
            var height = renameWindow.windowHeight;
            renameWindow.position = new Rect((resolution.width * 0.5f) - (width * 0.5f), (resolution.height * 0.5f) - (height * 0.5f), width, height);
            renameWindow.ShowPopup();
        }

        private void InitTexturesAndDrawLayout()
        {
            borderTexture = new Texture2D(1, 1);
            borderTexture.SetPixel(0, 0, borderColour);
            borderTexture.Apply();

            bgTexture = new Texture2D(1, 1);
            bgTexture.SetPixel(0, 0, backgroundColor);
            bgTexture.Apply();

            iconTexture = Resources.Load<Texture2D>("settings");

            borderSection.x = 0f;
            borderSection.y = 0f;
            borderSection.width = windowWidth;
            borderSection.height = windowHeight;

            bgSection.x = 2f;
            bgSection.y = 2f;
            bgSection.width = windowWidth-4;
            bgSection.height = windowHeight-4;

            closeSection.x = windowWidth - 36f;
            closeSection.y = 15f;
            closeSection.width = 20f;
            closeSection.height = 20f;

            iconSection.x = 15;
            iconSection.y = 15;
            iconSection.width = iconSize;
            iconSection.height = iconSize;
        }

        private void OnEnable()
        {
            InitTexturesAndDrawLayout();
        }

        private void OnGUI()
        {
            if (borderTexture != null)
            {
                GUI.DrawTexture(borderSection, borderTexture);
            }

            if (bgTexture != null)
            {
                GUI.DrawTexture(bgSection, bgTexture);
            }

            if (iconTexture != null)
            {
                GUI.DrawTexture(iconSection, iconTexture);
            }

            // Close Button
            GUILayout.BeginArea(closeSection);
            if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20))) { this.Close(); }
            GUILayout.EndArea();

            // Heading
            GUILayout.Space(15);
            GUILayout.BeginHorizontal();
            GUILayout.Space(layout);
            EditorGUILayout.LabelField("Rename Hierarchy Info Labels", EditorStyles.whiteLargeLabel);
            GUILayout.EndHorizontal();
            GUILayout.Space(verticalGap);

            // Input Fields
            switch (CustomHierarchy.styleData.displayLabelType)
            {
                case ObjectInfoDisplay.None:
                    break;
                case ObjectInfoDisplay.ID:
                    break;
                case ObjectInfoDisplay.Layers:
                    break;
                case ObjectInfoDisplay.Tags:
                    break;
                case ObjectInfoDisplay.Direction:
                    break;
                case ObjectInfoDisplay.Position:
                    break;
                case ObjectInfoDisplay.Rotation:
                    break;
                case ObjectInfoDisplay.Quaternion:
                    break;
                case ObjectInfoDisplay.Scale:
                    break;
                case ObjectInfoDisplay.Children:
                    break;
                case ObjectInfoDisplay.Objects:
                    break;
                case ObjectInfoDisplay.State:
                    break;
                case ObjectInfoDisplay.Static:
                    break;
                case ObjectInfoDisplay.SpriteAll:
                    SetField("Sorting Layer", ref renameOne, ref CustomHierarchy.styleData.spriteLayerName, ref CustomHierarchy.spriteLayer);
                    GUILayout.Space(verticalGap);
                    SetField("Sorting Order", ref renameTwo, ref CustomHierarchy.styleData.spriteOrderName, ref CustomHierarchy.spriteOrder);
                    break;
                case ObjectInfoDisplay.SpriteLayer:
                    SetField("Sorting Layer", ref renameThree, ref CustomHierarchy.styleData.sortingLayerName, ref CustomHierarchy.sortingLayer);
                    break;
                case ObjectInfoDisplay.SpriteOrder:
                    SetField("Sorting Order", ref renameFour, ref CustomHierarchy.styleData.sortingOrderName, ref CustomHierarchy.sortingOrder);
                    break;
            }
        }

        private void SetField(string name, ref string newName, ref string styleField, ref string localField)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(layout);
            EditorGUILayout.LabelField($"Current Label: {localField}", EditorStyles.wordWrappedLabel); 
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(verticalGap);
            GUILayout.Label($"{name}:", EditorStyles.label, GUILayout.Width(inputStart), GUILayout.Height(inputHeight));
            newName = GUILayout.TextField(newName, GUILayout.Width(inputWidth), GUILayout.Height(inputHeight));
            if (GUILayout.Button("Rename", GUILayout.Width(buttonWidth)))
            {
                styleField = newName;
                localField = newName;
                AssetDatabase.SaveAssets();
            }
            GUILayout.EndHorizontal();
        }
    }
}