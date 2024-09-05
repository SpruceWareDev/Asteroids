Public Class UIButton : Inherits UIComponent : Implements IInput

    Private _text As String
    Private _width As Single
    Private _height As Single
    Private _backgroundBrush As Brush
    Private _fontBrush As Brush
    Private _runFunction As Func(Of Boolean)

    Public Sub New(ByVal x As Single, ByVal y As Single, ByVal text As String, ByVal width As Single, ByVal height As Single, ByVal backBrush As Brush, ByVal fontBrush As Brush, ByVal runFunc As Func(Of Boolean))
        MyBase.New(x, y)
        Me._text = text
        Me._width = width
        Me._height = height
        Me._backgroundBrush = backBrush
        Me._fontBrush = fontBrush
        Me._runFunction = runFunc
        InputManager.Subscribe(Me)
    End Sub

    Public Overrides Sub Render(ByVal device As System.Drawing.Graphics)
        device.FillRectangle(_backgroundBrush, New Rectangle(X, Y, _width, _height))
        device.DrawString(_text, Fonts.MAIN_FONT, _fontBrush, New PointF(X + 2, Y + 2))
    End Sub

    Public Overrides Sub Update()

    End Sub

    Public Sub KeyPressed(ByVal keyCode As Integer) Implements IInput.KeyPressed
        
    End Sub

    Public Sub MouseClicked(ByVal sender As Object, ByVal mouseEventArgs As MouseEventArgs) Implements IInput.MouseClicked
        If IsHovered(mouseEventArgs.X, mouseEventArgs.Y) Then
            _runFunction.Invoke()
        End If
    End Sub

    Private Function IsHovered(ByVal mouseX As Integer, ByVal mouseY As Integer) As Boolean
        Return mouseX >= X And mouseY >= Y And mouseX <= X + _width And mouseY <= Y + _height
    End Function
End Class
