Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Namespace Binary

    Public Class Cache : Inherits Folder

        Public ReadOnly Property Item() As Item
            Get
                Return New Item(MyBase.Folder)
            End Get
        End Property

        'Public ReadOnly Property Item(ByVal UniqueId As String) As Items
        '    Get
        '        Return New Items(UniqueId)
        '    End Get
        'End Property

        Public Sub New(ByVal Folder As String)
            MyBase.New(Folder)
        End Sub

    End Class

    Public MustInherit Class Folder

        Private _Folder As String

        Public Property Folder() As String
            Get
                Return Me._Folder
            End Get
            Set(ByVal Value As String)
                Me._Folder = Value
            End Set
        End Property

        Sub New(ByVal Folder As String)
            Me._Folder = Folder
        End Sub

    End Class

    Public Class Item

        Private _Folder As String

        Sub New(ByVal Folder As String)
            Me._Folder = Folder
        End Sub

        Public Function GetItem(ByVal UniqueId As String) As String
            Try
                Dim MyFolder As New System.IO.DirectoryInfo(Me._Folder)
                If Not MyFolder.Exists Then Throw New Exception
                For Each f As System.IO.FileInfo In MyFolder.GetFiles
                    If f.Name.Substring(0, f.Name.LastIndexOf(".")).ToLower = UniqueId.ToLower Then
                        Return f.Name
                    End If
                Next
                Return String.Empty
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

        Public Function Add(ByVal UniqueId As String, ByVal PostedFile As System.Web.HttpPostedFile) As Boolean
            Try
                Dim MyFolder As New System.IO.DirectoryInfo(Me._Folder)
                If Not MyFolder.Exists Then Throw New Exception
                PostedFile.SaveAs(MyFolder.FullName & "\" & UniqueId)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function Add(ByVal UniqueId As String, ByVal PostedFile As System.Web.HttpPostedFile, ByVal FileExtension As String) As Boolean
            Try
                Dim MyFolder As New System.IO.DirectoryInfo(Me._Folder)
                If Not MyFolder.Exists Then Throw New Exception
                PostedFile.SaveAs(MyFolder.FullName & "\" & UniqueId & FileExtension)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function AddThumb(ByVal ThumbFolder As String, ByVal UniqueId As String, ByVal SourceFile As String, ByVal ThumbWidth As Integer, ByVal ThumbHeight As Integer) As Boolean
            Try
                Dim Fso As New Scripting.FileSystemObject
                If Not Fso.FolderExists(Me._Folder & "\" & ThumbFolder) Then Throw New Exception
                Dim t As New iConsulting.Library.Image.clsThumbnail(ThumbHeight, ThumbWidth, New Bitmap(Me._Folder & "\" & SourceFile))
                Dim b As New Bitmap(New MemoryStream(t.GetThumbnail))
                b.Save(Me._Folder & "\" & ThumbFolder & "\" & UniqueId, Imaging.ImageFormat.Jpeg)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class

    Public Class Items

        Private _Item As String
        Private _UniqueId As String
        Private _Value As String
        Private _Folder As String
        Private _Type As String

        Public ReadOnly Property Value(ByVal Type As String) As String
            Get
                Me._Type = Type
                Return Me._GetValue
            End Get
        End Property

        Sub New(ByVal UniqueId As String)
            Me._UniqueId = UniqueId
            Me._Value = "" ' Hämta en sökväg till dokumentet baserat på UniqueId
        End Sub

        Private Function _GetValue() As String
            Try
                Select Case Me._Type.ToLower
                    Case "gif", "png", "jpg"
                        Return Me._Value
                    Case Else
                        Return String.Empty
                End Select
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

    End Class

End Namespace
