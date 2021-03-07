Module Module1
    Sub Main()
        WriteHeader("Entity Framework Core connection in app.config")
        EmptyLine()

        Dim contacts = ContactOperations.GetContacts()

        WriteCyan($"Contact count: {contacts.Count}", False)

        Console.ReadLine()
    End Sub

End Module
