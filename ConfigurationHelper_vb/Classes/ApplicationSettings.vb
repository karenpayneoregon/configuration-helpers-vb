Namespace Classes
	''' <summary>
	''' Singleton entry point to access information from appsettings.json
	'''
	''' For each property to be exposed which have not been, setup a private
	''' variable, set it's value in the new constructor followed creating a read-only
	''' property for accessing the value.
	''' </summary>
	Public NotInheritable Class ApplicationSettings
		Private Shared ReadOnly Lazy As New Lazy(Of ApplicationSettings)(Function() New ApplicationSettings())

		Private Shared _dsn As String
		Private Shared _environment As String
		Private Shared _connectionString As String
		Private Shared _mailAddress As List(Of String)
		Private Shared _qryCacheShort As TimeSpan

		Private Sub New()
			LoadSettings()
		End Sub
		''' <summary>
		''' Load settings, in this case only several settings
		''' are exposed.
		''' </summary>
		Private Sub LoadSettings()
			Dim settings = Helper.GetApplicationSettings()

			_dsn = settings?.DiConfiguration.Dsn
			_environment = If(settings?.Environment, "Development")
			_mailAddress = settings.MailAddressesList
			_qryCacheShort = settings.DiConfiguration.QryCacheShort
			_connectionString = settings.ConnectionString
		End Sub

		''' <summary>
		''' Access point to methods and properties
		''' </summary>
		Public Shared ReadOnly Property Instance() As ApplicationSettings
			Get
				Return Lazy.Value
			End Get
		End Property
		''' <summary>
		''' Reload settings from appsettings.json
		''' </summary>
		Public Sub Reload()
			LoadSettings()
		End Sub
		Public ReadOnly Property Dsn() As String
			Get
				Return _dsn
			End Get
		End Property
		''' <summary>
		''' Indicates to use dev, test or prod environment
		''' </summary>
		''' <returns></returns>
		Public ReadOnly Property Environment() As String
			Get
				Return _environment
			End Get
		End Property
		''' <summary>
		''' For database connection string
		''' </summary>
		''' <returns></returns>
		Public ReadOnly Property ConnectionString() As String
			Get
				Return _connectionString
			End Get
		End Property
		Public ReadOnly Property MailAddresses() As List(Of String)
			Get
				Return _mailAddress
			End Get
		End Property
		Public ReadOnly Property QryCacheShort() As TimeSpan
			Get
				Return _qryCacheShort
			End Get
		End Property
	End Class
End Namespace
