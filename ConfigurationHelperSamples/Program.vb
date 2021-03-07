Imports System
Imports ConfigurationHelper
Imports ConfigurationHelper.Classes
Imports ConfigurationHelperSamples.Classes
Imports ConfigurationHelperSamples.Classes.Containers

Module Program
    Sub Main(args As String())

        DatabaseSettings()

        Console.WriteLine()

        EmailSettings()

        Console.ReadLine()
    End Sub
    Private Function GeneralSettings() As GeneralSettings
        Return Helper.Configuration()
    End Function
    Private Sub WriteSection(message As String)
        Dim originalForeColor = Console.ForegroundColor

        Console.ForegroundColor = ConsoleColor.Yellow

        Console.WriteLine(message)
        
        Console.ForegroundColor = originalForeColor
    End Sub
    Private Sub DatabaseSettings()

        WriteSection("Data connection string")
        Console.WriteLine($"Connection string: {GeneralSettings().DatabaseSettings.ConnectionString}")

    End Sub

    Private Sub EmailSettings()

        WriteSection("Email")
        Console.WriteLine($"PickupDirectoryLocation: {GeneralSettings().EmailSettings.PickupDirectoryLocation}")
        Console.WriteLine($"                   Host: {GeneralSettings().EmailSettings.Host}")
        Console.WriteLine($"                   Port: {GeneralSettings().EmailSettings.Port}")
        Console.WriteLine($"              EnableSsl: {GeneralSettings().EmailSettings.EnableSsl}")

    End Sub

End Module
