# Contributing

The project is still on a very early state of development. Some elements and overall logics are implemented, but it's too early to talk about using it in production.

Current version is 0.1.0.x, which means, that EVERYTHING still can be changed. So everyone is welcome to contribute to the project. You're free to make issues, forks, etc, just please follow the following guidelines.

I welcome programmers of any levels, just please be polite to each other!

## Issues and PRs

You're free to create any PR's you think are good, but please create **only one PR per one issue**! That means, that PR should solve only the precise problem.

If you don't see the issue, that you'd like to fix with your PR, than open the issue first and tell in it's text, that you'd like to work on this feature. Otherwise I'll grab it myself or add the **up-for-grabs** badge. Also, please, don't forget to introduce a `Test` for your feature and add info in `Docs` if your PR changes the public API.

## How to extend root

To add additional properties to the `Root.json`, change the `Jaml.Wpf/Models/JsonModels/RootModel`, but you’ll most probably will need to add some other classes to models too.

## How to extend styles

To add additional properties to the `Styles.json`, change the `Jaml.Wpf/Models/StyleModels/IStyleModel` and `Jaml.Wpf/Models/StyleModels/StyleModel` interface and class.

## Adding new properties to parse

Not everything in the `json` file can be parsed straight to the WPF properties. If you'd like to add a new property, you should also introduce a parser for it. Property parsers are located in `Jaml.Wpf/Parsers/PropertyParser` static class. Just don't forget to create a separate issue for introducing a new parser (to prevent cases, when someone's already working for it).

## How to add a new control

To add a new control, you should create a new class inside of `Jaml.Wpf/Models/UiElementModels` folder and inherit from `UiElementModel` class. If you think, that functionality of your control should be available for all controls, then first create the PR and issue with adding this stuff to `IUiElementModel` and `UiElementModel`.

The final step is to add your control to the `Jaml.Wpf/Models/ChildModels/ChildModel` class.

## How to add a new event

First, write your event's name into `Jaml.Wpf/Constants/EventNames` class. Then add some code to the `Jaml.Wpf/Providers/CommandProvider/ICommandProvider.BindCommand` method. It's pretty easy to understand what to write, when you'll see the method's content.
