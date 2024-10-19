<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="MailTest.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtTo" style="Z-INDEX: 100; LEFT: 312px; POSITION: absolute; TOP: 136px" runat="server"
				Width="296px">jool@iconsulting.se</asp:TextBox>
			<asp:Label id="Label5" style="Z-INDEX: 110; LEFT: 272px; POSITION: absolute; TOP: 72px" runat="server">Smtp:</asp:Label>
			<asp:TextBox id="txtText" style="Z-INDEX: 101; LEFT: 312px; POSITION: absolute; TOP: 168px" runat="server"
				Width="296px" Height="104px" TextMode="MultiLine">Test</asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 272px; POSITION: absolute; TOP: 136px" runat="server">Till:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 272px; POSITION: absolute; TOP: 168px" runat="server">Text:</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 272px; POSITION: absolute; TOP: 104px" runat="server">Från:</asp:Label>
			<asp:TextBox id="txtFrom" style="Z-INDEX: 106; LEFT: 312px; POSITION: absolute; TOP: 104px" runat="server"
				Width="296px">info@iconsulting.se</asp:TextBox>
			<asp:Button id="Button1" style="Z-INDEX: 107; LEFT: 552px; POSITION: absolute; TOP: 288px" runat="server"
				Text="Skicka"></asp:Button>
			<asp:Label id="Label4" style="Z-INDEX: 108; LEFT: 616px; POSITION: absolute; TOP: 112px" runat="server"
				Width="432px" Height="160px">Label</asp:Label>
			<asp:TextBox id="txtSmtp" style="Z-INDEX: 109; LEFT: 312px; POSITION: absolute; TOP: 72px" runat="server"
				Width="296px">burton</asp:TextBox>
		</form>
	</body>
</HTML>
