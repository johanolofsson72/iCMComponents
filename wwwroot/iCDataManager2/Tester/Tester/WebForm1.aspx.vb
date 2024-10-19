Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private oDO As New iCDataManager.iCDataObject
    Private oCrypto As New iConsulting.Library.Security.clsCrypto
    Private ED As String = oCrypto.Encrypt("MySql")
    Private EC As String = oCrypto.Encrypt("Database=iCDataManagerTester; User=root; Port=3306; Host=localhost; Pooling=false; Connection Lifetime=0")
    Private ds As New DataSet
    Private sError As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not oDO.GetDataSet("sit_sites", "", "", sError, ED, EC, ds) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If
        Response.Write(ds.Tables(0).Rows(0)("sit_alias"))
    End Sub
End Class
