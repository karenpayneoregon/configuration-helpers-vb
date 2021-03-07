Imports System.IO
Imports Classes
Imports Microsoft.Extensions.Configuration

Public Class Helper
    Private Shared _dsn As String

    ''' <summary>
    ''' Configuration file name to read from.
    ''' </summary>
    Public Shared Property ConfigurationFileName() As String = "appsettings.json"

    ''' <summary>
    ''' Return all settings for the current environment
    ''' </summary>
    ''' <remarks>
    ''' This method may be called and ignore the return information and
    ''' use the properties in this class instead.
    ''' </remarks>
    Public Shared Function GetApplicationSettings() As Settings
        Dim config = InitMainConfiguration()

        Dim current = config.
                GetSection("GeneralSettings").
                Get(Of List(Of Settings))().
                FirstOrDefault(Function(setting) setting.Environment = Environment)

        _dsn = current?.DiConfiguration.Dsn

        _mailAddress = current?.DiConfiguration.MailTo.Split(";"c).ToList()
        current.MailAddressesList = _mailAddress

        _qryCacheShort = current.DiConfiguration.QryCacheShort

        Return current

    End Function
    ''' <summary>
    ''' Current environment this application will run under
    ''' </summary>
    Public Shared ReadOnly Property Environment() As String
        Get
            Dim config = InitMainConfiguration()
            Return config.GetSection("Environment").Get(Of Environment)().Name
        End Get
    End Property

    Private Shared _qryCacheShort As TimeSpan
    ''' <summary>
    ''' Short time out for the application
    ''' </summary>
    Public Shared ReadOnly Property QryCacheShort() As TimeSpan
        Get
            Return _qryCacheShort
        End Get
    End Property
    ''' <summary>
    ''' DSN used in the entire application
    ''' </summary>
    Public Shared ReadOnly Property Dsn() As String
        Get
            Return _dsn
        End Get
    End Property
    ''' <summary>
    ''' List of email addresses for sending on unhandled exceptions
    ''' </summary>
    Private Shared _mailAddress As List(Of String)
    Public Shared ReadOnly Property MailAddress() As List(Of String)
        Get
            Return _mailAddress
        End Get
    End Property

    ''' <summary>
    ''' Initialize ConfigurationBuilder for appsettings
    ''' </summary>
    ''' <returns>IConfigurationRoot</returns>
    Private Shared Function InitMainConfiguration() As IConfigurationRoot

        Dim builder = (New ConfigurationBuilder()).
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile(ConfigurationFileName)

        Return builder.Build()

    End Function
    ''' <summary>
    ''' Generic method to read a section from the json configuration file.
    ''' </summary>
    ''' <typeparam name="T">Class type</typeparam>
    ''' <param name="section">Section to read</param>
    ''' <returns>Instance of T</returns>
    ''' <remarks>
    '''     InitMainConfiguration()
    '''     Dim applicationSettings = InitOptions(Of DatabaseSettings)("database")
    ''' </remarks>
    Public Shared Function InitOptions(Of T As New)(section As String) As T
        Dim config = InitMainConfiguration()
        Return config.GetSection(section).Get(Of T)()
    End Function

End Class