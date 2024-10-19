Namespace Data

    Public Class clsMultiQueryList

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
            dc = New DataColumn("Table", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("Where", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("Order", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            DataSet.Tables.Add(DataTable)
        End Sub

        Public Function AddQuery(ByVal Table As String, ByVal Where As String, ByVal Order As String, ByRef dsMultiList As DataSet) As Boolean
            Try
                Dim dr As DataRow
                dr = dsMultiList.Tables(0).NewRow
                dr("Table") = Table
                dr("Where") = Where
                dr("Order") = Order
                dsMultiList.Tables(0).Rows.Add(dr)
                Return True
            Catch
                Return False
            End Try
        End Function

    End Class

End Namespace
