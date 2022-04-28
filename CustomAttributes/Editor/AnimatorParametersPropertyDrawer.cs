// NOTE: Put in an editor folder. //

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(AnimatorParameterAttribute))]
    public class AnimatorParametersPropertyDrawer : PropertyDrawer
    {
        AnimatorParameterAttribute animatorParameterAttribute;
        Animator animator;

        private readonly List<string> animatorParams = new List<string>();
        private readonly List<string> paramTypes = new List<string>();
        private readonly List<string> paramsDisplay = new List<string>();

        private string[] animatorParameters;
        private string[] parameterTypes;
        private string[] parametersDisplay;

        private readonly string nameColour = "#ffbd00";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Get Property Drawer Overrides

            animatorParameterAttribute = attribute as AnimatorParameterAttribute;

            if (property == null)
            {
                return;
            }

            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogError($"{nameof(AnimatorParameterAttribute)} supports only string fields.");
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            if (!animator)
            {
                animator = AnimatorExtension.GetAnimator(property);
                DebugPropertyMessage(position, label, "⚠ No Animator Component! ⚠", Color.red);
                return;
            }

            animator.logWarnings = false;

            if (animator.isInitialized)
            {
                GetParameters();

                if (animator.parameterCount == 0)
                {
                    animatorParameters = null;
                    parameterTypes = null;
                    parametersDisplay = null;

                    if (animator.runtimeAnimatorController)
                    {
                        DebugPropertyMessage(position, label, "⚠ No animation parameters set! ⚠", Color.yellow);
                    }
                    else
                    {
                        DebugPropertyMessage(position, label, "⚠ No animation runtime controller! ⚠", Color.yellow);
                    }
                    return;
                }
            }

            animator.logWarnings = true;

            if (animatorParameters == null || animatorParameters.Length == 0)
            {
                GUIContent content = new GUIContent("♨", "refresh elements");

                GUIStyle style = EditorStyles.miniButtonRight;
                style.fixedWidth = 18;
                style.fixedHeight = 18;
                style.contentOffset = new Vector2(0f, -1f);
                style.alignment = TextAnchor.MiddleCenter;

                Rect buttonRect = new Rect(position.width, position.y, position.width, position.height);
                Rect positionRect = new Rect(position.x, position.y, position.width - 22, position.height);

                if (GUI.Button(buttonRect, content, style))
                {
                    animator.Rebind();
                }

                EditorGUI.PropertyField(positionRect, property, label);

                return;
            }

            DrawStringProperty(position, property, label);

            #endregion
        }

        private void GetParameters()
        {
            #region Get Animation Parameters

            animatorParams.Clear();
            paramTypes.Clear();
            paramsDisplay.Clear();

            foreach (var parameter in animator.parameters)
            {
                switch (animatorParameterAttribute.parameterType)
                {
                    case ParameterType.Float:
                        if ((int)ParameterType.Float == (int)parameter.type)
                        {
                            AddParameterOption(parameter);
                        }
                        break;
                    case ParameterType.Int:
                        if ((int)ParameterType.Int == (int)parameter.type)
                        {
                            AddParameterOption(parameter);
                        }
                        break;
                    case ParameterType.Bool:
                        if ((int)ParameterType.Bool == (int)parameter.type)
                        {
                            AddParameterOption(parameter);
                        }
                        break;
                    case ParameterType.Trigger:
                        if ((int)ParameterType.Trigger == (int)parameter.type)
                        {
                            AddParameterOption(parameter);
                        }
                        break;
                    default:
                        AddParameterOption(parameter);
                        break;
                }

                animatorParameters = animatorParams.ToArray();
                parameterTypes = paramTypes.ToArray();
                parametersDisplay = paramsDisplay.ToArray();
            }

            #endregion
        }

        private void AddParameterOption(AnimatorControllerParameter parameter)
        {
            #region Add Animation Parameter To Lists

            animatorParams.Add(parameter.name);
            paramTypes.Add(parameter.type.ToString());
            paramsDisplay.Add($"{parameter.name} ({parameter.type})");

            #endregion
        }

        private void DrawStringProperty(Rect rect, SerializedProperty property, GUIContent label)
        {
            #region Draw String Properties

            int index = Mathf.Clamp(Array.IndexOf(animatorParameters, property.stringValue), 0, animatorParameters.Length);

            string[] display;
            if (animatorParameterAttribute.displayType) { display = parametersDisplay; }
            else { display = animatorParameters; }

            int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, display);

            string newParam = animatorParameters[newIndex];
            if (property.stringValue?.Equals(newParam, StringComparison.Ordinal) == false)
            {
                property.stringValue = animatorParameters[newIndex];
                if (animatorParameterAttribute.debug)
                {
                    Debug.Log($"Selected Animation Parameter: <color={nameColour}>{animatorParameters[newIndex]}</color> (Type {parameterTypes[newIndex]})");
                }
            }

            #endregion
        }

        private void DebugPropertyMessage(Rect position, GUIContent label, string message, Color msgColour)
        {
            #region Draw Warning Messages

            EditorGUI.LabelField(position, label);

            GUIStyle style = new GUIStyle(EditorStyles.miniBoldLabel);
            style.alignment = TextAnchor.UpperRight;

            var prevColour = GUI.color;
            GUI.color = msgColour;
            EditorGUI.LabelField(position, message, style);
            GUI.color = prevColour;

            #endregion
        }
    }
}