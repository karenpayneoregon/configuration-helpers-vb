Module Program
    Sub Main(args As String())

        WriteHeader("appsettings.json simple")
        EmptyLine()

        WriteWhite("ConnectionString")
        Console.WriteLine(ApplicationConfiguration.Instance.ConnectionString)
        EmptyLine()

        WriteWhite("Mail addresses")

        For index As Integer = 0 To ApplicationConfiguration.Instance.MailAddresses.Count - 1
            WriteYellow($"{vbTab}{index}", ApplicationConfiguration.Instance.MailAddresses(index))
        Next

        EmptyLine()

        WriteWhite("UseGeoLocation")

        Console.WriteLine(ApplicationConfiguration.Instance.UseGeoLocation)
        EmptyLine()

        PressAnyKey()

    End Sub

End Module
