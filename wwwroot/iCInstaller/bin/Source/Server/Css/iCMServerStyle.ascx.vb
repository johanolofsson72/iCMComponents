Public Class iCMServerStyle
    Inherits System.Web.UI.UserControl

    Public ViewSource As [String] = Nothing
    Protected WithEvents StyleContainer As System.Web.UI.WebControls.PlaceHolder
    Public ViewType As [String] = Nothing

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        Render_Stylecheet()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub Render_Stylecheet()
        Dim oSite As clsSiteSettings = CType(System.Web.HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
        Dim Content As String

        Content += "<title>" & oSite.SiteName & "</title>" & vbCrLf
        Content += "<meta name=""description"" content=""" & oSite.MetaDescription & """>" & vbCrLf
        Content += "<meta name=""keywords"" content=""" & oSite.MetaKeywords & """>" & vbCrLf
        Content += "<meta name=""author"" content=""" & oSite.MetaAuthor & """>" & vbCrLf
        Content += "<meta name=""copyright"" content=""" & oSite.MetaCopyright & """>" & vbCrLf
        Content += "<meta name=""robots"" content=""" & oSite.MetaRobots & """>" & vbCrLf

        Content += "<style>" & vbCrLf
        'Content += ".SelectedTab {font-family: Verdana, Helvetica, sans-serif;font-size: 10px;color:royalblue;text-decoration:none;font-weight: normal}" & vbCrLf
        'Content += ".OtherTabs {font-family: Verdana, Helvetica, sans-serif;font-size: 10px;color:royalblue;text-decoration:none;font-weight: normal}" & vbCrLf
        'Content += "A.OtherTabs:link{font-family: Verdana, Helvetica, sans-serif;font-size: 10px;color:black;text-decoration:none;font-weight: normal}" & vbCrLf
        'Content += "A.OtherTabs:visited{font-family: Verdana, Helvetica, sans-serif;font-size: 10px;color:black;text-decoration:none;font-weight: normal}" & vbCrLf
        'Content += "A.OtherTabs:active{font-family: Verdana, Helvetica, sans-serif;font-size: 10px;color:black;text-decoration:none;font-weight: normal}" & vbCrLf
        'Content += "A.OtherTabs:hover{font-family: Verdana, Helvetica, sans-serif; font-size: 10px;color:black;text-decoration:none;font-weight: normal}" & vbCrLf
        'Content += ".StandardText1{font-family:Verdana, Helvetica, sans-serif;font-size:x-small;font-style:normal;font-variant:normal;font-weight:normal;color:gray;}" & vbCrLf
        Content += ".Head{font-family: " & oSite.SiteCssDetails.HeadFamily & ", Verdana, Helvetica, sans-serif;font-size: " & oSite.SiteCssDetails.HeadSize & "px;font-weight: " & oSite.SiteCssDetails.HeadWeight & ";color: " & oSite.SiteCssDetails.HeadColor & ";}" & vbCrLf
        Content += ".SubHead{font-family: " & oSite.SiteCssDetails.SubHeadFamily & ", Verdana, Helvetica, sans-serif;font-size:  " & oSite.SiteCssDetails.SubHeadSize & "px;font-weight: " & oSite.SiteCssDetails.SubHeadWeight & ";color: " & oSite.SiteCssDetails.SubHeadColor & ";}" & vbCrLf
        Content += ".SubSubHead {font-family: " & oSite.SiteCssDetails.SubSubHeadFamily & ", Verdana, Helvetica, sans-serif;font-size:  " & oSite.SiteCssDetails.SubSubHeadSize & "px;font-weight: " & oSite.SiteCssDetails.SubSubHeadWeight & ";color: " & oSite.SiteCssDetails.SubSubHeadColor & ";}" & vbCrLf
        Content += ".Normal{font-family: " & oSite.SiteCssDetails.NormalFamily & ", Verdana, Helvetica, sans-serif; font-size: " & oSite.SiteCssDetails.NormalSize & "px;font-weight: " & oSite.SiteCssDetails.NormalWeight & ";line-height: 12px;color: " & oSite.SiteCssDetails.NormalColor & "}" & vbCrLf
        Content += ".iCWebControls{background-color: GhostWhite;border-color: RoyalBlue;font-size: xx-small;font-family: Verdana;height: 21px;}" & vbCrLf
        Content += ".iCWebControlsII{border-right: " & oSite.SiteCssDetails.ButtonBorderColor & " " & oSite.SiteCssDetails.ButtonBorderSize & "px solid;border-top: " & oSite.SiteCssDetails.ButtonBorderColor & " " & oSite.SiteCssDetails.ButtonBorderSize & "px solid;font-weight: " & oSite.SiteCssDetails.ButtonFontWeight & ";font-size: " & oSite.SiteCssDetails.ButtonFontSize & "px;border-left: " & oSite.SiteCssDetails.ButtonBorderColor & " " & oSite.SiteCssDetails.ButtonBorderSize & "px solid;border-bottom: " & oSite.SiteCssDetails.ButtonBorderColor & " " & oSite.SiteCssDetails.ButtonBorderSize & "px solid;font-family: " & oSite.SiteCssDetails.ButtonFontFamily & ", Verdana;background-color: " & oSite.SiteCssDetails.ButtonBackColor & ";color: " & oSite.SiteCssDetails.ButtonForeColor & ";text-align: " & oSite.SiteCssDetails.ButtonTextAlign & ";}" & vbCrLf
        Content += ".Button{border-right: #203470 thin solid;border-top: #4169e1 thin solid;font-size: xx-small;border-left: #4169e1 thin solid;border-bottom: #203470 thin solid;font-family: Verdana;background-color: white;text-align: center;}" & vbCrLf
        Content += "HR {color: " & oSite.SiteCssDetails.HrColor & ";height:" & oSite.SiteCssDetails.HrHeight & "pt;text-align:" & oSite.SiteCssDetails.HrAlign & "}" & vbCrLf
        Content += "cursor:default;" & vbCrLf
        Content += "behavior:url(#default#clientcaps) " & vbCrLf
        Content += ".normaltext { font: 8pt Verdana, Arial; }" & vbCrLf
        Content += "td { font-family:  font face=Sylfaen;  font-size: 12px;}" & vbCrLf
        Content += "toolbarCtrls {background-color: buttonface;height: 25px; left: 0px; position: relative; top: 0px}" & vbCrLf
        Content += ".OptionItems{background-color: buttonface; }" & vbCrLf
        Content += ".menubuttons{border: 0px ;padding:0px;margin:0px;}" & vbCrLf
        Content += ".toolz{border: 0px ;padding:0px;margin:0px;}" & vbCrLf
        Content += ".h3 {font: 10px, sans-serif;}" & vbCrLf
        Content += ".h4 {font:12.5px, sans-serif;}" & vbCrLf
        Content += "BODY{BACKGROUND-COLOR: white;FONT-FAMILY: Verdana, Helvetica, sans-serif;FONT-SIZE: .8em;FONT-WEIGHT: normal;LETTER-SPACING: normal;TEXT-TRANSFORM: none;WORD-SPACING: normal}" & vbCrLf
        Content += "H1, H2, H3, H4, H5, TH, THEAD, TFOOT {COLOR: #003366;" & vbCrLf
        Content += "H1 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size:	2em;font-weight:	700;font-style:	normal;text-decoration:	none;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;}	" & vbCrLf
        Content += "H2 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size:	1.75em;font-weight:	700;font-style:	normal;text-decoration:	none;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;}" & vbCrLf
        Content += "H3 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size:	1.58em;font-weight:	500;font-style:	normal;text-decoration:	none;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;}" & vbCrLf
        Content += "H4 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size:	1.33em;font-weight:	500;text-decoration:	none;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;}" & vbCrLf
        Content += "H5, DT {font-family: Verdana, Arial, Helvetica, sans-serif;font-size:	1em;font-weight:	700;font-style:	normal;text-decoration:	none;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;}" & vbCrLf
        Content += "H6 {font-family: Verdana, Arial, Helvetica, sans-serif;font-size:	.8em;font-weight:	700;font-style:	normal;text-decoration:	none;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;}" & vbCrLf
        Content += "TFOOT, THEAD {font-size:	1em;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;font-family: Arial, Helvetica, sans-serif;}" & vbCrLf
        Content += "TH {vertical-align:	baseline;font-size:	1em;font-weight:	bold;word-spacing:	normal;letter-spacing:	normal;text-transform:	none;font-family: Arial, Helvetica, sans-serif;}" & vbCrLf

        Content += "A:link {text-decoration:	none;color:	" & oSite.SiteCssDetails.NormalColor & ";}" & vbCrLf
        Content += "A:visited {text-decoration:	none;color:	" & oSite.SiteCssDetails.NormalColor & ";}" & vbCrLf
        Content += "A:active {text-decoration:	none;color:	" & oSite.SiteCssDetails.NormalColor & ";}" & vbCrLf
        Content += "A:hover {text-decoration:	underline;color:	" & oSite.SiteCssDetails.NormalColor & ";}" & vbCrLf

        Content += "SMALL {font-size:	.7em;}" & vbCrLf
        Content += "BIG {font-size:	1.17em;}" & vbCrLf
        Content += "BLOCKQUOTE, PRE	{font-family:	Courier New, monospace;}" & vbCrLf
        Content += "UL LI	{list-style-type:	square ;}" & vbCrLf
        Content += "UL LI LI {list-style-type:	disc;}" & vbCrLf
        Content += "UL LI LI LI {list-style-type:	circle;}" & vbCrLf
        Content += "OL LI {list-style-type:	decimal;}" & vbCrLf
        Content += "OL OL LI {list-style-type:	lower-alpha;}" & vbCrLf
        Content += "OL OL OL LI {list-style-type:	lower-roman;}" & vbCrLf
        'Content += "IMG {margin-top: 5px;margin-left: 10px;margin-right: 10px;}" & vbCrLf
        Content += ".Grid{border-bottom: #203470 1pt solid; BORDER-TOP: #4169E1 1pt solid;overflow:hidden;BACKGROUND:window;font-size: xx-small;font-family: Verdana;background-color: white;Width:100%}" & vbCrLf
        Content += ".GridHead{border-top: 1px solid;font-weight: bold;font-size: xx-small;border-left: #000000;border-bottom: darkgray 4px solid;font-family: Verdana;background-color: #F1F1F1;}" & vbCrLf
        Content += ".GridHead TD {BACKGROUND-COLOR:#F1F1F1;font-size: xx-small;border:thin solid 1;border-left:#000000; font-family: Verdana;}" & vbCrLf
        Content += ".GridHead A:link{text-decoration:	none;color:	black;}" & vbCrLf
        Content += ".GridHead A:visited{text-decoration:	none;color:	black;}" & vbCrLf
        Content += ".GridHead A:hover{text-decoration:	none;color:	black;}" & vbCrLf
        Content += ".webfx-tree-container {margin: 0px;padding: 0px;font: icon;white-space: nowrap;}" & vbCrLf
        Content += ".webfx-tree-item {padding: 0px;margin: 0px;font: icon;color: WindowText;white-space: nowrap;height: 16px;}" & vbCrLf
        Content += ".webfx-tree-item a, .webfx-tree-item a:active, .webfx-tree-item a:hover {margin-left: 3px;padding: 0px 2px 1px 2px;}" & vbCrLf
        Content += ".webfx-tree-item a {color: black;text-decoration: none;}" & vbCrLf
        Content += ".webfx-tree-item a:hover {color: #3b5159;text-decoration: underline;}" & vbCrLf
        Content += ".webfx-tree-item a:active {background: #3b5159;color: #FFFFFF;text-decoration: none;}" & vbCrLf
        Content += ".webfx-tree-item img {vertical-align: middle;border: 2px;}" & vbCrLf
        Content += ".webfx-tree-icon {width: 16px;height: 16px;}" & vbCrLf
        Content += "</style>" & vbCrLf

        StyleContainer.Controls.Add(New LiteralControl(Content))
    End Sub

End Class
