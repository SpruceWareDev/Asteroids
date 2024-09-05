Public Class NumberSetting : Inherits Setting

    Private min As Integer
    Private max As Integer
    Private interval As Integer

    Public Sub New(ByVal name As String, ByVal value As Integer, min As Integer, max As Integer, interval As Integer)
        MyBase.New(name, value)
        Me.min = min
        Me.max = max
        Me.interval = interval
    End Sub

    Public Sub SetValue(ByVal value As Integer)
        Me.value = value
    End Sub

    Public Shadows Function GetValue() As Integer
        Return MyBase.GetValue()
    End Function

    Public Function GetMin() As Integer
        Return min
    End Function

    Public Function GetMax() As Integer
        Return max
    End Function

    Public Function GetInterval() As Integer
        Return interval
    End Function

End Class
