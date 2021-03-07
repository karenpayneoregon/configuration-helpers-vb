Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.CompilerServices
Imports NorthWindLibrary.Classes.BaseClasses

Namespace Classes

    Public Class CustomerEntity
        Inherits BaseEntity
        Implements INotifyPropertyChanged

        Private _customerIdentifier As Integer
        Private _companyName As String
        Private _contactIdentifier? As Integer

        Public Property CustomerIdentifier() As Integer
            Get
                Return _customerIdentifier
            End Get
            Set
                _customerIdentifier = value
                OnPropertyChanged()
            End Set
        End Property
        <Required>
        Public Property CompanyName() As String
            Get
                Return _companyName
            End Get
            Set
                _companyName = value
                OnPropertyChanged()
            End Set
        End Property
        Public Property ContactIdentifier() As Integer?
            Get
                Return _contactIdentifier
            End Get
            Set
                _contactIdentifier = value
                OnPropertyChanged()
            End Set
        End Property


        Public Overrides Function ToString() As String
            Return CustomerIdentifier.ToString()
        End Function

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional ByVal propertyName As String = Nothing)
            PropertyChangedEvent?.Invoke(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

    End Class
End NameSpace