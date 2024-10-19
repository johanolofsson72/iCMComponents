<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RBTemplate2Edit.aspx.vb" Inherits="iConsulting.iCMServer.Modules.RBTemplate2.RBTemplate2Edit"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="4" width="98%" border="0">
							<tr vAlign="top">
								<td width="10">&nbsp;</td>
								<td width="*">
									<table cellSpacing="0" cellPadding="0" width="98%" border="0">
										<tr>
											<td width="44"><asp:label id="r1_1" runat="server">Rubrik:</asp:label></td>
											<td width="16"><asp:textbox id="Header1_1" runat="server" Width="233px" Font-Names="Verdana" Font-Size="10pt"
													Font-Bold="True"></asp:textbox></td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44" vAlign="top"><asp:label id="t1_1" runat="server">Text:</asp:label></td>
											<td width="16" rowspan="8" vAlign="top"><asp:textbox id="Text1_1" runat="server" Width="233px" Height="325px" Font-Names="Verdana" Font-Size="8pt"
													TextMode="MultiLine"></asp:textbox></td>
											<td width="41">&nbsp;</td>
											<td width="515">
												<asp:Panel id="Panel1" runat="server" Width="291px" Height="80px">
													<P>&nbsp;</P>
												</asp:Panel></td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41"><asp:label id="t2_2" runat="server">Text:</asp:label></td>
											<td width="515"><asp:textbox id="txtSection2_2" runat="server" Width="291px" Font-Names="Verdana" Font-Size="8pt"
													Height="21px"></asp:textbox></td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515"><IMG id="Section2_2" height="139" alt="" src="" width="291" runat="server"></td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41"><asp:label id="b2_2" runat="server">Bild:</asp:label></td>
											<td width="515"><INPUT id="filSection2_2" type="file" size="29" name="FileUpload" runat="server"></td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="41"><asp:label id="l2_2" runat="server">Länk:</asp:label></td>
											<td width="515"><asp:textbox id="txt2_2" runat="server" Width="291px"></asp:textbox></td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="16">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="16">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<TR>
											<td width="44">&nbsp;</td>
											<td width="16"><IMG id="Section1_3" height="171" alt="" src="" width="291" runat="server"></td>
											<td width="41" vAlign="top"><asp:label id="r2_3" runat="server">Rubrik:</asp:label><br>
												<br>
												<asp:label id="t2_3" runat="server">Text:</asp:label></td>
											<td width="515" vAlign="top">
												<asp:textbox id="Header2_3" runat="server" Width="233px" Font-Names="Verdana" Font-Size="10pt"
													Font-Bold="true"></asp:textbox><br>
												<asp:textbox id="Text2_3" runat="server" Width="233px" Height="125px" Font-Names="Verdana" Font-Size="8pt"
													TextMode="MultiLine"></asp:textbox>
											</td>
										</TR>
										<tr>
											<td width="44"><asp:label id="b1_3" runat="server"> Bild:</asp:label></td>
											<td width="16"><INPUT id="filSection1_3" type="file" size="29" name="FileUpload" runat="server"></td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44"><asp:label id="l1_3" runat="server">Länk:</asp:label></td>
											<td width="16"><asp:textbox id="txt1_3" runat="server" Width="291px"></asp:textbox></td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td width="44">&nbsp;</td>
											<td width="16">&nbsp;</td>
											<td width="41">&nbsp;</td>
											<td width="515">&nbsp;</td>
										</tr>
										<tr>
											<td align="left" width="971" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="776" border="0" height="24">
													<tr>
														<td align="center"><asp:button id="btnBack" runat="server" Text="Button"></asp:button>&nbsp;
															<asp:button id="btnSave" runat="server" Text="Button"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
