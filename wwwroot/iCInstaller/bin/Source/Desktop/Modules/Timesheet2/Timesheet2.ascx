<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Timesheet2.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Timesheet2.Timesheet2" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" EditText="" Location="iConsulting.iCMServer.Modules.Timesheet2" Phrase="timesheet2_edit" EditUrl="~/Desktop/Modules/Timesheet2/Timesheet2Edit.aspx" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr height="20">
			<td width="5">&nbsp;</td>
			<TD vAlign="top" bgcolor="#ffffff" align="left" width="322" style="BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 322px; BORDER-BOTTOM: black 1px solid">
				&nbsp;
				<asp:ImageButton id="imgNewAppointment" runat="server" ImageUrl="Images/newappointment.gif" ImageAlign="Bottom"
					Visible="false"></asp:ImageButton>
				<%If IsAuthorized Then%>
				<IMG onclick="OPENNEW<%=ModuleId%>('<%=ViewState.Item("iCMServer.Modules.Timesheet2.SelectedDay" & ModuleId)%>');" id="imgA" alt="" src="Desktop/Modules/Timesheet2/Images/newappointment.gif"
					style="CURSOR: hand">
				<%End If%>
				<asp:LinkButton id="lnkNew" runat="server" Font-Name="verdana" Font-Bold="false" Font-Size="8" ForeColor="black">New</asp:LinkButton></TD>
			<TD vAlign="top" bgcolor="#ffffff" width="2" style="BORDER-TOP: black 1px solid; WIDTH: 2px; BORDER-BOTTOM: black 1px solid">&nbsp;</TD>
			<TD vAlign="top" bgcolor="#ffffff" width="100%" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-BOTTOM: black 1px solid">&nbsp;</TD>
			<td width="5">&nbsp;</td>
		</tr>
		<TR>
			<td width="5">&nbsp;</td>
			<TD vAlign="top" bgcolor="#ffffff" align="center" width="322" style="BORDER-LEFT: black 1px solid; WIDTH: 322px">
				<asp:calendar id="cal" runat="server" Width="152px" Height="112px" BackColor="White" DayNameFormat="FirstLetter"
					ForeColor="Black" Font-Size="9pt" Font-Names="Verdana" BorderColor="White" SelectionMode="DayWeek"
					BorderWidth="1px">
					<TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
					<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="Black" VerticalAlign="Bottom"></NextPrevStyle>
					<DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
					<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
					<TitleStyle Font-Size="10pt" BorderWidth="2px" ForeColor="Black" BorderColor="Black" BackColor="#ffffff"
						Font-Bold="true" Font-Name="verdana"></TitleStyle>
					<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
				</asp:calendar></TD>
			<TD width="2" bgcolor="#ffffff" valign="top" style="WIDTH: 2px; BACKGROUND-REPEAT: repeat-x"
				background="Desktop/Modules/Calendar/Images/bar3.gif">&nbsp;</TD>
			<TD width="100%" bgcolor="#ffffff" valign="top" style="BORDER-RIGHT: black 1px solid;">
				<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
					<TR>
						<TD NOWRAP>
							<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
								<TR>
									<TD>
										<asp:PlaceHolder id="BarHolder" runat="server"></asp:PlaceHolder>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD NOWRAP>
							<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
								<TR>
									<TD>
										<asp:PlaceHolder id="TimeHolder" runat="server" EnableViewState="false"></asp:PlaceHolder>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</TD>
			<td width="5">&nbsp;</td>
		</TR>
		<!--
		<tr>
			<td width="5">&nbsp;</td>
			<td width="322" bgcolor="#ffffff" valign="top" style="BORDER-LEFT: black 1px solid;BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="2" bgcolor="#ffffff" valign="top" style="BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="100%" bgcolor="#ffffff" valign="top" style="BORDER-RIGHT: black 1px solid;BORDER-BOTTOM: black 1px solid">&nbsp;</td>
			<td width="5">&nbsp;</td>
		</tr>
		-->
		<tr>
			<td width="5">&nbsp;</td>
			<td width="100%" colspan="3" bgcolor="#f5f5f5" valign="top" style="BORDER-RIGHT: black 1px solid;BORDER-LEFT: black 1px solid;BORDER-BOTTOM: black 1px solid">
										<asp:PlaceHolder id="CalendarHolder" runat="server" EnableViewState="false"></asp:PlaceHolder>&nbsp;</td>
			<td width="5">&nbsp;</td>
		</tr>
	</TABLE>
</div>
