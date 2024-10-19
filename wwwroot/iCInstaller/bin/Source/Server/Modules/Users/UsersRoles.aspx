<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsersRoles.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Users.UsersRoles"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UsersRoles</title>
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
														<td class="Head" align="left"><asp:label id="HeaderText" runat="server" CssClass="Head"></asp:label></td>
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
											<td class="SubHead" width="50"><asp:label id="SubText1" runat="server" CssClass="SubHead"></asp:label></td>
											<td colSpan="3"><asp:textbox id="txtUser" runat="server" ReadOnly="True" width="300" cssclass="NormalTextBox"></asp:textbox></td>
										</tr>
										<tr>
											<td class="SubHead" vAlign="top" width="50"><asp:label id="SubText2" runat="server" CssClass="SubHead"></asp:label></td>
											<td><asp:dropdownlist id="ddlRoles" runat="server" AutoPostBack="false" EnableViewState="true" Width="149px"></asp:dropdownlist></td>
											<td align="right" colSpan="2"><asp:button id="btnAdd" runat="server" Text="Button"></asp:button></td>
										</tr>
										<tr>
											<td class="Normal" vAlign="top">&nbsp;
											</td>
											<td colSpan="3"><asp:datalist id="userRoles" runat="server" DataKeyField="rol_id" RepeatColumns="3">
													<ItemStyle />
													<ItemTemplate>
														&nbsp;&nbsp;
														<asp:ImageButton id="userRolesImage" runat="server" ImageUrl="Images/Delete.gif" CommandName="delete"
															AlternateText="Delete"></asp:ImageButton>
														<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "rol_name") %>' cssclass="SubSubHead" runat="server" ID="userRolesLabel" />
													</ItemTemplate>
												</asp:datalist></td>
										</tr>
										<tr>
											<td colSpan="4">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td colSpan="4" align="right"><asp:button id="btnOk" runat="server" Text="Button"></asp:button>
												&nbsp;<asp:Button id="btnCancel" runat="server" Text="Button"></asp:Button></td>
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
