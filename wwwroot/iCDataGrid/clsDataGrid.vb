Imports System.Security.Cryptography
Imports System.Text
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports System
Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports iConsulting.iCMServer.iCDataManager

Public Class clsDataGrid

    Const CLASSNAME = "[Namespace::iConsulting.iCMServer.Components.iCDataGrid][Class::clsDataGrid]"

    Const GRID_PAGESIZE_DEFAULT As Integer = 10
    Const GRID_GRIDSTYLE_DEFAULT As Integer = 1
    Const DAT_TABLE_LBOUND = 0
    Const DAT_COLUMN_LBOUND = 0
    Const DAT_ROW_LBOUND = 0
    Dim iColumns As Integer = 0

    Private m_CRYPTO_KEY As Byte()
    Private m_CRYPTO_IV As Byte()
    Private m_ds As New DataSet
    Private m_dsColumnList As New DataSet
    Private m_sAuthorizedColumnString As String
    Private m_bButton As New Button
    Private m_sButtonText As String
    Private m_sTableID As String
    Private m_sTableName As String
    Private m_dgDataGrid As New DataGrid
    Private m_iPageSize As Integer
    Private m_iGridStyle As Integer
    Private m_iGridWidh As Integer

    Private m_sDataSource As String

    Private m_sConnectionString As String
    Private m_sUpdateText As String
    Private m_sEditText As String
    Private m_sDeleteText As String
    Private m_sCancelText As String
    Private m_bEditable As Boolean
    Private m_sConfirmText As String
    Private m_sLinkText As String
    Private m_sEditImageUrl As String
    Private m_sUpdateImageUrl As String
    Private m_sCancelImageUrl As String
    Private m_sDeleteImageUrl As String
    Private m_sLinkImageUrl As String
    Private m_sLinkDestPath As String
    Private m_bIsLinked As Boolean
    Private m_iArrowColumnID As Integer = -1
    Private m_iEditColumnID As Integer = -1
    Private m_iUpdateColumnID As Integer = -1
    Private m_iCancelColumnID As Integer = -1
    Private m_iDeleteColumnID As Integer = -1
    Private m_iLinkColumnID As Integer = -1
    Private m_iSelectedDataGridItem As Integer = -1
    Private m_bArrow As Boolean
    Private m_sArrowUrl As String
    Private m_iDefaultColumnWidth As Integer
    Private m_sDefaultColumnText As String
    Private m_sit_id As Integer

    Private m_bUseExtId As Boolean = False
    Private m_iExtId As Integer

