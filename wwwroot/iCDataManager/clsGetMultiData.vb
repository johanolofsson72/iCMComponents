Imports System

Namespace iConsulting.iCMServer

    Public NotInheritable Class clsGetMultiData : Inherits iConsulting.iCMServer.clsConnection

        Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsGetMultiData]"

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

        Private Function ConcateSQLQuestion(ByVal dr As DataRow) As String
            Const FUNCTIONNAME = CLASSNAME & "[Function::ConcateSQLQuestion]"
            Try
                Dim sSQL As String
                sSQL = "SELECT * FROM " & dr("Table")
                If Len(dr("Where")) > 0 Then sSQL += vbCrLf & " WHERE " & dr("Where")
                If Len(dr("Order")) > 0 Then sSQL += vbCrLf & " ORDER BY " & dr("Order")
                Return sSQL
            Catch
                Me.AddErrorData(Me.myBaseError, Err.Number, ERR_GETDATA, FUNCTIONNAME, Err.Description)
                Return Nothing
            End Try
        End Function

#End Region

#Region " Public Functions "

        Public Function Execute(ByVal dsMultiList As DataSet, ByRef dsDataSet As DataSet) As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::Execute]"
            Try
                Dim oConn As Object = MyBase.GetConnection()
                Dim sTable As String
                Dim sSQL As String
                Dim dr As DataRow

                If TypeOf (oConn) Is SqlClient.SqlConnection Then
                    Dim oConnection As New SqlClient.SqlConnection()
                    oConnection = oConn
                    Dim oAdapter As SqlClient.SqlDataAdapter
                    Dim oCmdBuilder As SqlClient.SqlCommandBuilder
                    For Each dr In dsMultiList.Tables(0).Rows
                        sTable = dr("Table")
                        sSQL = ConcateSQLQuestion(dr)
                        oAdapter = New SqlClient.SqlDataAdapter(sSQL, oConnection)
                        oCmdBuilder = New SqlClient.SqlCommandBuilder(oAdapter)
                        oAdapter.Fill(dsDataSet, sTable)
                    Next
                    MyBase.CloseConnection(oConnection)
                ElseIf TypeOf (oConn) Is CoreLab.MySql.MySqlConnection Then
                    Dim oConnection As CoreLab.MySql.MySqlConnection = oConn
                    Dim oAdapter As CoreLab.MySql.MySqlDataAdapter
                    Dim oCmdBuilder As CoreLab.MySql.MySqlCommandBuilder
                    For Each dr In dsMultiList.Tables(0).Rows
                        sTable = dr("Table")
                        sSQL = ConcateSQLQuestion(dr)
                        oAdapter = New CoreLab.MySql.MySqlDataAdapter(sSQL, oConnection)
                        oCmdBuilder = New CoreLab.MySql.MySqlCommandBuilder(oAdapter)
                        oAdapter.Fill(dsDataSet, sTable)
                    Next
                    MyBase.CloseConnection(oConnection)
                ElseIf TypeOf (oConn) Is OleDb.OleDbConnection Then
                    Dim oConnection As New OleDb.OleDbConnection
                    oConnection = oConn
                    Dim oAdapter As OleDb.OleDbDataAdapter
                    Dim oCmdBuilder As OleDb.OleDbCommandBuilder
                    For Each dr In dsMultiList.Tables(0).Rows
                        sTable = dr("Table")
                        sSQL = ConcateSQLQuestion(dr)
                        oAdapter = New OleDb.OleDbDataAdapter(sSQL, oConnection)
                        oCmdBuilder = New OleDb.OleDbCommandBuilder(oAdapter)
                        oAdapter.Fill(dsDataSet, sTable)
                    Next
                    MyBase.CloseConnection(oConnection)
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