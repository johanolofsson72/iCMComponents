<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PagesEngine.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Pages.PagesEngine" %>
<%
Response.Expires = -1000
Response.ContentType = "text/xml"
Response.Write(CreateXMLBasedOnXmlHttpRequest(Request("sID")))
%>
