Imports iConsulting.iCMServer.Library

Namespace iConsulting.iCMServer.Library.Tester

Partial Class WebForm1

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim T As Double
        'T = Timer
        'Dim iCM As New iCMServer
        'Response.Write(iCM.Sites.GetSite(1).Pages.GetPage(2).Modules.GetModule(1).Name & " hämtning tog " & (Timer - T).ToString & "<br>")

        'Response.Write("<br><br>")

        T = Timer
        Dim i As New iCMServer
        If IsNothing(i.Find("default")) Then Response.Write("finns ej")
        Response.End()
        'Dim s As Site = i.Sites(0)
        'Response.Write(s.Name & (Timer - T).ToString & "<br>")
        'T = Timer
        'Dim p As Library.Page = s.Pages.GetPage(2)
        'Response.Write(p.Name & (Timer - T).ToString & "<br>")
        'Response.Write(p.Modules.Count & (Timer - T).ToString & "<br>")
        'Dim mc As ModuleCollection = p.Modules
        For Each m As Library.Module In i.Sites(0).Pages.GetPage(2).Modules.Items
            T = Timer
            Response.Write(m.Name & (Timer - T).ToString & "<br>")
        Next

        Dim ss As String = ""


        'Response.Write("Deklaration av page tog " & (Timer - T).ToString & "<br>")
        'T = Timer
        'Dim m1 As [Module] = CType(p.Modules(1), Library.Module)
        'Response.Write(m1.Name & " hämtning tog " & (Timer - T).ToString & "<br>")
        'T = Timer
        'Response.Write(p.Modules(2).Name & " hämtning tog " & (Timer - T).ToString & "<br>")

        'Response.Write(p.Name & " hämtning tog " & (Timer - T).ToString & "<br>")
        'Response.Write(o.Sites().GetSite("Default").Name)
        'Dim T As Double
        'Dim AP As New Library.PageCollection(1, True)
        'For Each p As Library.Page In AP.Items
        '    T = Timer
        '    Response.Write(p.Name & " hämtning tog " & (Timer - T).ToString & "<br>")
        'Next

        Dim icm As New iConsulting.iCMServer.Library.iCMServer
        Dim pp As iConsulting.iCMServer.Library.Page = icm.Sites(1).Pages(4)
        Dim pp2 As New Library.Page(1, 3, True)
        Dim oldCrypt As New iConsulting.Library.Security.clsCrypto
        Dim a As String = oldCrypt.Decrypt("sps")



        Dim f As New System.IO.FileInfo("c:\temp\1.doc")
        Dim bo As New iConsulting.Library.CacheItem(f)
        Dim boo As New iConsulting.Library.DocumentCache(Server.MapPath("."))
        boo.Add(bo)

        'Dim col As New System.Collections.Hashtable
        'col.Add("BackColor", "#000000")
        'Dim ca As New ColorAttribute
        'ca.Color = "grön"
        'ca.Depth = "1"
        'Dim Attributes As New ColorAttribute
        'Attributes.

        'Attributes.Item(0) = 1

    End Sub

    Public Class ColorAttribute
        Public Color As Object
        Public Depth As Object
    End Class

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

End Class
End Namespace
