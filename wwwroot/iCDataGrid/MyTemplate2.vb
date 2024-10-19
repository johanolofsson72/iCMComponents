
#Region " Description "

'=========================================================================
'Copyright (C) 2003 By Johan Birgersson, iConsutling 
'=========================================================================
'Class:         clsJbr1DataGrid     
'Category:      Class 
'Comments:      To Create dynamic template
'Revision:      2003-04-05, Johan Birgersson, Created
'-------------------------------------------------------------------------

#End Region

Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class MyTemplate2

    Implements System.Web.UI.ITemplate
    Private ssValue As String
    '// constructor
    Sub New(ByVal sValue As String)
        ssValue = sValue
    End Sub
    '// Contianer
    Public Overridable Overloads Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
        Dim oLabel As Label = New Label()
        oLabel.ID = "lbl" & ssValue
        AddHandler oLabel.DataBinding, AddressOf bindTextBox
        container.Controls.Add(oLabel)
    End Sub
    '// Binddata
    Public Sub bindTextBox(ByVal sender As Object, ByVal e As EventArgs)
        Dim oLabel As Label = CType(sender, Label)
        Dim container As DataGridItem = CType(oLabel.NamingContainer, DataGridItem)
        If Not container.DataItem(ssValue).GetType.ToString = "System.DBNull" Then
            Try
                oLabel.CssClass = "GridITEM"
                oLabel.Text = container.DataItem(ssValue)
            Catch
            End Try
        End If
    End Sub

End Class
