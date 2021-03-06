''' <summary>
''' Provides timeout to ReadLine for Console projects
''' </summary>
Public Module ConsoleWaiter
    ''' <summary>
    ''' Wait for timeout or user presses a key
    ''' </summary>
    ''' <param name="timeout">TimeSpan</param>
    ''' <returns></returns>
    Public Function ReadLineWithTimeout(timeout As TimeSpan) As String

        Dim task As Task(Of String) = Threading.Tasks.Task.Factory.StartNew(AddressOf Console.ReadLine)

        Dim result = If(Threading.Tasks.Task.WaitAny(New Task() {task}, timeout) = 0, task.Result, String.Empty)

        Return result

    End Function

    Public Function ReadLineWithTimeout() As String
        Dim time = TimeSpan.FromSeconds(5)
        Return ReadLineWithTimeout(time)
    End Function
    Public Function ReadLineWithTimeoutAndMessage() As String
        EmptyLine()
        PressAnyKey()
        Dim time = TimeSpan.FromSeconds(5)
        Return ReadLineWithTimeout(time)
    End Function
End Module
