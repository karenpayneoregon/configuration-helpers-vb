Imports System.Configuration

Module Module1

    Sub Main()

        WriteHeader("Custom app.setting code sample 2")

        Dim config = DirectCast(ConfigurationManager.GetSection("SettingsConfig"), SettingsConfig)

        WriteYellow($"Connection string")
        Console.WriteLine(config.ConnectionString)

        EmptyLine()

        WriteMagenta($"Use WindowsAuthentication")
        Console.WriteLine(config.WindowsAuthentication)

        EmptyLine()

        Console.WriteLine("Done")

        Console.ReadLine()

    End Sub
End Module