Public Class Easy
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
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtTitle)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(336, 48)
        Me.GroupBox6.TabIndex = 21
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Program titel (används även som virtuellt katalognamn) :"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(16, 16)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(304, 20)
        Me.txtTitle.TabIndex = 19
        Me.txtTitle.Text = "Ny App..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 192)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(304, 72)
        Me.Label1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(16, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(304, 80)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Skapa"
        '
        'Easy
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 262)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "Easy"
        Me.Text = "Easy"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim VirtualDir As String = txtTitle.Text
            Dim Server As String = System.Windows.Forms.SystemInformation.ComputerName

            If Not CopyMySQLFiles(True) Then
                Label1.Text = "Ett fel uppstod vid skapandet av databasen!"
                Throw New Exception("Ett fel uppstod vid skapandet av databasen!")
            End If

            If Not CopyFiles(True) Then
                Label1.Text = "Ett fel uppstod vid kopiering av filer!"
                Throw New Exception("Ett fel uppstod vid kopiering av filer!")
            End If

            If VirtualDirCreate(Server, System.Configuration.ConfigurationSettings.AppSettings.Get("FileDestination") & txtTitle.Text & "\", VirtualDir, System.Configuration.ConfigurationSettings.AppSettings.Get("IISSiteIndex")) Then
                Label1.Text = "Installationen gick bra!"
            Else
                Label1.Text = "Ett fel uppstod vid skapandet av virtuell katalog!"
                Throw New Exception("Ett fel uppstod vid skapandet av virtuell katalog!")
            End If

            If Not UpdateConfigFile(VirtualDir, System.Configuration.ConfigurationSettings.AppSettings.Get("FileDestination") & txtTitle.Text & "\") Then
                Label1.Text = "Ett fel uppstod vid skapandet av konfigfil!"
                Throw New Exception("Ett fel uppstod vid skapandet av konfigfil!")
            Else
                Label1.Text = "Installationen gick bra!"
            End If

        Catch ex As Exception

        End Try
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

    Private Function VirtualDirCreate(ByVal Server As String, ByVal Path As String, ByVal VDirName As String, ByVal SiteIndexString As String) As Boolean
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
            IISAdmin = New System.DirectoryServices.DirectoryEntry("IIS://localhost/W3SVC/" & SiteIndexString & "/Root")
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

    Private Function CopyFiles(ByVal Overwrite As Boolean) As Boolean
        Try
            Dim Path As String = System.Configuration.ConfigurationSettings.AppSettings.Get("FileDestination") & txtTitle.Text & "\"
            Dim di As New System.IO.DirectoryInfo(Path)
            di.Create()
            If System.IO.Directory.Exists(Application.StartupPath & "\Source\") Then
                If Not MoveFoldersAndFiles(Application.StartupPath & "\Source\", di.FullName, Overwrite) Then
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
            Dim di As New System.IO.DirectoryInfo(System.Configuration.ConfigurationSettings.AppSettings.Get("mySQLDataFolder"))
            Dim dj As System.IO.DirectoryInfo = di.CreateSubdirectory(txtTitle.Text)
            If System.IO.Directory.Exists(Application.StartupPath & "\MySQL\") Then
                If Not MoveFoldersAndFiles(Application.StartupPath & "\MySQL\", dj.FullName & "\", Overwrite) Then
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

End Class
