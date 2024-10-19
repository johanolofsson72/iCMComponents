<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Template013.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Template013.Template013" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" EditText="" Location="iConsulting.iCMServer.Modules.Template013" Phrase="template013_edit"
	EditUrl="~/Desktop/Modules/Template013/Template013Edit.aspx" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" id="Table1">
		<tr>
			<td width="20%">&nbsp;</td>
			<td width="10%">&nbsp;</td>
			<td width="20%">&nbsp;</td>
			<td width="30%">&nbsp;</td>
			<td width="20%">&nbsp;</td>
		</tr>
		<tr height="24">
			<td>&nbsp;</td>
			<td><asp:label id="lblTo" runat="server" CssClass="subsubhead">lblTo</asp:label></td>
			<td><asp:dropdownlist id="ddTo" runat="server" CssClass="label" Width="255px"></asp:dropdownlist></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr height="24">
			<td>&nbsp;</td>
			<td><asp:label id="lblFrom" runat="server" CssClass="subsubhead">lblFrom</asp:label></td>
			<td><asp:textbox id="txtFrom" runat="server" CssClass="label" Width="255px"></asp:textbox></td>
			<td><asp:label id="lblNote" runat="server" CssClass="subsubhead" DESIGNTIMEDRAGDROP="389">lblNote</asp:label></td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td><asp:label id="lblCompany" runat="server" CssClass="subsubhead">lblCompany</asp:label></td>
			<td><asp:textbox id="txtCompany" runat="server" CssClass="label" Width="255px"></asp:textbox></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td><asp:label id="lblGroup" runat="server" CssClass="subsubhead">lblGroup</asp:label></td>
			<td><asp:textbox id="txtGroup" runat="server" CssClass="label" Width="255px"></asp:textbox></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<asp:label id="lblCourse" runat="server" CssClass="subsubhead">lblCourse</asp:label></td>
			<td>
				<asp:dropdownlist id="ddCourse" runat="server" CssClass="label" Width="255px"></asp:dropdownlist></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr height="24">
			<td>&nbsp;</td>
			<td></td>
			<td></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td align="right">&nbsp;
				<asp:button id="btnSend" runat="server" CssClass="iCWebControlsII" Text="Button"></asp:button></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
			<td>&nbsp;
				<asp:Panel id="Panel1" runat="server">
					<asp:label id="lblMessage" runat="server" CssClass="subhead">lblMessage</asp:label>
				</asp:Panel></td>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
	</TABLE>
</div>
