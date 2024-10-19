<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PublisherEditImage.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Publisher.PublisherEditImage"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<title>Bild detaljer</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<body bottomMargin="0" bgColor="silver" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0"
		marginheight="0">
		<form id="ImageForm" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="150">&nbsp;
								</td>
								<td>
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr>
											<td class="Head" align="left" height="18">&nbsp;
												<asp:Label id="lblHeader" runat="server">lblHeader</asp:Label>
											</td>
											<td class="Head" align="right" height="18">Max : 3000 Kb
											</td>
										</tr>
										<tr>
											<td colSpan="2">
												<hr noShade SIZE="1">
											</td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="726" border="0">
										<tr vAlign="top">
											<td class="SubHead">
												<asp:Label id="lblAlt" runat="server">lblAlt</asp:Label>
											</td>
											<td>&nbsp;
											</td>
											<td><asp:textbox id="NewImageAlt" runat="server" maxlength="250" Columns="28" width="353" cssclass="NormalTextBox"></asp:textbox></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" width="100">
												<asp:Label id="lblBorder" runat="server">lblBorder</asp:Label>
											</td>
											<td>&nbsp;
											</td>
											<td><asp:dropdownlist id="NewImageBorder" Width="35" Runat="server">
													<asp:ListItem Selected="True" Value="0"></asp:ListItem>
													<asp:ListItem Value="1"></asp:ListItem>
													<asp:ListItem Value="2"></asp:ListItem>
													<asp:ListItem Value="3"></asp:ListItem>
													<asp:ListItem Value="4"></asp:ListItem>
													<asp:ListItem Value="5"></asp:ListItem>
													<asp:ListItem Value="6"></asp:ListItem>
													<asp:ListItem Value="7"></asp:ListItem>
													<asp:ListItem Value="8"></asp:ListItem>
													<asp:ListItem Value="9"></asp:ListItem>
													<asp:ListItem Value="10"></asp:ListItem>
												</asp:dropdownlist></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" noWrap>
											</td>
											<td>&nbsp;
											</td>
											<td><input id="FileUpload" style="WIDTH: 353px; FONT-FAMILY: verdana" type="file" name="FileUpload"
													runat="server" width="300">
											</td>
										</tr>
									</table>
									<table border="0">
										<tr>
											<td align="left" width="200"><asp:button id="btnSave" runat="server" Text="Spara" CssClass="iCWebControlsII"></asp:button>
												<asp:button id="btnCancel" runat="server" Text="Ångra" CssClass="iCWebControlsII"></asp:button></td>
										</tr>
										<tr>
											<td colSpan="2">
												<hr width="500" noShade SIZE="1">
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
