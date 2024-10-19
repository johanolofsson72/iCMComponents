
#Region " Imports "

Imports System.Runtime.InteropServices

#End Region

Public Class cDHBrowseForFolder

#Region " Delegates "

	Private Delegate Function BrowseCallBack(ByVal hWnd As Integer, ByVal uMsg As Int16, ByVal lParam As Integer, ByVal lpData As Integer) As Int16
	Private Delegate Function EnumChildCallBack(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer

#End Region

#Region " API Constants "

	Private Const BFFM_INITIALIZED As Integer = 1
	Private Const BFFM_SETSELECTION As Integer = &H466
	Private Const BFFM_SELCHANGED As Integer = 2
	Private Const MAX_PATH As Integer = 260
	Private Const BIF_USENEWUI As Integer = &H40
	Private Const BIF_EDITBOX As Integer = &H10
	Private Const WS_DISABLED As Integer = &H8000000
	Private Const GWL_STYLE As Integer = (-16)
	Private Const BM_SETSTYLE As Integer = &HF4

#End Region

#Region " API Structures "

	<StructLayout(LayoutKind.Sequential)> Private Structure BROWSEINFO
		Public hWndOwner As Integer
		Public pIDLRoot As Integer
		Public pszDisplayName As String
		Public lpszTitle As String
		Public ulFlags As Integer
		Public lpfnCallback As BrowseCallBack
		Public lParam As Integer
		Public iImage As Integer
	End Structure

#End Region

#Region " Declarations "

	Private Declare Sub CoTaskMemFree Lib "ole32.dll" (ByVal hMem As Integer)
	Private Declare Function SHBrowseForFolder Lib "shell32" (ByRef lpbi As BROWSEINFO) As Integer
	Private Declare Function SHGetPathFromIDList Lib "shell32" (ByVal pidList As Integer, ByVal lpBuffer As String) As Integer
	Private Declare Function SHGetSpecialFolderLocation Lib "shell32" (ByVal hWndOwner As Integer, ByVal nFolder As Integer, ByRef ListId As Integer) As Integer
	Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, <MarshalAsAttribute(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer
	Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Integer, ByVal hWnd2 As Integer, ByVal lpsz1 As String, ByVal lpsz2 As String) As Integer
	Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
	Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	Private Declare Function lstrlen Lib "kernel32" Alias "lstrlenA" (ByVal lpString As String) As Integer
	Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
	Private Declare Function SetWindowText Lib "user32" Alias "SetWindowTextA" (ByVal hwnd As Integer, ByVal lpString As String) As Integer
	Private Declare Function EnumChildWindows Lib "user32" (ByVal hWndParent As Integer, ByVal lpEnumFunc As EnumChildCallBack, ByVal lParam As Integer) As Integer
	Private Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Integer, ByVal lpClassName As String, ByVal nMaxCount As Integer) As Integer

#End Region

#Region " Enumerations "

	Public Enum BROWSE_TYPE
		BrowseForFolders = &H1
		BrowseForComputers = &H1000
		BrowseForPrinters = &H2000
		BrowseForEverything = &H4000
	End Enum
	Public Enum FOLDER_TYPE
		CSIDL_BITBUCKET = 10
		CSIDL_CONTROLS = 3
		CSIDL_DESKTOP = 0
		CSIDL_DRIVES = 17
		CSIDL_FONTS = 20
		CSIDL_NETHOOD = 18
		CSIDL_NETWORK = 19
		CSIDL_PERSONAL = 5
		CSIDL_PRINTERS = 4
		CSIDL_PROGRAMS = 2
		CSIDL_RECENT = 8
		CSIDL_SENDTO = 9
		CSIDL_STARTMENU = 11
	End Enum

#End Region

#Region " Member Variables "

	Private m_sStartDir As String = ""
	Private m_bUseNewUI As Boolean = True
	Private m_bEditBox As Boolean = True
	Private m_hWndDialog As Integer = 0
	Private m_hWndStatic As Integer = 0

#End Region

#Region " Events "

	Public Event SelectionChanged(ByVal sFolder As String, ByRef bDisable As Boolean, ByRef sMessage As String)

#End Region

#Region " Properties "

	Public Property StartDir() As String
		Get
			StartDir = m_sStartDir
		End Get
		Set(ByVal Value As String)
			m_sStartDir = Value
		End Set
	End Property
	Public Property UseNewUI() As Boolean
		Get
			UseNewUI = m_bUseNewUI
		End Get
		Set(ByVal Value As Boolean)
			m_bUseNewUI = Value
		End Set
	End Property
	Public Property EditBox() As Boolean
		Get
			EditBox = m_bEditBox
		End Get
		Set(ByVal Value As Boolean)
			m_bEditBox = Value
		End Set
	End Property

#End Region

