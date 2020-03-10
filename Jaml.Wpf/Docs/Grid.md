# Grid

This entry refers to `Grid control` (`GridModel`) documentation.

`Grid` contains all of your elements on page.

## Contents

`GridModel` inherits from `UIElementModel`, so you can read about basic properties in it’s [docs](UIElement.md).

`Grid` properties are not required by default, but can be required for some `children` controls. If initialized `Grid` without properties -- the app will be open with blank page.

|        Name         |                         Description                          |                           Comment                            | Default value | Example |
| :-----------------: | :----------------------------------------------------------: | :----------------------------------------------------------: | :-----------: | :-----: |
|  `RowDefinitions`   | Row definitions array for grid, `IEnumerable<RowDefinitionModel>` |   Read [RowDefinition](RowDefinition.md) for more details    |  Empty list   |         |
| `ColumnDefinitions` | Column definitions array for grid, `IEnumerable<ColumnDefinitionModel>` | Read [ColumnDefinition](ColumnDefinition.md) for more details |  Empty list   |         |
|    `Background`     |                      `BackgroundModel`                       |                             WIP                              |      WIP      |   WIP   |
|     `Children`      | Collection of child controls on grid, `IEnumerable<ChildModel>` |           Read [Child](Child.md) for more details            |               |         |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>GridModel.cs</summary>

``` cs --source-file ../Models/UIElementModels/GridModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
"Grid": {
    "Name": "MainGrid",
    "RowDefinitions": [{
            "Height": "*"
        }
    ],
    "ColumnDefinitions": [{
        "Width": "*"
    }],
    "VerticalAlignment": "Stretch",
    "HorizontalAlignment": "Stretch",
    "Children": [
    ]
}
```