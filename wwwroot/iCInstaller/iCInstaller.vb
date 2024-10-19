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
    Friend WithEvents btnInstall As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents chkOver As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbExe As System.Windows.Forms.RadioButton
    Friend WithEvents rbWeb As System.Windows.Forms.RadioButton
    Friend WithEvents rbMySQL As System.Windows.Forms.RadioButton
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMsSQL As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnInstall = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.lblNote = New System.Windows.Forms.Label
        Me.chkOver = New System.Windows.Forms.CheckBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbExe = New System.Windows.Forms.RadioButton
        Me.rbWeb = New System.Windows.Forms.RadioButton
        Me.rbMySQL = New System.Windows.Forms.RadioButton
        Me.rbNone = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.rbMsSQL = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInstall
        '
        Me.btnInstall.Location = New System.Drawing.Point(176, 16)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(152, 48)
        Me.btnInstall.TabIndex = 0
        Me.btnInstall.Text = "Installera"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(16, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(72, 21)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Text = "ComboBox1"
        '
        'lblNote
        '
        Me.lblNote.Location = New System.Drawing.Point(24, 496)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(336, 32)
        Me.lblNote.TabIndex = 3
        Me.lblNote.Text = "Label2"
        '
        'chkOver
        '
        Me.chkOver.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkOver.Location = New System.Drawing.Point(16, 40)
        Me.chkOver.Name = "chkOver"
        Me.chkOver.Size = New System.Drawing.Size(72, 24)
        Me.chkOver.TabIndex = 4
        Me.chkOver.Text = "Ja"
        Me.chkOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(16, 24)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(208, 20)
        Me.txtPath.TabIndex = 5
        Me.txtPath.Text = "c:\"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(224, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 20)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Browse"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Skriv över tidigare:"
        '
        'rbExe
        '
        Me.rbExe.Checked = True
        Me.rbExe.Location = New System.Drawing.Point(24, 24)
        Me.rbExe.Name = "rbExe"
        Me.rbExe.Size = New System.Drawing.Size(128, 24)
        Me.rbExe.TabIndex = 9
        Me.rbExe.TabStop = True
        Me.rbExe.Text = "Windows applikation"
        '
        'rbWeb
        '
        Me.rbWeb.Location = New System.Drawing.Point(24, 48)
        Me.rbWeb.Name = "rbWeb"
        Me.rbWeb.TabIndex = 10
        Me.rbWeb.Text = "Web applikation"
        '
        'rbMySQL
        '
        Me.rbMySQL.Location = New System.Drawing.Point(16, 48)
        Me.rbMySQL.Name = "rbMySQL"
        Me.rbMySQL.TabIndex = 11
        Me.rbMySQL.Text = "MySQL"
        '
        'rbNone
        '
        Me.rbNone.Checked = True
        Me.rbNone.Location = New System.Drawing.Point(16, 24)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.TabIndex = 12
        Me.rbNone.TabStop = True
        Me.rbNone.Text = "Ingen"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbExe)
        Me.GroupBox1.Controls.Add(Me.rbWeb)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 80)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Installationssätt:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.rbMsSQL)
        Me.GroupBox2.Controls.Add(Me.rbNone)
        Me.GroupBox2.Controls.Add(Me.rbMySQL)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 152)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Databas:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Datafils katalog:"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(224, 120)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(56, 20)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Browse"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(16, 120)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(208, 20)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Text = "c:\"
        '
        'rbMsSQL
        '
        Me.rbMsSQL.Enabled = False
        Me.rbMsSQL.Location = New System.Drawing.Point(16, 72)
        Me.rbMsSQL.Name = "rbMsSQL"
        Me.rbMsSQL.TabIndex = 13
        Me.rbMsSQL.Text = "MsSQL"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(200, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 56)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Web applikations nummer:"
        Me.GroupBox3.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtPath)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Location = New System.Drawing.Point(24, 336)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(336, 56)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Destnations katalog för programfiler:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkOver)
        Me.GroupBox5.Controls.Add(Me.btnInstall)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Location = New System.Drawing.Point(24, 408)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(336, 80)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(16, 16)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(304, 20)
        Me.txtTitle.TabIndex = 19
        Me.txtTitle.Text = "TextBox2"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtTitle)
        Me.GroupBox6.Location = New System.Drawing.Point(24, 8)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(336, 48)
        Me.GroupBox6.TabIndex = 20
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Program titel (används även som virtuellt katalognamn) :"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(384, 550)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblNote)
        Me.Name = "Form1"
        Me.Text = "iCInstaller"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents m_cBFF As New cDHBrowseForFolder
    Private SiteNumber As Integer = 1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Init()
    End Sub

    Private Sub Init()
        Try
            lblNote.Text = "Välj destinationskatalog och webbsite id"
            ComboBox1.Items.Clear()
            For i As Integer = 1 To 1000
                ComboBox1.Items.Add(i.ToString)
            Next
            ComboBox1.SelectedIndex = 0
            'ComboBox1.SelectedValue = 1
            'btnInstall.Enabled = False
            chkOver.Checked = False
            chkOver.Text = "Nej"
            txtTitle.Text = System.Configuration.ConfigurationSettings.AppSettings.Get("ProjectTitle")
        Catch ex As Exception

        End Try
    End Sub

    Private Function MoveFoldersAndFiles(ByVal Path As String, ByVal Dest As String, ByVal Overwrite As Boolean) As Boolean
        Try
            Dim di As New System.IO.DirectoryInfo(Path)
            Dim dis() As System.IO.DirectoryInfo = di.GetDirectories
            Dim fis() As System.IO.FileInfo = di.GetFiles
            For Each d As System.IO.DirectoryInfo In dis
                If Not Overwrite Then
                    If Not System.IO.Directory.Exists(Dest & d.Name) Then
                        Dim oSC As New Scripting.FileSystemObjectClass
                        oSC.CopyFolder(d.FullName, Dest, True)
                    End If
                Else
                    Dim oSC As New Scripting.FileSystemObjectClass
                    oSC.CopyFolder(d.FullName, Dest, True)
                End If
            Next
            For Each f As System.IO.FileInfo In fis
                If Not Overwrite Then
                    If Not System.IO.File.Exists(Dest & f.Name) Then
                        f.CopyTo(Dest & f.Name, True)
                    End If
                Else
                    f.CopyTo(Dest & f.Name, True)
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CopyFiles(ByVal Overwrite As Boolean) As Boolean
        Try
            If System.IO.Directory.Exists(Application.StartupPath & "\Source\") Then
                If System.IO.Directory.Exists(txtPath.Text) Then
                    If Not MoveFoldersAndFiles(Application.StartupPath & "\Source\", txtPath.Text, Overwrite) Then
                        Throw New Exception
                    End If
                Else
                    Throw New Exception
                End If
            Else
                Throw New Exception
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function CopyMySQLFiles(ByVal Overwrite As Boolean) As Boolean
        Try
            Dim di As New System.IO.DirectoryInfo(TextBox1.Text)
            Dim dj As System.IO.DirectoryInfo = di.CreateSubdirectory(txtTitle.Text)
            If System.IO.Directory.Exists(Application.StartupPath & "\MySQL\") Then
                If System.IO.Directory.Exists(txtPath.Text) Then
                    If Not MoveFoldersAndFiles(Application.StartupPath & "\MySQL\", dj.FullName & "\", Overwrite) Then
                        Throw New Exception
                    End If
                Else
                    Throw New Exception
                End If
            Else
                Throw New Exception
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstall.Click
        Try
            btnInstall.Enabled = False
            Dim VirtualDir As String = txtTitle.Text
            Dim Server As String = System.Windows.Forms.SystemInformation.ComputerName
            If rbMySQL.Checked Then
                If Not CopyMySQLFiles(True) Then
                    lblNote.Text = "Ett fel uppstod vid skapandet av databasen!"
                    Throw New Exception("Ett fel uppstod vid skapandet av databasen!")
                End If
            End If
            If chkOver.Checked Then
                If Not CopyFiles(True) Then
                    lblNote.Text = "Ett fel uppstod vid kopiering av filer!"
                    Throw New Exception("Ett fel uppstod vid kopiering av filer!")
                End If
                If rbWeb.Checked Then
                    If VirtualDirCreate(Server, txtPath.Text, VirtualDir) Then
                        lblNote.Text = "Installationen gick bra!"
                    Else
                        lblNote.Text = "Ett fel uppstod vid skapandet av virtuell katalog!"
                        Throw New Exception("Ett fel uppstod vid skapandet av virtuell katalog!")
                    End If
                Else
                    lblNote.Text = "Installationen gick bra!"
                End If
            Else
                If Not CopyFiles(False) Then
                    lblNote.Text = "Ett fel uppstod vid kopiering av filer!"
                    Throw New Exception("Ett fel uppstod vid kopiering av filer!")
                End If
                If rbWeb.Checked Then
                    If VirtualDirExists(Server, txtPath.Text, VirtualDir) Then
                        lblNote.Text = "Den virtuella katalogen finns redan!"
                    Else
                        If VirtualDirCreate(Server, txtPath.Text, VirtualDir) Then
                            If Not UpdateConfigFile(VirtualDir, txtPath.Text) Then
                                lblNote.Text = "Ett fel uppstod vid skapandet av konfigfil!"
                                Throw New Exception("Ett fel uppstod vid skapandet av konfigfil!")
                            Else
                                lblNote.Text = "Installationen gick bra!"
                            End If
                        Else
                            lblNote.Text = "Ett fel uppstod vid skapandet av virtuell katalog!"
                            Throw New Exception("Ett fel uppstod vid skapandet av virtuell katalog!")
                        End If
                    End If
                Else
                    lblNote.Text = "Installationen gick bra!"
                End If
            End If
            btnInstall.Enabled = True
        Catch ex As Exception
            btnInstall.Enabled = True
            Dim el As New iConsulting.Library.Common.EventLogEntry(ex, "iCInstaller.exe", "btnInstall_Click")
            lblNote.Text = "Ett fel uppstod vid skapandet av virtuell katalog!"
        End Try
    End Sub

    Private Function VirtualDirExists(ByVal Server As String, ByVal Path As String, ByVal VDirName As String) As Boolean
        Try
            Dim IISSchema As System.DirectoryServices.DirectoryEntry
            Dim IISAdmin As System.DirectoryServices.DirectoryEntry
            Dim VDir As System.DirectoryServices.DirectoryEntry
            Dim IISUnderNT As Boolean
            Dim RootDir As Boolean = False

            IISSchema = New System.DirectoryServices.DirectoryEntry("IIS://" & Server & "/Schema/AppIsolated")
            If IISSchema.Properties("Syntax").Value.ToString().ToUpper() = "BOOLEAN" Then
                IISUnderNT = True
            Else
                IISUnderNT = False
            End If
            IISAdmin = New System.DirectoryServices.DirectoryEntry("IIS://localhost/W3SVC/" & SiteNumber.ToString & "/Root")
            If Not RootDir Then
                For Each v As System.DirectoryServices.DirectoryEntry In IISAdmin.Children
                    If v.Name = VDirName Then
                        Try
                            Return True
                        Catch ex As Exception
                            Return False
                        End Try
                    End If
                Next
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function VirtualDirCreate(ByVal Server As String, ByVal Path As String, ByVal VDirName As String) As Boolean
        Try
            Dim IISSchema As System.DirectoryServices.DirectoryEntry
            Dim IISAdmin As System.DirectoryServices.DirectoryEntry
            Dim VDir As System.DirectoryServices.DirectoryEntry
            Dim IISUnderNT As Boolean
            Dim RootDir As Boolean = False

            IISSchema = New System.DirectoryServices.DirectoryEntry("IIS://" & Server & "/Schema/AppIsolated")
            If IISSchema.Properties("Syntax").Value.ToString().ToUpper() = "BOOLEAN" Then
                IISUnderNT = True
            Else
                IISUnderNT = False
            End If
            IISAdmin = New System.DirectoryServices.DirectoryEntry("IIS://localhost/W3SVC/" & SiteNumber.ToString & "/Root")
            If Not RootDir Then
                For Each v As System.DirectoryServices.DirectoryEntry In IISAdmin.Children
                    If v.Name = VDirName Then
                        Try
                            IISAdmin.Invoke("Delete", New String() {v.SchemaClassName, VDirName})
                            IISAdmin.CommitChanges()
                        Catch ex As Exception
                            Return False
                        End Try
                    End If
                Next
            End If
            If Not RootDir Then
                VDir = IISAdmin.Children.Add(VDirName, "IIsWebVirtualDir")
            Else
                VDir = IISAdmin
            End If
            VDir.Properties("AccessRead")(0) = True
            VDir.Properties("AccessExecute")(0) = False
            VDir.Properties("AccessWrite")(0) = False
            VDir.Properties("AccessScript")(0) = True
            VDir.Properties("AuthNTLM")(0) = True
            VDir.Properties("EnableDefaultDoc")(0) = True
            VDir.Properties("EnableDirBrowsing")(0) = False
            VDir.Properties("DefaultDoc")(0) = True
            VDir.Properties("Path")(0) = Path
            VDir.Properties("AppFriendlyName")(0) = VDirName
            If Not IISUnderNT Then
                VDir.Properties("AspEnableParentPaths")(0) = True
            End If
            VDir.CommitChanges()
            If IISUnderNT Then
                VDir.Invoke("AppCreate", False)
            Else
                VDir.Invoke("AppCreate", 1)
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim eBT As cDHBrowseForFolder.BROWSE_TYPE = cDHBrowseForFolder.BROWSE_TYPE.BrowseForFolders
        Dim eFT As cDHBrowseForFolder.FOLDER_TYPE = cDHBrowseForFolder.FOLDER_TYPE.CSIDL_DESKTOP
        With m_cBFF
            .StartDir = "C:\"
            .UseNewUI = True
            .EditBox = True
            txtPath.Text = .BrowseForFolder(Me.Handle.ToInt32, "Välj installations katalog eller skapa en ny.", eBT, eFT)
        End With
    End Sub

    Private Sub chkOver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOver.CheckedChanged
        If chkOver.Checked Then
            chkOver.Text = "Ja"
        Else
            chkOver.Text = "Nej"
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        SiteNumber = Val(ComboBox1.SelectedItem(ComboBox1.SelectedIndex))

    End Sub

    Private Sub rbWeb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWeb.CheckedChanged
        If rbWeb.Checked Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub

    Private Sub rbMySQL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMySQL.CheckedChanged
        If rbMySQL.Checked Then
            TextBox1.Enabled = True
            Button2.Enabled = True
        Else
            TextBox1.Enabled = False
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim eBT As cDHBrowseForFolder.BROWSE_TYPE = cDHBrowseForFolder.BROWSE_TYPE.BrowseForFolders
        Dim eFT As cDHBrowseForFolder.FOLDER_TYPE = cDHBrowseForFolder.FOLDER_TYPE.CSIDL_DESKTOP
        With m_cBFF
            .StartDir = "C:\"
            .UseNewUI = True
            .EditBox = True
            TextBox1.Text = .BrowseForFolder(Me.Handle.ToInt32, "Välj datafils katalog eller skapa en ny.", eBT, eFT)
        End With
    End Sub

    Private Function UpdateConfigFile(ByVal Database As String, ByVal Dest As String) As Boolean
        Try
            Dim objXMLDocument As New System.xml.XmlDocument

            objXMLDocument.Load(Dest & "\Web.config")

            objXMLDocument.GetElementsByTagName("appSettings").Item(0)
            Dim objXMLElement As System.xml.XmlElement = objXMLDocument.CreateElement("add")
            Dim objXMLAttribute As System.xml.XmlAttribute = objXMLDocument.CreateAttribute("key")
            objXMLAttribute.Value = "ConnectionString"
            objXMLElement.Attributes.Append(objXMLAttribute)
            Dim objXMLAttribute2 As System.xml.XmlAttribute = objXMLDocument.CreateAttribute("value")
            objXMLAttribute2.Value = "Database=" & Database & "; " & System.Configuration.ConfigurationSettings.AppSettings.Get("NewConnection")
            objXMLElement.Attributes.Append(objXMLAttribute2)
            objXMLDocument.GetElementsByTagName("appSettings").Item(0).AppendChild(objXMLElement)
            objXMLDocument.Save(Dest & "\Web.config")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class

Public Class vv
    Public Value As Integer
    Public Text As Integer
End Class
