<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Discussion.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Discussion.Discussion" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/Discussion/DiscussionNew.aspx"
	Phrase="discussion_new" Location="iConsulting.iCMServer.Modules.Discussion" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
	<asp:DataList id="TopLevelList" width="98%" ItemStyle-Cssclass="Normal" DataKeyField="dis_id"
		runat="server">
		<ItemTemplate>
			<asp:ImageButton id="btnSelect" ImageUrl='<%# NodeImage(Cint(DataBinder.Eval(Container.DataItem, "dis_childcount"))) %>' CommandName="select" runat="server" />
			<a class="SubSubHead" style="cursor:hand;text-decoration:underline" onclick='<%# FormatUrl(CInt(DataBinder.Eval(Container.DataItem, "dis_id"))) %>'>
				<%# DataBinder.Eval(Container.DataItem, "dis_title") %>
			</a>&nbsp;&nbsp;<%=Posted%>:&nbsp;
			<%# DataBinder.Eval(Container.DataItem,"dis_createddate", "{0:g}") %>
			&nbsp;<%=By%>:&nbsp;
			<%# DataBinder.Eval(Container.DataItem,"dis_createdby") %>
		</ItemTemplate>
		<SelectedItemTemplate>
			<asp:ImageButton id="btnCollapse" ImageUrl="Images/minus.gif" runat="server" CommandName="collapse" />
			<a class="SubSubHead" style="cursor:hand;text-decoration:underline" onclick='<%# FormatUrl(CInt(DataBinder.Eval(Container.DataItem, "dis_id"))) %>'>
				<%# DataBinder.Eval(Container.DataItem, "dis_title") %>
			</a>&nbsp;&nbsp;<%=Posted%>:&nbsp;
			<%# DataBinder.Eval(Container.DataItem,"dis_createddate", "{0:g}") %>
			&nbsp;<%=By%>:&nbsp;
			<%# DataBinder.Eval(Container.DataItem,"dis_createdby") %>
			<asp:DataList id="DetailList" ItemStyle-Cssclass="Normal" datasource="<%# GetThreadMessages() %>" runat="server">
				<ItemTemplate>
					<%# DataBinder.Eval(Container.DataItem, "dis_indent") %>
					<img src="Desktop/Modules/Discussion/Images/1x1.gif" height="15"> <a class="SubSubHead" style="cursor:hand;text-decoration:underline" onclick='<%# FormatUrl(CInt(DataBinder.Eval(Container.DataItem, "dis_id"))) %>'>
						<%# DataBinder.Eval(Container.DataItem, "dis_title") %>
					</a>&nbsp;&nbsp;<%=Posted%>:&nbsp;
					<%# DataBinder.Eval(Container.DataItem,"dis_createddate", "{0:g}") %>
					&nbsp;<%=By%>:&nbsp;
					<%# DataBinder.Eval(Container.DataItem,"dis_createdby") %>
				</ItemTemplate>
			</asp:DataList>
		</SelectedItemTemplate>
	</asp:DataList>
</div>
<asp:Literal id="Literal1" runat="server" EnableViewState="true"></asp:Literal>
