
Public Class clsGridColumnsList

    Public ColumnList As DataSet
    Dim DataTable As DataTable

    Sub New()
        ColumnList = New DataSet("GridColumnList")
        DataTable = New DataTable("GridColumnListTable")
        Call AddColumn()
    End Sub

    Sub New(ByVal sDataSetName As String)
        ColumnList = New DataSet(sDataSetName)
        DataTable = New DataTable("GridColumnListTable")
        Call AddColumn()
    End Sub

    Sub New(ByVal sDataSetName As String, ByVal sDataTableName As String)
        ColumnList = New DataSet(sDataSetName)
        DataTable = New DataTable(sDataTableName)
        Call AddColumn()
    End Sub

    Private Sub AddColumn()
        Dim dc As DataColumn
        dc = New DataColumn("Name", System.Type.GetType("System.String"))
        DataTable.Columns.Add(dc)
        dc = New DataColumn("Alias", System.Type.GetType("System.String"))
        DataTable.Columns.Add(dc)
        ColumnList.Tables.Add(DataTable)
    End Sub

    Public Function AddColumn(ByVal sName As String, ByVal sAlias As String) As Boolean
        Try
            Dim dr As DataRow
            dr = ColumnList.Tables(0).NewRow
            dr("Name") = sName
            dr("Alias") = sAlias
            ColumnList.Tables(0).Rows.Add(dr)
            Return True
        Catch
            Return False
        End Try
    End Function

End Class
