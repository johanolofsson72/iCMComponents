Public Class clsModuleItem

    Implements IComparable

    Private _moduleOrder As Integer
    Private _title As String
    Private _pane As String
    Private _id As Integer
    Private _defId As Integer


    Public Property ModuleOrder() As Integer
        Get
            Return _moduleOrder
        End Get
        Set(ByVal Value As Integer)
            _moduleOrder = Value
        End Set
    End Property


    Public Property ModuleTitle() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property


    Public Property FieldName() As String
        Get
            Return _pane
        End Get
        Set(ByVal Value As String)
            _pane = Value
        End Set
    End Property


    Public Property ModuleId() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property


    Public Property ModuleDefId() As Integer
        Get
            Return _defId
        End Get
        Set(ByVal Value As Integer)
            _defId = Value
        End Set
    End Property


    Protected Overridable Function CompareTo(ByVal value As Object) As Integer Implements IComparable.CompareTo
        If value Is Nothing Then
            Return 1
        End If
        Dim compareOrder As Integer = CType(value, clsModuleItem).ModuleOrder
        If Me.ModuleOrder = compareOrder Then Return 0
        If Me.ModuleOrder < compareOrder Then Return -1
        If Me.ModuleOrder > compareOrder Then Return 1
        Return 0
    End Function

End Class