#Region " Properties "
    Public WriteOnly Property UseExtId() As Boolean
        Set(ByVal Value As Boolean)
            Me.m_bUseExtId = Value
        End Set
    End Property
    Public WriteOnly Property ExtId() As Integer
        Set(ByVal Value As Integer)
            Me.m_iExtId = Value
        End Set
    End Property
    Public Property SiteId() As Integer
        Get
            Return Me.m_sit_id
        End Get
        Set(ByVal Value As Integer)
            Me.m_sit_id = Value
        End Set
    End Property
    Public WriteOnly Property DefaultColumnWidth() As Integer
        Set(ByVal Value As Integer)
            Me.m_sDefaultColumnText = String.Empty
            Dim i As Integer
            For i = 0 To Value
                Me.m_sDefaultColumnText += "&nbsp;"
            Next
        End Set
    End Property
    Public WriteOnly Property UseArrow() As Boolean
        Set(ByVal Value As Boolean)
            Me.m_bArrow = Value
        End Set
    End Property

    Public WriteOnly Property ArrowUrl() As String
        Set(ByVal Value As String)
            Me.m_sArrowUrl = Value
        End Set
    End Property

    Public WriteOnly Property IsLinked() As Boolean
        Set(ByVal Value As Boolean)
            Me.m_bIsLinked = Value
        End Set
    End Property

    Public WriteOnly Property EditImageUrl() As String
        Set(ByVal Value As String)
            Me.m_sEditImageUrl = Value
        End Set
    End Property

    Public WriteOnly Property LinkDestPath() As String
        Set(ByVal Value As String)
            Me.m_sLinkDestPath = Value
        End Set
    End Property

    Public WriteOnly Property UpdateImageUrl() As String
        Set(ByVal Value As String)
            Me.m_sUpdateImageUrl = Value
        End Set
    End Property

    Public WriteOnly Property CancelImageUrl() As String
        Set(ByVal Value As String)
            Me.m_sCancelImageUrl = Value
        End Set
    End Property

    Public WriteOnly Property DeleteImageUrl() As String
        Set(ByVal Value As String)
            Me.m_sDeleteImageUrl = Value
        End Set
    End Property

    Public WriteOnly Property LinkImageUrl() As String
        Set(ByVal Value As String)
            Me.m_sLinkImageUrl = Value
        End Set
    End Property

    Public WriteOnly Property ConfirmText() As String
        Set(ByVal Value As String)
            Me.m_sConfirmText = Value
        End Set
    End Property

    Public WriteOnly Property UpdateText() As String
        Set(ByVal Value As String)
            Me.m_sUpdateText = Value
        End Set
    End Property

    Public WriteOnly Property CancelText() As String
        Set(ByVal Value As String)
            Me.m_sCancelText = Value
        End Set
    End Property

    Public WriteOnly Property EditText() As String
        Set(ByVal Value As String)
            Me.m_sEditText = Value
        End Set
    End Property

    Public WriteOnly Property DeleteText() As String
        Set(ByVal Value As String)
            Me.m_sDeleteText = Value
        End Set
    End Property

    Public WriteOnly Property LinkText() As String
        Set(ByVal Value As String)
            Me.m_sLinkText = Value
        End Set
    End Property

    Public WriteOnly Property GridColumnList() As DataSet
        Set(ByVal Value As DataSet)
            Me.m_dsColumnList = Value
        End Set
    End Property

    Public WriteOnly Property SetAuthorizedColumnString() As String
        Set(ByVal Value As String)
            Me.m_sAuthorizedColumnString = Value
        End Set
    End Property

    Public WriteOnly Property PageSize() As Integer
        Set(ByVal Value As Integer)
            Me.m_iPageSize = Value
        End Set
    End Property

    Public WriteOnly Property GridStyle() As Integer
        Set(ByVal Value As Integer)
            Me.m_iGridStyle = Value
        End Set
    End Property

    Public ReadOnly Property AddNewButton() As Button
        Get
            Return Me.m_bButton
        End Get
    End Property

    Public WriteOnly Property ButtonText() As String
        Set(ByVal Value As String)
            Me.m_sButtonText = Value
        End Set
    End Property

    Public WriteOnly Property GridWith() As Integer
        Set(ByVal Value As Integer)
            Me.m_iGridWidh = Value
        End Set
    End Property


    Private Property DataSource() As String
        Get
            Return Me.m_sDataSource
        End Get
        Set(ByVal Value As String)
            Me.m_sDataSource = Value
        End Set
    End Property

    Private Property ConnectionString() As String
        Get
            Return Me.m_sConnectionString
        End Get
        Set(ByVal Value As String)
            Me.m_sConnectionString = Value
        End Set
    End Property



#End Region

#Region " Constructors "
    Public Sub Main()

    End Sub
    Public Sub New(ByVal sDataSource As String, ByVal sConnectionString As String, ByVal bAuthorizedEdit As Boolean, ByVal CRYPTO_KEY As Byte(), ByVal CRYPTO_IV As Byte())
        Me.DataSource = sDataSource
        Me.ConnectionString = sConnectionString
        Me.PageSize = GRID_PAGESIZE_DEFAULT
        Me.GridStyle = GRID_GRIDSTYLE_DEFAULT
        m_bEditable = bAuthorizedEdit
        m_CRYPTO_KEY = CRYPTO_KEY
        m_CRYPTO_IV = CRYPTO_IV
        Call SetStandardValues()
    End Sub

    Public Sub New(ByVal sDataSource As String, ByVal sConnectionString As String, ByVal iPageStyle As Integer, ByVal bAuthorizedEdit As Boolean, ByVal CRYPTO_KEY As Byte(), ByVal CRYPTO_IV As Byte())
        Me.DataSource = sDataSource
        Me.ConnectionString = sConnectionString
        Me.PageSize = iPageStyle
        Me.GridStyle = GRID_GRIDSTYLE_DEFAULT
        m_bEditable = bAuthorizedEdit
        m_CRYPTO_KEY = CRYPTO_KEY
        m_CRYPTO_IV = CRYPTO_IV
        Call SetStandardValues()
    End Sub

    Public Sub New(ByVal sDataSource As String, ByVal sConnectionString As String, ByVal iPageStyle As Integer, ByVal iGridStyle As Integer, ByVal bAuthorizedEdit As Boolean, ByVal CRYPTO_KEY As Byte(), ByVal CRYPTO_IV As Byte())
        Me.DataSource = sDataSource
        Me.ConnectionString = sConnectionString
        Me.PageSize = iPageStyle
        Me.GridStyle = iGridStyle
        m_bEditable = bAuthorizedEdit
        m_CRYPTO_KEY = CRYPTO_KEY
        m_CRYPTO_IV = CRYPTO_IV
        Call SetStandardValues()
    End Sub

    Private Sub SetStandardValues()
        Me.m_sButtonText = "Add New"
        Me.m_sAuthorizedColumnString = ""
        Me.m_sCancelText = "Cancel"
        Me.m_sDeleteText = "Delete"
        Me.m_sEditText = "Edit"
        Me.m_sUpdateText = "Update"
        Me.m_sConfirmText = "Are you Sure you want to delete this item?"
        Me.m_sDefaultColumnText = "&nbsp;&nbsp;&nbsp;&nbsp;"
    End Sub

