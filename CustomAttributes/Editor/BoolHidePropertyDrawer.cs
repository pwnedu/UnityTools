// NOTE: Put in a Editor folder. //

// Originally created by Brecht Lecluyse
// Modified by: - kiltec

using UnityEditor;
using UnityEngine;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(BoolHideAttribute))]
    public class BoolHidePropertyDrawer : PropertyDrawer
    {
        BoolHideAttribute boolAttribute;
        bool enabled;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            #region  Get Property Values

            // Get the attribute data
            boolAttribute = attribute as BoolHideAttribute;

            if (property == null) { return 0; }

            // Check if the propery we want to draw should be enabled
            enabled = GetHideAttributeResult(boolAttribute, property);

            if (boolAttribute.InverseOperation)
            {
                if (!boolAttribute.HideInInspector || !enabled)
                {
                    return EditorGUI.GetPropertyHeight(property, label); // The property is being drawn
                }
                else
                {
                    return -EditorGUIUtility.standardVerticalSpacing; // Undo the spacing added before and after the property
                }
            }
            else
            {
                if (!boolAttribute.HideInInspector || enabled)
                {
                    return EditorGUI.GetPropertyHeight(property, label); // The property is being drawn
                }
                else
                {
                    return -EditorGUIUtility.standardVerticalSpacing; // Undo the spacing added before and after the property
                }
            }

            #endregion
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  PropertyDrawer Overrides

            if (property == null) { return; }

            // Get the attribute data
            //BoolHideAttribute boolAttribute = (BoolHideAttribute)attribute;

            // Check if the propery we want to draw should be enabled
            //bool enabled = GetHideAttributeResult(boolAttribute, property);

            // Enable or disable the property
            bool wasEnabled = GUI.enabled;

            // Check if we should draw the property
            if (boolAttribute.InverseOperation)
            {
                GUI.enabled = !enabled;
                if (!boolAttribute.HideInInspector || !enabled)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }
            else
            {
                GUI.enabled = enabled;
                if (!boolAttribute.HideInInspector || enabled)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }

            // Ensure that the next property that is being drawn uses the correct settings
            GUI.enabled = wasEnabled;

            #endregion
        }

        private bool GetHideAttributeResult(BoolHideAttribute condHideAtt, SerializedProperty property)
        {
            #region  Get Hide Results

            bool enabled;
            bool conditionOne = true;
            bool conditionTwo = true;

            // Look for the sourcefield within the object that the property belongs to
            string propertyPath = property.propertyPath; // Returns the path of the property we want to apply the attribute to

            string conditionPath = propertyPath.Replace(property.name, condHideAtt.BoolAsStringSourceConditionOne); // Changes the path to the conditionalSourceOne property path
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

            string conditionPathTwo = propertyPath.Replace(property.name, condHideAtt.BoolAsStringSourceConditionTwo); // Changes the path to the conditionalSourceTwo property path
            SerializedProperty sourcePropertyValueTwo = property.serializedObject.FindProperty(conditionPathTwo);

            // Get the first property value
            if (sourcePropertyValue != null)
            {
                conditionOne = sourcePropertyValue.boolValue;
            }
            else
            {
                Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching first SourcePropertyValue found in object: " + condHideAtt.BoolAsStringSourceConditionOne);
            }

            // Get the second property value
            if (sourcePropertyValueTwo != null)
            {
                conditionTwo = sourcePropertyValueTwo.boolValue;
            }
            else
            {
                Debug.LogWarning("Attempting to use a ConditionalHideAttribute but no matching second SourcePropertyValue found in object: " + condHideAtt.BoolAsStringSourceConditionTwo);
            }

            // Apply our logic to the conditions
            if (condHideAtt.OneOfTheTwo)
            {
                if (conditionOne || conditionTwo) { enabled = true; }
                else { enabled = false; }
            }
            else
            {
                if (conditionOne && conditionTwo) { enabled = true; }
                else { enabled = false; }
            }

            return enabled;

            #endregion
        }
    }
}