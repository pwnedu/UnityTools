using CustomExtensions;
using UnityEngine;

namespace CustomHierarchy
{
    [CreateAssetMenu(menuName = "Unity Tools/Hierarchy View/Hierarchy Styles")]
    public class CustomHierarchyStyles : ScriptableObject
    {
        // Object Information Label Style
        public ObjectInfoDisplay displayLabelType;
        [Tooltip("Don't display a label for default states.")] public bool excludeDefault = true;
        [Range(0, 400), Tooltip("Min 0 is always on.  Below set value extensions are hidden.")] public float widthToShowLabels;
        [SerializeField] [Range(-40, 20), Tooltip("Min 0 is right justified.  Max 20 is the right offest.")] private float rightOffset;
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
                fixedHeight = CustomHierarchy.DisplayHeight,
                richText = true,
                fontSize = textSize
            },
            anchor = textAlign,
            xAdjust = rightOffset,
        };

        // Custom Hierarchy Style Data
        public StyleData[] styles;
    }

    [System.Serializable]
    public struct StyleData
    {
        public string headerTag;

        [Header("Icon Style")]
        public Icon iconType;
        [Range(0, 400), Tooltip("Min 0 is always on.  Below set value icons are hidden.")] public float widthToShowIcons;
        [SerializeField] [Range(-20, 20), Tooltip("Icon horizontal position. Min -20 is moved left. 0 is default position. Max 20 is moved right.")] private float iconOffset;
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
                fixedHeight = CustomHierarchy.DisplayHeight,
                richText = true,
                fontSize = iconSize
            },
            anchor = iconAlign,
            xAdjust = iconOffset,
        };

        [Header("Background Styles")]
        [Range(-27, 20), Tooltip("Min -27 is subtract left offset. 0 is default justified. Max 20 is add left offest.")] public float leftOffset;
        [Range(-40, 15), Tooltip("Min -40 is subtract right offset. 0 is default justified. Max 15 is add right offest.")] public float rightOffset;
        [Range(0, 1), Tooltip("Min 0 is off.  Max 1 is the default size.")] public float backgroundHeight;
        [SerializeField] [Tooltip("Increase the alpha channel to see the background.")] private Color backgroundColor;
        [SerializeField] private bool randomBackgroundColor;
        public Color BackgroundColor => randomBackgroundColor ? Random.ColorHSV() : backgroundColor;

        [Header("Text Styles")]
        [SerializeField] [Range(0, 16), Tooltip("Keep it 0 for default size. Max is 16 as per the range")] private int textSize;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color32 textColor;
        [SerializeField] private TextAnchor textAlignment;
        [SerializeField] private FontStyle textStyle;
        public GUIStyle TextStyle => new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = textColor },
            fontStyle = textStyle,
            alignment = textAlignment,
            fixedHeight = CustomHierarchy.DisplayHeight,
            richText = true,
            fontSize = textSize,
        };

        [Header("How Will This Be Used?")]
        public UseCase useCaseScenario;
    }

    public enum UseCase { ForInGameObject, ForEditorUseOnly }
    public enum ObjectInfoDisplay { None, ID, Layers, Tags, Direction, Position, Rotation, Quaternion, Scale, Children, Objects, State, Static }
}