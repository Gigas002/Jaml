# Button

This entry refers to `Button control` (`ButtonModel`) inside `Child` (`ChildModel`) documentation.

## Contents

`ButtonModel` inherits from `UIElementModel`, so you can read about basic properties in it’s [docs](UIElement.md).

`Buttons` can be stored in your `json` files inside of `Grid.Children` element.

Parameters:

|   Name    |       Description        |            Comment             | Default value | Example |
| :-------: | :----------------------: | :----------------------------: | :-----------: | :-----: |
| `Content` | Text on button, `string` | Only text content is supported |    `null`     | `Exit`  |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>ButtonModel.cs</summary>

``` cs --source-file ../Models/UIElementModels/ButtonModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
"Button": {
    "Name": "ExitButton",
    "ParentRow": 1,
    "ParentColumn": 0,
    "VerticalAlignment": "Center",
    "HorizontalAlignment": "Left",
    "Content": "Exit",
    "StyleId": 0,
    "Commands": [{
        "Event": "Click",
        "Method": "LoadPageModel",
        "Args": "Resources/UI/MainMenu.json"
    },{
        "Event": "MouseRightButtonUp",
        "Method": "CloseApp"
    }]
}
```

