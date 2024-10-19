<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Sites.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Sites.Sites" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<Site:title runat="server" id="Title2" />
<div id="Minimizer" runat="server">
	<table cellSpacing="1" cellPadding="2" border="0" width="98%" align="left">
		<tr>
			<td width="1%"></td>
			<td class="SubSubHead" align="left" colspan="2">
				<asp:Label id="lblHeader" runat="server">lblHeader</asp:Label></td>
			<td class="SubHead" align="right">
				<asp:Button id="btnSettings" runat="server" Text="btnSettings" CssClass="iCWebControlsII"></asp:Button></td>
		</tr>
	</table>
</div>
