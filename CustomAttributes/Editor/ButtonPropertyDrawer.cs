using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonPropertyDrawer : PropertyDrawer
    {
        ButtonAttribute buttonAttribute;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            buttonAttribute = attribute as ButtonAttribute;

            var height = base.GetPropertyHeight(property, label);
            if (buttonAttribute.hideProperty) { height = 0; }

            return height + buttonAttribute.height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Object target = property.serializedObject.targetObject;

            if (!buttonAttribute.hideProperty)
            {
                Rect propertyPosition = new Rect(position);
                propertyPosition.size = new Vector2(position.width, position.height - buttonAttribute.height);

                if (buttonAttribute.buttonAbove)
                {
                    propertyPosition.yMin = position.y + (buttonAttribute.height);
                    propertyPosition.yMax = position.y + position.height;
                }

                EditorGUI.PropertyField(propertyPosition, property, label);
            }

            var width = position.width;

            if (buttonAttribute.width != 0)
            {
                width = position.width + (buttonAttribute.width - position.width);
            }

            if (buttonAttribute.AdditionalButton)
            {
                width *= 0.5f;
            }

            Rect buttonPosition = new Rect(position);
            buttonPosition.size = new Vector2(width, position.height - 2);
            buttonPosition.min = new Vector2(position.x, position.y + (position.height - buttonAttribute.height) + 2);

            if (buttonAttribute.buttonAbove)
            {
                buttonPosition.yMin = position.y;
                buttonPosition.yMax = position.y + (buttonAttribute.height) - 2;
            }

            var textColour = GUI.contentColor;
            GUI.contentColor = GetColour(buttonAttribute.textColour);

            var bgColour = GUI.backgroundColor;
            GUI.backgroundColor = GetColour(buttonAttribute.buttonColour);

            ButtonOne(target, buttonPosition);

            if (buttonAttribute.AdditionalButton)
            {
                ButtonTwo(target, buttonPosition, width);
            }

            GUI.backgroundColor = bgColour;
            GUI.contentColor = textColour;
        }

        private Color GetColour(string colour)
        {
            return StringColourExtension.Colour(colour);
        }

        private void MethodNullWarning(Rect position, string methodName)
        {
            var prevColour = GUI.color;
            GUI.color = Color.red;
            GUI.Label(position, $"⚠ {methodName} not found. Check it's public? ⚠");
            GUI.color = prevColour;
        }

        private void ParameterWarning(Rect position, string methodName)
        {
            var prevColour = GUI.color;
            GUI.color = Color.yellow;
            GUI.Label(position, $"⚠ {methodName} contains parameters. ⚠");
            GUI.color = prevColour;
        }

        private void ButtonOne(Object target, Rect buttonPosition)
        {
            string methodName = buttonAttribute.MethodName;
            System.Type type = target.GetType();
            System.Reflection.MethodInfo method = type.GetMethod(methodName);

            if (method == null)
            {
                MethodNullWarning(buttonPosition, methodName);
                return;
            }

            if (method.GetParameters().Length > 0)
            {
                ParameterWarning(buttonPosition, method.Name);
                return;
            }

            if (GUI.Button(buttonPosition, buttonAttribute.ButtonName))
            {
                method.Invoke(target, null);
            }
        }

        private void ButtonTwo(Object target, Rect buttonPosition, float width)
        {
            string methodNameTwo = buttonAttribute.AdditionalMethod;
            System.Type typeTwo = target.GetType();
            System.Reflection.MethodInfo methodTwo = typeTwo.GetMethod(methodNameTwo);

            Rect buttonPositionTwo = new Rect(buttonPosition);
            buttonPositionTwo.x = width + 20;

            if (methodTwo == null)
            {
                MethodNullWarning(buttonPositionTwo, methodNameTwo);
                return;
            }

            if (methodTwo.GetParameters().Length > 0)
            {
                ParameterWarning(buttonPositionTwo, methodTwo.Name);
                return;
            }

            if (GUI.Button(buttonPositionTwo, buttonAttribute.AdditionalName))
            {
                methodTwo.Invoke(target, null);
            }
        }
    }
}