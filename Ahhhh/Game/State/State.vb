Public MustInherit Class State
    Public MustOverride Sub Init()
    Public MustOverride Sub Tick()
    Public MustOverride Sub Render(device As Graphics)
    Public MustOverride Sub Clean()
End Class
