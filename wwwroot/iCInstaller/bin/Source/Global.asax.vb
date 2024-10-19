Imports System.Web
Imports System.Web.SessionState
Imports iConsulting
Imports iConsulting.iCMServer
Imports System.Security
Imports System.Security.Principal
Imports System.Web.Security

    Public Class Global : Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        Dim oSiteLog As New clsSiteLog
        If Not oSiteLog.LogUser Then

        End If
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
        'Dim Index As Integer = 0
        Dim PageId As Integer = 0

        ' Get Index from querystring
        'If Not (Request.Params("Index") Is Nothing) Then
        '    Index = CInt(Request.Params("Index"))
        'End If

        ' Get Page from querystring
        If Not (Request.Params("PageId") Is Nothing) Then
            PageId = CInt(Request.Params("PageId"))
        End If

        Context.Items.Add("SiteSettings", New clsSiteSettings(0, PageId))

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticat the use

        If Request.IsAuthenticated = True Then

            Dim roles() As String

            ' Create the roles cookie if it doesn't exist yet for this session.
            If Request.Cookies("siteroles") Is Nothing Then

                ' Get roles from UserRoles table, and add to cookie
                Dim _user As New clsUser

                ' Create a string to persist the roles
                Dim roleStr As String = ""

                roleStr = _user.GetRoles(User.Identity.Name)

                ' Create a cookie authentication ticket.
                '   version
                '   user name
                '   issue time
                '   expires every hour
                '   don't persist cookie
                '   roles
                Dim ticket As New FormsAuthenticationTicket(1, _
                    Context.User.Identity.Name, _
                    DateTime.Now.ToUniversalTime, _
                    DateTime.Now.AddHours(2).ToUniversalTime, _
                    False, _
                    roleStr)

                ' Encrypt the ticket
                Dim cookieStr As String = FormsAuthentication.Encrypt(ticket)

                ' Send the cookie to the client
                Response.Cookies("siteroles").Value = cookieStr
                Response.Cookies("siteroles").Path = "/"
                'Response.Cookies("siteroles").Expires = DateTime.Now.AddHours(1)
                Response.Cookies("siteroles").Expires = DateTime.Now.AddHours(2)

            Else

                ' Get roles from roles cookie
                Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(Context.Request.Cookies("siteroles").Value)

                'convert the string representation of the role data into a string array
                Dim userRoles As New ArrayList

                Dim role As String

                For Each role In ticket.UserData.Split(New Char() {";"c})
                    userRoles.Add(role)
                Next role

                roles = CType(userRoles.ToArray(GetType(String)), String())

            End If

            ' Add our own custom principal to the request containing the roles in the auth ticket
            Context.User = New GenericPrincipal(Context.User.Identity, roles)

        End If
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class