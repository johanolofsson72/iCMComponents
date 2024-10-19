<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DocumentsEngine.aspx.vb" Inherits="iConsulting.iCMServer.Modules.Documents.DocumentsEngine"%>
<%
Response.Expires = -1000
Response.ContentType = "text/xml"
Response.Write(CreateXMLBasedOnXmlHttpRequest(Request("sID")))
%>