Public Class Asteroid : Inherits GameObject

    Private p_asteroidModel() As PointF
    Public Property ShouldRemove As Boolean
    Private colour As Brush

    Public Sub New(x As Single, y As Single, size As Single)
        MyBase.New(x, y, size)
        ShouldRemove = False
        GenerateAsteroidModel()
    End Sub

    Private Sub GenerateAsteroidModel()
        Dim theme As Theme = ThemeManager.GetInstance().GetSelectedTheme()
        colour = theme.GetAsteroidColour()
        Dim vertexes As Single = theme.GetAsteroidVertexCount()
        ReDim p_asteroidModel(vertexes - 1)
        For i As Single = 0 To vertexes - 1
            Dim angle As Single = (i / vertexes) * (2 * Math.PI)
            Dim radius As Single = theme.GetRadiusRandomness() + (Rnd() * 0.4)
            If theme.GetRadiusRandomness() = 0 Then
                radius = 1
            End If
            p_asteroidModel(i) = New PointF(Math.Sin(angle) * radius, Math.Cos(angle) * radius)
        Next
    End Sub

    Public Overrides Sub Tick()
        X += DX
        Y += DY
        Angle += 0.01
        Utils.WrapCoordinates(X, Y, X, Y)
    End Sub

    Public Overrides Sub Render(device As Graphics)
        Renderer.DrawWireFrameModel(device, p_asteroidModel, X, Y, Angle, Size, colour)
    End Sub

    Public Function GetScore() As Integer
        Select Case Size
            Case 32
                Return 20
            Case 16
                Return 30
        End Select
        Return 10
    End Function
End Class
