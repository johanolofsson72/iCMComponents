Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.Web.HttpContext
Imports System.IO
Imports System.Diagnostics.Debug
Imports SoftArtisans.Net

<DefaultProperty("HeaderText"), ToolboxData("<{0}:iCUpload HeaderText=""Header"" SaveState=""1"" StateString=""c:\"" runat=""server""></{0}:iCUpload>")> _
Public Class iCUpload : Inherits Control : Implements INamingContainer

    Protected myFileUp As New HtmlControls.HtmlInputFile
    Protected myButton As New WebControls.ImageButton
    Protected myProgress As WebControls.Image
    Protected myList As New WebControls.Label

    Dim _header As String
    Dim _button As String
    Dim _width As Integer
    Dim _state As myState
    Dim _statestring As String
    Dim _progressbarid As String
    Dim _shadowid As String
    Dim _buttonid As String
    Dim _progressbarimageurl As String
    Dim _progressbarheight As Integer
    Dim _progressbarwidth As Integer
    Dim _headercss As String
    Dim _uploadcss As String
    Dim _buttoncss As String
    Dim _listcss As String
    Dim _buttonimage As String
    Dim _buttonimageload As String

    Public Enum myState
        FilePath = 1
        Session = 2
    End Enum

    <Bindable(False), Category("Appearance"), DefaultValue("")> _
    Property [HeaderText]() As String
        Get
            Return _header
        End Get

        Set(ByVal Value As String)
            _header = Value
        End Set
    End Property

    <Bindable(False), Category("Appearance"), DefaultValue("100")> _
    Property [ProgressBarWidth]() As Integer
        Get
            Return _progressbarwidth
        End Get

        Set(ByVal Value As Integer)
            _progressbarwidth = Value
        End Set
    End Property

    <Bindable(False), Category("Appearance"), DefaultValue("10")> _
    Property [ProgressBarHeight]() As Integer
        Get
            Return _progressbarheight
        End Get

        Set(ByVal Value As Integer)
            _progressbarheight = Value
        End Set
    End Property

    <Bindable(False), Category("Appearance"), DefaultValue("")> _
    Property [ProgressBarImageUrl]() As String
        Get
            Return _progressbarimageurl
        End Get

        Set(ByVal Value As String)
            _progressbarimageurl = Value
        End Set
    End Property

    <Bindable(False), Category("Appearance"), DefaultValue("")> _
    Property [ButtonImage]() As String
        Get
            Return _buttonimage
        End Get

        Set(ByVal Value As String)
            _buttonimage = Value
        End Set
    End Property

    <Bindable(False), Category("Appearance"), DefaultValue("")> _
    Property [ButtonImageLoad]() As String
        Get
            Return _buttonimageload
        End Get

        Set(ByVal Value As String)
            _buttonimageload = Value
        End Set
    End Property

    <Bindable(False), Category("Behavior"), DefaultValue("1")> _
    Property [SaveState]() As myState
        Get
            Return _state
        End Get

        Set(ByVal Value As myState)
            _state = Value
        End Set
    End Property

    <Bindable(False), Category("Behavior"), DefaultValue("")> _
    Property [StateString]() As String
        Get
            Return _statestring
        End Get

        Set(ByVal Value As String)
            _statestring = Value
        End Set
    End Property

    <Bindable(False), Category("Behavior"), DefaultValue("")> _
    Property [HeaderCss]() As String
        Get
            Return _headercss
        End Get

        Set(ByVal Value As String)
            _headercss = Value
        End Set
    End Property

    <Bindable(False), Category("Behavior"), DefaultValue("")> _
    Property [UploadCss]() As String
        Get
            Return _uploadcss
        End Get

        Set(ByVal Value As String)
            _uploadcss = Value
        End Set
    End Property

    <Bindable(False), Category("Behavior"), DefaultValue("")> _
    Property [ButtonCss]() As String
        Get
            Return _buttoncss
        End Get

        Set(ByVal Value As String)
            _buttoncss = Value
        End Set
    End Property

    <Bindable(False), Category("Behavior"), DefaultValue("")> _
    Property [ListCss]() As String
        Get
            Return _listcss
        End Get

        Set(ByVal Value As String)
            _listcss = Value
        End Set
    End Property

    Protected Overrides Sub CreateChildControls()
        Dim myTable As Table
        Dim myRow As TableRow
        Dim myCell As TableCell
        Dim myInnerTable As Table
        Dim myInnerRow As TableRow
        Dim myInnerCell As TableCell
        Dim myLabel As Label
        Dim myShadow As HtmlInputImage

        Dim _Width As Integer = 330 - 20
        Dim _Margin As Integer = 10
        Dim _ButtonWidth As String = "77px"
        Dim _ShowProgress As Boolean

        ' Button...
        myButton.ID = "UploadButton"
        myButton.EnableViewState = True
        myButton.Style.Add("visibility", "visible")
        myButton.Style.Add("width", _ButtonWidth)
        myButton.CssClass = IIf(IsNothing([ButtonCss]), "", [ButtonCss])
        myButton.ImageUrl = [ButtonImage]
        _buttonid = Me.ID & ":" & myButton.ID
        AddHandler myButton.Click, AddressOf Button_Click

        ' Shadow...
        myShadow = New HtmlInputImage
        myShadow.ID = "ShadowButton"
        myShadow.Style.Add("visibility", "hidden")
        myShadow.Style.Add("width", "0px")
        myShadow.Attributes.Add("class", IIf(IsNothing([ButtonCss]), "", [ButtonCss]))
        myShadow.Src = [ButtonImageLoad]
        myShadow.Disabled = True
        _shadowid = Me.ID & "_" & myShadow.ID

        ' List...
        PopulateList(myList)

        ' ProgressBar...
        If Not IsNothing([ProgressBarImageUrl]) Then
            If Not [ProgressBarImageUrl] = String.Empty Then

                myProgress = New WebControls.Image
                myProgress.EnableViewState = True
                myProgress.ID = "ProgressImage"
                myProgress.ImageUrl = [ProgressBarImageUrl]
                myProgress.Height = Unit.Pixel([ProgressBarHeight])
                myProgress.Width = Unit.Pixel([ProgressBarWidth])
                myProgress.Style.Add("visibility", "hidden")
                _progressbarid = Me.ID & "_" & myProgress.ID

                ' Add Event raiser
                myButton.Attributes.Add("onclick", "return DoProgress_" & Me.ID & "();")

                ' Create javascript
                Dim s As String = "<script language=""javascript"">"
                s += "__imagecache_" & Me.ID & " = new Image();"
                s += "__imagecache_" & Me.ID & ".src = '" & [ProgressBarImageUrl] & "';"
                s += "function DoProgress_" & Me.ID & "(){try{"
                s += "window.setTimeout(""ChangeProgress_" & Me.ID & "();"",100);}catch(e){window.status=e}"
                s += "return true;}"
                s += "function ChangeProgress_" & Me.ID & "(){try{"
                s += "var __myImage = window.document.getElementById('" & _progressbarid & "');"
                s += "__myImage.style.visibility=""visible"";"
                s += "__myImage.src = __imagecache_" & Me.ID & ".src;"
                s += "var __myButton = window.document.getElementById('" & _buttonid & "');"
                s += "__myButton.style.visibility=""hidden"";"
                s += "__myButton.style.width=""0px"";"
                s += "var __myShadow = window.document.getElementById('" & _shadowid & "');"
                s += "__myShadow.style.visibility=""visible"";"
                s += "__myShadow.style.width=""" & _ButtonWidth & """;"
                s += "}catch(e){window.status=e}}"
                s += "</script>"

                If Not Page.IsClientScriptBlockRegistered(Me.ID) Then
                    Page.RegisterClientScriptBlock(Me.ID, s)
                End If

                _ShowProgress = True
            End If
        End If

        ' FileUp...
        myFileUp.ID = "FileUpload"
        'myFileUp.Style.Add("WIDTH", _Width.ToString)
        myFileUp.Attributes.Add("size", "30")
        myFileUp.Attributes.Add("class", IIf(IsNothing([UploadCss]), "", [UploadCss]))

        ' Label...
        myLabel = New Label
        myLabel.ID = "HeaderLabel"
        myLabel.Attributes.Add("width", _Width.ToString)
        myLabel.Text = [HeaderText]
        myLabel.CssClass = IIf(IsNothing([HeaderCss]), "", [HeaderCss])

        ' Table...
        myTable = New Table
        myTable.CellPadding = 0
        myTable.CellSpacing = 0
        'myTable.GridLines = GridLines.Both

        ' First row...
        myRow = New TableRow
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Width.ToString)
        myCell.HorizontalAlign = HorizontalAlign.Left
        myCell.Controls.Add(myLabel)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myTable.Rows.Add(myRow)

        ' Second row...
        myRow = New TableRow
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Width.ToString)
        myCell.HorizontalAlign = HorizontalAlign.Left
        myCell.Controls.Add(myFileUp)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myTable.Rows.Add(myRow)

        ' Third row...
        myRow = New TableRow
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Width.ToString)
        myCell.HorizontalAlign = HorizontalAlign.Left

        ' InnerTable...
        myInnerTable = New Table
        myInnerTable.CellPadding = 0
        myInnerTable.CellSpacing = 0
        'myInnerTable.GridLines = GridLines.Both
        myInnerTable.Attributes.Add("width", "100%")
        myInnerRow = New TableRow
        myInnerCell = New TableCell
        myInnerCell.HorizontalAlign = HorizontalAlign.Left
        If _ShowProgress Then myInnerCell.Controls.Add(myProgress) : myInnerCell.Controls.Add(New LiteralControl("&nbsp;"))
        myInnerRow.Controls.Add(myInnerCell)
        myInnerCell = New TableCell
        myInnerCell.HorizontalAlign = HorizontalAlign.Left
        myInnerCell.Controls.Add(New LiteralControl("&nbsp;"))
        myInnerRow.Controls.Add(myInnerCell)
        myInnerCell = New TableCell
        myInnerCell.HorizontalAlign = HorizontalAlign.Right
        myInnerCell.Controls.Add(myButton)
        myInnerCell.Controls.Add(myShadow)
        myInnerRow.Controls.Add(myInnerCell)
        myInnerTable.Controls.Add(myInnerRow)

        myCell.Controls.Add(myInnerTable)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myTable.Rows.Add(myRow)

        ' Forth row...
        myRow = New TableRow
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Width.ToString)
        myCell.HorizontalAlign = HorizontalAlign.Left
        myCell.Controls.Add(myList)
        myRow.Cells.Add(myCell)
        myCell = New TableCell
        myCell.Attributes.Add("width", _Margin.ToString)
        myRow.Cells.Add(myCell)
        myTable.Rows.Add(myRow)

        Me.Controls.Add(myTable)
    End Sub

    Private Function PopulateList(ByRef myList As WebControls.Label)
        Try
            myList = New WebControls.Label
            myList.CssClass = IIf(IsNothing([ListCss]), "", [ListCss])
            Select Case [SaveState]
                Case myState.FilePath
                    Try
                        Dim Path As String
                        If [StateString].IndexOf("\") > -1 Then
                            Path = [StateString]
                        Else
                            Path = Current.Server.MapPath([StateString])
                        End If
                        For Each f As FileInfo In New DirectoryInfo(Path).GetFiles
                            If [StateString].IndexOf("\") > -1 Then
                                myList.Text += f.Name & "<br>"
                            Else
                                myList.Text += "<a href=""" & [StateString] & "/" & f.Name & """ target=""_blank"">" & f.Name & "</a><br>"
                            End If
                        Next
                    Catch ex As Exception

                    End Try
                Case myState.Session
                    Try
                        myList.Text += CType(Current.Session.Item([StateString]), HttpPostedFile).FileName & "<br>"
                    Catch ex As Exception

                    End Try
            End Select

        Catch ex As Exception

        End Try
    End Function

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As ImageClickEventArgs)
        Dim oFileUp As New FileUp(System.Web.HttpContext.Current)
        oFileUp.CreateNewFile = True
        Dim oFile As SaFile = CType(oFileUp.Form(Me.ID & ":FileUpload"), SaFile)
        Try
            If Not IsNothing(oFile) Then
                If Not oFile.IsEmpty Then
                    Select Case [SaveState]
                        Case myState.FilePath
                            Dim Path As String
                            If [StateString].IndexOf("\") > -1 Then
                                Path = [StateString]
                            Else
                                Path = Current.Server.MapPath([StateString])
                            End If
                            Dim myDir As New DirectoryInfo(Path)
                            If Not myDir.Exists Then
                                myDir.Create()
                            End If
                            'oFile.Path = myDir.FullName
                            oFileUp.Path = myDir.FullName
                            oFileUp.Save()
                            'oFile.Save()
                        Case myState.Session
                            If IsNothing(Current.Session.Item([StateString])) Then
                                Current.Session.Add([StateString], String.Empty)
                            End If
                            Current.Session.Item([StateString]) = oFile
                    End Select
                End If
            End If
            '''If myFileUp.PostedFile.ContentLength > 0 Then
            '''    Select Case [SaveState]
            '''        Case myState.FilePath
            '''            Dim myDir As New DirectoryInfo([StateString])
            '''            If Not myDir.Exists Then
            '''                myDir.Create()
            '''            End If
            '''            myFileUp.PostedFile.SaveAs(myDir.FullName & "\" & myFileUp.PostedFile.FileName.Substring(myFileUp.PostedFile.FileName.LastIndexOf("\") + 1))
            '''        Case myState.Session
            '''            If IsNothing(Current.Session.Item([StateString])) Then
            '''                Current.Session.Add([StateString], String.Empty)
            '''            End If
            '''            Current.Session.Item([StateString]) = myFileUp.PostedFile
            '''    End Select
            '''End If
            Current.Response.Write("<script language=""javascript"">window.location.href=window.location.href;</script>")
        Catch ex As Exception

        Finally
            If Not IsNothing(oFileUp) Then
                oFileUp.Dispose()
            End If
            oFileUp = Nothing
        End Try
    End Sub

End Class
