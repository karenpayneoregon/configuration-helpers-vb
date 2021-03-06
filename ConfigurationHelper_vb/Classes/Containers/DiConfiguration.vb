Namespace Classes
	''' <summary>
	''' A fictitious class to store setting in appsettings.json for a fictitious app
	''' </summary>
	Public Class DiConfiguration
		Public Property Dsn() As String
		Public Property Globals() As String
		Public Property Globals2() As String
		Public Property MailTo() As String
		Public Property ExitLink() As String
		Public Property OcsLink() As String
		Public Property MfLink() As String
		Public Property MfUser() As String
		Public Property MfPass() As String
		Public Property UseGeoLocation() As Boolean
		Public Property ResetPinLocation() As String
		Public Property BaseServerAddress() As String
		Public Property UirTakeTest() As Boolean
		Public Property QryCacheShort() As TimeSpan
		Public Property QryCacheLong() As TimeSpan
	End Class
End Namespace