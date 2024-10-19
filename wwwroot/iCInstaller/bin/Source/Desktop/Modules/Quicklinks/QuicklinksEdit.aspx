<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="QuicklinksEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Quicklinks.QuicklinksEdit"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td>
						<br>
						<table width="98%" cellspacing="0" cellpadding="4" border="0">
							<tr valign="top">
								<td width="150">
									&nbsp;
								</td>
								<td width="*">
									<table width="500" cellspacing="0" cellpadding="0">
										<tr>
											<td align="left" class="Head">
												<asp:Label id="lblHeader" runat="server">lblHeader</asp:Label>
											</td>
										</tr>
									</table>
									<table width="750" cellspacing="0" cellpadding="0" border="0">
										<tr>
											<td class="SubHead" colspan="3">
												<hr>
											</td>
										</tr>
										<tr>
											<td width="100" class="SubHead">
												<asp:Label id="lblTitle" runat="server">lblTitle</asp:Label>
											</td>
											<td rowspan="5">
												&nbsp;
											</td>
											<td>
												<asp:TextBox id="txtTitle" runat="server" Width="363px"></asp:TextBox>
											</td>
											<td width="25" rowspan="5">
												&nbsp;
											</td>
											<td class="Normal" width="250">
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												<asp:Label id="lblUrl" runat="server">lblUrl</asp:Label>
											</td>
											<td height="17">
												<asp:DropDownList id="ddUrl" runat="server" Width="363px" AutoPostBack="True"></asp:DropDownList>
											</td>
											<td class="Normal">
											</td>
										</tr>
										<tr>
											<td class="SubHead">
											</td>
											<td>
												<asp:TextBox id="txtUrl" runat="server" Width="363px"></asp:TextBox>
											</td>
											<td class="Normal">
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												<asp:Label id="lblTarget" runat="server">lblTarget</asp:Label>
											</td>
											<td height="27">
												<asp:DropDownList id="ddTarget" runat="server" Width="363px" AutoPostBack="True">
													<asp:ListItem Value="_blank" Selected="True">_Blank</asp:ListItem>
													<asp:ListItem Value="_self">_Self</asp:ListItem>
												</asp:DropDownList>
											</td>
											<td class="Normal">
											</td>
										</tr>
										<tr>
											<td class="SubHead" vAlign="top">
												<asp:Label id="lblDescription" runat="server">lblDescription</asp:Label>
											</td>
											<td>
												<asp:TextBox id="txtDescription" runat="server" Width="363px" TextMode="MultiLine" Height="104px"></asp:TextBox>
											</td>
											<td>
												&nbsp;
											</td>
										</tr>
										<tr>
											<td class="SubHead">
												<asp:Label id="lblOrder" runat="server">lblOrder</asp:Label>
											</td>
											<td>
											</td>
											<td class="Normal">
												<asp:TextBox id="txtOrder" runat="server" Width="64px"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td class="SubHead" colspan="3">
												&nbsp;
											</td>
										</tr>
										<tr>
											<td class="SubHead" colspan="3">
												<hr>
											</td>
										</tr>
										<tr>
											<td class="SubHead" colspan="3">
												&nbsp;
											</td>
										</tr>
										<tr>
											<td class="SubHead" colspan="3">
												<asp:Button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnCancel" runat="server" Text="btnCancel" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnDelete" runat="server" Text="btnDelete" CssClass="iCWebControlsII"></asp:Button>
											</td>
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
