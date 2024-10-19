<%@ Register TagPrefix="cc1" Namespace="iCUpload" Assembly="iCUpload" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="Tester.WebForm1" codePage="28605" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-15">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" ENCTYPE="multipart/form-data" runat="server">
			&nbsp;
			<cc1:iCUpload id="ICUpload1" runat="server" UploadCss="cUpload" ListCss="cList" HeaderCss="cHeader"
				ButtonCss="cButton" ProgressBarImageUrl="ProgressBar.gif" ProgressBarWidth="200" ProgressBarHeight="22"
				SaveState="1" HeaderText="Laste op filer..." ButtonImage="Upload1.gif" ButtonImageLoad="Upload2.gif"
				StateString="c:\_workfolder\"></cc1:iCUpload>
			<cc1:iCUpload id="ICUpload2" runat="server" ButtonImageLoad="Upload2.gif" ButtonImage="Upload1.gif"
				HeaderText="lite filer till" StateString="Uploads" SaveState="1" ProgressBarHeight="5" ProgressBarWidth="100"
				ProgressBarImageUrl="ProgressBar.gif"></cc1:iCUpload></form>
	</body>
</HTML>
