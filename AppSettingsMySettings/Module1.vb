Module Module1

    Sub Main()

        WriteHeader("Standard app.setting code sample")

        WriteYellow($"Connection string")
        Console.WriteLine(My.Settings.ConnectionString)

        EmptyLine()

        WriteYellow($"Autentication")
        Console.WriteLine(My.Settings.WindowsAuthentication)


        EmptyLine()

        Console.WriteLine("Done")

        Console.ReadLine()

    End Sub

End Module
