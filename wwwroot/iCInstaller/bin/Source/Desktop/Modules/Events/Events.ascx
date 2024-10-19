<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Events.ascx.vb" Inherits="iConsulting.iCMServer.Modules.Events.Events" TargetSchema="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" %>
<%@ Register TagPrefix="Site" TagName="Title" Src="~/Desktop/Controls/DesktopModuleTitle.ascx"%>
<SITE:TITLE id="Title2" runat="server" EditUrl="~/Desktop/Modules/Events/EventsEdit.aspx" Phrase="events_edit"
	Location="iConsulting.iCMServer.Modules.Events" EditText=""></SITE:TITLE>
<div id="Minimizer" runat="server">
	<asp:datalist id="myDataList" runat="server" EnableViewState="false" Width="98%" CellPadding="4">
		<ItemTemplate>
			<TABLE border="0">
				<TR>
					<TD align="left" colSpan="2">
						<asp:HyperLink id=editLink runat="server" ImageUrl="Images/edit.gif" NavigateUrl='<%# "~/Desktop/Modules/Events/EventsEdit.aspx?EveId=" &amp; DataBinder.Eval(Container.DataItem,"eve_id") &amp; "&amp;ModId=" &amp; ModuleId &amp; "&amp;PageId=" &amp; PagId %>' Visible="<%# IsEditable %>">
						</asp:HyperLink></TD>
					<TD align="left" width="100%"><SPAN class="SubHead" align="left"><%# DataBinder.Eval(Container.DataItem,"eve_title") %>
							<asp:Label id=ShowDate runat="server" Visible='<%# DataBinder.Eval(Container.DataItem,"eve_hidedate") < Now %>' ForeColor="#ff0066" CssClass="SubSubHead">c1</asp:Label>
							<asp:Label id=HideDate runat="server" Visible='<%# DataBinder.Eval(Container.DataItem,"eve_showdate") > Now %>' ForeColor="#009966" CssClass="SubSubHead">u1</asp:Label>
						</SPAN></TD>
				</TR>
				<TR>
					<TD align="left" width="1"></TD>
					<TD align="left" width="1"></TD>
					<TD colSpan="2"><SPAN class="SubSubHead"><%# DataBinder.Eval(Container.DataItem,"eve_description") %></SPAN></TD>
				</TR>
				<TR>
					<TD align="left" width="1"></TD>
					<TD align="left" width="1"></TD>
					<TD colSpan="2">
						<asp:HyperLink id=moreLink runat="server" NavigateUrl='<%# GetUrl(DataBinder.Eval(Container.DataItem,"eve_link")) %>' Enabled='<%# Len(DataBinder.Eval(Container.DataItem,"eve_link")) > 0%>' Visible='<%# CType(Len(DataBinder.Eval(Container.DataItem,"eve_link")) > 7,Boolean)%>' CssClass="SubSubHead" Target='<%# GetTarget(DataBinder.Eval(Container.DataItem,"eve_link")) %>'>aaaa</asp:HyperLink></TD>
				</TR>
			</TABLE>
		</ItemTemplate>
	</asp:datalist>
</div>
