Imports System.Web.Services
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Services.Protocols

Public Class clsInternal : Implements IDisposable

    Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::clsInternal]"

    Private m_sError As String
    Private m_sPKIDCol As String
    Private m_sTSIDCol As String
    Private m_sTabelName As String
    Private m_sTableWhere As String
    Private m_sTableOrder As String
    Private m_sDataSource As String
    Private m_sConnectionString As String
    Private m_Disposed As Boolean

#Region " Properties "

    Private Property TableName() As String
        Get
            Return Me.m_sTabelName
        End Get
        Set(ByVal Value As String)
            Me.m_sTabelName = Value
        End Set
    End Property

    Private Property TableWhere() As String
        Get
            Return Me.m_sTableWhere
        End Get
        Set(ByVal Value As String)
            Me.m_sTableWhere = Value
        End Set
    End Property

    Private Property TableOrder() As String
        Get
            Return Me.m_sTableOrder
        End Get
        Set(ByVal Value As String)
            Me.m_sTableOrder = Value
        End Set
    End Property

    Private Property PKIDCol() As String
        Get
            Return Me.m_sPKIDCol
        End Get
        Set(ByVal Value As String)
            Me.m_sPKIDCol = Value
        End Set
    End Property

    Private Property TSIDCol() As String
        Get
            Return Me.m_sTSIDCol
        End Get
        Set(ByVal Value As String)
            Me.m_sTSIDCol = Value
        End Set
    End Property

    Private Property Service_Error() As String
        Get
            Return Me.m_sError
        End Get
        Set(ByVal Value As String)
            Me.m_sError = Value
        End Set
    End Property

    Private Property DataSource() As String
        Get
            Return Me.m_sDataSource
        End Get
        Set(ByVal Value As String)
            Me.m_sDataSource = Value
        End Set
    End Property

    Private Property ConnectionString() As String
        Get
            Return Me.m_sConnectionString
        End Get
        Set(ByVal Value As String)
            Me.m_sConnectionString = Value
        End Set
    End Property

#End Region

#Region " Constructors "


    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.m_Disposed Then
            If disposing Then
                m_sError = String.Empty
                m_sPKIDCol = String.Empty
                m_sTSIDCol = String.Empty
                m_sTabelName = String.Empty
                m_sTableWhere = String.Empty
                m_sTableOrder = String.Empty
                m_sDataSource = String.Empty
                m_sConnectionString = String.Empty
            End If
        End If
        Me.m_Disposed = True
    End Sub

#End Region

