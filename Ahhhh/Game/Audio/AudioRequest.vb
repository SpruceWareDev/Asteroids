Public Class AudioRequest

    Private p_path As String
    Private p_mustFinish As Boolean

    Public Sub New(ByVal path As String, mustFinish As Boolean)
        Me.p_mustFinish = mustFinish
        Me.p_path = path
    End Sub

    Public Function GetPath() As String
        Return p_path
    End Function

    Public Function MustFinish() As Boolean
        Return p_mustFinish
    End Function
End Class
