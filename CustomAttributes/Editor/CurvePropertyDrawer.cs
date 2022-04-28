// NOTE: Put in an editor folder. //

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(CurveAttribute))]
    public class CurvePropertyDrawer : PropertyDrawer
    {
        CurveAttribute curveAttribute;

        private readonly float line = GUI.skin.textField.lineHeight + 3;
        private float height;
        private float curveHeight;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            #region  Get Property Values

            curveAttribute = attribute as CurveAttribute;

            curveHeight = curveAttribute.height;

            if (curveHeight <= 0)
            {
                curveHeight = line;
            }

            height = curveHeight;

            bool addLineForHeading = curveAttribute.wide && curveAttribute.label;
            bool addLineForValues = (curveAttribute.values && curveAttribute.wide && !curveAttribute.label) ||
                                    (curveAttribute.values && !curveAttribute.wide);

            if (addLineForHeading)
            {
                height += line;
            }

            if (curveAttribute.presets)
            {
                height += line;
            }

            if (addLineForValues)
            {
                height += line;
            }

            return height + 2;

            #endregion
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  Get Property Overrides

            if (property == null) { return; }

            if (property.propertyType != SerializedPropertyType.AnimationCurve)
            {
                Debug.LogError($"{nameof(CurveAttribute)} supports only AnimationCurve fields.");
            }

            if (property.animationCurveValue.keys.Length == 0)
            {
                property.animationCurveValue = AnimationCurve.Linear(curveAttribute.start, curveAttribute.min, curveAttribute.end, curveAttribute.max);  //AnimationCurve.Linear(0, 0, 1, 1); 
            }

            var previousColour = GUI.backgroundColor;
            GUI.backgroundColor = BGColour;

            var curveRange = new Rect(curveAttribute.start, curveAttribute.min, curveAttribute.end, curveAttribute.max);

            if (curveAttribute.start < 0) { curveRange.width += Mathf.Abs(curveAttribute.start); }
            if (curveAttribute.start > 0 && curveAttribute.start < 1) { curveRange.width -= Mathf.Abs(curveAttribute.start); }
            if (curveAttribute.min < 0) { curveRange.height += Mathf.Abs(curveAttribute.min); }
            if (curveAttribute.min > 0 && curveAttribute.min < 1) { curveRange.height -= Mathf.Abs(curveAttribute.min); }

            if (curveAttribute.label)
            {
                if (curveAttribute.wide)
                {
                    var labelPosition = new Rect(position.x, position.y, position.width, line);
                    GUI.Label(labelPosition, label);

                    position = new Rect(position.x, position.y + line, position.width, curveHeight);
                    property.animationCurveValue = EditorGUI.CurveField(position, property.animationCurveValue, color: LineColour, curveRange);
                }
                else
                {
                    position = new Rect(position.x, position.y, position.width, curveHeight);
                    property.animationCurveValue = EditorGUI.CurveField(position, label, property.animationCurveValue, color: LineColour, curveRange);
                }
            }
            else
            {
                if (curveAttribute.wide)
                {
                    position = new Rect(position.x, position.y, position.width, curveHeight);
                    property.animationCurveValue = EditorGUI.CurveField(position, property.animationCurveValue, color: LineColour, curveRange);
                }
                else
                {
                    position = new Rect(position.x, position.y, position.width, curveHeight);
                    property.animationCurveValue = EditorGUI.CurveField(position, " ", property.animationCurveValue, color: LineColour, curveRange);
                }
            }

            GUI.backgroundColor = previousColour;

            if (curveAttribute.values)
            {
                GUIStyle style = EditorStyles.miniLabel;
                style.alignment = TextAnchor.MiddleRight;

                var labelWidth = 28f;
                var inputWidth = position.width * 0.075f;
                var inputHeight = position.y - line;
                var spacing = inputWidth + labelWidth;
                var offset = 18f;

                var firstPosition = position.width - spacing * 4 + offset;

                if (!curveAttribute.wide || !curveAttribute.label)
                {
                    inputHeight = position.y + position.height + line + 4;
                }

                var valueOneLabel = new Rect(firstPosition, inputHeight, labelWidth, line);
                var valueOneRect = new Rect(firstPosition + labelWidth, inputHeight, inputWidth, line);

                var valueTwoLabel = new Rect(valueOneLabel.x + spacing, inputHeight, labelWidth, line);
                var valueTwoRect = new Rect(valueOneRect.x + spacing, inputHeight, inputWidth, line);

                var valueThreeLabel = new Rect(valueTwoLabel.x + spacing, inputHeight, labelWidth, line);
                var valueThreeRect = new Rect(valueTwoRect.x + spacing, inputHeight, inputWidth, line);

                var valueFourLabel = new Rect(valueThreeLabel.x + spacing, inputHeight, labelWidth, line);
                var valueFourRect = new Rect(valueThreeRect.x + spacing, inputHeight, inputWidth, line);

                GUI.Label(valueOneLabel, "Start", style);
                curveAttribute.start = EditorGUI.FloatField(valueOneRect, curveAttribute.start);

                GUI.Label(valueTwoLabel, "End", style);
                curveAttribute.end = EditorGUI.FloatField(valueTwoRect, curveAttribute.end);

                GUI.Label(valueThreeLabel, "Min", style);
                curveAttribute.min = EditorGUI.FloatField(valueThreeRect, curveAttribute.min);

                GUI.Label(valueFourLabel, "Max", style);
                curveAttribute.max = EditorGUI.FloatField(valueFourRect, curveAttribute.max);
            }

            if (curveAttribute.presets)
            {
                var start = curveAttribute.start;
                var end = curveAttribute.end;
                var min = curveAttribute.min;
                var max = curveAttribute.max;
                var width = position.width * 0.2f;

                if (!curveAttribute.wide)
                {
                    width *= 0.575f;
                }

                var firstPosition = position.width + 18 - (width * 5);

                var buttonOneRect = new Rect(firstPosition, position.y + position.height + 2, width, line);
                var buttonTwoRect = new Rect(buttonOneRect.x + width, position.y + position.height + 2, width, line);
                var buttonThreeRect = new Rect(buttonTwoRect.x + width, position.y + position.height + 2, width, line);
                var buttonFourRect = new Rect(buttonThreeRect.x + width, position.y + position.height + 2, width, line);
                var buttonFiveRect = new Rect(buttonFourRect.x + width, position.y + position.height + 2, width, line);

                //var constVal = (max - min) * 0.5f;
                var constVal = (max - Mathf.Abs(min)) * 0.5f;

                if (GUI.Button(buttonOneRect, "Constant")) { property.animationCurveValue = AnimationCurve.Constant(start, end, constVal); }
                if (GUI.Button(buttonTwoRect, "EaseIn")) { property.animationCurveValue = AnimationCurve.EaseInOut(start, min, end, max); }
                if (GUI.Button(buttonThreeRect, "EaseOut")) { property.animationCurveValue = AnimationCurve.EaseInOut(start, max, end, min); }
                if (GUI.Button(buttonFourRect, "LinearIn")) { property.animationCurveValue = AnimationCurve.Linear(start, min, end, max); }
                if (GUI.Button(buttonFiveRect, "LinearOut")) { property.animationCurveValue = AnimationCurve.Linear(start, max, end, min); }
            }

            #endregion
        }

        private Color LineColour
        {
            get { return StringColourExtension.Colour(curveAttribute.lineColour); }
        }

        private Color BGColour
        {
            get { return StringColourExtension.Colour(curveAttribute.bgColour); }
        }
    }
}