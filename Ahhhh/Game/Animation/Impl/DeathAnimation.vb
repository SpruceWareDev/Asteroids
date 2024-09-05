Public Class DeathAnimation : Inherits Animation

    Private particles As List(Of Particle)

    Public Sub New(x As Single, y As Single)
        particles = New List(Of Particle)
        For i As Integer = 0 To 32
            particles.Add(New Particle(x, y, Rnd() * 4 - 2, Rnd() * 4 - 2, 8, Brushes.White, Rnd() * 100))
        Next
    End Sub

    Public Overrides Sub Tick()
        particles.RemoveAll(Function(particle) particle.IsDead)
        If particles.Count = 0 Then
            p_finished = True
        End If
        For Each particle As Particle In particles
            particle.Tick()
        Next
    End Sub

    Public Overrides Sub Render(g As Graphics)
        For Each particle As Particle In particles
            particle.Render(g)
        Next
    End Sub
End Class
