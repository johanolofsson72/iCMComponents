<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RolesEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Roles.RolesEdit"%>
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
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="100">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr>
											<td class="Head" align="left" width="525">
												<asp:label id="lblHeader" runat="server">lblHeader</asp:label>
											</td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0">
										<tr vAlign="top">
											<td class="SubHead" colSpan="3" width="395">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" width="100">
												<asp:Label id="lblName" runat="server">lblName</asp:Label></td>
											<td rowSpan="4" width="9">&nbsp;
											</td>
											<td width="298">
												<asp:TextBox id="txtName" runat="server" Width="277px"></asp:TextBox></td>
											<td width="25" rowSpan="4">&nbsp;
											</td>
											<td class="Normal" width="250"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblDescription" runat="server">lblDescription</asp:Label></td>
											<td width="9">
												<asp:TextBox id="txtDescription" runat="server" Width="277px" TextMode="MultiLine" Height="104px"></asp:TextBox></td>
											<td class="Normal" width="298"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td width="9"></td>
											<td class="Normal" width="298"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3" width="395">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td width="9"></td>
											<td class="Normal" width="298"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3" width="395" align="right"><asp:button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnCancel" runat="server" Text="btnCancel" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnDelete" runat="server" Text="btnDelete" CssClass="iCWebControlsII"></asp:button></td>
										</tr>
									</table>
									<p>&nbsp;&nbsp;&nbsp;</p>
									<span class="Normal">
										<br>
									</span>
									<P></P>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