#End Region

#Region " Private Functions "

    Private Function Encrypt(ByVal Value As String) As String
        Try
            Dim RMCrypto As New RijndaelManaged
            Dim ByteArray() As Byte = Encoding.UTF8.GetBytes(Value)
            Dim enc As ICryptoTransform = RMCrypto.CreateEncryptor(Me.m_CRYPTO_KEY, Me.m_CRYPTO_IV)
            Dim ByteArr() As Byte = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0))
            Return Convert.ToBase64String(ByteArr)
        Catch
            Return "The connection failed."
        End Try
    End Function

    Private Function Decrypt(ByVal base64String As String) As String
        Try
            Dim RMCrypto As New RijndaelManaged
            Dim dec As ICryptoTransform = RMCrypto.CreateDecryptor(Me.m_CRYPTO_KEY, Me.m_CRYPTO_IV)
            Dim ByteArr() As Byte = Convert.FromBase64String(base64String)
            Return Encoding.UTF8.GetString(dec.TransformFinalBlock(ByteArr, 0, ByteArr.GetLength(0)))
        Catch
            Return "Decrypt - " & Err.Description
        End Try
    End Function

    Private Sub BuildDataGrid()
        Dim iCCount As Integer = Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns.Count
        Dim i As Integer = 0
        Dim dr As DataRow
        Dim dc As DataColumn
        'iCCount = iCCount - 7
        Dim drCol As DataRow
        Dim bDO As Boolean = False
        Dim sTempName As String
        If Me.m_iGridStyle = GRID_GRIDSTYLE_DEFAULT Then
            If Me.m_bArrow Then
                Dim ArrowCol As New TemplateColumn
                ArrowCol.EditItemTemplate = New clsArrowTemplate(Me.m_sArrowUrl)
                Me.m_iArrowColumnID = iColumns : iColumns += 1
                Me.m_dgDataGrid.Columns.Add(ArrowCol)
                Me.m_dgDataGrid.Columns(iColumns - 1).HeaderText = Me.m_sDefaultColumnText
            End If

            If Me.m_dsColumnList.Tables.Count > 0 Then
                For Each dc In Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns
                    If i <> 0 Then
                        For Each drCol In Me.m_dsColumnList.Tables(DAT_TABLE_LBOUND).Rows
                            If drCol("Name") = Me.m_ds.Tables(0).Columns(i).ColumnName Then
                                bDO = True
                                sTempName = drCol("Alias")
                                Exit For
                            End If
                        Next
                        If bDO Then
                            Dim tc As New TemplateColumn
                            sTempName = sTempName
                            tc.HeaderText = sTempName
                            tc.ItemTemplate = New MyTemplate2(Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns(i).ColumnName)
                            tc.EditItemTemplate = New MyTemplate(Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns(i).ColumnName)
                            tc.ItemStyle.Wrap = False

                            Me.m_dgDataGrid.Columns.Add(tc)
                            sTempName = ""
                            bDO = False
                            iColumns += 1
                        End If
                    End If
                    i = i + 1
                Next
            Else
                For Each dc In Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns
                    If i <> 0 Then
                        Dim tc As New TemplateColumn
                        tc.HeaderText = Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns(i).ColumnName
                        tc.ItemTemplate = New MyTemplate2(Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns(i).ColumnName)
                        tc.EditItemTemplate = New MyTemplate(Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns(i).ColumnName)
                        tc.ItemStyle.Wrap = False
                        Me.m_dgDataGrid.Columns.Add(tc)
                        iColumns += 1
                    End If
                    i = i + 1
                Next
            End If
        End If


        '//Create Editbuttons
        'Dim Editcol As New EditCommandColumn
        'Editcol.ButtonType = ButtonColumnType.LinkButton
        'Editcol.CancelText = Me.m_sCancelText
        'Editcol.EditText = Me.m_sEditText
        'Editcol.UpdateText = Me.m_sUpdateText
        'If Me.m_bEditable Then Me.m_dgDataGrid.Columns.Add(Editcol)

        Dim EditCol As New TemplateColumn
        EditCol.ItemTemplate = New clsDeleteButtonTemplate(Me.m_sEditText, "Edit", "", Me.m_sEditImageUrl)
        'EditCol.EditItemTemplate = New clsDeleteButtonTemplate(Me.m_sEditText, "Edit", "", Me.m_sEditImageUrl)
        Me.m_iEditColumnID = iColumns : iColumns += 1
        If Me.m_bEditable Then Me.m_dgDataGrid.Columns.Add(EditCol) : Me.m_dgDataGrid.Columns(iColumns - 1).HeaderText = Me.m_sDefaultColumnText

        Dim UpdateCol As New TemplateColumn
        'UpdateCol.ItemTemplate = New clsDeleteButtonTemplate(Me.m_sUpdateText, "Update", "", "")
        UpdateCol.EditItemTemplate = New clsDeleteButtonTemplate(Me.m_sUpdateText, "Update", "", Me.m_sUpdateImageUrl)
        Me.m_iUpdateColumnID = iColumns : iColumns += 1
        If Me.m_bEditable Then Me.m_dgDataGrid.Columns.Add(UpdateCol) : Me.m_dgDataGrid.Columns(iColumns - 1).HeaderText = Me.m_sDefaultColumnText

        Dim CancelCol As New TemplateColumn
        'CancelCol.ItemTemplate = New clsDeleteButtonTemplate(Me.m_sCancelText, "Cancel", "", "")
        CancelCol.EditItemTemplate = New clsDeleteButtonTemplate(Me.m_sCancelText, "Cancel", "", Me.m_sCancelImageUrl)
        Me.m_iCancelColumnID = iColumns : iColumns += 1
        If Me.m_bEditable Then Me.m_dgDataGrid.Columns.Add(CancelCol) : Me.m_dgDataGrid.Columns(iColumns - 1).HeaderText = Me.m_sDefaultColumnText

        Dim DeleteCol As New TemplateColumn
        'DeleteCol.ItemTemplate = New clsDeleteButtonTemplate(Me.m_sDeleteText, "Delete", "return confirm('" & Me.m_sConfirmText & "');", "")
        DeleteCol.EditItemTemplate = New clsDeleteButtonTemplate(Me.m_sDeleteText, "Delete", "return confirm('" & Me.m_sConfirmText & "');", Me.m_sDeleteImageUrl)
        Me.m_iDeleteColumnID = iColumns : iColumns += 1
        If Me.m_bEditable Then Me.m_dgDataGrid.Columns.Add(DeleteCol) : Me.m_dgDataGrid.Columns(iColumns - 1).HeaderText = Me.m_sDefaultColumnText

        Dim LinkCol As New TemplateColumn
        'LinkCol.ItemTemplate = New clsLinkButtonTemplate(Me.m_sLinkText, Me.m_sLinkDestPath, "", Me.m_iSelectedDataGridItem)
        LinkCol.EditItemTemplate = New clsLinkButtonTemplate(Me.m_sLinkText, Me.m_sLinkDestPath, Me.m_sLinkImageUrl, Me.m_iSelectedDataGridItem)
        Me.m_iLinkColumnID = iColumns ' : iColumns += 1
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Add(LinkCol) : Me.m_dgDataGrid.Columns(iColumns - 1).HeaderText = Me.m_sDefaultColumnText

        If Me.m_bEditable Then
            With Me.m_dgDataGrid.Columns
                .Item(Me.m_iEditColumnID).Visible = True
                .Item(Me.m_iUpdateColumnID).Visible = False
                .Item(Me.m_iCancelColumnID).Visible = False
                .Item(Me.m_iDeleteColumnID).Visible = False
            End With
        End If
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Item(Me.m_iLinkColumnID).Visible = False

        '//Add Handler
        AddHandler Me.m_dgDataGrid.PageIndexChanged, AddressOf DataGrid1_PageIndexChanged
        AddHandler Me.m_dgDataGrid.EditCommand, AddressOf DataGrid1_DoItemEdit
        AddHandler Me.m_dgDataGrid.CancelCommand, AddressOf DataGrid1_DoItemCancel
        AddHandler Me.m_dgDataGrid.UpdateCommand, AddressOf DataGrid1_DoItemUpdate
        AddHandler Me.m_dgDataGrid.ItemDataBound, AddressOf DataGrid1_ItemDataBound
        AddHandler Me.m_dgDataGrid.DeleteCommand, AddressOf DataGrid1_DoItemDelete
        AddHandler Me.m_dgDataGrid.ItemCreated, AddressOf DataGrid1_ItemCreated
    End Sub

    Private Sub DataGrid1_ItemCreated(ByVal Sender As Object, ByVal e As DataGridItemEventArgs)
        'Select Case e.Item.ItemType
        '    Case ListItemType.Item, ListItemType.AlternatingItem
        '        Dim myDeleteButton As LinkButton
        '        myDeleteButton = e.Item.FindControl("DeleteCol")
        '        If Not IsNothing(myDeleteButton) Then

        '            myDeleteButton.Attributes.Add("onclick", "return confirm('Are you Sure you want to delete this company?');")
        '        End If
        'End Select
    End Sub

    Private Sub SetDataGridProperties(ByVal iStyle As Integer)
        Select Case iStyle
            Case 1
                'Me.m_dgDataGrid.BorderWidth = Unit.Pixel(1)
                'Me.m_dgDataGrid.GridLines = GridLines.Both
                'Me.m_dgDataGrid.BorderColor = Color.RoyalBlue
                'Me.m_dgDataGrid.BackColor = System.Drawing.Color.GhostWhite
                'Me.m_dgDataGrid.CellPadding = 2
                'Me.m_dgDataGrid.Font.Size = Me.m_dgDataGrid.Font.Size.XSmall
                'Me.m_dgDataGrid.Font.Name = "Verdana"
                'Me.m_dgDataGrid.ItemStyle.CssClass = "ITEMSTYLEHYPERLINK"
                'Me.m_dgDataGrid.HeaderStyle.Font.Size = Me.m_dgDataGrid.HeaderStyle.Font.Size.XSmall
                'Me.m_dgDataGrid.HeaderStyle.Font.Bold = True
                'Me.m_dgDataGrid.HorizontalAlign = HorizontalAlign.Center
                'Me.m_dgDataGrid.HeaderStyle.Font.Name = "Verdana"
                'Me.m_dgDataGrid.HeaderStyle.ForeColor = Me.m_dgDataGrid.HeaderStyle.ForeColor.Lavender
                'Me.m_dgDataGrid.HeaderStyle.BackColor = Color.MidnightBlue
                'Me.m_dgDataGrid.FooterStyle.Font.Size = Me.m_dgDataGrid.HeaderStyle.Font.Size.XXSmall
                'Me.m_dgDataGrid.FooterStyle.Font.Bold = False
                'Me.m_dgDataGrid.FooterStyle.ForeColor = Me.m_dgDataGrid.HeaderStyle.ForeColor.Black
                'Me.m_dgDataGrid.FooterStyle.BackColor = Color.Gray
                'Me.m_dgDataGrid.PagerStyle.BackColor = Me.m_dgDataGrid.PagerStyle.BackColor.WhiteSmoke
                'Me.m_dgDataGrid.PagerStyle.Font.Size = Me.m_dgDataGrid.PagerStyle.Font.Size.XXSmall

                Me.m_dgDataGrid.BorderWidth = Unit.Pixel(1)
                ' Me.m_dgDataGrid.ItemStyle.CssClass = "GridITEM"
                Me.m_dgDataGrid.CssClass = "Grid"
                Me.m_dgDataGrid.HeaderStyle.CssClass = "GridHead"
                Me.m_dgDataGrid.Width = m_dgDataGrid.Width.Pixel(m_iGridWidh)
                Me.m_dgDataGrid.GridLines = GridLines.Horizontal


                Me.m_dgDataGrid.ID = "MyGrid"
                Me.m_dgDataGrid.ShowHeader = True
                Me.m_dgDataGrid.AutoGenerateColumns = False
                Me.m_dgDataGrid.AllowPaging = True
                Me.m_dgDataGrid.CurrentPageIndex = 0
                Me.m_dgDataGrid.Enabled = True
                Me.m_dgDataGrid.EnableViewState = True '"LEFT: 0%; POSITION: absolute; TOP: 0%"
                Me.m_dgDataGrid.Style.Add("LEFT", "10px") 'style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 432px"
                Me.m_dgDataGrid.Style.Add("TOP", "10px")
                Me.m_dgDataGrid.HeaderStyle.Wrap = False


            Case Else
        End Select
    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal objSender As Object, ByVal objArgs As EventArgs)
        'write your code here
        Dim strTemp
        strTemp = Me.m_dgDataGrid.SelectedItem()
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal objSender As Object, ByVal objArgs As DataGridPageChangedEventArgs)
        Me.m_dgDataGrid.CurrentPageIndex = objArgs.NewPageIndex
        Call BindDataGrid()
    End Sub

    Private Sub DataGrid1_DoItemEdit(ByVal objSender As Object, ByVal objArgs As DataGridCommandEventArgs)
        If Me.m_bIsLinked Then

            Dim i As Integer
            For i = 0 To Me.m_dgDataGrid.Columns.Count - 1
                Me.m_dgDataGrid.Columns.Item(i).Visible = True
            Next
            Me.m_dgDataGrid.Columns.RemoveAt(iColumns)

            Me.m_iSelectedDataGridItem = Me.m_dgDataGrid.DataKeys(objArgs.Item.ItemIndex)
            Dim LinkCol As New TemplateColumn
            If Me.m_bUseExtId Then
                LinkCol.EditItemTemplate = New clsLinkButtonTemplate(Me.m_sLinkText, Me.m_sLinkDestPath & "?iID=" & Me.m_iSelectedDataGridItem, Me.m_sLinkImageUrl, Me.m_iSelectedDataGridItem)
            Else
                LinkCol.EditItemTemplate = New clsLinkButtonTemplate(Me.m_sLinkText, Me.m_sLinkDestPath & "?ExtId=" & Me.m_iExtId & "&iID=" & Me.m_iSelectedDataGridItem, Me.m_sLinkImageUrl, Me.m_iSelectedDataGridItem)
            End If
            Me.m_iLinkColumnID = iColumns
            Me.m_dgDataGrid.Columns.Add(LinkCol)
            Me.m_dgDataGrid.Columns(iColumns).HeaderText = Me.m_sDefaultColumnText
        End If
        With Me.m_dgDataGrid.Columns
            .Item(Me.m_iEditColumnID).Visible = False
            .Item(Me.m_iUpdateColumnID).Visible = True
            .Item(Me.m_iCancelColumnID).Visible = True
            .Item(Me.m_iDeleteColumnID).Visible = True
        End With
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Item(Me.m_iLinkColumnID).Visible = True
        'Me.m_dgDataGrid.Columns.RemoveAt(iColumns)
        Me.m_dgDataGrid.EditItemIndex = objArgs.Item.ItemIndex
        Call BindDataGrid()
    End Sub

    Private Sub DataGrid1_DoItemUpdate(ByVal objSender As Object, ByVal objArgs As DataGridCommandEventArgs)
        '//Stnadard
        Dim sError As String
        Dim iID As Integer
        Dim objCtrl1, objCtrl2 As TextBox
        Dim dc As DataColumn
        Dim i As Integer
        Dim sValue As String
        Dim ds2 As New DataSet
        Dim sWhereAuthorized As String
        '//Get Id for the edit row
        iID = Me.m_dgDataGrid.DataKeys(objArgs.Item.ItemIndex)

        '//Get new dataset with editiable row
        Dim iCData As New iCDataObject
        If Me.m_sAuthorizedColumnString <> "" Then
            sWhereAuthorized = " AND " & Me.m_sAuthorizedColumnString
        End If
        If Not iCData.GetDataSet(Me.m_sTableName, Me.m_sTableID & "=" & iID & sWhereAuthorized & " AND sit_id = " & Me.m_sit_id, Me.m_sTableID, sError, DataSource, ConnectionString, ds2) Then
            ' no error handler here
            Exit Sub
        End If
        If ds2.Tables(DAT_TABLE_LBOUND).Rows.Count < 1 Then
            Me.m_dgDataGrid.EditItemIndex = -1
            Call BindDataGrid()
            Exit Sub
        End If

        System.Diagnostics.Debug.WriteLine(ds2.GetXml)
        '//Count Columns
        Dim iCCount As Integer = ds2.Tables(DAT_TABLE_LBOUND).Columns.Count
        '//For iconsutling, this is special to pass the iConsuling iCDataMangaer standard
        If Me.m_iGridStyle = GRID_GRIDSTYLE_DEFAULT Then '// Just for check that it's iConsulting Grid, -7 is standard
            iCCount = iCCount - 7
            If Me.m_iGridStyle = GRID_GRIDSTYLE_DEFAULT Then
                For Each dc In ds2.Tables(DAT_TABLE_LBOUND).Columns

                    If i = 0 Then ' Or Not i < iCCount Then
                    Else
                        Dim sControl As String
                        Dim oControl As TextBox
                        sControl = ds2.Tables(DAT_TABLE_LBOUND).Columns(i).ColumnName
                        '//Find Controls
                        oControl = CType(objArgs.Item.FindControl(sControl), TextBox)
                        If Not IsNothing(oControl) Then
                            If Len(oControl.Text) > 0 Then
                                ds2.Tables(DAT_TABLE_LBOUND).Rows(DAT_ROW_LBOUND)(sControl) = oControl.Text
                            End If
                        End If
                        'System.Diagnostics.Debug.WriteLine(ds2.GetXml)
                        'System.Diagnostics.Debug.WriteLine(oControl.Text)

                        ' kolla igenom Me.m_dsColumnList om det finns i den.

                    End If
                    i = i + 1
                Next
            End If
        End If
        'System.Diagnostics.Debug.WriteLine(ds2.GetXml)

        '//Save ds
        If Not iCData.SaveDataSet(sError, DataSource, ConnectionString, ds2, False) Then
            ' no error handler here
            Exit Sub
        End If
        '// Get a updated dataSet
        Dim dsTemp As New DataSet
        If Not iCData.GetDataSet(Me.m_sTableName, Me.m_sAuthorizedColumnString & " AND sit_id = " & Me.m_sit_id, Me.m_sTableID, sError, DataSource, ConnectionString, dsTemp) Then
            Exit Sub
        End If
        Me.m_ds = dsTemp
        '//Bind
        With Me.m_dgDataGrid.Columns
            .Item(Me.m_iEditColumnID).Visible = True
            .Item(Me.m_iUpdateColumnID).Visible = False
            .Item(Me.m_iCancelColumnID).Visible = False
            .Item(Me.m_iDeleteColumnID).Visible = False
        End With
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Item(Me.m_iLinkColumnID).Visible = False
        Me.m_dgDataGrid.EditItemIndex = -1
        Call BindDataGrid()
    End Sub

    Private Sub DataGrid1_DoItemCancel(ByVal objSender As Object, ByVal objArgs As DataGridCommandEventArgs)
        With Me.m_dgDataGrid.Columns
            .Item(Me.m_iEditColumnID).Visible = True
            .Item(Me.m_iUpdateColumnID).Visible = False
            .Item(Me.m_iCancelColumnID).Visible = False
            .Item(Me.m_iDeleteColumnID).Visible = False
        End With
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Item(Me.m_iLinkColumnID).Visible = False
        Me.m_dgDataGrid.EditItemIndex = -1
        Call BindDataGrid()
    End Sub

    Private Sub DataGrid1_DoItemDelete(ByVal objSender As Object, ByVal objArgs As DataGridCommandEventArgs)

        Dim iCData As New iCDataObject
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim sError As String
        Dim iID As Integer = Me.m_dgDataGrid.DataKeys(objArgs.Item.ItemIndex)
        Dim sWhereAuthorized As String

        If Me.m_sAuthorizedColumnString <> "" Then
            sWhereAuthorized = " AND " & Me.m_sAuthorizedColumnString
        End If

        If Not iCData.GetDataSet(Me.m_sTableName, Me.m_sTableID & "=" & iID & sWhereAuthorized & " AND sit_id = " & Me.m_sit_id, "", sError, DataSource, ConnectionString, ds) Then
            Exit Sub
        End If

        If ds.Tables.Count > DAT_TABLE_LBOUND Then
            If ds.Tables(DAT_TABLE_LBOUND).Rows.Count > DAT_ROW_LBOUND Then
                ds.Tables(DAT_TABLE_LBOUND).Rows(DAT_ROW_LBOUND)(Left(Me.m_sTableID, 4) & "deleted") = 1
                If Not iCData.SaveDataSet(sError, DataSource, ConnectionString, ds, False) Then
                    System.Diagnostics.Debug.WriteLine(ds.GetXml)
                End If
            End If
        End If

        Dim dsTemp As New DataSet
        If Not iCData.GetDataSet(Me.m_sTableName, Me.m_sAuthorizedColumnString & " AND sit_id = " & Me.m_sit_id, Me.m_sTableID, sError, DataSource, ConnectionString, dsTemp) Then
            Exit Sub
        End If

        Me.m_ds = dsTemp
        If Me.m_dgDataGrid.CurrentPageIndex > 0 And objArgs.Item.ItemIndex = 0 Then
            Me.m_dgDataGrid.CurrentPageIndex = Me.m_dgDataGrid.CurrentPageIndex - 1
        End If
        With Me.m_dgDataGrid.Columns
            .Item(Me.m_iEditColumnID).Visible = True
            .Item(Me.m_iUpdateColumnID).Visible = False
            .Item(Me.m_iCancelColumnID).Visible = False
            .Item(Me.m_iDeleteColumnID).Visible = False
        End With
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Item(Me.m_iLinkColumnID).Visible = False
        Me.m_dgDataGrid.EditItemIndex = -1
        Call BindDataGrid()
    End Sub

    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor='lavender'")

            If e.Item.ItemType = ListItemType.Item Then
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            Else
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white'")
            End If
        End If
    End Sub

    Function ChangeColor(ByVal value)
        If value = "Owner" Then
            ChangeColor = "<font color=#ff0000>" & value & "</font>"

        ElseIf value = "Sales Representative" Then
            ChangeColor = "<font color=#fff000>" & value & "</font>"

        Else
            ChangeColor = value
        End If

    End Function

    Function ChangeColor2(ByVal value1, ByVal value2)
        If value1 = "Owner" Then
            ChangeColor2 = "<font color=#ff0000>" & value2 & "</font>"
        Else
            ChangeColor2 = value2
        End If
    End Function

    Private Sub CreateAddNewButton()
        'Me.m_bButton.ID = "iCDataGrid::AddNewButton"
        Me.m_bButton.Text = Me.m_sButtonText
        Me.m_bButton.BorderColor = Color.RoyalBlue
        Me.m_bButton.BackColor = System.Drawing.Color.GhostWhite
        Me.m_bButton.Font.Size = Me.m_bButton.Font.Size.XXSmall
        Me.m_bButton.Font.Name = "Verdana"
        Me.m_bButton.Height = Me.m_bButton.Height.Pixel(21)
        AddHandler Me.m_bButton.Click, AddressOf m_bButton_Click
    End Sub

    Private Sub m_bButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iCData As New iCDataObject
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim sError As String
        If Not iCData.GetDataSet(Me.m_sTableName, Me.m_sAuthorizedColumnString & " AND sit_id = " & Me.m_sit_id, Me.m_sTableID, sError, DataSource, ConnectionString, ds) Then
            Exit Sub
        End If
        dr = ds.Tables(0).NewRow
        Dim a As Array
        Dim i As Integer
        For i = 1 To dr.ItemArray.Length - 1
            System.Diagnostics.Debug.WriteLine(ds.Tables(0).Columns(i).DataType.FullName)
            If ds.Tables(0).Columns(i).Caption = "sit_id" Then
                dr.Item(i) = Me.m_sit_id
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.String" Then
                dr.Item(i) = ""
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.Int16" Then
                dr.Item(i) = 0
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.Int32" Then
                dr.Item(i) = 0
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.Int64" Then
                dr.Item(i) = 0
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.Integer" Then
                dr.Item(i) = 0
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.Boolean" Then
                dr.Item(i) = False
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.DateTime" Then
                dr.Item(i) = Now
            ElseIf ds.Tables(0).Columns(i).DataType.FullName = "System.Date" Then
                dr.Item(i) = Now
            End If
        Next

        ds.Tables(0).Rows.Add(dr)
        If Not iCData.SaveDataSet(sError, DataSource, ConnectionString, ds, False) Then
            System.Diagnostics.Debug.WriteLine(ds.GetXml)
        End If
        Dim dsTemp As New DataSet
        If Not iCData.GetDataSet(Me.m_sTableName, Me.m_sAuthorizedColumnString & " AND sit_id = " & Me.m_sit_id, Me.m_sTableID, sError, DataSource, ConnectionString, dsTemp) Then
            Exit Sub
        End If
        Me.m_ds = dsTemp
        Call BindDataGrid()
        Me.m_dgDataGrid.CurrentPageIndex = Me.m_dgDataGrid.PageCount - 1
        Call BindDataGrid()
        Me.m_dgDataGrid.EditItemIndex = Me.m_dgDataGrid.Items.Count - 1
        If Me.m_bEditable Then
            With Me.m_dgDataGrid.Columns
                .Item(Me.m_iEditColumnID).Visible = False
                .Item(Me.m_iUpdateColumnID).Visible = True
                .Item(Me.m_iCancelColumnID).Visible = True
                .Item(Me.m_iDeleteColumnID).Visible = True
            End With
        End If
        If Me.m_bIsLinked Then Me.m_dgDataGrid.Columns.Item(Me.m_iLinkColumnID).Visible = True
        Call BindDataGrid()
    End Sub

