Public Class Particle

    Private p_x As Single
    Private p_y As Single
    Private p_xVel As Single
    Private p_yVel As Single
    Private p_size As Single
    Private p_color As Brush
    Private p_lifeTicks As Integer

    Public Sub New(ByVal x As Single, ByVal y As Single, ByVal xVel As Single, ByVal yVel As Single, ByVal size As Single, ByVal color As Brush, ByVal lifeTicks As Integer)
        Me.p_x = x
        Me.p_y = y
        Me.p_xVel = xVel
        Me.p_yVel = yVel
        Me.p_size = size
        Me.p_color = color
        Me.p_lifeTicks = lifeTicks
    End Sub

    Public Sub Tick()
        Me.p_x += Me.p_xVel
        Me.p_y += Me.p_yVel
        Me.p_lifeTicks -= 1
    End Sub

    Public Sub Render(ByVal g As Graphics)
        g.FillRectangle(Me.p_color, Me.p_x, Me.p_y, Me.p_size, Me.p_size)
    End Sub

    Public Function IsDead() As Boolean
        Return Me.p_lifeTicks <= 0
    End Function
End Class
