Imports System.Threading
Imports WMPLib

Public Class AudioSystem

    Private Shared instance As AudioSystem

    Private audioThread As Thread
    Private audioRequests As Queue(Of AudioRequest)
    Private player As WindowsMediaPlayer
    Private playing As Boolean

    Public Sub Initzialize()
        audioRequests = New Queue(Of AudioRequest)
        audioThread = New Thread(AddressOf Run)
        player = New WindowsMediaPlayer()
        AddHandler player.PlayStateChange, AddressOf Player_PlayStateChange
        audioThread.Start()
    End Sub

    Public Sub AddRequest(ByVal request As AudioRequest)
        audioRequests.Enqueue(request)
    End Sub

    Public Sub StopAudioThread()
        player.controls.stop()
        player.close()
        audioThread.Abort()
    End Sub

    Private Sub Run()
        While True
            If audioRequests.Count > 0 And Not playing Then
                Dim request As AudioRequest = audioRequests.Dequeue()
                player.URL = request.GetPath()
                player.settings.volume = 20
                player.controls.play()
                playing = True
            End If
        End While
    End Sub

    Private Sub Player_PlayStateChange(NewState As Integer)
        If NewState = WMPPlayState.wmppsMediaEnded Then
            playing = False
        End If
    End Sub

    Public Shared Function GetInstance() As AudioSystem
        If instance Is Nothing Then
            instance = New AudioSystem()
        End If
        Return instance
    End Function
End Class
