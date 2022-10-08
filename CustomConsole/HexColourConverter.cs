using UnityEngine;

namespace CustomConsole
{
    public static class CC
    {
        // Color32 To Hex Conversion
        public static string ColToHex(Color32 colour)
        {
            Color32 col = colour;

            // Separate colour
            int intRedVal = col.r;
            int intGreenVal = col.g;
            int intBlueVal = col.b;

            string hexVal = intRedVal.ToString("X2") + intGreenVal.ToString("X2") + intBlueVal.ToString("X2");

            return hexVal;
        }

        // Log Color32 Conversion
        public static string ColToHex(Color32 colour, bool debug)
        {
            Color32 col = colour;

            int intRedVal = col.r;
            int intGreenVal = col.g;
            int intBlueVal = col.b;

            string hexVal = intRedVal.ToString("X2") + intGreenVal.ToString("X2") + intBlueVal.ToString("X2");

            if (debug)
            {
                Debug.Log($"Input Colour32: <color=#{hexVal}>{col} Return: Hex(#{hexVal})</color>");
            }

            return hexVal;
        }

        // Color To Hex Conversion
        public static string ColToHex(Color colour)
        {
            Color col = colour;

            int intRedVal = (int)(col.r * 255);
            int intGreenVal = (int)(col.g * 255);
            int intBlueVal = (int)(col.b * 255);

            string hexVal = intRedVal.ToString("X2") + intGreenVal.ToString("X2") + intBlueVal.ToString("X2");

            return hexVal;
        }

        // Log Color Conversion
        public static string ColToHex(Color colour, bool debug)
        {
            Color col = colour;

            int intRedVal = (int)(col.r * 255);
            int intGreenVal = (int)(col.g * 255);
            int intBlueVal = (int)(col.b * 255);

            string hexVal = intRedVal.ToString("X2") + intGreenVal.ToString("X2") + intBlueVal.ToString("X2");

            if (debug)
            {
                Debug.Log($"Input Colour: <color=#{hexVal}>{col} Return: Hex(#{hexVal})</color>");
            }

            return hexVal;
        }


        // Debug Color Start
        public static string Col(Color colour)
        {
            return $"<color=#{ColToHex(colour)}>";
        }

        // Debug Color End
        public static string End()
        {
            return "</color>";
        }
    }
}