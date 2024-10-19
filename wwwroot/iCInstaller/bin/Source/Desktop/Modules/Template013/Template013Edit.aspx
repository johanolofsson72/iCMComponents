<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Template013Edit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template013.Template013Edit" %>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Edit</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginheight="0" marginwidth="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top" height="100">
					<td colSpan="2">&nbsp;</td>
				</tr>
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%">
							<tr vAlign="top">
								<td width="150">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="1" cellPadding="2" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="Head" align="left"><asp:Label id="HeaderText" runat="server">Label</asp:Label>
														</td>
													</tr>
													<tr>
														<td>
															<hr noShade SIZE="1">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td class="SubHead" width="84" valign="top">
												<asp:Label id="lblSmtp" runat="server" DESIGNTIMEDRAGDROP="88" CssClass="SubSubHead">lblSmtp</asp:Label>
											</td>
											<td colspan="3">
												<asp:TextBox id="txtSmtp" runat="server" Width="216px"></asp:TextBox></td>
										</tr>
										<tr>
											<td class="SubHead" width="84" valign="top">
												<asp:Label id="lblMail" runat="server" DESIGNTIMEDRAGDROP="88" CssClass="SubSubHead">lblSmtp</asp:Label>
											</td>
											<td colspan="3">
												<asp:TextBox id="txtMail" runat="server" Width="216px"></asp:TextBox></td>
										</tr>
										<tr>
											<td class="SubHead" width="84" valign="top">
												<asp:Label id="lblPrefix" runat="server" DESIGNTIMEDRAGDROP="88" CssClass="SubSubHead">lblPrefix</asp:Label>
											</td>
											<td colspan="3">
												<asp:TextBox id="txtPrefix" runat="server" Width="216px"></asp:TextBox></td>
										</tr>
										<tr>
											<td class="SubHead" width="84" valign="top">
												<asp:Label id="lblUsers" runat="server" CssClass="SubSubHead" DESIGNTIMEDRAGDROP="41">lblUsers</asp:Label>
											</td>
											<TD colSpan="3">
												<asp:TextBox id="txtUsers" runat="server" Width="432px" Wrap="False" TextMode="MultiLine" Height="166px"></asp:TextBox></TD>
										</tr>
										<tr>
											<td class="SubHead" width="84" valign="top">
												<asp:Label id="lblCourses" runat="server" CssClass="SubSubHead" DESIGNTIMEDRAGDROP="41">lblUsers</asp:Label>
											</td>
											<TD colSpan="3">
												<asp:TextBox id="txtCourses" runat="server" Width="432px" Wrap="False" TextMode="MultiLine" Height="166px"></asp:TextBox></TD>
										</tr>
										<tr>
											<td colSpan="4">
												<hr noShade SIZE="1">
												<asp:Label id="lblNotice" runat="server" CssClass="SubSubHead" ForeColor="Red">lblNotice</asp:Label>
											</td>
										</tr>
										<tr>
											<td colSpan="4" align="right">
												<asp:Button id="btnOk" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:Button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
