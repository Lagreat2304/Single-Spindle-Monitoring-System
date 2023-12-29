Option Explicit On

#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
#End Region

Module ModuleSecurity

    Public Function Encryption(ByVal mvarPlanText As String, ByVal ipassPhrase As String) As String
        Dim cipherText As String = ""
        Try
            Dim passPhrase As String = ipassPhrase
            Dim saltValue As String = "APL2005"
            Dim hashAlgorithm As String = "SHA1"
            Dim initVector As String = "@a1B2c3D4e5F6g7H8"
            Dim passwordIterations As Integer = 2
            Dim keySize As Integer = 256

            Dim initVectorBytes() As Byte = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes() As Byte = Encoding.ASCII.GetBytes(saltValue)
            Dim plainTextBytes() As Byte = Encoding.UTF8.GetBytes(mvarPlanText)

            Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
            cryptoStream.FlushFinalBlock()

            Dim cipherTextBytes() As Byte = memoryStream.ToArray()
            memoryStream.Close()
            cryptoStream.Close()
            cipherText = Convert.ToBase64String(cipherTextBytes)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return cipherText
    End Function
    Public Function Decryption(ByVal cipherText As String, ByVal ipassPhrase As String) As String
        Dim plainText As String = ""
        Try
            Dim passPhrase As String = ipassPhrase
            Dim saltValue As String = "APL2005"
            Dim hashAlgorithm As String = "SHA1"
            Dim initVector As String = "@a1B2c3D4e5F6g7H8"
            Dim passwordIterations As Integer = 2
            Dim keySize As Integer = 256

            Dim initVectorBytes() As Byte = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes() As Byte = Encoding.ASCII.GetBytes(saltValue)
            Dim ciperTextBytes() As Byte = Convert.FromBase64String(cipherText)

            Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()

            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
            Dim memoryStream As MemoryStream = New MemoryStream(ciperTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

            Dim plainTextBytes(ciperTextBytes.Length - 1) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return plainText
    End Function
End Module
