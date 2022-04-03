# Custom Attributes #

Add this reference to the top of your script:

* using CustomAttributes;

Property Attribute Examples:

* [Colour(100, 150, 200, 255)] public float myFloat;
* [Disable] public double myDisabledField;
* [DisplayAs("My Default Axis!!!")] public Vector3 axis;
* [Highlight(75, 100, 125, 255)] public int myInt;
* [Format("textColour", "fieldColour", boldBool, italicBool, indentBool)] public string myString;
* [Preview(size, TextureType.Texture2D)] public Texture2D texture2D;
* [Preview(size, TextureType.Sprite)] public Sprite sprite;
* [Progress("progressColour", "backgroundColour", minValue, maxValue, height)] public float myProgress;
* [ShowOnly] public string myShowOnlyField;
* [Tag] public string myTag;
* [Scene] public string mySceneString;
* [Scene] public string mySceneInt;
* [Validation(RegexStringMatch, "InvalidEntryErrorString")] public stringToValidate;

Decorator Attribute Examples:

* [Heading("headingColour", fontSize, boldBool, italicBool, centeredBool, order = 1)]
* [LineBreak("lineColour", lineThickness, verticalPadding, order = 2)]
* [DisplayImage("fileNameInResourcesFolder", imageWidth, imageHeight, stretchImageWidth, order = 3)]

Additional colours can be added to the Format stylesheet in CustomAttributes/Editor folder.

Tested in Unity versions 2019, 2020

Created by kiltec
