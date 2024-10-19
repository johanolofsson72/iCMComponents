Namespace Data

    Public Class clsMultiQueryListSP

        Public DataSet As DataSet
        Dim DataTable As DataTable

        Sub New()
            DataSet = New DataSet("MultiQueryList")
            DataTable = New DataTable("MultiQueryListTable")
            Call AddColumn()
        End Sub

        Sub New(ByVal sDataSetName As String)
            DataSet = New DataSet(sDataSetName)
            DataTable = New DataTable("MultiQueryListTable")
            Call AddColumn()
        End Sub

        Sub New(ByVal sDataSetName As String, ByVal sDataTableName As String)
            DataSet = New DataSet(sDataSetName)
            DataTable = New DataTable(sDataTableName)
            Call AddColumn()
        End Sub

        Private Sub AddColumn()
            Dim dc As DataColumn
            dc = New DataColumn("Key", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("Query", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            DataSet.Tables.Add(DataTable)
        End Sub

        Public Function AddQuery(ByVal Key As String, ByVal Query As String) As Boolean
            Try
                Dim dr As DataRow
                dr = Me.DataSet.Tables(0).NewRow
                dr("Key") = Key
                dr("Query") = Query
                Me.DataSet.Tables(0).Rows.Add(dr)
                Return True
            Catch
                Return False
            End Try
        End Function

    End Class

End Namespace
