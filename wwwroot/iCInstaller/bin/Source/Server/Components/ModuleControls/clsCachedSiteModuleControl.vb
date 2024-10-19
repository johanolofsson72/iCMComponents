Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class clsCachedSiteModuleControl
    Inherits Control

    Private _moduleConfiguration As clsModuleSettings
    Private _cachedOutput As String = ""
    Private _siteId As Integer = 0

    Public Property ModuleConfiguration() As clsModuleSettings
        Get
            Return _moduleConfiguration
        End Get
        Set(ByVal Value As clsModuleSettings)
            _moduleConfiguration = Value
        End Set
    End Property

    Public ReadOnly Property ModuleId() As Integer
        Get
            Return _moduleConfiguration.ModuleId
        End Get
    End Property

    Public Property SiteId() As Integer
        Get
            Return _siteId
        End Get
        Set(ByVal Value As Integer)
            _siteId = Value
        End Set
    End Property

    Public ReadOnly Property CacheKey() As String
        Get
            Return "Key:" & Me.GetType().ToString() & Me.ModuleId & clsSiteSecurity.IsInRoles(_moduleConfiguration.AuthorizedEditRoles)
        End Get
    End Property

    Protected Overrides Sub CreateChildControls()
        ' Attempt to resolve previously cached content from the ASP.NET Cache
        If _moduleConfiguration.CacheTime > 0 Then
            _cachedOutput = CStr(Context.Cache(CacheKey))
        End If
        ' If no cached content is found, then instantiate and add the portal
        ' module user control into the portal's page server control tree
        If _cachedOutput Is Nothing Then
            MyBase.CreateChildControls()
            Dim [module] As clsSiteModuleControl = CType(Page.LoadControl(_moduleConfiguration.DesktopSrc), clsSiteModuleControl)
            [module].ModuleConfiguration = Me.ModuleConfiguration
            [module].SiteId = Me.SiteId
            Me.Controls.Add([module])
        End If
    End Sub

    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
        ' If no caching is specified, render the child tree and return 
        If _moduleConfiguration.CacheTime = 0 Then
            MyBase.Render(output)
            Return
        End If
        ' If no cached output was found from a previous request, render
        ' child controls into a TextWriter, and then cache the results
        ' in the ASP.NET Cache for future requests.
        If _cachedOutput Is Nothing Then
            Dim tempWriter = New StringWriter
            MyBase.Render(New HtmlTextWriter(tempWriter))
            _cachedOutput = tempWriter.ToString()
            Context.Cache.Insert(CacheKey, _cachedOutput, Nothing, DateTime.Now.AddSeconds(_moduleConfiguration.CacheTime), TimeSpan.Zero)
        End If
        output.Write(_cachedOutput)
    End Sub

End Class
