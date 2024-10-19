Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class clsSiteModuleControl
    Inherits UserControl

    Private _moduleConfiguration As clsModuleSettings
    Private _isEditable As Integer = 0
    Private _siteId As Integer = 0
    Private _settings As Hashtable

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ModuleId() As Integer
        Get
            Return CInt(_moduleConfiguration.ModuleId)
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SiteId() As Integer
        Get
            Return _siteId
        End Get
        Set(ByVal Value As Integer)
            _siteId = Value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property IsEditable() As Boolean
        Get
            ' Perform tri-state switch check to avoid having to perform a security
            ' role lookup on every property access (instead caching the result)
            If _isEditable = 0 Then
                ' Obtain PortalSettings from Current Context
                Dim _portalSettings As clsSiteSettings = CType(HttpContext.Current.Items("SiteSettings"), clsSiteSettings)
                If _portalSettings.AlwaysShowEditButton = True Or clsSiteSecurity.IsInRoles(_moduleConfiguration.AuthorizedEditRoles) Then
                    _isEditable = 1
                Else
                    _isEditable = 2
                End If
            End If
            Return _isEditable = 1
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ModuleConfiguration() As clsModuleSettings
        Get
            Return _moduleConfiguration
        End Get
        Set(ByVal Value As clsModuleSettings)
            _moduleConfiguration = Value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Settings() As Hashtable
        Get
            If _settings Is Nothing Then
                '_settings = clsModuleSettings.GetModuleSettings(ModuleId)
            End If
            Return _settings
        End Get
    End Property

End Class
