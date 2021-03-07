Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Imports NorthWindLibrary.Models

Namespace Context
    Public Class CustomerConfiguration
        Implements IEntityTypeConfiguration(Of Customer)

        Public Sub Configure(entity As EntityTypeBuilder(Of Customer)) Implements IEntityTypeConfiguration(Of Customer).Configure
            entity.HasKey(Function(e) e.CustomerIdentifier).HasName("PK_Customers_1")
        End Sub
    End Class
End Namespace