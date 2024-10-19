Imports System.IO
Imports System.Net
Imports System
Imports System.Text
Imports System.Text.RegularExpressions

Public Class clsHttpRequest

    Public Function GetDataAsXML(ByVal Url As String) As DataSet
        Dim sStream As Stream
        Dim URLReq As HttpWebRequest
        Dim URLRes As HttpWebResponse
        Try
            URLReq = WebRequest.Create(Url)
            URLRes = URLReq.GetResponse()
            sStream = URLRes.GetResponseStream()
            Dim ds As New DataSet
            Dim o As Object
            o = ds.ReadXml(sStream, XmlReadMode.Auto)
            Return ds
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

    Public Function HttpTrigger(ByVal Url As String) As Boolean
        Dim URLReq As HttpWebRequest
        Dim URLRes As HttpWebResponse
        Try
            URLReq = WebRequest.Create(Url)
            If URLReq.HaveResponse Then
                URLRes = URLReq.GetResponse()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
