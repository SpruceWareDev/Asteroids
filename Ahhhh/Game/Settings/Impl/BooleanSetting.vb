Public Class BooleanSetting : Inherits Setting

    Public Sub New(ByVal name As String, ByVal value As Boolean)
        MyBase.New(name, value)
    End Sub

    Public Sub Toggle()
        value = Not value
    End Sub

    Public Sub SetValue(ByVal value As Boolean)
        Me.value = value
    End Sub

    Public Shadows Function GetValue() As Boolean
        Return MyBase.GetValue()
    End Function
End Class
