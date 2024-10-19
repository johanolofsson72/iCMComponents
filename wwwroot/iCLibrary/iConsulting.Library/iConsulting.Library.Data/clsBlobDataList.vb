Namespace Data

    Public Class clsBlobDataList

        Public DataSet As DataSet
        Dim DataTable As DataTable

        Sub New()
            DataSet = New DataSet("BlobDataList")
            DataTable = New DataTable("BlobDataListTable")
            Call AddColumn()
        End Sub

        Sub New(ByVal sDataSetName As String)
            DataSet = New DataSet(sDataSetName)
            DataTable = New DataTable("BlobDataListTable")
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
            dc = New DataColumn("DataValue", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("DataType", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("DataLength", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("DataPrecision", System.Type.GetType("System.String"))
            DataTable.Columns.Add(dc)
            dc = New DataColumn("Blob", System.Type.GetType("System.Boolean"))
            DataTable.Columns.Add(dc)
            DataSet.Tables.Add(DataTable)
        End Sub

        Public Function AddTableInfo(ByVal ColumnName As String, ByVal DataValue As String, ByVal DataType As String, ByVal DataLength As String, ByVal DataPrecision As String, ByVal Blob As Boolean) As Boolean
            Try
                Dim dr As DataRow
                dr = Me.DataSet.Tables(0).NewRow
                dr("ColumnName") = ColumnName
                dr("DataValue") = DataValue
                dr("DataType") = DataType
                dr("DataLength") = DataLength
                dr("DataPrecision") = DataPrecision
                dr("Blob") = Blob
                Me.DataSet.Tables(0).Rows.Add(dr)
                Return True
            Catch
                Return False
            End Try
        End Function

    End Class

End Namespace
