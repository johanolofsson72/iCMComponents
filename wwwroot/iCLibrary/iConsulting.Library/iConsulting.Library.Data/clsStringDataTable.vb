Namespace Data

    Public Class clsStringDataTable
        Public DataTable As New DataTable

        Public Sub New(ByVal oJoin As clsJoinView, ByVal FieldTypeList As String)
            Dim dg As New System.Web.UI.WebControls.DataGrid
            dg.DataSource = oJoin
            dg.DataBind()
            Dim Fields() As String = FieldTypeList.Split(",")
            Dim i As Integer
            Dim j As Integer
            Dim dt As New DataTable(oJoin.Table.TableName)
            Dim dr As DataRow
            Try
                If dg.Items.Count > 0 Then
                    ' Columns
                    For j = 0 To dg.Items(0).Cells.Count - 1
                        dt.Columns.Add(Left(Fields(j), InStr(Fields(j), ":") - 1), System.Type.GetType("System." & Right(Fields(j), InStr(StrReverse(Fields(j)), ":") - 1)))
                    Next
                    ' Add Values
                    For i = 0 To dg.Items.Count - 1
                        dr = dt.NewRow
                        For j = 0 To dg.Items(i).Cells.Count - 1
                            dr(Left(Fields(j), InStr(Fields(j), ":") - 1)) = dg.Items(i).Cells(j).Text
                        Next
                        dt.Rows.Add(dr)
                    Next
                End If
                DataTable = dt
            Catch ex As Exception
                DataTable = New DataTable
            End Try
        End Sub

    End Class

End Namespace