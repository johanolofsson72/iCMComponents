<%@ Control Language="vb" AutoEventWireup="false" Codebehind="SignIn.ascx.vb" Inherits="iConsulting.iCMServer.Modules.SignIn.SignIn" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>CheckBrowser()</script>
<br>
<br>
<div class="SubHead" id="Header" style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; BORDER-LEFT: 1px solid; WIDTH: 300px; HEIGHT: 60px"
	align="center" runat="server"><br>
	<table cellSpacing="0" cellPadding="0" width="300" align="center">
		<tr>
			<td width="12">&nbsp;</td>
			<td width="100"><asp:label id="lblHeader" runat="server" CssClass="Head">Label</asp:label></td>
			<td align="right"><img src="Server/Modules/SignIn/Images/ic.gif"></td>
			<td width="20">&nbsp;</td>
		</tr>
	</table>
	<br>
</div>
<div class="SubHead" id="Content" style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; BORDER-LEFT: 1px solid; WIDTH: 300px; BORDER-BOTTOM: 1px solid; HEIGHT: 200px"
	align="center" runat="server"><br>
	<table cellSpacing="0" cellPadding="0" width="300" align="center">
		<tr>
			<td colSpan="4">&nbsp;</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td class="SubHead" style="HEIGHT: 23px" width="100"><asp:label id="Label1" runat="server" CssClass="SubHead"></asp:label>:</td>
			<td><asp:textbox id="UserName" runat="server" Width="195px"></asp:textbox></td>
			<td width="20">&nbsp;</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td class="SubHead" width="100"><asp:label id="Label2" runat="server" CssClass="SubHead"></asp:label>:</td>
			<td><asp:textbox id="UserPass" onkeydown="KeyDown()" runat="server" Width="195px" TextMode="Password"></asp:textbox></td>
			<td width="20">&nbsp;</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td colSpan="2"><asp:label id="Msg" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" EnableClientScript="False" Display="Dynamic"
					ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="UserName" ErrorMessage="Du måste ange en giltlig epost adress"></asp:regularexpressionvalidator></td>
			<td width="20">&nbsp;</td>
		</tr>
		<tr>
			<td colSpan="4">&nbsp;
			</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td width="100">&nbsp;</td>
			<td align="right">&nbsp;<asp:button id="LoginBtn" onclick="LoginBtn_Click" runat="server" CssClass="iCWebControlsII"
					Width="60" text="Login"></asp:button>&nbsp;</td>
			<td width="20">&nbsp;</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td colSpan="2"><IMG id="b1" style="CURSOR: hand" onclick="ShowHideNote()" src="Server/Modules/SignIn/Images/info.gif"></td>
			<td width="20">&nbsp;</td>
		</tr>
		<tr>
			<td colSpan="4">&nbsp;
			</td>
		</tr>
		<tr id="l01">
			<td width="20">&nbsp;</td>
			<td colSpan="2"><asp:label id="lblText1" runat="server" CssClass="SubSubHead"></asp:label></td>
			<td width="20">&nbsp;</td>
		</tr>
		<tr id="l02">
			<td width="20">&nbsp;</td>
			<td colSpan="2"><asp:label id="lblText2" runat="server" CssClass="SubSubHead"></asp:label></td>
			<td width="20">&nbsp;</td>
		</tr>
	</table>
</div>
<script language="javascript">
	document.getElementById("l01").style.display='none'; 
	document.getElementById("l02").style.display='none'; 
	function ShowHideNote(){
		if(document.getElementById("l01").style.display=='none'){
			document.getElementById("l01").style.display=''; 
			document.getElementById("l02").style.display='';
		}
		else{
			document.getElementById("l01").style.display='none'; 
			document.getElementById("l02").style.display='none';
		}
	}
	function KeyDown(){
		if (document.all)
			if (event.keyCode == 13)
				mySubmit();
	}
	function mySubmit()
	{
		try{
			var e1 = document.all("iCMServer_SignIn_LoginBtn");
			e1.focus();
		}
		catch(e){
		
		}
	}
	try{
		var e1 = document.all("iCMServer_SignIn_UserName");
		e1.focus();
	}
	catch(e){
	
	}
	
</script>
