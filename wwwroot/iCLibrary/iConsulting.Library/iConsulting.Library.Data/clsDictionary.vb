Namespace Data

    Public Class clsDictionary

        Private m_ds As DataSet
        Private m_dt As DataTable

        Public ReadOnly Property Dictionary() As DataSet
            Get
                Return Me.m_ds
            End Get
        End Property

        Public Sub New()
            Me.m_ds = New DataSet("Dictionary")
            Me.m_dt = New DataTable("DictionaryTable")
            Call AddColumn()
        End Sub

        Private Sub AddColumn()
            Dim dc As DataColumn
            dc = New DataColumn("Key", System.Type.GetType("System.String"))
            Me.m_dt.Columns.Add(dc)
            dc = New DataColumn("Value", System.Type.GetType("System.String"))
            Me.m_dt.Columns.Add(dc)
            Me.m_ds.Tables.Add(Me.m_dt)
        End Sub

        Public Sub AddData(ByVal Key As String, ByVal Value As String)
            Dim dr As DataRow
            dr = m_ds.Tables("DictionaryTable").NewRow
            dr("Key") = Key
            dr("Value") = Value
            Me.m_ds.Tables("DictionaryTable").Rows.Add(dr)
        End Sub

    End Class

End Namespace
