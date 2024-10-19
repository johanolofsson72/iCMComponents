Imports System.ComponentModel
Namespace Data

    Friend Class FieldInfo
        '
        ' This class stores information about a single column exposed by the JoinViewRow
        ' It is parsed in the JoinView constructor
        '
        Public FieldName As String      ' name in base table/related table
        Public RelationName As String   ' empty string if field resides in base table
        Public FieldAlias As String     ' name revealed to others
        Public Type As Type             ' data type of field
    End Class

    Public Class clsJoinView
        '
        ' This class, and the related classes in this file, form a replacement for System.Data.DataView
        ' that can be used in a Windows Form DataGrid control to display and edit fields from a DataTable
        ' and also display fields from related parent tables. It is not really intended for use outside
        ' this scenario since the standard DataView and hierarchical binding will suffice. It uses a
        ' DataView internally as the root source of data. An ArrayList is also used to provide support
        ' for sorting (specifically to allow support for fields that aren't in the base DataView).
        '
        ' Specific functionality supported:
        '  - Specifying a limited subset of fields to expose
        '  - Specifying field display order
        '  - Specifying an alias for field names
        '  - Specifying fields in related parent tables for read-only use - i.e. not editable
        '  - Sorting by clicking the DataGrid column header
        '  - Row delete - you can turn this off
        '  - Row add - you can turn this off
        '  - Row edit (with undo) - you can turn this off
        '  - Searching via the Find method
        '  - Filtering rows - done in the constructor - further filtering is not supported
        '  - Sorting the rows - once a sort has been performed,
        '    there is not way to undo it other than sort on a different column
        '  - Enumerating the list
        '
        ' Functionality not supported:
        '  - Filtering the JoinView after it has been constructed
        '  - There is no active filtering. i.e.
        '     - If a record is altered to make it fall outside the original filter,
        '       it will remain in the list rather than be dropped
        '     - If a new record falls outside the original filter,
        '       it will remain in the list rather than be dropped
        '
        Implements IList, ITypedList, IBindingList, IComparer

        Friend Table As DataTable              ' used for schema information and looking up parent rows
        Friend FieldInfo As ArrayList          ' stores parsed field list
        Public JoinViewName As String          ' the name to expose to DataGrid.TableStyles collection
        Friend List As ArrayList               ' stores JoinViewRow objects
        Friend AddNewObject As JoinViewRow     ' stores JoinViewRow that represents the new row (also in List)
        Private SortColumn As Integer = -1     ' unsorted - see caveat in main comment above
        Private SortDir As ListSortDirection = ListSortDirection.Ascending
        Private AllowNewFlag As Boolean        ' we can turn editing on/off
        Private AllowEditFlag As Boolean       ' but only if the underlying DataView allows editing
        Private AllowDeleteFlag As Boolean
        Private AllowSortFlag As Boolean