#Region " Public Functions - For Use With WebMethods And As Public Methods "

    Public Function GetDefinedDataSet(ByVal sTable As String, ByVal dsDefinedDataList As DataSet, ByVal sWhere As String, ByVal sOrder As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDefinedDataSet]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString, sTable, sWhere, sOrder)
            Dim obj As New iConsulting.iCMServer.clsGetData(Me.DataSource, Me.ConnectionString)
            If Not obj.Execute(Me.TableName, ValidateSQLString(ConcateDefinedSQLQuestion(dsDefinedDataList)), dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDEFINEDDATASET, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            Return True
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDEFINEDDATASET, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return False
        End Try
    End Function

    Public Function SaveBlobData(ByVal sTable As String, ByVal sWhere As String, ByVal dsBlobList As DataSet, ByVal Blob As Byte(), ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal IsUpdate As Boolean) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::SaveBlobData]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString, sTable, sWhere)
            Dim obj As New iConsulting.iCMServer.clsSaveBlobData(Me.DataSource, Me.ConnectionString)
            Return obj.Execute(Me.TableName, ValidateSQLString(Me.TableWhere), dsBlobList, Blob, IsUpdate)
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_SAVEBLOBDATA, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return False
        End Try
    End Function

    Public Function GetDataScalar(ByVal sTable As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String) As Integer
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDataScalar]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString, sTable)
            Dim obj As New iConsulting.iCMServer.clsGetDataScalar(Me.DataSource, Me.ConnectionString)
            Return obj.Execute(Me.TableName)
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDATASCALAR, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return -1
        End Try
    End Function

    Public Function GetDataSet(ByVal sTable As String, ByVal sWhere As String, ByVal sOrder As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDataSet]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString, sTable, sWhere, sOrder)
            Dim obj As New iConsulting.iCMServer.clsGetData(Me.DataSource, Me.ConnectionString)
            If Not obj.Execute(Me.TableName, ValidateSQLString(ConcateSQLQuestion()), dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDATASET, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            Return True
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDATASET, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return False
        End Try
    End Function

    Public Function GetDataFromSP(ByVal sSQL As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetDataFromSP]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString)
            Dim obj As New iConsulting.iCMServer.clsGetDataFromSP(Me.DataSource, Me.ConnectionString)
            If Not obj.Execute(sSQL, dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDATASET, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            Return True
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDATASET, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return False
        End Try
    End Function

    Public Function GetMultiDataSet(ByVal dsMultiList As DataSet, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetMultiDataSet]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString)
            Dim obj As New iConsulting.iCMServer.clsGetMultiData(Me.DataSource, Me.ConnectionString)
            If Not obj.Execute(dsMultiList, dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETMULTIDATASET, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            Return True
        Catch

        End Try
    End Function

    Public Function GetMultiDataSetFromSP(ByVal dsMultiList As DataSet, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetMultiDataSet]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString)
            Dim obj As New iConsulting.iCMServer.clsGetMultiDataFromSP(Me.DataSource, Me.ConnectionString)
            If Not obj.Execute(dsMultiList, dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETMULTIDATASET, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            Return True
        Catch

        End Try
    End Function

    Public Function GetEmptyDataSet(ByVal sTable As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetEmptyDataSet]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString, sTable)
            Dim obj As New iConsulting.iCMServer.clsGetData(Me.DataSource, Me.ConnectionString)
            If Not obj.Execute(Me.TableName, GetMaxPKIDColQuestion(), dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GET_MAXPKIDCOL, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            Dim iRowNumber As Integer = IIf(IsDBNull(dsDataSet.Tables(Me.TableName).Rows(DAT_ROW_LBOUND)(DAT_COLUMN_LBOUND)), 0, dsDataSet.Tables(Me.TableName).Rows(DAT_ROW_LBOUND)(DAT_COLUMN_LBOUND))
            dsDataSet.Clear()
            If Not obj.Execute(Me.TableName, CreateEmptyDataSetQuestion(iRowNumber), dsDataSet) Then
                Me.Service_Error = obj.GetError
                Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETEMPTYDATASET, FUNCTIONNAME, Err.Description)
                sError = Me.Service_Error
                Return False
            End If
            If Not ClearDataSet(dsDataSet) Then
                Err.Raise(ERR_ABORT)
            End If
            Return True
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETEMPTYDATASET, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return False
        End Try
    End Function

    Public Function SaveDataSet(ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet, ByVal Refresh As Boolean) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::SaveDataSet]"
        Try
            Call Initialize(EncryptedDataSource, EncryptedConnectionString)
            Select Case CalculateDataSet(dsDataSet)
                Case DSE_INVALID_TYPE : Err.Raise(ERR_ABORT)
                Case DSE_UPDATE_SINGLE, DSE_UPDATE_MULTI
                    Dim obj As New iConsulting.iCMServer.clsUpdateData(Me.DataSource, Me.ConnectionString)
                    If Not obj.Execute(dsDataSet) Then
                        Me.Service_Error = obj.GetError
                        Me.AddErrorData(Me.Service_Error, Err.Number, ERR_SAVEDATASET, FUNCTIONNAME, Err.Description)
                        sError = Me.Service_Error
                        Return False
                    End If
                Case DSE_SAVE_SINGLE
                    Dim obj As New iConsulting.iCMServer.clsSaveData(Me.DataSource, Me.ConnectionString)
                    If Not obj.Execute(dsDataSet, Refresh) Then
                        Me.Service_Error = obj.GetError
                        Me.AddErrorData(Me.Service_Error, Err.Number, ERR_SAVEDATASET, FUNCTIONNAME, Err.Description)
                        sError = Me.Service_Error
                        Return False
                    End If
            End Select
            If Refresh Then
                Me.TableName = dsDataSet.Tables(DAT_TABLE_LBOUND).TableName
                Me.TableWhere = Left(Me.TableName, 3) & "_id = " & dsDataSet.Tables(Me.TableName).Rows(DAT_ROW_LBOUND)(DAT_MAX_PKIDCOL)
                dsDataSet.Tables(Me.TableName).Columns.Remove(DAT_MAX_PKIDCOL)
                dsDataSet.Clear()
                Dim objRefresh = New iConsulting.iCMServer.clsGetData(Me.DataSource, Me.ConnectionString)
                If Not objRefresh.Execute(Me.TableName, ValidateSQLString(ConcateSQLQuestion()), dsDataSet) Then
                    Me.Service_Error = objRefresh.GetError
                    Me.AddErrorData(Me.Service_Error, Err.Number, ERR_GETDATASET, FUNCTIONNAME, Err.Description)
                    sError = Me.Service_Error
                    Return False
                End If
            End If
            Return True
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_SAVEDATASET, FUNCTIONNAME, Err.Description)
            sError = Me.Service_Error
            Return False
        End Try
    End Function

