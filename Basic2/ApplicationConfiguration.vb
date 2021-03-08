Imports Microsoft.Extensions.Configuration

Public NotInheritable Class ApplicationConfiguration
    Private Shared ReadOnly Lazy As New Lazy(Of ApplicationConfiguration)(Function() New ApplicationConfiguration())

    ''' <summary>
    ''' Access point to methods and properties
    ''' </summary>
    Public Shared ReadOnly Property Instance() As ApplicationConfiguration
        Get
            Return Lazy.Value
        End Get
    End Property

    Private Property Settings() As IConfiguration

    Public Property MailToAddressList() As List(Of String)

    Private Sub New()
        SetUp()
    End Sub
    ''' <summary>
    ''' Initialize configuration to read json file
    ''' </summary>
    ''' <returns></returns>
    Private Function GetConfiguration() As IConfiguration

        Dim builder = (New ConfigurationBuilder()).
                SetBasePath(AppContext.BaseDirectory).
                AddJsonFile("appsettings.json",
                            [optional]:=True,
                            reloadOnChange:=True)

        Return builder.Build()

    End Function
    ''' <summary>
    ''' Get values from json file, assign to properties
    ''' </summary>
    Private Sub SetUp()

        MailToAddressList = New List(Of String)
        Settings = GetConfiguration()

        _connectionString = Settings("Environment:ConnectionString")
        _mailAddress = Settings("Environment:MailTo").Split(";"c).ToList()
        _useGeoLocation = CType(Settings("Environment:UseGeoLocation"), Boolean)

    End Sub

    Private Shared _mailAddress As List(Of String)
    ''' <summary>
    ''' Mail addresses for sending error report
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MailAddresses() As List(Of String)
        Get
            Return _mailAddress
        End Get
    End Property
    Private Shared _connectionString As String
    ''' <summary>
    ''' Database connection string
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
    End Property

    Private Shared _useGeoLocation As Boolean
    ''' <summary>
    ''' Get current location
    ''' </summary>
    ''' <returns>True collect, False do not collect geo location</returns>
    Public ReadOnly Property UseGeoLocation() As Boolean
        Get
            Return _useGeoLocation
        End Get
    End Property
End Class
