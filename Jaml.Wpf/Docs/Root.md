# Root

This entry refers to `Root.json` documentation.

`Root.json` is one of a few required files for your application to work. It should be placed into `Resources` directory of your app.

## Contents

`RootModel` inherits from `IJsonModel` interface.

Content of `Root.json` file should define paths for different files, used in your app.

|     Name     |                         Description                          |                      Comment                      | Default value | Example                     |
| :----------: | :----------------------------------------------------------: | :-----------------------------------------------: | :-----------: | --------------------------- |
| `FirstPage`  |     Defines the path to entry page of your app, `string`     |       Read [Page](Page.md) for more details       |    `null`     | `Resources/UI/OnLoad.json`  |
|   `Styles`   | Defines the path to the file with styles for your controls, `string` |     Read [Styles](Styles.md) for more details     |    `null`     | `Resources/UI/Styles.json`  |
| `MainWindow` |     Defines the path to main window of the app, `string`     | Read [MainWindow](MainWindow.md) for more details |    `null`     | `Resources/MainWindow.json` |

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
