Imports Microsoft.EntityFrameworkCore

Imports NorthWindLibrary.Models

Namespace Context
    Partial Public Class NorthWindContext
        Inherits DbContext

        Public Sub New()

        End Sub
        Public Sub New(options As DbContextOptions(Of NorthWindContext))
            MyBase.New(options)
        End Sub
        Public Overridable Property Customers() As DbSet(Of Customer)

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            If Not optionsBuilder.IsConfigured Then
                optionsBuilder.UseSqlServer(Helper.ConnectionString())
            End If
        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.ApplyConfiguration(New CustomerConfiguration())

            OnModelCreatingPartial(modelBuilder)
        End Sub
        Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
        End Sub

    End Class
End Namespace