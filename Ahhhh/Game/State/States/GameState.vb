Public Class GameState : Inherits State

    Private p_asteroids As List(Of Asteroid)
    Private Shared p_bullets As List(Of Bullet)
    Private p_player As Player
    Private p_score As Integer

    Private p_gameEnded As Boolean
    Private p_gameEndedAnimation As DeathAnimation

    Public Overrides Sub Init()
        p_score = 0
        p_asteroids = New List(Of Asteroid)
        Dim asteroid As New Asteroid(10, 10, 128) With {
            .DX = 4,
            .DY = 4
        }
        p_asteroids.Add(asteroid)
        p_bullets = New List(Of Bullet)
        p_player = New Player(Game.WindowSize.Width / 2, Game.WindowSize.Height / 2, 64)
    End Sub

    Public Overrides Sub Tick()
        If p_gameEnded Then
            p_player.EndGame()
            HandleGameOver()
            Return
        End If

        p_player.Tick()
        If p_asteroids.Count = 0 Then
            SpawnAsteroids()
        End If

        p_asteroids.RemoveAll(Function(asteroid) asteroid.ShouldRemove)
        UpdateAsteroids()
        p_bullets.RemoveAll(Function(bullet) bullet.X < 0 Or bullet.X > Game.WindowSize.Width Or bullet.Y < 0 Or bullet.Y > Game.WindowSize.Height)
        UpdateBullets()
    End Sub

    Private Sub HandleGameOver()
        If p_gameEndedAnimation Is Nothing Then
            p_gameEndedAnimation = New DeathAnimation(p_player.X, p_player.Y)
        End If
        p_gameEndedAnimation.Tick()
        If p_gameEndedAnimation.Finished Then
            Game.StateManager.ChangeState(New LoseState(p_score))
        End If
    End Sub

    Private Sub SpawnAsteroids()
        p_asteroids.Add(New Asteroid(2 * Math.Sin(p_player.Angle - Math.PI / 2),
                                         2 * Math.Cos(p_player.Angle - Math.PI / 2), 128) With {
                                                    .DX = Math.Sin(p_player.Angle + Rnd()) * 4,
                                                    .DY = Math.Cos(p_player.Angle + Rnd()) * 4
                                          })
        p_asteroids.Add(New Asteroid(2 * Math.Sin(p_player.Angle + Math.PI / 2),
                                     2 * Math.Cos(p_player.Angle + Math.PI / 2), 128) With {
                                                .DX = Math.Sin(-p_player.Angle + Rnd()) * 4,
                                                .DY = Math.Cos(-p_player.Angle + Rnd()) * 4
                                      })
    End Sub

    Private Sub UpdateAsteroids()
        For Each asteroid As Asteroid In p_asteroids
            If Utils.IsPointInCircle(p_player.X, p_player.Y, asteroid.X, asteroid.Y, asteroid.Size) Then
                AudioSystem.GetInstance().AddRequest(New AudioRequest(Assets.GetAudioFilePath("death"), True))
                p_gameEnded = True
            End If
            asteroid.Tick()
        Next
    End Sub

    Private Sub UpdateBullets()
        Dim newAsteroids As New List(Of Asteroid)
        For Each bullet As Bullet In p_bullets
            bullet.Tick()
            ' Collision detection
            For Each asteroid In p_asteroids
                If Utils.IsPointInCircle(bullet.X, bullet.Y, asteroid.X, asteroid.Y, asteroid.Size) And Not asteroid.ShouldRemove Then
                    p_score += asteroid.GetScore()
                    PointManager.GetInstance().AddPoints(asteroid.GetScore() / 10)
                    bullet.X = -100
                    asteroid.ShouldRemove = True
                    asteroid.PlayDeathSound()
                    newAsteroids = SplitExistingAsteroid(asteroid)
                End If
            Next
        Next
        ' Add new asteroids to the main list
        For Each newAsteroid As Asteroid In newAsteroids
            p_asteroids.Add(newAsteroid)
        Next
    End Sub

    Private Function SplitExistingAsteroid(oldAsteroid As Asteroid) As List(Of Asteroid)
        Randomize()
        Dim newAsteroids As New List(Of Asteroid)
        If oldAsteroid.Size > 32 Then
            ' Generate the angles for the new asteroids
            Dim angle1 As Single = Rnd() * (Math.PI * 2)
            Dim angle2 As Single = Rnd() * (Math.PI * 2)
            newAsteroids.Add(New Asteroid(oldAsteroid.X, oldAsteroid.Y, oldAsteroid.Size / 2) With {
                                        .DX = Math.Sin(angle1) * 4,
                                        .DY = Math.Cos(angle1) * 4
                                    })
            newAsteroids.Add(New Asteroid(oldAsteroid.X, oldAsteroid.Y, oldAsteroid.Size / 2) With {
                                        .DX = Math.Sin(angle2) * 4,
                                        .DY = Math.Cos(angle2) * 4
                                    })
        End If
        Return newAsteroids
    End Function

    Public Overrides Sub Render(device As Graphics)
        If Not p_gameEnded Then
            p_player.Render(device)
        End If
        For Each asteroid As Asteroid In p_asteroids
            asteroid.Render(device)
        Next
        For Each bullet As Bullet In p_bullets
            bullet.Render(device)
        Next
        device.DrawString($"Score: {p_score}", Fonts.MAIN_FONT, Brushes.White, 10, 10)
        If p_gameEnded And Not (p_gameEndedAnimation Is Nothing) Then
            p_gameEndedAnimation.Render(device)
        End If
    End Sub

    Public Shared Sub AddBullet(bullet As Bullet)
        p_bullets.Add(bullet)
    End Sub

    Public Overrides Sub Clean()
        InputManager.Unsubscribe(p_player)
    End Sub
End Class
