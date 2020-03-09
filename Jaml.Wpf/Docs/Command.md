# Command

This entry is about so-called commands: binding control-specific events to methods.

## Contents

`CommandModel` inherits from `ICommandModel` interface.

`Command` can be stored in your `json` files inside of `Control` elements, e.g. `Button`.

Required parameters:

|  Name   |           Description           |                           Comment                            | Default value | Example |
| :-----: | :-----------------------------: | :----------------------------------------------------------: | :-----------: | :-----: |
| `Event` | Name of event to bind, `string` | Read current control’s msdn article to see full list of events |    `null`     | `Click` |

Optional parameters:

|   Name   |                Description                |                           Comment                            | Default value |        Example        |
| :------: | :---------------------------------------: | :----------------------------------------------------------: | :-----------: | :-------------------: |
| `Method` |     Name of method to bind, `string`      |      Read [List of supported commands]() for more info       |    `null`     |    `LoadPageModel`    |
|  `Args`  | Arguments to the method to call, `string` | Specify the exact amount of `args` or do not create this element at all |    `null`     | `Resources/Next.json` |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>CommandModel.cs</summary>

``` cs --source-file ../Models/CommandModels/CommandModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
"Commands": [{
    "Event": "PreviewMouseLeftButtonUp",
    "Method": "LoadPageModel",
    "Args": "Resources/UI/MainMenu.json"
},{
    "Event": "MouseRightButtonUp",
    "Method": "CloseApp"
}]
```