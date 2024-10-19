<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Pages.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Pages.Pages" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<LINK href="~/Server/Css/iCMServer.css" type="text/css" rel="stylesheet">
<script src="Server/Modules/Pages/XLoadTree/xtree.js" type="text/javascript"></script>
<script src="Server/Modules/Pages/XLoadTree/xmlextras.js" type="text/javascript"></script>
<script src="Server/Modules/Pages/XLoadTree/xloadtree.js" type="text/javascript"></script>
<LINK href="~/Server/Modules/Pages/XLoadTree/xtree.css" type="text/css" rel="stylesheet">
<script language="javascript">
	// WebFX Config...
	webFXTreeConfig.rootIcon		= "Server/Modules/Pages/XLoadTree/images/xp/folder.png";
	webFXTreeConfig.openRootIcon	= "Server/Modules/Pages/XLoadTree/images/xp/openfolder.png";
	webFXTreeConfig.folderIcon		= "Server/Modules/Pages/XLoadTree/images/xp/folder.png";
	webFXTreeConfig.openFolderIcon	= "Server/Modules/Pages/XLoadTree/images/xp/openfolder.png";
	webFXTreeConfig.fileIcon		= "Server/Modules/Pages/XLoadTree/images/xp/file.png";
	webFXTreeConfig.lMinusIcon		= "Server/Modules/Pages/XLoadTree/images/xp/Lminus.png";
	webFXTreeConfig.lPlusIcon		= "Server/Modules/Pages/XLoadTree/images/xp/Lplus.png";
	webFXTreeConfig.tMinusIcon		= "Server/Modules/Pages/XLoadTree/images/xp/Tminus.png";
	webFXTreeConfig.tPlusIcon		= "Server/Modules/Pages/XLoadTree/images/xp/Tplus.png";
	webFXTreeConfig.iIcon			= "Server/Modules/Pages/XLoadTree/images/xp/I.png";
	webFXTreeConfig.lIcon			= "Server/Modules/Pages/XLoadTree/images/xp/L.png";
	webFXTreeConfig.tIcon			= "Server/Modules/Pages/XLoadTree/images/xp/T.png";
	var Pages = new WebFXLoadTree("Pages", "Server/Modules/Pages/PagesEngine.aspx?sID=0,0,0", "Javascript:SelectSubItem(0)", "explorer", "Server/Modules/Pages/XLoadTree/images/xp/net.png","Server/Modules/Pages/XLoadTree/images/xp/net.png");
	Pages.setBehavior("explorer");
	
	// Object Variables
	var Object_Toggle="";
	var Object_Select="";
	var Object_deSelect="";
	var Object_Focus="";
	var Object_Blur="";
	var Object_Child=false;
	var Object_Root=false;
	var Object_ID=0;
	var SelectedSubItem=0;
	var DeselectedSubItem=0;
	var Report="";
	var CurrentCatalog=0;
	
	// Object Properties
	
	// This Properties will be set in XLoadTree\xtree.js
	function SetToggle(object){Object_Toggle=object;BuildReport();}
	function SetSelect(object){Object_Select=object;BuildReport();}
	function SetdeSelect(object){Object_deSelect=object;BuildReport();}
	function SetFocus(object){Object_Focus=object;SetChild(object);SetID(object);BuildReport();}
	function SetBlur(object){Object_Blur=object;BuildReport();}
	
	// This Property will be set in this context
	function SetCurrentCatalog(id){CurrentCatalog=id;BuildReport();}
	function SetChild(object){if(object.childNodes.length > 0){Object_Child=true;}else{Object_Child=false;}}
	function SetID(object){tempstr=object.id;Object_ID=tempstr.substr(18,5);if(Object_ID==4){SetRoot(true)}else{SetRoot(false)}}
	function SetRoot(x){Object_Root=x;}
	function GetToggle(){return Object_Toggle;}
	function GetToggleText(){return Object_Toggle.text;}
	function GetFocus(){return Object_Focus;}
	function GetFocusText(){return Object_Focus.text;}
	
	// Build Variables Report
	function BuildReport(){
		Report="Object_Toggle = "+Object_Toggle.text+"\nObject_Select = "+Object_Select.text+"\nObject_deSelect = "+Object_deSelect.text+"\nObject_Focus = "+Object_Focus.text+"\nObject_Blur = "+Object_Blur.text+"\nCurrentCatalog = "+CurrentCatalog+"\nObject_Child = "+Object_Child+"\nObject_ID = "+Object_ID+"\nObject_Root = "+Object_Root+"\nDeselectedSubItem = "+DeselectedSubItem;
	}
	function SelectSubItem(id){
		DeselectedSubItem=SelectedSubItem;
		SelectedSubItem=id;
		SetCurrentCatalog(id);
		document.getElementById("Sel").value = Object_Focus.text;
	} 
	function EditSubItem(){
		if((Object_Root==false) && (!Object_Focus=="")){
			document.location.href="Server/Modules/Pages/EditPages.aspx?PageID="+SelectedSubItem
		}
	}
	function AddNewSub(){
		document.location.href="Server/Modules/Pages/EditPages.aspx?PageID="+SelectedSubItem+"&Mode=Add"
	}
	function MoveUpSubItem(){
		document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=Up"+"&FromId="+<%=FromId%>;	
	}
	function MoveDownSubItem(){
		document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=Down"+"&FromId="+<%=FromId%>;	
	}
	function MoveTo(){
		document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=To"+"&ToId="+DeselectedSubItem+"&FromId="+<%=FromId%>;
	}
	function DeleteSubItem(){
		if((Object_Root==false) && (!Object_Focus=="")){
			if(confirm("<%=oLang.Find(al, "pag_confirm")%>: "+Object_Focus.text+" ?")){
				document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=Delete"+"&FromId="+<%=FromId%>;
			}
		}
	}
