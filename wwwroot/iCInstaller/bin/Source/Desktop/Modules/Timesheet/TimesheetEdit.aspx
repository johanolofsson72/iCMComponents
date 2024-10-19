<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TimesheetEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Timesheet.TimesheetEdit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RolesUsers</title>
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
											<td class="SubHead" width="50" valign="top">
												<asp:Label id="SubText2" runat="server" DESIGNTIMEDRAGDROP="88" CssClass="SubHead">Label</asp:Label>
											</td>
											<td><asp:DropDownList id="ddlUsers" runat="server" Width="149px" EnableViewState="true" AutoPostBack="false"></asp:DropDownList>
											</td>
											<td colSpan="2" align="right">
												<asp:Button id="btnAdd" runat="server" Text="Button" DESIGNTIMEDRAGDROP="92"></asp:Button></td>
										</tr>
										<tr>
											<td class="Normal" valign="top"><asp:Label id="SubText3" runat="server" CssClass="SubHead">Label</asp:Label>
											</td>
											<td><asp:ListBox id="ListBox1" runat="server" Width="149px" Height="104px"></asp:ListBox></td>
											<td colSpan="2" vAlign="bottom" align="right">
												<asp:Button id="btnDelete" runat="server" Text="Button"></asp:Button>
											</td>
										</tr>
										<tr>
											<td colSpan="4">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td colSpan="4" align="right">
												<asp:Button id="btnOk" runat="server" Text="Button"></asp:Button>&nbsp;
												<asp:Button id="btnCancel" runat="server" Text="Button"></asp:Button></td>
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
