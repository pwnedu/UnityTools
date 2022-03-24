﻿// NOTE: put in a Editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    [CreateAssetMenu(menuName = "Custom View Styles/Format Styles", order = 4)]
    public class FormatStyles : ScriptableObject
    {
        public ColourData[] colours;

        [System.Serializable]
        public struct ColourData
        {
            [Tooltip("Name reference to call text colour.")] public string colourName;
            [Tooltip("Increase the alpha channel to see the text.")] public Color textColour;
        }
    }
}