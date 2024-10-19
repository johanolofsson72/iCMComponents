<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Template006Edit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template006.Template006Edit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="680" border="0" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid">
							<tr>
								<td><asp:label id="Label2" runat="server" CssClass="SubHead">Rubrik:</asp:label></td>
								<td><asp:textbox id="Header1" runat="server" Width="286px"></asp:textbox></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="SubHead">Text:</asp:label></td>
								<td vAlign="top"><asp:textbox id="Text1" runat="server" Width="286px" TextMode="MultiLine" Height="144px"></asp:textbox></td>
								<td>&nbsp;</td>
								<td vAlign="top"><asp:label id="Label3" runat="server" CssClass="SubHead">Bild:</asp:label></td>
								<td vAlign="top">
									<P><asp:image id="Image1" runat="server"></asp:image></P>
									<P><INPUT id="Browse1" style="WIDTH: 200px; HEIGHT: 22px" type="file" size="13" name="FileUpload"
											runat="server"></P>
								</td>
							</tr>
							<tr>
								<td colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="5" align="center">
									<asp:Button id="Save" runat="server" Text="Spara" CssClass="iCWebControlsII"></asp:Button></td>
							</tr>
							<tr>
								<td colSpan="5">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