#Region "Intrinsic methods and properties"

        Public Sub New(ByVal DataTable As DataTable, ByVal FieldList As String, Optional ByVal RowFilter As String = "", Optional ByVal Sort As String = "")
            '
            ' Constructs the JoinView object. Performs the following operations
            '  - Makes sure DataTable is in a DataSet - otherwise we can't do relations and a DataView would serve
            '  - Parses the field list
            '  - Selects sorted/filtered DataRow objects as the basis for data
            '  - Sets initial edit flag state and name for use in DataGrid.TableStyles
            '  - Initializes the ArrayList
            '
            Table = DataTable
            If Table.DataSet Is Nothing Then Throw New InvalidOperationException("DataTable must be part of a DataSet.")
            ParseFieldList(FieldList)
            AllowEditFlag = True
            AllowNewFlag = True
            AllowDeleteFlag = True
            AllowSortFlag = True
            JoinViewName = Table.TableName & "_JoinView"
            List = New ArrayList
            Dim Row As DataRow
            For Each Row In Table.Select(RowFilter, Sort)
                List.Add(New JoinViewRow(Me, Row))
            Next
        End Sub

        Public Overridable Sub OnListChanged(ByVal e As ListChangedEventArgs)
            RaiseEvent ListChanged(Me, e)
        End Sub

        Private Function GetColumnIndex(ByVal ColumnName As String) As Integer
            '
            ' Returns the index/ordinal value of a column name in the FieldInfo ArrayList.
            ' This is required for finding and sorting - both pass in a field name.
            ' Since FieldAlias is what is exposed externally, that's what the routine
            ' must match against and not FieldName.
            '
            Dim Col As Integer
            ColumnName = ColumnName.ToUpper()
            For Col = FieldInfo.Count - 1 To 0 Step -1
                If ColumnName = CType(FieldInfo(Col), FieldInfo).FieldAlias.ToUpper() Then Exit For
            Next
            ' fall-through value will be -1, since we're stepping backwards in the loop, meaning column name not found
            Return Col
        End Function

        Public Property AllowDelete() As Boolean
            '
            ' Can records be deleted - defaults to True in constructor
            '
            Get
                Return AllowDeleteFlag
            End Get
            Set(ByVal Value As Boolean)
                AllowDeleteFlag = Value
            End Set
        End Property

        Public Property AllowEdit() As Boolean
            '
            ' Can records be edited - defaults to True in constructor
            '
            Get
                Return AllowEditFlag
            End Get
            Set(ByVal Value As Boolean)
                AllowEditFlag = Value
            End Set
        End Property

        Public Property AllowNew() As Boolean
            '
            ' Can records be added - defaults to True in constructor
            '
            Get
                Return AllowNewFlag
            End Get
            Set(ByVal Value As Boolean)
                AllowNewFlag = Value
            End Set
        End Property

        Public Property AllowSort() As Boolean
            '
            ' can records be sorted - defaults to True
            '
            Get
                Return AllowSortFlag
            End Get
            Set(ByVal Value As Boolean)
                AllowSortFlag = Value
            End Set
        End Property

        Public Property Sort() As String
            '
            ' Allows you to examine the column currently sorted on and to set it.
            ' The Get method does not return the sort direction.
            ' The Set method assumes Ascending unless explicitly specified with ASC or DESC suffix.
            ' Sorting does not support multiple field names.
            ' You cannot un-sort. Once sorted, always sorted.
            '
            ' Syntax:  fieldname[ ASC|DESC]
            '
            Get
                If SortColumn = -1 Then
                    Return ""
                Else
                    Return CType(FieldInfo(SortColumn), FieldInfo).FieldAlias
                End If
            End Get
            Set(ByVal Value As String)
                If AllowSort = False Then Throw New InvalidOperationException("Sorting is disallowed at this time.")
                If Value = "" Then
                    '
                    ' Do nothing. This JoinView does not support un-sorting.
                    '
                ElseIf InStr(Value, ",") > 0 Then
                    Throw New InvalidOperationException("The Sort property only accepts single field names.")
                Else
                    Value = Value.ToUpper().Trim()
                    SortDir = ListSortDirection.Ascending   ' the default
                    If Value.EndsWith(" ASC") Then
                        SortDir = ListSortDirection.Ascending
                        Value = Value.Substring(0, Value.Length - 4).Trim()
                    ElseIf Value.EndsWith(" DESC") Then
                        SortDir = ListSortDirection.Descending
                        Value = Value.Substring(0, Value.Length - 5).Trim()
                    End If
                    Dim Col As Integer = GetColumnIndex(Value)
                    If Col = -1 Then Throw New ArgumentException("Column '" & Value & "' does not exist in the JoinView.")
                    SortColumn = Col
                    List.Sort(Me)
                    OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, 0))
                End If
            End Set
        End Property

        Private Function CompareValues(ByVal x As Object, ByVal y As Object) As Integer
            '
            ' Compares two objects and takes DBNull.Value into account. DBNull.Value is smaller than
            ' any other value.
            '
            If x Is DBNull.Value Then
                If y Is DBNull.Value Then
                    Return 0
                Else
                    Return -1
                End If
            Else
                If y Is DBNull.Value Then
                    Return 1
                ElseIf x < y Then
                    Return -1
                ElseIf x = y Then
                    Return 0
                Else
                    Return 1
                End If
            End If
        End Function

        Public Function Find(ByVal ColumnName As String, ByVal Key As Object) As Integer
            '
            ' Find will search any column. If it's the sorted column, we can optimize by
            ' using ArrayList.BinarySearch. Otherwise, a sequential search is performed.
            ' The index of the first match is returned.
            '
            Dim Col As Integer = GetColumnIndex(ColumnName)
            If Col = -1 Then Throw New ArgumentException("Column '" & ColumnName & "' does not exist in the JoinView.")
            If Col = SortColumn Then
                Return List.BinarySearch(Key, Me)
            Else
                '
                ' Sequential search if ColumnName isn't the sorted column.
                ' If sorting is turned off, code will always fall through to this section.
                '
                Dim I As Integer
                For I = 0 To List.Count - 1
                    If CompareValues(Key, CType(List(I), JoinViewRow).Item(Col)) = 0 Then Return I
                Next
                Return -1
            End If
        End Function

        Private Sub ParseFieldList(ByVal FieldList As String)
            '
            ' Parses FieldList into FieldInfo objects and adds them to the FieldInfo private member
            '
            ' FieldList syntax: [relationname.]fieldname[ alias],...
            '

            FieldInfo = New ArrayList
            Dim Field As FieldInfo, FieldParts() As String, Fields() As String = FieldList.Split(",")
            Dim I As Integer
            For I = 0 To Fields.Length - 1
                Field = New FieldInfo
                '
                ' Parse FieldAlias
                '
                FieldParts = Fields(I).Trim().Split(" ")
                Select Case FieldParts.Length
                    Case 1
                        ' to be set at the end of the loop
                    Case 2
                        Field.FieldAlias = FieldParts(1)
                    Case Else
                        Throw New ArgumentException("Too many spaces in field definition: '" & Fields(I) & "'.")
                End Select
                '
                ' Parse FieldName and RelationName
                '
                FieldParts = FieldParts(0).Split(".")
                Select Case FieldParts.Length
                    Case 1
                        Field.FieldName = FieldParts(0)
                        Field.Type = Table.Columns(Field.FieldName).DataType
                    Case 2
                        Field.RelationName = FieldParts(0).Trim()
                        Field.FieldName = FieldParts(1).Trim()
                        Field.Type = Table.ParentRelations(Field.RelationName).ParentTable.Columns(Field.FieldName).DataType
                    Case Else
                        Throw New ArgumentException("Invalid field definition: '" & Fields(I) & "'.")
                End Select
                If Field.FieldAlias = "" Then Field.FieldAlias = Field.FieldName
                FieldInfo.Add(Field)
            Next
        End Sub

