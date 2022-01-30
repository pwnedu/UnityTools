using UnityEngine;

namespace CustomHierarchy
{
    [CreateAssetMenu(menuName = "Hierarchy/Styles")]
    public class CustomHierarchyStyles : ScriptableObject
    {
        public StyleData[] styles;
    }

    [System.Serializable]
    public struct StyleData
    {
        public string headerTag;
        [Header("Background Styles")]
        [Range(0, 1), Tooltip("Min 0 is off.  Max 1 is the default size.")] public float backgroundWidth;
        [Range(0, 1), Tooltip("Min 0 is off.  Max 1 is the default size.")] public float backgroundHeight;
        [SerializeField] [Tooltip("Increase the alpha channel to see the background.")] private Color backgroundColor;
        [SerializeField] private bool randomBackgroundColor;
        public Color BackgroundColor => randomBackgroundColor ? Random.ColorHSV() : backgroundColor;

        [Header("Text Styles")]
        [Range(0, 16), Tooltip("Keep it 0 for default size. Max is 16 as per the range")]
        [SerializeField] private int textSize;
        [SerializeField] [Tooltip("Increase the alpha channel to see the text.")] private Color32 textColor;
        [SerializeField] private TextAnchor textAlignment;
        [SerializeField] private FontStyle textStyle;
        public GUIStyle TextStyle => new GUIStyle()
        {
            normal = new GUIStyleState() { textColor = textColor },
            fontStyle = textStyle,
            alignment = textAlignment,
            richText = true,
            fontSize = textSize,
        };
        
        [Header("How Will This Be Used?")]
        public UseCase useCaseScenario;
    }

    public enum UseCase { ForInGameObject, ForEditorUseOnly }
}