#End Region

#Region " Private Functions "

    Private Sub Initialize(ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, Optional ByVal sTable As String = "", Optional ByVal sWhere As String = "", Optional ByVal sOrder As String = "")
        Me.TableName = sTable
        Me.TableWhere = sWhere
        Me.TableOrder = sOrder
        Me.PKIDCol = Left(Me.TableName, 3) & "_id"
        Me.TSIDCol = Left(Me.TableName, 3) & "_ts"
        Me.DataSource = Decrypt(EncryptedDataSource)
        Me.ConnectionString = Decrypt(EncryptedConnectionString)
    End Sub

    Private Sub AddErrorData(ByRef sError As String, ByVal lNumber As Long, ByVal lSeverity As Long, ByVal sSource As String, ByVal sMsg As String)
        Try
            sError += "#" & lNumber & "|" & lSeverity & "|" & sSource & "|" & sMsg
        Catch
        End Try
    End Sub

    Private Function ClearDataSet(ByRef dsDataSet As DataSet) As Boolean
        Const FUNCTIONNAME = CLASSNAME & "[Function::ClearDataSet]"
        Try
            Dim drDataRow As DataRow
            Dim dcDataColumn As DataColumn
            Dim dcCaption As String
            Dim dsDataTable As DataTable = dsDataSet.Tables(Me.TableName)
            If dsDataTable.Rows.Count > 0 Then
                dsDataTable.Columns.Remove(DAT_MAX_PKIDCOL)
                dsDataTable.Columns.Remove(Me.PKIDCol)
                dsDataTable.Columns.Remove(Me.TSIDCol)
                drDataRow = dsDataTable.Rows(DAT_ROW_LBOUND)
                For Each dcDataColumn In dsDataTable.Columns
                    dcCaption = dcDataColumn.Caption
                    If TypeOf drDataRow(dcCaption) Is String Then
                        drDataRow.Item(dcCaption) = ""
                    ElseIf TypeOf drDataRow(dcCaption) Is Integer Then
                        drDataRow.Item(dcCaption) = 0
                    ElseIf TypeOf drDataRow(dcCaption) Is Boolean Then
                        drDataRow.Item(dcCaption) = False
                    End If
                Next
            Else
                drDataRow = dsDataTable.NewRow  'New DataRow() ' dsDataTable.Rows(DAT_ROW_LBOUND)
                'For Each dcDataColumn In dsDataTable.Columns
                '    dcCaption = dcDataColumn.Caption
                '    If TypeOf dcDataColumn.DataType Is String Then
                '        drDataRow.Item(dcCaption) = ""
                '    ElseIf TypeOf dcDataColumn.DataType Is Integer Then
                '        drDataRow.Item(dcCaption) = 0
                '    ElseIf TypeOf dcDataColumn.DataType Is Boolean Then
                '        drDataRow.Item(dcCaption) = False
                '    End If
                'Next
                dsDataTable.Columns.Remove(DAT_MAX_PKIDCOL)
                dsDataTable.Columns.Remove(Me.PKIDCol)
                dsDataTable.Columns.Remove(Me.TSIDCol)
                dsDataTable.Rows.Add(drDataRow)

            End If
            Return True
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_CLEAR_DATASET, FUNCTIONNAME, Err.Description)
            Return False
        End Try
    End Function

    Private Function CalculateDataSet(ByVal dsDataSet As DataSet) As Integer
        Const FUNCTIONNAME = CLASSNAME & "[Function::CalculateDataSet]"
        Try
            Select Case dsDataSet.Tables.Count
                Case 1
                    If LCase(Left(dsDataSet.Tables(0).TableName, 3)) & LCase(Right(dsDataSet.Tables(0).Columns(0).Caption, 3)) = LCase(dsDataSet.Tables(0).Columns(0).Caption) Then
                        Return DSE_UPDATE_SINGLE
                    Else
                        Return DSE_SAVE_SINGLE
                    End If
                Case Else : Return DSE_UPDATE_MULTI
            End Select
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_CONCATE_SQL, FUNCTIONNAME, Err.Description)
            Return DSE_INVALID_TYPE
        End Try
    End Function

    Private Function ConcateDefinedSQLQuestion(ByVal dsDefinedDataList As DataSet) As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::ConcateDefinedSQLQuestion]"
        Try
            Dim Concated As Boolean = False
            Dim sSQL As String = "SELECT "
            Dim sDef As String
            Dim dr As DataRow
            For Each dr In dsDefinedDataList.Tables(DAT_TABLE_LBOUND).Rows
                sDef += dr("ColumnName") & ", "
                Concated = True
            Next
            If Concated Then
                sSQL = sSQL & Left(sDef, Len(sDef) - 2) & " FROM " & Me.TableName
            Else
                sSQL = "SELECT * FROM " & Me.TableName
            End If
            If Len(Me.TableWhere) > 0 Then sSQL += vbCrLf & " WHERE " & Me.TableWhere
            If Len(Me.TableOrder) > 0 Then sSQL += vbCrLf & " ORDER BY " & Me.TableOrder
            Return sSQL
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_CONCATE_SQL, FUNCTIONNAME, Err.Description)
            Return Nothing
        End Try
    End Function

    Private Function ConcateSQLQuestion() As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::ConcateSQLQuestion]"
        Try
            Dim sSQL As String
            sSQL = "SELECT * FROM " & Me.TableName
            If Len(Me.TableWhere) > 0 Then sSQL += vbCrLf & " WHERE " & Me.TableWhere
            If Len(Me.TableOrder) > 0 Then sSQL += vbCrLf & " ORDER BY " & Me.TableOrder
            Return sSQL
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_CONCATE_SQL, FUNCTIONNAME, Err.Description)
            Return Nothing
        End Try
    End Function

    Private Function GetMaxPKIDColQuestion() As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::GetMaxPKIDColQuestion]"
        Try
            Dim sSQL As String = "SELECT MAX(" & Me.PKIDCol & ") AS " & DAT_MAX_PKIDCOL & " FROM " & Me.TableName
            Return sSQL
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_MAXPKIDCOL_QUESTION, FUNCTIONNAME, Err.Description)
            Return Nothing
        End Try
    End Function

    Private Function CreateEmptyDataSetQuestion(ByVal iRowNumber As Integer) As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::CreateEmptyDataSetQuestion]"
        Try
            Dim sSQL As String
            sSQL = "SELECT * FROM " & Me.TableName & " WHERE " & Me.PKIDCol & " = " & iRowNumber
            'If iRowNumber = 0 Then
            '    sSQL = "SELECT * FROM " & Me.TableName & " WHERE " & Me.PKIDCol & " = " & iRowNumber
            'Else
            '    sSQL = "SELECT * FROM " & Me.TableName & " WHERE " & Me.PKIDCol & " = " & iRowNumber
            'End If
            Return sSQL
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_EMPTYDATASET_QUESTION, FUNCTIONNAME, Err.Description)
            Return Nothing
        End Try
    End Function

    Private Function ValidateSQLString(ByVal sSQL As String) As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::ValidateSQLString]"
        Try
            If InStr(UCase(sSQL), " DROP ") Or InStr(UCase(sSQL), " ALTER ") Then
                Err.Raise(ERR_ABORT)
            End If
            Return sSQL
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_VALIDATE_SQL, FUNCTIONNAME, Err.Description)
            Return Nothing
        End Try
    End Function

    Private Function Encrypt(ByVal Value As String) As String
        Const FUNCTIONNAME = CLASSNAME & "[Function::Encrypt]"
        Try
            Dim RMCrypto As New RijndaelManaged
            Dim ByteArray() As Byte = Encoding.UTF8.GetBytes(Value)
            Dim enc As ICryptoTransform = RMCrypto.CreateEncryptor(CRYPTO_KEY, CRYPTO_IV)
            Dim ByteArr() As Byte = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0))
            Return Convert.ToBase64String(ByteArr)
        Catch
            Me.AddErrorData(Me.Service_Error, Err.Number, ERR_ENCRYPT, FUNCTIONNAME, Err.Description)
            Return "The connection failed."
        End Try
    End Function

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
