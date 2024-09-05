Public Class Player : Inherits GameObject : Implements IInput

    Private Const DECELERATION_CONSTANT As Single = 0.95
    Private Const MIN_SPEED As Single = 2
    Private Const MAX_SPEED As Single = 32

    Private p_dex As Single
    Private p_dey As Single

    Private gameEnded As Boolean = False

    Private p_shipModel() As PointF = {
        New PointF(0, -5.5),
        New PointF(-2.5, 2.5),
        New PointF(2.5, 2.5)
    }

    Private p_flameModel() As PointF = {
        New PointF(0, 6.5),
        New PointF(-1.5, 2.5),
        New PointF(1.5, 2.5)
    }

    Public Sub New(ByVal x As Single, ByVal y As Single, ByVal size As Single)
        MyBase.New(x, y, size)
        Me.p_dex = 0
        Me.p_dey = 0
        gameEnded = False
        InputManager.Subscribe(Me)
    End Sub

    Public Overrides Sub Tick()
        If InputManager.IsKeyDown(Keys.Left) Then
            Angle -= 0.1
        ElseIf InputManager.IsKeyDown(Keys.Right) Then
            Angle += 0.1
        End If

        If InputManager.IsKeyDown(Keys.Up) Then
            If Math.Abs(DX) < MAX_SPEED Then DX += Math.Sin(Angle) * 2
            If Math.Abs(DY) < MAX_SPEED Then DY += -Math.Cos(Angle) * 2
        Else
            p_dex = DX * DECELERATION_CONSTANT
            p_dey = DY * DECELERATION_CONSTANT
            If Math.Abs(p_dex) > MIN_SPEED Then DX = p_dex
            If Math.Abs(p_dey) > MIN_SPEED Then DY = p_dey
        End If

        X += DX
        Y += DY
        Utils.WrapCoordinates(X, Y, X, Y)
    End Sub

    Public Overrides Sub Render(ByVal device As Graphics)
        If InputManager.IsKeyDown(Keys.Up) Then
            Renderer.DrawWireFrameModel(device, p_flameModel, X, Y, Angle, 10, Brushes.Orange)
        End If
        Renderer.DrawWireFrameModel(device, p_shipModel, X, Y, Angle, 10, Brushes.White)
    End Sub

    Public Sub KeyPressed(ByVal keyCode As Integer) Implements IInput.KeyPressed
        If gameEnded Then
            Return
        End If

        If keyCode = Keys.Space Then
            GameState.AddBullet(New Bullet(X, Y, Math.Sin(Angle) * 10, -Math.Cos(Angle) * 10))
            AudioSystem.GetInstance().AddRequest(New AudioRequest(Assets.GetAudioFilePath("shoot"), False))
        End If
    End Sub

    Public Sub MouseClicked(ByVal sender As Object, ByVal mouseEventArgs As MouseEventArgs) Implements IInput.MouseClicked

    End Sub

    Public Sub EndGame()
        gameEnded = True
    End Sub
End Class
