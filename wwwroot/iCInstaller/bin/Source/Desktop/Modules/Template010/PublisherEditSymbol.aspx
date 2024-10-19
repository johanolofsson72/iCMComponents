<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PublisherEditSymbol.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Template010.PublisherEditSymbol"%>
<%@ Register TagPrefix="iCMServerStyle" TagName="Title" Src="~/Server/Css/iCMServerStyle.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Symbol</title>
		<icmserverstyle:title id="iCMServerStyle1" ViewSource="Main" ViewType="Standard" runat="server"></icmserverstyle:title>
		<style type="text/css"><!--.ColorItems { cursor: hand}
	--> 
	</style>
		<script>
			function ReturnSelectedSymbol(){
				try{
					window.opener.InsertNewSymbol(SymbolSelector.value);
					window.close();
				}
				catch(e){
					this.close;
				}
				
			}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="5" topmargin="5" bgcolor="buttonface" style="OVERFLOW: hidden">
		<fieldset>
			<table border="0" align="center" id=Table1>
				<tr>
					<td>
						<select id='SymbolSelector' size="6" style="WIDTH: 94px; HEIGHT: 102px" onDblClick="ReturnSelectedSymbol();" name=SymbolSelector>
							<option value='à' selected>
							à
							<option value='á'>
							á
							<option value='â'>
							â
							<option value='ã'>
							ã
							<option value='ä'>
							ä
							<option value='å'>
							å
							<option value='æ'>
							æ
							<option value='À'>
							À
							<option value='Á'>
							Á
							<option value='Â'>
							Ã
							<option value='Ä'>
							Ä
							<option value='Å'>
							Å
							<option value='Æ'>
							Æ
							<option value='è'>
							è
							<option value='é'>
							é
							<option value='ê'>
							ê
							<option value='ë'>
							ë
							<option value='È'>
							È
							<option value='É'>
							É
							<option value='Ê'>
							Ê
							<option value='ì'>
							ì
							<option value='í'>
							í
							<option value='î'>
							î
							<option value='ï'>
							ï
							<option value='Ì'>
							Ì
							<option value='Í'>
							Í
							<option value='Î'>
							Î
							<option value='Ï'>
							Ï
							<option value='ò'>
							ò
							<option value='ó'>
							ó
							<option value='ô'>
							ô
							<option value='õ'>
							õ
							<option value='ö'>
							ö
							<option value='ø'>
							ø
							<option value='œ'>
							œ
							<option value='Ò'>
							Ò
							<option value='Ó'>
							Ó
							<option value='Ô'>
							Ô
							<option value='Õ'>
							Õ
							<option value='Ö'>
							Ö
							<option value='Ø'>
							Ø
							<option value='Œ'>
							Œ
							<option value='ù'>
							ù
							<option value='ú'>
							ú
							<option value='û'>
							û
							<option value='ü'>
							ü
							<option value='Ù'>
							Ù
							<option value='Ú'>
							Ú
							<option value='Û'>
							Û
							<option value='Ü'>
							Ü
							<option value='ÿ'>
							ÿ
							<option value='Ÿ'>
							Ÿ
							<option value='ç'>
							ç
							<option value='Ç'>
							Ç
							<option value='ß'>
							ß
							<option value='ñ'>
							ñ
							<option value='Ñ'>
							Ñ
							<option value='"'>
							"
							<option value='“'>
							“
							<option value='”'>
							”
							<option value='«'>
							«
							<option value='»'>
							»
							<option value='#'>
							#
							<option value='&amp;'>
							&amp;
							<option value='<'>
							&lt;
							<option value='>'>
							&gt;
							<option value='¬'>
							¬
							<option value='±'>
							±
							<option value='÷'>
							÷
							<option value='µ'>
							µ
							<option value='¼'>
							¼
							<option value='½'>
							½
							<option value='¾'>
							&amp;#;
							<option value='¯'>
							¯<option value="" 
        DESIGNTIMESP=
4999							% 19891? DESIGNTIMESP="4735">
							%
							<option value='‰'>
							‰
							<option value='¢'>
							¢<option value="" 
        DESIGNTIMESP=
5002							$ DESIGNTIMESP="4738" 19894?>
							$
							<option value='£'>
							£
							<option value='¥'>
							¥
							<option value='™'>
							™
							<option value='©'>
							©
							<option value='®'>
							®<option value="" 
        DESIGNTIMESP=
5008							@ DESIGNTIMESP="4744" 19900?>
							@
							<option value='…'>
							…
							<option value='¡'>
							¡
							<option value='¿'>
							¿
							<option value='¦'>
							¦
							<option value='·'>
							·
							<option value='•'>
							•
							<option value='º'>
							º
							<option value='§'>
							§
							<option value='¶'>
							¶
							<option value='ª'>
							ª
							<option value='¹'>
							¹
							<option value='²'>
							²
							<option value='³'>
							³
							<option value='&shy;'>
							&shy;
							<option value='&nbsp;'>
							nbsp</option>
						</select>
				<tr>
					<td colspan="2">
						<button type="button" class="iCWebControlsII" onclick='ReturnSelectedSymbol();' style="WIDTH: 47px" onFocus="this.blur()" ID="Button1" title="<%=Save%>" value="<%=Save%>"><%=Save%></button>
						<button type="button" class="iCWebControlsII" onclick='window.close();' style="WIDTH: 47px" onFocus="this.blur()" ID="Button2" title="<%=Cancel%>" value="<%=Cancel%>"><%=Cancel%></button> 
</FORM></td></tr>
			</table>
		</fieldset>
	</body>
</HTML>
