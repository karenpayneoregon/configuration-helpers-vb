Option Infer On

Imports System.Drawing

Public Module ConsoleColors
    Public Sub WriteHeader(message As String)
        Dim item = New ConsoleRectangle(message, 100, 1, New Point(0, 0))
        item.Draw()
    End Sub
    Public Sub WriteYellow(message As String, Optional line As Boolean = True)

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub

    Public Sub WriteYellow(message As String, value As Integer)

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(message)
        Console.ResetColor()
        Console.Write(value)

    End Sub

    Public Sub WriteWhite(message As String, Optional line As Boolean = True)

        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteRed(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteMagenta(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteGreen(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteGray(ByVal message As String, Optional ByVal line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkYellow(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkRed(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkMagenta(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkGreen(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkDarkGreen(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkCyan(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkCyan
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteDarkBlue(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteCyan(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteBlue(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub WriteBlack(message As String, Optional line As Boolean = True)
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine(message)
        Console.ResetColor()
        AddDashLine(line)
    End Sub
    Public Sub PressAnyKey(Optional message As String = "Press any key to exit")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(message)
        Console.ResetColor()
    End Sub

    Public Sub WriteIndented(message As String)
        Console.WriteLine($"{vbTab}{message}")
    End Sub
    Public Sub WriteIndented(value As Integer)
        Console.WriteLine($"{vbTab}{value}")
    End Sub
    Public Sub WriteIndented(ByVal value As Decimal)
        Console.WriteLine($"{vbTab}{value}")
    End Sub
    Public Sub WriteIndented(value As Double)
        Console.WriteLine($"{vbTab}{value}")
    End Sub
    Public Sub WriteIndented(message As Boolean)
        Console.WriteLine($"{vbTab}{message}")
    End Sub
    Public Sub EmptyLine()
        Console.WriteLine("")
    End Sub
    Private Sub AddDashLine(line As Boolean)
        If line Then
            Console.WriteLine(New String("-"c, 100))
        End If
    End Sub

End Module