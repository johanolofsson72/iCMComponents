<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DiscussionDetails.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Discussion.DiscussionDetails"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
		<script>
			function ToNew(){
				window.opener.location.href="DiscussionNew.aspx?PageId=<%=PagId%>&ModId=<%=ModId%>&DisId=<%=DisId%>";
				this.close();
			}
		</script> 
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="1">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr>
											<td class="Head" align="left"><asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
											<td class="SubHead" align="right">
												<table>
													<tr>
														<td width="15"><asp:imagebutton id="btnRev" runat="server"></asp:imagebutton></td>
														<td width="15"><asp:imagebutton id="btnFwd" runat="server"></asp:imagebutton></td>
														<td><a onclick="ToNew()" style="cursor:hand;text-decoration:underline"><%=Reply%></a></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="2" height="36">
												<hr>
											</td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblSubject" runat="server">lblSubject</asp:label></td>
											<td align="left"><asp:label id="lblSubjectText" runat="server" CssClass="SubSubHead">lblSubjectText</asp:label></td>
											<td>&nbsp;
											</td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"><asp:label id="lblTitle" runat="server">lblTitle</asp:label></td>
											<td align="left"><asp:label id="lblAuthorText" runat="server" CssClass="SubSubHead">lblAuthorText</asp:label><asp:textbox id="txtTitle" runat="server" Width="173px" CssClass="SubSubHead"></asp:textbox></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" height="19"><asp:label id="lblCreated" runat="server">lblCreated</asp:label></td>
											<td align="left" height="19"><asp:label id="lblCreatedText" runat="server" CssClass="SubSubHead">lblCreatedText</asp:label><asp:textbox id="txtDescription" runat="server" Width="361px" TextMode="MultiLine" Height="112px"
													CssClass="SubSubHead"></asp:textbox></td>
											<td class="Normal" height="19"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3"><asp:textbox id="txtMessage" runat="server" Width="361px" TextMode="MultiLine" Height="112px"
													CssClass="SubSubHead" BorderStyle="None" BorderColor="Gainsboro"></asp:textbox></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3" height="36">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3"><asp:button id="btnUpdate" runat="server" CssClass="iCWebControlsII" Text="btnUpdate"></asp:button>&nbsp;
												<asp:button id="btnCancel" runat="server" CssClass="iCWebControlsII" Text="btnCancel"></asp:button>&nbsp;
												<asp:button id="btnDelete" runat="server" CssClass="iCWebControlsII" Text="btnDelete"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
