// NOTE: Put in an editor folder. //

// Originally created by Brecht Lecluyse
// Modified by kiltec

using UnityEngine;
using UnityEditor;

namespace CustomAttributes 
{
    [CustomPropertyDrawer(typeof(EnumHideAttribute))]
    public class ConditionalEnumHidePropertyDrawer : PropertyDrawer
    {
        EnumHideAttribute enumAttribute;
        int enumValue;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            #region  Get Hide Values

            // Get the attribute data
            enumAttribute = attribute as EnumHideAttribute;
            enumValue = GetHideAttributeResult(enumAttribute, property);
            bool values = (enumAttribute.EnumValue1 == enumValue) || (enumAttribute.EnumValue2 == enumValue) || (enumAttribute.EnumValue3 == enumValue) || (enumAttribute.EnumValue4 == enumValue) || (enumAttribute.EnumValue5 == enumValue) || (enumAttribute.EnumValue6 == enumValue);

            if (enumAttribute.InverseOperation)
            {
                if (!enumAttribute.HideInInspector || !values)
                {
                    return EditorGUI.GetPropertyHeight(property, label);
                }
                else
                {
                    return -EditorGUIUtility.standardVerticalSpacing;
                }
            }
            else
            {
                if (!enumAttribute.HideInInspector || values)
                {
                    return EditorGUI.GetPropertyHeight(property, label);
                }
                else
                {
                    return -EditorGUIUtility.standardVerticalSpacing;
                }
            }

            #endregion
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            #region  PropertyDrawer Overrides

            // Get the attribute data
            //EnumHideAttribute enumAttribute = (EnumHideAttribute)attribute;
            //int enumValue = GetHideAttributeResult(enumAttribute, property);

            // Enable or disable the property
            bool enabled = GUI.enabled;
            bool values = (enumAttribute.EnumValue1 == enumValue) || (enumAttribute.EnumValue2 == enumValue) || (enumAttribute.EnumValue3 == enumValue) || (enumAttribute.EnumValue4 == enumValue) || (enumAttribute.EnumValue5 == enumValue) || (enumAttribute.EnumValue6 == enumValue);

            // Check if we should draw the property
            if (enumAttribute.InverseOperation)
            {
                GUI.enabled = !values;

                if (!enumAttribute.HideInInspector || !values)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }
            else
            {
                GUI.enabled = values;

                if (!enumAttribute.HideInInspector || values)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
            }

            // Ensure that the next property that is being drawn uses the correct settings
            GUI.enabled = enabled;

            #endregion
        }

        private int GetHideAttributeResult(EnumHideAttribute condHAtt, SerializedProperty property)
        {
            #region  Get Property Results

            int enumValue = 0;

            SerializedProperty sourcePropertyValue;
            //Get the full relative property path of the sourcefield so we can have nested hiding
            if (!property.isArray)
            {
                string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
                string conditionPath = propertyPath.Replace(property.name, condHAtt.EnumeratorAsStringSourceCondition); //changes the path to the conditionalsource property path
                sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

                //if the find failed->fall back to the old system
                if (sourcePropertyValue == null)
                {
                    //original implementation (doens't work with nested serializedObjects)
                    sourcePropertyValue = property.serializedObject.FindProperty(condHAtt.EnumeratorAsStringSourceCondition);
                }
            }
            else
            {
                //original implementation (doens't work with nested serializedObjects)
                sourcePropertyValue = property.serializedObject.FindProperty(condHAtt.EnumeratorAsStringSourceCondition);
            }


            if (sourcePropertyValue != null)
            {
                enumValue = sourcePropertyValue.enumValueIndex;
            }
            else
            {
                Debug.LogWarning("Attempting to use a Conditional Enumerator Hide Attribute but no matching Source Property Value found in object: " + condHAtt.EnumeratorAsStringSourceCondition);
            }

            return enumValue;

            #endregion
        }
    }
}