Public Class clsiCMServer

    Public SiteId As Integer
    Public SiteAlias As String
    Public SiteServer As String
    Public SiteDatabase As String
    Public SiteUserId As Integer
    Public SiteUser As String
    Public SitePassword As String

    Public Sub New()

    End Sub

    Public Function Logon(ByVal sServer As String, ByVal sDatabase As String, ByVal sType As String, ByVal sAlias As String, ByVal sDbUser As String, ByVal sDbPassword As String, ByVal sUser As String, ByVal sPassword As String) As Boolean
        Try
            Dim oCrypto As New clsCrypto
            Dim ED As String
            Dim EC As String
            Select Case LCase(sType)
                Case "mssqlserver"
                    ED = oCrypto.Encrypt("MSSQLServer")
                    EC = oCrypto.Encrypt("server=" & sServer & ";user=" & sDbUser & ";password=" & sDbPassword & ";database=" & sDatabase)
                Case "msaccess"
                    ED = ""
                    EC = ""
                Case "mysql"
                    ED = ""
                    EC = ""
            End Select
            Dim ds As New DataSet
            Dim oDO As New iCDataManager.iCDataObject
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("sit_id")
            If Not oDO.GetDefinedDataSet("sit_sites", oDefine.DataSet, "sit_alias = '" & sAlias & "' AND sit_deleted = 0", "", "", ED, EC, ds) Then
                Throw New Exception
            End If
            If Not ds.Tables(0).Rows.Count > 0 Then
                Throw New Exception
            End If
            Dim SitId As Integer = ds.Tables(0).Rows(0)("sit_id")
            ds = New DataSet
            oDefine = New clsDefinedDataList
            oDefine.AddDefinedTableColumn("usr_id")
            If Not oDO.GetDefinedDataSet("usr_users", oDefine.DataSet, "sit_id = " & SitId & " AND usr_email = '" & sUser & "' AND usr_password = '" & oCrypto.Encrypt(sPassword) & "' AND usr_deleted = 0", "", "", ED, EC, ds) Then
                Throw New Exception
            End If
            If Not ds.Tables(0).Rows.Count > 0 Then
                Throw New Exception
            End If
            ' om det går, go for it.....
            Me.SiteId = SitId
            Me.SiteAlias = sAlias
            Me.SiteDatabase = sDatabase
            Me.SiteUserId = ds.Tables(0).Rows(0)("usr_id")
            Me.SiteUser = sUser
            Me.SitePassword = sPassword
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
