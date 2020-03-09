# UiElement

`UiElement` (`Jaml.Wpf.Models.UiElementModel`) represents every control on your window, it’s the basic class for all `controlModel`s.

You don’t create this element in `json` explicitly, but since it’s the basic thing, here’s docs for it.

## Contents

`UiElementModel` inherits from `IUiElementModel`.

|         Name          |                      Description                       |                           Comment                            |       Default value       |  Example   |
| :-------------------: | :----------------------------------------------------: | :----------------------------------------------------------: | :-----------------------: | :--------: |
|        `Name`         |            Current control's name, `string`            |   Optional field, not used in code. Can be used as comment   |          `null`           | `MainPage` |
|  `VerticalAlignment`  |    Vertical alignment of current control, `string`     | Read [msdn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.verticalalignment) article for more info |         `Center`          | `Stretch`  |
| `HorizontalAlignment` |   Horizontal alignment of current control, `string`    | Read [msdn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.horizontalalignment) article for more info |         `Center`          | `Stretch`  |
|       `Content`       |          Content of current control, `string`          |        For more details read specific control’s docs         |          `null`           |            |
|       `StyleId`       |       Id of style to use for this element, `int`       | For more information about this, please, read the [Styles](Styles.md) |           `-1`            |    `0`     |
|      `ParentRow`      |         Position in parent `Grid`‘s row, `int`         |               Not used for main page’s `Grid`                |            `0`            |    `1`     |
|    `ParentColumn`     |       Position in parent `Grid`‘s column, `int`        |               Not used for main page’s `Grid`                |            `0`            |    `1`     |
|       `RowSpan`       |      Controls how many rows control takes, `int`       |                             None                             |            `1`            |    `2`     |
|     `ColumnSpan`      |     Controls how many columns control takes, `int`     |                             None                             |            `1`            |    `2`     |
|      `Commands`       | Commands, associated with this element, `CommandModel` |    For more info, please, read the [Command](Commands.md)    | Empty `List<CommandModel` |            |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>UiElementModel.cs</summary>

``` cs --source-file ../Models/UiElementModels/UiElementModel.cs --project ../Jaml.Wpf.csproj

```

</details>

