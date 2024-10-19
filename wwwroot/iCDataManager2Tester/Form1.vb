Imports System.Web.UI.WebControls
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Insert med ws"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 240)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Status:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(48, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(408, 16)
        Me.Label2.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(8, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Insert utan ws"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(8, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Insert utan ws sp"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Right
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(608, 0)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(224, 266)
        Me.DataGrid1.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(8, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "get data ws"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(8, 136)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "get data ws sp"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(8, 168)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(104, 23)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "DataTable"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(264, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(32, 20)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = "1"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(216, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Counter:"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Location = New System.Drawing.Point(440, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(168, 238)
        Me.ListBox1.TabIndex = 12
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(120, 168)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(104, 23)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "IDataReader"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(152, 80)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(96, 48)
        Me.Button8.TabIndex = 14
        Me.Button8.Text = "All"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(832, 266)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private counter As Integer = 999

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Label2.Text = ""
        Dim t As DateTime = Now
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        For i As Integer = 1 To counter
            Dim oDo As New ws_iCDataManager.iCDataObject
            Dim ds As New DataSet
            If Not oDo.GetEmptyDataSet("tab", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0).Item("tab_text") = "text_item_" & i.ToString
            If Not oDo.SaveDataSet("", ED, EC, ds, False) Then

            End If
            ds.Dispose()
            oDo.Dispose()
            Label2.Text = "Rad " & i.ToString & " skapades efter: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
            ProgressBar1.Value = i
            ProgressBar1.Refresh()
            Me.Refresh()
        Next
        Button1.Enabled = True
        Label2.Text = counter.ToString & " rader tog: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
    End Sub

    Private Sub Init(ByVal i As Integer)
        counter = i
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = counter
        ProgressBar1.Text = counter.ToString
        Label2.Text = ""
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        counter = Integer.Parse(TextBox1.Text)
        ProgressBar1.Minimum = 1
        ProgressBar1.Maximum = counter
        ProgressBar1.Text = counter.ToString
        Label2.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Label2.Text = ""
        Dim t As DateTime = Now
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        For i As Integer = 1 To counter
            Dim oDo As New iCDataManager.iCDataObject
            Dim ds As New DataSet
            If Not oDo.GetEmptyDataSet("tab", "", ED, EC, ds) Then

            End If
            ds.Tables(0).Rows(0).Item("tab_text") = "text_item_" & i.ToString
            If Not oDo.SaveDataSet("", ED, EC, ds, False) Then

            End If
            ds.Dispose()
            oDo.Dispose()
            Label2.Text = "Rad " & i.ToString & " skapades efter: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
            ProgressBar1.Value = i
            ProgressBar1.Refresh()
            Me.Refresh()
        Next
        Button2.Enabled = True
        Label2.Text = counter.ToString & " rader tog: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button2.Enabled = False
        Label2.Text = ""
        Dim t As DateTime = Now
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        For i As Integer = 1 To counter
            Dim oDo As New iCDataManager.iCDataObject
            Dim ds As New DataSet
            If Not oDo.GetDataFromSP("insert into tab (tab_text) values (" & "text_item_" & i.ToString & ")", "", ED, EC, ds) Then

            End If
            ds.Dispose()
            oDo.Dispose()
            Label2.Text = "Rad " & i.ToString & " skapades efter: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
            ProgressBar1.Value = i
            ProgressBar1.Refresh()
            Me.Refresh()
        Next
        Button2.Enabled = True
        Label2.Text = counter.ToString & " rader tog: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button2.Enabled = False
        Label2.Text = ""
        Dim t As DateTime = Now
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        Dim oDo As New iCDataManager.iCDataObject
        Dim ds As New DataSet
        If Not oDo.GetDataSet("tab", "", "", "", ED, EC, ds) Then

        End If
        ds.Dispose()
        oDo.Dispose()
        Button2.Enabled = True
        Label2.Text = ds.Tables(0).Rows.Count.ToString & " rader tog: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
        DataGrid1.DataSource = ds
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button2.Enabled = False
        Label2.Text = ""
        Dim t As DateTime = Now
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        Dim oDo As New iCDataManager.iCDataObject
        Dim ds As New DataSet
        If Not oDo.GetDataFromSP("select * from tab", "", ED, EC, ds) Then

        End If
        ds.Dispose()
        oDo.Dispose()
        Button2.Enabled = True
        Label2.Text = ds.Tables(0).Rows.Count.ToString & " rader tog: " & Now.Subtract(t).TotalMilliseconds.ToString() & " millisekunder"
        DataGrid1.DataSource = ds
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button6.Enabled = False
        Init(Integer.Parse(TextBox1.Text))
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        Dim Handle(counter) As iCDataManager.iCDataHandle
        Dim dt As DataTable

        ' With only one connection...
        Dim t As DateTime = Now
        Handle(0) = New iCDataManager.iCDataHandle(ED, EC)
        Handle(0).Connect()
        For i As Integer = 1 To counter
            For Each dr As DataRow In Handle(0).GetDataTable("SELECT * FROM TAB").Rows
                If dr("tab_id") = 100000 Then ListBox1.Items.Add(Now.Subtract(t).TotalMilliseconds.ToString()) : Exit For
            Next
            ProgressBar1.Value = i
        Next
        'DataGrid1.DataSource = ""
        'DataGrid1.Refresh()
        If Handle(0).IsConnected Then Handle(0).Close()
        Label2.Text = "klar"
        Button6.Enabled = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Button7.Enabled = False
        Init(Integer.Parse(TextBox1.Text))
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        Dim DataHandle(counter) As iCDataManager.iCDataHandle
        Dim ds As New DataSet

        ' With only one connection...
        Dim t As DateTime = Now
        DataHandle(0) = New iCDataManager.iCDataHandle(ED, EC)
        DataHandle(0).Connect()
        For i As Integer = 1 To counter
            Dim r As IDataReader = DataHandle(0).ExecuteReader("SELECT * FROM TAB")
            While r.Read
                If r.Item("tab_id") = 100000 Then ListBox1.Items.Add(Now.Subtract(t).TotalMilliseconds.ToString())
            End While
            r.Close()
            ProgressBar1.Value = i
        Next
        'DataGrid1.DataSource = ds
        'DataGrid1.Refresh()
        If DataHandle(0).IsConnected Then DataHandle(0).Close()
        Label2.Text = "klar"
        Button7.Enabled = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Button8.Enabled = False
        Init(Integer.Parse(TextBox1.Text))
        Dim oCrypt As New iConsulting.Library.Security.clsCrypto
        Dim ED As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("DataSource"))
        Dim EC As String = oCrypt.Encrypt(System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionString"))
        Dim DataHandle As iCDataManager.iCDataHandle = New iCDataManager.iCDataHandle(ED, EC)
        Dim ds As New DataSet

        Dim t As DateTime = Now
        DataHandle.Connect()
        DataHandle.NewTransaction()
        DataHandle.ExecuteNonQuery("insert into tab (tab_text) values ('ska inte finnas on tran funkar')")
        DataHandle.ExecuteNonQuery("insert into tab (tab_text3) values ('ap-bajs2')")
        DataHandle.EndTransaction()
        DataGrid1.DataSource = DataHandle.GetDataTable("select * from tab order by tab_id desc")
        DataGrid1.Refresh()
        If DataHandle.IsConnected Then DataHandle.Close()
        Label2.Text = "klar"
        Button8.Enabled = True

        'Dim o As New iCDataManager.TestTran
        'DataGrid1.DataSource = o.TestMe()
        'DataGrid1.Refresh()
        'Label2.Text = "klar"
        'Button8.Enabled = True
    End Sub
End Class
