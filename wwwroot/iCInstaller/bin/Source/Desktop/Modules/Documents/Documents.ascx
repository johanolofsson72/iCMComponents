<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Documents.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Documents.Documents" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script src="Server/Modules/Pages/XLoadTree/xtree.js" type="text/javascript"></script>
<script src="Server/Modules/Pages/XLoadTree/xmlextras.js" type="text/javascript"></script>
<script src="Server/Modules/Pages/XLoadTree/xloadtree.js" type="text/javascript"></script>
<%If Not SimpleViewState Then%>
<script language="javascript">
	// WebFX Config...
	webFXTreeConfig.rootIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/folder.png";
	webFXTreeConfig.openRootIcon	= "Desktop/Modules/Documents/XLoadTree/images/xp/openfolder.png";
	webFXTreeConfig.folderIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/folder.png";
	webFXTreeConfig.openFolderIcon	= "Desktop/Modules/Documents/XLoadTree/images/xp/openfolder.png";
	webFXTreeConfig.fileIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/file.png";
	webFXTreeConfig.lMinusIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/Lminus.png";
	webFXTreeConfig.lPlusIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/Lplus.png";
	webFXTreeConfig.tMinusIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/Tminus.png";
	webFXTreeConfig.tPlusIcon		= "Desktop/Modules/Documents/XLoadTree/images/xp/Tplus.png";
	webFXTreeConfig.iIcon			= "Desktop/Modules/Documents/XLoadTree/images/xp/I.png";
	webFXTreeConfig.lIcon			= "Desktop/Modules/Documents/XLoadTree/images/xp/L.png";
	webFXTreeConfig.tIcon			= "Desktop/Modules/Documents/XLoadTree/images/xp/T.png";
	var <%=TreeName%> = new WebFXLoadTree("<%=ModTitle%>", "Desktop/Modules/Documents/DocumentsEngine.aspx?sID=0,<%=ModId%>,0", "Javascript:GetDocuments<%=ModId%>(0)", "explorer", "Desktop/Modules/Documents/XLoadTree/images/xp/folder.png","Desktop/Modules/Documents/XLoadTree/images/xp/openfolder.png");
	<%=TreeName%>.setBehavior("explorer");
