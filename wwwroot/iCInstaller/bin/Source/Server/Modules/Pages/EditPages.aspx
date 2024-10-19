<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditPages.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Pages.EditPages" %>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditLitePages</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<script src="Js/Color.js" type="text/javascript"></script>
		<script>
		function CheckStd(){
			try{
				if(document.getElementById('s01').style.display=='none'){
					ShowStd();
				}
				else{
					HideStd();
				}
			}
			catch(e){
			
			}
		}
		function ShowStd(){
			document.getElementById('imgstd').src="Images/uparrow.png";
			Show('s01');Show('s02');Show('s03');Show('s04');Show('s05');Show('s06');Show('s07');Show('s08');
		}
		function HideStd(){
			document.getElementById('imgstd').src="Images/downarrow.png";
			Hide('s01');Hide('s02');Hide('s03');Hide('s04');Hide('s05');Hide('s06');Hide('s07');Hide('s08');
		}
		function CheckAdv(){
			if(document.getElementById('tr01').style.display=='none'){
				ShowAdv();
			}
			else{
				HideAdv();
			}
		}
		function ShowAdv(){
			document.getElementById('imgadv').src="Images/uparrow.png";
			Show('tr01');Show('tr02');Show('tr03');Show('tr04');Show('tr05');Show('tr06');Show('tr07');Show('tr08');Show('tr09');Show('tr10');Show('tr11');Show('tr12');Show('tr13');Show('tr14');
		}
		function HideAdv(){
			document.getElementById('imgadv').src="Images/downarrow.png";
			Hide('tr01');Hide('tr02');Hide('tr03');Hide('tr04');Hide('tr05');Hide('tr06');Hide('tr07');Hide('tr08');Hide('tr09');Hide('tr10');Hide('tr11');Hide('tr12');Hide('tr13');Hide('tr14');
		}
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
		function CheckIfHide(){
				ShowStd();
				HideAdv();
			<%If ExpandMinimizer Then%>
				HideStd();
				ShowAdv();
			<%Else%>
				ShowStd();
				HideAdv();
			<%End If%>
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout" onload="CheckIfHide();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top" height="30">
					<td colSpan="2">&nbsp;</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="4" width="98%">
				<tr vAlign="top">
					<td width="50">&nbsp;
					</td>
					<td width="*">
						<table cellSpacing="0" cellPadding="4" width="98%">
							<tr vAlign="top">
								<td width="30">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="1" cellPadding="2" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="Head" align="left">&nbsp;
															<asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
													</tr>
													<tr>
														<td>
															<hr noShade SIZE="1">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<!-- Standard Settings Start -->
										<tr>
											<td class="Head" width="520" colSpan="4"><IMG id="imgstd" style="CURSOR: hand" onclick="CheckStd();" src="Images/uparrow.png">&nbsp;
												<asp:Label id="lblStdHeader" runat="server">lblStdHeader</asp:Label></td>
										</tr>
										<%If Not IsAdmin Then%>
										<tr id="s01">
											<td class="SubHead" width="120"><asp:label id="lblName" runat="server">lblName</asp:label></td>
											<td colSpan="3"><asp:textbox id="PageName" runat="server" width="300" cssclass="NormalTextBox"></asp:textbox></td>
										</tr>
										<%End If%>
										<tr id="s02">
											<td class="SubHead" vAlign="top" noWrap><asp:label id="lblRoles" runat="server">lblRoles</asp:label></td>
											<td colSpan="3"><asp:checkboxlist id="authRoles" runat="server" RepeatColumns="3" Font-Names="Verdana,Arial" Font-Size="8pt"></asp:checkboxlist></td>
										</tr>
										<%If Not IsAdmin Then%>
										<tr id="s03">
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr id="s04">
											<td class="SubHead"><asp:label id="lblAddMod" runat="server">lblAddMod</asp:label></td>
											<td class="SubSubHead"><asp:label id="lblModType" runat="server">lblModType</asp:label></td>
											<td colSpan="2"><asp:dropdownlist id="moduleType" runat="server" DataValueField="ModuleDefID" DataTextField="FriendlyName"></asp:dropdownlist></td>
										</tr>
										<tr id="s05">
											<td>&nbsp;
											</td>
											<td class="SubSubHead"><asp:label id="lblModName" runat="server">lblModName</asp:label></td>
											<td colSpan="2"><asp:textbox id="moduleTitle" runat="server" width="250" cssclass="NormalTextBox" EnableViewState="false"
													Text="Nytt Modul Namn"></asp:textbox></td>
										</tr>
										<tr id="s06">
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<table width="100%">
													<tr>
														<td align="center"><asp:button id="btnAdd" runat="server" Text="btnAdd" CssClass="iCWebControlsII"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="s07">
											<td>&nbsp;
											</td>
											<td colSpan="3">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr id="s08" vAlign="top">
											<td class="SubHead"><asp:label id="lblOrg" runat="server">lblOrg</asp:label></td>
											<td width="120">
												<table cellSpacing="0" cellPadding="2" width="100%" border="0">
													<tr>
														<td class="SubSubHead">&nbsp;
															<asp:label id="lblLeftModField" runat="server">lblLeftModField</asp:label></td>
													</tr>
													<tr vAlign="top">
														<td>
															<table cellSpacing="2" cellPadding="0" border="0">
																<tr vAlign="top">
																	<td rowSpan="2"><asp:listbox id=LeftModuleField runat="server" width="110" DataValueField="ModuleId" DataTextField="ModuleTitle" DataSource="<%# leftList %>" rows="7"></asp:listbox></td>
																	<td vAlign="top" noWrap><asp:imagebutton id="LeftUpBtn" runat="server" ImageUrl="Images/MovePageUp.gif" CommandName="up"
																			CommandArgument="LeftModuleField" AlternateText="Flytta markerad modul upp i listan"></asp:imagebutton><br>
																		<asp:imagebutton id="LeftRightBtn" runat="server" ImageUrl="Images/MovePageRight.gif" CommandName="right"
																			AlternateText="Flytta markerad modul till det centrerade fältet" sourcepane="LeftModuleField"
																			targetpane="ContentModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="LeftDownBtn" runat="server" ImageUrl="Images/MovePageDown.gif" CommandName="down"
																			CommandArgument="LeftModuleField" AlternateText="Flytta markerad modul ner i listan"></asp:imagebutton>&nbsp;&nbsp;
																	</td>
																</tr>
																<tr>
																	<td vAlign="bottom" noWrap><asp:imagebutton id="LeftEditBtn" runat="server" ImageUrl="Images/EditPage.gif" CommandName="edit"
																			CommandArgument="LeftModuleField" AlternateText="Editera"></asp:imagebutton><br>
																		<asp:imagebutton id="LeftDeleteBtn" runat="server" ImageUrl="Images/DeletePage.gif" CommandName="delete"
																			CommandArgument="LeftModuleField" AlternateText="Radera"></asp:imagebutton></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
											<td width="*">
												<table cellSpacing="0" cellPadding="2" width="100%" border="0">
													<tr>
														<td class="SubSubHead" align="center">
															<asp:label id="lblContentModField" runat="server">lblContentModField</asp:label></td>
													</tr>
													<tr>
														<td align="center">
															<table cellSpacing="2" cellPadding="0" border="0">
																<tr vAlign="top">
																	<td rowSpan="2"><asp:listbox id=ContentModuleField runat="server" width="170" DataValueField="ModuleId" DataTextField="ModuleTitle" DataSource="<%# contentList %>" rows="7"></asp:listbox></td>
																	<td vAlign="top" noWrap><asp:imagebutton id="ContentUpBtn" runat="server" ImageUrl="Images/MovePageUp.gif" CommandName="up"
																			CommandArgument="ContentModuleField" AlternateText="Flytta markerad modul upp i listan"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentLeftBtn" runat="server" ImageUrl="Images/MovePageLeft.gif" AlternateText="Flytta markerad modul till vänstra fältet"
																			sourcepane="ContentModuleField" targetpane="LeftModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentRightBtn" runat="server" ImageUrl="Images/MovePageRight.gif" AlternateText="Flytta markerad modul till högra fältet"
																			sourcepane="ContentModuleField" targetpane="RightModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentDownBtn" runat="server" ImageUrl="Images/MovePageDown.gif" CommandName="down"
																			CommandArgument="ContentModuleField" AlternateText="Flytta markerad modul ner i listan"></asp:imagebutton>&nbsp;&nbsp;
																	</td>
																</tr>
																<tr>
																	<td vAlign="bottom" noWrap><asp:imagebutton id="ContentEditBtn" runat="server" ImageUrl="Images/EditPage.gif" CommandName="edit"
																			CommandArgument="ContentModuleField" AlternateText="Editera"></asp:imagebutton><br>
																		<asp:imagebutton id="ContentDeleteBtn" runat="server" ImageUrl="Images/DeletePage.gif" CommandName="delete"
																			CommandArgument="ContentModuleField" AlternateText="Radera"></asp:imagebutton></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
											<td width="120">
												<table cellSpacing="0" cellPadding="2" width="100%" border="0">
													<tr>
														<td class="SubSubHead">&nbsp;
															<asp:label id="lblRightModField" runat="server">lblRightModField</asp:label></td>
													</tr>
													<TR>
														<td>
															<table cellSpacing="2" cellPadding="0" border="0">
																<tr vAlign="top">
																	<td rowSpan="2"><asp:listbox id=RightModuleField runat="server" width="110" DataValueField="ModuleId" DataTextField="ModuleTitle" DataSource="<%# rightList %>" rows="7"></asp:listbox></td>
																	<td vAlign="top" noWrap><asp:imagebutton id="RightUpBtn" runat="server" ImageUrl="Images/MovePageUp.gif" CommandName="up"
																			CommandArgument="RightModuleField" AlternateText="Flytta markerad modul upp i listan"></asp:imagebutton><br>
																		<asp:imagebutton id="RightLeftBtn" runat="server" ImageUrl="Images/MovePageLeft.gif" AlternateText="Flytta markerad modul till det centrerade fältet"
																			sourcepane="RightModuleField" targetpane="ContentModuleField"></asp:imagebutton><br>
																		<asp:imagebutton id="RightDownBtn" runat="server" ImageUrl="Images/MovePageDown.gif" CommandName="down"
																			CommandArgument="RightModuleField" AlternateText="Flytta markerad modul ner i listan"></asp:imagebutton></td>
																</tr>
																<tr>
																	<td vAlign="bottom" noWrap><asp:imagebutton id="RightEditBtn" runat="server" ImageUrl="Images/EditPage.gif" CommandName="edit"
																			CommandArgument="RightModuleField" AlternateText="Editera"></asp:imagebutton><br>
																		<asp:imagebutton id="RightDeleteBtn" runat="server" ImageUrl="Images/DeletePage.gif" CommandName="delete"
																			CommandArgument="RightModuleField" AlternateText="Radera"></asp:imagebutton></td>
																</tr>
															</table>
														</td>
													</TR>
												</table>
											</td>
										</tr>
										<%End If%>
										<!-- Standard Settings End -->
										<!-- Advanced Settings Start -->
										<tr>
											<td class="Head" width="520" colSpan="4"><IMG id="imgadv" style="CURSOR: hand" onclick="CheckAdv();" src="Images/uparrow.png">&nbsp;
												<asp:Label id="lblAdvHeader" runat="server">lblAdvHeader</asp:Label></td>
										</tr>
										<tr id="tr01">
											<td class="SubHead" width="120"><asp:label id="lblLeftWidth" runat="server">lblLeftWidth</asp:label></td>
											<td colSpan="3"><asp:dropdownlist id="ddlV" runat="server" EnableViewState="true" Width="160px"></asp:dropdownlist></td>
										</tr>
										<tr id="tr02">
											<td class="SubHead" width="120">
												<asp:Label id="lblContentWidth" runat="server">lblContentWidth</asp:Label>
											</td>
											<td>
												<asp:DropDownList id="ddlC" runat="server" Width="160px"></asp:DropDownList>
											</td>
											<td>
												<asp:CheckBox id="chkContentAlignCenter" runat="server" CssClass="SubSubHead" Text="chkContentAlignCenter"></asp:CheckBox>
											</td>
											<td>
											</td>
										</tr>
										<tr id="tr03">
											<td class="SubHead" width="120"><asp:label id="lblRightWidth" runat="server">lblRightWidth</asp:label></td>
											<td colSpan="3"><asp:dropdownlist id="ddlH" runat="server" EnableViewState="true" Width="160px"></asp:dropdownlist></td>
										</tr>
										<tr id="tr14">
											<td class="SubHead" width="120">
												<asp:Label id="lblTop" runat="server">lblTop</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:DropDownList id="ddTop" runat="server" Width="160px"></asp:DropDownList></td>
										</tr>
										<tr id="tr05">
											<td class="SubHead" width="120">
												<asp:Label id="lblHeight" runat="server">lblHeight</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:DropDownList id="ddHeight" runat="server" Width="160px"></asp:DropDownList></td>
										</tr>
										<tr id="tr13">
											<td class="SubHead" width="120">
												<asp:Label id="lblUseMinimizer" runat="server">lblUseMinimizer</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:RadioButton id="rbUseMinimizer1" runat="server" Text="Ja" GroupName="minimizer" CssClass="SubSubHead"></asp:RadioButton>
												<asp:RadioButton id="rbUseMinimizer2" runat="server" Text="Nej" GroupName="minimizer" CssClass="SubSubHead"></asp:RadioButton></td>
										</tr>
										<%If Not IsHomeOrAdmin Then%>
										<tr id="tr04">
											<td class="SubHead" width="120">
												<asp:label id="lblIsVisible" runat="server">lblIsVisible</asp:label></td>
											<td colSpan="3" width="400">
												<asp:radiobutton id="rbVisible1" runat="server" Text="Ja" CssClass="SubSubHead" GroupName="shw" Checked="True"></asp:radiobutton>
												<asp:radiobutton id="rbVisible2" runat="server" Text="Nej" CssClass="SubSubHead" GroupName="shw"></asp:radiobutton></td>
										</tr>
										<%End If%>
										<tr id="tr06">
											<td class="SubHead" width="120" height="23">
												<asp:Label id="lblBackColor" runat="server">lblBackColor</asp:Label></td>
											<td colSpan="3" width="400" height="23">
												<asp:TextBox id="txtBackColor" runat="server" Width="143px"></asp:TextBox><INPUT style="WIDTH: 15px; CURSOR: hand; HEIGHT: 22px" onclick="ChangeColor2();" type="button"
													size="20" value=".."></td>
										</tr>
										<tr id="tr07">
											<td class="SubHead" width="120">
												<asp:Label id="lblBackPicture" runat="server">lblBackPicture</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:Image id="imgBackPicture" runat="server"></asp:Image>
												<asp:Button id="btnBackPicture" runat="server" Text="btnBackPicture" CssClass="iCWebControlsII"></asp:Button></td>
										</tr>
										<tr id="tr08">
											<td class="SubHead" width="120">
												<asp:Label id="lblBackPictureHorizontalAlign" runat="server">lblBackPictureHorizontalAlign</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:DropDownList id="ddBackPictureHorizontalAlign" runat="server" Width="160px"></asp:DropDownList></td>
										</tr>
										<tr id="tr09">
											<td class="SubHead" width="120">
												<asp:Label id="lblBackPictureVerticalAlign" runat="server">lblBackPictureVerticalAlign</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:DropDownList id="ddBackPictureVerticalAlign" runat="server" Width="160px"></asp:DropDownList></td>
										</tr>
										<tr id="tr10">
											<td class="SubHead" width="120">
												<asp:Label id="lblBackPictureHorizontalTiling" runat="server">lblBackPictureHorizontalTiling</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:RadioButton id="rbBackPictureHorizontalTiling1" runat="server" Text="Ja" CssClass="SubSubHead"
													GroupName="horizontaltiling"></asp:RadioButton>
												<asp:RadioButton id="rbBackPictureHorizontalTiling2" runat="server" Text="Nej" CssClass="SubSubHead"
													GroupName="horizontaltiling"></asp:RadioButton></td>
										</tr>
										<tr id="tr11">
											<td class="SubHead" width="120">
												<asp:Label id="lblBackPictureVerticalTiling" runat="server">lblBackPictureVerticalTiling</asp:Label></td>
											<td colSpan="3" width="400">
												<asp:RadioButton id="rbBackPictureVerticalTiling1" runat="server" Text="Ja" CssClass="SubSubHead"
													GroupName="verticaltiling"></asp:RadioButton>
												<asp:RadioButton id="rbBackPictureVerticalTiling2" runat="server" Text="Nej" CssClass="SubSubHead"
													GroupName="verticaltiling"></asp:RadioButton></td>
										</tr>
										<tr>
											<td class="SubHead" width="120"></td>
											<td colSpan="3" width="400"></td>
										</tr>
										<tr id="tr12">
											<td class="SubHead" width="120"></td>
											<td colSpan="3" width="400"></td>
										</tr>
										<!-- Advanced Settings End -->
										<tr>
											<td colSpan="4">
												<hr noShade SIZE="1">
											</td>
										</tr>
										<tr>
											<td colSpan="2" align="left"></td>
											<td colSpan="2" align="right">
												<table border="0">
													<tr>
														<td>
															<asp:button id="btnSave" runat="server" Text="btnSave" CssClass="iCWebControlsII"></asp:button>&nbsp;
															<asp:button id="btnCancel" runat="server" Text="btnSave" CssClass="iCWebControlsII"></asp:button>&nbsp;
															<asp:button id="btnUpdate" runat="server" Text="btnUpdate" CssClass="iCWebControlsII"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE></form>
		<!--

<tr>
	<td class="SubHead" width="120"></td>
	<td colSpan="3" width="400"></td>
</tr>
-->
	</body>
</HTML>
