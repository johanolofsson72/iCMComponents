<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ModuleDefinition.ascx.cs" Inherits="iConsulting.iCMServer.Modules.ModuleDefinition.ModuleDefinition" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<table cellSpacing="1" cellPadding="1" width="100%" border="0">
		<tr>
			<td width="20">&nbsp;</td>
			<td width="80"><asp:Label id="lblSystem" runat="server" CssClass="SubHead">Label</asp:Label></td>
			<td><asp:DropDownList id="ddSystem" runat="server" Width="344px" AutoPostBack="True"></asp:DropDownList>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td width="80"><asp:Label id="lblDesktop" runat="server" CssClass="SubHead">Label</asp:Label></td>
			<td><asp:DropDownList id="ddDesktop" runat="server" Width="344px" AutoPostBack="True"></asp:DropDownList>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td colspan="4">&nbsp;</td>
		</tr>
		<tr>
			<td width="20">&nbsp;</td>
			<td colspan="2">
				<asp:Panel id="ItemInfo" runat="server">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD width="83">
								<asp:Label id="lblType" runat="server" CssClass="SubHead">Label</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtType" runat="server" Width="344px" ReadOnly="True"></asp:TextBox></TD>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD width="83">
								<asp:Label id="lblId" runat="server" CssClass="SubHead">Label</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtId" runat="server" Width="344px" ReadOnly="True"></asp:TextBox></TD>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD width="83">
								<asp:Label id="lblTitle" runat="server" CssClass="SubHead">Label</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtTitle" runat="server" Width="344px"></asp:TextBox></TD>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD width="83">
								<asp:Label id="lblUrl" runat="server" CssClass="SubHead">Label</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtUrl" runat="server" Width="344px"></asp:TextBox></TD>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD width="83">&nbsp;</TD>
							<TD>
								<TABLE cellSpacing="4" cellPadding="4">
									<TR>
										<TD>
											<asp:Button id="btnUpdate" runat="server" CssClass="button" Text="Button"></asp:Button></TD>
									</TR>
								</TABLE>
							</TD>
							<TD>&nbsp;</TD>
						</TR>
					</TABLE>
				</asp:Panel>
			</td>
			<td>&nbsp;</td>
		</tr>
	</table>
</div>
