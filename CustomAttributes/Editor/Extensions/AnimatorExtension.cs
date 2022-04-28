// NOTE: Put in an editor folder. //

using System;
using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    public class AnimatorExtension
    {
        public static Animator GetAnimator(SerializedProperty property)
        {
            #region Get Animator Component

            var component = property.serializedObject.targetObject as Component;

            if (component == null)
            {
                throw new InvalidCastException("Unable to cast targetObject");
            }

            var anim = component.GetComponent<Animator>();

            if (anim == null)
            {
                return null;
            }

            return anim;

            #endregion
        }
    }
}