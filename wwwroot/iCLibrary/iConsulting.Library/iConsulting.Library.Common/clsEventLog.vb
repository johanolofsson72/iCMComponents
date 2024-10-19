Namespace Common

    Public Class EventLogEntry
        Public Sub New(ByVal ex As Exception, ByVal sAssembly As String, ByVal Routine As String)
            System.Diagnostics.EventLog.WriteEntry(sAssembly, ex.GetType().ToString() & "occured in " & Routine & "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase & "\r\nCaller: " & System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " & ex.StackTrace, EventLogEntryType.Error)
        End Sub
    End Class

End Namespace