</script>
<%End If%>
<script language=javascript>
	
	// Object Variables
	var Object_Toggle<%=ModId%>="";
	var Object_Select<%=ModId%>="";
	var Object_deSelect<%=ModId%>="";
	var Object_Focus<%=ModId%>="";
	var Object_Blur<%=ModId%>="";
	var Object_Child<%=ModId%>=false;
	var Object_Root<%=ModId%>=false;
	var Object_ID<%=ModId%>=0;
	var SelectedSubItem<%=ModId%>=0;
	var DeselectedSubItem<%=ModId%>=0;
	var Report<%=ModId%>="";
	var CurrentFolder<%=ModId%>=0;
	
	// Object Properties
	
	// This Properties will be set in XLoadTree\xtree.js
	function SetToggle<%=ModId%>(object){Object_Toggle<%=ModId%>=object;BuildReport<%=ModId%>();}
	function SetSelect<%=ModId%>(object){Object_Select<%=ModId%>=object;BuildReport<%=ModId%>();}
	function SetdeSelect<%=ModId%>(object){Object_deSelect<%=ModId%>=object;BuildReport<%=ModId%>();}
	function SetFocus<%=ModId%>(object){Object_Focus<%=ModId%>=object;SetChild<%=ModId%>(object);SetID<%=ModId%>(object);BuildReport<%=ModId%>();}
	function SetBlur<%=ModId%>(object){Object_Blur<%=ModId%>=object;BuildReport<%=ModId%>();}
	
	// This Property will be set in this context
	function SetCurrentFolder<%=ModId%>(id){CurrentFolder<%=ModId%>=id;BuildReport<%=ModId%>();}
	function SetChild<%=ModId%>(object){if(object.childNodes.length > 0){Object_Child<%=ModId%>=true;}else{Object_Child<%=ModId%>=false;}}
	function SetID<%=ModId%>(object){tempstr=object.id;Object_ID<%=ModId%>=tempstr.substr(18,5);if(Object_ID<%=ModId%>==4){SetRoot<%=ModId%>(true)}else{SetRoot<%=ModId%>(false)}}
	function SetRoot<%=ModId%>(x){Object_Root<%=ModId%>=x;}
	function GetToggle<%=ModId%>(){return Object_Toggle<%=ModId%>;}
	function GetToggleText<%=ModId%>(){return Object_Toggle<%=ModId%>.text;}
	function GetFocus<%=ModId%>(){return Object_Focus<%=ModId%>;}
	function GetFocusText<%=ModId%>(){return Object_Focus<%=ModId%>.text;}
	
	// Build Variables Report
	function BuildReport<%=ModId%>(){
		//Report="Object_Toggle<%=ModId%> = "+Object_Toggle<%=ModId%>.text+"\nObject_Select = "+Object_Select<%=ModId%>.text+"\nObject_deSelect = "+Object_deSelect<%=ModId%>.text+"\nObject_Focus = "+Object_Focus<%=ModId%>.text+"\nObject_Blur = "+Object_Blur<%=ModId%>.text+"\nCurrentFolder = "+CurrentFolder<%=ModId%>+"\nObject_Child = "+Object_Child+"\nObject_ID = "+Object_ID<%=ModId%>+"\nObject_Root = "+Object_Root<%=ModId%>+"\nDeselectedSubItem = "+DeselectedSubItem<%=ModId%>;
	}
	// Reload the tree or just the selected node, Executed from CatalogsModule\CatalogEdit.aspx
	function ReloadSelectedNode<%=ModId%>(mode){
		switch (mode){
			case 'ADD':
				if((Object_Child<%=ModId%>==true)&&(Object_Root<%=ModId%>==false)){	
					Object_Focus<%=ModId%>.reload();
				}
				else{
					window.location.reload();
				}
				break
			case 'DELETE':
				window.location.reload();
				break
			default:
				window.location.reload();
		}
	}
	function ToggleSelectedNode<%=ModId%>(){
		if(Object_Focus<%=ModId%>!=""){
			webFXTreeHandler.select(Object_Focus<%=ModId%>);
			window.setTimeout("GetDocuments<%=ModId%>(CurrentFolder<%=ModId%>);",500) 
		} 
	}
	function AddFolder<%=ModId%>(){
		if(!Object_Focus<%=ModId%>==""){
			var a = "<%=AddFolderConfirm1%>";
			a += Object_Focus<%=ModId%>.text;
			a += "<%=AddFolderConfirm2%>";
			var b = "<%=AddFolderDefaultText%>";
			var title=prompt(a,b);
			if(title==null){
				return;
			}
			else{
				document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsFolderEdit.aspx?Mode=ADDFOLDER&CatId="+CurrentFolder<%=ModId%>+"&ModId="+"<%=ModId%>&Title="+title+"&PagId="+<%=PagId%>;
			}
		}
	}
	function EditFolder<%=ModId%>(){
		if((Object_Root<%=ModId%>==false) && (!Object_Focus<%=ModId%>=="")){
			var title=prompt("<%=EditFolderConfirm%>",Object_Focus<%=ModId%>.text);
			if(title==null){
				return;
			}
			else{
				document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsFolderEdit.aspx?Mode=EDITFOLDER&CatId="+CurrentFolder<%=ModId%>+"&ModId="+"<%=ModId%>&Title="+title+"&PagId="+<%=PagId%>;
			}
		}
	}
	function DeleteFolder<%=ModId%>(){
		if((Object_Root<%=ModId%>==false) && (!Object_Focus<%=ModId%>=="")){
			if(confirm("<%=DeleteFolderConfirm%>"+Object_Focus<%=ModId%>.text+" ?")){
				document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsFolderEdit.aspx?Mode=DELETEFOLDER&CatId="+CurrentFolder<%=ModId%>+"&ModId="+"<%=ModId%>"+"&PagId="+<%=PagId%>;
			}
		}
	}
	function EditFile<%=ModId%>(){
		document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsEdit.aspx?CatId="+CurrentFolder<%=ModId%>+"&ModId="+"<%=ModId%>"+"&PageId="+<%=PagId%>;
	}
	function UploadFile<%=ModId%>(){
		document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsEdit.aspx?CatId="+CurrentFolder<%=ModId%>+"&ModId="+"<%=ModId%>"+"&PageId="+<%=PagId%>;
	}
	function UploadFileSimple<%=ModId%>(){
		window.open('Desktop/Modules/Documents/DocumentsEditSimple.aspx?ModId='+'<%=ModId%>'+'&PageId='+<%=PagId%>,'DocumentsEdit','Height=350,Width=500');
	}
	function GetDocuments<%=ModId%>(CatId){
		SetCurrentFolder<%=ModId%>(CatId);
		var d = new Date()
		var sTime = d.getHours() + d.getMinutes() + d.getSeconds()
		document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsGetFiles.aspx?CatId="+CatId+"&ModId="+"<%=ModId%>&H="+"<%=HasEditAuth%>"+"&Time="+sTime;
	}
	function Refresh<%=ModId%>(){
		document.location.reload();  
	}
	function Search<%=ModId%>(){
		var Search = document.getElementById("txtSearchBox").value;
		var d = new Date()
		var sTime = d.getHours() + d.getMinutes() + d.getSeconds()
		document.getElementById("FileContainer<%=ModId%>").src="Desktop/Modules/Documents/DocumentsGetFiles.aspx?CatId=0&ModId="+"<%=ModId%>&H="+"<%=HasEditAuth%>"+"&Time="+sTime+"&Search="+Search;
	}	
	
	
	
	
	WebFXTreeAbstractNode.prototype.toggle = function() {
	if (this.folder) {
		SetToggle<%=ModId%>(this);
		if (this.open) { this.collapse(); }
		else { this.expand(); }
}	}
WebFXTreeAbstractNode.prototype.select = function() {
	// Catalogs/Catalogs.ascx
	SetSelect<%=ModId%>(this);
	document.getElementById(this.id + '-anchor').focus();
}

