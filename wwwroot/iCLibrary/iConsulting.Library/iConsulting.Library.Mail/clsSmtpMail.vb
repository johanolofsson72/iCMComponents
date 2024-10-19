
Imports System.Text
Imports System.Web.mail
Imports System.IO

Namespace Mail

    Public Class clsSmtpMail


        Const CLASSNAME = "[Namespace::iConsulting.Library.Mail][ClassLibrary::iCLibrary][Class::clsSmtpMail]"

        Private m_sServer As String
        Private m_sMailFrom As String
        Private m_sMailTo As String
        Private m_sSubject As String
        Private m_sBody As String
        Private m_iFormat As Integer    ' 0 = Text   1 = Html

        Private m_sError As String
        Private m_bHasError As Boolean
        Private m_MailAttachments As New ArrayList

#Region " Properties "

        Public Property MailServer() As String
            Get
                Return Me.m_sServer
            End Get
            Set(ByVal Value As String)
                Me.m_sServer = Value
            End Set
        End Property

        Public Property MailFrom() As String
            Get
                Return Me.m_sMailFrom
            End Get
            Set(ByVal Value As String)
                Me.m_sMailFrom = Value
            End Set
        End Property

        Public Property MailTo() As String
            Get
                Return Me.m_sMailTo
            End Get
            Set(ByVal Value As String)
                Me.m_sMailTo = Value
            End Set
        End Property

        Public Property MailSubject() As String
            Get
                Return Me.m_sSubject
            End Get
            Set(ByVal Value As String)
                Me.m_sSubject = Value
            End Set
        End Property

        Public Property MailBody() As String
            Get
                Return Me.m_sBody
            End Get
            Set(ByVal Value As String)
                Me.m_sBody = Value
            End Set
        End Property

        Public Property MailFormat() As Integer
            Get
                Return Me.m_iFormat
            End Get
            Set(ByVal Value As Integer)
                Me.m_iFormat = Value
            End Set
        End Property

        Public Shadows ReadOnly Property GetError() As String
            Get
                Return Me.m_sError
            End Get
        End Property

        Public Shadows ReadOnly Property HasError() As Boolean
            Get
                Return Me.m_bHasError
            End Get
        End Property

#End Region

#Region " Constructors "

        Public Sub New()
            Me.m_sServer = String.Empty
            Me.m_sMailFrom = String.Empty
            Me.m_sMailTo = String.Empty
            Me.m_sSubject = String.Empty
            Me.m_sBody = String.Empty
            Me.m_iFormat = 0
        End Sub

#End Region

#Region " Private Functions "

        Private Sub AddErrorData(ByRef sError As String, ByVal lNumber As String, ByVal lSeverity As String, ByVal sSource As String, ByVal sMsg As String)
            Try
                sError += "#" & lNumber & "|" & lSeverity & "|" & sSource & "|" & sMsg
                Me.m_bHasError = True
            Catch
            End Try
        End Sub

        Private Function CheckServer() As Boolean
            Try
                If Me.m_sServer.Length = 0 Then
                    Throw New Exception("Server.Length = 0")
                Else
                    Return True
                End If
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Private Function CheckMailFrom() As Boolean
            Try
                If Me.m_sMailFrom.Length = 0 Then
                    Throw New Exception("MailFrom.Length = 0")
                Else
                    Return True
                End If
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Private Function CheckMailTo() As Boolean
            Try
                If Me.m_sMailTo.Length = 0 Then
                    Throw New Exception("MailTo.Length = 0")
                Else
                    Return True
                End If
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Private Function CheckSubject() As Boolean
            Try
                If Me.m_sSubject.Length = 0 Then
                    Throw New Exception("Subject.Length = 0")
                Else
                    Return True
                End If
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Private Function CheckBody() As Boolean
            Try
                If Me.m_sBody.Length = 0 Then
                    Throw New Exception("Body.Length = 0")
                Else
                    Return True
                End If
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Private Function CheckFormat() As Boolean
            Try
                Select Case Me.m_iFormat
                    Case 0
                        Return True
                    Case 1
                        Return True
                    Case Else
                        Throw New Exception("Format <> 0 Or 1")
                End Select
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Private Function SendMail() As Boolean
            Try
                Dim CDonts As New MailMessage
                CDonts.From = Me.m_sMailFrom
                CDonts.To = Me.m_sMailTo
                CDonts.Subject = Me.m_sSubject
                CDonts.Body = Me.m_sBody
                CDonts.BodyFormat = Me.m_iFormat
                For Each File As String In Me.m_MailAttachments
                    Dim MA As New MailAttachment(File)
                    CDonts.Attachments.Add(MA)
                Next
                SmtpMail.SmtpServer = Me.m_sServer
                SmtpMail.Send(CDonts)
                Return True
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

#End Region

#Region " Public Functions "

        Public Function Send() As Boolean
            Const FUNCTIONNAME = CLASSNAME & "[Function::Send]"
            Try
                If Not Me.CheckServer Then Throw New Exception
                If Not Me.CheckMailFrom Then Throw New Exception
                If Not Me.CheckMailTo Then Throw New Exception
                If Not Me.CheckSubject Then Throw New Exception
                If Not Me.CheckBody Then Throw New Exception
                If Not Me.CheckFormat Then Throw New Exception
                If Not Me.SendMail Then Throw New Exception
                Return True
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
                Return False
            End Try
        End Function

        Public Sub AddAttachment(ByVal File As System.IO.FileInfo)
            Const FUNCTIONNAME = CLASSNAME & "[Subrutine::AddAttachment]"
            Try
                'Me.m_MailAttachments.Add(New XItem(File))
                Me.m_MailAttachments.Add(File.FullName)
            Catch ex As Exception
                Me.AddErrorData(Me.m_sError, "0000", ex.StackTrace, ex.Source, ex.Message)
            End Try
        End Sub

#End Region

    End Class

    'Public Class XItem
    '    Public File As System.IO.FileInfo
    '    Public Sub New(ByVal File As System.IO.FileInfo)
    '        File = File
    '    End Sub
    'End Class

End Namespace
