Imports System.Web.UI.Page
Imports System.Web
Imports System
Imports System.Drawing
Imports iConsulting
Imports System.Collections

Public Class clsImage

    Private oDO As New iCDataManager.iCDataObject
    Private oCrypto As New iConsulting.iCMServer.clsCrypto
    Private ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Private EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
    Private oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

    Public Function GetImage(ByVal DocId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            If Not oDO.GetDataSet("doc_documents", "sit_id = " & oSite.SiteId & " AND doc_id = " & DocId, "", "", ED, EC, ds) Then

            End If
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds
                Else
                    Return New DataSet
                End If
            Else
                Return New DataSet
            End If
        Catch ex As Exception
            Return New DataSet
        End Try
    End Function

End Class
