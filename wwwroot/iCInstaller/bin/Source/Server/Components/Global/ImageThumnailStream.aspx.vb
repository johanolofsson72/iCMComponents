Public Class ImageThumnailStream
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Private DocId As Integer = 0

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

        If Not (Request.Params("DocId") Is Nothing) Then
            DocId = Int32.Parse(Request.Params("DocId"))
        End If

        Dim oImage As New clsImage
        Dim ds As New Data.DataSet
        ds = oImage.GetImage(DocId)
        Dim dr As Data.DataRow
        dr = ds.Tables(0).Rows(0)
        Dim oThumb As New clsThumbnail(150, 200, CType(ds.Tables(0).Rows(0)("doc_content"), Byte()))
        Dim buffer As Byte() = oThumb.GetThumbnail
        Response.AppendHeader("content-disposition", "filename=" & dr("doc_name"))
        Response.ContentType = CType(dr("doc_contenttype"), String)
        Response.OutputStream.Write(buffer, 0, buffer.Length)
        Response.End()
    End Sub

End Class
