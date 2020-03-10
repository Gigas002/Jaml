# MediaElement

This entry refers to `MediaElement control` (`MediaElementModel`) inside `Child` (`ChildModel`) documentation.

## Contents

`MediaElementModel` inherits from `UIElementModel`, so you can read about basic properties in it’s [docs](UIElement.md).

`MediaElement`’s are **video** and **audio** files, that can be stored in your `json` files inside of `Grid.Children` element.

Required parameters:

|   Name    |         Description          |                Comment                | Default value |         Example         |
| :-------: | :--------------------------: | :-----------------------------------: | :-----------: | :---------------------: |
| `Content` | Path to media file, `string` | todo Supported extensions: `mp4, mp3` |    `null`     | `Resources/Video/1.mp4` |

## Class

Use `dotnet try` tool to see the contents of the code block below.

<details>
  <summary>MediaElementModel.cs</summary>

``` cs --source-file ../Models/UIElementModels/MediaElementModel.cs --project ../Jaml.Wpf.csproj

```

</details>

## Example

```json
"MediaElement": {
    "Name": "OpeningVideo",
    "ParentRow": 0,
    "ParentColumn": 0,
    "VerticalAlignment": "Stretch",
    "HorizontalAlignment": "Stretch",
    "Content": "Resources/Video/1.mp4",
    "Commands": [{
        "Event": "MediaEnded",
        "Method": "LoopMediaElement"
    },{
        "Event": "PreviewMouseLeftButtonUp",
        "Method": "LoadPageModel",
        "Args": "Resources/UI/MainMenu.json"
    },{
        "Event": "Initialized",
        "Method": "PlayMediaElement"
    }]
}
```