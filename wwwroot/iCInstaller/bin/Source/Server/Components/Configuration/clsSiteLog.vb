Imports System.Web.UI.Page

Public Class clsSiteLog

    Public Function LogUser() As Boolean
        Try
            Dim oSiteSettings As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oDO As New iCDataManager.iCDataObject
            Dim oCrypto As New clsCrypto
            Dim drDataRow As DataRow
            Dim ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
            Dim EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
            Dim dsLog As New DataSet
            Dim sError As String

            ' Get empty slg_sitelog
            If Not oDO.GetEmptyDataSet("slg_sitelog", sError, ED, EC, dsLog) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If

            With dsLog.Tables(0).Rows(0)
                .Item("sit_id") = oSiteSettings.SiteId
                .Item("slg_logdate") = Now
                .Item("slg_ip") = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
                .Item("slg_referrer") = HttpContext.Current.Request.ServerVariables("HTTP_REFERER")
                .Item("slg_url") = HttpContext.Current.Request.ServerVariables("URL")
                .Item("slg_useragent") = HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT")
                .Item("slg_hostaddress") = HttpContext.Current.Request.ServerVariables("REMOTE_HOST")
                .Item("slg_hostname") = HttpContext.Current.Request.ServerVariables("HTTP_HOST")
                .Item("slg_hidden") = 0
                .Item("slg_deleted") = 0
            End With

            ' Save slg_sitelog
            If Not oDO.SaveDataSet(sError, ED, EC, dsLog, False) Then
                System.Diagnostics.Debug.WriteLine(sError)
            End If

            Return True
        Catch
            Return False
        End Try
    End Function

End Class

