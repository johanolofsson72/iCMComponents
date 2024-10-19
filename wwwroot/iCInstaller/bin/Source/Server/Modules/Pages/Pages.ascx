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
			document.location.href="Server/Modules/Pages/EditPages.aspx?PageID="+SelectedSubItem+"&ModId=<%=ModuleId%>"
		}
	}
	function AddNewSub(){
		document.location.href="Server/Modules/Pages/EditPages.aspx?PageID="+SelectedSubItem+"&Mode=Add"+"&ModId=<%=ModuleId%>"
	}
	function MoveUpSubItem(){
		document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=Up"+"&FromId="+<%=FromId%>+"&ModId=<%=ModuleId%>";	
	}
	function MoveDownSubItem(){
		document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=Down"+"&FromId="+<%=FromId%>+"&ModId=<%=ModuleId%>";	
	}
	function MoveTo(){
		document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=To"+"&ToId="+DeselectedSubItem+"&FromId="+<%=FromId%>+"&ModId=<%=ModuleId%>";
	}
	function DeleteSubItem(){
		if((Object_Root==false) && (!Object_Focus=="")){
			if(confirm("<%=server.htmldecode(oLang.Find(al, "pag_confirm"))%>: "+Object_Focus.text+" ?")){
				document.location.href="Server/Modules/Pages/HandlePages.aspx?PageID="+SelectedSubItem+"&Mode=Delete"+"&FromId="+<%=FromId%>+"&ModId=<%=ModuleId%>";
			}
		}
	}
</script>
<Site:title runat="server" id="Title2" />
<div id="Minimizer" runat="server">
<TABLE cellSpacing="1" cellPadding="1" border="0" id="Table1" align="left">
	<tr valign="top">
		<td width="1%">
			&nbsp;
		</td>
		<td width="58%" class="Normal" align="left">
			<table cellSpacing="0" cellPadding="0" border="0" id="Table2">
				<tr>
					<td>
						<div class="SubHead" style="WIDTH: 108px;"><%=oLang.Find(al, "pag_info")%></div>
					</td>
					<td>&nbsp;</td>
					<td> 
						<input value="<%=oLang.Find(al, "pag_selpage")%>" class="SubSubHead" type="text" id="Sel" name="Sel" readonly size="23"  style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: #f9f9f9; BORDER-BOTTOM-STYLE: none">
					</td>
				</tr>
			</table>
		</td>
		<td width="36%" class="Normal" align="center" >
			<table cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td align="left">
						<IMG id="imgUp" alt="<%=oLang.Find(al, "pag_moveup")%>" src="Server/Modules/Pages/images/MovePageUp.gif" onclick="MoveUpSubItem()" align="middle" style="CURSOR:hand">
					</td>
					<td>&nbsp;</td>
					<td align="left">
						<div class="SubSubHead" onclick="MoveUpSubItem()" style="WIDTH: 40px;cursor:hand"><%=oLang.Find(al, "pag_labelmoveup")%></div>
					</td>
					<td>&nbsp;</td>
					<td align="left">
						<IMG id="imgDown" alt="<%=oLang.Find(al, "pag_movedown")%>" src="Server/Modules/Pages/images/MovePageDown.gif" onclick="MoveDownSubItem()" align="middle" style="CURSOR:hand">
					</td>
					<td>&nbsp;</td>
					<td align="left">
						<div class="SubSubHead" onclick="MoveDownSubItem()" style="WIDTH: 40px;cursor:hand"><%=oLang.Find(al, "pag_labelmovedown")%></div>
					</td>
					<td>&nbsp;</td>
					<td align="left">
						<IMG id="imgRight" alt="<%=oLang.Find(al, "pag_moveto")%>" src="Server/Modules/Pages/images/MovePageRight.gif" onclick="MoveTo()" align="middle" style="VISIBILITY: hidden; CURSOR: hand">
					</td>
					<td>&nbsp;</td>
					<td align="left">
						<div visible="false" class="SubSubHead" onclick="MoveTo()" style="VISIBILITY: hidden; WIDTH: 40px;cursor:hand"><%=oLang.Find(al, "pag_labelmoveto")%></div>
					</td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</td>
		<td width="5%" class="Normal" align="right" colspan="2" rowspan="2">
			<table id="Table3" cellSpacing="0" cellPadding="0" border="0">
				<tr height="10">
					<td colspan="3"><INPUT id="btnAddPage" class="iCWebControlsII" type="button" value="<%=oLang.Find(al, "pag_addpage")%>" OnClick="AddNewSub()"
							style="CURSOR:hand">&nbsp;&nbsp;</td>
				</tr>
				<tr><td colspan="3">&nbsp;</td></tr>
				<tr><td colspan="3">&nbsp;</td></tr>
				<tr>
					<td align="left">
						<IMG id="imgEdit" alt="<%=oLang.Find(al, "pag_edit")%>" src="Server/Modules/Pages/images/EditPage.gif" onclick="EditSubItem()" align="middle" style="CURSOR:hand">
					</td>
					<td>&nbsp;</td>
					<td width="90%">
						<div class="SubSubHead" onclick="EditSubItem()" style="WIDTH: 44px;cursor:hand"><%=oLang.Find(al, "pag_labeledit")%></div>
					</td>
				</tr>
				<tr><td colspan="3">&nbsp;</td></tr>
				<tr>
					<td align="left">
						<IMG id="imgDelete" alt="<%=oLang.Find(al, "pag_delete")%>" src="Server/Modules/Pages/images/DeletePage.gif" onclick="DeleteSubItem()" align="middle" style="CURSOR:hand">
					</td>
					<td>&nbsp;</td>
					<td width="90%">
						<div class="SubSubHead" onclick="DeleteSubItem()" style="WIDTH: 44px;cursor:hand"><%=oLang.Find(al, "pag_labeldelete")%></div>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr valign="top">
		<td width="1%">
			&nbsp;
		</td>
		<td width="99%" class="Normal" align="left" colspan="2">
			<script> 
				document.write(Pages) 
			</script>
		</td>
	</tr>
</TABLE>
</div> 