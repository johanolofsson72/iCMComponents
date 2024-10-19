
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration.ConfigurationSettings
Imports System.Web.Caching

Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oDO As New iCDataManager.iCDataObject
        Dim oCrypto As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypto.Encrypt(AppSettings.Get("DataSource"))
        Dim EC As String = oCrypto.Encrypt(AppSettings.Get("ConnectionString"))
        Dim sAlias As String = AppSettings.Get("SiteAlias")
        Dim dsSites As New DataSet
        Dim sError As String
        If Not oDO.GetDataSet("sit_sites", "sit_alias = '" & sAlias & "' AND sit_deleted = 0", "", sError, ED, EC, dsSites) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        DataGrid1.DataSource = dsSites
        DataGrid1.DataBind()

    End Sub

End Class
