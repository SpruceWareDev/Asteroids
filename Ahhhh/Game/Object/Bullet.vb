Public Class Bullet : Inherits GameObject

    Public Sub New(x As Single, y As Single, dxIn As Single, dyIn As Single)
        MyBase.New(x, y, 5)
        DX = dxIn
        DY = dyIn
    End Sub

    Public Overrides Sub Tick()
        X += DX
        Y += DY
    End Sub

    Public Overrides Sub Render(device As Graphics)
        device.FillRectangle(Brushes.White, X, Y, Size, Size)
    End Sub
End Class
