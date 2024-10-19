Imports System.IO
Imports System.CodeDom.Compiler


Namespace Wrapper995ws


Public Class Wrapper

    Private _SourceFile As FileInfo
    Private _TempFile As FileInfo
    Private _PdfFile As FileInfo
    Private _DestinationFile As FileInfo
    Private _DestinationDir As DirectoryInfo
    Private _TempDir As DirectoryInfo
    Private _TotalWaitTime As Integer = 60000
    Private _WaitForExit As Boolean
    Private _SourceUrl As String

    Public Sub New()

    End Sub

    Public Function ConvertToPDF(ByVal SourceFile As String, ByVal DestinationDir As String) As Boolean
        Try
            _SourceFile = New FileInfo(SourceFile)
            _DestinationDir = New DirectoryInfo(DestinationDir)
            _WaitForExit = False
            Return _ConvertToPDF()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ConvertToPDF(ByVal SourceFile As String) As Boolean
        Try
            _SourceFile = New FileInfo(SourceFile)
            _DestinationDir = Nothing
            _WaitForExit = False
            Return _ConvertToPDF()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ConvertToPDF(ByVal SourceFile As String, ByVal WaitForExit As Boolean, Optional ByVal TotalWaitTime As Integer = 60000) As Boolean
        Try
            _SourceFile = New FileInfo(SourceFile)
            _DestinationDir = Nothing
            _TotalWaitTime = TotalWaitTime
            _WaitForExit = WaitForExit
            Return _ConvertToPDF()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CreatePdfFromURL(ByVal SourceURL As String, ByVal DestinationFile As String) As Boolean
        Try
            _SourceUrl = SourceURL
            _DestinationFile = New FileInfo(DestinationFile)
            _WaitForExit = False
            Return _CreatePdfFromURL()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CreatePdfFromURL(ByVal SourceURL As String, ByVal DestinationFile As String, ByVal WaitForExit As Boolean, Optional ByVal TotalWaitTime As Integer = 60000) As Boolean
        Try
            _SourceUrl = SourceURL
            _DestinationFile = New FileInfo(DestinationFile)
            _WaitForExit = WaitForExit
            _TotalWaitTime = TotalWaitTime
            Return _CreatePdfFromURL()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _ConvertToPDF() As Boolean
        Try
            Call CreateTemporaryDirectory()
            Call CopySourceFileToTemporaryDirectory()
            Call ExecuteOmniformat()
            If _WaitForExit Then
                Call WaitForTempFileToBeConverted()
                Call CopyTempFileToDestinationDirectory()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _CreatePdfFromURL() As Boolean
        Try
            Call ExecuteOmniformatUrl()
            If _WaitForExit Then
                Call WaitForUrlToBeConverted()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub CreateTemporaryDirectory()
        Try
            If Not IsNothing(_DestinationDir) Then
                Dim tfColl As New TempFileCollection
                _TempDir = New DirectoryInfo(tfColl.BasePath)
                _TempDir.Create()
            Else
                _TempDir = _SourceFile.Directory
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CopySourceFileToTemporaryDirectory()
        Try
            If Not IsNothing(_DestinationDir) Then
                _TempFile = _SourceFile.CopyTo(_TempDir.FullName & "\" & _SourceFile.Name, True)
            Else
                _TempFile = _SourceFile
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExecuteOmniformat()
        Try
            Dim proc As New System.Diagnostics.Process
            Dim info As New System.Diagnostics.ProcessStartInfo
            info.FileName = "c:\omniformat\omniformat.exe"
            info.Arguments = _TempFile.FullName
                System.Diagnostics.Process.Start(info)
            If Not proc.HasExited Then
                proc.WaitForExit()
                proc.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExecuteOmniformatUrl()
        Try
            Dim proc As New System.Diagnostics.Process
            Dim info As New System.Diagnostics.ProcessStartInfo
            info.FileName = "c:\omniformat\html2pdf995.exe"
            info.Arguments = """" & _SourceUrl & """ """ & _DestinationFile.FullName & """"
                System.Diagnostics.Process.Start(info)
            If Not proc.HasExited Then
                proc.WaitForExit()
                proc.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WaitForTempFileToBeConverted()
        Try
            Dim Done As Boolean
            Dim ExitTime As Date = Now.AddMilliseconds(_TotalWaitTime)
            Do Until ExitTime < Now Or Done
                    System.Threading.Thread.Sleep(100)
                _PdfFile = New System.IO.FileInfo(_TempFile.FullName.Substring(0, _TempFile.FullName.Length - 4) & ".pdf")
                Done = _PdfFile.Exists
            Loop
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WaitForUrlToBeConverted()
        Try
            Dim Done As Boolean
            Dim ExitTime As Date = Now.AddMilliseconds(_TotalWaitTime)
            Do Until ExitTime < Now Or Done
                    System.Threading.Thread.Sleep(100)
                _PdfFile = New System.IO.FileInfo(_DestinationFile.FullName)
                Done = _PdfFile.Exists
            Loop
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyTempFileToDestinationDirectory()
        Try
            If Not _DestinationDir.Exists Then _DestinationDir.Create()
            _PdfFile.CopyTo(_DestinationDir.FullName & "\" & _PdfFile.Name, True)
            _TempDir.Delete(True)
        Catch ex As Exception

        End Try
    End Sub
End Class

End Namespace
