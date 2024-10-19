Imports System
Imports System.IO

Namespace iConsulting.iCMServer

    Public NotInheritable Class clsSaveBlobData : Inherits iConsulting.iCMServer.clsConnection

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

        Public Function Execute(ByVal sTable As String, ByVal sWhere As String, ByVal dsBlobList As DataSet, ByVal Blob As Byte(), ByVal IsUpdate As Boolean) As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::Execute]"
            Try
                Dim oConn As Object = MyBase.GetConnection()
                Dim sDataTableName As String
                If TypeOf (oConn) Is SqlClient.SqlConnection Then
                    Dim oConnection As SqlClient.SqlConnection = oConn
                    Try
                        Dim oAdapter As New SqlClient.SqlDataAdapter
                        Dim drDataRow As DataRow
                        Dim drBlobRow As DataRow
                        Dim sSQL As String
                        sSQL += "SELECT * FROM " & sTable
                        If Not sWhere = "" Then sSQL += " WHERE " & sWhere
                        oAdapter.SelectCommand = New SqlClient.SqlCommand(sSQL, oConnection)
                        Dim oCmdBuilder As New SqlClient.SqlCommandBuilder(oAdapter)
                        Dim dsMerge As DataSet = New DataSet
                        oAdapter.Fill(dsMerge, sTable)
                        If IsUpdate Then
                            drDataRow = dsMerge.Tables(0).Rows(0)
                            For Each drBlobRow In dsBlobList.Tables(0).Rows
                                If drBlobRow("Blob") Then
                                    drDataRow(drBlobRow("ColumnName")) = Blob
                                Else
                                    drDataRow(drBlobRow("ColumnName")) = drBlobRow("DataValue")
                                End If
                            Next
                        Else
                            drDataRow = dsMerge.Tables(0).NewRow()
                            For Each drBlobRow In dsBlobList.Tables(0).Rows
                                If drBlobRow("Blob") Then
                                    drDataRow(drBlobRow("ColumnName")) = Blob
                                Else
                                    drDataRow(drBlobRow("ColumnName")) = drBlobRow("DataValue")
                                End If
                            Next
                            dsMerge.Tables(0).Rows.Add(drDataRow)
                        End If
                        oAdapter.Update(dsMerge, sTable)
                        MyBase.CloseConnection(oConnection)
                    Catch
                        MyBase.CloseConnection(oConnection)
                    End Try
                ElseIf TypeOf (oConn) Is CoreLab.MySql.MySqlConnection Then
                    Dim oConnection As CoreLab.MySql.MySqlConnection = oConn
                    Try
                        Dim oAdapter As New CoreLab.MySql.MySqlDataAdapter
                        Dim drDataRow As DataRow
                        Dim drBlobRow As DataRow
                        Dim sSQL As String
                        sSQL += "SELECT * FROM " & sTable
                        If Not sWhere = "" Then sSQL += " WHERE " & sWhere
                        oAdapter.SelectCommand = New CoreLab.MySql.MySqlCommand(sSQL, oConnection)
                        Dim oCmdBuilder As New CoreLab.MySql.MySqlCommandBuilder(oAdapter)
                        Dim dsMerge As DataSet = New DataSet
                        oAdapter.Fill(dsMerge, sTable)
                        If IsUpdate Then
                            drDataRow = dsMerge.Tables(0).Rows(0)
                            For Each drBlobRow In dsBlobList.Tables(0).Rows
                                If drBlobRow("Blob") Then
                                    drDataRow(drBlobRow("ColumnName")) = Blob
                                Else
                                    drDataRow(drBlobRow("ColumnName")) = drBlobRow("DataValue")
                                End If
                            Next
                        Else
                            drDataRow = dsMerge.Tables(0).NewRow()
                            For Each drBlobRow In dsBlobList.Tables(0).Rows
                                If drBlobRow("Blob") Then
                                    drDataRow(drBlobRow("ColumnName")) = Blob
                                Else
                                    drDataRow(drBlobRow("ColumnName")) = drBlobRow("DataValue")
                                End If
                            Next
                            dsMerge.Tables(0).Rows.Add(drDataRow)
                        End If
                        oAdapter.Update(dsMerge, sTable)
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
