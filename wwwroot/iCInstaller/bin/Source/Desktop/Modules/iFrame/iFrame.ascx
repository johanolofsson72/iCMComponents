<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="iFrame.ascx.vb" Inherits="iConsulting.iCMServer.Modules.iFrame.iFrame" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/iFrame/iFrameEdit.aspx" Phrase="iframe_edit"
	Location="iConsulting.iCMServer.Modules.iFrame" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
<asp:Literal id="LiteralIFrame" runat="server"></asp:Literal>
<asp:Literal id="LiteralIFrameSize" runat="server"></asp:Literal>
</div>
