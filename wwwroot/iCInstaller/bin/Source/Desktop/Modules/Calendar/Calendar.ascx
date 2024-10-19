<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Calendar.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Calendar.Calendar" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SITE:TITLE id="Title2" EditText="" Location="" Phrase="" EditUrl="" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr height="20">
			<td width="5">&nbsp;</td>
			<TD vAlign="top" bgcolor="#ffffff" align="left" width="322" style="BORDER-BOTTOM: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid;  WIDTH: 322px">
				&nbsp;
				<asp:ImageButton id="imgNewAppointment" runat="server" ImageUrl="Images/newappointment.gif" ImageAlign="Bottom"
					Visible="false"></asp:ImageButton>
				<%If IsAuthorized Then%>
				<IMG onclick="OPENNEW('<%=Session.Item("iCMServer.Modules.Calendar.SelectedDay")%>');" id="imgA" alt="" src="Desktop/Modules/Calendar/Images/newappointment.gif"
					style="CURSOR: hand">
				<%End If%>
				<asp:LinkButton id="lnkNew" runat="server" Font-Name="verdana" Font-Bold="false" Font-Size="8" ForeColor="black">New</asp:LinkButton></TD>
			<TD vAlign="top" bgcolor="#ffffff" width="2" style="BORDER-BOTTOM: black 1px solid; BORDER-TOP: black 1px solid; WIDTH: 2px">&nbsp;</TD>
			<TD align="right" vAlign="top" bgcolor="#ffffff" width="99%" style="BORDER-BOTTOM: black 1px solid; BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid;">&nbsp;
				<asp:CheckBox id="chkSimpleViewState" CssClass="SubSubHead" runat="server" EnableViewState="true" AutoPostBack="true"></asp:CheckBox>&nbsp;
			</TD>
			<td width="5">&nbsp;</td>
		</tr>
		<TR>
			<td width="5">&nbsp;</td>
			<TD vAlign="top" bgcolor="#ffffff" align="center" width="322" style="BORDER-BOTTOM: black 1px solid;BORDER-LEFT: black 1px solid; WIDTH: 322px">
				<asp:calendar id="cal" runat="server" Width="152px" Height="112px" BackColor="White" DayNameFormat="FirstLetter"
					ForeColor="Black" Font-Size="9pt" Font-Names="Verdana" BorderColor="White" SelectionMode="DayWeek"
					BorderWidth="1px">
					<TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
					<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="Black" VerticalAlign="Bottom"></NextPrevStyle>
					<DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
					<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
					<TitleStyle Font-Size="10pt" BorderWidth="2px" ForeColor="Black" BorderColor="Black" BackColor="#ffffff" Font-Bold="true" Font-Name="verdana"></TitleStyle>
					<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
				</asp:calendar></TD>
			<TD width="2" bgcolor="#ffffff" valign="top" style="BORDER-BOTTOM: black 1px solid;WIDTH: 2px; BACKGROUND-REPEAT: repeat-x" background="Desktop/Modules/Calendar/Images/bar3.gif">&nbsp;</TD>
			<TD width="100%" bgcolor="#ffffff" valign="top" style="BORDER-RIGHT: black 1px solid;BORDER-BOTTOM: black 1px solid;">
				<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
					<TR>
						<TD NOWRAP>
							<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
								<TR>
									<TD>
										<asp:PlaceHolder id="BarHolder" runat="server">
											<TABLE cellSpacing="0" cellPadding="0" align="left" border="0">
												<TR height="20">
													<TD width="62" bgColor="#e0dfe3">&nbsp;</TD>
												</TR>
											</TABLE>
										</asp:PlaceHolder>
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
										<asp:PlaceHolder id="CalendarHolder" runat="server" EnableViewState="false"></asp:PlaceHolder>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</TD>
			<td width="5">&nbsp;</td>
		</TR>
	</TABLE>
</div>
