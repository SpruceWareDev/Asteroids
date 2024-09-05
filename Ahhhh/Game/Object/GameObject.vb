Public MustInherit Class GameObject

    Private p_x As Single
    Private p_y As Single
    Private p_dx As Single
    Private p_dy As Single
    Private p_size As Single
    Private p_angle As Single

    Public Sub New(x As Single, y As Single, size As Single)
        p_x = x
        p_y = y
        p_size = size
        p_dx = 0
        p_dy = 0
        p_angle = 0
    End Sub

    Public MustOverride Sub Tick()
    Public MustOverride Sub Render(device As Graphics)

    Public Property X As Single
        Get
            Return p_x
        End Get
        Set(value As Single)
            p_x = value
        End Set
    End Property

    Public Property Y As Single
        Get
            Return p_y
        End Get
        Set(value As Single)
            p_y = value
        End Set
    End Property

    Public Property DX As Single
        Get
            Return p_dx
        End Get
        Set(value As Single)
            p_dx = value
        End Set
    End Property

    Public Property DY As Single
        Get
            Return p_dy
        End Get
        Set(value As Single)
            p_dy = value
        End Set
    End Property

    Public ReadOnly Property Size As Single
        Get
            Return p_size
        End Get
    End Property

    Public Property Angle As Single
        Get
            Return p_angle
        End Get
        Set(value As Single)
            p_angle = value
        End Set
    End Property

End Class
