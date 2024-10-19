Public Class WebForm2
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents foa1 As System.Web.UI.HtmlControls.HtmlInputFile

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
        'Put user code to initialize the page here
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim intCount As Integer
        Dim oFileUp As New SoftArtisans.Net.FileUp(System.Web.HttpContext.Current)
        Try
            Dim oFile1 As SoftArtisans.Net.SaFile = CType(oFileUp.Form("foa1"), SoftArtisans.Net.SaFile)
            oFile1.Path = "c:\temp\"
            'System.Diagnostics.Debug.WriteLine(oFile1.ContentTransferEncoding)
            oFile1.PreserveMacBinary = True
            If Not IsNothing(oFile1) Then
                If Not oFile1.IsEmpty Then
                    Dim n As String = System.Web.HttpContext.Current.Server.HtmlDecode(oFile1.ShortFilename)
                    oFile1.SaveAs(oFile1.ShortFilename)
                End If
            End If
        Catch ex As Exception
            Response.Write("<b>Wrong selection : </b>" & ex.ToString)
        End Try

    End Sub
End Class
