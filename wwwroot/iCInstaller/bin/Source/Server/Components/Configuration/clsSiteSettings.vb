
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration.ConfigurationSettings

Public Class clsSiteSettings

    Public SiteId As Integer
    Public SiteName As String
    Public SiteAlias As String
    Public AlwaysShowEditButton As Boolean
    Public Language As Integer
    Public SiteCSS As String
    Public SiteLogo As String
    Public SiteLogoHref As String
    Public SiteSoftDelete As Boolean
    Public SiteFooterTextLeft As String
    Public SiteFooterTextContent As String
    Public SiteFooterTextRight As String
    Public SiteShowFooter As Boolean
    Public SiteContentAdjust As Integer
    Public SiteStartPage As Integer
    Public DesktopPages As New ArrayList
    Public MobilePages As New ArrayList
    Public LanguageText As New ArrayList
    Public ActivePage As New clsPageSettings
    Public Color As String
    Public SiteLogoHorizotalAlign As String
    Public SiteLogoVerticalAlign As String
    Public SiteLogoHorizotalTiling As Boolean
    Public SiteLogoVerticalTiling As Boolean
    Public MenuDetails As New clsMenuDetails
    Public SiteCssDetails As New clsSiteCssDetails
    Public SiteWidth As String
    Public SiteAlign As String
    Public ContainerWidth1 As String
    Public ContainerWidth2 As String
    Public ContainerWidth3 As String
    Public MetaDescription As String
    Public MetaKeywords As String
    Public MetaAuthor As String
    Public MetaCopyright As String
    Public MetaRobots As String

    Public Sub New(ByVal Index As Integer, ByVal PageId As Integer)

        Dim oDO As New iCDataManager.iCDataObject
        Dim oCrypto As New clsCrypto
        Dim ED As String = oCrypto.Encrypt(AppSettings.Get("DataSource"))
        Dim EC As String = oCrypto.Encrypt(AppSettings.Get("ConnectionString"))
        Dim sAlias As String = AppSettings.Get("SiteAlias")
        Dim dsSites As New DataSet
        Dim sError As String

        ' Get data from sit_sites
        If Not oDO.GetDataSet("sit_sites", "sit_alias = '" & sAlias & "' AND sit_deleted = 0", "", sError, ED, EC, dsSites) Then
            System.Diagnostics.Debug.WriteLine(sError)
        End If

        If dsSites.Tables(0).Rows.Count > 0 Then
            ' If there is a site called (SiteAlias)...
            Dim drSites As DataRow = dsSites.Tables(0).Rows(0)
            Me.SiteId = drSites("sit_id")
            Me.SiteName = drSites("sit_name")
            Me.AlwaysShowEditButton = IIf(IsDBNull(drSites("sit_alwaysshoweditbutton")), False, drSites("sit_alwaysshoweditbutton"))
            Me.SiteCSS = IIf(IsDBNull(drSites("sit_css")), "", drSites("sit_css"))
            Me.SiteLogo = IIf(IsDBNull(drSites("sit_logo")), "", drSites("sit_logo"))
            Me.SiteStartPage = IIf(IsDBNull(drSites("sit_startpage")), 0, drSites("sit_startpage"))
            Me.Language = IIf(IsDBNull(drSites("lng_id")), 1, drSites("lng_id"))
            Me.SiteLogoHref = IIf(IsDBNull(drSites("sit_logohref")), "", drSites("sit_logohref"))
            Me.SiteFooterTextLeft = IIf(IsDBNull(drSites("sit_footertextleft")), "", drSites("sit_footertextleft"))
            Me.SiteFooterTextContent = IIf(IsDBNull(drSites("sit_footertextcontent")), "", drSites("sit_footertextcontent"))
            Me.SiteFooterTextRight = IIf(IsDBNull(drSites("sit_footertextright")), "", drSites("sit_footertextright"))
            Me.SiteShowFooter = IIf(IsDBNull(drSites("sit_showfooter")), False, drSites("sit_showfooter"))
            Me.SiteContentAdjust = IIf(IsDBNull(drSites("sit_contentadjust")), 0, drSites("sit_contentadjust"))
            Me.SiteSoftDelete = IIf(drSites("sit_softdelete") = 0, False, True)
            Me.Color = IIf(IsDBNull(drSites("sit_color")), "", drSites("sit_color"))
            Me.SiteLogoHorizotalAlign = IIf(IsDBNull(drSites("sit_logohorizontalalign")), "", drSites("sit_logohorizontalalign"))
            Me.SiteLogoVerticalAlign = IIf(IsDBNull(drSites("sit_logoverticalalign")), "", drSites("sit_logoverticalalign"))
            Me.SiteLogoHorizotalTiling = IIf(IsDBNull(drSites("sit_logohorizontaltiling")), False, drSites("sit_logohorizontaltiling"))
            Me.SiteLogoVerticalTiling = IIf(IsDBNull(drSites("sit_logoverticaltiling")), False, drSites("sit_logoverticaltiling"))

            ' Css Head Variables
            Me.SiteCssDetails.HeadFamily = IIf(IsDBNull(drSites("sit_cssheadfamily")), "", drSites("sit_cssheadfamily"))
            Me.SiteCssDetails.HeadSize = IIf(IsDBNull(drSites("sit_cssheadsize")), "", drSites("sit_cssheadsize"))
            Me.SiteCssDetails.HeadWeight = IIf(IsDBNull(drSites("sit_cssheadweight")), "", drSites("sit_cssheadweight"))
            Me.SiteCssDetails.HeadColor = IIf(IsDBNull(drSites("sit_cssheadcolor")), "", drSites("sit_cssheadcolor"))

            ' Css SubHead Variables
            Me.SiteCssDetails.SubHeadFamily = IIf(IsDBNull(drSites("sit_csssubheadfamily")), "", drSites("sit_csssubheadfamily"))
            Me.SiteCssDetails.SubHeadSize = IIf(IsDBNull(drSites("sit_csssubheadsize")), "", drSites("sit_csssubheadsize"))
            Me.SiteCssDetails.SubHeadWeight = IIf(IsDBNull(drSites("sit_csssubheadweight")), "", drSites("sit_csssubheadweight"))
            Me.SiteCssDetails.SubHeadColor = IIf(IsDBNull(drSites("sit_csssubheadcolor")), "", drSites("sit_csssubheadcolor"))

            ' Css SubSubHead Variables
            Me.SiteCssDetails.SubSubHeadFamily = IIf(IsDBNull(drSites("sit_csssubsubheadfamily")), "", drSites("sit_csssubsubheadfamily"))
            Me.SiteCssDetails.SubSubHeadSize = IIf(IsDBNull(drSites("sit_csssubsubheadsize")), "", drSites("sit_csssubsubheadsize"))
            Me.SiteCssDetails.SubSubHeadWeight = IIf(IsDBNull(drSites("sit_csssubsubheadweight")), "", drSites("sit_csssubsubheadweight"))
            Me.SiteCssDetails.SubSubHeadColor = IIf(IsDBNull(drSites("sit_csssubsubheadcolor")), "", drSites("sit_csssubsubheadcolor"))

            ' Css Normal Variables
            Me.SiteCssDetails.NormalFamily = IIf(IsDBNull(drSites("sit_cssnormalfamily")), "", drSites("sit_cssnormalfamily"))
            Me.SiteCssDetails.NormalSize = IIf(IsDBNull(drSites("sit_cssnormalsize")), "", drSites("sit_cssnormalsize"))
            Me.SiteCssDetails.NormalWeight = IIf(IsDBNull(drSites("sit_cssnormalweight")), "", drSites("sit_cssnormalweight"))
            Me.SiteCssDetails.NormalColor = IIf(IsDBNull(drSites("sit_cssnormalcolor")), "", drSites("sit_cssnormalcolor"))

            ' Css Button Variables
            Me.SiteCssDetails.ButtonBorderSize = IIf(IsDBNull(drSites("sit_cssbuttonbordersize")), "", drSites("sit_cssbuttonbordersize"))
            Me.SiteCssDetails.ButtonBorderColor = IIf(IsDBNull(drSites("sit_cssbuttonbordercolor")), "", drSites("sit_cssbuttonbordercolor"))
            Me.SiteCssDetails.ButtonBackColor = IIf(IsDBNull(drSites("sit_cssbuttonbackcolor")), "", drSites("sit_cssbuttonbackcolor"))
            Me.SiteCssDetails.ButtonForeColor = IIf(IsDBNull(drSites("sit_cssbuttonforecolor")), "", drSites("sit_cssbuttonforecolor"))
            Me.SiteCssDetails.ButtonTextAlign = IIf(IsDBNull(drSites("sit_cssbuttontextalign")), "", drSites("sit_cssbuttontextalign"))
            Me.SiteCssDetails.ButtonFontFamily = IIf(IsDBNull(drSites("sit_cssbuttonfontfamily")), "", drSites("sit_cssbuttonfontfamily"))
            Me.SiteCssDetails.ButtonFontSize = IIf(IsDBNull(drSites("sit_cssbuttonfontsize")), "", drSites("sit_cssbuttonfontsize"))
            Me.SiteCssDetails.ButtonFontWeight = IIf(IsDBNull(drSites("sit_cssbuttonfontweight")), "", drSites("sit_cssbuttonfontweight"))

            ' Css Hr Variables
            Me.SiteCssDetails.HrColor = IIf(IsDBNull(drSites("sit_csshrcolor")), "", drSites("sit_csshrcolor"))
            Me.SiteCssDetails.HrHeight = IIf(IsDBNull(drSites("sit_csshrheight")), "", drSites("sit_csshrheight"))
            Me.SiteCssDetails.HrAlign = IIf(IsDBNull(drSites("sit_csshralign")), "", drSites("sit_csshralign"))

            ' Site, Meta Variables
            Me.SiteWidth = IIf(IsDBNull(drSites("sit_sitewidth")), "n/a", drSites("sit_sitewidth"))
            Me.SiteAlign = IIf(IsDBNull(drSites("sit_sitealign")), "left", drSites("sit_sitealign"))
            Me.ContainerWidth1 = IIf(IsDBNull(drSites("sit_containerwidth1")), "170", drSites("sit_containerwidth1"))
            Me.ContainerWidth2 = IIf(IsDBNull(drSites("sit_containerwidth2")), "600", drSites("sit_containerwidth2"))
            Me.ContainerWidth3 = IIf(IsDBNull(drSites("sit_containerwidth3")), "170", drSites("sit_containerwidth3"))
            Me.MetaDescription = IIf(IsDBNull(drSites("sit_metadescription")), "", drSites("sit_metadescription"))
            Me.MetaKeywords = IIf(IsDBNull(drSites("sit_metakeywords")), "", drSites("sit_metakeywords"))
            Me.MetaAuthor = IIf(IsDBNull(drSites("sit_metaauthor")), "", drSites("sit_metaauthor"))
            Me.MetaCopyright = IIf(IsDBNull(drSites("sit_metacopyright")), "", drSites("sit_metacopyright"))
            Me.MetaRobots = IIf(IsDBNull(drSites("sit_metarobots")), "", drSites("sit_metarobots"))


            Dim oMultiQueryList As New clsMultiQueryList
            oMultiQueryList.AddQuery("lgt_languagetext", "lng_id = " & Me.Language & " AND lgt_location = 'iConsulting.iCMServer' AND lgt_deleted = 0", "", oMultiQueryList.DataSet)
            oMultiQueryList.AddQuery("pag_page", "sit_id = " & Me.SiteId & " AND pag_deleted = 0", "pag_order", oMultiQueryList.DataSet)
            oMultiQueryList.AddQuery("mde_moduledefinitions", "sit_id = " & Me.SiteId & " AND mde_deleted = 0", "", oMultiQueryList.DataSet)
            oMultiQueryList.AddQuery("men_menu", "sit_id = " & Me.SiteId & " AND men_deleted = 0", "", oMultiQueryList.DataSet)

            Dim dsMulti As New DataSet
            If Not oDO.GetMultiDataSet(oMultiQueryList.DataSet, sError, ED, EC, dsMulti) Then
                'System.Diagnostics.Debug.WriteLine(sError)
            End If

            Dim drLanguage As DataRow
            Dim oLanguageSettings As clsLanguageSettings
            For Each drLanguage In dsMulti.Tables("lgt_languagetext").Rows
                oLanguageSettings = New clsLanguageSettings
                oLanguageSettings.Phrase = drLanguage("lgt_phrase")
                oLanguageSettings.Text = drLanguage("lgt_text")
                Me.LanguageText.Add(oLanguageSettings)
            Next

            Dim drMenu As DataRow
            drMenu = dsMulti.Tables("men_menu").Rows(0)
            Me.MenuDetails.MenuAlign = IIf(IsDBNull(drMenu("men_menualign")), "", drMenu("men_menualign"))
            Me.MenuDetails.MenuFade = IIf(IsDBNull(drMenu("men_menufade")), False, drMenu("men_menufade"))
            Me.MenuDetails.MenuDurance = IIf(IsDBNull(drMenu("men_menufadedurance")), "", drMenu("men_menufadedurance"))
            Me.MenuDetails.MenuOffset = IIf(IsDBNull(drMenu("men_menuoffset")), 0, drMenu("men_menuoffset"))
            Me.MenuDetails.MenuTop = IIf(IsDBNull(drMenu("men_menutop")), 0, drMenu("men_menutop"))
            Me.MenuDetails.MenuLeft = IIf(IsDBNull(drMenu("men_menuleft")), 0, drMenu("men_menuleft"))
            Me.MenuDetails.MenuForeColor1 = IIf(IsDBNull(drMenu("men_menuforecolor1")), "", drMenu("men_menuforecolor1"))
            Me.MenuDetails.MenuBackColor1 = IIf(IsDBNull(drMenu("men_menubackcolor1")), "", drMenu("men_menubackcolor1"))
            Me.MenuDetails.MenuForeColor2 = IIf(IsDBNull(drMenu("men_menuforecolor2")), "", drMenu("men_menuforecolor2"))
            Me.MenuDetails.MenuBackColor2 = IIf(IsDBNull(drMenu("men_menubackcolor2")), "", drMenu("men_menubackcolor2"))
            Me.MenuDetails.MenuOverForeColor1 = IIf(IsDBNull(drMenu("men_menuoverforecolor1")), "", drMenu("men_menuoverforecolor1"))
            Me.MenuDetails.MenuOverBackColor1 = IIf(IsDBNull(drMenu("men_menuoverbackcolor1")), "", drMenu("men_menuoverbackcolor1"))
            Me.MenuDetails.MenuOverForeColor2 = IIf(IsDBNull(drMenu("men_menuoverforecolor2")), "", drMenu("men_menuoverforecolor2"))
            Me.MenuDetails.MenuOverBackColor2 = IIf(IsDBNull(drMenu("men_menuoverbackcolor2")), "", drMenu("men_menuoverbackcolor2"))
            Me.MenuDetails.MenuFont = IIf(IsDBNull(drMenu("men_menufont")), "", drMenu("men_menufont"))
            Me.MenuDetails.MenuBold1 = IIf(IsDBNull(drMenu("men_menubold1")), False, drMenu("men_menubold1"))
            Me.MenuDetails.MenuOverBold1 = IIf(IsDBNull(drMenu("men_menuoverbold1")), False, drMenu("men_menuoverbold1"))
            Me.MenuDetails.MenuBold2 = IIf(IsDBNull(drMenu("men_menubold2")), False, drMenu("men_menubold2"))
            Me.MenuDetails.MenuOverBold2 = IIf(IsDBNull(drMenu("men_menuoverbold2")), False, drMenu("men_menuoverbold2"))
            Me.MenuDetails.MenuPlacement = IIf(IsDBNull(drMenu("men_placement")), "center", drMenu("men_placement"))
            Me.MenuDetails.MenuBetween = IIf(IsDBNull(drMenu("men_between")), 10, drMenu("men_between"))
            Me.MenuDetails.MenuWait = IIf(IsDBNull(drMenu("men_wait")), 0, drMenu("men_wait"))
            Me.MenuDetails.MenuLevel1BorderX = IIf(IsDBNull(drMenu("men_menulevel1borderx")), False, drMenu("men_menulevel1borderx"))
            Me.MenuDetails.MenuLevel1BorderY = IIf(IsDBNull(drMenu("men_menulevel1bordery")), False, drMenu("men_menulevel1bordery"))
            Me.MenuDetails.MenuLevel2BorderX = IIf(IsDBNull(drMenu("men_menulevel2borderx")), False, drMenu("men_menulevel2borderx"))
            Me.MenuDetails.MenuLevel2BorderY = IIf(IsDBNull(drMenu("men_menulevel2bordery")), False, drMenu("men_menulevel2bordery"))

            Me.MenuDetails.MenuRoundBorder = IIf(IsDBNull(drMenu("men_menuroundborder")), False, drMenu("men_menuroundborder"))
            Me.MenuDetails.MenuFontSize1 = IIf(IsDBNull(drMenu("men_menufontsize1")), "", drMenu("men_menufontsize1"))
            Me.MenuDetails.MenuOverFontSize1 = IIf(IsDBNull(drMenu("men_menuoverfontsize1")), "", drMenu("men_menuoverfontsize1"))
            Me.MenuDetails.MenuFontSize2 = IIf(IsDBNull(drMenu("men_menufontsize2")), "", drMenu("men_menufontsize2"))
            Me.MenuDetails.MenuOverFontSize2 = IIf(IsDBNull(drMenu("men_menuoverfontsize2")), "", drMenu("men_menuoverfontsize2"))
            Me.MenuDetails.MenuBorderColor1 = IIf(IsDBNull(drMenu("men_menubordercolor1")), "", drMenu("men_menubordercolor1"))
            Me.MenuDetails.MenuBorderColor2 = IIf(IsDBNull(drMenu("men_menubordercolor2")), "", drMenu("men_menubordercolor2"))

            Me.MenuDetails.MenuMultiplicator = IIf(IsDBNull(drMenu("men_multiplicator")), Val("9.5"), Val(drMenu("men_multiplicator")))
            Me.MenuDetails.MenuTextAlign1 = IIf(IsDBNull(drMenu("men_headtextalign")), "left", drMenu("men_headtextalign"))
            Me.MenuDetails.MenuTextAlign2 = IIf(IsDBNull(drMenu("men_subtextalign")), "left", drMenu("men_subtextalign"))
            Me.MenuDetails.MenuWidth1 = IIf(IsDBNull(drMenu("men_headwidth")), "n/a", drMenu("men_headwidth"))
            Me.MenuDetails.MenuWidth2 = IIf(IsDBNull(drMenu("men_subwidth")), "n/a", drMenu("men_subwidth"))
            Me.MenuDetails.MenuHeight1 = IIf(IsDBNull(drMenu("men_headheight")), "18", drMenu("men_headheight"))
            Me.MenuDetails.MenuHeight2 = IIf(IsDBNull(drMenu("men_subheight")), "18", drMenu("men_subheight"))

            Dim drPage As DataRow
            Dim objPSD As clsPageStripDetails
            For Each drPage In dsMulti.Tables("pag_page").Rows
                objPSD = New clsPageStripDetails
                objPSD.PageId = drPage("pag_id")
                objPSD.PageParentId = drPage("pag_pageparentid")
                objPSD.PageName = drPage("pag_name")
                objPSD.PageOrder = drPage("pag_order")
                objPSD.AuthorizedRoles = drPage("pag_authorizedroles")
                objPSD.IsVisible = drPage("pag_isvisible")
                Me.DesktopPages.Add(objPSD)
                If drPage("pag_showmobile") Then
                    objPSD = New iCMServer.clsPageStripDetails
                    objPSD.PageId = drPage("pag_id")
                    objPSD.PageParentId = drPage("pag_pageparentid")
                    objPSD.PageName = drPage("pag_name")
                    objPSD.AuthorizedRoles = drPage("pag_authorizedroles")
                    objPSD.IsVisible = drPage("pag_isvisible")
                    Me.MobilePages.Add(objPSD)
                End If
            Next

            If PageId <> 0 Then
                Me.ActivePage.PageId = PageId
            Else
                If Me.ActivePage.PageId = 0 Then
                    If Me.SiteStartPage = 0 Then
                        Me.ActivePage.PageId = CType(Me.DesktopPages(0), clsPageStripDetails).PageId
                    Else
                        Me.ActivePage.PageId = Me.SiteStartPage
                    End If
                End If
            End If

            Dim dsModules As New DataSet
            Dim drModules As DataRow
            ' Get data from mod_modules
            If Not oDO.GetDataSet("mod_modules", "sit_id = " & Me.SiteId & " AND pag_id = " & Me.ActivePage.PageId & " AND mod_deleted = 0 OR sit_id = " & Me.SiteId & " AND mod_secure = 1 AND mod_deleted = 0", "mod_order", sError, ED, EC, dsModules) Then
                'System.Diagnostics.Debug.WriteLine(sError)
            End If

            Dim drModulesDef As DataRow()
            Dim objMS As clsModuleSettings
            For Each drModules In dsModules.Tables(0).Rows
                drModulesDef = dsMulti.Tables("mde_moduledefinitions").Select("mde_id='" & drModules("mde_id") & "'")
                If drModulesDef.Length > 0 Then
                    objMS = New clsModuleSettings
                    objMS.ModuleId = drModules("mod_id")
                    objMS.ModuleDefId = drModules("mde_id")
                    objMS.PageId = drModules("pag_id")
                    objMS.Language = IIf(IsDBNull(drModules("lng_id")), 0, drModules("lng_id"))
                    objMS.CacheTime = drModules("mod_cachetime")
                    objMS.ModuleOrder = drModules("mod_order")
                    objMS.ModuleFieldName = drModules("mod_panename")
                    objMS.ModuleTitle = drModules("mod_title")
                    objMS.AuthorizedEditRoles = drModules("mod_authorizededitroles")
                    objMS.ShowMobile = drModules("mod_showmobile")
                    objMS.DesktopSrc = IIf(IsDBNull(drModulesDef(0)("mde_desktopsrc")), "", drModulesDef(0)("mde_desktopsrc"))
                    objMS.MobileSrc = IIf(IsDBNull(drModulesDef(0)("mde_mobilesrc")), "", drModulesDef(0)("mde_mobilesrc"))
                    objMS.Alignment = IIf(IsDBNull(drModules("mod_alignment")), "", drModules("mod_alignment"))
                    objMS.Color = IIf(IsDBNull(drModules("mod_color")), "", drModules("mod_color"))
                    objMS.Border = IIf(IsDBNull(drModules("mod_border")), "", drModules("mod_border"))
                    objMS.EditSrc = IIf(IsDBNull(drModules("mod_editsrc")), "", drModules("mod_editsrc"))
                    objMS.IconFile = IIf(IsDBNull(drModules("mod_iconfile")), "", drModules("mod_iconfile"))
                    objMS.EditModuleIcon = IIf(IsDBNull(drModules("mod_editmoduleicon")), "", drModules("mod_editmoduleicon"))
                    objMS.Secure = IIf(IsDBNull(drModules("mod_secure")), False, drModules("mod_secure"))
                    objMS.AllPages = IIf(IsDBNull(drModules("mod_allpages")), False, drModules("mod_allpages"))
                    objMS.ShowTitle = drModules("mod_showtitle")
                    objMS.Personalize = IIf(IsDBNull(drModules("mod_personalize")), 0, drModules("mod_personalize"))
                    objMS.FriendlyName = IIf(IsDBNull(drModules("mod_friendlyname")), "", drModules("mod_friendlyname"))
                    objMS.SkinPath = IIf(IsDBNull(drModules("mod_skinpath")), "none", drModules("mod_skinpath"))
                    objMS.Hidden = drModules("mod_hidden")
                    Me.ActivePage.Modules.Add(objMS)
                End If
            Next

            Dim drActivePage As DataRow()
            drActivePage = dsMulti.Tables("pag_page").Select("pag_id = '" & Me.ActivePage.PageId & "'")
            Me.ActivePage.Index = Index
            Me.ActivePage.PageId = drActivePage(0)("pag_id")
            Me.ActivePage.Language = IIf(IsDBNull(drActivePage(0)("lng_id")), 0, drActivePage(0)("lng_id"))
            Me.ActivePage.PageParentId = drActivePage(0)("pag_pageparentid")
            Me.ActivePage.PageTop = drActivePage(0)("pag_top")
            Me.ActivePage.PageHeight = drActivePage(0)("pag_height")
            Me.ActivePage.PagePictureHorizontalTiling = IIf(IsDBNull(drActivePage(0)("pag_picturehorizontaltiling")), 0, drActivePage(0)("pag_picturehorizontaltiling"))
            Me.ActivePage.PagePictureVerticalTiling = IIf(IsDBNull(drActivePage(0)("pag_pictureverticaltiling")), 0, drActivePage(0)("pag_pictureverticaltiling"))
            Me.ActivePage.PageMinimizer = IIf(IsDBNull(drActivePage(0)("pag_minimizer")), 0, drActivePage(0)("pag_minimizer"))
            Me.ActivePage.PageBackColor = drActivePage(0)("pag_backcolor")
            Me.ActivePage.PagePictureId = drActivePage(0)("pag_pictureid")
            Me.ActivePage.PagePictureHref = drActivePage(0)("pag_picturehref")
            Me.ActivePage.PagePictureHorizotalAlign = drActivePage(0)("pag_picturehorizontalalign")
            Me.ActivePage.PagePictureVerticalAlign = drActivePage(0)("pag_pictureverticalalign")
            Me.ActivePage.PageName = drActivePage(0)("pag_name")
            Me.ActivePage.PageOrder = drActivePage(0)("pag_order")
            Me.ActivePage.MobilePageName = drActivePage(0)("pag_mobilename")
            Me.ActivePage.AuthorizedRoles = drActivePage(0)("pag_authorizedroles")
            Me.ActivePage.ShowMobile = IIf(IsDBNull(drActivePage(0)("pag_showmobile")), False, drActivePage(0)("pag_showmobile"))
            Me.ActivePage.LeftModuleFieldWidth = IIf(IsDBNull(drActivePage(0)("pag_leftmodulefieldwidth")), "", drActivePage(0)("pag_leftmodulefieldwidth"))
            Me.ActivePage.ContentModuleFieldWidth = IIf(IsDBNull(drActivePage(0)("pag_contentmodulefieldwidth")), "", drActivePage(0)("pag_contentmodulefieldwidth"))
            Me.ActivePage.RightModuleFieldWidth = IIf(IsDBNull(drActivePage(0)("pag_rightmodulefieldwidth")), "", drActivePage(0)("pag_rightmodulefieldwidth"))
            Me.ActivePage.ContentAlignCenter = IIf(IsDBNull(drActivePage(0)("pag_contentalign")), False, drActivePage(0)("pag_contentalign"))
            Me.ActivePage.IsVisible = IIf(IsDBNull(drActivePage(0)("pag_isvisible")), False, drActivePage(0)("pag_isvisible"))
            Me.ActivePage.Level = IIf(IsDBNull(drActivePage(0)("pag_level")), 0, drActivePage(0)("pag_level"))
            Me.ActivePage.IconFile = IIf(IsDBNull(drActivePage(0)("pag_iconfile")), "", drActivePage(0)("pag_iconfile"))
            Me.ActivePage.AdminPageIcon = IIf(IsDBNull(drActivePage(0)("pag_adminpageicon")), "", drActivePage(0)("pag_adminpageicon"))
            Me.ActivePage.HasChildren = IIf(IsDBNull(drActivePage(0)("pag_haschildren")), False, drActivePage(0)("pag_haschildren"))

        Else
            ' If there is no site?
        End If

    End Sub

End Class



