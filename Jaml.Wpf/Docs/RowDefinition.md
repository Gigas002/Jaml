# RowDefinition

This entry refers to `RowDefinition` (`RowDefinition`) property (`RowDefinitions`) of `Grid` (`GridModel`) documentation.

## Contents

Optional parameters:

|   Name   |                Description                 |                           Comment                            | Default value | Example |
| :------: | :----------------------------------------: | :----------------------------------------------------------: | :-----------: | :-----: |
| `Height` | Height of current row definition, `string` | Can contain values `*` for all available height, `Auto` for automatic calculation, depends on content size and `double` (inside string!) for exact size |    `Auto`     |   `*`   |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>RowDefinitionModel.cs</summary>

``` cs --source-file ../Models/UiElementModels/RowDefinitionModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
{
	"Height": "*"
}
```