#End Region

#Region " Public Functions "

    Public Function CreateDataGrid(ByVal ds As DataSet) As DataGrid
        Me.m_ds.Merge(ds)
        Me.m_sTableName = Me.m_ds.Tables(DAT_TABLE_LBOUND).TableName
        Call SetDataGridProperties(Me.m_iGridStyle)
        Me.m_dgDataGrid.DataKeyField = Me.m_ds.Tables(DAT_TABLE_LBOUND).Columns(DAT_COLUMN_LBOUND).ColumnName
        Me.m_sTableID = Me.m_dgDataGrid.DataKeyField
        Call CreateAddNewButton()
        Call BuildDataGrid()
        Call BindDataGrid()
        Return Me.m_dgDataGrid
    End Function

    Public Sub BindDataGrid()
        If Me.m_iPageSize = Nothing Then
            Me.m_dgDataGrid.PageSize = CInt(GRID_PAGESIZE_DEFAULT)
        Else
            Me.m_dgDataGrid.PageSize = CInt(Me.m_iPageSize)
        End If
        Me.m_dgDataGrid.PagerStyle.Mode = PagerMode.NumericPages
        Me.m_dgDataGrid.DataSource = Me.m_ds
        Me.m_dgDataGrid.DataBind()
    End Sub

#End Region

End Class


