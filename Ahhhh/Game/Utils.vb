Public Class Utils

    ' A method that takes x, y, outputX and outputY as arguments and
    ' wraps the coordinates around the screen.
    Public Shared Sub WrapCoordinates(ByVal x As Single, ByVal y As Single, ByRef ox As Single, ByRef oy As Single)
        ox = x
        oy = y
        If x < 0 Then ox = x + Game.WindowSize.Width
        If x > Game.WindowSize.Width Then ox = x - Game.WindowSize.Width
        If y < 0 Then oy = y + Game.WindowSize.Height
        If y > Game.WindowSize.Height Then oy = y - Game.WindowSize.Height
    End Sub

    Public Shared Function IsPointInCircle(ByVal x As Single, ByVal y As Single, ByVal cx As Single, ByVal cy As Single, ByVal radius As Single) As Boolean
        Return Math.Sqrt((x - cx) ^ 2 + (y - cy) ^ 2) < radius
    End Function
End Class
