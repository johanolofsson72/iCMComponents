Public Class clsFTP

    Private WithEvents ChilkatFTP1 As New CHILKATFTPLib.ChilkatFTPClass
    
    Private m_Hostname As String
    Private m_Username As String
    Private m_Password As String
    Private m_FTP As Long

    Public WriteOnly Property Hostname() As String
        Set(ByVal Value As String)
            Me.m_HostName = Value
        End Set
    End Property

    Public WriteOnly Property Username() As String
        Set(ByVal Value As String)
            Me.m_UserName = Value
        End Set
    End Property

    Public WriteOnly Property Password() As String
        Set(ByVal Value As String)
            Me.m_Password = Value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal Hostname As String, ByVal Username As String, ByVal Password As String)
        Me.Hostname = HostName
        Me.Username = UserName
        Me.Password = Password
    End Sub

    Public Function PutFile(ByVal LocalFileName As String, ByVal RemoteDir As String, ByVal RemoteFileName As String) As Boolean
        If Not Connect() Then
            Return False
        Else
            If Len(RemoteDir) > 0 Then ChilkatFTP1.ChangeRemoteDir(RemoteDir)
            Me.m_FTP = ChilkatFTP1.PutFile(LocalFileName, RemoteFileName)
            If (Me.m_FTP = 0) Then
                Call Disconnect()
                Return False
            Else
                Call Disconnect()
                Return True
            End If
        End If
    End Function

    Public Function PutFiles(ByVal LocalDir As String, ByVal RemoteDir As String) As Boolean
        If Not Connect() Then
            Return False
        Else
            If Len(RemoteDir) > 0 Then ChilkatFTP1.ChangeRemoteDir(RemoteDir)
            Me.m_FTP = ChilkatFTP1.MPutFiles(LocalDir)
            If (Me.m_FTP = 0) Then
                Call Disconnect()
                Return False
            Else
                Call Disconnect()
                Return True
            End If
        End If
    End Function

    Public Function PutPDFFiles(ByVal LocalDir As String, ByVal RemoteDir As String) As Boolean
        If Not Connect() Then
            Return False
        Else
            If Len(RemoteDir) > 0 Then ChilkatFTP1.ChangeRemoteDir(RemoteDir)
            Me.m_FTP = ChilkatFTP1.MPutFiles(LocalDir & "*.pdf")
            If (Me.m_FTP = 0) Then
                Call Disconnect()
                Return False
            Else
                Call Disconnect()
                Return True
            End If
        End If
    End Function

    Public Function GetFile(ByVal RemoteDir As String, ByVal RemoteFileName As String, ByVal LocalFileName As String) As Boolean
        If Not Connect() Then
            Return False
        Else
            If Len(RemoteDir) > 0 Then ChilkatFTP1.ChangeRemoteDir(RemoteDir)
            Me.m_FTP = ChilkatFTP1.GetFile(RemoteFileName, LocalFileName)
            If (Me.m_FTP = 0) Then
                Call Disconnect()
                Return False
            Else
                Call Disconnect()
                Return True
            End If
        End If
    End Function

    Public Function GetFiles(ByVal RemoteDir As String, ByVal LocalDir As String) As Boolean
        If Not Connect() Then
            Return False
        Else
            If Len(RemoteDir) > 0 Then ChilkatFTP1.ChangeRemoteDir(RemoteDir)
            Me.m_FTP = ChilkatFTP1.MGetFiles(RemoteDir & "/*.*", LocalDir)
            If (Me.m_FTP = 0) Then
                Call Disconnect()
                Return False
            Else
                Call Disconnect()
                Return True
            End If
        End If
    End Function

    Private Function Connect() As Boolean
        ChilkatFTP1.Hostname = Me.m_Hostname
        ChilkatFTP1.Username = Me.m_Username
        ChilkatFTP1.Password = Me.m_Password
        Me.m_FTP = ChilkatFTP1.Connect()
        If (Me.m_FTP = 0) Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Disconnect()
        ChilkatFTP1.Disconnect()
        'ChilkatFTP1.SaveXmlLog("log.xml")
        Me.m_FTP = 0
    End Sub

End Class
