<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ProjectList.ascx.vb" Inherits="iConsulting.iCMServer.Modules.ProjectList.ProjectList" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<meta content="False" name="vs_showGrid">
<SITE:TITLE id="Title2" EditText="" Location="" Phrase="" EditUrl="" runat="server"></SITE:TITLE>
<div id="Minimizer" runat="server">
	<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD><asp:datagrid id="dgProjList" runat="server" OnEditCommand="dgProjList_EditCommand" OnCancelCommand="dgProjList_CancelCommand"
					OnDeleteCommand="dgProjList_DeleteCommand" OnUpdateCommand="dgProjList_UpdateCommand" Width="470px"
					BorderColor="#F7E1B0" DataKeyField="prl_id" HorizontalAlign="Left" AutoGenerateColumns="False"
					CellSpacing="2" CellPadding="2" BorderWidth="1px" ForeColor="Black">
					<ItemStyle ForeColor="DimGray"></ItemStyle>
					<HeaderStyle Font-Size="10px" Font-Names="Verdana" ForeColor="Black" BackColor="#D5AE6B"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Nummer">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle ForeColor="Black" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox width="20px" TextMode=SingleLine style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ForeColor=#000000 ID="lblNr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_number") %>' ReadOnly=True>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox width="20px" TextMode=SingleLine ID="txtNr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_number") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Start">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle Wrap="False" ForeColor="Black" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox width="70px" style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ReadOnly=True TextMode=SingleLine ID="lblStart" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_start") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox width="70px" TextMode=SingleLine ID="txtStart" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_start") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Ledare">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox width="50px" style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ReadOnly=True TextMode=SingleLine ID="lblLeader" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_leader") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox width="50px" TextMode=SingleLine ID="txtLeader" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_leader") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Deltagare">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox width="100px" style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" ReadOnly=True TextMode=SingleLine ID="lblParticipant" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_participant") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox width="100px" TextMode=SingleLine ID="txtParticipant" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_participant") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Beskrivning">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox ReadOnly=True Width=150 Rows=3 style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" TextMode=MultiLine ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_description") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox TextMode=MultiLine Width=150 Rows=3 ID="txtDescription" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_description") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Syfte">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox ReadOnly=True  Width=150 Rows=3  style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" TextMode=MultiLine ID="lblAim" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_aim") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox TextMode=MultiLine  Width=150 Rows=3  ID="txtAim" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_aim") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Klart">
							<HeaderStyle Font-Names="verdana" ForeColor="Black"></HeaderStyle>
							<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox width="70px" ReadOnly=True style="BORDER-RIGHT: #f3f3cd 0pt solid; BORDER-TOP: #f3f3cd 0pt solid; FONT-SIZE: xx-small; OVERFLOW-Y: auto; BORDER-LEFT: #f3f3cd 0pt solid; COLOR: black; BORDER-BOTTOM: #f3f3cd 0pt solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: transparent" TextMode=SingleLine ID="lblMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_month") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:TextBox width="70px" TextMode=SingleLine ID="txtMonth" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.prl_month") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid></TD>
		</TR>
		<TR>
			<TD><asp:label id="lblError" runat="server"></asp:label></TD>
		</TR>
		<TR>
			<TD><asp:button id="btnAddRow" runat="server" Text="Lägg till"></asp:button></TD>
		</TR>
	</TABLE>
</div>