#Region " Procedures "

	Private Function BrowseCallbackProc(ByVal hWnd As Integer, ByVal uMsg As Int16, ByVal lParam As Integer, ByVal lpData As Integer) As Int16
		Dim sPath As String = ""
		Dim iRet As Integer
		Dim bDisable As Boolean = False
		Dim sMessage As String = ""

		Select Case uMsg

			'the dialog has been created
		Case BFFM_INITIALIZED

				'store the dialog handle
				m_hWndDialog = hWnd

				'if a start directory has been specified then set it now
				If Not (m_sStartDir = "") Then
					sPath = m_sStartDir
					Call SendMessage(hWnd, BFFM_SETSELECTION, True, sPath)
				End If

				'a new directory has been selected (not "applied")
			Case BFFM_SELCHANGED

				'populate the string
				sPath = sPath.PadLeft(MAX_PATH)

				'convert the pIDL to a path string
				iRet = SHGetPathFromIDList(lParam, sPath)

				'if we have a valid path then raise the event back to the caller,
				'pass the bDisable flag and Message string by reference so the caller
				'can modify from there
				If Not (iRet = 0) Then

					RaiseEvent SelectionChanged(sPath.Substring(0, lstrlen(sPath)), bDisable, sMessage)

					'enable or disable the ok button (modified by caller)
					SetOK(bDisable)

					'set a new dialog message (modified by caller)
					If sMessage.Length > 0 Then
						SetMessage(sMessage)
					End If
				End If

			Case Else
				'unexpected message
		End Select

	End Function
	Private Function EnumChildProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer
		Dim sClass As String = ""		Dim sText As String = ""		Dim iRet As Integer		'populate the string		sClass = sClass.PadLeft(256, " ")		'get the class name		iRet = GetClassName(hWnd, sClass, 256)		'find the static window that we want by a process of deduction		If sClass.ToUpper.Substring(0, iRet) = "STATIC" Then
			'populate the string
			sText = sText.PadLeft(256, " ")

			'get the text
			GetWindowText(hWnd, sText, 256)

			'remove the trailing and leading spaces
			sText = sText.Trim

			'GetWindowText seems to return a Null Terminated string which we must remove
			'in order to check it
			sText = sText.Substring(0, sText.Length - 1)

			Select Case sText
				Case ""
				Case "Folder:"
				Case "To view any subfolders, click a plus sign above."
				Case Else
					m_hWndStatic = hWnd
			End Select
		End If		'continue enumeration		Return 1	End Function
	Private Function GetOptions() As Integer
		Dim iOpts As Integer = 0

		'add the UseNewUI flag
		If m_bUseNewUI Then
			iOpts = iOpts Or BIF_USENEWUI
		Else
			'remove the UseNewUI flag
			iOpts = iOpts And Not BIF_USENEWUI
		End If

		'add the include EditBox flag
		If m_bEditBox Then
			iOpts = iOpts Or BIF_EDITBOX
		Else
			'remove the include EditBox flag
			iOpts = iOpts And Not BIF_EDITBOX
		End If

		Return iOpts
	End Function
	Private Sub SetOK(ByVal bDisable As Boolean)
		Dim iOK As Integer
		Dim iStyle As Integer

		'if dialog initialized
		If m_hWndDialog Then

			'get a handle to the ok button
			iOK = FindWindowEx(m_hWndDialog, 0, "Button", "OK")

			'get it's style props
			iStyle = GetWindowLong(iOK, GWL_STYLE)

			'set as disabled
			If bDisable Then
				iStyle = iStyle Or WS_DISABLED
			Else
				'set as enabled
				iStyle = iStyle And Not WS_DISABLED
			End If

			'add the new style
			SetWindowLong(iOK, GWL_STYLE, iStyle)

			'redraw
			SendMessage(iOK, BM_SETSTYLE, 0, 0)
		End If
	End Sub
	Private Sub SetMessage(ByVal sMessage As String)

		'if dialog initialized
		If m_hWndDialog Then

			'get a handle to the static box
			EnumChildWindows(m_hWndDialog, AddressOf EnumChildProc, 0)

			'set the new text
			SetWindowText(m_hWndStatic, sMessage)

		End If
	End Sub

#End Region

#Region " Methods "

	Public Function BrowseForFolder(ByVal hWndOwner As Integer, ByVal sMessage As String, ByVal Browse As BROWSE_TYPE, ByVal RootFolder As FOLDER_TYPE) As String
		Dim tBI As BROWSEINFO
		Dim lpIDList As Integer
		Dim res As Integer
		Dim sPath As String
		Dim RootID As Integer
		Dim iOpts As Integer

		'Get pidl of special folder
		SHGetSpecialFolderLocation(hWndOwner, RootFolder, RootID)

		'set window handle
		tBI.hWndOwner = hWndOwner

		'get old school string pointer
		tBI.lpszTitle = sMessage

		'set browse options
		iOpts = GetOptions()

		tBI.ulFlags = Browse Or iOpts

		'set callback procedure
		tBI.lpfnCallback = AddressOf BrowseCallbackProc

		'set root pidl
		If RootID <> 0 Then tBI.pIDLRoot = RootID

		'launch dialog
		lpIDList = SHBrowseForFolder(tBI)

		' a selection was made
		If lpIDList <> 0 Then

			'pad return buffer
			sPath = New String(" ", MAX_PATH)

			'resolve path
			res = SHGetPathFromIDList(lpIDList, sPath)

			'release win32/COM memory
			Call CoTaskMemFree(lpIDList)

			'clean up path
			sPath = sPath.Replace(Chr(0), "").Trim

			'standardize return path (I don't know if you have to do this anymore)
			If Right(sPath, 1) <> "\" Then
                'sPath = sPath.Concat(sPath, "\")
			End If

		End If

		'return folder (or null if cancel)
		Return sPath
	End Function

#End Region

End Class
