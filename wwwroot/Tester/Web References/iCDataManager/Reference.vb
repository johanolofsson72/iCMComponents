﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
'
Namespace iCDataManager
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="iCDataObjectSoap", [Namespace]:="iConsulting.iCMServer")>  _
    Public Class iCDataObject
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://localhost/Development/iConsulting/iCMComponents/wwwroot/iCDataManager/iCDa"& _ 
"taObject.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetDefinedDataSet", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDefinedDataSet(ByVal sTable As String, ByVal dsDefinedDataList As System.Data.DataSet, ByVal sWhere As String, ByVal sOrder As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.Invoke("GetDefinedDataSet", New Object() {sTable, dsDefinedDataList, sWhere, sOrder, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginGetDefinedDataSet(ByVal sTable As String, ByVal dsDefinedDataList As System.Data.DataSet, ByVal sWhere As String, ByVal sOrder As String, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDefinedDataSet", New Object() {sTable, dsDefinedDataList, sWhere, sOrder, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetDefinedDataSet(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/SaveBlobData", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SaveBlobData(ByVal sTable As String, ByVal sWhere As String, ByVal dsBlobList As System.Data.DataSet, <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> ByVal Blob() As Byte, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal IsUpdate As Boolean) As Boolean
            Dim results() As Object = Me.Invoke("SaveBlobData", New Object() {sTable, sWhere, dsBlobList, Blob, sError, EncryptedDataSource, EncryptedConnectionString, IsUpdate})
            sError = CType(results(1),String)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginSaveBlobData(ByVal sTable As String, ByVal sWhere As String, ByVal dsBlobList As System.Data.DataSet, ByVal Blob() As Byte, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal IsUpdate As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SaveBlobData", New Object() {sTable, sWhere, dsBlobList, Blob, sError, EncryptedDataSource, EncryptedConnectionString, IsUpdate}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndSaveBlobData(ByVal asyncResult As System.IAsyncResult, ByRef sError As String) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetDataScalar", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDataScalar(ByVal sTable As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String) As Integer
            Dim results() As Object = Me.Invoke("GetDataScalar", New Object() {sTable, sError, EncryptedDataSource, EncryptedConnectionString})
            sError = CType(results(1),String)
            Return CType(results(0),Integer)
        End Function
        
        '<remarks/>
        Public Function BeginGetDataScalar(ByVal sTable As String, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDataScalar", New Object() {sTable, sError, EncryptedDataSource, EncryptedConnectionString}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetDataScalar(ByVal asyncResult As System.IAsyncResult, ByRef sError As String) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            Return CType(results(0),Integer)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetDataSet", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDataSet(ByVal sTable As String, ByVal sWhere As String, ByVal sOrder As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.Invoke("GetDataSet", New Object() {sTable, sWhere, sOrder, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginGetDataSet(ByVal sTable As String, ByVal sWhere As String, ByVal sOrder As String, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDataSet", New Object() {sTable, sWhere, sOrder, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetDataSet(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetDataFromSP", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDataFromSP(ByVal sSQL As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.Invoke("GetDataFromSP", New Object() {sSQL, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginGetDataFromSP(ByVal sSQL As String, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDataFromSP", New Object() {sSQL, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetDataFromSP(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetMultiDataSet", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMultiDataSet(ByVal dsMultiList As System.Data.DataSet, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.Invoke("GetMultiDataSet", New Object() {dsMultiList, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginGetMultiDataSet(ByVal dsMultiList As System.Data.DataSet, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetMultiDataSet", New Object() {dsMultiList, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetMultiDataSet(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetMultiDataSetFromSP", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMultiDataSetFromSP(ByVal dsMultiList As System.Data.DataSet, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.Invoke("GetMultiDataSetFromSP", New Object() {dsMultiList, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginGetMultiDataSetFromSP(ByVal dsMultiList As System.Data.DataSet, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetMultiDataSetFromSP", New Object() {dsMultiList, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetMultiDataSetFromSP(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/GetEmptyDataSet", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetEmptyDataSet(ByVal sTable As String, ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.Invoke("GetEmptyDataSet", New Object() {sTable, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginGetEmptyDataSet(ByVal sTable As String, ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetEmptyDataSet", New Object() {sTable, sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetEmptyDataSet(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("iConsulting.iCMServer/SaveDataSet", RequestNamespace:="iConsulting.iCMServer", ResponseNamespace:="iConsulting.iCMServer", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SaveDataSet(ByRef sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByRef dsDataSet As System.Data.DataSet, ByVal Refresh As Boolean) As Boolean
            Dim results() As Object = Me.Invoke("SaveDataSet", New Object() {sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet, Refresh})
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
        
        '<remarks/>
        Public Function BeginSaveDataSet(ByVal sError As String, ByVal EncryptedDataSource As String, ByVal EncryptedConnectionString As String, ByVal dsDataSet As System.Data.DataSet, ByVal Refresh As Boolean, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SaveDataSet", New Object() {sError, EncryptedDataSource, EncryptedConnectionString, dsDataSet, Refresh}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndSaveDataSet(ByVal asyncResult As System.IAsyncResult, ByRef sError As String, ByRef dsDataSet As System.Data.DataSet) As Boolean
            Dim results() As Object = Me.EndInvoke(asyncResult)
            sError = CType(results(1),String)
            dsDataSet = CType(results(2),System.Data.DataSet)
            Return CType(results(0),Boolean)
        End Function
    End Class
End Namespace
