# Page

This entry refers to pages `.json` documentation.

Pages are the core of your application. To learn how to link your first page, please read the [Root](Root.md) documentation file. If you want to learn, how to link other pages, read this file further.

## Contents

`PageModel` inherits from `IJsonModel` interface.

Page should define only one element, and it is `Grid`:

Required parameters:

|  Name  |                    Description                     |                           Comment                            | Default value | Example            |
| :----: | :------------------------------------------------: | :----------------------------------------------------------: | :-----------: | ------------------ |
| `Grid` | Contains all elements on current page, `GridModel` | Throws an exception, if no `Grid` in `Page.json`. To read more info, please read [Grid](Grid.md) documentation |    `null`     | Page example below |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>PageModel.cs</summary>

``` cs --source-file ../Models/JsonModels/PageModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
{
    "Page": {
        "Grid":{
        }
    }
}
```
