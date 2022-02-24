using CustomExtensions;
using UnityEngine;

namespace CustomProjectView
{
    [CreateAssetMenu(menuName = "Unity Tools/Project View/Project Styles")]
    public class CustomProjectStyles : ScriptableObject
    {
        // File Information Label Style
        public FileInfoDisplay fileLabelType;
        [Range(0, 400), Tooltip("Min 0 is always on.  Below set value extensions are hidden.")] public float widthToShowExtensions;
        [SerializeField] [Range(-20, 0), Tooltip("Min 0 is right justified.  Max 20 is the right offest.")] private float rightOffset;
        [SerializeField] [Range(0, 16), Tooltip("Keep it 0 for default size. Max is 16 as per the range")] private int textSize;
        [SerializeField] [Tooltip("Vertical text alignment.")] private InfoAnchor textAlign = InfoAnchor.Top;
        [SerializeField] [Tooltip("Font stylig.")] private FontStyle textStyle = FontStyle.Normal;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color textColor;
        [SerializeField] private bool randomTextColor;
        public Color TextColor => randomTextColor ? Random.ColorHSV() : textColor;
        public LabelStyle LabelStyle => new LabelStyle()
        {
            guiStyle = new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = textColor },
                fontStyle = textStyle,
                alignment = TextAnchor.UpperLeft,
                fixedHeight = CustomProjectView.DisplayHeight,
                richText = true,
                fontSize = textSize
            },
            anchor = textAlign,
            xAdjust = rightOffset
        };

        // Custom Project View Style Data
        public StyleData[] styles;
    }

    [System.Serializable]
    public struct StyleData
    {
        public string folderOrFileName;

        [Header("Icon Style")]
        public Icon iconType;
        [Range(0, 400), Tooltip("Min 0 is always on. Below set value icons are hidden.")] public float widthToShowIcons;
        [SerializeField] [Range(-10, 10), Tooltip("Icon horizontal position. Min -10 move left. Max 10 move right.")] private float iconOffset;
        [SerializeField] [Range(0, 16), Tooltip("Keep it 0 for default size. Max is 16 as per the range")] private int iconSize;
        [SerializeField] [Tooltip("Vertical icon alignment.")] private InfoAnchor iconAlign;
        [SerializeField] [Tooltip("Increase the alpha channel to see the icon.")] private Color iconColor;
        [SerializeField] private bool randomIconColor;
        public Color IconColor => randomIconColor ? Random.ColorHSV() : iconColor;
        public LabelStyle IconStyle => new LabelStyle()
        {
            guiStyle = new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = iconColor },
                fontStyle = FontStyle.Normal,
                alignment = TextAnchor.UpperLeft,
                fixedHeight = CustomProjectView.DisplayHeight,
                richText = true,
                fontSize = iconSize
            },
            anchor = iconAlign,
            xAdjust = iconOffset,
        };

        [Header("Background Style")]
        [Range(-40, 0), Tooltip("Min 0 is right justified.  Max -40 is the right offest.")] public float rightOffset;
        [Range(0, 1), Tooltip("Min 0 is off.  Max 1 is the default size.")] public float backgroundHeight;
        [SerializeField] [Tooltip("Increase the alpha channel to see the background.")] private Color backgroundColor;
        [SerializeField] private bool randomBackgroundColor;
        public Color BackgroundColor => randomBackgroundColor ? Random.ColorHSV() : backgroundColor;

        [Header("Text Style")]
        [SerializeField] [Range(0, 16), Tooltip("Keep it 0 for default size. Max is 16 as per the range")] private int textSize;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color32 textColor;
        [SerializeField] private TextAnchor textAlignment;
        [SerializeField] private FontStyle textStyle;
        public GUIStyle TextStyle => new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = textColor },
            fontStyle = textStyle,
            alignment = textAlignment,
            fixedHeight = CustomProjectView.DisplayHeight,
            richText = true,
            fontSize = textSize
        };
    }

    public enum FileInfoDisplay { None, Extension, Size }
}