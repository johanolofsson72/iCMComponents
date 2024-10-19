<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Search.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Search.Search" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SITE:TITLE id="Title2" EditText="" Location="" Phrase="" EditUrl="" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE WIDTH="100%" BORDER="0" CELLSPACING="1" CELLPADDING="1">
		<TR>
			<TD align="center"><asp:TextBox id="txtSearch" runat="server"></asp:TextBox>
				<asp:Button id="btnSearch" runat="server" Text="btnSearch"></asp:Button></TD>
		</TR>
		<TR>
			<TD align="center" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid" bgcolor=white><asp:PlaceHolder id="ResultHolder" runat="server"></asp:PlaceHolder></TD>
		</TR>
	</TABLE>
</div>
<asp:PlaceHolder id="ScriptHolder" runat="server"></asp:PlaceHolder>

