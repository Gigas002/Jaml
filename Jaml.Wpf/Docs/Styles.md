# Styles

This entry refers to `Styles.json` documentation.

`Style.json` is a optional file, that defines visual appearence for different controls inside of your visual novel. To learn how to link your `Style.json` file, please read the [Root](Root.md) documentation file.

## Contents

`PageModel` inherits from `IJsonModel` interface.

`Styles.json` doesn't contain any required parameters. If you want to add a style, your minimal `json` would look like:

```json
{
    "Styles":
    [
        {
            "Id": 0
        }
    ]
}
```

This will create a style with some default values. To see detailed documentation, see [Style](Style.md).

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>StylesModel.cs</summary>

``` cs --source-file ../Models/JsonModels/StylesModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
{
    "Styles":
    [
        {
            "Id": 0,
            "FontSize": 30.0,
            "FontFamily": "Resources/Fonts/Roboto-Regular.ttf",
            "FontWeight": "Bold",
            "FontStyle": "Italic",
            "Foreground": "255,10,10,255",
            "Background":
            {
                "IsImage": false,
                "Value": "255,100,100,100"
            },
            "BorderThickness": 5.0,
            "Visibility": "Visible"
        }
    ]
}
```
