<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Template009Edit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template009.Template009Edit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="250" border="0">
							<tr>
								<td colSpan="3">&nbsp;</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="230">
									<asp:Label id="Header" runat="server" CssClass="Head">Label</asp:Label></td>
								<td width="10">&nbsp;</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="230">&nbsp;</td>
								<td width="10">&nbsp;</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="230"><asp:Image id="Image1" runat="server" Width="200px" Height="100px"></asp:Image></td>
								<td width="10">&nbsp;</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="230"><INPUT id="Browse1" style="WIDTH: 200px; HEIGHT: 22px" type="file" size="13" name="FileUpload"
										runat="server"></td>
								<td width="10">&nbsp;</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="230">&nbsp;</td>
								<td width="10">&nbsp;</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="230">&nbsp;</td>
								<td width="10">&nbsp;</td>
							</tr>
							<TR>
								<td width="20">&nbsp;</td>
							</TR>
							<tr>
								<td colSpan="3">&nbsp;
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><asp:button id="btnSave" runat="server" CssClass="iCWebControlsII" Text="btnSave"></asp:button></td>
							</tr>
							<tr>
								<td colSpan="3">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
