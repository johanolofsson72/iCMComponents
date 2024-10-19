<%@ Page Language="vb" AutoEventWireup="false" Codebehind="iCM.aspx.vb" Inherits="iConsulting.iCMServer.iCM"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<script src="Server/Js/Generic.js"></script>
	</HEAD>
	<body id="iCMBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginheight="0"
		marginwidth="0" runat="server">
		<form id="Form1" runat="server">
			<asp:Panel id="JavaScriptHolder" runat="server"></asp:Panel>
			<table id="iCMPage" height="100%" align="left" cellSpacing="0" cellPadding="0" width="1000" border="0"
				runat="server">
				<TBODY>
					<tr>
						<td vAlign="top">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr vAlign="top">
									<!-- <td id="sTopModuleField" height="15" runat="server"></td> -->
									<td id="TopModuleField" height="1" runat="server"></td>
									<td align="right">
										<table width="100%" border="0">
											<!--
											<tr>
												<td>&nbsp;</td>
											</tr>
											-->
											<tr>
												<td align="right">
													<asp:LinkButton id="btnLogIn" runat="server" CssClass="SubSubHead">LinkButton</asp:LinkButton>
													<asp:LinkButton id="btnLogOut" runat="server" CssClass="SubSubHead">LinkButton</asp:LinkButton></td>
											</tr>
										</table>
									</td>
								</tr>
								<asp:placeholder id="ContentAdjust1" runat="server"></asp:placeholder>
								<TR>
									<TD colSpan="2">
										<div id="iCMPageHeight" runat="server">
											<table cellSpacing="0" cellPadding="2" width="100%" border="0">
												<tr vAlign="top" height="100%">
													<td class="LeftModuleField" id="LeftModuleField" vAlign="top" width="20%" runat="server"
														Visible="True"><br>
														<asp:image id="LeftModuleFieldSpacer" ImageUrl="~/Server/Images/spacer.gif" Height="1" BorderWidth="0"
															Runat="server"></asp:image></td>
													<td class="ContentModuleField" id="ContentModuleField" vAlign="top" runat="server" Visible="True"><br>
														<asp:image id="ContentModuleFieldSpacer" Width="1" ImageUrl="~/Server/Images/spacer.gif" Height="1"
															BorderWidth="0" Runat="server"></asp:image></td>
													<td class="RightModuleField" id="RightModuleField" vAlign="top" width="20%" runat="server"
														Visible="True"><br>
														<asp:image id="RightModuleFieldSpacer" ImageUrl="~/Server/Images/spacer.gif" Height="1" BorderWidth="0"
															Runat="server"></asp:image></td>
												</tr>
											</table>
										</div>
									</TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<td vAlign="bottom">
							<asp:placeholder id="FooterField1" runat="server"></asp:placeholder>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
