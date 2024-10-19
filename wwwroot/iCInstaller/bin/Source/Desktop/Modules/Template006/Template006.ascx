<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Template006.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Template006.Template006" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/Template006/Template006Edit.aspx"
	Phrase="template006_edit" Location="iConsulting.iCMServer.Modules.Template006" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr height="25">
						<td width="20">&nbsp;</td>
						<td bgcolor="#660000" style="BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid">&nbsp;<asp:Label id="Header1" runat="server" Font-Names="Verdana" Font-Bold="True" Font-Size="Small"
								ForeColor="White">Label</asp:Label></td>
						<td bgcolor="#660000" width="30" style="BORDER-TOP: silver 1px solid">&nbsp;</td>
						<td bgcolor="#660000" width="200" style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid">&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td bgcolor="#f5f5f5" vAlign="top" style="BORDER-LEFT: silver 1px solid; BORDER-BOTTOM: silver 1px solid">
							<TABLE cellSpacing="4" cellPadding="4" width="100%" border="0">
								<tr>
									<td><asp:Label id="Text1" runat="server" Font-Names="Verdana" Font-Size="X-Small" ForeColor="Gray">Label</asp:Label></td>
								</tr>
							</TABLE>
						</td>
						<td bgcolor="#f5f5f5" width="30" style="BORDER-BOTTOM: silver 1px solid">&nbsp;</td>
						<td bgcolor="#f5f5f5" width="200" vAlign="top" style="BORDER-RIGHT: silver 1px solid; BORDER-BOTTOM: silver 1px solid"
							align="right">
							<TABLE cellSpacing="4" cellPadding="4" width="100%" border="0">
								<tr>
									<td align="right"><asp:Image id="Image1" runat="server"></asp:Image></td>
								</tr>
							</TABLE>
						</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td colspan="5">&nbsp;</td>
					</tr>
				</TABLE>
			</td>
		</tr>
	</TABLE>
</div>
