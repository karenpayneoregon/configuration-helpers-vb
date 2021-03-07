
Imports System.Configuration
Imports Contexts.Configurations
Imports Microsoft.EntityFrameworkCore
Imports Models

Namespace Contexts
    Partial Public Class NorthWindContext
        Inherits DbContext

        Private _connectionString As String

        Public Sub New()

        End Sub

        Public Sub New(options As DbContextOptions(Of NorthWindContext))
            MyBase.New(options)
        End Sub

        Public Overridable Property ContactType() As DbSet(Of ContactType)
        Public Overridable Property Contacts() As DbSet(Of Contacts)

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            If Not optionsBuilder.IsConfigured Then
                Dim configurationHelper = New ConfigurationHelper
                _connectionString = configurationHelper.ConnectionString

                If Not optionsBuilder.IsConfigured Then
                    optionsBuilder.UseSqlServer(_connectionString)
                End If

            End If
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)

            modelBuilder.ApplyConfiguration(New ContactTypeConfiguration())
            modelBuilder.ApplyConfiguration(New ContactsConfiguration())

            OnModelCreatingPartial(modelBuilder)

        End Sub

        Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
        End Sub
    End Class
End Namespace
