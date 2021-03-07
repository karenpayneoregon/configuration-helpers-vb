Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports Contexts
Imports Microsoft.EntityFrameworkCore
Imports Models

Public Class ContactOperations
    Public Shared Async Function GetContactsAsync() As Task(Of List(Of Contacts))
        Return Await Task.Run(Async Function()
                                  Using context = New NorthWindContext()
                                      Return Await context.Contacts.Include(Function(contact) contact.ContactTypeIdentifierNavigation).ToListAsync()
                                  End Using
                              End Function)
    End Function
    Public Shared Function GetContacts() As List(Of Contacts)
        Using context = New NorthWindContext()
            Return context.Contacts.Include(Function(contact) contact.ContactTypeIdentifierNavigation).ToList()
        End Using
    End Function
End Class