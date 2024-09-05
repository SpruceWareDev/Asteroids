Imports System.Collections.Concurrent

Public Class InputManager

    Private Shared heldKeys(256) As Boolean
    Private Shared subscribers As ConcurrentBag(Of IInput)

    Private Shared SpacePressed As Boolean = False

    Public Shared Sub Initialize(ByVal parent As PictureBox)
        subscribers = New ConcurrentBag(Of IInput)
        AddHandler parent.MouseClick, AddressOf MouseClick
    End Sub

    Public Shared Sub Subscribe(ByVal subscriber As IInput)
        subscribers.Add(subscriber)
    End Sub

    Public Shared Sub Unsubscribe(ByVal subscriber As IInput)
        subscribers = New ConcurrentBag(Of IInput)(subscribers.Except({subscriber}))
    End Sub

    Private Shared Sub MouseClick(ByVal sender As Object, ByVal mouseEventArgs As MouseEventArgs)
        For Each subscriber As IInput In subscribers
            subscriber.MouseClicked(sender, mouseEventArgs)
        Next
    End Sub

    Public Shared Sub KeyDown(ByVal sender As Object, ByVal keyEventArgs As KeyEventArgs)
        If keyEventArgs.KeyCode > heldKeys.Length Or keyEventArgs.KeyCode < 0 Then
            Return
        End If
        heldKeys(keyEventArgs.KeyCode) = True

        If keyEventArgs.KeyCode = Keys.Space And SpacePressed Then
            Return
        Else
            SpacePressed = True
        End If

        For Each subscriber As IInput In subscribers
            subscriber.KeyPressed(keyEventArgs.KeyCode)
        Next
    End Sub

    Public Shared Sub KeyUp(ByVal sender As Object, ByVal keyEventArgs As KeyEventArgs)
        If keyEventArgs.KeyCode > heldKeys.Length Or keyEventArgs.KeyCode < 0 Then
            Return
        End If
        If keyEventArgs.KeyCode = Keys.Space Then
            SpacePressed = False
        End If
        heldKeys(keyEventArgs.KeyCode) = False
    End Sub

    Public Shared Function IsKeyDown(ByVal key As Integer) As Boolean
        If key > heldKeys.Length Or key < 0 Then
            Return False
        End If
        Return heldKeys(key)
    End Function
End Class
