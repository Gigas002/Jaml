# Image

This entry refers to `Image control` (`ImageModel`) inside `Child` (`ChildModel`) documentation.

## Contents

`ImageModel` inherits from `UIElementModel`, so you can read about basic properties in it’s [docs](UIElement.md).

`Images` can be stored in your `json` files inside of `Grid.Children` element.

|   Name    |       Description       |    Comment    | Default value |          Example           |
| :-------: | :---------------------: | :-----------: | :-----------: | :------------------------: |
| `Content` | Path to image, `string` | Relative path |    `null`     | `Resources/Images/Bg1.png` |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>ImageModel.cs</summary>

``` cs --source-file ../Models/UIElementModels/ImageModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
"Image": {
    "Name": "Bg",
    "Content": "Resources/Images/Bg/thousand2.jpg",
    "ParentRow": 0,
    "ParentColumn": 0,
    "RowSpan": 2,
    "VerticalAlignment": "Stretch",
    "HorizontalAlignment": "Stretch"
}
```