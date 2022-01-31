/*
 * 
 * MIT License
 * 
 * Copyright © 2021 BlitzKorp Pty Ltd
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
 * IN THE SOFTWARE. 
 * 
 */

using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace pwnedu.Tools
{
    public class MyNotes : EditorWindow
    {
        //config
        static readonly string nl = Environment.NewLine; // Automatically select "\r\n" for win "\n" for mac
        static readonly string referencePath = "Assets/"; // This is the save path. Make sure it exists. 
        static readonly string fileName = "MyNote";
        static readonly string extension = ".txt";
        static readonly string appName = "My Notes";
        static readonly string appVersion = "v1.2";
        static readonly int lines = 4;

        //layout and style
        private static MyNotesStyle styleData;
        Color headerColour = new Color(59f / 255f, 63f / 255f, 171f / 255f, 255f / 255f);
        Color borderColour = new Color(171f / 255f, 115f / 255f, 59f / 255f, 255f / 255f);
        Texture2D headerTexture;
        Texture2D borderTexture;
        Rect headerSection;
        Rect header;
        Rect toolTip;
        Rect buttonBar;
        Rect saveIndicator;
        Rect bodySection;
        Vector2 scrollPos;
        GUIStyle style;

        //variables
        static string text = "";
        string documentChanged = "";
        string fixedLineBreaks = "";

        [MenuItem("Tools/Notes/My Notes %&n", priority = 20)] // Shortcut [Ctrl + Alt + N]
        public static void ShowWindow()
        {
            GetWindow(typeof(MyNotes));
        }

        public void OnEnable()
        {
            InitTextures();
            OpenNote();
        }

        private void OnFocus()
        {
            InitTextures();
        }

        private void OnHierarchyChange()
        {
            InitTextures();
        }

        public void InitTextures()
        {
            titleContent = new GUIContent(appName);

            FindStyleData();

            if (styleData != null)
            {
                headerColour = styleData.HeaderColor;
                borderColour = styleData.BackgroundColor;
            }

            headerTexture = new Texture2D(1, 1);
            headerTexture.SetPixel(0, 0, headerColour);
            headerTexture.Apply();

            borderTexture = new Texture2D(1, 1);
            borderTexture.SetPixel(0, 0, borderColour);
            borderTexture.Apply();

            Repaint();
        }

        private void OnGUI()
        {
            DrawLayout();
            DrawHeader();
            DrawContent();
        }

        private void DrawLayout()
        {
            headerSection.x = 0;
            headerSection.y = 0;
            headerSection.width = position.width;
            headerSection.height = 20;

            header.x = 4;
            header.y = -1;
            header.width = headerSection.width - (toolTip.width + buttonBar.width + saveIndicator.width + 6);
            header.height = 20;

            toolTip.x = headerSection.width - 186;
            toolTip.y = 1;
            toolTip.width = 10;
            toolTip.height = headerSection.height;

            buttonBar.x = headerSection.width - 175;
            buttonBar.y = 2.5f;
            buttonBar.width = 110;
            buttonBar.height = headerSection.height;

            saveIndicator.x = headerSection.width - 69;
            saveIndicator.y = 1;
            saveIndicator.width = 66;
            saveIndicator.height = headerSection.height;

            bodySection.x = headerSection.x;
            bodySection.y = headerSection.height;
            bodySection.width = position.width;
            bodySection.height = position.height - headerSection.height;
        }

        private void DrawHeader()
        {
            GUILayout.BeginArea(headerSection);
            if (headerTexture != null) { GUI.DrawTexture(headerSection, headerTexture); }
            GUILayout.EndArea();

            GUILayout.BeginArea(header);
            if (styleData == null) { style = EditorStyles.boldLabel; }
            else { style = new GUIStyle(styleData.TextStyle); }
 
            GUILayout.Label($"{Application.productName} {Application.version}", style);
            GUILayout.EndArea();

            GUILayout.BeginArea(buttonBar);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save", GUILayout.Width(50), GUILayout.Height(15)))
            {
                SaveNote();
                documentChanged = "saved";
            }
            if (GUILayout.Button("Close", GUILayout.Width(50), GUILayout.Height(15)))
            {
                if (documentChanged == "not saved")
                {
                    if (EditorUtility.DisplayDialog("Close Script", "This will close your notes without saving." + nl + "Are you sure?", "Confirm"))
                    {
                        this.Close();
                    }
                }
                else { this.Close(); }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            GUILayout.BeginArea(toolTip);
            EditorGUILayout.LabelField(new GUIContent("?", appName + " " + appVersion + nl + nl +
                "Press Ctrl + Alt + N to open My Notes or open " + nl + "from Tools > Note Editor." + nl + nl +
                "© " + DateTime.Now.Year + " BlitzKorp Pty Ltd"), EditorStyles.boldLabel);
            GUILayout.EndArea();

            GUILayout.BeginArea(saveIndicator);
            GUILayout.Label(documentChanged, EditorStyles.helpBox, GUILayout.Height(17));
            GUILayout.EndArea();
        }

        private void DrawContent()
        {
            if (borderTexture != null) { GUI.DrawTexture(bodySection, borderTexture); }
            GUILayout.BeginArea(bodySection);
            GUILayout.FlexibleSpace();
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            EditorGUI.BeginChangeCheck();
            text = GUILayout.TextArea(text, GUILayout.MaxHeight(position.height), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            if (EditorGUI.EndChangeCheck())
            {
                documentChanged = "not saved";
            }
            EditorGUILayout.EndScrollView();
            GUILayout.FlexibleSpace();
            GUILayout.EndArea();
        }

        private void OpenNote()
        {
            string path = referencePath + fileName + extension;

            if (!File.Exists(path))
            {
                ClearNote();
            }
            else
            {
                // Read text in the file.
                StreamReader reader = new StreamReader(path);
                text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void SaveNote()
        {
            // Make sure line endings are fit for the environment. Finds all occurrence of \r\n or \n and replaces with nl
            fixedLineBreaks = Regex.Replace(text, @"\r\n?|\n", nl);

            // Write text to the file.
            StreamWriter writer = new StreamWriter(referencePath + fileName + extension, false, encoding: Encoding.UTF8);
            writer.Flush();
            writer.Write(fixedLineBreaks);
            writer.Close();

            // Update the reference in the editor.
            AssetDatabase.Refresh();
        }

        private static void ClearNote()
        {
            // Clear the text.
            text = "";

            // Add blank lines.
            for (int i = 0; i < lines; i++)
            {
                text += nl;
            }
        }

        [MenuItem("Tools/Notes/Delete/Clear Note")]
        public static void DeleteSavedText()
        {
            string path = referencePath + fileName + extension;

            if (EditorUtility.DisplayDialog("Delete " + appName + " data", "This will clear all of your saved note data." + nl + "Are you sure?", "Confirm"))
            {
                if (File.Exists(path))
                {
                    ClearNote();

                    // Write blank text to the file.
                    StreamWriter writer = new StreamWriter(path, false, encoding: Encoding.UTF8);
                    writer.Flush();
                    writer.Write(text);
                    writer.Close();

                    // Redraw the note.
                    var window = GetWindow<MyNotes>();
                    window.OpenNote();
                    window.Repaint();

                    // Update the reference in the editor.
                    AssetDatabase.Refresh();
                }
                else
                {
                    Debug.LogWarning(appName + " " + appVersion + " message: There is no " + fileName + extension + " file to clear in folder " + referencePath);
                }
            }
        }

        private static void FindStyleData()
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(MyNotesStyle)}");
            if (guids.Length > 0)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[0]);
                styleData = AssetDatabase.LoadAssetAtPath<MyNotesStyle>(path);
            }
        }
    }
}
