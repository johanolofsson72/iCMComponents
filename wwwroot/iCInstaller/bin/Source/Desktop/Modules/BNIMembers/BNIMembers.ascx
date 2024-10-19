<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BNIMembers.ascx.vb" Inherits="iConsulting.iCMServer.Modules.BNIMembers.BNIMembers" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SITE:TITLE id="Title2" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<table id="Table1" style="WIDTH: 584px; HEIGHT: 480px" align="left" height="480" width="584"
		border="0">
		<tr>
			<td height="36"></td>
			<td vAlign="bottom" height="36">
				<table width="100%">
					<tr>
						<td align="left" width="50%"><asp:image id="imgLogga" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="0px"></asp:image></td>
						<td align="right" vAlign="bottom" width="50%"><asp:hyperlink id="lnkLogga" runat="server" Font-Name="verdana" Font-Size="8" ForeColor="black">Ny logga</asp:hyperlink>&nbsp;&nbsp;&nbsp;</td>
					</tr>
				</table>
			</td>
			<td vAlign="bottom" height="36">
				<table width="100%">
					<tr>
						<td align="left" width="50%"><asp:label id="lblSeek" runat="server" Font-Name="verdana" Font-Size="8" ForeColor="black">Söker </asp:label></td>
						<td align="right" width="50%"><asp:hyperlink id="lnkNewPic" Font-Name="verdana" Font-Size="8" ForeColor="black" runat="server">Ny Bild</asp:hyperlink></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td vAlign="top" height="62"></td>
			<td vAlign="top" rowSpan="2"><asp:textbox id="txtMemberText" Height="376px" Width="384px" style="BORDER-RIGHT: #f3f3cd 1pt solid; BORDER-TOP: #f3f3cd 1pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 1pt solid; COLOR: dimgray; BORDER-BOTTOM: #f3f3cd 1pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent"
					runat="server" BorderWidth="1" ForeColor="#6B6B61" Font-Size="10px" Font-Names="Verdana" TextMode="MultiLine" ReadOnly="True"
					borderColor="#f3f3cd" Rows="29" Columns="71" BackColor="#ffffff" MaxLength="4000"></asp:textbox></td>
			<td vAlign="top" height="62"><asp:textbox id="txtBoxSearch" style="BORDER-RIGHT: #f3f3cd 1pt solid; BORDER-TOP: #f3f3cd 1pt solid; FONT-SIZE: xx-small; OVERFLOW: hidden; BORDER-LEFT: #f3f3cd 1pt solid; COLOR: dimgray; BORDER-BOTTOM: #f3f3cd 1pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent"
					runat="server" BorderWidth="1" ForeColor="#6B6B61" Font-Size="10px" Font-Names="Verdana" Width="168" Height="170"
					Rows="12" Columns="28" TextMode="MultiLine" ReadOnly="True" borderColor="#f3f3cd" BackColor="#ffffff" MaxLength="4000"></asp:textbox></td>
		</tr>
		<tr>
			<td vAlign="bottom" align="right"></td>
			<td vAlign="top"><asp:image id="imgMe" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="0px"
					Width="170px" Height="206px"></asp:image></td>
			<td></td>
		</tr>
		<tr>
			<td></td>
			<td vAlign="top" align="center" width="442">
				<table id="Table2" width="200">
					<TR>
						<TD><asp:label id="lName" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">Namn:</asp:label></TD>
						<TD><asp:textbox id="txtName" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server" Visible="False"
								Width="192" Columns="28" MaxLength="255"></asp:textbox><asp:label Font-Name="verdana" Font-Size="8" ForeColor="Gray" id="lblName" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lStreet" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">Gata:</asp:label></TD>
						<TD><asp:textbox id="txtStreet" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server"
								Visible="False" Width="192px" Columns="28" MaxLength="255"></asp:textbox>
							<asp:label id="lblStreet" runat="server" ForeColor="Gray" Font-Size="8" Font-Name="verdana"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lPcode" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">PostNr:</asp:label></TD>
						<TD><asp:textbox id="txtPcode" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server"
								Visible="False" Width="192px" Columns="28" MaxLength="25"></asp:textbox>
							<asp:label id="lblPcode" runat="server" ForeColor="Gray" Font-Size="8" Font-Name="verdana"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lcity" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">Ort:</asp:label></TD>
						<TD><asp:textbox id="txtCity" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server" Visible="False"
								Width="192px" Columns="28" MaxLength="255"></asp:textbox>
							<asp:label id="lblCity" runat="server" ForeColor="Gray" Font-Size="8" Font-Name="verdana"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lPhone" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">Telefon:</asp:label></TD>
						<TD><asp:textbox id="txtPhone" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server"
								Visible="False" Width="192" Columns="28" MaxLength="255"></asp:textbox><asp:label Font-Name="verdana" Font-Size="8" ForeColor="Gray" id="lblPhone" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD><asp:label id="lMail" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">E-Mail:</asp:label></TD>
						<TD><asp:textbox id="txtMail" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server" Visible="False"
								Width="192" Columns="28" MaxLength="255"></asp:textbox><asp:hyperlink Font-Name="verdana" Font-Size="8" ForeColor="Gray" id="lnkMail" runat="server"></asp:hyperlink></TD>
					</TR>
					<TR>
						<TD><asp:label id="lWeb" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server">Web:</asp:label></TD>
						<TD><asp:textbox id="txtWeb" Font-Name="verdana" Font-Size="8" ForeColor="Gray" runat="server" Visible="False"
								Width="192px" Columns="28" MaxLength="255"></asp:textbox><asp:hyperlink Font-Name="verdana" Font-Size="8" ForeColor="Gray" id="lnkWeb" runat="server"></asp:hyperlink></TD>
					</TR>
				</table>
				<asp:button id="btnSave" runat="server" CssClass="iCWebControlsII" Visible="False" Text="Spara"></asp:button></td>
			<td></td>
		</tr>
	</table>
</div>
