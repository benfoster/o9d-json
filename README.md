<img alt="Json Icon" src="src/Json.Formatting/assets/icon.png" width="64px" />

# JSON Extensions

[![NuGet](https://img.shields.io/nuget/v/O9d.Json.Formatting.svg)](https://www.nuget.org/packages/O9d.Json.Formatting) 
[![NuGet](https://img.shields.io/nuget/dt/O9d.Json.Formatting.svg)](https://www.nuget.org/packages/O9d.Json.Formatting)
[![License](https://img.shields.io/:license-mit-blue.svg)](https://benfoster.mit-license.org/)

![Build](https://github.com/benfoster/o9d-json/workflows/Build/badge.svg)
[![Coverage Status](https://coveralls.io/repos/github/benfoster/o9d-json/badge.svg?branch=main)](https://coveralls.io/github/benfoster/o9d-json?branch=main)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=benfoster_o9d-json&metric=alert_status)](https://sonarcloud.io/dashboard?id=benfoster_o9d-json)


Extensions for [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-5.0).

## Quick Start

Add the O9d.Json.Formatting package from [NuGet](https://www.nuget.org/packages/O9d.Json.Formatting)

```
dotnet add package O9d.Json.Formatting
```

If you want to use a pre-release package, you can download them GitHub packages.

## Features

### Snake Case Formatting

This O9d.Json.Formatting library adds support for snake_case formatting to System.Text.Json which is [still missing](https://github.com/dotnet/runtime/issues/782). The included implementation originates from the [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) project.

To configure snake case formatting when using `JsonSerializer` directly:

```c#
var options = new JsonSerializerOptions()
{
    PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
};

string json = JsonSerializer.Serialize(someObj, options);
```

To configure snake case formatting in an ASP.NET Core MVC project:

```c#
services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
    });
```

Or in ASP.NET 6.0 Minimal APIs:

```c#
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy());
});
```

### Pre-release Packages

Pre-release packages can be downloaded from [GitHub Packages](https://github.com/benfoster?tab=packages&repo_name=o9d-json).

```
dotnet add package O9d.Json.Formatting --prerelease --source https://nuget.pkg.github.com/benfoster/index.json
```

[More information](https://docs.github.com/en/packages/guides/configuring-dotnet-cli-for-use-with-github-packages) on using GitHub packages with .NET.

## Building locally 

This project uses [Cake](https://cakebuild.net/) to build, test and publish packages. 

Run `build.sh` (Mac/Linux) or `build.ps1` (Windows) To build and test the project. 

This will output NuGet packages and coverage reports in the `artifacts` directory.

## Contributing

To contribute to O9d.Json, fork the repository and raise a PR. If your change is substantial please [open an issue](https://github.com/benfoster/o9d-json/issues) first to discuss your objective.

## Docs

The JSON documentation is built using [DocFx](https://dotnet.github.io/docfx/). To build and serve the docs locally run:

```
./build.sh --target ServeDocs
```

This will serve the docs on http://localhost:8080.
