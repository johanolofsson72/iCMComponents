<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Mediagallery.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Mediagallery.Mediagallery" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/Mediagallery/MediagalleryUpload.aspx"
	EditText="" LOCATION="iConsulting.iCMServer.Modules.Mediagallery" PHRASE="mediagallery_upload"></SITE:TITLE>
<div id="Minimizer" runat="server">
<TABLE cellSpacing="1" cellPadding="1" width="98%" border="0">
	<tr>
		<td>&nbsp;</td>
	</tr>
</TABLE>
<asp:table id="Table1" Width="100%" Runat="server" CellSpacing="0" CellPadding="15" Font-Size="8pt"
	Font-Name="Verdana" HorizontalAlign="Center" GridLines="none">
	<asp:TableRow ID="TR1">
		<asp:TableCell ID="TD1" Wrap="true"></asp:TableCell>
	</asp:TableRow>
</asp:table>
</div>