#End Region

#Region "IList interface implementation"
        '
        ' This Region contains the IList interface implementation
        '

        Public ReadOnly Property SyncRoot() As Object Implements System.Collections.IList.SyncRoot
            '
            ' Used to synchronize multi-threaded access to this class.
            ' JoinView is not inherently threadsafe.
            '
            Get
                Return Me
            End Get
        End Property

        Default Public Property Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
            '
            ' Return the requested JoinViewRow.
            ' Disallow assignments - same s DataView in this respect.
            '
            Get
                Return List(index)
            End Get
            Set(ByVal Value As Object)
                Throw New InvalidOperationException("The Item property is read-only.")
            End Set
        End Property

        Public ReadOnly Property Count() As Integer Implements System.Collections.IList.Count
            '
            ' Retun the number of rows in the List.
            '
            Get
                Return List.Count
            End Get
        End Property

        Public Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
            '
            ' Disallow adding - must use the AddNew method.
            '
            Throw New InvalidOperationException("The list is read-only. You must use the AddNew method instead.")
        End Function

        Public Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
            '
            ' Returns True if the object passed in is a JoinViewRow and is in the List.
            ' The JoinViewRow.Delete method sets JoinViewRow.View to Nothing to prevent false positives.
            '
            If TypeOf value Is JoinViewRow Then
                Return CType(value, JoinViewRow).View Is Me
            End If
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IList.GetEnumerator
            '
            ' Returns an enumerator for JoinViewRow.
            ' This should be all that is required for ASP.NET Web Form binding support, but has not been tested.
            '
            Return List.GetEnumerator()
        End Function

        Public Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf
            '
            ' Returns the position of the passed-in object in the List. Otherwise, returns -1 to
            ' indicate the object is not part of the List.
            '
            If TypeOf value Is JoinViewRow AndAlso CType(value, JoinViewRow).View Is Me Then
                Return List.IndexOf(value)
            Else
                Return -1
            End If
        End Function

        Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
            '
            ' Return True is additions/deletions to the list are not allowed.
            ' TODO: Documentation is not clear whether this just controls Add/Remove/RemoveAt
            '       or whether it affects the AddNew method and other notifications as well.
            '       To be on the safe side, we'll be permissve in allowing it here and throw
            '       exceptions if necessary in other places.
            '
            Get
                Return Not (AllowNew Or AllowDelete)
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
            '
            ' Return True if no modifcations to the list are supported.
            ' TODO: Documentation is not clear whether this applies to setting the Item property
            '       or whether it applies to setting values in a JoinViewRow. To be on the safe side,
            '       we'll assume the latter and throw an exception in IList.Item.Set.
            '
            Get
                Return Not (AllowNew Or AllowEdit Or AllowDelete)
            End Get
        End Property

        Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.IList.IsSynchronized
            '
            ' JoinView is not inherently threadsafe.
            '
            Get
                Return False
            End Get
        End Property

        Public Sub Clear() Implements System.Collections.IList.Clear
            '
            ' Delete all the records in the List and the underlying DataView
            '
            Dim jrv As JoinViewRow
            Do While List.Count > 0
                jrv = CType(List(0), JoinViewRow)
                If Not (jrv Is AddNewObject) Then jrv.BaseRow.Delete()
                jrv.BaseRow = Nothing
                List.RemoveAt(0)
            Loop
            OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, 0))
        End Sub

        Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.IList.CopyTo
            '
            ' Copy JoinViewRow objects from the List to an array.
            '
            List.CopyTo(array, index)
        End Sub

        Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
            '
            ' Disallow this operation since our data comes from elsewhere.
            '
            Throw New InvalidOperationException("The list is read-only. Use the AddNew method.")
        End Sub

        Public Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
            '
            ' Remove the JoinViewRow object from the List and the base DataTable
            '
            RemoveAt(List.IndexOf(value))
        End Sub

        Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
            '
            ' Remove the JoinViewRow object from the List and the base DataTable
            ' If removing the AddNewObject, it has not been added to the DataTable yet.
            '
            If Not AllowDelete Then Throw New InvalidOperationException("Rows cannot be deleted.")
            Dim jrv As JoinViewRow
            jrv = CType(List(index), JoinViewRow)
            If jrv Is AddNewObject Then
                AddNewObject = Nothing
            Else
                jrv.BaseRow.Delete()
            End If
            jrv.BaseRow = Nothing
            jrv.View = Nothing
            List.RemoveAt(index)
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemDeleted, index))
        End Sub
