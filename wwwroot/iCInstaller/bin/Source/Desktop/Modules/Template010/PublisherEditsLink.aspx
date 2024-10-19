<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PublisherEditsLink.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template010.PublisherEditLink"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<title>Hyperlänk</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<script language="JavaScript">
			function ReturnLink(obj){
				var obj = dialogArguments;
				obj._urlfield = document.all["urlfield"].value;
				obj._displayfield = document.all["displayfield"].value;
				obj.InsertNewLink();
				window.close();
			}
			function ChangeType(value){
				//alert(value);
				document.all["urlfield"].value=value;   
				//document.Form1.urlfield.value=document.Form1.typefield.value;  
			}
		</script>
	</HEAD>
	<body bgColor="silver">
		<form id="Form1">
			<TABLE height="74" cellSpacing="0" cellPadding="0" width="372" border="0">
				<tr>
					<td colspan="7">&nbsp;</td>
				</tr>
				<tr>
					<td width="5">&nbsp;</td>
					<td width="30" class="SubHead">Typ:</td>
					<td width="5">&nbsp;</td>
					<td>
						<SELECT name="typefield" onchange="ChangeType(this.value);">
							<option value="">(other)</option>
							<option value="file://">file:</option>
							<OPTION selected value="http://">http:</OPTION>
							<option value="https://">https:</option>
							<option value="gopher://">gopher:</option>
							<option value="mailto:">mailto:</option>
							<option value="news:">news:</option>
							<option value="telnet:">telnet:</option>
							<option value="wais:">wais:</option>
						</SELECT>
					</td>
					<td colspan="2">&nbsp;</td>
					<td rowspan="3">
						<table align="center">
							<tr valign="middle">
								<td><button type="button" class="iCWebControlsII" onclick='ReturnLink();' style="WIDTH: 75px"
										onFocus="this.blur()">OK</button></td>
							</tr>
							<tr valign="middle">
								<td><button type="button" class="iCWebControlsII" onclick='window.close();' style="WIDTH: 75px"
										onFocus="this.blur()">Ångra</button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="SubHead">Visa:</td>
					<td>&nbsp;</td>
					<td><INPUT id="displayfield" name="displayfield" type="text" value="MyLink..." size="28"></td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="SubHead">URL:</td>
					<td>&nbsp;</td>
					<td><INPUT id="urlfield" name="urlfield" type="text" value="http://" size="28"></td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="SubHead">Target:</td>
					<td>&nbsp;</td>
					<td><INPUT id="urlfield" name="urlfield" type="text" value="http://" size="28"></td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td colspan="7"></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
