# ColumnDefinition

This entry refers to `ColumnDefinition` (`ColumnDefinition`) property (`ColumnDefinitions`) of `Grid` (`GridModel`) documentation.

## Contents

Optional parameters:

|  Name   |                  Description                  |                           Comment                            | Default value | Example |
| :-----: | :-------------------------------------------: | :----------------------------------------------------------: | :-----------: | :-----: |
| `Width` | Height of current column definition, `string` | Can contain values `*` for all available height, `Auto` for automatic calculation, depends on content size and `double` (inside string!) for exact size |    `Auto`     |   `*`   |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>ColumnDefinitionModel.cs</summary>

``` cs --source-file ../Models/UIElementModels/ColumnDefinitionModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
{
	"Width": "*"
}
```