Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class clsDeleteButtonTemplate : Implements System.Web.UI.ITemplate

    Private ssValue As String
    Private ssCommand As String
    Private ssConfirm As String
    Private ssImageUrl As String

    Sub New(ByVal sValue As String, ByVal sCommand As String, ByVal sConfirm As String, ByVal sImageUrl As String)
        Me.ssValue = sValue
        Me.ssCommand = sCommand
        Me.ssConfirm = sConfirm
        Me.ssImageUrl = sImageUrl
    End Sub

    Public Overridable Overloads Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
        Dim p As New ImageButton
        If Me.ssImageUrl <> String.Empty Then
            p.ImageUrl = Me.ssImageUrl
        End If
        p.AlternateText = Me.ssValue
        p.ToolTip = Me.ssValue
        p.CommandName = Me.ssCommand
        p.Attributes.Add("onclick", Me.ssConfirm)
        container.Controls.Add(p)
    End Sub

End Class
