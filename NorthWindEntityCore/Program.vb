Imports System

Module Program
    Sub Main(args As String())
        WriteHeader("Entity Framework Core connection in appsettings.json")
        EmptyLine()


        Dim contacts = ContactOperations.GetContacts()
        WriteYellow("Contact count: ", contacts.Count)


        Console.ReadLine()
    End Sub
End Module
