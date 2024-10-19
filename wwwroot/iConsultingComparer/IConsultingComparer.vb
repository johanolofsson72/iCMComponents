Public Class IConsultingComparer : Implements System.Collections.IComparer
    Function Compare(ByVal x As [Object], ByVal y As [Object]) As Integer Implements System.Collections.IComparer.Compare
        If IsNumeric(x) And IsNumeric(y) Then
            Return IIf((Val(x) > Val(y)), 1, IIf((Val(x) < Val(y)), -1, 0))
        ElseIf IsNumeric(x) And Not IsNumeric(y) Then
            Return -1
        ElseIf Not IsNumeric(x) And IsNumeric(y) Then
            Return 1
        Else
            Return IIf((CType(x, String).ToUpper > CType(y, String).ToUpper), 1, IIf((CType(x, String).ToUpper < CType(y, String).ToUpper), -1, 0))
        End If
    End Function
End Class

Public Class IConsultingFileComparer : Implements System.Collections.IComparer
    Function Compare(ByVal x As [Object], ByVal y As [Object]) As Integer Implements System.Collections.IComparer.Compare
        x = CType(x, String).Substring(0, CType(x, String).Length - 4)
        y = CType(y, String).Substring(0, CType(y, String).Length - 4)
        If IsNumeric(x) And IsNumeric(y) Then
            Return IIf((Val(x) > Val(y)), 1, IIf((Val(x) < Val(y)), -1, 0))
        ElseIf IsNumeric(x) And Not IsNumeric(y) Then
            Return -1
        ElseIf Not IsNumeric(x) And IsNumeric(y) Then
            Return 1
        Else
            Return IIf((CType(x, String).ToUpper > CType(y, String).ToUpper), 1, IIf((CType(x, String).ToUpper < CType(y, String).ToUpper), -1, 0))
        End If
    End Function
End Class
