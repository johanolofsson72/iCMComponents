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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim LocalFileName As String = "Backup-On-City-" & Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString & ".zip"
        Dim RemoteFileName As String = System.Configuration.ConfigurationSettings.AppSettings.Get("RemoteFileName")
        Dim LocalFilePath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("LocalFilePath")
        Dim Ftp As New clsFTP
        Ftp.Hostname = System.Configuration.ConfigurationSettings.AppSettings.Get("Hostname")
        Ftp.Username = System.Configuration.ConfigurationSettings.AppSettings.Get("Username")
        Ftp.Password = System.Configuration.ConfigurationSettings.AppSettings.Get("Password")
        Ftp.GetFile("", RemoteFileName, LocalFilePath & LocalFileName)
        End
    End Sub
End Class
