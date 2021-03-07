# About

Read setting not using My.Settings, instead reads properties using the following class

```csharp
Imports System.Configuration
Imports System.Xml
Imports System.Xml.Serialization

Public Class AppSettngsLoader
    Implements IConfigurationSectionHandler

    Public Function Create(parent As Object, configContext As Object, section As XmlNode) As Object _
        Implements IConfigurationSectionHandler.Create

        If section Is Nothing Then
            Throw New ArgumentNullException($"XMLNode passed in is null.")
        End If

        Dim type = AppDomain.CurrentDomain.GetAssemblies().
                SelectMany(Function(assembly) assembly.GetTypes()).
                FirstOrDefault(Function(itemType) itemType.Name = section.Name)

        If type Is Nothing Then
            Throw New ArgumentException($"Type with name {section.Name} couldn't be found.")
        End If

        Dim ser As New XmlSerializer(type, New XmlRootAttribute(section.Name))

        Using reader As XmlReader = New XmlNodeReader(section)
            Return ser.Deserialize(reader)
        End Using

    End Function

End Class
```


Two properties to read `ConnectionString` and `WindowsAuthentication`.

```xml
<SettingsConfig>
	<ConnectionString>Data Source=DevServer;Initial Catalog=NorthWindAzure;Integrated Security=True</ConnectionString>
	<WindowsAuthentication>true</WindowsAuthentication>
</SettingsConfig>
```

