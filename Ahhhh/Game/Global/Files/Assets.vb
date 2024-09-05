Public Class Assets
    Public Shared Function GetAudioFilePath(name As String) As String
        Return "assets/audio/" & name & ".wav"
    End Function
End Class
