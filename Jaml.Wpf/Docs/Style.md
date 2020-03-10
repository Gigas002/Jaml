# Style

`Style` (`Jaml.Wpf.StyleModels.StyleModel`) represents one custom style, parsed from `Styles.json`.

## Contents

`StyleModel` inherits from `IStyleModel` interface.

When creating a new element for `Styles.json`, you’re required to set your style’s `Id` to `Id >= 0`.

|       Name        |              Description              |                           Comment                            |  Default value   |           Example            |
| :---------------: | :-----------------------------------: | :----------------------------------------------------------: | :--------------: | :--------------------------: |
|       `Id`        | Style id to reference on pages, `int` |                     Required  parameter                      |       `-1`       |             `0`              |
|    `FontSize`     |          Font size, `double`          |                                                              |      `20.0`      |            `15.0`            |
|   `FontFamily`    |      Path to font file, `string`      |                 Supported extensions: `ttf`                  | Default WPF font | `Resources/Fonts/Roboto.ttf` |
|    `FontStyle`    |         Font style, `string`          | See [msdn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.fontstyle) article for more details |     `Normal`     |           `Italic`           |
|   `FontWeight`    |         Font weight, `string`         | See [msdn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.fontweight) article for more details |    `Regular`     |            `Bold`            |
|   `Foreground`    |         Foreground, `string`          |         Waits for `Argb` string in format `a,r,g,b`          |     `White`      |      `255,100,100,100`       |
|   `Background`    |     Background, `BackgroundModel`     |       See [Background](Background.md) for more details       |  `Transparent`   |  `Resources/Images/Bg1.png`  |
| `BorderThickness` |      Border thickness, `double`       | See [msdn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.thickness) article for more details |      `1.0`       |            `2.0`             |
|   `Visibility`    |         Visibility, `string`          | See [msdn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.visibility) article for more details |    `Visible`     |           `Hidden`           |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>StyleModel.cs</summary>


``` cs --source-file ../Models/StyleModels/StyleModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
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
```