#End Region

#Region "IBindingList interface implementation"
        '
        ' This Region contains the IBindingList interface implementation
        '

        '
        ' The ListChanged event allows the JoinView to notify the CurrencyManager to refresh itself
        '
        Public Event ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs) Implements IBindingList.ListChanged

        Public Function AddNew() As Object Implements IBindingList.AddNew
            '
            ' Gets a new row from the underlying DataTable (but doesn't add it) and creates a JoinViewRow to wrap it.
            ' Adds the JoinViewRow to the ArrayList and stores it in AddNewObject.
            ' CancelEdit calls RemoveAt on the new row. This removes it from the ArrayList. It was never added to the underlying DataTable.
            ' EndEdit adds the new row to the underlying DataTable and sets AddNewObject to Nothing.
            ' AddNewRow is required because EndEdit is called on JoinViewRow objects other
            ' than the new row before adding is complete or cancelled.
            '
            If Not AllowNew Then Throw New InvalidOperationException("AddNew is not allowed.")
            Dim dr As DataRow = Table.NewRow()
            AddNewObject = New JoinViewRow(Me, dr)
            List.Add(AddNewObject)
            OnListChanged(New ListChangedEventArgs(ListChangedType.ItemAdded, List.Count - 1))
            Return AddNewObject
        End Function

        Private Function Find(ByVal [property] As PropertyDescriptor, ByVal key As Object) As Integer Implements IBindingList.Find
            '
            ' Not sure who would call this directly, but redirect to the main Find method.
            '
            Find([property].DisplayName, key)
        End Function

        Private ReadOnly Property AllowEdit2() As Boolean Implements IBindingList.AllowEdit
            '
            ' Redirect to the main AllowEdit method. Need two, since the other is read/write.
            '
            Get
                Return AllowEdit
            End Get
        End Property

        Private ReadOnly Property AllowNew2() As Boolean Implements IBindingList.AllowNew
            '
            ' Redirect to the main AllowNew method. Need two, since the other is read/write.
            '
            Get
                Return AllowNew
            End Get
        End Property

        Private ReadOnly Property AllowDelete2() As Boolean Implements IBindingList.AllowRemove
            '
            ' Redirect to the main AllowDelete method. Need two, since the other is read/write.
            '
            Get
                Return AllowDelete
            End Get
        End Property

        Private ReadOnly Property IsSorted() As Boolean Implements IBindingList.IsSorted
            '
            ' -1 indicates unsorted - though this is a fiction after the first sort has taken place.
            ' Positive number between 0 .. cols-1 indicates sorted
            ' No error handling. We're relying on good code elsewhere not to screw up
            ' and produce a number outside this range. Not much harm either way, though.
            '
            Get
                Return SortColumn <> -1
            End Get
        End Property

        Private ReadOnly Property SortDirection() As ListSortDirection Implements IBindingList.SortDirection
            '
            ' Return sort direction. If the list isn't sorted, returns the last value it had.
            '
            Get
                Return SortDir
            End Get
        End Property

        Private ReadOnly Property SortProperty() As PropertyDescriptor Implements IBindingList.SortProperty
            '
            ' Returns a JoinViewRowPropertyDescriptor for the sorted column.
            ' If the list is unsorted, returns Nothing.
            '
            Get
                If SortColumn = -1 Then
                    Return Nothing
                Else
                    Dim Info As FieldInfo = FieldInfo(SortColumn)
                    Return New JoinViewRowPropertyDescriptor(Info.FieldAlias, SortColumn, System.Type.GetType(Info.Type.FullName), Info.RelationName <> "")
                End If
            End Get
        End Property

        Private ReadOnly Property SupportsChangeNotification() As Boolean Implements IBindingList.SupportsChangeNotification
            '
            ' JoinView does raise the ListChanged event.
            '
            Get
                Return True
            End Get
        End Property

        Private ReadOnly Property SupportsSearching() As Boolean Implements IBindingList.SupportsSearching
            '
            ' Via the Find method. This is always available.
            '
            Get
                Return True
            End Get
        End Property

        Private ReadOnly Property SupportsSorting() As Boolean Implements IBindingList.SupportsSorting
            '
            ' Via the ArrayList.Sort method and IComparer implementation. Always available.
            '
            Get
                Return True
            End Get
        End Property

        Private Sub AddIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.AddIndex
            '
            ' do nothing - JoinView doesn't use indices but we won't throw an exception either
            '
        End Sub

        Private Sub ApplySort(ByVal [property] As PropertyDescriptor, ByVal direction As ListSortDirection) Implements IBindingList.ApplySort
            '
            ' Sets and SortDir and Sort - Sort does all the work
            '
            If direction = ListSortDirection.Ascending Then
                Sort = [property].DisplayName
            Else
                Sort = [property].DisplayName & " DESC"
            End If

        End Sub

        Private Sub RemoveIndex(ByVal [property] As PropertyDescriptor) Implements IBindingList.RemoveIndex
            '
            ' do nothing - JoinView doesn't use indices - but don't throw an exception either
            '
        End Sub

        Private Sub RemoveSort() Implements IBindingList.RemoveSort
            '
            ' Sets and SortDir and Sort - Sort does all the work
            '
            Sort = ""
        End Sub
