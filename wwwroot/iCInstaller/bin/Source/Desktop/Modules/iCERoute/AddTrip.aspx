<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AddTrip.aspx.vb" Inherits="iConsulting.iCMServer.Modules.ICERoute.AddTrip"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AddTrip</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table bgColor="#d4d0c8"> <!--CCCCCC-->
				<tr>
					<td>
						<table>
							<tr>
								<td bgColor="gainsboro" colSpan="2"><asp:label id="Label8" runat="server"> Hämtning</asp:label></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;</td>
							</tr>
							<tr>
								<td><asp:label id="Label1" runat="server">Hållplatsnr:</asp:label></td>
								<td><asp:textbox id="TextBox1" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label2" runat="server">Tid:</asp:label></td>
								<td><asp:textbox id="TextBox2" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label3" runat="server">Tur:</asp:label></td>
								<td><asp:textbox id="TextBox3" runat="server"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td colspan="2">
						<table>
							<tr>
								<td bgColor="gainsboro" colSpan="2"><asp:label id="Label17" runat="server"> Lämning</asp:label></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;</td>
							</tr>
							<tr>
								<td><asp:label id="Label20" runat="server">Hållplatsnr:</asp:label></td>
								<td><asp:textbox id="Textbox9" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label21" runat="server">Tid:</asp:label></td>
								<td><asp:textbox id="Textbox11" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="Label22" runat="server">Tur:</asp:label></td>
								<td><asp:textbox id="Textbox12" runat="server"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						&nbsp;
					</td>
					<td>
						<asp:Button id="Button1" runat="server" Text="Ok" Width="100px"></asp:Button>
					</td>
					<td>
						<asp:Button id="Button2" runat="server" Text="Avbryt" Width="100px"></asp:Button>
					</td>
				</tr>
				<tr>
					<td colspan="3">
						&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
