
// NOTE: DON'T put in an editor folder. //

using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <para>Use this PropertyAttribute to display a dial to represent angles in the inspector: </para>
    /// <code>[Angle("measeurementString", snappingFloat, minimumAngleFloat, maximumAngleFloat, dialSizeFloat, dialFirstBool, leftJustifiedBool, calculateSingleRotationBool, colour = "colourString")]</code>
    /// <para>Available Colours: </para>
    /// <code> "red", "green", "blue", "yellow", "orange", "cyan", "magenta", "white"</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Display a dial with degrees measure and cyan indicator, angle snapping whole numbers, dial size of 100, minimum value -180, maximum value 180, dial last, right justified, normalRotation: </para>
    /// <code>[Angle("degrees", 1f, -180, 180, 100, false, false, false, colour = "cyan")] private float myProgress;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a dial with degrees measure and orange indicator, angle snapping 45 degrees, dial size of 80, minimum value 0, maximum value 360, dial first, left justified, normalRotation: </para>
    /// <code>[Angle("degrees", 45f, 0, 360, 80, true, true, false, colour = "orange")] private float myProgress;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a dial with degrees measure and green indicator, angle snapping whole numbers, dial size of 60, minimum value -360, maximum value 360, dial last, right justified, normalRotation: </para>
    /// <code>[Angle] private float myProgress;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class AngleAttribute : PropertyAttribute
    {
        public string colour;
        public string unit;
        public float snap;
        public float min;
        public float max;
        public float height;
        public bool dialFirst;
        public bool alignLeft;
        public bool limitRotation;

        public AngleAttribute()
        {
            colour = "green";
            unit = null;
            snap = 1;
            min = -360;
            max = 360;
            height = 60;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(float angleSnap)
        {
            colour = "green";
            unit = null;
            snap = angleSnap;
            min = -360;
            max = 360;
            height = 60;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(float angleSnap, float minimum, float maximum)
        {
            colour = "green";
            unit = null;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = 60;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(float angleSnap, float minimum, float maximum, float dialSize)
        {
            colour = "green";
            unit = null;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(float angleSnap, float minimum, float maximum, float dialSize, bool dialIsFirst)
        {
            colour = "green";
            unit = null;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = dialIsFirst;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(float angleSnap, float minimum, float maximum, float dialSize, bool dialIsFirst, bool leftJustify)
        {
            colour = "green";
            unit = null;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = dialIsFirst;
            alignLeft = leftJustify;
            limitRotation = false;
        }

        public AngleAttribute(float angleSnap, float minimum, float maximum, float dialSize, bool dialIsFirst, bool leftJustify, bool calculateSingleRotation)
        {
            colour = "green";
            unit = null;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = dialIsFirst;
            alignLeft = leftJustify;
            limitRotation = calculateSingleRotation;
        }

        public AngleAttribute(string measurement)
        {
            colour = "green";
            unit = measurement;
            snap = 1;
            min = -360;
            max = 360;
            height = 60;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(string measurement, float angleSnap)
        {
            colour = "green";
            unit = measurement;
            snap = angleSnap;
            min = -360;
            max = 360;
            height = 60;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(string measurement, float angleSnap, float minimum, float maximum)
        {
            colour = "green";
            unit = measurement;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = 60;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(string measurement, float angleSnap, float minimum, float maximum, float dialSize)
        {
            colour = "green";
            unit = measurement;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = false;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(string measurement, float angleSnap, float minimum, float maximum, float dialSize, bool dialIsFirst)
        {
            colour = "green";
            unit = measurement;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = dialIsFirst;
            alignLeft = false;
            limitRotation = false;
        }

        public AngleAttribute(string measurement, float angleSnap, float minimum, float maximum, float dialSize, bool dialIsFirst, bool leftJustify)
        {
            colour = "green";
            unit = measurement;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = dialIsFirst;
            alignLeft = leftJustify;
            limitRotation = false;
        }

        public AngleAttribute(string measurement, float angleSnap, float minimum, float maximum, float dialSize, bool dialIsFirst, bool leftJustify, bool calculateSingleRotation)
        {
            colour = "green";
            unit = measurement;
            snap = angleSnap;
            min = minimum;
            max = maximum;
            height = dialSize;
            dialFirst = dialIsFirst;
            alignLeft = leftJustify;
            limitRotation = calculateSingleRotation;
        }
    }
}