<%@ Page Language="vb" AutoEventWireup="false" Codebehind="iFrameEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.iFrame.iFrameEdit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
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
												<asp:Label id="lblHeader" runat="server">lblHeader</asp:Label></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="750">
										<tr vAlign="top">
											<td class="SubHead" colSpan="3">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" width="100">
												<asp:Label id="lblTitle" runat="server">lblTitle</asp:Label></td>
											<td rowSpan="4" height="96">&nbsp;
											</td>
											<td>
												<asp:TextBox id="txtTitle" runat="server" Width="361px"></asp:TextBox></td>
											<td width="25" rowSpan="4" height="96">&nbsp;
											</td>
											<td class="Normal" width="250"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblDescription" runat="server">lblDescription</asp:Label></td>
											<td>
												<asp:TextBox id="txtDescription" runat="server" Width="361px" TextMode="MultiLine" Height="104px"></asp:TextBox></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblUrl" runat="server">lblUrl</asp:Label></td>
											<td>
												<asp:TextBox id="txtUrl" runat="server" Width="361px"></asp:TextBox></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblTarget" runat="server">lblTarget</asp:Label></td>
											<td>
												<asp:DropDownList id="ddTarget" runat="server" Width="72px">
													<asp:ListItem Value="_self" Selected="True">_self</asp:ListItem>
													<asp:ListItem Value="_blank">_blank</asp:ListItem>
												</asp:DropDownList></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblHeight" runat="server">lblHeight</asp:Label></td>
											<td></td>
											<td class="Normal">
												<asp:TextBox id="txtHeight" runat="server" Width="72px"></asp:TextBox></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblWidth" runat="server">lblWidth</asp:Label></td>
											<td></td>
											<td class="Normal">
												<asp:TextBox id="txtWidth" runat="server" Width="72px"></asp:TextBox></td>
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
											<td class="SubHead" colSpan="3">
												<asp:Button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnCancel" runat="server" Text="btnCancel" CssClass="iCWebControlsII"></asp:Button></td>
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
