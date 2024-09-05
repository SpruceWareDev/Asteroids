Public MustInherit Class Animation

    Protected p_finished As Boolean

    Public MustOverride Sub Tick()
    Public MustOverride Sub Render(g As Graphics)

    Public ReadOnly Property Finished As Boolean
        Get
            Return p_finished
        End Get
    End Property
End Class
