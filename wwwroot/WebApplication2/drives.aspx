<%@ Page Language="vb" CodeBehind="drives.aspx.vb" AutoEventWireup="false" Inherits="WebApplication2.drives" %>
<%@Import namespace="System.IO"%>
<html>
<head><title>Exploring Files and Folders with ASP.NET</title>
<style>
a.entry {
  font-family: "MS Sans Serif";
  font-size: 8pt;
  color: "black";
  text-decoration: none;
}
</style>
</head>
<body>
<%
  string[] arrDrives = Directory.GetLogicalDrives();
  for (int i=0; i<=arrDrives.Length-1; i++) {
	Response.Write("<img src='images/drive.gif'><a href='browse.aspx?d="+arrDrives[i]+"' class='entry'>"+arrDrives[i]+"</a><br>");
  }
%>
</body>
</html>