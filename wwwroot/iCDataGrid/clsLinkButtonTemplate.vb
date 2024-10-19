Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class clsLinkButtonTemplate : Implements System.Web.UI.ITemplate

    Private ssValue As String
    Private ssDestPath As String
    Private ssImageUrl As String
    Private iiID As Integer

    Sub New(ByVal sValue As String, ByVal sDestPath As String, ByVal sImageUrl As String, ByVal iID As Integer)
        Me.ssValue = sValue
        Me.ssDestPath = sDestPath
        Me.ssImageUrl = sImageUrl
        Me.iiID = iID
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

        Dim op As New HyperLink
        op.ImageUrl = Me.ssImageUrl
        op.ToolTip = Me.ssValue
        op.NavigateUrl = Me.ssDestPath '& "?iID=" & iiID
        container.Controls.Add(op)
    End Sub

End Class
