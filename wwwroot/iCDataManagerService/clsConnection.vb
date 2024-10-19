Imports System    

Namespace iConsulting.iCMServer

    Public MustInherit Class clsConnection

        Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsConnection]"

        Private m_sError As String
        Private m_bHasError As Boolean
        Private m_sDataSource As String
        Private m_sConnectionString As String
        Private m_bIsConnected As Boolean

#Region " Properties "

        Public ReadOnly Property GetError() As String
            Get
                Return Me.m_sError
            End Get
        End Property

        Public Shadows ReadOnly Property HasError() As Boolean
            Get
                Return Me.m_bHasError
            End Get
        End Property

        Public Property DataSource() As String
            Get
                Return Me.m_sDataSource
            End Get
            Set(ByVal Value As String)
                Me.m_sDataSource = Value
            End Set
        End Property

        Public Property ConnectionString() As String
            Get
                Return Me.m_sConnectionString
            End Get
            Set(ByVal Value As String)
                Me.m_sConnectionString = Value
            End Set
        End Property

        Protected ReadOnly Property IsConnected() As String
            Get
                Return Me.m_bIsConnected
            End Get
        End Property

        Public ReadOnly Property Connectable() As Boolean
            Get
                If Me.ValidateDataSource And Me.ValidateConnectionString Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

#End Region

#Region " Constructors "

        Public Sub New()
            Me.m_bIsConnected = False
        End Sub

        Public Sub New(ByVal sConnectionString As String)
            Me.m_sConnectionString = sConnectionString
            Me.m_bIsConnected = False
        End Sub

        Public Sub New(ByVal sDataSource As String, ByVal sConnectionString As String)
            Me.m_sDataSource = sDataSource
            Me.m_sConnectionString = sConnectionString
            Me.m_bIsConnected = False
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

        Private Function ValidateDataSource() As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::ValidateDataSource]"
            Try
                Select Case Me.DataSource
                    Case ICM_DATASOURCE_MSSQLSERVER, ICM_DATASOURCE_MSACCESS, ICM_DATASOURCE_MYSQL
                        Return True
                    Case Else
                        Err.Raise(ERR_ABORT)
                End Select
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_UNKNOWN_DATASOURCE, FUNCTIONNAME, Err.Description)
                Return False
            End Try
        End Function

        Private Function ValidateConnectionString() As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::ValidateConnectionString]"
            Try
                If Me.m_sConnectionString = "" Then Err.Raise(ERR_ABORT)
                Return True
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_INVALID_CONNECTIONSTRING, FUNCTIONNAME, Err.Description)
                Return False
            End Try
        End Function

#End Region

#Region " Public Functions "

        Public Function GetConnection() As Object
            Const FUNCTIONNAME = CLASSNAME & "[Function::GetConnection]"
            Try
                If Me.Connectable Then
                    Select Case Me.DataSource
                        Case ICM_DATASOURCE_MSSQLSERVER
                            Dim oConnection As New SqlClient.SqlConnection(Me.ConnectionString)
                            oConnection.Open()
                            Me.m_bIsConnected = True
                            Return oConnection
                        Case ICM_DATASOURCE_MSACCESS
                            Dim oConnection As New OleDb.OleDbConnection(Me.ConnectionString)
                            oConnection.Open()
                            Me.m_bIsConnected = True
                            Return oConnection
                        Case ICM_DATASOURCE_MYSQL
                            Dim oConnection As New CoreLab.MySql.MySqlConnection(Me.ConnectionString)
                            oConnection.Open()
                            Me.m_bIsConnected = True
                            Return oConnection
                    End Select
                Else
                    Me.m_bIsConnected = False
                    Err.Raise(ERR_ABORT)
                End If
            Catch
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_INVALID_CONNECTIONSTRING, FUNCTIONNAME, Err.Description)
                Me.m_bIsConnected = False
                Return New SqlClient.SqlConnection
            End Try
        End Function

        Public Sub CloseConnection(ByRef oConnection As Object)
            Const FUNCTIONNAME = CLASSNAME & "[Function::CloseConnection]"
            Try
                oConnection.Close()
                oConnection = Nothing
            Catch
                oConnection = Nothing
                Me.AddErrorData(Me.m_sError, Err.Number, ERR_CLOSE_CONNECTION, FUNCTIONNAME, Err.Description)
            End Try
        End Sub

#End Region

    End Class

End Namespace
