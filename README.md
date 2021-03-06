# Jaml

**Jaml** is an alternative to **Xaml**, that uses `.json` files instead

The nearest plans are for **WPF** support (**Jaml.Wpf** library), but in future I'd like to support a cross-platform solution too (using **Avalonia UI** probably?).

[![Build status](https://ci.appveyor.com/api/projects/status/0fvuk184rr4qgu8j?svg=true)](https://ci.appveyor.com/project/Gigas002/jaml) [![Actions Status](https://github.com/Gigas002/Jaml/workflows/.NET%20Core%20CI/badge.svg)](https://github.com/Gigas002/Jaml/actions)

## Table of contents

- [Table of contents](#table-of-contents)
- [Current state](#current-state)
- [Building](#building)
- [Documentation](#documentation)
- [Contributing](#contributing)
- [License](#license)

## Current state

This project supports [SemVer 2.0.0](https://semver.org/) with template `{MAJOR}.{MINOR}.{PATCH}.{BUILD}`.

The project is still heavy under development and there's a lot of things to do before releasing something.
Feel free to contribute, just read the [CONTRIBUTING](CONTRIBUTING.md) file first.

You can also track current state in GitHub's [issues](https://github.com/Gigas002/Jaml/issues), [milestones](https://github.com/Gigas002/Jaml/milestones) and [projects](https://github.com/Gigas002/Jaml/projects).

Stable releases will be located here: [![Release](https://img.shields.io/github/release/Gigas002/Jaml.svg)](https://github.com/Gigas002/Jaml/releases/latest), or on NuGet: [![NuGet](https://img.shields.io/nuget/v/Jaml.svg)](https://www.nuget.org/packages/Jaml.Wpf/).

Previous versions can be found on [releases](https://github.com/Gigas002/Jaml/releases) and [branches](https://github.com/Gigas002/Jaml/branches) pages. You can also search through **Git**'s tags.

If you want to learn, what've been done in previous releases, take a look at [CHANGELOG](CHANGELOG.md).

## Building

This project uses `Microsoft.NET.Sdk.WindowsDesktop`, so you you can only build and use it on **Windows** systems.

Solution can be build in **VS2019 (16.8.3+)**. You can also use **VSCode (1.52.0+)** with **omnisharp-vscode (1.23.7+)** extension.

Project targets **.NET 5.0.1**, so you'll need **.NET 5.0.101 SDK**.

## Dependencies

**Build from source only:**

- [Microsoft.CodeAnalysis.NetAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.NetAnalyzers/) -- 5.0.1;
- [Microsoft.SourceLink.GitHub](https://www.nuget.org/packages/Microsoft.SourceLink.GitHub/) -- 1.0.0;

## Documentation

Offline documentation is located inside of [Jaml.Wpf/Docs](Jaml.Wpf/Docs/README.md) directory.

To browse the docs offline, it's recommended to use [dotnet try](https://github.com/dotnet/try) tool. Really, just give it a try! To see the docs, just run the `docs.ps1` script.

## Contributing

Feel free to contribute this project: make forks, issues, PRs, etc. For more details, please read [CONTRIBUTING](CONTRIBUTING.md).

## License

The project is distributed under [DBADPL](https://dbad-license.org/) license. Read the [LICENSE](LICENSE.md) for more details.
