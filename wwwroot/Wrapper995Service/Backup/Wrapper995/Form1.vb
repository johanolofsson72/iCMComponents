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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(440, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(448, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Browse"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(368, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Convert"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(208, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(152, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(304, 23)
        Me.Label2.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(416, 40)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Execute Service"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(224, 224)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "From URL to"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(8, 224)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(208, 20)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "http://www.iconsulting.se"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(320, 224)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(216, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Text = "c:\temp\iconsulting.pdf"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 266)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents m_cBFF As New cDHBrowseForFolder

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim eBT As cDHBrowseForFolder.BROWSE_TYPE = cDHBrowseForFolder.BROWSE_TYPE.BrowseForEverything
        Dim eFT As cDHBrowseForFolder.FOLDER_TYPE = cDHBrowseForFolder.FOLDER_TYPE.CSIDL_DESKTOP
        With m_cBFF
            .StartDir = "C:\_workfolder\testfiler\"
            .UseNewUI = False
            .EditBox = False
            TextBox1.Text = .BrowseForFolder(Me.Handle.ToInt32, "Select media file:", eBT, eFT)
        End With
    End Sub

    Private Sub ExecuteProcess(ByVal Workfile As String)
        Try
            Dim proc As New System.Diagnostics.Process
            Dim info As New System.Diagnostics.ProcessStartInfo
            info.FileName = "c:\omniformat\omniformat.exe"
            info.Arguments = Workfile
            proc.Start(info)
            Label1.BackColor = System.Drawing.Color.Yellow
            Me.Refresh()
            proc.WaitForExit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SetStatus(System.Drawing.Color.Green, "Begin to process folder: " & TextBox1.Text)
        Dim myDir As New System.IO.DirectoryInfo(TextBox1.Text)
        For Each myFile As System.IO.FileInfo In myDir.GetFiles
            Dim obj As New Wrapper995Service.Wrapper
            obj.ConvertToPDF(myFile.FullName)
            'DoStuff(myFile.FullName)
        Next
        SetStatus(System.Drawing.Color.Green, "Done process folder: " & TextBox1.Text)
    End Sub

    Private Sub SetStatus(ByVal Mark As System.Drawing.Color, ByVal Text As String)
        Label2.Text = Text
        Label1.BackColor = Mark
        Me.Refresh()
        Label2.Refresh()
        Label1.Refresh()
    End Sub

    Private Sub DoStuff(ByVal Workfile As String)
        Try
            SetStatus(System.Drawing.Color.Red, "Processing: " & Workfile)
            ExecuteProcess(Workfile)
            SetStatus(System.Drawing.Color.GreenYellow, "Wait for: " & Workfile)
            Me.Refresh()
            Dim done As Boolean
            Do Until done
                System.Threading.Thread.CurrentThread.Sleep(100)
                Dim myFile As New System.IO.FileInfo(Workfile.Substring(0, Workfile.Length - 4) & ".pdf")
                done = myFile.Exists
            Loop
            SetStatus(System.Drawing.Color.Green, "Finished: " & Workfile)
        Catch ex As Exception
            SetStatus(System.Drawing.Color.Red, "Error converting: " & Workfile)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.BackColor = System.Drawing.Color.Green
        Me.Refresh()
        'Dim obj As New Wrapper995Service.Wrapper
        'obj.CreatePdfFromURL("http://www.iconsulting.se", "c:\temp\iconsulting.pdf")
        'End
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SetStatus(System.Drawing.Color.Red, "Processing: " & TextBox1.Text)
        Dim obj As New Wrapper995Service.Wrapper
        SetStatus(System.Drawing.Color.Green, "Processing: " & obj.ConvertToPDF(TextBox1.Text))
        'SetStatus(System.Drawing.Color.Green, "Processing: " & obj.ConvertToPDF(TextBox1.Text, "C:\_Workfolder"))
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim obj As New Wrapper995Service.Wrapper
        obj.CreatePdfFromURL(TextBox2.Text, TextBox3.Text, True)
        'Try
        '    Dim proc As New System.Diagnostics.Process
        '    Dim info As New System.Diagnostics.ProcessStartInfo
        '    info.FileName = "c:\omniformat\html2pdf995.exe"
        '    info.Arguments = """" & TextBox2.Text & """ """ & TextBox3.Text & """"
        '    proc.Start(info)
        '    If Not proc.HasExited Then
        '        proc.WaitForExit()
        '        proc.Close()
        '    End If
        '    Me.Refresh()
        'Catch ex As Exception

        'End Try
    End Sub
End Class
