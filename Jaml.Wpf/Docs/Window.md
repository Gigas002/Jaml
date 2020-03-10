# Window

This entry refers to `Window` (`WindowModel`) control documentation.

You can use this control as `MainWindow` of your application, in case you want to create a console app without any `xaml`, depending only on code-behind and `jaml`.

## Contents

`WindowModel` inherits from `UIElementModel`, so you can read about basic properties in it’s [docs](UIElement.md).

`WindowModel` **must** contain a `GridModel` inside.

|  Name  |               Description                |                Comment                | Default value |                Example                |
| :----: | :--------------------------------------: | :-----------------------------------: | :-----------: | :-----------------------------------: |
| `Grid` | Main grid with data for app, `GridModel` | Read [Grid](Grid.md) for more details |    `null`     | Read [Grid](Grid.md) for more details |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>WindowModel.cs</summary>


``` cs --source-file ../Models/UIElementModels/WindowModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
"Window": {
    "Name": "MainWindow",
    "Grid": {
        "Name": "MainGrid",
        "RowDefinitions": [{
            Height": "*"
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
```