WebFXTreeAbstractNode.prototype.deSelect = function() {
	// Catalogs/Catalogs.ascx
	SetdeSelect<%=ModId%>(this);
	document.getElementById(this.id + '-anchor').className = '';
	webFXTreeHandler.selected = null;
}

WebFXTreeAbstractNode.prototype.focus = function() {
	// Catalogs/Catalogs.ascx
	SetFocus<%=ModId%>(this);
	if ((webFXTreeHandler.selected) && (webFXTreeHandler.selected != this)) { webFXTreeHandler.selected.deSelect(); }
	webFXTreeHandler.selected = this;
	if ((this.openIcon) && (webFXTreeHandler.behavior != 'classic')) { document.getElementById(this.id + '-icon').src = this.openIcon; }
	document.getElementById(this.id + '-anchor').className = 'selected';
	document.getElementById(this.id + '-anchor').focus();
	if (webFXTreeHandler.onSelect) { webFXTreeHandler.onSelect(this); }
}

WebFXTreeAbstractNode.prototype.blur = function() {
	// Catalogs/Catalogs.ascx
	SetBlur<%=ModId%>(this);
	if ((this.openIcon) && (webFXTreeHandler.behavior != 'classic')) { document.getElementById(this.id + '-icon').src = this.icon; }
	document.getElementById(this.id + '-anchor').className = 'selected-inactive';
}
</script>
<SITE:TITLE id="Title2" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE id="Table1" height="98%" cellSpacing="0" cellPadding="1" width="99%" align="left"
		border="0">
		<!-- Button Bar -->
		<tr>
			<td width="5">&nbsp;</td>
			<td <%If Not SimpleViewState Then%>bgColor="#ffffff" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"<%End If%>>
				<TABLE id="Table2" height="21" cellSpacing="0" cellPadding="1" width="100%" align="left"
					border="0">
					<TR>
						<td width="3">&nbsp;</td>
						<TD <%If Not SimpleViewState Then%>bgColor="#ffffff"<%End If%> align="left">
							<table width="100%" border="0" cellSpacing="0" cellPadding="0">
								<tr>
									<%If HasEditAuth Then%>
									<td align="left"><IMG id=btnRefresh style="CURSOR: hand" onclick=Refresh<%=ModId%>() alt="<%=RefreshAltText%>" src="Desktop/Modules/Documents/Images/Refresh.gif" ></td>
									<td align="left"><div nowrap id="lblRefresh" style="CURSOR: hand" class="SubSubHead" onclick="Refresh<%=ModId%>()">&nbsp;<%=RefreshAltText%>&nbsp;&nbsp;</div></td>
									<%End If%>
									<%If Not SimpleViewState Then%>
										<%If HasEditAuth Then%>
									<td align="left"><IMG id=btnAddFolder style="CURSOR: hand" onclick=AddFolder<%=ModId%>() alt="<%=AddFolderAltText%>" src="Desktop/Modules/Documents/Images/AddFolder.gif" ></td>
									<td align="left"><div nowrap id="lblAddFolder" style="CURSOR: hand" class="SubSubHead" onclick="AddFolder<%=ModId%>()">&nbsp;<%=AddFolderAltText%>&nbsp;&nbsp;</div></td>
									<td align="left"><IMG id=btnEditFolder style="CURSOR: hand" onclick=EditFolder<%=ModId%>() alt="<%=EditFolderAltText%>" src="Desktop/Modules/Documents/Images/EditFolder.gif" ></td>
									<td align="left"><div nowrap id="lblEditFolder" style="CURSOR: hand" class="SubSubHead" onclick="EditFolder<%=ModId%>()">&nbsp;<%=EditFolderAltText%>&nbsp;&nbsp;</div></td>
									<td align="left"><IMG id=btnDeleteFolder style="CURSOR: hand" onclick=DeleteFolder<%=ModId%>() alt="<%=DeleteFolderAltText%>" src="Desktop/Modules/Documents/Images/DeleteFolder.gif" ></td>
									<td align="left"><div nowrap id="lblDeleteFolder" style="CURSOR: hand" class="SubSubHead" onclick="DeleteFolder<%=ModId%>()">&nbsp;<%=DeleteFolderAltText%>&nbsp;&nbsp;</div></td>
									<td align="left"><IMG id=btnUploadFile style="CURSOR: hand" onclick=UploadFile<%=ModId%>() alt="<%=UploadFileAltText%>" src="Desktop/Modules/Documents/Images/UploadFile.gif" ></td>
									<td align="left"><div nowrap id="lblUploadFile" style="CURSOR: hand" class="SubSubHead" onclick="UploadFile<%=ModId%>()">&nbsp;<%=UploadFileAltText%>&nbsp;&nbsp;</div></td>
										<%End If%>
									<%Else%>
										<%If HasEditAuth Then%>
									<td align="left"><IMG id=btnUploadFile2 style="CURSOR: hand" onclick=UploadFileSimple<%=ModId%>() alt="<%=UploadFileAltText%>" src="Desktop/Modules/Documents/Images/UploadFile.gif" ></td>
									<td align="left"><div nowrap id="lblUploadFile2" style="CURSOR: hand" class="SubSubHead" onclick="UploadFileSimple<%=ModId%>()">&nbsp;<%=UploadFileAltText%></div></td>
										<%End If%>
									<%End If%>
									<td width="100%">&nbsp;</td>
								</tr>
							</table>
						</TD>
						<TD <%If Not SimpleViewState Then%>bgColor="#ffffff"<%End If%> align="right">
							<asp:CheckBox id="chkSimpleViewState" CssClass="SubSubHead" runat="server" EnableViewState="true" AutoPostBack="true"></asp:CheckBox>&nbsp;</TD>
					</TR>
				</TABLE>
			</td>
		</tr>
		<tr>
			<td width="5">&nbsp;</td>
			<td <%If Not SimpleViewState Then%>bgColor="#ffffff" style="BORDER-RIGHT: black 1px solid;BORDER-LEFT: black 1px solid;BORDER-BOTTOM: black 1px solid;"<%End If%>>
				<TABLE height="21" cellSpacing="0" cellPadding="1" width="100%" align="left" border="0">
					<tr>
						<TD>&nbsp;<span style="WIDTH: 2px"></TD>
						<TD></span><input type="text" value="" id="txtSearchBox" onkeydown="KeyDown()" style="width:160px;height:19px" class="label"></TD>
						<TD>&nbsp;</TD>
						<TD><input type="button" id="btnSearchButton" onclick="Search<%=ModId%>()" class="iCWebControlsII" style="height:19px;cursor:hand" name="btnSearchButton" title="Sök" value="Sök"></TD>
						<TD width="90%">&nbsp;</TD>
					</tr>
				</TABLE>
			</td>
		</tr>
		<%If SimpleViewState Then%>
		<!-- Standard -->
		<tr>
			<td width="5">&nbsp;</td>
			<td>
				<TABLE height="21" cellSpacing="0" cellPadding="1" width="100%" align="left" border="0">
					<tr>
						<TD width="5%">&nbsp;</TD>
						<TD width="50%"><asp:label id="lblTitleSimple" runat="server" CssClass="SubHead">Title</asp:label></TD>
						<TD width="15%" align="right"><asp:label id="lblSizeSimple" runat="server" CssClass="SubHead">Size&nbsp;&nbsp;&nbsp;</asp:label></TD>
						<TD width="30%" align="right"><asp:label id="lblModifiedSimple" runat="server" CssClass="SubHead">Last Modified&nbsp;&nbsp;&nbsp;</asp:label></TD>
					</tr>
				</TABLE>
			</td>
		</tr>
		<tr id="StandardViewBar">
			<td width="5">&nbsp;</td>
			<td>
				<asp:PlaceHolder ID="SimpleFiles" Runat="server"></asp:PlaceHolder> 
			</td>
		</tr>
		<%Else%>
		<!-- Advanced -->
		<!-- AdvancedViewInfoBar -->
		<tr id="AdvancedViewInfoBar">
			<td>&nbsp;</td>
			<td bgColor="#ffffff" style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid">
				<TABLE id="Table3" height="21" cellSpacing="0" cellPadding="1" width="100%" align="left"
					border="0">
					<TR>
						<td width="3">&nbsp;</td>
						<TD width="30%" bgColor="#ffffff">&nbsp;
							<asp:label id="lblFolders" runat="server" CssClass="SubHead">Folders</asp:label></TD>
						<TD vAlign="top" align="left" width="18" bgColor="#ffffff" height="100%">
							<!--<div style="BORDER-RIGHT: gainsboro thin solid; FONT-WEIGHT: bold; FONT-SIZE: small; VERTICAL-ALIGN: baseline; WIDTH: 18px; FONT-FAMILY: Verdana; POSITION: static; HEIGHT: 100%; BACKGROUND-COLOR: #f9f9f9; TEXT-ALIGN: center"></div>-->
						</TD>
						<TD align="left" width="70%" bgColor="#f9f9f9">
							<table id="Table4" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f9f9f9" border="0">
								<tr>
									<TD width="5%">&nbsp;</TD>
									<TD width="50%"><asp:label id="lblTitle" runat="server" CssClass="SubHead">Title</asp:label></TD>
									<TD align="center" width="15%"><asp:label id="lblSize" runat="server" CssClass="SubHead">Size</asp:label></TD>
									<TD align="center" width="30%"><asp:label id="lblModified" runat="server" CssClass="SubHead">Date Modified</asp:label></TD>
								</tr>
							</table>
						</TD>
					</TR>
				</TABLE>
			</td>
		</tr>
		<!-- Folders & Files -->
		<tr id="AdvancedViewBar">
			<td>&nbsp;</td>
			<td bgColor="#ffffff" style="BORDER-RIGHT: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid">
				<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="1" width="100%" align="left"
					border="0">
					<TR>
						<td width="3">&nbsp;</td>
						<TD vAlign="top" align="left" width="30%" height="100%">
							<table>
								<tr>
									<td bgColor="#ffffff">
										<script>document.write(<%=TreeName%>)</script>
									</td>
								</tr>
							</table>
						</TD>
						<TD vAlign="top" align="left" width="18" height="100%"><div style="BORDER-RIGHT: gainsboro thin solid; FONT-WEIGHT: bold; FONT-SIZE: small; VERTICAL-ALIGN: baseline; WIDTH: 18px; FONT-FAMILY: Verdana; POSITION: static; HEIGHT: 100%; BACKGROUND-COLOR: #f9f9f9; TEXT-ALIGN: center"></div>
						</TD>
						<TD vAlign="top" align="left" width="70%" height="100%"><iframe id="FileContainer<%=ModId%>" style="WIDTH: 100%; HEIGHT: 400px" marginWidth="0" marginHeight="0"
								src="" frameBorder="0" width="100%" scrolling="auto" height="400"></iframe>
						</TD>
					</TR>
				</TABLE>
			</td>
		</tr>
		<%End If%>
	</TABLE>
	<script>
		try{
			GetDocuments<%=ModId%>(0);
		}
		catch(e){
		
		}
		function KeyDown(){
			if (document.all)
				if (event.keyCode == 13)
					mySubmit();
		}
		function mySubmit()
		{
			try{
				var e1 = document.getElementById("btnSearchButton");
				e1.focus();
			}
			catch(e){
			
			}
		}
		try{
			var e1 = document.getElementById("txtSearchBox");
			e1.focus();
		}
		catch(e){
		
		}
	</script>
</div>
