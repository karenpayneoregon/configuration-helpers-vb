Imports System.Drawing

Public Class ConsoleRectangle
	Private _hLocation As Point

	Private ReadOnly _text As String

	Public Sub New(text As String, width As Integer, height As Integer, location As Point, Optional borderColor As ConsoleColor = ConsoleColor.Blue, Optional ByVal backColor As ConsoleColor = ConsoleColor.Blue, Optional ByVal foreBackgroundColor As ConsoleColor = ConsoleColor.White)

		Me.Width = width
		Me.Height = height

		_hLocation = location

		Me.BorderColor = borderColor

		BackgroundColor = backColor
		ForegroundColor = foreBackgroundColor

		_text = text

	End Sub

	Public Property Location() As Point
		Get
			Return _hLocation
		End Get
		Set
			_hLocation = Value
		End Set
	End Property

	Public Property Width() As Integer
	Public Property Height() As Integer
	Public Property BorderColor() As ConsoleColor
	Public Property BackgroundColor() As ConsoleColor
	Public Property ForegroundColor() As ConsoleColor

	Public Sub Draw()
		Dim border As String = "╔"
		Dim space As String = ""
		Dim temp As String = ""

		For index As Integer = 0 To Width - 1
			space &= " "
			border &= "═"
		Next index

		For j As Integer = 0 To Location.X - 1
			temp &= " "
		Next j

		border &= "╗" & vbLf

		For index As Integer = 0 To Height - 1
			border &= temp & "║" & space & "║" & vbLf
		Next index

		border &= temp & "╚"

		For index As Integer = 0 To Width - 1
			border &= "═"
		Next index

		border &= "╝" & vbLf

		Console.BackgroundColor = BackgroundColor
		Console.CursorTop = _hLocation.Y
		Console.CursorLeft = _hLocation.X
		Console.Write(border)
		Console.ResetColor()
		Console.CursorTop = 1
		Console.CursorLeft = 3

		Console.BackgroundColor = BorderColor
		Console.ForegroundColor = ForegroundColor
		Console.WriteLine(_text)
		Console.ResetColor()

		Console.CursorTop = 4
		Console.CursorLeft = 0

	End Sub
End Class
