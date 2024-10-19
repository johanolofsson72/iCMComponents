Imports System

Namespace iConsulting.iCMServer

    Public NotInheritable Class clsGetDataScalar : Inherits iConsulting.iCMServer.clsConnection

        Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsGetDataScalar]"

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

        Public Function Execute(ByVal sTable As String) As Integer
            Const FUNCTIONNAME = CLASSNAME & "[Function::Execute]"
            Try
                Dim oConn As Object = MyBase.GetConnection()
                If TypeOf (oConn) Is SqlClient.SqlConnection Then
                    Dim oConnection As New SqlClient.SqlConnection
                    oConnection = oConn
                    Dim oCmd As New SqlClient.SqlCommand("SELECT COUNT(*) FROM " & sTable, oConnection)
                    Return oCmd.ExecuteScalar
                    MyBase.CloseConnection(oConnection)
                ElseIf TypeOf (oConn) Is CoreLab.MySql.MySqlConnection Then
                    Dim oConnection As CoreLab.MySql.MySqlConnection = oConn
                    Dim oCmd As New CoreLab.MySql.MySqlCommand("SELECT COUNT(*) FROM " & sTable, oConnection)
                    Return oCmd.ExecuteScalar
                    MyBase.CloseConnection(oConnection)
                ElseIf TypeOf (oConn) Is OleDb.OleDbConnection Then
                    Dim oConnection As New OleDb.OleDbConnection
                    oConnection = oConn
                    Dim oCmd As New OleDb.OleDbCommand("SELECT COUNT(*) FROM " & sTable, oConnection)
                    Return oCmd.ExecuteScalar
                    MyBase.CloseConnection(oConnection)
                End If
                If MyBase.HasError Then Err.Raise(ERR_ABORT)
                Return 1
            Catch
                Me.AddErrorData(Me.myBaseError, Err.Number, ERR_GETDATASCALAR, FUNCTIONNAME, Err.Description)
                Return -1
            End Try
        End Function

#End Region

    End Class

End Namespace
