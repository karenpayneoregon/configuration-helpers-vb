Module Program
    Sub Main(args As String())

        Dim tester As New Test()

        DoesObjectImplementITestInterface(tester)

        Console.WriteLine($"Length of the string entered = {tester.Length("Hello")}")
        tester.Check()

        Console.ReadLine()

    End Sub
    Sub DoesObjectImplementITestInterface(sender As Object)

        If TypeOf sender Is ITestInterface Then
            Console.ForegroundColor = ConsoleColor.Yellow
            CType(sender, ITestInterface).Details(55, "Some name")
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("No")
        End If

        Console.ResetColor()

    End Sub
End Module
Module Module1
    Interface ITestInterface
        Function Length(value As String) As Integer
        Sub Details(age As Integer, ByVal name As String)
    End Interface
End Module
Class Test
    Implements ITestInterface

    Public Sub Details(age As Integer, name As String) Implements ITestInterface.Details
        Console.WriteLine($"Age of person = {age}")
        Console.WriteLine($"Name of person = {name}")
    End Sub

    Public Function Length(value As String) As Integer Implements ITestInterface.Length
        Console.WriteLine($"Original String: {value}")
        Return value.Length()
    End Function

    Sub Check()
        Console.WriteLine("The sub can be accessed")
    End Sub

End Class


