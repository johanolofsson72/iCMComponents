<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Quicklinks.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Quicklinks.Quicklinks" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/Quicklinks/QuicklinksEdit.aspx"
	Phrase="quicklinks_edit" Location="iConsulting.iCMServer.Modules.Quicklinks" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
<asp:DataList id="myDataList" CellPadding="4" Width="100%" EnableViewState="false" runat="server">
	<ItemTemplate>
		<TABLE>
			<TR>
				<TD>
					<asp:HyperLink id="editLink" CssClass="SubHead" runat="server" ImageUrl="<%# linkImage %>" NavigateUrl='<%# "~/Desktop/Modules/Quicklinks/QuicklinksEdit.aspx?QuiId=" &amp; DataBinder.Eval(Container.DataItem,"qui_id") &amp; "&amp;ModId=" &amp; ModuleId &amp; "&amp;PageId=" &amp; PagId %>'>HyperLink</asp:HyperLink></TD>
				<TD Class="SubSubHead">
					<a href="<%# GetUrl(DataBinder.Eval(Container.DataItem,"qui_url")) %>" target="<%# GetTarget(DataBinder.Eval(Container.DataItem,"qui_url")) %>"><%# DataBinder.Eval(Container.DataItem,"qui_title") %></a></TD>
				<TD>
					<asp:Label id="editUrl" Visible="false" runat="server"><%# DataBinder.Eval(Container.DataItem,"qui_url") %></asp:Label></TD>
			</TR>
		</TABLE>
	</ItemTemplate>
</asp:DataList>
</div>