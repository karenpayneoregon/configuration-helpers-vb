# About

Code sample for reading information from `app.config` in a .NET Framework 4.8 project.

Two properties to read `ConnectionString` and `WindowsAuthentication`.

```xml
<userSettings>
    <AppSettingsMySettings.My.MySettings>
        <setting name="ConnectionString" serializeAs="String">
            <value>Data Source=DevServer;Initial Catalog=NorthWindAzure;Integrated Security=True</value>
        </setting>
        <setting name="WindowsAuthentication" serializeAs="String">
            <value>True</value>
        </setting>
    </AppSettingsMySettings.My.MySettings>
</userSettings>
```