Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Public Class iCM:Inherits System.Web.UI.Page

    Protected iCMBody As HtmlGenericControl
    Protected iCMPageHeight As HtmlGenericControl
    Protected iCMPage As HtmlTable

    Protected LeftModuleField As HtmlTableCell
    Protected ContentModuleField As HtmlTableCell
    Protected RightModuleField As HtmlTableCell
    Protected LeftModuleFieldSpacer As Image
    Protected ContentModuleFieldSpacer As Image
    Protected RightModuleFieldSpacer As Image

    Protected WithEvents LnbLoggaIn As LinkButton
    Protected WithEvents pnlLoggIn As Panel
    Protected WithEvents Linkbutton1 As LinkButton

    Protected WithEvents TopModuleField As HtmlTableCell
    Protected WithEvents ContentAdjust1 As PlaceHolder
    Protected WithEvents FooterField1 As PlaceHolder
    Protected WithEvents JavaScriptHolder As Panel
    Public ContentAdjust As String
    Protected WithEvents btnLogOut As LinkButton
    Protected WithEvents btnLogIn As LinkButton
    Private ExpId As String = ""

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        Dim strContainer As String
        Dim strCurrentId As String
        Dim strCurrentHeaderId As String
        Dim strBodyOnLoad As String
        Dim blnFirstModule As Boolean = False
        Dim blnLoginMode As Boolean
        Dim i As Integer

        ' Obtain SiteSettings from Current Context
        Dim _SiteSettings As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)

        ' Ensure that the visiting user has access to the current page
        If clsSiteSecurity.IsInRoles(_SiteSettings.ActivePage.AuthorizedRoles) = False Then
            Response.Redirect("~/Server/Security/AccessDenied.aspx")
        End If

        ' Show login module if the client is not yet authenticated and they requested to login
        If Not Request.IsAuthenticated And Request.QueryString("ShowLogin") = "1" Then
            Dim c As New Control
            c = Page.LoadControl("~/Server/Modules/SignIn/SignIn.ascx")
            c.ID = "iCMServer_SignIn"
            ContentModuleField.Controls.Add(c)
            ContentModuleField.Visible = True
            btnLogIn.Visible = True
            btnLogOut.Visible = False
            blnLoginMode = True
        ElseIf Request.IsAuthenticated = False Then
            btnLogIn.Visible = True
            btnLogOut.Visible = False
        Else
            btnLogIn.Visible = False
            btnLogOut.Visible = True
        End If

        ' Obtain ExpId if the page uses Minimizer icons...
        If Not (Request.Params("ExpId") Is Nothing) Then
            ExpId = Request.Params("ExpId")
        End If

        ' Render Site backimage and backcolor.....
        If Not Trim(_SiteSettings.SiteLogo) = "" And Not Trim(_SiteSettings.SiteLogo) = "0" Then
            Call Render_BackImage(_SiteSettings, Trim(_SiteSettings.SiteLogo), Trim(_SiteSettings.SiteLogoHref))
        End If
        If Not Trim(_SiteSettings.Color) = "n/a" Then
            Call Render_BackColor(Trim(_SiteSettings.Color))
        End If

        ' Render Page backimage and backcolor
        If Not Trim(_SiteSettings.ActivePage.PagePictureId) = "" And Not Trim(_SiteSettings.ActivePage.PagePictureId) = "0" Then
            Call Render_PageImage(_SiteSettings, Trim(_SiteSettings.ActivePage.PagePictureId), Trim(_SiteSettings.ActivePage.PagePictureHref))
        End If
        If Not Trim(_SiteSettings.ActivePage.PageBackColor) = "n/a" Then
            Call Render_BackColor(Trim(_SiteSettings.ActivePage.PageBackColor))
        End If

        '' Render Footer text ...
        'If _SiteSettings.SiteShowFooter Then
        '    Call Render_Footer(_SiteSettings.SiteFooterTextLeft, _SiteSettings.SiteFooterTextContent, _SiteSettings.SiteFooterTextRight)
        'End If

        ' Render Page Height ...
        Call Render_PageHeight(_SiteSettings.ActivePage.PageHeight)

        ' Render SiteAlign ...
        Call Render_SiteAlign(_SiteSettings.SiteAlign)

        ' Render SiteWidth ...
        Call Render_SiteWidth(_SiteSettings.SiteWidth)

        ' Render Content Adjust
        If CType(_SiteSettings.SiteContentAdjust, Integer) > 0 Then
            Call Render_ContentAdjust(CType(_SiteSettings.SiteContentAdjust, Integer) + CType(_SiteSettings.ActivePage.PageTop, Integer))
        End If

        ' Set ModuleFeild width
        If _SiteSettings.ActivePage.ContentAlignCenter Then
            LeftModuleField.Width = ""
            RightModuleField.Width = ""
            If _SiteSettings.ActivePage.ContentModuleFieldWidth <> "" Then
                ContentModuleField.Width = _SiteSettings.ActivePage.ContentModuleFieldWidth & "px"
            End If
            ContentModuleField.Align = "center"
        Else
            If _SiteSettings.ActivePage.LeftModuleFieldWidth <> "" Then
                LeftModuleField.Width = _SiteSettings.ActivePage.LeftModuleFieldWidth & "px"
            End If
            If _SiteSettings.ActivePage.ContentModuleFieldWidth <> "" Then
                ContentModuleField.Width = _SiteSettings.ActivePage.ContentModuleFieldWidth & "px"
            End If
            If _SiteSettings.ActivePage.RightModuleFieldWidth <> "" Then
                RightModuleField.Width = _SiteSettings.ActivePage.RightModuleFieldWidth & "px"
            End If
        End If

        ' Set LanguageText
        Dim oLanguageText As New clsLanguageText
        btnLogIn.Text = oLanguageText.Find(_SiteSettings.LanguageText, "sys_signin")
        btnLogOut.Text = oLanguageText.Find(_SiteSettings.LanguageText, "sys_signout")

        ' Dynamically Populate the Left, Center and Right pane sections of the portal page
        If _SiteSettings.ActivePage.Modules.Count > 0 Then

            ' Loop through each entry in the configuration system for this tab
            Dim _ModuleSettings As clsModuleSettings

            If _SiteSettings.ActivePage.PageMinimizer Then
                JavaScriptHolder.Controls.Add(New LiteralControl("<script>function MinimizerShowThis(o){try{document.getElementById(o).style.display='';}catch(e){}}</script>" & vbCrLf))
                JavaScriptHolder.Controls.Add(New LiteralControl("<script>function MinimizerHideThis(o){try{document.getElementById(o).style.display='none';}catch(e){}}</script>" & vbCrLf))
            End If

            For Each _ModuleSettings In _SiteSettings.ActivePage.Modules

                If Not _ModuleSettings.Hidden Then

                    Dim parent As Control = Page.FindControl(_ModuleSettings.ModuleFieldName)

                    ' if the module is the Menu module...
                    If _ModuleSettings.Secure Then
                        If _ModuleSettings.CacheTime = 0 Then
                            Dim SiteModule As clsSiteModuleControl = CType(Page.LoadControl(_ModuleSettings.DesktopSrc), clsSiteModuleControl)
                            SiteModule.SiteId = _SiteSettings.SiteId
                            SiteModule.ModuleConfiguration = _ModuleSettings
                            parent.Controls.Add(SiteModule)
                        Else
                            Dim SiteModule As New clsCachedSiteModuleControl
                            SiteModule.SiteId = _SiteSettings.SiteId
                            SiteModule.ModuleConfiguration = _ModuleSettings
                            parent.Controls.Add(SiteModule)
                        End If
                    Else
                        If Not blnLoginMode Then
                            strContainer = "<table id=" & _ModuleSettings.ModuleId
                            If _ModuleSettings.Color <> "" Then
                                strContainer += " bgcolor=""" & _ModuleSettings.Color & """"
                            End If
                            strContainer += " border=""" & IIf(_ModuleSettings.Border = "", "0", _ModuleSettings.Border) & """"
                            strContainer += " cellpadding=""0"" cellspacing=""0"" width=""100%"""
                            strContainer += ">"
                            strContainer += "<tr><td"
                            strContainer += " align=""" & IIf(_ModuleSettings.Alignment = "", "left", _ModuleSettings.Alignment) & """"
                            strContainer += ">"

                            parent.Controls.Add(New LiteralControl(strContainer))
                            ' If no caching is specified, create the user control instance and dynamically
                            ' inject it into the page.  Otherwise, create a cached module instance that
                            ' may or may not optionally inject the module into the tree
                            If _ModuleSettings.CacheTime = 0 Then
                                Dim SiteModule As clsSiteModuleControl = CType(Page.LoadControl(_ModuleSettings.DesktopSrc), clsSiteModuleControl)
                                SiteModule.SiteId = _SiteSettings.SiteId
                                SiteModule.ModuleConfiguration = _ModuleSettings
                                parent.Controls.Add(SiteModule)
                            Else
                                Dim SiteModule As New clsCachedSiteModuleControl
                                SiteModule.SiteId = _SiteSettings.SiteId
                                SiteModule.ModuleConfiguration = _ModuleSettings
                                parent.Controls.Add(SiteModule)
                            End If


                            If _SiteSettings.ActivePage.PageMinimizer Then
                                strCurrentId = parent.Controls.Item(parent.Controls.Count - 1).ClientID() & "_" & _ModuleSettings.ModuleId
                                strCurrentHeaderId = parent.Controls.Item(parent.Controls.Count - 1).Controls.Item(0).ClientID() & "_Minimizer_" & _ModuleSettings.ModuleId

                                If Not blnFirstModule Then
                                    If Not ExpId = "" Then
                                        If CType(ExpId, Integer) = CType(_ModuleSettings.ModuleId, Integer) Then
                                            strBodyOnLoad += "MinimizerShow" & _ModuleSettings.ModuleId & "();"
                                        Else
                                            strBodyOnLoad += "MinimizerHide" & _ModuleSettings.ModuleId & "();"
                                        End If
                                    Else
                                        strBodyOnLoad = "MinimizerShow" & _ModuleSettings.ModuleId & "();"
                                    End If
                                Else
                                    If Not ExpId = "" Then
                                        If CType(ExpId, Integer) = CType(_ModuleSettings.ModuleId, Integer) Then
                                            strBodyOnLoad += "MinimizerShow" & _ModuleSettings.ModuleId & "();"
                                        Else
                                            strBodyOnLoad += "MinimizerHide" & _ModuleSettings.ModuleId & "();"
                                        End If
                                    Else
                                        strBodyOnLoad += "MinimizerHide" & _ModuleSettings.ModuleId & "();"
                                    End If
                                End If

                                blnFirstModule = True

                                JavaScriptHolder.Controls.Add(New LiteralControl("<script>function MinimizerHandle" & _ModuleSettings.ModuleId & "(){if(document.getElementById('" & strCurrentId & "').style.display=='none'){MinimizerShow" & _ModuleSettings.ModuleId & "();}else{MinimizerHide" & _ModuleSettings.ModuleId & "();};}</script>" & vbCrLf))
                                JavaScriptHolder.Controls.Add(New LiteralControl("<script>function MinimizerShow" & _ModuleSettings.ModuleId & "(){try{document.getElementById('" & strCurrentHeaderId & "').src='Server/Images/uparrow.png';MinimizerShowThis('" & strCurrentId & "');}catch(e){}}</script>" & vbCrLf))
                                JavaScriptHolder.Controls.Add(New LiteralControl("<script>function MinimizerHide" & _ModuleSettings.ModuleId & "(){try{document.getElementById('" & strCurrentHeaderId & "').src='Server/Images/downarrow.png';MinimizerHideThis('" & strCurrentId & "');}catch(e){}}</script>" & vbCrLf))
                            End If

                            strContainer = "</td></tr></table><br>"

                            parent.Controls.Add(New LiteralControl(strContainer))

                            parent.Visible = True

                        End If

                    End If

                End If

            Next _ModuleSettings

            If Not strBodyOnLoad = "" Then
                iCMBody.Attributes.Add("onload", strBodyOnLoad)
            End If

        End If

    End Sub

    'Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub Render_ContentAdjust(ByVal Rows As Integer)
        Dim i As Integer
        Dim trContent As HtmlTableRow
        Dim tdContent As HtmlTableCell
        For i = 0 To Rows
            trContent = New HtmlTableRow
            tdContent = New HtmlTableCell
            tdContent.InnerHtml = "&nbsp;"
            trContent.Cells.Add(tdContent)
            ContentAdjust1.Controls.Add(trContent)
        Next
    End Sub

    'Private Sub Render_Footer(ByVal LeftText As String, ByVal ContentText As String, ByVal RightText As String)

    '    Dim tFooter As New HtmlTable
    '    Dim trFooter As New HtmlTableRow
    '    Dim tdFooter As HtmlTableCell
    '    Dim divFooter As HtmlGenericControl
    '    Dim fontFooter As Literal

    '    ' Spacer ...
    '    tdFooter = New HtmlTableCell
    '    tdFooter.Attributes.Add("width", "10")
    '    tdFooter.InnerHtml = "&nbsp;"
    '    trFooter.Controls.Add(tdFooter)

    '    ' Left Footer ...
    '    tdFooter = New HtmlTableCell
    '    tdFooter.Attributes.Add("noWrap", "")
    '    tdFooter.Attributes.Add("align", "left")
    '    tdFooter.Attributes.Add("width", "20%")
    '    tdFooter.InnerHtml = "<div style='BORDER-RIGHT: darkgray 0px solid; BORDER-TOP: darkgray 1px solid; BORDER-LEFT: darkgray 1px solid; BORDER-BOTTOM: darkgray 1px solid; BACKGROUND-COLOR: transparent'><font face='Verdana' size='1'>&nbsp;&nbsp;&nbsp;" & LeftText & "</font></div>"
    '    trFooter.Controls.Add(tdFooter)

    '    ' Content Footer  ...
    '    tdFooter = New HtmlTableCell
    '    tdFooter.Attributes.Add("noWrap", "")
    '    tdFooter.Attributes.Add("align", "center")
    '    tdFooter.InnerHtml = "<div style='BORDER-RIGHT: darkgray 0px solid; BORDER-TOP: darkgray 1px solid; BORDER-LEFT: darkgray 0px solid; BORDER-BOTTOM: darkgray 1px solid; BACKGROUND-COLOR: transparent'><font face='Verdana' size='1'>" & ContentText & "</font></div>"
    '    trFooter.Controls.Add(tdFooter)

    '    ' Right Footer  ...
    '    tdFooter = New HtmlTableCell
    '    tdFooter.Attributes.Add("noWrap", "")
    '    tdFooter.Attributes.Add("align", "right")
    '    tdFooter.Attributes.Add("width", "20%")
    '    tdFooter.InnerHtml = "<div style='BORDER-RIGHT: darkgray 1px solid; BORDER-TOP: darkgray 1px solid; BORDER-LEFT: darkgray 0px solid; BORDER-BOTTOM: darkgray 1px solid; BACKGROUND-COLOR: transparent'><font face='Verdana' size='1'>" & RightText & "&nbsp;&nbsp;&nbsp;</font></div>"
    '    trFooter.Controls.Add(tdFooter)

    '    ' Table ...
    '    tFooter.Attributes.Add("cellSpacing", "0")
    '    tFooter.Attributes.Add("cellPadding", "0")
    '    tFooter.Attributes.Add("width", "100%")
    '    tFooter.Attributes.Add("border", "0")
    '    tFooter.Controls.Add(trFooter)

    '    FooterField1.Controls.Add(tFooter)

    'End Sub

    Private Sub Render_PageHeight(ByVal Height As String)
        If Not Height.ToLower = "n/a" Then
            iCMPageHeight.Style.Add("OVERFLOW", "auto")
            iCMPageHeight.Style.Add("HEIGHT", Height)
        End If
    End Sub

    Private Sub Render_SiteWidth(ByVal Width As String)
        If Not Width.ToLower = "n/a" Then
            iCMPage.Attributes.Item("width") = Width
        Else
            iCMPage.Attributes.Item("width") = "100%"
        End If
    End Sub

    Private Sub Render_SiteAlign(ByVal Align As String)
        Select Case Align.ToLower
            Case "left"
                iCMPage.Attributes.Item("align") = "left"
            Case "center"
                iCMPage.Attributes.Item("align") = "center"
            Case "right"
                iCMPage.Attributes.Item("align") = "right"
            Case Else
                iCMPage.Attributes.Item("align") = "left"
        End Select
    End Sub

    Private Sub Render_BackImage(ByVal oSite As clsSiteSettings, ByVal DocId As Integer, ByVal DocHref As String)
        If oSite.SiteLogoHorizotalTiling And oSite.SiteLogoVerticalTiling Then
            iCMBody.Style.Add("BACKGROUND-REPEAT", "repeat-xy")
        ElseIf oSite.SiteLogoHorizotalTiling And Not oSite.SiteLogoVerticalTiling Then
            iCMBody.Style.Add("BACKGROUND-REPEAT", "repeat-x")
        ElseIf oSite.SiteLogoVerticalTiling And Not oSite.SiteLogoHorizotalTiling Then
            iCMBody.Style.Add("BACKGROUND-REPEAT", "repeat-y")
        Else
            iCMBody.Style.Add("BACKGROUND-REPEAT", "no-repeat")
        End If
        'iCMBody.Style.Add("BACKGROUND-IMAGE", "url(Server/Components/Global/ImageStream.aspx?DocId=" & DocId & ")")
        iCMBody.Style.Add("BACKGROUND-IMAGE", "url(Server/Design/" & DocHref & ")")
        Select Case oSite.SiteLogoHorizotalAlign
            Case "left"
                Select Case oSite.SiteLogoVerticalAlign
                    Case "top"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "left top")
                    Case "center"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "left center")
                    Case "bottom"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "left bottom")
                End Select
            Case "center"
                Select Case oSite.SiteLogoVerticalAlign
                    Case "top"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "center top")
                    Case "center"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "center center")
                    Case "bottom"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "center bottom")
                End Select
            Case "right"
                Select Case oSite.SiteLogoVerticalAlign
                    Case "top"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "right top")
                    Case "center"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "right center")
                    Case "bottom"
                        iCMBody.Style.Add("BACKGROUND-POSITION", "right bottom")
                End Select
        End Select
    End Sub

    Private Sub Render_BackColor(ByVal Color As String)
        iCMBody.Style.Add("BACKGROUND-COLOR", Color)
    End Sub

    Private Sub Render_PageImage(ByVal oSite As clsSiteSettings, ByVal DocId As Integer, ByVal DocHref As String)
        If oSite.ActivePage.PagePictureHorizontalTiling And oSite.ActivePage.PagePictureVerticalTiling Then
            iCMPage.Style.Add("BACKGROUND-REPEAT", "repeat-xy")
        ElseIf oSite.ActivePage.PagePictureHorizontalTiling And Not oSite.ActivePage.PagePictureVerticalTiling Then
            iCMPage.Style.Add("BACKGROUND-REPEAT", "repeat-x")
        ElseIf oSite.ActivePage.PagePictureVerticalTiling And Not oSite.ActivePage.PagePictureHorizontalTiling Then
            iCMPage.Style.Add("BACKGROUND-REPEAT", "repeat-y")
        Else
            iCMPage.Style.Add("BACKGROUND-REPEAT", "no-repeat")
        End If
        iCMPage.Style.Add("BACKGROUND-IMAGE", "url(Server/Components/Global/ImageStream.aspx?DocId=" & DocId & ")")

        Select Case oSite.ActivePage.PagePictureHorizotalAlign
            Case "left"
                Select Case oSite.ActivePage.PagePictureVerticalAlign
                    Case "top"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "left top")
                    Case "center"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "left center")
                    Case "bottom"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "left bottom")
                End Select
            Case "center"
                Select Case oSite.ActivePage.PagePictureVerticalAlign
                    Case "top"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "center top")
                    Case "center"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "center center")
                    Case "bottom"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "center bottom")
                End Select
            Case "right"
                Select Case oSite.ActivePage.PagePictureVerticalAlign
                    Case "top"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "right top")
                    Case "center"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "right center")
                    Case "bottom"
                        iCMPage.Style.Add("BACKGROUND-POSITION", "right bottom")
                End Select
        End Select
    End Sub

    Private Sub Render_PageColor(ByVal Color As String)
        iCMPage.Style.Add("BACKGROUND-COLOR", Color)
    End Sub

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        Response.Redirect("~/icm.aspx?ShowLogin=1")
    End Sub

    Private Sub btnLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogOut.Click
        Response.Redirect("~/Server/Modules/SignIn/SignOut.aspx")
    End Sub

End Class
