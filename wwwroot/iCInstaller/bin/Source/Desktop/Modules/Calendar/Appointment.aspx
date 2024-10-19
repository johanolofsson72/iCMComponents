<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Appointment.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Calendar.Appointment"%>
<HTML>
	<HEAD>
		<title>Appointment</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<icmserverstyle:title id="iCMServerStyle1" runat="server" ViewType="Standard" ViewSource="Main"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="1">&nbsp;
								</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr>
											<td class="Head" align="left" width="525"><asp:label id="lblHeader" runat="server">lblHeader</asp:label></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="500">
										<tr vAlign="top" height="20">
											<td class="SubHead" colSpan="3">
												<hr>
											</td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead" width="200" height="20"><asp:label id="lblSubject" runat="server">lblSubject</asp:label>&nbsp;&nbsp;&nbsp;</td>
											<td height="20"><asp:textbox id="txtSubject" runat="server" Width="408px"></asp:textbox></td>
											<td class="Normal" width="150" height="20"></td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead" width="200"><asp:label id="lblStartTime" runat="server">lblStartTime</asp:label>&nbsp;</td>
											<td><asp:dropdownlist id="ddYear" runat="server" Width="59px">
													<asp:ListItem Value="2000" Selected="True">2000</asp:ListItem>
													<asp:ListItem Value="2001">2001</asp:ListItem>
													<asp:ListItem Value="2003">2003</asp:ListItem>
													<asp:ListItem Value="2004">2004</asp:ListItem>
													<asp:ListItem Value="2005">2005</asp:ListItem>
													<asp:ListItem Value="2006">2006</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
													<asp:ListItem Value="2010">2010</asp:ListItem>
													<asp:ListItem Value="2011">2011</asp:ListItem>
													<asp:ListItem Value="2012">2012</asp:ListItem>
													<asp:ListItem Value="2013">2013</asp:ListItem>
													<asp:ListItem Value="2014">2014</asp:ListItem>
													<asp:ListItem Value="2015">2015</asp:ListItem>
													<asp:ListItem Value="2016">2016</asp:ListItem>
													<asp:ListItem Value="2017">2017</asp:ListItem>
													<asp:ListItem Value="2018">2018</asp:ListItem>
													<asp:ListItem Value="2019">2019</asp:ListItem>
													<asp:ListItem Value="2020">2020</asp:ListItem>
												</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddMonth" runat="server">
													<asp:ListItem Value="01" Selected="True">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
												</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddDay" runat="server">
													<asp:ListItem Value="01" Selected="True">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist>&nbsp;
												<asp:label id="lblError" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Names="Verdana">Label</asp:label></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead" width="200"><asp:label id="lblEndTime" runat="server">lblStartTime</asp:label>&nbsp;</td>
											<td><asp:dropdownlist id="ddYear2" runat="server" Width="59px">
													<asp:ListItem Value="2000" Selected="True">2000</asp:ListItem>
													<asp:ListItem Value="2001">2001</asp:ListItem>
													<asp:ListItem Value="2003">2003</asp:ListItem>
													<asp:ListItem Value="2004">2004</asp:ListItem>
													<asp:ListItem Value="2005">2005</asp:ListItem>
													<asp:ListItem Value="2006">2006</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
													<asp:ListItem Value="2010">2010</asp:ListItem>
													<asp:ListItem Value="2011">2011</asp:ListItem>
													<asp:ListItem Value="2012">2012</asp:ListItem>
													<asp:ListItem Value="2013">2013</asp:ListItem>
													<asp:ListItem Value="2014">2014</asp:ListItem>
													<asp:ListItem Value="2015">2015</asp:ListItem>
													<asp:ListItem Value="2016">2016</asp:ListItem>
													<asp:ListItem Value="2017">2017</asp:ListItem>
													<asp:ListItem Value="2018">2018</asp:ListItem>
													<asp:ListItem Value="2019">2019</asp:ListItem>
													<asp:ListItem Value="2020">2020</asp:ListItem>
												</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddMonth2" runat="server">
													<asp:ListItem Value="01" Selected="True">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
												</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddDay2" runat="server">
													<asp:ListItem Value="01" Selected="True">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist>&nbsp;
												<asp:label id="lblError2" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Names="Verdana">Label</asp:label></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead" width="200"><asp:label id="lblStart" runat="server">lblStart</asp:label>&nbsp;</td>
											<TD><asp:dropdownlist id="ddStartTime" runat="server">
													<asp:ListItem Value="00:00" Selected="True">00:00</asp:ListItem>
													<asp:ListItem Value="00:30">00:30</asp:ListItem>
													<asp:ListItem Value="01:00">01:00</asp:ListItem>
													<asp:ListItem Value="01:30">01:30</asp:ListItem>
													<asp:ListItem Value="02:00">02:00</asp:ListItem>
													<asp:ListItem Value="02:30">02:30</asp:ListItem>
													<asp:ListItem Value="03:00">03:00</asp:ListItem>
													<asp:ListItem Value="03:30">03:30</asp:ListItem>
													<asp:ListItem Value="04:00">04:00</asp:ListItem>
													<asp:ListItem Value="04:30">04:30</asp:ListItem>
													<asp:ListItem Value="05:00">05:00</asp:ListItem>
													<asp:ListItem Value="05:30">05:30</asp:ListItem>
													<asp:ListItem Value="06:00">06:00</asp:ListItem>
													<asp:ListItem Value="06:30">06:30</asp:ListItem>
													<asp:ListItem Value="07:00">07:00</asp:ListItem>
													<asp:ListItem Value="07:30">07:30</asp:ListItem>
													<asp:ListItem Value="08:00">08:00</asp:ListItem>
													<asp:ListItem Value="08:30">08:30</asp:ListItem>
													<asp:ListItem Value="09:00">09:00</asp:ListItem>
													<asp:ListItem Value="09:30">09:30</asp:ListItem>
													<asp:ListItem Value="10:00">10:00</asp:ListItem>
													<asp:ListItem Value="10:30">10:30</asp:ListItem>
													<asp:ListItem Value="11:00">11:00</asp:ListItem>
													<asp:ListItem Value="11:30">11:30</asp:ListItem>
													<asp:ListItem Value="12:00">12:00</asp:ListItem>
													<asp:ListItem Value="12:30">12:30</asp:ListItem>
													<asp:ListItem Value="13:00">13:00</asp:ListItem>
													<asp:ListItem Value="13:30">13:30</asp:ListItem>
													<asp:ListItem Value="14:00">14:00</asp:ListItem>
													<asp:ListItem Value="14:30">14:30</asp:ListItem>
													<asp:ListItem Value="15:00">15:00</asp:ListItem>
													<asp:ListItem Value="15:30">15:30</asp:ListItem>
													<asp:ListItem Value="16:00">16:00</asp:ListItem>
													<asp:ListItem Value="16:30">16:30</asp:ListItem>
													<asp:ListItem Value="17:00">17:00</asp:ListItem>
													<asp:ListItem Value="17:30">17:30</asp:ListItem>
													<asp:ListItem Value="18:00">18:00</asp:ListItem>
													<asp:ListItem Value="18:30">18:30</asp:ListItem>
													<asp:ListItem Value="19:00">19:00</asp:ListItem>
													<asp:ListItem Value="19:30">19:30</asp:ListItem>
													<asp:ListItem Value="20:00">20:00</asp:ListItem>
													<asp:ListItem Value="20:30">20:30</asp:ListItem>
													<asp:ListItem Value="21:00">21:00</asp:ListItem>
													<asp:ListItem Value="21:30">21:30</asp:ListItem>
													<asp:ListItem Value="22:00">22:00</asp:ListItem>
													<asp:ListItem Value="22:30">22:30</asp:ListItem>
													<asp:ListItem Value="23:00">23:00</asp:ListItem>
													<asp:ListItem Value="23:30">23:30</asp:ListItem>
												</asp:dropdownlist></TD>
											<td class="Normal" style="VERTICAL-ALIGN: baseline; OVERFLOW: hidden; DIRECTION: rtl; TEXT-ALIGN: left"></td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead" width="200">
												<asp:label id="lblEnd" runat="server">lblEnd</asp:label>&nbsp;</td>
											<td><asp:dropdownlist id="ddEndTime" runat="server">
													<asp:ListItem Value="00:00">00:00</asp:ListItem>
													<asp:ListItem Value="00:30" Selected="True">00:30</asp:ListItem>
													<asp:ListItem Value="01:00">01:00</asp:ListItem>
													<asp:ListItem Value="01:30">01:30</asp:ListItem>
													<asp:ListItem Value="02:00">02:00</asp:ListItem>
													<asp:ListItem Value="02:30">02:30</asp:ListItem>
													<asp:ListItem Value="03:00">03:00</asp:ListItem>
													<asp:ListItem Value="03:30">03:30</asp:ListItem>
													<asp:ListItem Value="04:00">04:00</asp:ListItem>
													<asp:ListItem Value="04:30">04:30</asp:ListItem>
													<asp:ListItem Value="05:00">05:00</asp:ListItem>
													<asp:ListItem Value="05:30">05:30</asp:ListItem>
													<asp:ListItem Value="06:00">06:00</asp:ListItem>
													<asp:ListItem Value="06:30">06:30</asp:ListItem>
													<asp:ListItem Value="07:00">07:00</asp:ListItem>
													<asp:ListItem Value="07:30">07:30</asp:ListItem>
													<asp:ListItem Value="08:00">08:00</asp:ListItem>
													<asp:ListItem Value="08:30">08:30</asp:ListItem>
													<asp:ListItem Value="09:00">09:00</asp:ListItem>
													<asp:ListItem Value="09:30">09:30</asp:ListItem>
													<asp:ListItem Value="10:00">10:00</asp:ListItem>
													<asp:ListItem Value="10:30">10:30</asp:ListItem>
													<asp:ListItem Value="11:00">11:00</asp:ListItem>
													<asp:ListItem Value="11:30">11:30</asp:ListItem>
													<asp:ListItem Value="12:00">12:00</asp:ListItem>
													<asp:ListItem Value="12:30">12:30</asp:ListItem>
													<asp:ListItem Value="13:00">13:00</asp:ListItem>
													<asp:ListItem Value="13:30">13:30</asp:ListItem>
													<asp:ListItem Value="14:00">14:00</asp:ListItem>
													<asp:ListItem Value="14:30">14:30</asp:ListItem>
													<asp:ListItem Value="15:00">15:00</asp:ListItem>
													<asp:ListItem Value="15:30">15:30</asp:ListItem>
													<asp:ListItem Value="16:00">16:00</asp:ListItem>
													<asp:ListItem Value="16:30">16:30</asp:ListItem>
													<asp:ListItem Value="17:00">17:00</asp:ListItem>
													<asp:ListItem Value="17:30">17:30</asp:ListItem>
													<asp:ListItem Value="18:00">18:00</asp:ListItem>
													<asp:ListItem Value="18:30">18:30</asp:ListItem>
													<asp:ListItem Value="19:00">19:00</asp:ListItem>
													<asp:ListItem Value="19:30">19:30</asp:ListItem>
													<asp:ListItem Value="20:00">20:00</asp:ListItem>
													<asp:ListItem Value="20:30">20:30</asp:ListItem>
													<asp:ListItem Value="21:00">21:00</asp:ListItem>
													<asp:ListItem Value="21:30">21:30</asp:ListItem>
													<asp:ListItem Value="22:00">22:00</asp:ListItem>
													<asp:ListItem Value="22:30">22:30</asp:ListItem>
													<asp:ListItem Value="23:00">23:00</asp:ListItem>
													<asp:ListItem Value="23:30">23:30</asp:ListItem>
													<asp:ListItem Value="23:59">24:00</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead"><asp:label id="lblLabel" runat="server">lblLabel</asp:label></td>
											<td><asp:DropDownList id="ddLabel" runat="server"></asp:DropDownList></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" width="200"><asp:label id="lblText" runat="server">lblText</asp:label>&nbsp;</td>
											<td><asp:textbox id="txtText" runat="server" Width="405px" TextMode="MultiLine" Height="144px"></asp:textbox></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top" height="20">
											<td class="SubHead" colSpan="3">
												<hr>
											</td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead"></td>
											<td></td>
											<td class="Normal"></td>
										</tr>
										<tr vAlign="top">
											<td class="SubHead" colSpan="3"><asp:button id="btnUpdate" runat="server" CssClass="iCWebControlsII" Text="btnUpdate"></asp:button>&nbsp;
												<asp:button id="btnCancel" runat="server" CssClass="iCWebControlsII" Text="btnCancel"></asp:button>&nbsp;
												<asp:button id="btnDelete" runat="server" CssClass="iCWebControlsII" Text="btnDelete"></asp:button></td>
										</tr>
									</table>
									<p>&nbsp;&nbsp;&nbsp;</p>
									<span class="Normal">
										<br>
									</span>
									<P></P>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
