Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class clsThumbnail

    Private _bStream As Byte()
    Private _bmpSource As Bitmap
    Private _bmpThumb As Bitmap
    Private _MaxHeight As Integer
    Private _MaxWidth As Integer
    Private _Height As Integer
    Private _Width As Integer

    Public ReadOnly Property GetThumbHeight() As Integer
        Get
            Return Me._Height
        End Get
    End Property

    Public ReadOnly Property GetThumbWidth() As Integer
        Get
            Return Me._Width
        End Get
    End Property

    Public Sub New(ByVal MaxHeight As Integer, ByVal MaxWidth As Integer, ByVal bSource As Bitmap)
        Me._MaxHeight = MaxHeight
        Me._MaxWidth = MaxWidth
        Me._bmpSource = bSource
        Call Calculate()
    End Sub

    Public Sub New(ByVal MaxHeight As Integer, ByVal MaxWidth As Integer, ByVal bStream As Byte())
        Me._MaxHeight = MaxHeight
        Me._MaxWidth = MaxWidth
        Me._bStream = bStream
        Me._bmpSource = New Bitmap(New MemoryStream(Me._bStream, 0, Me._bStream.Length))
        Call Calculate()
    End Sub

    Public Function GetThumbnail() As Byte()
        Try
            Dim mS As MemoryStream = New MemoryStream
            Me._bmpThumb = New Bitmap(Me._bmpSource.GetThumbnailImage(Me._Width, Me._Height, Nothing, Nothing))
            Me._bmpThumb.Save(mS, Me._bmpThumb.RawFormat.Png)
            Return mS.ToArray
        Catch ex As Exception
            Return Me._bStream
        End Try
    End Function

    Private Sub Calculate()
        If Me._bmpSource.Height < Me._MaxHeight And Me._bmpSource.Width < Me._MaxWidth Then
            Me._Height = Me._bmpSource.Height
            Me._Width = Me._bmpSource.Width
        Else
            Dim _HeightRatio As Integer = Me._bmpSource.Height / Me._MaxHeight
            Dim _WidthRatio As Integer = Me._bmpSource.Width / Me._MaxWidth
            If _WidthRatio > _HeightRatio Then
                Me._Height = Me._bmpSource.Height / _WidthRatio
                Me._Width = Me._bmpSource.Width / _WidthRatio
            Else
                Me._Height = Me._bmpSource.Height / _HeightRatio
                Me._Width = Me._bmpSource.Width / _HeightRatio
            End If
        End If
    End Sub

End Class
