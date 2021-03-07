Imports System.IO
Imports ConfigurationHelper
Imports Microsoft.EntityFrameworkCore
Imports NorthWindLibrary.Models

Namespace Context
    ''' <summary>
    ''' Code sample for logging to a file
    ''' </summary>
    Public Class NorthWindContextLogging
        Inherits DbContext
        Implements IAsyncDisposable, IDisposable

        Public Sub New()

        End Sub
        Public Sub New(options As DbContextOptions(Of NorthWindContext))
            MyBase.New(options)
        End Sub
        Public Overridable Property Customers() As DbSet(Of Customer)

        Private ReadOnly _logStream As New StreamWriter("ef-log.txt", append:= True)

        Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
            If Not optionsBuilder.IsConfigured Then

                optionsBuilder.UseSqlServer(Helper.ConnectionString()).
                    EnableSensitiveDataLogging().
                    EnableDetailedErrors().
                    LogTo(Sub(x) _logStream.WriteLine(x))
            End If
        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.ApplyConfiguration(New CustomerConfiguration())

            OnModelCreatingPartial(modelBuilder)
        End Sub
        Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
        End Sub
        Public Overrides Sub Dispose()
            MyBase.Dispose()
            _logStream.Dispose()
        End Sub
        ''' <summary>
        ''' The public parameter-less DisposeAsync() method is called implicitly in an await using statement,
        ''' and its purpose is to free unmanaged resources, perform general cleanup, and to indicate that the
        ''' finalizer, if one is present, need not run. Freeing the memory associated with a managed object is
        ''' always the domain of the garbage collector.
        ''' </summary>
        ''' <returns></returns>
        Protected Overridable Async Function DisposeAsyncCore() As Task(Of ValueTask)
            Await _logStream.DisposeAsync()
            Return DisposeAsync()
        End Function
    End Class
End NameSpace