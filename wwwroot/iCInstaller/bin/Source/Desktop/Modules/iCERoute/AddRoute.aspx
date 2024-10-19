<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AddRoute.aspx.vb" Inherits="iConsulting.iCMServer.Modules.ICERoute.AddRoute"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>AddRoute</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<script> 
			function ReturnResult()
			{ 
				try
					{ 
						window.opener.OpenRouteDialogResult = "true"; 
						window.close(); 
					} 
				catch(e)
				{ 
					this.close(); 
				} 
			} 
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginheight="0" marginwidth="0" >
		<form id="Form1" method="post" runat="server">
			<table bgColor="#d4d0c8"> <!--CCCCCC-->
				<tr>
					<td bgColor="gainsboro" colspan="3"><asp:label id="Label4" runat="server">Egenskaper för rutt:</asp:label></td>
				</tr>
				<tr>
					<td colspan="3">&nbsp;</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">Namn:</asp:label></td>
					<td colspan="2"><asp:textbox id="TextBox1" runat="server" Width="225px"></asp:textbox></td>
				</tr>
				<tr>
					<td colspan="3">&nbsp;</td>
				</tr>
				<tr>
					<td bgColor="gainsboro" colspan="3"><asp:label id="Label2" runat="server"> Hållplatser:</asp:label></td>
				</tr>
				<tr>
					<td colspan="3">&nbsp;</td>
				</tr>
				<tr>
					<td><asp:Button id="Button4" runat="server" Text="Lägg till från lista" Width="125px"></asp:Button></td>
					<td><asp:Button id="Button3" runat="server" Text="Lägg till från karta" Width="125px"></asp:Button></td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td colspan="2"><asp:ListBox id="ListBox1" runat="server" Width="250px"></asp:ListBox></td>
					<td valign="bottom"><asp:Button id="Button2" runat="server" Text="Ok" Width="100px"></asp:Button></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td><asp:Button id="Button1" runat="server" Text="Avbryt" Width="100px"></asp:Button></td>
				</tr>
				<tr>
					<td colspan="3">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
