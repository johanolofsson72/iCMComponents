<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PublisherEditTable.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Publisher.PublisherEditTable"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tabel</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
			<script>
		function ReturnTableContent(){
			try{
				window.opener.CreateTableSolution(document.getElementById('thisTableNumberOfRows').value,document.getElementById('thisTableNumberOfCols').value,document.getElementById('thisTableBorderColor').value,document.getElementById('thisTableBorderWidth').value,document.getElementById('thisTableForeColor').value,document.getElementById('thisTablePadding').value,document.getElementById('thisTableSpacing').value,document.getElementById('thisTableAlign').value,document.getElementById('thisTableWidth').value)
				window.close();
			}
			catch(e){
				//alert("Tabell: "+e);
				this.close();
			}
		}
			</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout" bgcolor="#d3d3d3">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="2" align="left" valign="middle"
				ID="Table1">
				<tr>
					<td align="left" valign="middle" width="70%" class="SubSubHead">
						<font size="-1"><%=Width%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="4" style="BACKGROUND-COLOR:white" id="thisTableWidth" size="10" NAME="thisTableWidth">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=Border%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="4" style="BACKGROUND-COLOR:white" id="thisTableBorderWidth" size="10"
							NAME="thisTableBorderWidth">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=Rows%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="4" style="BACKGROUND-COLOR:white" id="thisTableNumberOfRows" size="10"
							NAME="thisTableNumberOfRows">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=Columns%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="4" style="BACKGROUND-COLOR:white" id="thisTableNumberOfCols" size="10"
							NAME="thisTableNumberOfCols">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=CellPadding%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="4" style="BACKGROUND-COLOR:white" id="thisTablePadding" size="10" NAME="thisTablePadding">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=CellSpacing%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="4" style="BACKGROUND-COLOR:white" id="thisTableSpacing" size="10" NAME="thisTableSpacing">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=BGColor%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="20" style="BACKGROUND-COLOR:white" id="thisTableForeColor" size="10"
							NAME="thisTableForeColor">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=Align%></font>
					</td>
					<td align="left" valign="middle">
						<select id="thisTableAlign" NAME="thisTableAlign">
							<option selected style="BACKGROUND-COLOR:white" value="left"><%=Left%></option>
							<option style="BACKGROUND-COLOR:white" value="center"><%=Center%></option>
							<option style="BACKGROUND-COLOR:white" value="right"><%=Right%></option>
						</select>
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle" class="SubSubHead">
						<font size="-1"><%=BorderColor%></font>
					</td>
					<td align="left" valign="middle">
						<input maxlength="20" style="BACKGROUND-COLOR:white" id="thisTableBorderColor" size="10"
							NAME="thisTableBorderColor">
					</td>
				</tr>
				<tr>
					<td align="left" valign="middle"></td>
					<td align="center" valign="middle">
						&nbsp;&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center" valign="middle">
						<input type="button" class="iCWebControlsII" name="x" value="<%=Save%>" onclick='ReturnTableContent();'
							style="" onFocus="this.blur()" ID="Button1"> 
							<input type="button" class="iCWebControlsII" value="<%=Cancel%>" onclick='window.close();' style=""
							onFocus="this.blur()" ID="Button2" NAME="Button2">
					</td>
					<td align="center" valign="middle"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
