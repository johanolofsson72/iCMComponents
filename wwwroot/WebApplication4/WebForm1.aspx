<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="WebApplication4.WebForm1"%>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<script>
      function Set(id){
	    var x = window.document.getElementById(id)
	    x.src="w.gif";
      }
		</script>
	</HEAD>
	<body leftmargin="50" topmargin="50">
		Testis<br>
		<img id="etta" src="" border="0" width="140" height="13"><br>
		<img id="tva" src="" border="0" width="140" height="13"><br>
		<img id="trea" src="" border="0" width="140" height="13"><br>
		<script>
	window.setTimeout("Set('etta');",500);
	window.setTimeout("Set('tva');",1000);
	window.setTimeout("Set('trea');",1500);
		</script>
		<iewc:TreeView id="TreeView1" runat="server">
			<iewc:TreeNode Text="Node0"></iewc:TreeNode>
			<iewc:TreeNode Text="Node1"></iewc:TreeNode>
			<iewc:TreeNode Text="Node2"></iewc:TreeNode>
			<iewc:TreeNode Text="Node3"></iewc:TreeNode>
			<iewc:TreeNode Text="Node4"></iewc:TreeNode>
			<iewc:TreeNode Text="Node5"></iewc:TreeNode>
			<iewc:TreeNode Text="Node6"></iewc:TreeNode>
			<iewc:TreeNode Text="Node7"></iewc:TreeNode>
			<iewc:TreeNode Text="Node8"></iewc:TreeNode>
			<iewc:TreeNode Text="Node9"></iewc:TreeNode>
			<iewc:TreeNode Text="Node10"></iewc:TreeNode>
		</iewc:TreeView>
	</body>
</HTML>
