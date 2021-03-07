''' <summary>
''' A fictitious class to store setting in appsettings.json for a fictitious app
''' </summary>
Public Class SettingsConfig
    Public Property ConnectionString() As String
    Public Property WindowsAuthentication() As Boolean

    Public Overrides Function ToString() As String
        Return $"{ConnectionString}, {WindowsAuthentication}"
    End Function
End Class

