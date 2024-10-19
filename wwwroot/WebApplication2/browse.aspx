<%@ Page Language="vb" EnableViewState="false" CodeBehind="browse.aspx.vb" AutoEventWireup="false" Inherits="WebApplication2.browse" %>
<%@Import namespace="System.IO"%>
<script runat="server">
public void Page_Load(object s, System.EventArgs ea) {
	try {
		string strDir = Request.QueryString["d"];
		string strParent = strDir.Substring(0,strDir.LastIndexOf("\\"));
		strParent += strParent.EndsWith(":") ? "\\" : "";
		upLink.NavigateUrl = "browse.aspx?d="+strParent;
		txtCurrentDir.Text = "Address: <b>"+strDir + "</b>";
		DirectoryInfo DirInfo = new DirectoryInfo(strDir);
		DirectoryInfo[] subDirs = DirInfo.GetDirectories();		
		FileInfo[] Files = DirInfo.GetFiles();
		txtListing.Text = "<table>";
		for (int i=0; i<=subDirs.Length-1; i++) {
			txtListing.Text += "<tr><td><img src='images/folder.gif'><a href='browse.aspx?d="+subDirs[i].FullName+"' class='entry'>"+subDirs[i].Name+"</a></td><td valign='bottom'>"+subDirs[i].LastWriteTime+"</td></tr>";
		}
		for (int i=0; i<=Files.Length-1; i++) {
			txtListing.Text += "<tr><td><img src='images/file.gif'>"+Files[i].Name+"</td><td valign='bottom'>"+Files[i].LastWriteTime+"</td></tr>";
		}
		txtListing.Text += "</table>";

	}
	catch (Exception e){
		txtListing.Text = "Error retrieving directory info: "+e.Message;
	}
}
</script>
<html>
<head><title>Exploring Files and Folders with ASP.NET</title>
<style>
td {
  font-family: "MS Sans Serif";
  font-size: 8pt;
}
a.entry {
  font-family: "MS Sans Serif";
  font-size: 8pt;
  color: "black";
  text-decoration: none;
}
a.entry:hover {
  text-decoration: underline;
}
</style>
</head>
<body>
<form runat="server">
<asp:HyperLink id="upLink" runat="server" ImageUrl="images/up.gif"/>
<br/>
<asp:Label id="txtCurrentDir" Font-Name="MS Sans Serif" Font-Size="8pt" runat="server"/>
<br><br>
<asp:Label id="txtListing" Font-Name="MS Sans Serif" Font-Size="8pt" runat="server"/>
</form>
</body>
</html>