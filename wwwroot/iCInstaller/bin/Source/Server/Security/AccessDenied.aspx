<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ OutputCache Duration="36000" VaryByParam="none" %>
<%@ Page CodeBehind="AccessDenied.aspx.vb" language="vb" AutoEventWireup="false" Inherits="iConsulting.iCMServer.AccessDeniedPage" %>
<HTML>
	<HEAD>
		<title>iCMServer</title>
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0" marginheight="0">
		<form runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2"></td>
				</tr>
				<tr>
					<td vAlign="top">
						<center><br>
							<table width="500" border="0">
								<tr>
									<td class="Normal"><br>
										<br>
										<br>
										<br>
										<span class="Head">Access 
            Denied !!!</span>
										<br>
										<br>
										<hr noShade SIZE="1">
										<br>
										<br>
										<br>
										<asp:LinkButton id="btnStartPage" runat="server">Back to startpage</asp:LinkButton></td>
								</tr>
							</table>
						</center>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
