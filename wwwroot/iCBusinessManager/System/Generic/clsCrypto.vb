Imports System.Security.Cryptography
Imports System.Text

Public Class clsCrypto

    Public Function Encrypt(ByVal Value As String) As String
        Try
            Dim RMCrypto As New RijndaelManaged
            Dim ByteArray() As Byte = Encoding.UTF8.GetBytes(Value)
            Dim enc As ICryptoTransform = RMCrypto.CreateEncryptor(CRYPTO_KEY, CRYPTO_IV)
            Dim ByteArr() As Byte = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0))
            Return Convert.ToBase64String(ByteArr)
        Catch
            Return "The connection failed."
        End Try
    End Function

End Class
