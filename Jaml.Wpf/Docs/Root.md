# Root

This entry refers to `Root.json` documentation.

`Root.json` is one of a few required files for your application to work. It should be placed into `Resources` directory of your app.

## Contents

`PageModel` inherits from `IJsonModel` interface.

Content of `Root.json` file should define paths for different files, used in your app.

Required parameters:

|    Name     |                         Description                          |                           Comment                            | Default value | Example                    |
| :---------: | :----------------------------------------------------------: | :----------------------------------------------------------: | :-----------: | -------------------------- |
| `FirstPage` | Defines the path to entry page of your visual novel, `string` | If you don't specify this parameter, the application won't throw the exception, but load an empty page instead |    `null`     | `Resources/UI/OnLoad.json` |

Optional parameters:

|   Name   |                         Description                          |                  Comment                  | Default value | Example                    |
| :------: | :----------------------------------------------------------: | :---------------------------------------: | :-----------: | -------------------------- |
| `Styles` | Defines the path to the file with styles for your controls, `string` | Read [Styles](Styles.md) for more details |    `null`     | `Resources/UI/Styles.json` |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>RootModel.cs</summary>

``` cs --source-file ../Models/JsonModels/RootModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
{
    "Root":
    {
        "FirstPage": "Resources/UI/OnLoad.json",
        "Styles": "Resources/UI/Styles.json"
    }
}
```
