Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.VisualBasic

Public Class ApplicationConfiguration
    Private Shared ReadOnly _hasher As String = "P@@Sw0rd"
    Private Shared ReadOnly _saltPepper As String = "S@LT&KEY"
    Private Shared ReadOnly _mainKeyer As String = "@1B2c3D4e5F6g7H8"
    Public Shared Function Writer(plainText As String) As String
        Dim plainTextBytes() As Byte = Encoding.UTF8.GetBytes(plainText)

        Dim keyBytes() As Byte = (New Rfc2898DeriveBytes(_hasher, Encoding.ASCII.GetBytes(_saltPepper))).GetBytes(256 \ 8)

        Dim symmetricKey = New RijndaelManaged() With {
                .Mode = CipherMode.CBC,
                .Padding = PaddingMode.Zeros
                }

        Dim encryption = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(_mainKeyer))

        Dim cipherTextBytes() As Byte

        Using memoryStream As New MemoryStream()
            Using cryptoStream As New CryptoStream(memoryStream, encryption, CryptoStreamMode.Write)
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
                cryptoStream.FlushFinalBlock()
                cipherTextBytes = memoryStream.ToArray()
                cryptoStream.Close()
            End Using
            memoryStream.Close()
        End Using
        Return Convert.ToBase64String(cipherTextBytes)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="encryptedText"></param>
    ''' <returns></returns>
    Public Shared Function Reader(encryptedText As String) As String
        Dim cipherTextBytes() As Byte = Convert.FromBase64String(encryptedText)
        Dim keyBytes() As Byte = (New Rfc2898DeriveBytes(_hasher, Encoding.ASCII.GetBytes(_saltPepper))).GetBytes(256 \ 8)

        Dim symmetricKey = New RijndaelManaged() With {
                .Mode = CipherMode.CBC,
                .Padding = PaddingMode.None
                }

        Dim decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(_mainKeyer))

        Dim memoryStream As New MemoryStream(cipherTextBytes)
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

        Dim plainTextBytes(cipherTextBytes.Length - 1) As Byte

        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

        memoryStream.Close()
        cryptoStream.Close()

        Return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd(vbNullChar.ToCharArray())

    End Function
End Class