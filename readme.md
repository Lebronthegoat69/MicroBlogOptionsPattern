{

}
# MicroBlog Options Pattern

## Project Overview

This project demonstrates how to use the Options Pattern in an ASP.NET Core Razor Pages application. Application settings are stored in configuration files and injected into the application using dependency injection.

## Features

* Uses a `SiteOptions` class to define application settings.
* Binds configuration values from `appsettings.json`.
* Displays the configured site name in the shared layout.
* Controls whether the comment form appears using the `EnableComments` setting.
* Uses `appsettings.Development.json` to override settings for the Development environment.
* Uses different configurations for Development and Production.

## Configuration

### appsettings.json

The default configuration sets the site name to `My Micro Blog` and disables comments.

```json
"SiteOptions": {
  "SiteName": "My Micro Blog",
  "EnableComments": false
}
```

### appsettings.Development.json

The Development configuration enables comments.

```json
"SiteOptions": {
  "SiteName": "My Micro Blog",
  "EnableComments": true
}
```

When the application runs in Development mode, the comment form appears on the post Details page. When the application runs in Production mode, the default configuration disables the comment form.

## Options Pattern Implementation

The `SiteOptions` class defines the configuration properties:

* `SiteName`: Controls the name displayed in the site's shared layout.
* `EnableComments`: Controls whether the comment form is displayed.

In `Program.cs`, the configuration section is registered using:

```csharp
builder.Services.Configure<SiteOptions>(
    builder.Configuration.GetSection("SiteOptions"));
```

The settings are accessed through dependency injection using `IOptions<SiteOptions>`.

### Production Environment

The Production environment disables the comment form.

* C#
* ASP.NET Core Razor Pages
* .NET
* Dependency Injection
* Options Pattern
* JSON configuration files
* Git and GitHub

## How to Run

1. Open the project in Visual Studio.
2. Restore dependencies if prompted.
3. Build the solution.
4. Run the application.
5. Use the Development environment to see comments enabled.
6. Use the Production environment to see comments disabled.

Sam
<img width="479" height="433" alt="image" src="https://github.com/user-attachments/assets/d72e24e3-e296-490b-8750-3c0ba9916894" />
<img width="455" height="431" alt="image" src="https://github.com/user-attachments/assets/a87258c0-7f6b-4d35-b545-752bf17da243" />
