<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Template005Edit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template005.Template005Edit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="680" border="0" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid">
							<tr>
								<td><asp:label id="Label2" runat="server" CssClass="SubHead">Rubrik1:</asp:label></td>
								<td><asp:textbox id="Header1" runat="server" Width="286px"></asp:textbox></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td vAlign="top"><asp:label id="Label1" runat="server" CssClass="SubHead">Ingress1:</asp:label></td>
								<td vAlign="top">
									<asp:textbox id="Ingress1" runat="server" Width="286px" Height="144px" TextMode="MultiLine" DESIGNTIMEDRAGDROP="23"></asp:textbox></td>
								<td>&nbsp;</td>
								<td vAlign="top"><asp:label id="Label3" runat="server" CssClass="SubHead">Bild1:</asp:label></td>
								<td vAlign="top">
									<P><asp:image id="Image1" runat="server"></asp:image></P>
									<P><INPUT id="Browse1" style="WIDTH: 200px; HEIGHT: 22px" type="file" size="13" name="FileUpload"
											runat="server"></P>
								</td>
							</tr>
							<tr>
								<td vAlign="top">&nbsp;
									<asp:label id="Label10" runat="server" CssClass="SubHead">Text1:</asp:label></td>
								<td colSpan="4"><asp:textbox id="Text1" runat="server" Width="591px" TextMode="MultiLine" Height="144px"></asp:textbox></td>
							</tr>
							<tr>
								<td colSpan="5">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="680" border="0" style="BORDER-RIGHT: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid">
							<tr>
								<td><asp:label id="Label4" runat="server" CssClass="SubHead">Rubrik2:</asp:label></td>
								<td colSpan="4"><asp:textbox id="Header2" runat="server" Width="590px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="top"><asp:label id="Label5" runat="server" CssClass="SubHead">Bild2:</asp:label></td>
								<td vAlign="top">
									<P><asp:image id="Image2" runat="server"></asp:image></P>
									<P><INPUT id="Browse2" style="WIDTH: 200px; HEIGHT: 22px" type="file" size="13" name="FileUpload"
											runat="server"></P>
								</td>
								<td>&nbsp;</td>
								<td vAlign="top"><asp:label id="Label6" runat="server" CssClass="SubHead">Text2:</asp:label></td>
								<td vAlign="top"><asp:textbox id="Text2" runat="server" Width="321px" TextMode="MultiLine" Height="144px"></asp:textbox></td>
							</tr>
							<tr>
								<td colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="5" style="HEIGHT: 18px">&nbsp;</td>
							</tr>
							<tr>
								<td><asp:label id="Label9" runat="server" CssClass="SubHead">Rubrik3:</asp:label></td>
								<td colSpan="4"><asp:textbox id="Header3" runat="server" Width="590px"></asp:textbox></td>
							</tr>
							<tr>
								<td vAlign="top"><asp:label id="Label8" runat="server" CssClass="SubHead">Bild3:</asp:label></td>
								<td vAlign="top">
									<P><asp:Image id="Image3" runat="server"></asp:Image></P>
									<P><INPUT id="Browse3" style="WIDTH: 200px; HEIGHT: 22px" type="file" size="13" name="FileUpload"
											runat="server"></P>
								</td>
								<td>&nbsp;</td>
								<td vAlign="top"><asp:Label id="Label7" runat="server" CssClass="SubHead">Text3:</asp:Label></td>
								<td vAlign="top"><asp:TextBox id="Text3" runat="server" Width="321px" TextMode="MultiLine" Height="144px"></asp:TextBox></td>
							</tr>
							<tr>
								<td colSpan="5">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="5" align="center">
									<asp:Button id="Save" runat="server" Text="Spara" CssClass="iCWebControlsII"></asp:Button></td>
							</tr>
							<tr>
								<td colSpan="5">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
