// NOTE: Put in a Editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(AngleAttribute))]
    public class AnglePropertyDrawer : PropertyDrawer
    {
        AngleAttribute angleAttribute;

        private static readonly Texture2D dial = (Texture2D)Resources.Load("Dial2");// as Texture2D;
        private static Texture2D indicator;
        private static readonly float valueWidth = 64f;
        private static readonly float offset = 10f;

        private static Vector2 mousePosition;
        private static bool dialFirst;
        private static bool alignLeft;
        private static bool adjustRotation;
        private static string colour;
        private static string currentColour;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            #region Set Property Height and Indicator Colour

            angleAttribute = attribute as AngleAttribute;

            colour = angleAttribute.colour;
            if (currentColour != colour)
            {
                indicator = DialColour;
                currentColour = colour;
            }

            return angleAttribute.height;

            #endregion
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Property Drawer Overrides

            dialFirst = angleAttribute.dialFirst;
            alignLeft = angleAttribute.alignLeft;
            adjustRotation = angleAttribute.limitRotation;

            Rect labelRect = new Rect(position.x, position.y, position.width, position.height);
            if (alignLeft && dialFirst) { labelRect.x = angleAttribute.height + valueWidth + 40; }

            if (!string.IsNullOrEmpty(angleAttribute.unit)) { label.text = $"{label.text} ({angleAttribute.unit})"; }

            GUIStyle style = new GUIStyle(GUI.skin.label);
            float width = style.CalcSize(label).x;
            EditorGUI.LabelField(labelRect, label);

            var size = angleAttribute.height;
            if (dialFirst) { size += valueWidth; }

            var align = position.x;
            if (!alignLeft) { align = position.width - size; }
            else if (!dialFirst) { align += width + valueWidth + (offset * 2); }

            position.x = align;

            property.floatValue = FloatAngle(position, property.floatValue, angleAttribute.snap, angleAttribute.min, angleAttribute.max);

            #endregion
        }

        public static float FloatAngle(Rect rect, float value)
        {
            return FloatAngle(rect, value, -1, -1, -1);
        }

        public static float FloatAngle(Rect rect, float value, float snap)
        {
            return FloatAngle(rect, value, snap, -1, -1);
        }

        public static float FloatAngle(Rect rect, float value, float snap, float min, float max)
        {
            return FloatAngle(rect, value, snap, min, max, Vector2.up);
        }

        public static float FloatAngle(Rect rect, float value, float snap, float min, float max, Vector2 zeroVector)
        {
            #region Float GUI Angle Calculations

            int id = GUIUtility.GetControlID(FocusType.Passive, rect);
            float originalValue = value;
            Rect knobRect = new Rect(rect.x, rect.y, rect.height, rect.height);

            float delta;
            if (min != max)
            {
                delta = ((max - min) / 360);
            }
            else
            {
                delta = 1;
            }

            if (Event.current != null)
            {
                if (Event.current.type == EventType.MouseDown && knobRect.Contains(Event.current.mousePosition))
                {
                    GUIUtility.hotControl = id;
                    mousePosition = Event.current.mousePosition;
                }
                else if (Event.current.type == EventType.MouseUp && GUIUtility.hotControl == id)
                {
                    GUIUtility.hotControl = 0;
                }
                else if (Event.current.type == EventType.MouseDrag && GUIUtility.hotControl == id)
                {
                    //Vector2 move = mousePosition - Event.current.mousePosition;

                    Vector2 mouseStartDirection = (mousePosition - knobRect.center).normalized;
                    float startAngle = CalculateAngle(Vector2.up, mouseStartDirection);

                    Vector2 mouseNewDirection = (Event.current.mousePosition - knobRect.center).normalized;
                    float newAngle = CalculateAngle(Vector2.up, mouseNewDirection);

                    float sign = Mathf.Sign(newAngle - startAngle);
                    float delta2 = Mathf.Min(Mathf.Abs(newAngle - startAngle), Mathf.Abs(newAngle - startAngle + 360f), Mathf.Abs(newAngle - startAngle - 360f));
                    value -= delta2 * sign;

                    if (snap > 0)
                    {
                        float mod = Mathf.Abs(value) % snap;

                        if (mod < (delta * 3) || Mathf.Abs(mod - snap) < (delta * 3))
                            value = Mathf.Round(value / snap) * snap;
                    }

                    if (value != originalValue)
                    {
                        mousePosition = Event.current.mousePosition;
                        GUI.changed = true;
                    }
                }
            }

            float angleOffset = (CalculateAngle(Vector2.up, zeroVector) + 360f) % 360f;

            GUI.DrawTexture(knobRect, dial);
            Matrix4x4 matrix = GUI.matrix;

            if (adjustRotation)
            {
                if (min != max)
                {
                    GUIUtility.RotateAroundPivot((angleOffset + value) * (360 / (max - min)), knobRect.center);
                }
                else
                {
                    GUIUtility.RotateAroundPivot(angleOffset + value, knobRect.center);
                }
            }
            else
            {
                GUIUtility.RotateAroundPivot(angleOffset + value, knobRect.center);
            }

            GUI.DrawTexture(knobRect, indicator);
            GUI.matrix = matrix;

            float rectX;
            float rectY = rect.y + (rect.height * 0.5f) - offset;

            if (dialFirst) { rectX = rect.x + rect.height + offset; }
            else { rectX = rect.x - (valueWidth + offset); }

            Rect valueRect = new Rect(rectX, rectY, valueWidth, 18);
            value = EditorGUI.FloatField(valueRect, value);

            if (min != max)
            {
                value = Mathf.Clamp(value, min, max);
            }

            return value;

            #endregion
        }

        public static float CalculateAngle(Vector3 from, Vector3 to)
        {
            #region Angle Calculations

            Vector3 right = Vector3.right;
            float angle = Vector3.Angle(from, to);
            return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
            //return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;

            #endregion
        }

        static private Texture2D DialColour
        {
            #region Get Indicator Texture

            get
            {
                switch (colour)
                {
                    case "red": return (Texture2D)Resources.Load("IndicatorRed");
                    case "green": return (Texture2D)Resources.Load("IndicatorGreen");
                    case "blue": return (Texture2D)Resources.Load("IndicatorBlue");
                    case "cyan": return (Texture2D)Resources.Load("IndicatorCyan");
                    case "magenta": return (Texture2D)Resources.Load("IndicatorMagenta");
                    case "yellow": return (Texture2D)Resources.Load("IndicatorYellow");
                    case "orange": return (Texture2D)Resources.Load("IndicatorOrange");
                    default: return (Texture2D)Resources.Load("IndicatorWhite");
                }
            }

            #endregion
        }
    }
}