Imports System.Web.Services
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Services.Protocols

<WebService(Namespace:="iConsulting.iCMServer")> _
Public Class iCDataObject : Inherits System.Web.Services.WebService

#Region " Description "
    '=========================================================================
    'Copyright (C) 2003 By iConsulting
    '=========================================================================
    'Class:         iCDataManager
    'Category:      Web Service Class
    'Comments:      iCDataManager is a implements a bunch of functions used for
    '               connection to the datasource.
    'Revision:      Johan Olofsson, 2003-04-02, Created
    '               Johan Olofsson, 2005-03-02, Updated
    '-------------------------------------------------------------------------
#End Region

    Const CLASSNAME = "[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject]"

    Private m_Internal As New clsInternal

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

#Region " WebMethod() Public Functions "

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetDefinedDataSet]<br>This function is used for retriving a defined dataset from a specific database / table.<br>it can only carry info and data from one datatable.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetDefinedDataSet(ByVal sTable As String, ByVal dsDefinedDataList As DataSet, ByVal sWhere As String, ByVal sOrder As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Return m_Internal.GetDefinedDataSet(sTable, dsDefinedDataList, sWhere, sOrder, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::SaveBlobData]<br>This function is used for saving very large binary object's.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function SaveBlobData(ByVal sTable As String, ByVal sWhere As String, ByVal dsBlobList As DataSet, ByVal Blob As Byte(), ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal IsUpdate As Boolean) As Boolean
        Return m_Internal.SaveBlobData(sTable, sWhere, dsBlobList, Blob, sError, EncryptedDataSource, EncryptedConnectionString, IsUpdate)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetDataScalar]<br>This function is used for retriving the amount of rows in a specific tabel.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetDataScalar(ByVal sTable As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String) As Integer
        Return m_Internal.GetDataScalar(sTable, sError, EncryptedDataSource, EncryptedConnectionString)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetDataSet]<br>This function is used for retriving a dataset from a specific database / table.<br>it can only carry info and data from one datatable.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetDataSet(ByVal sTable As String, ByVal sWhere As String, ByVal sOrder As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Return m_Internal.GetDataSet(sTable, sWhere, sOrder, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetDataSet]<br>This function is used for retriving a dataset from a specific database / table from SP.<br>it can only carry info and data from one datatable.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetDataFromSP(ByVal sSQL As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Return m_Internal.GetDataFromSP(sSQL, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetMultiDataSet]<br>This function is used for retriving a dataset / table.<br>this function can hold info and data from multiple datatable's.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetMultiDataSet(ByVal dsMultiList As DataSet, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Return m_Internal.GetMultiDataSet(dsMultiList, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetMultiDataSetFromSP]<br>This function is used for retriving a dataset / table from SP.<br>this function can hold info and data from multiple datatable's.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetMultiDataSetFromSP(ByVal dsMultiList As DataSet, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Return m_Internal.GetMultiDataSetFromSP(dsMultiList, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::GetEmptyDataSet]<br>This function is used for retriving an empty dataset / table.<br>It return's all info about the datatable but with no data.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function GetEmptyDataSet(ByVal sTable As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet) As Boolean
        Return m_Internal.GetEmptyDataSet(sTable, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet)
    End Function

    <WebMethod(BufferResponse:=False, Description:="[Namespace::iConsulting.iCMServer][WebService::iCDataManager][Class::iCDataObject][Function::SaveDataSet]<br>This function is used for saving a dataset retrived from GetDataSet or GetEmptyDataSet.<br>It can return the updated dataset if that's required.<br>It's using a Hi Encryption method and can only be used with other applications<br>developed by http://www.iConsulting.se Corporation.")> _
    Public Function SaveDataSet(ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As DataSet, ByVal Refresh As Boolean) As Boolean
        Return m_Internal.SaveDataSet(sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet, Refresh)
    End Function

#End Region

End Class
