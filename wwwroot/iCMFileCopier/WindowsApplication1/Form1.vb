Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Copy New Files To iCMServer"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(56, 48)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(168, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(56, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 23)
        Me.Label1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 101)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "iCMFileCopier"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Print("Ready...")
    End Sub

    Public Function CopyFile(ByVal FileName As String, ByVal SourcePath As String, ByVal DestPath As String) As Boolean
        Dim fso As New Scripting.FileSystemObjectClass
        Try
            fso.CopyFile(SourcePath & FileName, DestPath & FileName, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sAppPath As String = "C:\Development\iConsulting\iCM2004\"
        Dim sSModPath As String = sAppPath & "iCMServer\Server\Modules\"
        Dim sDModPath As String = sAppPath & "iCMServer\Desktop\Modules\"
        Dim sBinPath As String = sAppPath & "iCMServer\bin\"
        ProgressBar1.Maximum = 80
        Call Print("Copying...")

        ' iCMServer.Modules.Language
        If Not CopyFile("Language.ascx", sAppPath & "iCMServer.Modules.Language\", sSModPath & "Language\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Language.dll", sAppPath & "iCMServer.Modules.Language\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.Menu
        If Not CopyFile("Menu.ascx", sAppPath & "iCMServer.Modules.Menu\", sSModPath & "Menu\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Menu.dll", sAppPath & "iCMServer.Modules.Menu\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.Modules
        If Not CopyFile("Modules.ascx", sAppPath & "iCMServer.Modules.Modules\", sSModPath & "Modules\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Modules.dll", sAppPath & "iCMServer.Modules.Modules\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.Pages
        If Not CopyFile("Pages.ascx", sAppPath & "iCMServer.Modules.Pages\", sSModPath & "Pages\") Then Err.Raise(1)
        If Not CopyFile("PagesEdit.aspx", sAppPath & "iCMServer.Modules.Pages\", sSModPath & "Pages\") Then Err.Raise(1)
        If Not CopyFile("PagesEngine.aspx", sAppPath & "iCMServer.Modules.Pages\", sSModPath & "Pages\") Then Err.Raise(1)
        If Not CopyFile("TreeViewXml.aspx", sAppPath & "iCMServer.Modules.Pages\", sSModPath & "Pages\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Pages.dll", sAppPath & "iCMServer.Modules.Pages\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.Roles
        If Not CopyFile("Roles.ascx", sAppPath & "iCMServer.Modules.Roles\", sSModPath & "Roles\") Then Err.Raise(1)
        If Not CopyFile("RolesUsers.aspx", sAppPath & "iCMServer.Modules.Roles\", sSModPath & "Roles\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Roles.dll", sAppPath & "iCMServer.Modules.Roles\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.SignIn
        If Not CopyFile("SignIn.ascx", sAppPath & "iCMServer.Modules.SignIn\", sSModPath & "SignIn\") Then Err.Raise(1)
        If Not CopyFile("SignOut.aspx", sAppPath & "iCMServer.Modules.SignIn\", sSModPath & "SignIn\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.SignIn.dll", sAppPath & "iCMServer.Modules.SignIn\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.Sites
        If Not CopyFile("Sites.ascx", sAppPath & "iCMServer.Modules.Sites\", sSModPath & "Sites\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Sites.dll", sAppPath & "iCMServer.Modules.Sites\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        ' iCMServer.Modules.Users
        If Not CopyFile("Users.ascx", sAppPath & "iCMServer.Modules.Users\", sSModPath & "Users\") Then Err.Raise(1)
        If Not CopyFile("UsersRoles.aspx", sAppPath & "iCMServer.Modules.Users\", sSModPath & "Users\") Then Err.Raise(1)
        If Not CopyFile("iConsulting.iCMServer.Modules.Users.dll", sAppPath & "iCMServer.Modules.Users\bin\", sBinPath) Then Err.Raise(1)
        ProgressBar1.PerformStep()

        Call Print("Ready...")
        ProgressBar1.Value = 0
    End Sub

    Private Sub Print(ByVal Text As String)
        Label1.Text = Text
        Label1.Update()
        Me.Update()
    End Sub
End Class
