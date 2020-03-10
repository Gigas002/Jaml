# MainWindow

This entry refers to `MainWindow` (`MainWindowModel`) json file documentation.

`MainWindow` is a `json` model for your application in case, when you want to create a console app without any `xaml`, depending only on code-behind and `jaml`.

You can use this control as `MainWindow` of your application, in case you want to create a console app without any `xaml`, depending only on code-behind and `jaml`.

## Contents

`MainWindowModel` inherits from `JsonModel`.

`MainWindowModel` **must** contain only `Window` inside.

|   Name   |                Description                |                  Comment                  | Default value |                  Example                  |
| :------: | :---------------------------------------: | :---------------------------------------: | :-----------: | :---------------------------------------: |
| `Window` | The main window of the app, `WindowModel` | Read [Window](Window.md) for more details |    `null`     | Read [Window](Window.md) for more details |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>MainWindowModel.cs</summary>



``` cs --source-file ../Models/JsonModels/MainWindowModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
{
    "MainWindow": {
        "Window": {
            "Name": "MainWindow",
            "Grid": {
                "Name": "MainGrid",
                "RowDefinitions": [{
                    "Height": "*"
                }],
                "ColumnDefinitions": [{
                    "Width": "*"
                }],
                "VerticalAlignment": "Stretch",
                "HorizontalAlignment": "Stretch"
            },
            "Commands": [{
                "Event": "Loaded",
                "Method": "LoadPageModel",
                "Args": "Resources/UI/OnLoad.json"
            }]
        }
    }
}
```