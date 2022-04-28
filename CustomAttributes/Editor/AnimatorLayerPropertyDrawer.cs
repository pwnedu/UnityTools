// NOTE: Put in an editor folder. //

using System;
using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(AnimatorLayerAttribute))]
    public class AnimatorLayerPropertyDrawer : PropertyDrawer
    {
        AnimatorLayerAttribute animatorLayerAttribute;
        static Animator animator;

        private string[] animatorLayers;

        private readonly string nameColour = "#ffbd00";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region Get Property Drawer Overrides

            animatorLayerAttribute = attribute as AnimatorLayerAttribute;

            if (property == null)
            {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            if (property.propertyType != SerializedPropertyType.String)
            {
                Debug.LogError($"{nameof(AnimatorLayerAttribute)} supports only string fields.");
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
                GetLayers();

                if (!animator.runtimeAnimatorController)
                {
                    DebugPropertyMessage(position, label, "⚠ No animation runtime controller! ⚠", Color.yellow);
                    return;
                }
            }

            animator.logWarnings = true;

            if (animatorLayers == null || animatorLayers.Length == 0)
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

        private void GetLayers()
        {
            #region Get Animation Parameters

            var length = animator.layerCount;
            animatorLayers = new string[length];

            for (int i = 0; i < length; i++)
            {
                animatorLayers[i] = animator.GetLayerName(i);
            }

            #endregion
        }

        private void DrawStringProperty(Rect rect, SerializedProperty property, GUIContent label)
        {
            #region Draw String Properties

            int index = Mathf.Clamp(Array.IndexOf(animatorLayers, property.stringValue), 0, animatorLayers.Length);

            int newIndex = EditorGUI.Popup(rect, label != null ? label.text : "", index, animatorLayers);

            string newParam = animatorLayers[newIndex];
            if (property.stringValue?.Equals(newParam, StringComparison.Ordinal) == false)
            {
                property.stringValue = animatorLayers[newIndex];
                if (animatorLayerAttribute.debug)
                {
                    Debug.Log($"Selected Animation Layer: <color={nameColour}>{animatorLayers[newIndex]}</color>");
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