#End Region

#Region "ITypedList interface implementation"
        '
        ' ITypedList interface implementation
        '

        Private Function GetItemProperties(ByVal listaccessors() As PropertyDescriptor) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            '
            ' Returns a JoinViewRowPropertyDescriptor for each column in FieldInfo.
            ' This allows binding to be done on a collection instead of on properties.
            '
            Dim PropDesc(Me.FieldInfo.Count - 1) As JoinViewRowPropertyDescriptor
            Dim I As Integer, Info As FieldInfo
            For I = 0 To PropDesc.Length - 1
                Info = Me.FieldInfo(I)
                PropDesc(I) = New JoinViewRowPropertyDescriptor(Info.FieldAlias, I, System.Type.GetType(Info.Type.FullName), Info.RelationName <> "")
            Next
            Return New PropertyDescriptorCollection(PropDesc)
        End Function

        Private Function GetListName(ByVal listAccessors() As PropertyDescriptor) As String Implements ITypedList.GetListName
            '
            ' This value is used by the DataGrid to see if there's an existing TableStyle it can use.
            ' Not as relevant as with a regular DataView, since you can limit and/or rename the field names in the constructor.
            '
            Return JoinViewName
        End Function

#End Region

#Region "IComparer interface implementation"
        '
        ' IComparer interface implementation
        '

        Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            '
            ' Used to implement our custom Sort routine that handles NULL values.
            ' NULL values are sorted prior to all other values (except other NULL values - they compare equal)
            ' SortDir is used to flip the comparison in order to perform a descending sort.
            '
            ' The routine contains conditional conversion because:
            ' - The Sort method passes in JoinViewRow objects.
            ' - The ArrayList.BinarySearch passes in a JoinViewRow and an Object.
            '
            Dim ReturnVal As Integer
            Dim xValue As Object, yValue As Object
            If TypeOf x Is JoinViewRow Then
                xValue = CType(x, JoinViewRow).Item(SortColumn)
            Else
                xValue = x
            End If
            If TypeOf y Is JoinViewRow Then
                yValue = CType(y, JoinViewRow).Item(SortColumn)
            Else
                yValue = y
            End If
            ReturnVal = CompareValues(xValue, yValue)
            If SortDir = ListSortDirection.Descending Then ReturnVal = -ReturnVal
            Return ReturnVal
        End Function

