Imports System.Security.Cryptography
Imports System.Text

Namespace Security

    Public Class clsCrypto

        ' System.Security.Cryptography.Rijndael symmetric encryption algorithm
        Private CRYPTO_KEY As Byte() = {&H15, &H2, &H3, &H44, &H5, &H6, &HF7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
        Private CRYPTO_IV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

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

        Public Function Decrypt(ByVal base64String As String) As String
            Try
                Dim RMCrypto As New RijndaelManaged
                Dim dec As ICryptoTransform = RMCrypto.CreateDecryptor(CRYPTO_KEY, CRYPTO_IV)
                Dim ByteArr() As Byte = Convert.FromBase64String(base64String)
                Return Encoding.UTF8.GetString(dec.TransformFinalBlock(ByteArr, 0, ByteArr.GetLength(0)))
            Catch
                Return "Decrypt - " & Err.Description
            End Try
        End Function

        'Public Function EncryptToByteString(ByVal Value As String) As String
        '    Try
        '        Dim RMCrypto As New RijndaelManaged
        '        Dim ByteArray() As Byte = Encoding.UTF8.GetBytes(Value)
        '        Dim enc As ICryptoTransform = RMCrypto.CreateEncryptor(CRYPTO_KEY, CRYPTO_IV)
        '        Dim ByteArr() As Byte = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0))
        '        Dim ByteString As String
        '        For i As Integer = LBound(ByteArr) To UBound(ByteArr)
        '            ByteString += ByteArr(i) & "|"
        '        Next
        '        If ByteString.Length > 0 Then ByteString = ByteString.Substring(0, ByteString.Length - 1)
        '        Return ByteString
        '    Catch
        '        Return "The connection failed."
        '    End Try
        'End Function

        'Public Function Decrypts(ByVal base64String As String) As String
        '    Try
        '        Dim RMCrypto As New RijndaelManaged
        '        Dim dec As ICryptoTransform = RMCrypto.CreateDecryptor(CRYPTO_KEY, CRYPTO_IV)
        '        'Dim ByteArr() As Byte = CType(Split(base64String, "|"), Byte()) 'Convert.FromBase64String(base64String)
        '        Return Encoding.UTF8.GetString(dec.TransformFinalBlock(ByteArr, 0, ByteArr.GetLength(0)))
        '    Catch
        '        Return "Decrypt - " & Err.Description
        '    End Try
        'End Function

    End Class

End Namespace