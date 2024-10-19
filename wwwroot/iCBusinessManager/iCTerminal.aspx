<%@ Page Language="vb" AutoEventWireup="false" Codebehind="iCTerminal.aspx.vb" Inherits="iCBusinessManager.iCTerminal"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>iCTerminal</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>
						<asp:textbox id="txtTerminal" onkeydown="KeyDown()" runat="server" AutoPostBack="true" EnableViewState="true"
							TextMode="MultiLine" ForeColor="LightGray" Font-Names="Tahoma,Verdana" BackColor="Black"
							Height="304px" Width="664px"></asp:textbox>
					</td>
					<td>
						<asp:textbox id="txtHolder" runat="server" TextMode="MultiLine"></asp:textbox>
					</td>
				</tr>
			</table>
			<script>
				document.all("txtTerminal").focus();
				document.all("txtTerminal").value=document.all("txtHolder").value;
				function KeyDown(){
					if (document.all){
						if (event.keyCode == 13){
							document.location.href="iCTerminal.aspx?Input="+document.all("txtTerminal").value;
						}
					}
				}
			</script>
		</form>
	</body>
</HTML>
