Imports System.IO
Imports System.Xml

Imports ConfigurationHelperSamples.Classes
Imports ConfigurationHelperSamples.Classes.Containers

Imports Microsoft.Extensions.Configuration
Imports Newtonsoft.Json

Public Class Helper
    Private Shared _fileName As String = "appsettings.json"
    ''' <summary>
    ''' Connection string for application database stored in appsettings.json
    ''' Another option would be to have the full connection string in the json file.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ConnectionString() As String

        InitConfiguration()

        Dim applicationSettings = InitOptions(Of DatabaseSettings)("database")

        Return $"Data Source={applicationSettings.DatabaseServer};" &
                $"Initial Catalog={applicationSettings.Catalog};" &
                "Integrated Security=True"
    End Function
    Public Shared Function Configuration() As GeneralSettings

        InitConfiguration()
        Return InitOptions(Of GeneralSettings)("GeneralSettings")

    End Function
    Public Shared Function AllSettings() As GeneralSettingsRoot
        Dim json = File.ReadAllText(_fileName)
        Return JsonConvert.DeserializeObject(Of GeneralSettingsRoot)(json)
    End Function
    ''' <summary>
    ''' Update all settings
    ''' </summary>
    ''' <param name="root"></param>
    Public Shared Sub Update(root As GeneralSettingsRoot)
        Dim output As String = JsonConvert.SerializeObject(root, Newtonsoft.Json.Formatting.Indented)
        File.WriteAllText(_fileName, output)

    End Sub

    ''' <summary>
    ''' Initialize ConfigurationBuilder
    ''' </summary>
    ''' <returns>IConfigurationRoot</returns>
    Private Shared Function InitConfiguration() As IConfigurationRoot

        Dim builder = (New ConfigurationBuilder()).
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile(
                    _fileName,
                    [optional]:=True,
                    reloadOnChange:=True)

        Return builder.Build()

    End Function
    ''' <summary>
    ''' Generic method to read a section from the json configuration file.
    ''' </summary>
    ''' <typeparam name="T">Class type</typeparam>
    ''' <param name="section">Section to read</param>
    ''' <returns>Instance of T</returns>
    Public Shared Function InitOptions(Of T As New)(section As String) As T

        Dim config = InitConfiguration()
        Return config.GetSection(section).Get(Of T)()

    End Function
End Class
