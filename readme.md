# About

In the .NET Framework prior to .NET Core application settings were in  [app.config](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/) file. 
All settings e.g. database connection, email setting etc in one file along with each 
setting are strings which need to be converted to proper types (see [the following](https://github.com/karenpayneoregon/configuration-helpers) for conversions) 
plus some functionality is missing like smtp sections. Moving to .NET Core, the standard is using 
a Json file generally named appsettings.json. The intent here is to layout how to use appsettings.json 
for desktop applications.



# GitHub repository

https://github.com/karenpayneoregon/configuration-helpers-vb

# Microsoft TechNet Article

TODO

# Sample configurations

**Examples 1**

```json
{
  "GeneralSettings": {
    "LogExceptions": true,
    "DatabaseSettings": {
      "DatabaseServer": ".\\SQLEXPRESS",
      "Catalog": "School",
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

**Example 2**

This one may not have the best names for properties although that is not really a problem especially when it's easy to setup alias for a property.

```json
{

  "Environment": {
    "Name": "Development"
  },
  "GeneralSettings": [
    {
      "Environment": "Development",
      "ReloadApplicationOnEveryRequest": true,
      "Trace": false,
      "Reload": "reload",
      "Password": true,
      "ConnectionString": "Dev connection",
      "DiConfiguration": {
        "Dsn": "ABC",
        "Globals": "globals",
        "Globals2": "globals2",
        "MailTo": "karen.payne@someDomain.com;fred.smith@comcast.net;billAdams@gmail.com",
        "ExitLink": "/ocs4/",
        "OcsLink": null,
        "MfLink": "",
        "MfUser": null,
        "MfPass": "",
        "UseGeoLocation": true,
        "ResetPinLocation": "/pinchange/begin/",
        "BaseServerAddress": "xxx4",
        "UirTakeTest": false,
        "QryCacheShort": "00:00:10",
        "QryCacheLong": "00:00:05"
      }
    },
    {
      "Environment": "Test",
      "ReloadApplicationOnEveryRequest": false,
      "Trace": false,
      "Reload": "reload",
      "Password": true,
      "ConnectionString": "Test connection",
      "DiConfiguration": {
        "Dsn": "DEF",
        "Globals": "globals",
        "Globals2": "globals2",
        "MailTo": "karen.payne@someDomain.com;fred.smith@comcast.net;billAdams@gmail.com",
        "ExitLink": "/ocs4/",
        "OcsLink": null,
        "MfLink": "",
        "MfUser": null,
        "MfPass": "",
        "UseGeoLocation": true,
        "ResetPinLocation": "/pinchange/begin/",
        "BaseServerAddress": "xxx4",
        "UirTakeTest": false,
        "QryCacheShort": "00:10:00",
        "QryCacheLong": "00:01:00"
      }
    },
    {
      "Environment": "Production",
      "ReloadApplicationOnEveryRequest": false,
      "Trace": false,
      "Reload": "reload",
      "Password": true,
      "ConnectionString": "Prod connection",
      "DiConfiguration": {
        "Dsn": "GHI",
        "Globals": "globals",
        "Globals2": "globals2",
        "MailTo": "karen.payne@someDomain.com;fred.smith@comcast.net;billAdams@gmail.com",
        "ExitLink": "/ocs4/",
        "OcsLink": null,
        "MfLink": "",
        "MfUser": null,
        "MfPass": "",
        "UseGeoLocation": true,
        "ResetPinLocation": "/pinchange/begin/",
        "BaseServerAddress": "xxx4",
        "UirTakeTest": false,
        "QryCacheShort": "06:00:00",
        "QryCacheLong": "00:30:00",
        "ConnectionString": "Prod connection"
      }
    }
  ]
}
```


# C# version

:heavy_check_mark: [Article](https://social.technet.microsoft.com/wiki/contents/articles/54173.net-core-desktop-application-configurations-c.aspx)

:heavy_check_mark: [repostory](https://github.com/karenpayneoregon/configuration-helpers)