#End Region

    End Class

    Public Class JoinViewRow
        '
        ' This class represents a single row of the JoinView.
        '
        ' The ICustomTypeDescriptor interface allows binding to occur on a collection as opposed to properties.
        ' This makes it more flexible - able to change columns at run-time as opposed to design-time.
        '
        ' The IEditableObject interface allows the current edit or addnew operation to be canceled via the ESC key.
        ' If the row is a new row, then CancelEdit deletes it from the ArrayList.
        '

        Implements ICustomTypeDescriptor, IEditableObject

        Friend View As clsJoinView         ' needs a reference back to its container object
        Friend BaseRow As DataRow       ' contains a copy of the corresponding DataRow of the base DataTable

        Public Sub New(ByVal JoinView As clsJoinView, ByVal Record As DataRow)
            '
            ' Constructs the JoinViewRow object.
            ' Assigns member variables.
            '
            View = JoinView
            BaseRow = Record
        End Sub

        Public Property Item(ByVal columnIndex As Integer) As Object
            '
            ' Returns and sets a value of a column indicated by columnIndex.
            ' The row is in the BaseRow member variable.
            ' If column is in a related DataTable, then the Get method traverses the relation and retrieves the value.
            '
            Get
                Dim Info As FieldInfo = View.FieldInfo(columnIndex)
                If Info.RelationName <> "" Then
                    Try
                        Return BaseRow.GetParentRow(Info.RelationName)(Info.FieldName)
                    Catch
                        Return DBNull.Value
                    End Try
                Else
                    Return BaseRow(Info.FieldName)
                End If
            End Get
            Set(ByVal Value As Object)
                Dim info As FieldInfo = View.FieldInfo(columnIndex)
                If info.RelationName <> "" Then Throw New InvalidOperationException("Cannot assign a value to read-only column '" & info.FieldAlias & "'.")
                BaseRow(info.FieldName) = Value
            End Set
        End Property

        Public Sub Delete()
            '
            ' Calls JoinView.IList.Remove
            '
            View.Remove(Me)
        End Sub

#Region "ICustomTypeDescriptor interface implementation"
        '
        ' ICustomTypeDescriptor interface implementation
        ' This interface is required to make the JoinViewRow appear as if it has dynamic properties.
        ' It does this by generating accessors at run-time that redirect calls to the Item collection.
        '

        Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
            '
            ' Columns have no special attributes.
            '
            Return New System.ComponentModel.AttributeCollection(Nothing)
        End Function

        Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
            '
            ' Return a name the calling application can use to match against.
            ' For example, the DataGrid.TableStyles collection.
            '
            Return View.JoinViewName
        End Function

        Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
            '
            ' Not necessary for this scenario
            '
            Return Nothing
        End Function

        Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
            '
            ' Not necessary for this scenario
            '
            Return Nothing
        End Function

        Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
            '
            ' No default event - this is for class designers
            '
            Return Nothing
        End Function

        Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
            '
            ' No default property - this is for class designers
            '
            Return Nothing
        End Function

        Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
            '
            ' No special editors - this is for class designers
            '
            Return Nothing
        End Function

        Public Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
            '
            ' No events - this is for class designers
            '
            Return New System.ComponentModel.EventDescriptorCollection(Nothing)
        End Function

        Public Function GetEvents2() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
            '
            ' No events - this is for class designers
            '
            Return New System.ComponentModel.EventDescriptorCollection(Nothing)
        End Function

        Public Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
            '
            ' Gets a collection of property descriptors - the JoinViewRowPropertyDesriptor redirects back to a collection
            '
            Return GetProperties2()
        End Function

        Public Function GetProperties2() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
            '
            ' Gets a collection of property descriptors - the JoinViewRowPropertyDesriptor redirects back to a collection
            ' Fields from related DataTables are treated as if they are read-only properties.
            '
            Dim PropDesc(View.FieldInfo.Count - 1) As JoinViewRowPropertyDescriptor
            Dim I As Integer, Info As FieldInfo
            For I = 0 To PropDesc.Length - 1
                Info = View.FieldInfo(I)
                PropDesc(I) = New JoinViewRowPropertyDescriptor(Info.FieldAlias, I, System.Type.GetType(Info.Type.FullName), Info.RelationName <> "")
            Next
            Return New PropertyDescriptorCollection(PropDesc)
        End Function

        Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
            '
            ' Returns the JoinViewRow the descriptors were generated from.
            '
            Return Me
        End Function
