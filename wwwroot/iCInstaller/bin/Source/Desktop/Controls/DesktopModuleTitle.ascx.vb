
Imports iConsulting.iCMServer

Public MustInherit Class DesktopModuleTitle
    Inherits System.Web.UI.UserControl

    Public EditText As [String] = Nothing
    Public EditUrl As [String] = Nothing
    Public Location As [String] = Nothing
    Public Phrase As [String] = Nothing

    Protected WithEvents ModTitle As System.Web.UI.WebControls.Panel
    Protected WithEvents ModButton As System.Web.UI.WebControls.Panel
    Protected WithEvents ModLine As System.Web.UI.WebControls.Panel

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

    Private Sub ModuleHeader(ByVal Text As String, ByVal Url As String, ByVal SourceModule As clsSiteModuleControl)
        Dim bShow As Boolean
        Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        If SourceModule.ModuleConfiguration.ShowTitle Then bShow = True
        If oSite.AlwaysShowEditButton = True Or (clsSiteSecurity.IsInRoles(SourceModule.ModuleConfiguration.AuthorizedEditRoles)) Then
            ' Show Hyperlink button.
            'Response.Write(Url & "<br>")
            Dim b As New HyperLink : b.Text = Text : b.CssClass = "SubSubHead" : b.ID = "ModuleButton" : b.NavigateUrl = Url : ModButton.Controls.Add(b)
            bShow = True
        Else
            ' Show nothing
            Dim b As New HyperLink : b.Text = "&nbsp;" : b.CssClass = "SubSubHead" : b.ID = "ModuleButton" : b.NavigateUrl = "" : ModButton.Controls.Add(b)
            Dim l As New Label : l.Text = "&nbsp;" : l.ID = "ModuleTitle" : l.CssClass = "Head" : l.EnableViewState = False : ModTitle.Controls.Add(l)
            ModLine.Controls.Add(New LiteralControl("&nbsp;"))
        End If
        If bShow Then
            ' Show Moduletitle and Line
            If oSite.ActivePage.PageMinimizer Then
                Dim m As New System.Web.UI.HtmlControls.HtmlImage : m.ID = "Minimizer_" & SourceModule.ModuleConfiguration.ModuleId : m.Style.Add("cursor", "hand") : m.Attributes.Add("onclick", "MinimizerHandle" & SourceModule.ModuleConfiguration.ModuleId & "();") : m.Src = "~/Server/Images/uparrow.png" : ModTitle.Controls.Add(m) : ModTitle.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
            End If
            Dim l As New Label : l.Text = SourceModule.ModuleConfiguration.ModuleTitle : l.ID = "ModuleTitle" : l.CssClass = "Head" : l.EnableViewState = False : ModTitle.Controls.Add(l)
            ModLine.Controls.Add(New LiteralControl("<hr noshade size=1>"))
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Obtain reference to parent portal module
        Dim SiteModule As clsSiteModuleControl

        Try
            SiteModule = CType(Me.Parent, clsSiteModuleControl)
        Catch ex As Exception
            ' This is a redirect becouse we have a problem here, and i´m not sure what it is...
            Response.Redirect("~/icm.aspx")
            'Response.Write("Det gick inte att skapa: iConsulting.iCMServer.clsSiteModuleControl")
            'Response.End()
        End Try

        If Not Location Is Nothing Then
            Dim oSite As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
            Dim oLang As New clsLanguageText
            Dim al As New ArrayList
            al = oLang.GetLanguageTextByLocation(oSite.Language, Location)
            EditText = Server.HtmlDecode(oLang.Find(al, Phrase))
        End If

        Call ModuleHeader(EditText, EditUrl & "?PageId=" & SiteModule.ModuleConfiguration.PageId & "&ModId=" & SiteModule.ModuleConfiguration.ModuleId, SiteModule)

    End Sub

End Class
