Public Class clsUser
    Dim oDO As New iCDataManager.iCDataObject
    Dim oCrypto As New clsCrypto
    Dim ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
    Dim EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))

    Public Function GetRoles(ByVal email As String) As String
        Dim dsUserRoles As New DataSet
        Dim dsUsers As New DataSet
        Dim dsRoles As New DataSet
        Dim sError As String
        Dim UserId As Integer
        Dim sWhere As String = " "
        Dim i As Integer
        Dim UserRoles As String
        Dim oDefine As New clsDefinedDataList
        oDefine.AddDefinedTableColumn("usr_id")
        If Not oDO.GetDefinedDataSet("usr_users", oDefine.DataSet, "usr_email = '" & email & "' AND usr_deleted = 0", "", sError, ED, EC, dsUsers) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        UserId = dsUsers.Tables(0).Rows(0)("usr_id")
        oDefine = New clsDefinedDataList
        oDefine.AddDefinedTableColumn("rol_id")
        If Not oDO.GetDefinedDataSet("uro_userroles", oDefine.DataSet, "usr_id = " & UserId & " AND uro_deleted = 0", "", sError, ED, EC, dsUserRoles) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        If dsUserRoles.Tables.Count > 0 Then
            If dsUserRoles.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsUserRoles.Tables(0).Rows.Count - 1
                    sWhere += dsUserRoles.Tables(0).Rows(i)("rol_id") & " OR rol_id = "
                Next
                sWhere = Left(sWhere, Len(sWhere) - 13)
                oDefine = New clsDefinedDataList
                oDefine.AddDefinedTableColumn("rol_name")
                If Not oDO.GetDefinedDataSet("rol_roles", oDefine.DataSet, "rol_id = " & sWhere & " AND rol_deleted = 0", "", sError, ED, EC, dsRoles) Then
                    System.Diagnostics.Debug.WriteLine(sError)
                End If
                For i = 0 To dsRoles.Tables(0).Rows.Count - 1
                    UserRoles += dsRoles.Tables(0).Rows(i)("rol_name") & ";"
                Next
                Return UserRoles 'Left(UserRoles, Len(UserRoles) - 1)
            End If
            Return String.Empty
        End If
        Return String.Empty
    End Function

End Class
