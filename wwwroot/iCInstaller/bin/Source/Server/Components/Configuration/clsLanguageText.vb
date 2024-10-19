
Public Class clsLanguageText

    Public Function Find(ByVal myList As ArrayList, ByVal myPhrase As String) As String
        Dim i As Integer
        For i = 0 To myList.Count - 1
            If CType(myList(i).Phrase, String) = myPhrase Then
                Return myList(i).Text
            End If
        Next
        Return String.Empty
    End Function

    Public Function GetLanguageTextByLocation(ByVal lng_id As Integer, ByVal Location As String) As Object
        Try
            Dim oDO As New iCDataManager.iCDataObject
            Dim oCrypto As New clsCrypto
            Dim ED As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
            Dim EC As String = oCrypto.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
            Dim dsLang As New DataSet
            Dim sError As String
            Dim al As New ArrayList
            Dim oDefine As New clsDefinedDataList
            oDefine.AddDefinedTableColumn("lgt_phrase")
            oDefine.AddDefinedTableColumn("lgt_text")
            If Not oDO.GetDefinedDataSet("lgt_languagetext", oDefine.DataSet, "lng_id = " & lng_id & " AND lgt_location = '" & Location & "' AND lgt_deleted = 0", "", sError, ED, EC, dsLang) Then

            End If
            Dim drLanguage As DataRow
            Dim oLanguageSettings As clsLanguageSettings
            For Each drLanguage In dsLang.Tables("lgt_languagetext").Rows
                oLanguageSettings = New clsLanguageSettings
                oLanguageSettings.Phrase = drLanguage("lgt_phrase")
                oLanguageSettings.Text = drLanguage("lgt_text")
                al.Add(oLanguageSettings)
            Next
            Return al
        Catch ex As Exception
            Return New ArrayList
        End Try
    End Function

End Class
