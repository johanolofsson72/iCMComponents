<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditSites.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Sites.EditSites"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditSites</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<script src="Js/Color.js" type="text/javascript"></script>
		<script>
		function Show(object){
			try{
				document.getElementById(object).style.display='';
			}
			catch(e){
			
			}
		}
		function Hide(object){
			try{
				document.getElementById(object).style.display='none';
			}
			catch(e){
			
			}
		}
		function CheckDef(){
			if(document.getElementById('tr201').style.display=='none'){
				ShowDef();
			}
			else{
				HideDef();
			}
		}
		function CheckSite(){
			if(document.getElementById('tr1').style.display=='none'){
				ShowSite();
			}
			else{
				HideSite();
			}
			CheckIfAllIsClosed();
		}
		function CheckMenuStd(){
			if(document.getElementById('tr15').style.display=='none'){
				ShowMenuStd();
			}
			else{
				HideMenuStd();
			}
			CheckIfAllIsClosed();
		}
		function CheckMenuAdv(){
			if(document.getElementById('tr16').style.display=='none'){
				ShowMenuAdv();
			}
			else{
				HideMenuAdv();
			}
			CheckIfAllIsClosed();
		}
		function CheckCss(){
			if(document.getElementById('tr60').style.display=='none'){
				ShowCss();
			}
			else{
				HideCss();
			}
			CheckIfAllIsClosed();
		}
		function ShowDef(){
			Show('tr201');Show('tr202');Show('tr203');
		}
		function HideDef(){
			Hide('tr201');Hide('tr202');Hide('tr203');
		}
		function CheckIfAllIsClosed(){
			if((!document.getElementById('tr1').style.display=='') && (!document.getElementById('tr15').style.display=='') && (!document.getElementById('tr16').style.display=='') && (!document.getElementById('tr60').style.display=='')){
				ShowDef();
			}
			else{
				HideDef();
			}
		}
		function ShowSite(){
			document.getElementById('imgsite').src="Images/uparrow.png";
			Show('tr1');Show('tr2');Show('tr3');Show('tr4');Show('tr5');Show('tr6');Show('tr7');Show('tr8');Show('tr9');Show('tr10');Show('tr11');Show('tr12');Show('tr13');Show('tr14');Show('tr95');Show('tr96');Show('tr110');Show('tr111');Show('trn01');Show('trn02');Show('trn03');Show('trn04');Show('trn05');Show('trn06');Show('trn07');Show('trn08');Show('trn09');Show('hr06');Show('hr07');Show('hr08');Show('hr09');Show('trn001')
		}
		function ShowMenuStd(){
			document.getElementById('imgmenustd').src="Images/uparrow.png";
			Show('tr15');Show('tr18');Show('tr20');Show('tr19');Show('tr34');Show('tr49');Show('tr99');Show('tr100');Show('hr04')
		}
		function ShowMenuAdv(){
			document.getElementById('imgmenuadv').src="Images/uparrow.png";
			Show('tr16');Show('tr17');Show('tr21');Show('tr22');Show('tr23');Show('tr24');Show('tr25');Show('tr26');Show('tr27');Show('tr28');Show('tr29');Show('tr30');Show('tr31');Show('tr32');Show('tr33');Show('tr35');Show('tr36');Show('tr37');Show('tr38');Show('tr39');Show('tr40');Show('tr41');Show('tr42');Show('tr43');Show('tr44');Show('tr45');Show('tr46');Show('tr47');Show('tr48');Show('tr101');Show('tr102');Show('hr01');Show('hr02');Show('hr03');Show('tr010');Show('tr011');Show('tr012');Show('tr013');Show('tr014');Show('tr015');Show('tr016');
		}
		function HideSite(){
			document.getElementById('imgsite').src="Images/downarrow.png";
			Hide('tr1');Hide('tr2');Hide('tr3');Hide('tr4');Hide('tr5');Hide('tr6');Hide('tr7');Hide('tr8');Hide('tr9');Hide('tr10');Hide('tr11');Hide('tr12');Hide('tr13');Hide('tr14');Hide('tr95');Hide('tr96');Hide('tr110');Hide('tr111');Hide('trn01');Hide('trn02');Hide('trn03');Hide('trn04');Hide('trn05');Hide('trn06');Hide('trn07');Hide('trn08');Hide('trn09');Hide('hr06');Hide('hr07');Hide('hr08');Hide('hr09');Hide('trn001')
		}
		function HideMenuStd(){
			document.getElementById('imgmenustd').src="Images/downarrow.png";
			Hide('tr15');Hide('tr18');Hide('tr20');Hide('tr19');Hide('tr34');Hide('tr49');Hide('tr99');Hide('tr100');Hide('hr04')
		}
		function HideMenuAdv(){
			document.getElementById('imgmenuadv').src="Images/downarrow.png";
			Hide('tr16');Hide('tr17');Hide('tr21');Hide('tr22');Hide('tr23');Hide('tr24');Hide('tr25');Hide('tr26');Hide('tr27');Hide('tr28');Hide('tr29');Hide('tr30');Hide('tr31');Hide('tr32');Hide('tr33');Hide('tr35');Hide('tr36');Hide('tr37');Hide('tr38');Hide('tr39');Hide('tr40');Hide('tr41');Hide('tr42');Hide('tr43');Hide('tr44');Hide('tr45');Hide('tr46');Hide('tr47');Hide('tr48');Hide('tr101');Hide('tr102');Hide('hr01');Hide('hr02');Hide('hr03');Hide('tr010');Hide('tr011');Hide('tr012');Hide('tr013');Hide('tr014');Hide('tr015');Hide('tr016');
		}
		function ShowCss(){
			document.getElementById('imgcss').src="Images/uparrow.png";
			Show('tr60');Show('tr61');Show('tr62');Show('tr63');Show('tr64');Show('tr65');Show('tr66');Show('tr67');Show('tr68');Show('tr69');Show('tr70');Show('tr71');Show('tr72');Show('tr73');Show('tr74');Show('tr75');Show('tr76');Show('tr77');Show('tr78');Show('tr79');Show('tr80');Show('tr81');Show('tr82');Show('tr83');Show('tr84');Show('tr85');Show('tr86');Show('tr87');Show('tr97');Show('tr98');Show('hr05')
		}
		function HideCss(){
			document.getElementById('imgcss').src="Images/downarrow.png";
			Hide('tr60');Hide('tr61');Hide('tr62');Hide('tr63');Hide('tr64');Hide('tr65');Hide('tr66');Hide('tr67');Hide('tr68');Hide('tr69');Hide('tr70');Hide('tr71');Hide('tr72');Hide('tr73');Hide('tr74');Hide('tr75');Hide('tr76');Hide('tr77');Hide('tr78');Hide('tr79');Hide('tr80');Hide('tr81');Hide('tr82');Hide('tr83');Hide('tr84');Hide('tr85');Hide('tr86');Hide('tr87');Hide('tr97');Hide('tr98');Hide('hr05')
		}
		function SetHide(){
			ShowSite();HideMenuStd();HideMenuAdv();HideCss();HideDef()
		}
		function Right(String, Length)
		{
			if (String == null)
				return (false);

			var dest = '';
			for (var i = (String.length - 1); i >= 0; i--)
				dest = dest + String.charAt(i);

			String = dest;
			String = String.substr(0, Length);
			dest = '';

			for (var i = (String.length - 1); i >= 0; i--)
				dest = dest + String.charAt(i);

			return dest;
		}
		</script>
	</HEAD>
	<body onload="SetHide()" MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>&nbsp;</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="98%">
				<tr>
					<td width="50">
						&nbsp;
					</td>
					<td>
						<table>
							<tr>
								<td colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="Head" align="left"><asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
										</tr>
										<tr>
											<td>
												<hr noShade SIZE="1">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td class="Head" style="WIDTH: 300px" colSpan="4"><IMG id="imgsite" style="CURSOR: hand" onclick="CheckSite();" src="Images/uparrow.png">&nbsp;
									<asp:label id="lblSiteHeader" runat="server">lblSiteHeader</asp:label></td>
							</tr>
							<tr id="hr06">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr1">
								<td class="SubHead" noWrap><asp:label id="lblTitle" runat="server">lblTitle</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="txtTitle" runat="server" Width="160px">txtTitle</asp:textbox></td>
								<td vAlign="top" align="right" rowSpan="10"><IMG src="Images/Sites-2.jpg"></td>
							</tr>
							<tr id="tr2">
								<td class="SubHead" noWrap><asp:label id="lblLanguage" runat="server">lblLanguage</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddLanguage" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<!--
							<tr id="tr4">
								<td class="SubHead"><asp:label id="lblShowfooter" runat="server">lblShowfooter</asp:label></td>
								<td class="SubSubHead" colSpan="3">&nbsp;
									<asp:radiobutton id="rbShowfooter1" runat="server" GroupName="showfooter" Text="1"></asp:radiobutton><asp:radiobutton id="rbShowfooter2" runat="server" GroupName="showfooter" Text="2" Checked="True"></asp:radiobutton></td>
							</tr>
							<tr id="tr5">
								<td class="SubHead"><asp:label id="lblFooterleft" runat="server">lblFooterleft</asp:label></td>
								<td class="SubSubHead" colSpan="3">&nbsp;
									<asp:textbox id="txtFooterleft" runat="server" Width="312px">txtFooterleft</asp:textbox></td>
							</tr>
							<tr id="tr6">
								<td class="SubHead"><asp:label id="lblFootercontent" runat="server">lblFootercontent</asp:label></td>
								<td class="SubSubHead" colSpan="3">&nbsp;
									<asp:textbox id="txtFootercontent" runat="server" Width="312px">txtFootercontent</asp:textbox></td>
							</tr>
							<tr id="tr7">
								<td class="SubHead"><asp:label id="lblFooterright" runat="server">lblFooterright</asp:label></td>
								<td class="SubSubHead" colSpan="3">&nbsp;
									<asp:textbox id="txtFooterright" runat="server" Width="312px">txtFooterright</asp:textbox></td>
							</tr>
							-->
							<tr id="tr3">
								<td class="SubHead"><asp:label id="lblShowedit" runat="server">lblShowedit</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbShowedit1" runat="server" GroupName="showedit" Text="1"></asp:radiobutton><asp:radiobutton id="rbShowedit2" runat="server" GroupName="showedit" Text="2" Checked="True"></asp:radiobutton></td>
							</tr>
							<tr id="tr9">
								<td class="SubHead"><asp:label id="lblSoftdelete" runat="server">lblSoftdelete</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbSoftdelete1" runat="server" GroupName="softdelete" Text="1"></asp:radiobutton><asp:radiobutton id="rbSoftdelete2" runat="server" GroupName="softdelete" Text="2" Checked="True"></asp:radiobutton></td>
							</tr>
							<tr id="tr8">
								<td class="SubHead"><asp:label id="lblContentadjust" runat="server">lblContentadjust</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddContentadjust" runat="server" Width="160px">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
										<asp:ListItem Value="17">17</asp:ListItem>
										<asp:ListItem Value="18">18</asp:ListItem>
										<asp:ListItem Value="19">19</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="trn01">
								<td class="SubHead"><asp:label id="lblSiteWidth" runat="server">lblSiteWidth</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSiteWidth" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="trn001">
								<td class="SubHead"><asp:label id="lblSiteAlign" runat="server">lblSiteAlign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSiteAlign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="hr07">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr10">
								<td class="SubHead" vAlign="top" noWrap><asp:label id="lblColor" runat="server">lblColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;&nbsp;<asp:textbox id="bColor" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor();" type="button"
										size="20" value=".."></td>
							</tr>
							<tr id="tr11">
								<td class="SubHead" vAlign="top" noWrap><asp:label id="lblPicture" runat="server">lblPicture</asp:label></td>
								<td class="SubSubHead" colSpan="2">&nbsp;
									<asp:image id="imgPicture" runat="server"></asp:image></td>
								<td class="SubSubHead" style="WIDTH: 185px" vAlign="top" colSpan="1">&nbsp;<asp:button id="btnPicture" style="CURSOR: hand" runat="server" Text="btnPicture" CssClass="iCWebControlsII"></asp:button></td>
							</tr>
							<tr id="tr12">
								<td class="SubHead" noWrap><asp:label id="lblLogohorizontalalign" runat="server">lblLogohorizontalalign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddLogohorizontalalign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr13">
								<td class="SubHead" noWrap><asp:label id="lblLogoverticalalign" runat="server">lblLogoverticalalign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddLogoverticalalign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr110">
								<td class="SubHead" noWrap><asp:label id="lblLogoVerticalTiling" runat="server">lblLogoVerticalTiling</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbLogoHorizontalTiling1" runat="server" GroupName="horizontaltailing" Text="1"></asp:radiobutton><asp:radiobutton id="rbLogoHorizontalTiling2" runat="server" GroupName="horizontaltailing" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr111">
								<td class="SubHead" noWrap><asp:label id="lblLogoHorizontalTiling" runat="server">lblLogoHorizontalTiling</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbLogoVerticalTiling1" runat="server" GroupName="verticaltiling" Text="1"></asp:radiobutton><asp:radiobutton id="rbLogoVerticalTiling2" runat="server" GroupName="verticaltiling" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="hr08">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="trn02">
								<td class="SubHead" noWrap><asp:label id="lblContainerWidth1" runat="server">lblContainerWidth1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddContainerWidth1" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="trn03">
								<td class="SubHead" noWrap><asp:label id="lblContainerWidth2" runat="server">lblContainerWidth2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddContainerWidth2" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="trn04">
								<td class="SubHead" noWrap><asp:label id="lblContainerWidth3" runat="server">lblContainerWidth3</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddContainerWidth3" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="hr09">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="trn05">
								<td class="SubHead" vAlign="top"><asp:label id="lblMetaDescription" runat="server">lblMetaDescription</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="txtMetaDescription" runat="server" Width="160px" Height="60px" TextMode="MultiLine"
										MaxLength="1000" Rows="5">txtMetaDescription</asp:textbox></td>
							</tr>
							<tr id="trn06">
								<td class="SubHead" vAlign="top"><asp:label id="lblMetaKeywords" runat="server">lblMetaKeywords</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="txtMetaKeywords" runat="server" Width="160px" Height="60px" TextMode="MultiLine"
										MaxLength="1000" Rows="5">txtMetaKeywords</asp:textbox></td>
							</tr>
							<tr id="trn07">
								<td class="SubHead"><asp:label id="lblMetaAuthor" runat="server">lblMetaAuthor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="txtMetaAuthor" runat="server" Width="160px">txtMetaAuthor</asp:textbox></td>
							</tr>
							<tr id="trn08">
								<td class="SubHead"><asp:label id="lblMetaCopyright" runat="server">lblMetaCopyright</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="txtMetaCopyright" runat="server" Width="160px">txtMetaCopyright</asp:textbox></td>
							</tr>
							<tr id="trn09">
								<td class="SubHead"><asp:label id="lblMetaRobots" runat="server">lblMetaRobots</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="txtMetaRobots" runat="server" Width="160px">txtMetaRobots</asp:textbox></td>
							</tr>
							<tr id="tr14">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr95">
								<td align="right" colSpan="4">
									<table border="0">
										<tr>
											<td><asp:button id="btnSiteOk" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnSiteCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnSiteUpdate" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button></td>
											<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="tr96">
								<td colSpan="4">&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Head" style="WIDTH: 300px" colSpan="4"><IMG id="imgcss" style="CURSOR: hand" onclick="CheckCss();" src="Images/downarrow.png">&nbsp;
									<asp:label id="lblCssHeader" runat="server">lblCssHeader</asp:label></td>
							</tr>
							<tr id="hr05">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr60">
								<td class="SubHead"><asp:label id="lblHeadFamily" runat="server">lblHeadFamily</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHeadFamily" runat="server" Width="160px">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
										<asp:ListItem Value="Arial Narrow">Arial Narrow</asp:ListItem>
										<asp:ListItem Value="Century Schoolbook">Century Schoolbook</asp:ListItem>
										<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Engravers MT">Engravers MT</asp:ListItem>
										<asp:ListItem Value="Franklin Gothic Demi">Franklin Gothic Demi</asp:ListItem>
										<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
										<asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
										<asp:ListItem Value="System">System</asp:ListItem>
										<asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Verdana" Selected="True">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
								<td vAlign="top" align="right" rowSpan="10"><IMG src="Images/Style.jpg"></td>
							</tr>
							<tr id="tr61">
								<td class="SubHead"><asp:label id="lblHeadSize" runat="server">lblHeadSize</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHeadSize" runat="server" Width="160px">
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr62">
								<td class="SubHead"><asp:label id="lblHeadWeight" runat="server">lblHeadWeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHeadWeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr63">
								<td class="SubHead"><asp:label id="lblHeadColor" runat="server">lblHeadColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor12" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor12();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr64">
								<td class="SubHead"><asp:label id="lblSubHeadFamily" runat="server">lblSubHeadFamily</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubHeadFamily" runat="server" Width="160px">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
										<asp:ListItem Value="Arial Narrow">Arial Narrow</asp:ListItem>
										<asp:ListItem Value="Century Schoolbook">Century Schoolbook</asp:ListItem>
										<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Engravers MT">Engravers MT</asp:ListItem>
										<asp:ListItem Value="Franklin Gothic Demi">Franklin Gothic Demi</asp:ListItem>
										<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
										<asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
										<asp:ListItem Value="System">System</asp:ListItem>
										<asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Verdana" Selected="True">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr65">
								<td class="SubHead"><asp:label id="lblSubHeadSize" runat="server">lblSubHeadSize</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubHeadSize" runat="server" Width="160px">
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr66">
								<td class="SubHead"><asp:label id="lblSubHeadWeight" runat="server">lblSubHeadWeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubHeadWeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr67">
								<td class="SubHead"><asp:label id="lblSubHeadColor" runat="server">lblSubHeadColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor13" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor13();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr68">
								<td class="SubHead"><asp:label id="lblSubSubHeadFamily" runat="server">lblSubSubHeadFamily</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubSubHeadFamily" runat="server" Width="160px">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
										<asp:ListItem Value="Arial Narrow">Arial Narrow</asp:ListItem>
										<asp:ListItem Value="Century Schoolbook">Century Schoolbook</asp:ListItem>
										<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Engravers MT">Engravers MT</asp:ListItem>
										<asp:ListItem Value="Franklin Gothic Demi">Franklin Gothic Demi</asp:ListItem>
										<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
										<asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
										<asp:ListItem Value="System">System</asp:ListItem>
										<asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Verdana" Selected="True">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr69">
								<td class="SubHead"><asp:label id="lblSubSubHeadSize" runat="server">lblSubSubHeadSize</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubSubHeadSize" runat="server" Width="160px">
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr70">
								<td class="SubHead"><asp:label id="lblSubSubHeadWeight" runat="server">lblSubSubHeadWeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubSubHeadWeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr71">
								<td class="SubHead"><asp:label id="lblSubSubHeadColor" runat="server">lblSubSubHeadColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor14" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor14();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr72">
								<td class="SubHead"><asp:label id="lblNormalFamily" runat="server">lblNormalFamily</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddNormalFamily" runat="server" Width="160px">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
										<asp:ListItem Value="Arial Narrow">Arial Narrow</asp:ListItem>
										<asp:ListItem Value="Century Schoolbook">Century Schoolbook</asp:ListItem>
										<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Engravers MT">Engravers MT</asp:ListItem>
										<asp:ListItem Value="Franklin Gothic Demi">Franklin Gothic Demi</asp:ListItem>
										<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
										<asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
										<asp:ListItem Value="System">System</asp:ListItem>
										<asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Verdana" Selected="True">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr73">
								<td class="SubHead"><asp:label id="lblNormalSize" runat="server">lblNormalSize</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddNormalSize" runat="server" Width="160px">
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr74">
								<td class="SubHead"><asp:label id="lblNormalWeight" runat="server">lblNormalWeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddNormalWeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr75">
								<td class="SubHead"><asp:label id="lblNormalColor" runat="server">lblNormalColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor15" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor15();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr76">
								<td class="SubHead"><asp:label id="lblButtonFamily" runat="server">lblButtonFamily</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddButtonFamily" runat="server" Width="160px">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
										<asp:ListItem Value="Arial Narrow">Arial Narrow</asp:ListItem>
										<asp:ListItem Value="Century Schoolbook">Century Schoolbook</asp:ListItem>
										<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Engravers MT">Engravers MT</asp:ListItem>
										<asp:ListItem Value="Franklin Gothic Demi">Franklin Gothic Demi</asp:ListItem>
										<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
										<asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
										<asp:ListItem Value="System">System</asp:ListItem>
										<asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Verdana" Selected="True">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr77">
								<td class="SubHead" height="25"><asp:label id="lblButtonSize" runat="server">lblButtonSize</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3" height="25">&nbsp;
									<asp:dropdownlist id="ddButtonSize" runat="server" Width="160px">
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="11">11</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="13">13</asp:ListItem>
										<asp:ListItem Value="14">14</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
										<asp:ListItem Value="16">16</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr78">
								<td class="SubHead"><asp:label id="lblButtonWeight" runat="server">lblButtonWeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddButtonWeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr79">
								<td class="SubHead"><asp:label id="lblButtonForeColor" runat="server">lblButtonForeColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor16" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor16();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr80">
								<td class="SubHead"><asp:label id="lblButtonBackColor" runat="server">lblButtonBackColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor17" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor17();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr81">
								<td class="SubHead"><asp:label id="lblButtonBorderSize" runat="server">lblButtonBorderSize</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddButtonBorderSize" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr82">
								<td class="SubHead"><asp:label id="lblButtonBorderColor" runat="server">lblButtonBorderColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor18" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor18();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr83">
								<td class="SubHead"><asp:label id="lblButtonTextAlign" runat="server">lblButtonTextAlign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddButtonTextAlign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr84">
								<td class="SubHead"><asp:label id="lblHrHeight" runat="server">lblHrHeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHrHeight" runat="server" Width="160px">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr85">
								<td class="SubHead"><asp:label id="lblHrColor" runat="server">lblHrColor</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor19" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor19();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr86">
								<td class="SubHead"><asp:label id="lblHrAlign" runat="server">lblHrAlign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHrAlign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr87">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr97">
								<td align="left" colSpan="1"></td>
								<td align="right" colSpan="3">
									<table border="0">
										<tr>
											<td>
												<asp:button id="btnCssOk" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnCssCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnCssUpdate" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>
											</td>
											<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="tr98">
								<td colSpan="4">&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Head" style="WIDTH: 300px" width="433" colSpan="4"><IMG id="imgmenustd" style="CURSOR: hand" onclick="CheckMenuStd();" src="Images/downarrow.png">&nbsp;
									<asp:label id="lblMenuStdHeader" runat="server">lblMenuStdHeader</asp:label></td>
							</tr>
							<tr id="hr04">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr15">
								<td class="SubHead" vAlign="top" noWrap><asp:label id="lblMenuplacement" runat="server">lblMenuplacement</asp:label></td>
								<td class="SubSubHead" noWrap colSpan="3">
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td>&nbsp;<asp:radiobutton id="rbMenualign1" runat="server" GroupName="menualign" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenualign2" runat="server" GroupName="menualign" Text="2" Checked="True"></asp:radiobutton><asp:radiobutton id="rbMenualign3" runat="server" GroupName="menualign" Text="3"></asp:radiobutton><asp:radiobutton id="rbMenualign4" runat="server" GroupName="menualign" Text="4"></asp:radiobutton></td>
										</tr>
									</table>
								</td>
								<td vAlign="top" align="right" rowSpan="10"><IMG src="Images/meny-standard.jpg"></td>
							</tr>
							<tr id="tr34">
								<td class="SubHead" noWrap><asp:label id="lblMenualign" runat="server">lblMenualign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuplacement" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr18">
								<td class="SubHead"><asp:label id="lblMenutop" runat="server">lblMenutop</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenutop" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr20">
								<td class="SubHead"><asp:label id="lblMenuleft" runat="server">lblMenuleft</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuleft" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr19">
								<td class="SubHead"><asp:label id="lblMenuOffset" runat="server">lblMenuOffset</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuOffset" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr49">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr99">
								<td align="left" colSpan="1"></td>
								<td align="right" colSpan="3">
									<table border="0">
										<tr>
											<td><asp:button id="btnMenuStdOk" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnMenuStdCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnMenuStdUpdate" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button></td>
											<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="tr100">
								<td colSpan="4">&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Head" style="WIDTH: 300px" colSpan="4"><IMG id="imgmenuadv" style="CURSOR: hand" onclick="CheckMenuAdv();" src="Images/downarrow.png">&nbsp;
									<asp:label id="lblMenuAdvHeader" runat="server">lblMenuAdvHeader</asp:label></td>
							</tr>
							<tr id="hr03">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr16">
								<td class="SubHead" vAlign="top"><asp:label id="lblMenufade" runat="server">lblMenufade</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenufade1" runat="server" GroupName="menufade" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenufade2" runat="server" GroupName="menufade" Text="2" Checked="True"></asp:radiobutton></td>
								<td vAlign="top" align="right" rowSpan="16"><IMG src="Images/meny-advance.jpg"></td>
							</tr>
							<tr id="tr17">
								<td class="SubHead" vAlign="top"><asp:label id="lblMenufadetime" runat="server">lblMenufadetime</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenufadetime" runat="server" Width="160px">
										<asp:ListItem Value="0.0">0.0</asp:ListItem>
										<asp:ListItem Value="0.1">0.1</asp:ListItem>
										<asp:ListItem Value="0.2">0.2</asp:ListItem>
										<asp:ListItem Value="0.3">0.3</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
										<asp:ListItem Value="0.5">0.5</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.7">0.7</asp:ListItem>
										<asp:ListItem Value="0.8">0.8</asp:ListItem>
										<asp:ListItem Value="0.9">0.9</asp:ListItem>
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="1.1">1.1</asp:ListItem>
										<asp:ListItem Value="1.2">1.2</asp:ListItem>
										<asp:ListItem Value="1.3">1.3</asp:ListItem>
										<asp:ListItem Value="1.4">1.4</asp:ListItem>
										<asp:ListItem Value="1.5">1.5</asp:ListItem>
										<asp:ListItem Value="1.6">1.6</asp:ListItem>
										<asp:ListItem Value="1.7">1.7</asp:ListItem>
										<asp:ListItem Value="1.8">1.8</asp:ListItem>
										<asp:ListItem Value="1.9">1.9</asp:ListItem>
										<asp:ListItem Value="2.0">2.0</asp:ListItem>
										<asp:ListItem Value="2.1">2.1</asp:ListItem>
										<asp:ListItem Value="2.2">2.2</asp:ListItem>
										<asp:ListItem Value="2.3">2.3</asp:ListItem>
										<asp:ListItem Value="2.4">2.4</asp:ListItem>
										<asp:ListItem Value="2.5">2.5</asp:ListItem>
										<asp:ListItem Value="2.6">2.6</asp:ListItem>
										<asp:ListItem Value="2.7">2.7</asp:ListItem>
										<asp:ListItem Value="2.8">2.8</asp:ListItem>
										<asp:ListItem Value="2.9">2.9</asp:ListItem>
										<asp:ListItem Value="3.0">3.0</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr36">
								<td class="SubHead"><asp:label id="lblMenuwait" runat="server">lblMenuwait</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuwait" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr29">
								<td class="SubHead" style="HEIGHT: 5px"><asp:label id="lblMenufont" runat="server">lblMenufont</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px; HEIGHT: 5px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenufont" runat="server" Width="160px">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
										<asp:ListItem Value="Arial Narrow">Arial Narrow</asp:ListItem>
										<asp:ListItem Value="Century Schoolbook">Century Schoolbook</asp:ListItem>
										<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Engravers MT">Engravers MT</asp:ListItem>
										<asp:ListItem Value="Franklin Gothic Demi">Franklin Gothic Demi</asp:ListItem>
										<asp:ListItem Value="Georgia">Georgia</asp:ListItem>
										<asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
										<asp:ListItem Value="System">System</asp:ListItem>
										<asp:ListItem Value="Tahoma">Tahoma</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
										<asp:ListItem Value="Verdana" Selected="True">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr id="tr41">
								<td class="SubHead"><asp:label id="lblMenuRoundBorder" runat="server">lblMenuRoundBorder</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenuRoundBorder1" runat="server" GroupName="menuroundborder" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenuRoundBorder2" runat="server" GroupName="menuroundborder" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr010">
								<td class="SubHead"><asp:label id="lblMenuMultiplicator" runat="server">lblMenuMultiplicator</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuMultiplicator" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="hr02">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr35">
								<td class="SubHead"><asp:label id="lblMenubetween" runat="server">lblMenubetween</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenubetween" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr21">
								<td class="SubHead" noWrap><asp:label id="lblMenuforecolor1" runat="server">lblMenuforecolor1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor2" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor2();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr22">
								<td class="SubHead" noWrap><asp:label id="lblMenubackcolor1" runat="server">lblMenubackcolor1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor3" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor3();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr25">
								<td class="SubHead" noWrap><asp:label id="lblMenuoverforecolor1" runat="server">lblMenuoverforecolor1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor6" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor6();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr26">
								<td class="SubHead" noWrap><asp:label id="lblMenuoverbackcolor1" runat="server">lblMenuoverbackcolor1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor7" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor7();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr30">
								<td class="SubHead"><asp:label id="lblMenubold1" runat="server">lblMenubold1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenuBold1_1" runat="server" GroupName="menubold1" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenuBold1_2" runat="server" GroupName="menubold1" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr31">
								<td class="SubHead"><asp:label id="lblMenuoverbold1" runat="server">lblMenuoverbold1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenuOverBold1_1" runat="server" GroupName="menuoverbold1" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenuOverBold1_2" runat="server" GroupName="menuoverbold1" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr37">
								<td class="SubHead"><asp:label id="lblMenulevel1borderx" runat="server">lblMenulevel1borderx</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenulevel1borderx1" runat="server" GroupName="1borderx" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenulevel1borderx2" runat="server" GroupName="1borderx" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr38">
								<td class="SubHead"><asp:label id="lblMenulevel1bordery" runat="server">lblMenulevel1bordery</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenulevel1bordery1" runat="server" GroupName="1bordery" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenulevel1bordery2" runat="server" GroupName="1bordery" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr42">
								<td class="SubHead"><asp:label id="lblMenuFontSize1" runat="server">lblMenuFontSize1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuFontSize1" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr43">
								<td class="SubHead"><asp:label id="lblMenuOverFontSize1" runat="server">lblMenuOverFontSize1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuOverFontSize1" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr46">
								<td class="SubHead"><asp:label id="lblMenuBorderColor1" runat="server">lblMenuBorderColor1</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor10" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor10();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr011">
								<td class="SubHead"><asp:label id="lblHeadMenuTextAlign" runat="server">lblHeadMenuTextAlign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHeadMenuTextAlign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr012">
								<td class="SubHead"><asp:label id="lblHeadMenuWidth" runat="server">lblHeadMenuWidth</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHeadMenuWidth" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr013">
								<td class="SubHead"><asp:label id="lblHeadMenuHeight" runat="server">lblHeadMenuHeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddHeadMenuHeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<!-- SubMenu -->
							<tr id="hr01">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr23">
								<td class="SubHead" noWrap><asp:label id="lblMenuforecolor2" runat="server">lblMenuforecolor2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor4" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor4();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr24">
								<td class="SubHead" noWrap><asp:label id="lblMenubackcolor2" runat="server">lblMenubackcolor2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor5" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor5();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr27">
								<td class="SubHead" noWrap><asp:label id="lblMenuoverforecolor2" runat="server">lblMenuoverforecolor2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor8" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor8();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr28">
								<td class="SubHead" noWrap><asp:label id="lblMenuoverbackcolor2" runat="server">lblMenuoverbackcolor2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor9" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor9();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr32">
								<td class="SubHead"><asp:label id="lblMenubold2" runat="server">lblMenubold2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenuBold2_1" runat="server" GroupName="menubold2" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenuBold2_2" runat="server" GroupName="menubold2" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr33">
								<td class="SubHead"><asp:label id="lblMenuoverbold2" runat="server">lblMenuoverbold2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenuOverBold2_1" runat="server" GroupName="menuoverbold2" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenuOverBold2_2" runat="server" GroupName="menuoverbold2" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr39">
								<td class="SubHead"><asp:label id="lblMenulevel2borderx" runat="server">lblMenulevel2borderx</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenulevel2borderx1" runat="server" GroupName="2borderx" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenulevel2borderx2" runat="server" GroupName="2borderx" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr40">
								<td class="SubHead"><asp:label id="lblMenulevel2bordery" runat="server">lblMenulevel2bordery</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:radiobutton id="rbMenulevel2bordery1" runat="server" GroupName="2bordery" Text="1"></asp:radiobutton><asp:radiobutton id="rbMenulevel2bordery2" runat="server" GroupName="2bordery" Text="2"></asp:radiobutton></td>
							</tr>
							<tr id="tr44">
								<td class="SubHead"><asp:label id="lblMenuFontSize2" runat="server">lblMenuFontSize2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuFontSize2" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr45">
								<td class="SubHead"><asp:label id="lblMenuOverFontSize2" runat="server">lblMenuOverFontSize2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddMenuOverFontSize2" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr47">
								<td class="SubHead"><asp:label id="lblMenuBorderColor2" runat="server">lblMenuBorderColor2</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:textbox id="bColor11" runat="server" Width="143px" Font-Name="verdana"></asp:textbox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor11();" type="button"
										value=".."></td>
							</tr>
							<tr id="tr014">
								<td class="SubHead"><asp:label id="lblSubMenuTextAlign" runat="server">lblSubMenuTextAlign</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubMenuTextAlign" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr015">
								<td class="SubHead"><asp:label id="lblSubMenuWidth" runat="server">lblSubMenuWidth</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubMenuWidth" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr016">
								<td class="SubHead"><asp:label id="lblSubMenuHeight" runat="server">lblSubMenuHeight</asp:label></td>
								<td class="SubSubHead" style="WIDTH: 228px" width="228" colSpan="3">&nbsp;
									<asp:dropdownlist id="ddSubMenuHeight" runat="server" Width="160px"></asp:dropdownlist></td>
							</tr>
							<tr id="tr48">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr101">
								<td align="left" colSpan="1"></td>
								<td align="right" colSpan="3">
									<table border="0">
										<tr>
											<td><asp:button id="btnMenuAdvOk" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnMenuAdvCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnMenuAdvUpdate" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button></td>
											<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="tr102">
								<td colSpan="4">&nbsp;
								</td>
							</tr>
							<tr id="tr201">
								<td colSpan="4">
									<hr noShade SIZE="1">
								</td>
							</tr>
							<tr id="tr202">
								<td align="left" colSpan="1"></td>
								<td align="right" colSpan="3">
									<table border="0">
										<tr>
											<td><asp:button id="btnMenuDefOk" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnMenuDefCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button>&nbsp;
												<asp:button id="btnMenuDefUpdate" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="tr203">
								<td colSpan="4">&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