#End Region

#Region "IEditableObject interface implementation"
        '
        ' IEditableObject interface implementation
        '

        Public Sub BeginEdit() Implements IEditableObject.BeginEdit
            '
            ' Let the base DataRow maintain state since fields from related DataTables are read-only.
            '
            BaseRow.BeginEdit()
        End Sub

        Public Sub CancelEdit() Implements IEditableObject.CancelEdit
            '
            ' Let the base DataRow maintain state since fields from related DataTables are read-only.
            '
            BaseRow.CancelEdit()
            If Me Is View.AddNewObject Then
                View.Remove(Me)
            End If
        End Sub

        Public Sub EndEdit() Implements IEditableObject.EndEdit
            '
            ' Let the base DataRow maintain state since fields from related DataTables are read-only.
            '
            BaseRow.EndEdit()
            If Me Is View.AddNewObject Then
                View.AddNewObject = Nothing
                View.Table.Rows.Add(BaseRow)
            End If
        End Sub
#End Region

    End Class

    Public Class JoinViewRowPropertyDescriptor   ' return this from JoinView
        '
        ' The JoinViewRowPropertyDescriptor contains an accessor for a property of a JoinViewRow object.
        ' This allows the JoinViewRow to dynamically generate a bindable property list at run-time
        ' and redirect the calls back to the Item collection.
        '

        Inherits System.ComponentModel.PropertyDescriptor

        Private ColType As Type
        Private ColIndex As Integer
        Private ColIsReadOnly As Boolean

        Public Sub New(ByVal ColumnName As String, ByVal ColumnIndex As Integer, ByVal ColumnType As Type, ByVal ColumnIsReadOnly As Boolean)
            '
            ' Construct the property descriptor
            '
            MyBase.New(ColumnName, Nothing)
            ColIndex = ColumnIndex
            ColType = ColumnType
            ColIsReadOnly = ColumnIsReadOnly
        End Sub

        Public Overrides Function GetValue(ByVal component As Object) As Object
            '
            ' Databound controls call this method to read a column from a particular JoinViewRow.
            ' Uses member variables to get the correct element from the Item collection.
            '
            Return CType(component, JoinViewRow).Item(ColIndex)
        End Function

        Public Overrides ReadOnly Property ComponentType() As System.Type
            '
            ' Returns the type of the JoinViewRow
            '
            Get
                Return GetType(JoinViewRow)
            End Get
        End Property

        Public Overrides ReadOnly Property PropertyType() As System.Type
            '
            ' Lets the bound control know the data type of the column.
            '
            Get
                Return ColType
            End Get
        End Property

        Public Overrides Sub ResetValue(ByVal component As Object)
            '
            ' JoinViewRow does not support default values for fields
            '
        End Sub

        Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
            '
            ' Databound controls call this method to write to a column from a particular JoinViewRow.
            ' Uses member variables to get the correct element from the Item collection.
            '
            CType(component, JoinViewRow).Item(ColIndex) = value
        End Sub

        Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
            '
            ' JoinViewRow does not support default values for fields
            '
            Return False
        End Function

        Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
            '
            ' This is a designer property - not supproted in this scenario
            '
            Return False
        End Function

        Public Overrides ReadOnly Property IsReadOnly() As Boolean
            '
            ' Lets the bound control know if it can update the column.
            '
            Get
                Return ColIsReadOnly
            End Get
        End Property
    End Class

End Namespace