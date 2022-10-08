using UnityEngine;

namespace CustomConsole
{
    public static class CC
    {
        public static string ColToHex(Color32 colour)
        {
            Color32 col = colour;

            //Debug colour
            int intRedVal = col.r;
            int intGreenVal = col.g;
            int intBlueVal = col.b;

            string hexVal = intRedVal.ToString("X2") + intGreenVal.ToString("X2") + intBlueVal.ToString("X2");

            return hexVal;
        }

        public static string ColToHex(Color32 colour, bool debug)
        {
            Color32 col = colour;

            //Debug colour
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

        public static string ColToHex(Color colour)
        {
            Color col = colour;

            //Debug colour
            int intRedVal = (int)(col.r * 255);
            int intGreenVal = (int)(col.g * 255);
            int intBlueVal = (int)(col.b * 255);

            string hexVal = intRedVal.ToString("X2") + intGreenVal.ToString("X2") + intBlueVal.ToString("X2");

            return hexVal;
        }

        public static string ColToHex(Color colour, bool debug)
        {
            Color col = colour;

            //Debug colour
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

        public static string Col(Color colour)
        {
            return $"<color=#{ColToHex(colour)}>";
        }

        public static string End()
        {
            return "</color>";
        }
    }
}