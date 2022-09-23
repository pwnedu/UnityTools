using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <code>[Button("methodName", "buttonName", "buttonColour", "textColour", width, height, buttonsAboveBool, additionalButtonBool, "additionalMethodName", "additionalButtonName", hidePropertyBool)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///    <item>
    /// <para>Display a button below property : </para> 
    /// <code>[Button("methodName")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a button above property : </para> 
    /// <code>[Button("methodName", true")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a button with automatic width but specify height: </para> 
    /// <code>[Button("methodName", 20")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a button and hide property: </para> 
    /// <code>[Button("methodName", hideProperty = true")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a button below property and specify button name : </para> 
    /// <code>[Button("methodName", "buttonName")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a button below property and specify button and text colours : </para> 
    /// <code>[Button("methodName", "buttonName", "red", "blue")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display a button below property and specify button name, colours and size: </para> 
    /// <code>[Button("methodName", "buttonName", "red", "blue", 80, 20")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display two buttons : </para> 
    /// <code>[Button("methodName", true, "additionalMethodName")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display two buttons with button names specified : </para> 
    /// <code>[Button("methodName", "buttonName", true, "additionalMethodName", "additionalButtonName")] private float myProperty;</code>
    ///     </item>
    ///     <item>
    /// <para>Display two large buttons above property with button names specified, custom colours, automatic button width and a set height : </para> 
    /// <code>[Button("methodName", "buttonName", true, "additionalMethodName", "additionalButtonName", buttonAbove = true, width = 0, height = 40, textColour = "red", buttonColour = "blue")] private float myProperty;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class ButtonAttribute : PropertyAttribute
    {
        public string MethodName { get; }
        public string ButtonName { get; }
        public bool AdditionalButton { get; }
        public string AdditionalMethod { get; }
        public string AdditionalName { get; }

        public string buttonColour = "";
        public string textColour = "";

        public float width = 0;
        public float height = 25;

        public bool buttonAbove = false;
        public bool hideProperty = false;

        public ButtonAttribute(string methodName)
        {
            MethodName = methodName;
            ButtonName = methodName;
        }

        public ButtonAttribute(string methodName, bool additionalButton, string additionalMethod)
        {
            MethodName = methodName;
            ButtonName = methodName;
            AdditionalButton = additionalButton;
            AdditionalMethod = additionalMethod;
            AdditionalName = additionalMethod;
        }

        public ButtonAttribute(string methodName, bool buttonAbove)
        {
            MethodName = methodName;
            ButtonName = methodName;
            this.buttonAbove = buttonAbove;
        }

        public ButtonAttribute(string methodName, string buttonName)
        {
            MethodName = methodName;
            ButtonName = buttonName;
        }

        public ButtonAttribute(string methodName, string buttonName, bool buttonAbove)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.buttonAbove = buttonAbove;
        }

        public ButtonAttribute(string methodName, string buttonName, bool additionalButton, string additionalMethod, string additionalName)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            AdditionalButton = additionalButton;
            AdditionalMethod = additionalMethod;
            AdditionalName = additionalName;
        }

        public ButtonAttribute(string methodName, float height)
        {
            MethodName = methodName;
            ButtonName = methodName;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, float height)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, float height, bool buttonAbove)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.height = height;
            this.buttonAbove = buttonAbove;
        }

        public ButtonAttribute(string methodName, float width, float height)
        {
            MethodName = methodName;
            ButtonName = methodName;
            this.width = width;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, float width, float height)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.width = width;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, float width, float height)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.buttonColour = buttonColour;
            this.width = width;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, string textColour, float width, float height)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.buttonColour = buttonColour;
            this.textColour = textColour;
            this.width = width;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, string textColour, float width, float height, bool buttonAbove)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            this.buttonColour = buttonColour;
            this.textColour = textColour;
            this.width = width;
            this.height = height;
            this.buttonAbove = buttonAbove;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, string textColour, bool additionalButton, string additionalMethod, string additionalName)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            AdditionalButton = additionalButton;
            AdditionalMethod = additionalMethod;
            AdditionalName = additionalName;
            this.buttonColour = buttonColour;
            this.textColour = textColour;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, string textColour, float width, float height, bool additionalButton, string additionalMethod, string additionalName)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            AdditionalButton = additionalButton;
            AdditionalMethod = additionalMethod;
            AdditionalName = additionalName;
            this.buttonColour = buttonColour;
            this.textColour = textColour;
            this.width = width;
            this.height = height;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, string textColour, float width, float height, bool buttonAbove, bool additionalButton, string additionalMethod, string additionalName)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            AdditionalButton = additionalButton;
            AdditionalMethod = additionalMethod;
            AdditionalName = additionalName;
            this.buttonColour = buttonColour;
            this.textColour = textColour;
            this.width = width;
            this.height = height;
            this.buttonAbove = buttonAbove;
        }

        public ButtonAttribute(string methodName, string buttonName, string buttonColour, string textColour, float width, float height, bool additionalButton, string additionalMethod, string additionalName, bool hideProperty)
        {
            MethodName = methodName;
            ButtonName = buttonName;
            AdditionalButton = additionalButton;
            AdditionalMethod = additionalMethod;
            AdditionalName = additionalName;
            this.buttonColour = buttonColour;
            this.textColour = textColour;
            this.width = width;
            this.height = height;
            this.hideProperty = hideProperty;
        }
    }
}