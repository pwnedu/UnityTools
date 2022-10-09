# Custom Console #

### Add this reference to the top of your script: ###

```cs
using CustomConsole;
```

### Use Colours in Debug Logs: ###

```cs
Debug.Log(CC.Col(Color.white) + "Test Message 1 Color.white" + CC.End());
```

```cs
Debug.Log(CC.Col(new Color(.4f, .4f, .8f, 1f)) + "Test Message 2 RGBA 0-1" + CC.End());
```

```cs
Debug.Log(CC.Col(new Color32(225, 125, 125, 255)) + "Test Message 2 RGBA 0-255" + CC.End());
```

### Debug Colour Examples With String Interpolation: ###

```cs
Debug.Log($"{CC.Col(Color.white)}Test Message 1 Color.white{CC.End()}");
```

```cs
Debug.Log($"{CC.Col(new Color(.4f, .4f, .8f, 1f))}Test Message 2 RGBA 0-1{CC.End()}");
```

```cs
Debug.Log($"{CC.Col(new Color32(225, 125, 125, 255))}Test Message 2 RGBA 0-255{CC.End()}");
```

### Convert Colours To Hex Values: ###


```cs
CC.ColToHex(Color.yellow);
```

```cs
CC.ColToHex(new Color(.4f, .8f, .2f, 1f));
```

```cs
CC.ColToHex(new Color32(225, 75, 25, 255));
```