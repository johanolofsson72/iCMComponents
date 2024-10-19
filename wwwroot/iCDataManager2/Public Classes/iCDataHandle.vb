
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CoreLab.MySql
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Reflection
Imports System.EnterpriseServices

Public Class iCDataHandle : Inherits iConsulting.iCMServer.clsConnection

    Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsInternal]"

    Private m_sError As String
    Private m_bIsConnected As Boolean
    Private m_oConnection As IDbConnection
    Private m_bDisposed As Boolean
    Private m_bUseTransaction As Boolean
    Private m_tTransaction As IDbTransaction
    Private m_bHasError As Boolean

#Region " Properties "

    Public Overloads ReadOnly Property IsConnected() As Boolean
        Get
            Return Me.m_bIsConnected
        End Get
    End Property

    Public Shadows ReadOnly Property HasError() As Boolean
        Get
            Return Me.m_bHasError
        End Get
    End Property

    Public Shadows ReadOnly Property GetError() As String
        Get
            Return Me.m_sError
        End Get
    End Property

    Private Property Service_Error() As String
        Get
            Return Me.m_sError
        End Get
        Set(ByVal Value As String)
            Me.m_sError = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal sDataSource As String, ByVal sConnectionString As String)
        MyBase.New()
        Call Me.Initialize(sDataSource, sConnectionString)
        Me.m_bIsConnected = False
    End Sub

#End Region

#Region " Public Functions "

    Public Function NewTransaction() As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::NewTransaction]"
        Try
            Me.m_tTransaction = Me.m_oConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            'Me.m_tTransaction = Me.m_oConnection.BeginTransaction
            Return True
        Catch ex As Exception
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_CREATE_TRANSACTION, FUNCTIONNAME, Err.Description)
            Return False
        End Try
    End Function

    Public Function EndTransaction() As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::NewTransaction]"
        Try
            If Not Me.HasError Then
                Me.m_tTransaction.Commit()
            Else
                Me.m_tTransaction.Rollback()
            End If
            Return True
        Catch ex As Exception
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_END_TRANSACTION, FUNCTIONNAME, Err.Description)
            Return False
        End Try
    End Function

    Public Sub Connect(ByVal UseTransaction As Boolean)
        Const FUNCTIONNAME = CLASSNAME & "[Function::Connect]"
        Try
            Me.m_oConnection = MyBase.GetConnection()
            Me.m_bIsConnected = MyBase.IsConnected
            If UseTransaction Then Me.NewTransaction()
        Catch ex As Exception
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_INVALID_CONNECTIONSTRING, FUNCTIONNAME, Err.Description)
        End Try
    End Sub

    Public Sub Connect()
        Const FUNCTIONNAME = CLASSNAME & "[Function::Connect]"
        Try
            Me.m_oConnection = MyBase.GetConnection()
            Me.m_bIsConnected = MyBase.IsConnected
        Catch ex As Exception
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_INVALID_CONNECTIONSTRING, FUNCTIONNAME, Err.Description)
        End Try
    End Sub

    Public Sub Close()
        Const FUNCTIONNAME = CLASSNAME & "[Function::Close]"
        Try
            MyBase.CloseConnection(Me.m_oConnection)
        Catch ex As Exception
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_CLOSE_CONNECTION, FUNCTIONNAME, Err.Description)
        End Try
    End Sub

    Public Function GetDataSet(ByVal sSQL As String) As DataSet
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDataSet]"
        If Me.IsConnected Then
            Try
                Dim ds As New DataSet
                If TypeOf (Me.m_oConnection) Is SqlClient.SqlConnection Then
                    Dim oAdapter As New SqlDataAdapter(sSQL, Me.m_oConnection)
                    oAdapter.Fill(ds, "GetDataSet")
                ElseIf TypeOf (Me.m_oConnection) Is MySqlConnection Then
                    Dim oAdapter As New MySqlDataAdapter(sSQL, Me.m_oConnection)
                    oAdapter.Fill(ds, "GetDataSet")
                ElseIf TypeOf (Me.m_oConnection) Is OleDb.OleDbConnection Then

                End If
                If MyBase.HasError Then Err.Raise(ERR_ABORT)
                Return ds
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_GETDATA, FUNCTIONNAME, Err.Description)
                Return New DataSet
            End Try
        End If
    End Function

    Public Function GetDataTable(ByVal sSQL As String) As DataTable
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDataTable]"
        If Me.IsConnected Then
            Try
                Dim ds As New DataSet
                If TypeOf (Me.m_oConnection) Is SqlClient.SqlConnection Then
                    Dim oAdapter As New SqlDataAdapter(sSQL, Me.m_oConnection)
                    oAdapter.Fill(ds, "GetDataTable")
                ElseIf TypeOf (Me.m_oConnection) Is MySqlConnection Then
                    Dim oAdapter As New MySqlDataAdapter(sSQL, Me.m_oConnection)
                    oAdapter.Fill(ds, "GetDataTable")
                ElseIf TypeOf (Me.m_oConnection) Is OleDb.OleDbConnection Then

                End If
                If MyBase.HasError Then Err.Raise(ERR_ABORT)
                Return ds.Tables(0)
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_GETDATA, FUNCTIONNAME, Err.Description)
                Return New DataTable
            End Try
        End If
    End Function

    Public Function ExecuteReader(ByVal sSQL As String) As IDataReader
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDataFromSP]"
        If Me.IsConnected Then
            Try
                Dim Reader As IDataReader
                If TypeOf (Me.m_oConnection) Is SqlClient.SqlConnection Then
                    Dim oCommand As New SqlCommand(sSQL, Me.m_oConnection)
                    Reader = oCommand.ExecuteReader
                ElseIf TypeOf (Me.m_oConnection) Is MySqlConnection Then
                    Dim oCommand As New MySqlCommand(sSQL)
                    oCommand.Connection = Me.m_oConnection
                    Reader = oCommand.ExecuteReader

                ElseIf TypeOf (Me.m_oConnection) Is OleDb.OleDbConnection Then

                End If
                If MyBase.HasError Then Err.Raise(ERR_ABORT)
                Return Reader
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_GETDATA, FUNCTIONNAME, Err.Description)
                Return Nothing
            End Try
        End If
    End Function

    Public Function ExecuteNonQuery(ByVal sSQL As String) As Integer
        Const FUNCTIONNAME = CLASSNAME & "[Function::ExecuteNonQuery]"
        If Me.IsConnected Then
            Try
                Dim Result As Integer
                If TypeOf (Me.m_oConnection) Is SqlClient.SqlConnection Then
                    Dim oCommand As New SqlCommand(sSQL, Me.m_oConnection)
                    Result = oCommand.ExecuteNonQuery
                ElseIf TypeOf (Me.m_oConnection) Is MySqlConnection Then
                    Dim oCommand As New MySqlCommand(sSQL)
                    oCommand.Connection = Me.m_oConnection
                    oCommand.Transaction = Me.m_tTransaction
                    Result = oCommand.ExecuteNonQuery
                ElseIf TypeOf (Me.m_oConnection) Is OleDb.OleDbConnection Then

                End If
                If MyBase.HasError Then Err.Raise(ERR_ABORT)
                Return Result
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_GETDATA, FUNCTIONNAME, Err.Description)
                Return 0
            End Try
        End If
    End Function

    Public Overloads Sub Dispose()
        MyBase.Dispose()
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.m_bDisposed Then
            If disposing Then
                m_sError = String.Empty
                If Me.m_oConnection.State = ConnectionState.Open Then Me.m_oConnection.Close()
            End If
        End If
        Me.m_bDisposed = True

    End Sub

