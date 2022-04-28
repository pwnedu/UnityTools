// NOTE: DON'T put in an editor folder. //

// Originally created by Brecht Lecluyse
// Modified by: - kiltec

using UnityEngine;
using System;

namespace CustomAttributes 
{
    /// <summary>
    /// <code>[BoolHide("boolOneName", "boolTwoName", hideBool, inverseBool, eitherBool)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Disable field if bool value is false by using : </para> 
    /// <code>[BoolHide("condition")] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>Hide field if bool value is false by using : </para> 
    /// <code>[BoolHide("condition", true)] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>Hide field if bool value is true by using : </para> 
    /// <code>[BoolHide("condition", true, true)] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>Disable field if both bool values are true by using : </para> 
    /// <code>[BoolHide("conditionOne", "conditionTwo", false, true)] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>Hide field if either bool value is false by using : </para> 
    /// <code>[BoolHide("conditionOne", "conditionTwo", true, false, true)] private float myFloat;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class BoolHideAttribute : PropertyAttribute
    {
        // The name of the bool field that will be in control
        public string BoolAsStringSourceConditionOne = "";
        public string BoolAsStringSourceConditionTwo = "";

        // TRUE = Hide in inspector / FALSE = Disable in inspector 
        public bool HideInInspector = false;

        // TRUE = False is active / FALSE = True is active 
        public bool InverseOperation = false;

        // TRUE = Either one is active / FALSE = Both are active 
        public bool OneOfTheTwo = false;

        #region  Attributes initialisation

        public BoolHideAttribute(string boolConditionOne)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionOne;
            this.HideInInspector = false;
            this.InverseOperation = false;
            this.OneOfTheTwo = false;
        }

        public BoolHideAttribute(string boolConditionOne, string boolConditionTwo)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionTwo;
            this.HideInInspector = false;
            this.InverseOperation = false;
            this.OneOfTheTwo = false;
        }

        public BoolHideAttribute(string boolConditionOne, bool hideInInspector)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionOne;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
            this.OneOfTheTwo = false;
        }

        public BoolHideAttribute(string boolConditionOne, string boolConditionTwo, bool hideInInspector)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionTwo;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
            this.OneOfTheTwo = false;
        }

        public BoolHideAttribute(string boolConditionOne, bool hideInInspector, bool invertLogic)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionOne;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
            this.OneOfTheTwo = false;
        }

        public BoolHideAttribute(string boolConditionOne, string boolConditionTwo, bool hideInInspector, bool invertLogic)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionTwo;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
            this.OneOfTheTwo = false;
        }

        public BoolHideAttribute(string boolConditionOne, string boolConditionTwo, bool hideInInspector, bool invertLogic, bool eitherOne)
        {
            this.BoolAsStringSourceConditionOne = boolConditionOne;
            this.BoolAsStringSourceConditionTwo = boolConditionTwo;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
            this.OneOfTheTwo = eitherOne;
        }

        #endregion
    }
}