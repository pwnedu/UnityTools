# Custom Attributes #

Add this reference to the top of your script:

* using CustomAttributes;

Property Attribute Examples:

* [Angle] public float myAngle;
* [AnimatorLayer(true)] public string animationLayer;
* [AnimatorParameter(true, true, ParameterType.All)] public string animationParameter;
* [Colour(100, 150, 200, 255)] public float myFloat;
* [Curve("cyan", 60, true, false, true, true, start = -0.5f, min = -0.5f, end = 0.5f, max = 0.5f)] public AnimationCurve myCurve;
* [Disable] public double myDisabledField;
* [DisplayAs("My Vector 3 Property!!!")] public Vector3 myVector;
* [Format("textColour", "fieldColour", boldBool, italicBool, indentBool)] public string myString;
* [Highlight(75, 100, 125, 255)] public int myInt;
* [Input] private string myInputAxis;
* [Preview(size, TextureType.Texture2D)] public Texture2D texture2D;
* [Preview(size, TextureType.Sprite)] public Sprite sprite;
* [Progress("progressColour", "backgroundColour", minValue, maxValue, height)] public float myProgress;
* [Scene] public string mySceneString;
* [Scene] public string mySceneInt;
* [ShowOnly] public string myShowOnlyField;
* [Tag] public string myTag;

Conditional Property Attributes:

* [Tooltip("Enable or Disable Demo Options")] public bool enableOne = true;
* [BoolHide("enableOne", false)] public string demoDisplayName = "Player One";

* [Tooltip("Enable or Disable Select Options")] public Select selectEnumerator;
* [EnumHide("selectEnumerator", 0)] public string enumDisplayName = "Player One";

* [StringValidate(RegexStringMatch, "InvalidEntryErrorString")] public stringToValidate;

Decorator Attribute Examples:

* [DisplayImage("fileNameInResourcesFolder", imageWidth, imageHeight, stretchImageWidth, order = 3)]
* [Heading("headingColour", fontSize, boldBool, italicBool, centeredBool, order = 1)]
* [LineBreak("lineColour", lineThickness, verticalPadding, order = 2)]
* [Note("This is a description of something important!", MessageLabel.Info, order = 5)]
    
Additional colours can be added to the Format stylesheet in CustomAttributes/Editor folder.

Tested in Unity versions 2019, 2020

Created by kiltec of pwnedu games
