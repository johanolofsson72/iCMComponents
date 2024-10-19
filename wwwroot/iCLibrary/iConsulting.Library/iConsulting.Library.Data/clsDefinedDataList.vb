Namespace Data

    Public Class clsDefinedDataList

        Public DataSet As DataSet
        Dim DataTable As DataTable

        Sub New()
            DataSet = New DataSet("DefinedDataList")
            DataTable = New DataTable("DefinedDataListTable")
            Call AddColumn()
        End Sub

        Sub New(ByVal sDataSetName As String)
            DataSet = New DataSet(sDataSetName)
            DataTable = New DataTable("DefinedDataListTable")
            Call AddColumn()
        End Sub

        Sub New(ByVal sDataSetName As String, ByVal sDataTableName As String)
            DataSet = New DataSet(sDataSetName)
            DataTable = New DataTable(sDataTableName)
            Call AddColumn()
        End Sub

        Private Sub AddColumn()
            Dim dc As DataColumn
            dc = New DataColumn("ColumnName", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            DataSet.Tables.Add(DataTable)
        End Sub

        Public Function AddDefinedTableColumn(ByVal ColumnName As String) As Boolean
            Try
                Dim dr As DataRow
                dr = Me.DataSet.Tables(0).NewRow
                dr("ColumnName") = ColumnName
                Me.DataSet.Tables(0).Rows.Add(dr)
                Return True
            Catch
                Return False
            End Try
        End Function

    End Class

End Namespace
