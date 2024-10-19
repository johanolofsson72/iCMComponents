Public Class iCTerminal
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtTerminal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHolder As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblServer As System.Web.UI.WebControls.Label
    Protected WithEvents lblIsOnServer As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Input As String
    Private iCM As clsiCMServer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (Request.Params("Input") Is Nothing) Then
            Input = Request.Params("Input")
            Call HandleInput()
        Else
            Call InitDefaultText()
        End If
    End Sub

    Private Sub InitDefaultText()
        txtHolder.Text = "iConsulting  iCBusinessManager  iCTerminal" & vbCrLf & ">"
    End Sub

    Public Sub HandleInput()
        If Not InStr(Input, ">") = 0 Then
            Dim handleText = Right(Input, InStr(StrReverse(Input), ">") - 1)
            Input = Replace(Input, ">", vbCrLf & ">")
            Select Case Trim(Mid(LCase(handleText), 1, 2))
                Case "db"
                    ' Check the rest of the params....
                    If Not InStr(handleText, "-t") = 0 And Not InStr(handleText, "-a") = 0 And Not InStr(handleText, "-u") = 0 And Not InStr(handleText, "-p") = 0 Then
                        Dim sDB As String = Mid(handleText, 3, InStr(handleText, "-t") - 4)
                        Dim sType As String = Mid(handleText, InStr(handleText, "-t") + 2, (InStr(handleText, "-a") - InStr(handleText, "-t") + 2) - 5)
                        Dim sAlias As String = Mid(handleText, InStr(handleText, "-a") + 2, (InStr(handleText, "-u") - InStr(handleText, "-a") + 2) - 5)
                        Dim sDBusr As String = Mid(handleText, InStr(handleText, "-u") + 2, (InStr(handleText, "-p") - InStr(handleText, "-u") + 2) - 5)
                        Dim sDBpwd As String = Mid(handleText, InStr(handleText, "-p") + 2)
                        txtHolder.Text = Input & vbCrLf & ">Please type the application user and password. Use APP, -U and -P switches " & vbCrLf & ">"
                        Session("ConnectionString") = sDB & "," & sType & "," & sAlias & "," & sDBusr & "," & sDBpwd
                        Exit Sub
                    Else
                        txtHolder.Text = Input & vbCrLf & ">Error: Can´t connect to database. Try with -T, -A, -U and -P switches" & vbCrLf & ">"
                        Exit Sub
                    End If
                Case "ap"
                    If Not InStr(handleText, "-u") = 0 And Not InStr(handleText, "-p") = 0 Then
                        Dim sSusr As String = Mid(handleText, InStr(handleText, "-u") + 2, (InStr(handleText, "-p") - InStr(handleText, "-u") + 2) - 5)
                        Dim sSpwd As String = Mid(handleText, InStr(handleText, "-p") + 2)
                        Dim sCon() As String = Split(Session("ConnectionString"), ",")
                        Dim oiCM As New clsiCMServer
                        If oiCM.Logon(Session("Server"), sCon(0), sCon(1), sCon(2), sCon(3), sCon(4), sSusr, sSpwd) Then
                            txtHolder.Text = Input & vbCrLf & ">You are authorized." & vbCrLf & ">"
                            Exit Sub
                        Else
                            txtHolder.Text = Input & vbCrLf & ">You are not authorized !" & vbCrLf & ">"
                            Exit Sub
                        End If
                    Else
                        txtHolder.Text = Input & vbCrLf & ">Error: Can´t logon to database. Try with -U and -P switches" & vbCrLf & ">"
                        Exit Sub
                    End If


            End Select
            Select Case Trim(Mid(LCase(handleText), 1, 5))
                Case "help"
                    txtHolder.Text = GetHelp()
                Case "exit"
                    Response.Write("<script>this.close()</script>")
                Case "logon"
                    Dim i As Integer = InStr(handleText, "-S")
                    If Not i = 0 Then
                        Session("Server") = Mid(handleText, i + 2)
                        txtHolder.Text = Input & vbCrLf & ">You are now connected to: " & Session("Server") & vbCrLf & ">"
                        Session("IsOnServer") = "1"
                    Else
                        txtHolder.Text = Input & vbCrLf & ">Error: No server selected. Try with -S switch" & vbCrLf & ">"
                    End If
                Case "logou"
                    If Session("IsOnServer") = "1" Then
                        txtHolder.Text = Input & vbCrLf & ">You are now disconnected from the server" & vbCrLf & ">"
                        Session("IsOnServer") = ""
                        Session("Server") = ""
                    Else
                        txtHolder.Text = Input & vbCrLf & ">Error: You are not connected to a server" & vbCrLf & ">"
                    End If
                Case Else
                    txtHolder.Text = GetError(handleText)
            End Select
        End If
    End Sub

    Private Sub Logon()
        Dim oiCM As New clsiCMServer
        If oiCM.Logon("burton", "iCMServer", "MSSQLServer", "Default", "sa", "i75c72", "admin@default.se", "admin") Then
            txtHolder.Text = Input & vbCrLf & ">You are authorized." & vbCrLf & ">"
        Else
            txtHolder.Text = Input & vbCrLf & ">You are not authorized !" & vbCrLf & ">"
        End If
    End Sub

    Private Function GetError(ByVal command As String) As String
        Return Input & vbCrLf & ">´" & command & "´ is not a recognized as an internal command !!!" & vbCrLf & ">"
    End Function

    Private Function GetHelp() As String
        Return Input & vbCrLf & ">iConsulting iCBusinessManager iCTerminal Help section:" & vbCrLf & _
                    ">[help  Show the help section]" & vbTab & "[cSite  Create new site]" & vbCrLf & _
                    ">[logon  Logon to a server]" & vbTab & "[cPage  Create new page]" & vbCrLf & _
                    ">[-S  Server]" & vbTab & vbTab & "[cMod  Create new module]" & vbCrLf & _
                    ">[DB  Database]" & vbTab & vbTab & "[cUser  Create new user]" & vbCrLf & _
                    ">[-U  User]" & vbTab & vbTab & "[cRole  Create new role]" & vbCrLf & _
                    ">[-P  Password]" & vbTab & vbTab & "[oPass  Change password]" & vbCrLf & _
                    ">[-T  Type]" & vbTab & vbTab & "[-L  List Servers]" & vbCrLf & _
                    ">[exit  End terminal session]" & vbTab & "[-Q  Commandline SQL query]" & vbCrLf & _
                    ">[logout  Logout from server]" & vbTab & "[-A SiteAlias]" & vbCrLf & _
                    ">"
    End Function

    Private Sub txtTerminal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerminal.TextChanged

    End Sub
End Class
