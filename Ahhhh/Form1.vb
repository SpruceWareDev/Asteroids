Public Class Form1
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim game As Game = New Game(Me, "Asteroids", New Size(1280, 720))
        game.Run()
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        InputManager.KeyUp(sender, e)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        InputManager.KeyDown(sender, e)
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        AudioSystem.GetInstance().StopAudioThread()
        FileManager.GetInstance().Save()
    End Sub
End Class
