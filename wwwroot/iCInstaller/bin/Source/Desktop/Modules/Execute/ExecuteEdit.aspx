<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExecuteEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Execute.ExecuteEdit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="150">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr>
											<td class="Head" align="left"><asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="750" border="0">
										<tr>
											<td class="SubHead" colSpan="3">
												<hr>
											</td>
										</tr>
										<tr>
											<td class="SubHead"></td>
											<td height="17"></td>
											<td class="Normal"></td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="Label1" runat="server">Execute:</asp:label></td>
											<td height="17"><asp:textbox id="txtUrl" runat="server" Width="360px"></asp:textbox></td>
											<td class="Normal"></td>
										</tr>
										<tr>
											<td class="SubHead" colSpan="3">&nbsp;
											</td>
										</tr>
										<tr>
											<td class="SubHead" colSpan="3"><asp:button id="btnUpdate" runat="server" CssClass="iCWebControlsII" Text="btnUpdate"></asp:button>&nbsp;
												<asp:button id="btnCancel" runat="server" CssClass="iCWebControlsII" Text="btnCancel"></asp:button>&nbsp;
												<asp:button id="btnDelete" runat="server" CssClass="iCWebControlsII" Text="btnDelete"></asp:button></td>
										</tr>
									</table>
									<p>&nbsp;&nbsp;&nbsp;</p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
