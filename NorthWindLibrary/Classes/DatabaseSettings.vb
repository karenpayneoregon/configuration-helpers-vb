Namespace Classes
    ''' <summary>
    ''' Properties for setting up a connection string
    ''' </summary>
    Public Class DatabaseSettings
        Public Property DatabaseServer() As String
        Public Property Catalog() As String
        Public Property IntegratedSecurity() As Boolean
        Public Property UsingLogging() As Boolean
        Public ReadOnly Property ConnectionString() As String
            Get
                Return $"Data Source={DatabaseServer};Initial Catalog={Catalog};Integrated Security={IntegratedSecurity}"
            End Get
        End Property

    End Class
End NameSpace