<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" validaterequest="false" autoeventwireup="false" codebehind="PublisherEdit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Publisher.PublisherEdit" %>
<HTML>
	<HEAD>
		<title>PublisherEdit</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="Js/PublisherGeneric.js" type="text/javascript"></script>
		<script src="Js/PublisherFont.js" type="text/javascript"></script>
		<script src="Js/PublisherUIStyle.js" type="text/javascript"></script>
		<script src="Js/PublisherColor.js" type="text/javascript"></script>
		<script src="Js/PublisherTable.js" type="text/javascript"></script>
		<script src="Js/PublisherMedia.js" type="text/javascript"></script>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<style type="text/css">.menubuttons { CURSOR: hand }
		</style>
	</HEAD>
	<body onload="Initialize();" ms_positioning="GridLayout">
		<table cellspacing="0" cellpadding="0" width="100%" border="0">
			<tbody>
				<tr valign="top" height="100">
					<td colspan="2">
					</td>
				</tr>
				<tr>
					<td>
						<table cellspacing="0" cellpadding="4" width="98%" border="0">
							<tbody>
								<tr valign="top">
									<td width="150">
										&nbsp;
									</td>
									<td>
										<table cellspacing="0" cellpadding="0" width="800">
											<tbody>
												<tr>
													<td class="Head" align="left">
														Editor
													</td>
												</tr>
												<tr>
													<td colspan="2">
														<hr noshade size="1">
													</td>
												</tr>
											</tbody>
										</table>
										<br>
										<table id="toolbarCtrls" height="25" cellspacing="0" cellpadding="0" width="804" border="1">
											<tr valign="top" bgcolor="#0d3171"><!-- #0d3171 -->
												<td class="toolz" valign="middle" align="left">
													<!-- 23 item -->
													<table>
														<tr>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<script>if(ShowSpecialCommand){document.write('<td><input onfocus=this.blur() onclick=ChangeContentViewMode() type=checkbox checked=checked /></td>');}</script>
															<script>if(ShowSpecialCommand){document.write('<td><span id=\"POP"\ style=\"FONT-SIZE: 11px; WIDTH: 65px; COLOR: white; FONT-FAMILY: Tahoma; HEIGHT: 13px"\><%=DesignMode%></span></td>');}</script>
															<script>if(ShowSpecialCommand){document.write('<td><img height=22 src=Images/separator.gif width=5 border=0 /></td>');}</script>
															<script>if(!ShowSpecialCommand){document.write('<td colspan=3>&nbsp;</td>');}</script>
															<script>//if(ShowMS6Command){document.write('<td colspan=6><select style=\'FONT: 8pt verdana\' onchange=ChangeFontHead(this.options[this.selectedIndex].value) name=FontHeading><option class=OptionItems value= selected=selected><%=Header%></option><option class=OptionItems value=Heading 1>H1</option><option class=OptionItems value=Heading 2>H2</option><option class=OptionItems value=Heading 3>H3</option><option class=OptionItems value=Heading 4>H4</option><option class=OptionItems value=Heading 5>H5</option><option class=OptionItems value=Heading 6>H6</option><option class=OptionItems value=Numbered List>Num List</option><option class=OptionItems value=Menu List>Menu List</option><option class=OptionItems value=Address>Address</option><option class=OptionItems value=Directory List>Directory List</option></select></td>');}
															</script>
															<script>//if(!ShowMS6Command){document.write('<td colspan=6>&nbsp;</td>');}
															</script>
															<script>document.write('<td colspan=6>&nbsp;</td>');</script>
															<td colspan="6"><select style="FONT: 8pt verdana" onchange="ChangeFontStyle(this.options[this.selectedIndex].value)"
																	name="FontStyle">
																	<option class="OptionItems" value="" selected><%=Font%></option>
																	<option class="OptionItems" value="Arial">Arial</option>
																	<option class="OptionItems" value="Arial Black">Arial Black</option>
																	<option class="OptionItems" value="Arial Narrow">Arial Narrow</option>
																	<option class="OptionItems" value="Century Schoolbook">Century Schoolbook</option>
																	<option class="OptionItems" value="Comic Sans MS">Comic Sans MS</option>
																	<option class="OptionItems" value="Courier New">Courier New</option>
																	<option class="OptionItems" value="Engravers MT">Engravers MT</option>
																	<option class="OptionItems" value="Franklin Gothic Demi">Franklin Gothic Demi</option>
																	<option class="OptionItems" value="Georgia">Georgia</option>
																	<option class="OptionItems" value="Sans Serif">Sans Serif</option>
																	<option class="OptionItems" value="System">System</option>
																	<option class="OptionItems" value="Tahoma">Tahoma</option>
																	<option class="OptionItems" value="Times New Roman">Times New Roman</option>
																	<option class="OptionItems" value="Trebuchet MS">Trebuchet MS</option>
																	<option class="OptionItems" value="Verdana">Verdana</option>
																</select></td>
															<td colspan="6"><select style="FONT: 8pt verdana" onchange="ChangeFontSize(this.options[this.selectedIndex].value);"
																	name="FontSize">
																	<option class="OptionItems" value="" selected><%=FontSize%></option>
																	<option class="OptionItems" value="1">1</option>
																	<option class="OptionItems" value="2">2</option>
																	<option class="OptionItems" value="3">3</option>
																	<option class="OptionItems" value="4">4</option>
																	<option class="OptionItems" value="5">5</option>
																	<option class="OptionItems" value="6">6</option>
																	<option class="OptionItems" value="7">7</option>
																	<option class="OptionItems" value="+1">+1</option>
																	<option class="OptionItems" value="+2">+2</option>
																	<option class="OptionItems" value="+3">+3</option>
																	<option class="OptionItems" value="+4">+4</option>
																	<option class="OptionItems" value="+5">+5</option>
																	<option class="OptionItems" value="+6">+6</option>
																	<option class="OptionItems" value="+7">+7</option>
																</select></td>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr valign="top" bgcolor="#E0DFE3">
												<td class="toolz" valign="middle" align="left">
													<!-- 23 item -->
													<table>
														<tr>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Undo%>" onfocus="this.blur()" onclick="ExecuteCommand('Undo')" onmouseout="MouseOut(this)"
																	height="22" alt="Undo" src="Images/undo.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Redo%>"  onfocus="this.blur()" onclick="ExecuteCommand('Redo')" onmouseout="MouseOut(this)"
																	height="22" alt="Redo" src="Images/redo.gif" width="23" border="0"></td>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Print%>" onfocus="this.blur()" onclick="window.print()" onmouseout="MouseOut(this)"
																	height="22" alt="Print" src="Images/print.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=SelectAll%>" onfocus="this.blur()" onclick="ExecuteCommand('SelectAll')" onmouseout="MouseOut(this)"
																	height="22" alt="SelectAll" src="Images/select.gif" width="23" border="0"></td>
															<script>if(ShowSpecialCommand){document.write('<td><img onmouseup=MouseUp(this) class=menubuttons onmousedown=MouseDown(this) onmouseover=MouseOver(this) title=<%=Cut%> onfocus=this.blur() onclick=ExecuteCommand(\'Cut\') onmouseout=MouseOut(this) height=22 alt=Cut src=Images/cut.gif width=23 border=0 /></td>');}</script>
															<script>if(ShowSpecialCommand){document.write('<td><img onmouseup=MouseUp(this) class=menubuttons onmousedown=MouseDown(this) onmouseover=MouseOver(this) title=<%=Copy%> onfocus=this.blur() onclick=ExecuteCommand(\'Copy\') onmouseout=MouseOut(this) height=22 alt=Copy src=Images/copy.gif width=23 border=0 /></td>');}</script>
															<script>if(ShowSpecialCommand){document.write('<td><img onmouseup=MouseUp(this) class=menubuttons onmousedown=MouseDown(this) onmouseover=MouseOver(this) title=<%=Paste%> onfocus=this.blur() onclick=ExecuteCommand(\'Paste\') onmouseout=MouseOut(this) height=22 alt=Paste src=Images/paste.gif width=23 border=0 /></td>');}</script>
															<script>if(!ShowSpecialCommand){document.write('<td colspan=3>&nbsp;</td>');}</script>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Bold%>" onfocus="this.blur()" onclick="ExecuteCommand('Bold')" onmouseout="MouseOut(this)"
																	height="22" alt="Bold" src="Images/bold.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Italic%>" onfocus="this.blur()" onclick="ExecuteCommand('Italic')" onmouseout="MouseOut(this)"
																	height="22" alt="Italic" src="Images/italic.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Underline%>" onfocus="this.blur()" onclick="ExecuteCommand('Underline')" onmouseout="MouseOut(this)"
																	height="22" alt="Underline" src="Images/underline.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Strikethrou%>" onfocus="this.blur()" onclick="ExecuteCommand('StrikeThrough')"
																	onmouseout="MouseOut(this)" height="22" alt="Strikethrough" src="Images/strikethrough.gif"
																	width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Left%>" onfocus="this.blur()" onclick="ExecuteCommand('Justifyleft')" onmouseout="MouseOut(this)"
																	height="22" alt="Left" src="Images/left.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Center%>" onfocus="this.blur()" onclick="ExecuteCommand('Justifycenter')" onmouseout="MouseOut(this)"
																	height="22" alt="Center" src="Images/centre.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Right%>" onfocus="this.blur()" onclick="ExecuteCommand('JustifyRight')" onmouseout="MouseOut(this)"
																	height="22" alt="Right" src="Images/right.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=OrderedList%>" onfocus="this.blur()" onclick="ExecuteCommand('Insertorderedlist')"
																	onmouseout="MouseOut(this)" height="22" alt="Ordered List" src="Images/orderlist.gif"
																	width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=BulletedList%>" onfocus="this.blur()" onclick="ExecuteCommand('Insertunorderedlist')"
																	onmouseout="MouseOut(this)" height="22" alt="Bulleted List" src="Images/bulletlist.gif"
																	width="23" border="0"></td>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Unindent%>" onfocus="this.blur()" onclick="ExecuteCommand('Outdent')" onmouseout="MouseOut(this)"
																	height="22" alt="Unindent" src="Images/outdent.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Indent%>" onfocus="this.blur()" onclick="ExecuteCommand('Indent')" onmouseout="MouseOut(this)"
																	height="22" alt="Indent" src="Images/indent.gif" width="23" border="0"></td>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr valign="top" bgcolor="#E0DFE3">
												<td valign="middle" align="left">
													<!-- 23 item -->
													<table>
														<tr>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=UpperCase%>" onfocus="this.blur()" onclick="UpperCase()" onmouseout="MouseOut(this)"
																	height="22" alt="Make Text UpperCase" src="Images/upper.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=LowerCase%>" onfocus="this.blur()" onclick="LowerCase()" onmouseout="MouseOut(this)"
																	height="22" alt="Make Text UpperCase" src="Images/lower.gif" width="23" border="0"></td>
															<script>if(ShowSpecialCommand){document.write('<td><img onmouseup=MouseUp(this) class=menubuttons onmousedown=MouseDown(this) onmouseover=MouseOver(this) title=SuperScript  onfocus=this.blur() onclick=ExecuteCommand(\'SuperScript\') onmouseout=MouseOut(this) height=22 src=Images/superscript.gif width=23 border=0 /></td>');}</script>
															<script>if(ShowSpecialCommand){document.write('<td><img onmouseup=MouseUp(this) class=menubuttons onmousedown=MouseDown(this) onmouseover=MouseOver(this) title=SubScript onfocus=this.blur() onclick=ExecuteCommand(\'SubScript\') onmouseout=MouseOut(this) height=22 src=Images/subscript.gif width=23 border=0 /></td>');}</script>
															<script>if(!ShowSpecialCommand){document.write('<td colspan=2>&nbsp;</td>');}</script>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Horizontal%>" onfocus="this.blur()" onclick="CreateHorizontalRule()"
																	onmouseout="MouseOut(this)" height="22" alt="Add Horizontal Rule" src="Images/hr.gif"
																	width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=TextColor%>" onfocus="this.blur()" onclick="ChangeForeColor()" onmouseout="MouseOut(this)"
																	height="22" alt="Text Color" src="Images/color.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=BGColor%>" onfocus="this.blur()" onclick="ChangeBackColor()" onmouseout="MouseOut(this)"
																	height="22" alt="Text BG Color" src="Images/fontback.gif" width="23" border="0"></td>
															<script>if(ShowSpecialCommand){document.write('<td><img onmouseup=MouseUp(this) class=menubuttons onmousedown=MouseDown(this) onmouseover=MouseOver(this) title=<%=Symbol%> onfocus=this.blur() onclick=if(Editable){CreateNewSymbol()}else{alertmedd()} onmouseout=MouseOut(this) height=22 alt=Insert Symbol src=Images/symbol.gif width=23 border=0 /></td>');}</script>
															<script>if(!ShowSpecialCommand){document.write('<td colspan=1>&nbsp;</td>');}</script>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Table%>" onfocus="this.blur()" onclick="if(Editable){CreateTablePre()}else{alertmedd()}"
																	onmouseout="MouseOut(this)" height="22" alt="Create A Table" src="Images/table.gif"
																	width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Link%>" onfocus="this.blur()" onclick="CreateLink()" onmouseout="MouseOut(this)"
																	height="22" alt="Add URL" src="Images/link.gif" width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)" title="<%=Image%>" onfocus="this.blur()" onclick="if(Editable){CreateNewImage(<%=PageId%>,<%=ModId%>)}else{alertmedd()}" onmouseout="MouseOut(this)" height="22" alt="Add URL" src="Images/image.gif" width="23" border="0" ></td>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Preview%>" onfocus="this.blur()" onclick="WebBrowserPreview()"
																	onmouseout="MouseOut(this)" height="22" alt="Preview in Internet Explorer" src="Images/preview.gif"
																	width="23" border="0"></td>
															<td><img onmouseup="MouseUp(this)" class="menubuttons" onmousedown="MouseDown(this)" onmouseover="MouseOver(this)"
																	title="<%=Delete%>" onfocus="this.blur()" onclick="ExecuteCommand('Delete')" onmouseout="MouseOut(this)"
																	height="22" alt="Delete" src="Images/delete.gif" width="23" border="0"></td>
															<td><img height="22" src="Images/separator.gif" width="5" border="0"></td>
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td>&nbsp;</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
										<table>
											<tr>
												<td>
													<iframe id="ContentView" style="BORDER-RIGHT: #0d3171 thin solid; BORDER-TOP: #0d3171 thin solid; BORDER-LEFT: #0d3171 thin solid; COLOR: green; BORDER-BOTTOM: #0d3171 thin solid"
														frameborder="yes" width="800" height="350" src="rem.htm"></iframe>
												</td>
											</tr>
										</table>
										<table>
											<tr>
												<td>
													<button class="iCWebControlsII" id="Update" title="Update" onclick="javascript:SaveContent()"
														name="Update" type="button">
														<%=Update%>
													</button>&nbsp;<button class="iCWebControlsII" id="Cancel" title="Cancel" onclick="window.history.go(-1);"
														name="Cancel" type="button"><%=Cancel%></button>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
			</tbody>
		</table>
		<form name="Editor" onsubmit="submitForm();" action="PublisherEdit.aspx" method="post">
			<input id="EditorContent" type="hidden" name="EditorContent"> <input id="ModId" type="hidden" value="<%=ModId%>" name="ModId" >
			<input id="PageId" type="hidden" value="<%=PageId%>" name="PageId" > <input id="urlholder" type="hidden" value="<%=urlholder%>" name="urlholder" >
			<input id="DesignMode" type="hidden" value="<%=DesignMode%>" name="DesignMode" >
			<input id="HtmlMode" type="hidden" value="<%=HtmlMode%>" name="HtmlMode" > <input id="Alert" type="hidden" value="<%=Alert%>" name="HtmlMode" >
		</form>
		<form id="PreWriter" runat="server">
			<asp:TextBox id="DesktopText" runat="server" textmode="multiline" rows="0" width="0" columns="0"></asp:TextBox>
		</form>
		<script>
		</script>
	</body>
</HTML>
