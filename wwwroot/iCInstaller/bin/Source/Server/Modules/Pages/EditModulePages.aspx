<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditModulePages.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Pages.EditModulePages" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditModuleLitePages</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<script src="Js/Color.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top" height="100">
					<td colSpan="2">&nbsp;</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="4" width="98%">
				<tr vAlign="top">
					<td width="50">&nbsp;
					</td>
					<td width="*">
						<table cellSpacing="0" cellPadding="4" width="98%">
							<tr vAlign="top">
								<td width="30">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="1" cellPadding="2" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="Head" align="left"><asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
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
											<td class="SubHead" width="100"><asp:label id="lblName" runat="server">lblName</asp:label></td>
											<td colSpan="3">&nbsp;<asp:textbox id="moduleTitle" runat="server" width="300" cssclass="NormalTextBox"></asp:textbox>
											</td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="lblCache" runat="server">lblCache</asp:label></td>
											<td colSpan="3">&nbsp;
												<asp:dropdownlist id="ddCache" runat="server" Width="80px"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="lblShowtitle" runat="server">lblShowtitle</asp:label></td>
											<td colSpan="3">&nbsp;
												<asp:radiobutton id="rbShow1" runat="server" Checked="True" GroupName="sh" Text="Ja" CssClass="SubSubHead"></asp:radiobutton><asp:radiobutton id="rbShow2" runat="server" GroupName="sh" Text="Nej" CssClass="SubSubHead"></asp:radiobutton></td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="lblIsVisible" runat="server">lblIsVisible</asp:label></td>
											<td colSpan="3">&nbsp;
												<asp:radiobutton id="rbVisible1" runat="server" Checked="True" GroupName="shw" Text="Ja" CssClass="SubSubHead"></asp:radiobutton><asp:radiobutton id="rbVisible2" runat="server" GroupName="shw" Text="Nej" CssClass="SubSubHead"></asp:radiobutton></td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="lblAlign" runat="server">lblAlign</asp:label></td>
											<td colSpan="3">&nbsp;
												<asp:dropdownlist id="ddAlign" runat="server" Width="80px"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="lblBorder" runat="server">lblBorder</asp:label></td>
											<td colSpan="3">&nbsp;
												<asp:dropdownlist id="ddBorder" runat="server" Width="80px"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="SubHead"><asp:label id="lblColor" runat="server">lblColor</asp:label></td>
											<td colSpan="3">&nbsp;
												<asp:TextBox id="bColor" runat="server" Width="62px" Font-Name="verdana"></asp:TextBox><INPUT onclick="ChangeColor();" style="WIDTH:16px; CURSOR:hand; HEIGHT:22px" type="button"
													value="...">
											</td>
										</tr>
										<tr>
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td class="SubHead" vAlign="top"><asp:label id="lblRoles" runat="server">lblRoles</asp:label></td>
											<td colSpan="3"></td>
										</tr>
										<tr>
											<td colSpan="4">
												<asp:checkboxlist id="authEditRoles" runat="server" width="600" RepeatColumns="3" Font-Names="Verdana,Arial"
													Font-Size="8pt" cellpadding="0" cellspacing="0"></asp:checkboxlist>
											</td>
										</tr>
										<tr>
											<td colSpan="4">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td colSpan="2" align="left">&nbsp;</td>
											<td colSpan="2" align="right">
												<table border="0">
													<tr>
														<td>
															<asp:Button id="btnSave" runat="server" Text="btnSave" CssClass="iCWebControlsII"></asp:Button>&nbsp;
															<asp:Button id="btnCancel" runat="server" Text="btnSave" CssClass="iCWebControlsII"></asp:Button>&nbsp;
															<asp:Button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:Button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE></form>
	</body>
</HTML>
