<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NoticeEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Notice.NoticeEdit"%>
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
											<td class="Head" align="left" width="525"><asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="750">
										<tr vAlign="top">
											<td class="SubHead" colSpan="3">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" width="100"><asp:label id="lblTitle" runat="server">lblTitle</asp:label></td>
											<td rowSpan="4">&nbsp;
											</td>
											<td><asp:textbox id="txtTitle" runat="server" Width="360px"></asp:textbox></td>
											<td width="25" rowSpan="4">&nbsp;
											</td>
											<td class="Normal" width="250"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblDescription" runat="server">lblDescription</asp:label></td>
											<td><asp:textbox id="txtDescription" runat="server" Width="361px" Height="112px" TextMode="MultiLine"></asp:textbox></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblLink" runat="server">lblLink</asp:label></td>
											<td><asp:textbox id="txtLink" runat="server" Width="360px"></asp:textbox></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblTarget" runat="server">lblTarget</asp:label></td>
											<td>
												<asp:DropDownList id="ddTarget" runat="server">
													<asp:ListItem Value="_blank" Selected="True">_Blank</asp:ListItem>
													<asp:ListItem Value="_self">_Self</asp:ListItem>
												</asp:DropDownList></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblShowDate" runat="server">lblShowDate</asp:label></td>
											<td></td>
											<td class="Normal"><asp:textbox id="txtShowDate" runat="server" Width="112px"></asp:textbox></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblHideDate" runat="server">lblHideDate</asp:label></td>
											<td></td>
											<td class="Normal"><asp:textbox id="txtHideDate" runat="server" Width="112px"></asp:textbox></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3"><asp:button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:button>&nbsp;
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
