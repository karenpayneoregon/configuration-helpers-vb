Public Class Form1
    Private Async Sub KarenVersionButton_Click(sender As Object, e As EventArgs) _ 
        Handles KarenVersionButton.Click

        Dim contacts = Await ContactOperations.GetContactsAsync()

    End Sub

    Private Async Sub MohammadVersion_Click(sender As Object, e As EventArgs) _ 
        Handles MohammadVersionButton.Click

        Dim contacts = Await ContactOperations.GetContactsAsync1()
        
    End Sub
End Class
