<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ICERoute.ascx.vb" Inherits="iConsulting.iCMServer.Modules.ICERoute.ICERoute" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" EditText="" Location="" Phrase="" EditUrl="" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<script language="Javascript"> 
		var OpenRouteDialogResult = null;
		function OpenRouteDialog()
		{
			var obj = window.open("Desktop/Modules/iCERoute/AddRoute.aspx", "AddRoute", "Height=297, Width=360");
		} 
	</script>

	<table width="800" bgColor="#d4d0c8"> <!--CCCCCC-->
		<tr>
			<td colSpan="2"></td>
		</tr>
		<tr vAlign="bottom">
			<td vAlign="bottom" colSpan="2">
				<table width="800">
					<tr>
						<td><asp:imagebutton id="btnOpen" runat="server" ImageUrl="Images/Open.jpg"></asp:imagebutton></td>
						<td>&nbsp;&nbsp;</td>
						<td><asp:imagebutton id="btnSave" runat="server" ImageUrl="Images/Save.jpg"></asp:imagebutton></td>
						<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td><asp:dropdownlist id="DropDownList1" runat="server">
								<asp:ListItem Value="M&#229;ndag">M&#229;ndag</asp:ListItem>
								<asp:ListItem Value="Tisdag">Tisdag</asp:ListItem>
								<asp:ListItem Value="Onsdag">Onsdag</asp:ListItem>
								<asp:ListItem Value="Torsdag">Torsdag</asp:ListItem>
								<asp:ListItem Value="Fredag">Fredag</asp:ListItem>
								<asp:ListItem Value="L&#246;rdag">L&#246;rdag</asp:ListItem>
								<asp:ListItem Value="S&#246;ndag">S&#246;ndag</asp:ListItem>
							</asp:dropdownlist></td>
						<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td><asp:imagebutton id="btnMeasure" runat="server" ImageUrl="Images/Measure.jpg"></asp:imagebutton></td>
						<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td><asp:imagebutton id="btnZoomIn" runat="server" ImageUrl="Images/ZoomIn.jpg"></asp:imagebutton></td>
						<td>&nbsp;</td>
						<td><asp:imagebutton id="btnZoomOut" runat="server" ImageUrl="Images/ZoomOut.jpg"></asp:imagebutton></td>
						<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td><asp:imagebutton id="btnPrint" runat="server" ImageUrl="Images/Print2.jpg"></asp:imagebutton></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr vAlign="top">
			<td>
				<table width="250">
					<tr>
						<td bgColor="gainsboro" colSpan="8"><asp:label id="Label8" runat="server">Elev 1 av 3</asp:label></td>
					</tr>
					<tr>
						<td><asp:imagebutton id="btnPrevCust" runat="server" ImageUrl="Images/Back.jpg" ToolTip="Visa föregående elev"></asp:imagebutton></td>
						<td><asp:imagebutton id="btnNextCust" runat="server" ImageUrl="Images/Forward.jpg" ToolTip="Visa nästa elev"></asp:imagebutton></td>
						<td><asp:imagebutton id="btnListAllCust" runat="server" ImageUrl="Images/List.jpg" ToolTip="Lista alla elever"></asp:imagebutton></td>
						<td>&nbsp;</td>
						<td><asp:imagebutton id="btnAddCust" runat="server" ImageUrl="Images/Add.jpg"></asp:imagebutton></td>
						<td><asp:label id="Label9" runat="server" Width="50px">Lägg till</asp:label></td>
						<td><asp:imagebutton id="btnDelCust" runat="server" ImageUrl="Images/Delete.jpg"></asp:imagebutton></td>
						<td><asp:label id="Label10" runat="server" Width="50px">Ta bort</asp:label></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label1" runat="server">Namn:</asp:label></td>
						<td><asp:textbox id="TextBox1" runat="server" Width="50px"></asp:textbox></td>
						<td colSpan="4"><asp:textbox id="TextBox5" runat="server" Width="95px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label2" runat="server">Adress:</asp:label></td>
						<td colSpan="5"><asp:textbox id="TextBox2" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label3" runat="server">Postadress:</asp:label></td>
						<td colSpan="5"><asp:textbox id="TextBox3" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label5" runat="server">Telefon:</asp:label></td>
						<td colSpan="5"><asp:textbox id="TextBox6" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label6" runat="server">Skola:</asp:label></td>
						<td colSpan="5"><asp:textbox id="Textbox7" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label7" runat="server">Klass:</asp:label></td>
						<td colSpan="5"><asp:textbox id="Textbox8" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label4" runat="server">Hållplatsnr:</asp:label></td>
						<td colSpan="5"><asp:textbox id="TextBox4" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="4">&nbsp;</td>
						<td colSpan="4"><asp:button id="btnGetPosAddr" runat="server" Width="160px" BorderStyle="None" Text="Hämta position från adress"
								CssClass="BUTTON"></asp:button></td>
					</tr>
					<tr>
						<td colSpan="8">
							<HR width="100%" SIZE="1">
						</td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label17" runat="server">Position:</asp:label></td>
						<td colSpan="5"><asp:textbox id="Textbox9" runat="server" Width="150px"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="4">&nbsp;</td>
						<td colSpan="4"><asp:button id="btnGetPosMap" runat="server" Width="160px" BorderStyle="None" Text="Hämta position från karta"
								CssClass="BUTTON"></asp:button></td>
					</tr>
					<tr>
						<td colSpan="8">
							<HR width="100%" SIZE="1">
						</td>
					</tr>
					<tr>
						<td colSpan="3"><asp:label id="Label14" runat="server">Hållplatser:</asp:label></td>
						<td>&nbsp;</td>
						<td><asp:imagebutton id="btnAddTrip" runat="server" ImageUrl="Images/Add.jpg"></asp:imagebutton></td>
						<td><asp:label id="Label15" runat="server">Lägg till</asp:label></td>
						<td><asp:imagebutton id="btnDelTrip" runat="server" ImageUrl="Images/Delete.jpg"></asp:imagebutton></td>
						<td><asp:label id="Label16" runat="server">Ta bort</asp:label></td>
					</tr>
					<tr>
						<td colSpan="3">&nbsp;</td>
						<td colSpan="5"><asp:listbox id="lbTrips" runat="server" Width="150px"></asp:listbox></td>
					</tr>
					<tr>
						<td colSpan="8">&nbsp;</td>
					</tr>
					<tr>
						<td bgColor="gainsboro" colSpan="8"><asp:label id="Label11" runat="server">Rutter</asp:label></td>
					</tr>
					<tr>
						<td colSpan="3">&nbsp;</td>
						<td>&nbsp;</td>
						<td colspan="2">
							<a onclick="OpenRouteDialog()" style="cursor:hand">
								<img src="Desktop/Modules/iCERoute/Images/Add.jpg">
								<asp:label id="Label13" runat="server">Lägg till</asp:label>
							</a>
							<!--<asp:imagebutton id="btnAddRoute" runat="server" ImageUrl="Images/Add.jpg"></asp:imagebutton>-->
						</td>
						<td><asp:imagebutton id="btnDelRoute" runat="server" ImageUrl="Images/Delete.jpg"></asp:imagebutton></td>
						<td><asp:label id="Label12" runat="server">Ta bort</asp:label></td>
					</tr>
					<tr>
						<td colSpan="3">&nbsp;</td>
						<td colSpan="5"><asp:listbox id="lbRoutes" runat="server" Width="150px"></asp:listbox></td>
					</tr>
					<tr>
						<td colSpan="4">&nbsp;</td>
						<td><asp:imagebutton id="btnPlanRoute" runat="server" ImageUrl="Images/Go.jpg"></asp:imagebutton></td>
						<td colspan="3"><asp:label id="Label18" runat="server">Planera rutt</asp:label></td>
					</tr>
				</table>
			</td>
			<td><asp:image id="imgMap" runat="server" ImageUrl="./Images/LargeEx.BMP" Width="550px"></asp:image></td>
		</tr>
	</table>
</div>