</script>
<Site:title runat="server" id="Title2" />
<TABLE cellSpacing="1" cellPadding="1" border="0" id="Table1" align="left">
	<tr valign="top">
		<td width="2">
			&nbsp;
		</td>
		<td width="370" class="Normal">
			<table cellSpacing="0" cellPadding="0" border="0" id="Table2">
				<tr>
					<td class="SubHead" align="left"><%=oLang.Find(al, "pag_info")%> <input value="<%=oLang.Find(al, "pag_selpage")%>" class="SubSubHead" type="text" name="Sel" readonly size="23">
					</td>
				</tr>
			</table>
		</td>
		<td width="98%" class="Normal">
			<table id="Table3">
				<tr height="10">
					<td><INPUT id="btnAddPage" class="iCWebControlsII" type="button" value="<%=oLang.Find(al, "pag_addpage")%>" OnClick="AddNewSub()"
							style="CURSOR:hand"></td>
				</tr>
			</table>
		</td>
	</tr>
	<!--
	<tr valign="top">
		<td width="2">
			&nbsp;
		</td>
		<td width="400" class="Normal" colspan="2">
			&nbsp;<a href="Javascript:alert(Report);">Report</a>
		</td>
	</tr>
	-->
	<tr valign="top">
		<td width="2">
			&nbsp;
		</td>
		<td width="370" class="Normal">
			<script> 
				document.write(Pages) 
			</script>
		</td>
		<td width=98%" class="Normal">
			<table id="Table4" border="0">
				<tr height="10">
					<td></td>
					<td><IMG id="imgUp" alt="<%=oLang.Find(al, "pag_moveup")%>" src="Server/Modules/Pages/images/MovePageUp.gif"
							onclick="MoveUpSubItem()" align="middle" style="CURSOR:hand"></td>
					<td><IMG id="imgDown" alt="<%=oLang.Find(al, "pag_movedown")%>" src="Server/Modules/Pages/images/MovePageDown.gif"
							onclick="MoveDownSubItem()" align="middle" style="CURSOR:hand"></td>
					<td><IMG id="imgRight" alt="<%=oLang.Find(al, "pag_moveto")%>" src="Server/Modules/Pages/images/MovePageRight.gif"
							onclick="MoveTo()" align="middle" style="CURSOR:hand"></td>
					<td></td>
				</tr>
				<tr>
					<td colSpan="5" style="HEIGHT: 12px"></td>
				</tr>
				<tr>
					<td style="HEIGHT: 14px" colSpan="5" align="center">
						<table id="Table5">
							<tr>
								<td style="HEIGHT: 14px">
									<IMG id="imgEdit" alt="<%=oLang.Find(al, "pag_edit")%>" src="Server/Modules/Pages/images/EditPage.gif" onclick="EditSubItem()"
										align="middle" style="CURSOR:hand">
								</td>
								<td style="HEIGHT: 14px"></td>
								<td style="HEIGHT: 14px">
									<IMG id="imgDelete" alt="<%=oLang.Find(al, "pag_delete")%>" src="Server/Modules/Pages/images/DeletePage.gif"
										onclick="DeleteSubItem()" align="middle" style="CURSOR:hand">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="5"></td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
<!--
<asp:textbox Width="0" Height="0" id="SelectedSiteID" runat="server" Visible="True" BorderWidth="0"
	BorderStyle="None">0</asp:textbox>
<asp:textbox Width="0" Height="0" id="SelectedPageID" runat="server" Visible="True" BorderWidth="0"
	BorderStyle="None">0</asp:textbox>
<asp:TextBox Width="0" Height="0" id="OldSelectedPageID" runat="server" Visible="True" BorderWidth="0"
	BorderStyle="None">0</asp:TextBox>
	-->
