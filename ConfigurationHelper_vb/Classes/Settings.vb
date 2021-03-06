Namespace Classes
	''' <summary>
	''' A fictitious class to store setting in appsettings.json for a fictitious app
	''' Container for application settings read using Helper class
	''' </summary>
	Public Class Settings
		Public Property Environment() As String
		Public Property ReloadApplicationOnEveryRequest() As Boolean
		Public Property Trace() As Boolean
		Public Property Reload() As String
		Public Property Password() As Boolean
		Public Property MailAddressesList() As List(Of String)
		Public Property DiConfiguration() As DiConfiguration

		Public Property ConnectionString() As String

		Public Sub New()
			DiConfiguration = New DiConfiguration()
		End Sub

		Public Overrides Function ToString() As String
			Return Environment
		End Function
	End Class
End Namespace
