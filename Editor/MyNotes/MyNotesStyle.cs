using UnityEngine;

namespace MyNotes
{
    [CreateAssetMenu(menuName = "Unity Tools/My Notes/Notes Style", order = 1)]
    public class MyNotesStyle : ScriptableObject
    {
        public StyleData style;
    }

    [System.Serializable]
    public struct StyleData
    {
        [Header("Border Background Style")]
        [SerializeField] [Tooltip("Increase the alpha channel to see the background.")] private Color backgroundColor;
        [SerializeField] private bool randomBackgroundColor;
        public Color BackgroundColor => randomBackgroundColor ? Random.ColorHSV() : backgroundColor;

        [Header("Header Background Style")]
        [SerializeField] [Tooltip("Increase the alpha channel to see the background.")] private Color headerColor;
        [SerializeField] private bool randomHeaderColor;
        public Color HeaderColor => randomHeaderColor ? Random.ColorHSV() : headerColor;

        [Header("Header Text Style")]
        [SerializeField] [Range(0, 18), Tooltip("Keep it 0 for default size. Max is 16 as per the range")] private int textSize;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color32 textColor;
        [SerializeField] private TextAnchor textAlignment;
        [SerializeField] private FontStyle textStyle;
        public GUIStyle TextStyle => new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = textColor },
            fontStyle = textStyle,
            alignment = textAlignment,
            clipping = TextClipping.Clip,
            fixedHeight = 20,
            richText = true,
            fontSize = textSize,
        };
    }
}