# Custom Attributes #

### Add this reference to the top of your script: ###

```cs
using CustomAttributes;
```


### Property Attribute Examples: ###

```cs
[Angle] public float myAngle;
```

```cs
[AnimatorLayer(logChangesToConsole)] public string animationLayer;
```

```cs
[AnimatorParameter(showParamaterType, logChangesToConsole, ParameterType.All)] public string animationParameter;
```

```cs
[Colour(100, 150, 200, 255)] public float myFloat;
```

```cs
[Curve("red", "yellow", height, showPresets, editableValues, fillWidth, showLabel)] public AnimationCurve myCurve;
```

```cs
[Disable] public double myDisabledField;
```

```cs
[DisplayAs("My Vector 3 Property!!!")] public Vector3 myVector;
```

```cs
[Format("textColour", "fieldColour", boldBool, italicBool, indentBool)] public string myString;
```

```cs
[Highlight(75, 100, 125, 255)] public int myInt;
```

```cs
[Input] private string myInputAxis;
```

```cs
[Preview(size, TextureType.Texture2D)] public Texture2D texture2D;
```

```cs
[Preview(size, TextureType.Sprite)] public Sprite sprite;
```

```cs
[Progress("progressColour", "backgroundColour", minValue, maxValue, height)] public float myProgress;
```

```cs
[Scene] public string mySceneString;
```

```cs
[Scene] public string mySceneInt;
```

```cs
[ShowOnly] public string myShowOnlyField;
```

```cs
[Tag] public string myTag;
```


### Conditional Property Attribute Examples: ###

```cs
[Tooltip("Enable or Disable Demo Options")] public bool enableOne = true;
```

```cs
[BoolHide("enableOne", hideFieldOrDisableBool, inverseOperationBool)] public string demoDisplayName = "Player One";
```

```cs
[Tooltip("Enable or Disable Select Options")] public Select selectEnumerator;
```

```cs
[EnumHide("selectEnumerator", 0)] public string enumDisplayName = "Player One";
```

```cs
[StringValidate(RegexStringMatch, "InvalidEntryErrorString")] public stringToValidate;
```


### Decorator Attribute Examples: ###

```cs
[DisplayImage("fileNameInResourcesFolder", imageWidth, imageHeight, stretchImageWidth, order = 3)]
```

```cs
[Heading("headingColour", fontSize, boldBool, italicBool, centeredBool, order = 1)]
```

```cs
[LineBreak("lineColour", lineThickness, verticalPadding, order = 2)]
```

```cs
[Note("This is a description of something important!", MessageLabel.Info, order = 5)]
```


Additional colours can be added to the Format stylesheet in CustomAttributes/Editor/Styles folder.
