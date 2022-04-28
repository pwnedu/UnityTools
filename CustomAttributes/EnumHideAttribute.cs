// NOTE: DON'T put in an editor folder. //

// Originally created by Brecht Lecluyse
// Modified by: - kiltec

using UnityEngine;
using System;

namespace CustomAttributes 
{
    /// <summary>
    /// <code>[EnumHide("enumeratorName", 0, 1, 2, 3, 4, 5, hideBool, inverseBool)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>If not enum value 0 field is disabled: </para> 
    /// <code>[EnumHide("enumerator", 0)] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>If not enum value 0 field is hidden:  </para>
    /// <code>[EnumHide("enumerator", 0, true)] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>Only for enum value 0 field is disabled: </para>
    /// <code>[EnumHide("enumerator", 0, false, true)] private float myFloat;</code>
    ///     </item>
    ///     <item>
    /// <para>Only for enum value 0 field is hidden: </para>
    /// <code>[EnumHide("enumerator", 0, true, true)] private float myFloat;</code>
    ///     </item>
    /// </list>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
        AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class EnumHideAttribute : PropertyAttribute
    {
        // The name of the enum field that will be in control.
        public string EnumeratorAsStringSourceCondition = "";

        // Grab our enum values (Up to 6).
        public int EnumValue1 = 0;
        public int EnumValue2 = 0;
        public int EnumValue3 = 0;
        public int EnumValue4 = 0;
        public int EnumValue5 = 0;
        public int EnumValue6 = 0;

        // TRUE = Hide in inspector / FALSE = Disable in inspector 
        public bool HideInInspector = false;

        // TRUE = False is active / FALSE = True is active 
        public bool InverseOperation = false;

        #region  Attributes initialisation, normal logic, property disabled.

        public EnumHideAttribute(string enumeratorCondition, int enumValue1)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue1;
            this.EnumValue3 = enumValue1;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = false;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue1;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = false;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = false;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = false;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, int enumValue5)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue5;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = false;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, int enumValue5, int enumValue6)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue5;
            this.EnumValue6 = enumValue6;
            this.HideInInspector = false;
            this.InverseOperation = false;
        }

        #endregion

        #region  Attributes initialisation, normal logic, specify disabled or hidden property.

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, bool hideInInspector)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue1;
            this.EnumValue3 = enumValue1;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, bool hideInInspector)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue1;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, bool hideInInspector)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, bool hideInInspector)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, int enumValue5, bool hideInInspector)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue5;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, int enumValue5, int enumValue6, bool hideInInspector)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue5;
            this.EnumValue6 = enumValue6;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = false;
        }

        #endregion

        #region  Attributes initialisation, specify disabled or hidden property, specify normal or inverse logic.

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, bool hideInInspector, bool invertLogic)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue1;
            this.EnumValue3 = enumValue1;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, bool hideInInspector, bool invertLogic)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue1;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, bool hideInInspector, bool invertLogic)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue1;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, bool hideInInspector, bool invertLogic)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue1;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, int enumValue5, bool hideInInspector, bool invertLogic)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue5;
            this.EnumValue6 = enumValue1;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
        }

        public EnumHideAttribute(string enumeratorCondition, int enumValue1, int enumValue2, int enumValue3, int enumValue4, int enumValue5, int enumValue6, bool hideInInspector, bool invertLogic)
        {
            this.EnumeratorAsStringSourceCondition = enumeratorCondition;
            this.EnumValue1 = enumValue1;
            this.EnumValue2 = enumValue2;
            this.EnumValue3 = enumValue3;
            this.EnumValue4 = enumValue4;
            this.EnumValue5 = enumValue5;
            this.EnumValue6 = enumValue6;
            this.HideInInspector = hideInInspector;
            this.InverseOperation = invertLogic;
        }

        #endregion

    }
}