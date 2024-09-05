Public Class PointManager : Implements ISaveable

    Private Shared instance As PointManager

    Private points As Integer

    Public Sub Initialize()
        points = 0
        FileManager.GetInstance().AddSaveableObject(Me)
    End Sub

    Public Sub AddPoints(ByVal points As Integer)
        Me.points += points
    End Sub

    Public Function GetPoints() As Integer
        Return points
    End Function

    Public Function GetSaveableName() As String Implements ISaveable.GetSaveableName
        Return "points"
    End Function

    Public Function Save() As String Implements ISaveable.Save
        Return points.ToString()
    End Function

    Public Sub Load(data As String) Implements ISaveable.Load
        points = Integer.Parse(data)
    End Sub

    Public Shared Function GetInstance() As PointManager
        If instance Is Nothing Then
            instance = New PointManager()
        End If
        Return instance
    End Function
End Class
