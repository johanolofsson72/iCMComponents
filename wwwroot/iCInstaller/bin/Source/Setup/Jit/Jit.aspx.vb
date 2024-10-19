Imports System.IO
Imports System.Net
Imports System
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Jit
    Inherits System.Web.UI.Page
    Protected WithEvents btnStartPage As System.Web.UI.WebControls.LinkButton
    Protected ErrorMessage As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call PreJitModules()
    End Sub

    Private Sub PreJitModules()
        Dim obj As Object

        Try
            Dim SourceURL As String = Left(Request.RawUrl, Len(Request.RawUrl) - 18)

            ' Discussion
            If Not HttpTrigger(SourceURL & "Desktop/Modules/Discussion/DiscussionDetails.aspx") Then
                ErrorMessage += ""
            End If

            ' Documents
            If Not HttpTrigger(SourceURL & "Desktop/Modules/Documents/DocumentsEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' Events
            If Not HttpTrigger(SourceURL & "Desktop/Modules/Events/EventsEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' iFrame
            If Not HttpTrigger(SourceURL & "Desktop/Modules/iFrame/iFrameEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' Mediagalley
            If Not HttpTrigger(SourceURL & "Desktop/Modules/Mediagallery/MediagalleryEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' Pages
            If Not HttpTrigger(SourceURL & "Server/Modules/Pages/EditModulePages.aspx") Then
                ErrorMessage += ""
            End If

            ' Publisher
            If Not HttpTrigger(SourceURL & "Desktop/Modules/Publisher/PublisherEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' Quicklinks
            If Not HttpTrigger(SourceURL & "Desktop/Modules/Quicklinks/QuicklinksEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' Roles
            If Not HttpTrigger(SourceURL & "Server/Modules/Roles/RolesEdit.aspx") Then
                ErrorMessage += ""
            End If

            ' SignIn
            If Not HttpTrigger(SourceURL & "Server/Modules/SignIn/SignOut.aspx") Then
                ErrorMessage += ""
            End If

            ' Sites
            If Not HttpTrigger(SourceURL & "Server/Modules/Sites/EditSitesStream.aspx") Then
                ErrorMessage += ""
            End If

            ' Users
            If Not HttpTrigger(SourceURL & "Server/Modules/Users/UsersEdit.aspx") Then
                ErrorMessage += ""
            End If

        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try


        obj = Nothing

    End Sub

    Public Function HttpTrigger(ByVal Url As String) As Boolean
        Dim URLReq As HttpWebRequest
        Dim URLRes As HttpWebResponse
        Try
            URLReq = WebRequest.Create(Url)
            URLRes = URLReq.GetResponse()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnStartPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartPage.Click
        Response.Redirect("~/icm.aspx")
    End Sub
End Class
