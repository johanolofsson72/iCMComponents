Imports System

Namespace iConsulting.iCMServer

    Public NotInheritable Class clsGetData : Inherits iConsulting.iCMServer.clsConnection

        Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsGetData]"

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

        Public Function Execute(ByVal sTable As String, ByVal sSQL As String, ByRef dsDataSet As DataSet) As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::Execute]"
            Try
                Dim oConn As Object = MyBase.GetConnection()
                If TypeOf (oConn) Is SqlClient.SqlConnection Then
                    Dim oConnection As New SqlClient.SqlConnection()
                    oConnection = oConn
                    Dim oAdapter As New SqlClient.SqlDataAdapter(sSQL, oConnection)
                    Dim oCmdBuilder As New SqlClient.SqlCommandBuilder
                    oCmdBuilder = New SqlClient.SqlCommandBuilder(oAdapter)
                    oAdapter.Fill(dsDataSet, sTable)
                    MyBase.CloseConnection(oConnection)
                ElseIf TypeOf (oConn) Is CoreLab.MySql.MySqlConnection Then
                    Dim oConnection As CoreLab.MySql.MySqlConnection = oConn
                    Dim oAdapter As New CoreLab.MySql.MySqlDataAdapter(sSQL, oConnection)
                    Dim oCmdBuilder As New CoreLab.MySql.MySqlCommandBuilder
                    oCmdBuilder = New CoreLab.MySql.MySqlCommandBuilder(oAdapter)
                    oAdapter.Fill(dsDataSet, sTable)
                    MyBase.CloseConnection(oConnection)
                ElseIf TypeOf (oConn) Is OleDb.OleDbConnection Then
                    Dim oConnection As New OleDb.OleDbConnection
                    oConnection = oConn
                    Dim oAdapter As New OleDb.OleDbDataAdapter(sSQL, oConnection)
                    Dim oCmdBuilder As New OleDb.OleDbCommandBuilder
                    oCmdBuilder = New OleDb.OleDbCommandBuilder(oAdapter)
                    oAdapter.Fill(dsDataSet, sTable)
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

