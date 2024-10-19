Imports System

Namespace iConsulting.iCMServer

    Public NotInheritable Class clsSaveData : Inherits iConsulting.iCMServer.clsConnection

        Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsSaveData]"

        Private m_sError As String
        Private m_bHasError As Boolean

#Region " Properties "

        Public Shadows ReadOnly Property GetError() As String
            Get
                Return Me.m_sError
            End Get
        End Property

        Public Shadows ReadOnly Property HasError() As Boolean
            Get
                Return Me.m_bHasError
            End Get
        End Property

        Private Property myBaseError() As String
            Get
                If MyBase.HasError Then
                    Me.m_sError = MyBase.GetError
                End If
                Return Me.m_sError
            End Get
            Set(ByVal Value As String)
                Me.m_sError = Value
            End Set
        End Property

#End Region

#Region " Constructors "

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal sConnectionString As String)
            MyBase.New(sConnectionString)
        End Sub

        Public Sub New(ByVal sDataSource As String, ByVal sConnectionString As String)
            MyBase.New(sDataSource, sConnectionString)
        End Sub

#End Region

#Region " Private Functions "

        Private Sub AddErrorData(ByRef sError As String, ByVal lNumber As Long, ByVal lSeverity As Long, ByVal sSource As String, ByVal sMsg As String)
            Try
                sError += "#" & lNumber & "|" & lSeverity & "|" & sSource & "|" & sMsg
                Me.m_bHasError = True
            Catch
            End Try
        End Sub

#End Region

#Region " Public Functions "

        Public Function Execute(ByRef dsDataSet As DataSet, ByVal Refresh As Boolean) As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::Execute]"
            Try
                Dim i As Integer
                Dim oConn As Object = MyBase.GetConnection()
                Dim sTable As String = dsDataSet.Tables(0).TableName
                Dim dsDataTable As DataTable = dsDataSet.Tables(0)
                Dim sDataTableName As String
                If TypeOf (oConn) Is SqlClient.SqlConnection Then
                    Dim oConnection As SqlClient.SqlConnection = oConn
                    Try
                        Dim oAdapter As New SqlClient.SqlDataAdapter()
                        Dim drDataRow As DataRow
                        oAdapter.SelectCommand = New SqlClient.SqlCommand("SELECT * FROM " & sTable, oConnection)
                        Dim oCmdBuilder As New SqlClient.SqlCommandBuilder(oAdapter)
                        Dim dsMerge As DataSet = New DataSet()
                        oAdapter.Fill(dsMerge, sTable)
                        drDataRow = dsMerge.Tables(0).NewRow()
                        For i = 0 To dsDataTable.Columns.Count - 1
                            sDataTableName = dsDataTable.Columns.Item(i).Caption
                            drDataRow.Item(sDataTableName) = dsDataTable.Rows(0)(sDataTableName)
                        Next
                        dsMerge.Tables(0).Rows.Add(drDataRow)
                        oAdapter.Update(dsMerge, sTable)
                        If Refresh Then
                            dsDataSet.Clear()
                            oAdapter.SelectCommand = New SqlClient.SqlCommand("SELECT @@IDENTITY AS " & DAT_MAX_PKIDCOL, oConnection)
                            oCmdBuilder = New SqlClient.SqlCommandBuilder(oAdapter)
                            oAdapter.Fill(dsDataSet, sTable)
                        End If
                        MyBase.CloseConnection(oConnection)
                    Catch
                        MyBase.CloseConnection(oConnection)
                    End Try
                ElseIf TypeOf (oConn) Is CoreLab.MySql.MySqlConnection Then
                    Dim oConnection As CoreLab.MySql.MySqlConnection = oConn
                    Try
                        Dim oAdapter As New CoreLab.MySql.MySqlDataAdapter
                        Dim drDataRow As DataRow
                        oAdapter.SelectCommand = New CoreLab.MySql.MySqlCommand("SELECT * FROM " & sTable, oConnection)
                        Dim oCmdBuilder As New CoreLab.MySql.MySqlCommandBuilder(oAdapter)
                        Dim dsMerge As DataSet = New DataSet
                        oAdapter.Fill(dsMerge, sTable)
                        drDataRow = dsMerge.Tables(0).NewRow()
                        For i = 0 To dsDataTable.Columns.Count - 1
                            sDataTableName = dsDataTable.Columns.Item(i).Caption
                            drDataRow.Item(sDataTableName) = dsDataTable.Rows(0)(sDataTableName)
                        Next
                        dsMerge.Tables(0).Rows.Add(drDataRow)
                        oAdapter.Update(dsMerge, sTable)
                        If Refresh Then
                            dsDataSet.Clear()
                            oAdapter.SelectCommand = New CoreLab.MySql.MySqlCommand("SELECT @@IDENTITY AS " & DAT_MAX_PKIDCOL, oConnection)
                            oCmdBuilder = New CoreLab.MySql.MySqlCommandBuilder(oAdapter)
                            oAdapter.Fill(dsDataSet, sTable)
                        End If
                        MyBase.CloseConnection(oConnection)
                    Catch
                        MyBase.CloseConnection(oConnection)
                    End Try
                ElseIf TypeOf (oConn) Is OleDb.OleDbConnection Then
                    Dim oConnection As OleDb.OleDbConnection = oConn
                    Try
                        Dim oAdapter As New OleDb.OleDbDataAdapter
                        Dim drDataRow As DataRow
                        oAdapter.SelectCommand = New OleDb.OleDbCommand("SELECT * FROM " & sTable, oConnection)
                        Dim oCmdBuilder As OleDb.OleDbCommandBuilder = New OleDb.OleDbCommandBuilder(oAdapter)
                        Dim dsMerge As DataSet = New DataSet
                        oAdapter.Fill(dsMerge, sTable)
                        drDataRow = dsMerge.Tables(0).NewRow()
                        For i = 0 To dsDataTable.Columns.Count - 1
                            sDataTableName = dsDataTable.Columns.Item(i).Caption
                            drDataRow.Item(sDataTableName) = dsDataTable.Rows(0)(sDataTableName)
                        Next
                        dsMerge.Tables(0).Rows.Add(drDataRow)
                        oAdapter.Update(dsMerge, sTable)
                        If Refresh Then
                            dsDataSet.Clear()
                            oAdapter.SelectCommand = New OleDb.OleDbCommand("SELECT @@IDENTITY AS " & DAT_MAX_PKIDCOL, oConnection)
                            oCmdBuilder = New OleDb.OleDbCommandBuilder(oAdapter)
                            oAdapter.Fill(dsDataSet, sTable)
                        End If
                        MyBase.CloseConnection(oConnection)
                    Catch
                        MyBase.CloseConnection(oConnection)
                    End Try
                End If
                If MyBase.HasError Then Err.Raise(ERR_ABORT)
                Return True
            Catch
                Me.AddErrorData(Me.myBaseError, Err.Number, ERR_GETDATA, FUNCTIONNAME, Err.Description)
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace
