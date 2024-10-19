
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Services.Protocols

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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(80, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Text = "ComboBox1"
        '
        'ComboBox2
        '
        Me.ComboBox2.Location = New System.Drawing.Point(80, 56)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 1
        Me.ComboBox2.Text = "ComboBox1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Button1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oDo As New iCDataManager.iCDataObject
        Dim SQL1 As String = "select pag_name from pag_page"
        Dim SQL2 As String = "select mod_title from mod_modules"
        Dim oMSP As New iConsulting.Library.Data.clsMultiQueryListSP
        oMSP.AddQuery("Pages", SQL1)
        oMSP.AddQuery("Modules", SQL2)
        Dim ds As New DataSet
        'oDo.GetDataFromSP(SQL1, "", Encrypt("MySql"), Encrypt("Database=iCMServer; User=root; Port=3306; Host=localhost"), ds)
        oDo.GetMultiDataSetFromSP(oMSP.DataSet, "", Encrypt("MySql"), Encrypt("Database=iCMServer; User=root; Port=3306; Host=localhost"), ds)
        'System.Diagnostics.Debug.WriteLine(ds.GetXml)
        ComboBox1.DataSource = ds.Tables("Pages")
        ComboBox1.DisplayMember = "pag_name"
        ComboBox2.DataSource = ds.Tables("Modules")
        ComboBox2.DisplayMember = "mod_title"
    End Sub

    Private Function Encrypt(ByVal Value As String) As String
        Dim RMCrypto As New RijndaelManaged
        Dim ByteArray() As Byte = Encoding.UTF8.GetBytes(Value)
        Dim enc As ICryptoTransform = RMCrypto.CreateEncryptor(CRYPTO_KEY, CRYPTO_IV)
        Dim ByteArr() As Byte = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0))
        Return Convert.ToBase64String(ByteArr)
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oDo As New iCDataManager.iCDataObject
        Dim SQL1 As String = "select pag_name from pag_page"
        Dim SQL2 As String = "select mod_title from mod_modules"
        Dim oMSP As New iConsulting.Library.Data.clsMultiQueryListSP
        oMSP.AddQuery("Pages", SQL1)
        oMSP.AddQuery("Modules", SQL2)
        Dim ds As New DataSet
        'oDo.GetDataFromSP(SQL1, "", Encrypt("MySql"), Encrypt("Database=iCMServer; User=root; Port=3306; Host=localhost"), ds)
        oDo.GetMultiDataSetFromSP(oMSP.DataSet, "", Encrypt("MySql"), Encrypt("Database=iCMServer; User=root; Port=3306; Host=localhost"), ds)
        'System.Diagnostics.Debug.WriteLine(ds.GetXml)
        ComboBox2.DataSource = ds.Tables("Pages")
        ComboBox2.DisplayMember = "pag_name"
        ComboBox1.DataSource = ds.Tables("Modules")
        ComboBox1.DisplayMember = "mod_title"
    End Sub
End Class
