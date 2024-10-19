Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class clsArrowTemplate : Implements System.Web.UI.ITemplate

    Private ssImageUrl As String

    Sub New(ByVal sImageUrl As String)
        Me.ssImageUrl = sImageUrl
    End Sub

    Public Overridable Overloads Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
        'Dim p As New ImageButton
        'p.ImageUrl = Me.ssImageUrl
        'p.ToolTip = Me.ssValue
        'p.AlternateText = Me.ssValue
        'p.Attributes.Add("onclick", "alert(3);")

        ''p.Attributes.Add("onclick", "window.document.location.href='test.aspx';")
        ''AddHandler p.Click, AddressOf LinkButton_Click
        'container.Controls.Add(p)

        'Dim op As New HyperLink
        'op.ImageUrl = Me.ssImageUrl
        'op.ToolTip = Me.ssValue
        'op.NavigateUrl = Me.ssDestPath & "?iID=" & iiID
        'container.Controls.Add(op)

        Dim p As New Image
        p.ImageUrl = ssImageUrl
        p.ImageAlign = ImageAlign.AbsMiddle
        container.Controls.Add(p)
    End Sub

End Class
