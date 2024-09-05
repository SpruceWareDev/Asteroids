Public MustInherit Class UIComponent

    Private _x As Single
    Private _y As Single

    Public Sub New(ByVal x As Single, ByVal y As Single)
        Me._x = x
        Me._y = y
    End Sub

    Public MustOverride Sub Update()
    Public MustOverride Sub Render(ByVal device As Graphics)

    Public Sub UpdatePosition(ByVal x As Single, ByVal y As Single)
        Me._x = x
        Me._y = y
    End Sub

    Protected Property X As Single
        Get
            Return _x
        End Get
        Set(ByVal value As Single)
            _x = value
        End Set
    End Property

    Protected Property Y As Single
        Get
            Return _y
        End Get
        Set(ByVal value As Single)
            _y = value
        End Set
    End Property
End Class
