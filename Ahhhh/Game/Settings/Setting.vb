Public MustInherit Class Setting

    Protected name As String
    Protected value As Object

    Public Sub New(ByVal name As String, ByVal value As Object)
        Me.name = name
        Me.value = value
    End Sub

    Public Function GetName() As String
        Return name
    End Function

    Public Function GetValue()
        Return value
    End Function
End Class
