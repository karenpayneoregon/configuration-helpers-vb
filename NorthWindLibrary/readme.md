# About

Code sample using appsettings.json for obtaining connection string

The `appsettings.json` in `NorthWindEntityCore` console project.

```json
{
  "GeneralSettings": {
    "LogExceptions": false,
    "DatabaseSettings": {
      "DatabaseServer": ".\\SQLEXPRESS",
      "Catalog": "NorthWind2020",
      "IntegratedSecurity": true,
      "UsingLogging": true
    },
    "EmailSettings": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "EnableSsl": true,
      "DefaultCredentials": false,
      "PickupDirectoryLocation": "MailDrop"
    }
  }
}
```

# Requires

![screen](../assets/Versions.png)

:heavy_check_mark: Visual Studio 2019 or higher

### NuGet packages

:heavy_check_mark: [microsoft.extensions.configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/) <br/>
:heavy_check_mark: [microsoft.extensions.configuration.binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/)<br/>
:heavy_check_mark: [microsoft.extensions.configuration.FileExensions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions/)<br/>
:heavy_check_mark: [microsoft.extensions.configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)