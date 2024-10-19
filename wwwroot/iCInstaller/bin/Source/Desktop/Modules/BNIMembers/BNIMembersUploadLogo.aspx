<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BNIMembersUploadLogo.aspx.vb" Inherits="iConsulting.iCMServer.Modules.BNIMembers.BNIMembersUploadLogo"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<table align="center">
				<tr vAlign="middle">
					<td class="Head"></td>
					<td width="334">
						<asp:Label id="lblTitle" runat="server" CssClass="SubHead">Label</asp:Label></td>
				</tr>
				<tr vAlign="middle">
					<td class="SubHead">
					</td>
					<td width="334"><hr>
					</td>
				</tr>
				<tr vAlign="middle">
					<td class="SubHead"></td>
					<td width="334"></td>
				</tr>
				<tr vAlign="middle">
					<td class="SubHead"></td>
					<td width="334"><INPUT id="FileUpload" type="file" size="36" runat="server" NAME="FileUpload"></td>
				</tr>
				<tr vAlign="middle">
					<td class="SubHead"></td>
					<td width="334"></td>
				</tr>
				<tr vAlign="middle">
					<td class="SubHead"></td>
					<td width="334"></td>
				</tr>
				<tr vAlign="middle">
					<td class="SubHead" colSpan="3" width="334">&nbsp;&nbsp;&nbsp;
						<asp:Button id="btnSave" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:Button>&nbsp;
						<asp:Button id="btnDelete" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:Button>&nbsp;
						<asp:Button id="btnCancel" runat="server" Text="Button" CssClass="iCWebControlsII"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