#End Region

#Region " Private Functions "

    Private Overloads Sub Initialize(ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String)
        Me.DataSource = Decrypt(EncryptedDataSource)
        Me.ConnectionString = Decrypt(EncryptedConnectionString)
    End Sub

    Private Sub AddErrorData(ByRef sError As String, ByVal lNumber As Long, ByVal lSeverity As Long, ByVal sSource As String, ByVal sMsg As String)
        Try
            sError += "#" & lNumber & "|" & lSeverity & "|" & sSource & "|" & sMsg
            Me.m_bHasError = True
        Catch
        End Try
    End Sub

    Private Function Decrypt(ByVal base64String As String) As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::Decrypt]"
        Try
            Dim RMCrypto As New RijndaelManaged
            Dim dec As ICryptoTransform = RMCrypto.CreateDecryptor(CRYPTO_KEY, CRYPTO_IV)
            Dim ByteArr() As Byte = Convert.FromBase64String(base64String)
            Return Encoding.UTF8.GetString(dec.TransformFinalBlock(ByteArr, 0, ByteArr.GetLength(0)))
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_DECRYPT, FUNCTIONNAME, Err.Description)
            Return "Decrypt - " & Err.Description
        End Try
    End Function

#End Region

End Class

Public Class TestTran : Inherits ServicedComponent
    Public Function TestMe() As DataSet
        Dim ed As String = Encrypt("MySql")
        Dim ec As String = Encrypt("host=localhost;user=root;database=ic2")
        Dim DataHandle As New iCDataHandle(ed, ec)
        Dim i As Integer
        DataHandle.Connect()
        Dim t As IDbTransaction = ContextUtil.Transaction
        i = DataHandle.ExecuteNonQuery("insert into tab (tab_text) values ('ap-bajs1')")
        If i = 0 Then t.Rollback()
        i = DataHandle.ExecuteNonQuery("insert into tab (tab_text3) values ('ap-bajs2')")
        If i = 0 Then t.Rollback()
        Dim ds As DataSet = DataHandle.GetDataSet("select * from tab order by tab_id desc")
        t.Commit()
        DataHandle.Close()
        Return ds
    End Function

    Private Function Encrypt(ByVal Value As String) As String
        Dim RMCrypto As New RijndaelManaged
        Dim ByteArray() As Byte = Encoding.UTF8.GetBytes(Value)
        Dim enc As ICryptoTransform = RMCrypto.CreateEncryptor(CRYPTO_KEY, CRYPTO_IV)
        Dim ByteArr() As Byte = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0))
        Return Convert.ToBase64String(ByteArr)
    End Function
End Class
