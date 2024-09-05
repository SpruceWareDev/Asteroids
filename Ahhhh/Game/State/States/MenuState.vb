Public Class MenuState : Inherits State

    Private _Asteroids As List(Of Asteroid)
    Private _uiManager As UIManager

    Public Overrides Sub Init()
        ' Setup asteroid background
        _Asteroids = New List(Of Asteroid)
        Dim rand As New Random
        For i As Integer = 0 To 4
            Dim asteroid As New Asteroid(rand.Next(10, Game.WindowSize.Width), rand.Next(10, Game.WindowSize.Height), rand.Next(42, 156))
            With asteroid
                .DX = rand.Next(1, 5)
                .DY = rand.Next(1, 5)
            End With
            _Asteroids.Add(asteroid)
        Next

        ' Setup UIManager and components
        Dim buttonBrush As SolidBrush = New SolidBrush(Color.FromArgb(180, Color.White))
        _uiManager = New UIManager()
        _uiManager.AddComponent(New UIButton(100, 100, "Play", 180, 42, buttonBrush, Brushes.Black, Function() As Boolean
                                                                                                        Game.StateManager.ChangeState(New GameState())
                                                                                                        Return True
                                                                                                    End Function))
        _uiManager.AddComponent(New UIButton(100, 100, "Themes", 180, 42, buttonBrush, Brushes.Black, Function() As Boolean
                                                                                                          'Need to make the theme selector state
                                                                                                          Return True
                                                                                                      End Function))
        _uiManager.AddComponent(New UIButton(100, 100, "Options", 180, 42, buttonBrush, Brushes.Black, Function() As Boolean
                                                                                                           Game.StateManager.ChangeState(New OptionsState())
                                                                                                           Return True
                                                                                                       End Function))
        _uiManager.AddComponent(New UIButton(100, 100, "Quit", 180, 42, buttonBrush, Brushes.Black, Function() As Boolean
                                                                                                        Form1.Close()
                                                                                                        Return True
                                                                                                    End Function))
    End Sub

    Public Overrides Sub Render(ByVal device As System.Drawing.Graphics)
        Dim w As Single = Game.WindowSize.Width
        Dim h As Single = Game.WindowSize.Height

        For Each _asteroid As Asteroid In _Asteroids
            _asteroid.Render(device)
        Next

        Dim backgroundBrush As SolidBrush = New SolidBrush(Color.FromArgb(128, Color.Black))
        device.FillRectangle(backgroundBrush, New Rectangle(0, 0, w, h))
        Renderer.DrawCenteredString(device, "Asteroids", Fonts.TITLE_FONT, New PointF(w / 2, h / 5), Brushes.White)

        _uiManager.Render(device)
    End Sub

    Public Overrides Sub Tick()
        Dim w As Integer = Game.WindowSize.Width
        Dim h As Integer = Game.WindowSize.Width

        For Each _asteroid As Asteroid In _Asteroids
            _asteroid.Tick()
        Next

        _uiManager.Update()
        Dim i As Integer = 0
        For Each comp As UIComponent In _uiManager.Components
            Dim x As Single = (w / 2) - 90
            Dim y As Single = (h / 5) + (i * 48)
            comp.UpdatePosition(x, y)
            i += 1
        Next
    End Sub

    Public Overrides Sub Clean()
        _Asteroids.Clear()
    End Sub
End Class
