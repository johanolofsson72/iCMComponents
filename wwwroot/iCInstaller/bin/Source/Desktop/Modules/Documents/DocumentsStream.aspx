<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocumentsStream.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Documents.DocumentsStream" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="Javascript">
			function A()
			{
				if ((document.all) && (event.ctrlKey)) 
				{
					alert("Not supported ...");
				}
			}
		</script>
		<script language='javascript'>
			function right(e)
			{
				if (navigator.appName == 'Netscape' && (e.which == 3 || e.which == 2))
				{
					return false;
				}
				else if (navigator.appName == 'Microsoft Internet Explorer' && (event.button == 2 || event.button == 3))
				{
					alert("For security resons, the right click feature has been disabled.");
					return false;
				}
				return true;
			}
			document.onmousedown=right;
			if (document.layers) 
			{
				window.captureEvents(Event.MOUSEDOWN);
			}
			window.onmousedown=right;
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onkeydown="A()" onkeypress="A()" onkeyup="A()">
		<form id="Form1" method="post" runat="server">
			<iframe id="IF1" runat="server"></iframe>
		</form>
	</body>
</HTML>
