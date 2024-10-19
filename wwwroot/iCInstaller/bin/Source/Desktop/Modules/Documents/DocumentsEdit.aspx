<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocumentsEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Documents.DocumentsEdit"%>
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
								<td width="10">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="352">
										<tr>
											<td class="Head" align="left" width="119">
												<asp:label id="lblHeader" runat="server">lblHeader</asp:label>
											</td>
											<td class="Head" align="right" width="200">
												<asp:Label id="lblMax" runat="server">lblMax</asp:Label>
											</td>
											<td class="Head" align="right" width="30">
											</td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="352" height="145">
										<tr vAlign="top">
											<td class="SubHead" colSpan="3" width="334">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" width="100"><asp:label id="lblTitle" runat="server">lblTitle</asp:label></td>
											<td rowSpan="4" width="1">&nbsp;
											</td>
											<td width="229"><asp:textbox id="txtTitle" runat="server" Width="224px"></asp:textbox></td>
											<td width="25" rowSpan="4">&nbsp;
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td width="229"><INPUT id="FileUpload" type="file" size="18" runat="server"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td width="229"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td width="229"></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3" width="334"><asp:button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnCancel" runat="server" Text="btnCancel" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnDelete" runat="server" Text="btnDelete" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:Button id="btnRevision" runat="server" Text="btnRevision" CssClass="iCWebControlsII"></asp:Button></td>
										</tr>
									</table>
									<asp:PlaceHolder id="Revisions" runat="server"></asp:PlaceHolder>
								</td>
							</tr>
							<tr>
								<td>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
