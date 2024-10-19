<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MediagalleryUpload.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Mediagallery.MediagalleryUpload" %>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<body leftmargin="0" bottommargin="0" rightmargin="0" topmargin="0" marginheight="0" marginwidth="0">
		<form enctype="multipart/form-data" runat="server" ID="Form1">
			<table width="100%" cellspacing="0" cellpadding="0" border="0">
				<tr valign="top" height="100">
					<td colspan="2">
					</td>
				</tr>
				<tr>
					<td>
						<br>
						<table width="98%" cellspacing="0" cellpadding="4" border="0">
							<tr valign="top">
								<td width="150">
									&nbsp;
								</td>
								<td>
									<table width="455" cellspacing="0" cellpadding="0">
										<tr>
											<td align="left" class="Head">&nbsp;
												<asp:Label id="lblHeader" runat="server">lblHeader</asp:Label>
											</td>
											<td align="right" class="Head">
												<asp:Label id="MaxPost" runat="server"></asp:Label>
											</td>
										</tr>
										<tr>
											<td colspan="2">
												<hr noshade size="1">
											</td>
										</tr>
									</table>
									<table width="726" cellspacing="0" cellpadding="0" border="0">
										<tr valign="top">
											<td width="100" class="SubHead">&nbsp;
												<asp:Label id="lblTitle" runat="server">lblTitle</asp:Label>
											</td>
											<td>
												&nbsp;
											</td>
											<td>
												<asp:TextBox id="NameField" cssclass="NormalTextBox" width="353" Columns="28" maxlength="150"
													runat="server" />
											</td>
											<td width="25" rowspan="6">
												&nbsp;
											</td>
											<td class="Normal" width="250">
											</td>
										</tr>
										<tr valign="top">
											<td nowrap class="SubHead">
												<!--Upload to Web Server:-->
												&nbsp;
											</td>
											<td>
												&nbsp;
											</td>
											<td>
												<asp:CheckBox id="Upload" Cssclass="Normal" Text="Upload document to server" runat="server" Checked="True"
													Visible="False" />
												<br>
												<asp:CheckBox id="storeInDatabase" Cssclass="Normal" Text="Store in database (web farm support)"
													runat="server" Checked="True" Visible="False" />
												<br>
												<input type="file" id="FileUpload" width="300" style="WIDTH:353px;FONT-FAMILY:verdana"
													runat="server" NAME="FileUpload">
											</td>
										</tr>
										<tr>
											<td colspan="3">
											</td>
										</tr>
										<tr>
											<td colspan="3"><hr noshade size="1">
											</td>
										</tr>
										<tr>
											<td colspan="3" align="right">
												<asp:Button id="btnSave" runat="server" Text="Spara" CssClass="iCWebControlsII"></asp:Button>&nbsp;
												<asp:Button id="btnCancel" runat="server" Text="Ångra" CssClass="iCWebControlsII"></asp:Button>&nbsp;
											</td>
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
