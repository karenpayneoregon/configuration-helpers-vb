
Imports Classes
Imports ConsoleHelpers

Module Program
    Sub Main(args As String())

        WriteHeader("Configuration code sample")

        Console.WriteLine($"Environment (Singleton): {ApplicationSettings.Instance.Environment}")

        Console.WriteLine($"            Environment: {Helper.Environment}")
        Console.WriteLine($"                    Dsn: {ApplicationSettings.Instance.Dsn}")
        Console.WriteLine($"      Connection string: {ApplicationSettings.Instance.ConnectionString}")

        EmptyLine()

        Dim mailAddress = ApplicationSettings.Instance.MailAddresses

        Console.WriteLine("Mail addresses")
        For Each address In mailAddress
            Console.WriteLine(vbTab & $"{address}")
        Next

        EmptyLine()
        Console.WriteLine($"QryCacheShort: {ApplicationSettings.Instance.QryCacheShort}")

        ReadLineWithTimeoutAndMessage()

    End Sub
End Module
