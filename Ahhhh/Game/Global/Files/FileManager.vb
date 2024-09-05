Imports System.IO

Public Class FileManager

    Private Shared instance As FileManager

    Private Const DIRECTORY_NAME As String = "GameData"
    Private saveableObjects As List(Of ISaveable)

    Public Sub Initialize()
        saveableObjects = New List(Of ISaveable)
        CheckDirectory()
    End Sub

    Private Sub CheckDirectory()
        If Not Directory.Exists(DIRECTORY_NAME) Then
            Directory.CreateDirectory(DIRECTORY_NAME)
        End If
    End Sub

    Public Sub AddSaveableObject(ByVal saveable As ISaveable)
        saveableObjects.Add(saveable)
    End Sub

    Public Sub Save()
        For Each saveable As ISaveable In saveableObjects
            Dim writer As New StreamWriter($"{DIRECTORY_NAME}/{saveable.GetSaveableName()}")
            writer.Write(saveable.Save())
            writer.Close()
        Next
    End Sub

    Public Sub Load()
        For Each saveable As ISaveable In saveableObjects
            Dim fileName As String = $"{DIRECTORY_NAME}/{saveable.GetSaveableName()}"
            If Not File.Exists(fileName) Then
                Continue For
            End If
            Dim reader As New StreamReader(fileName)
            saveable.Load(reader.ReadToEnd())
            reader.Close()
        Next
    End Sub

    Public Shared Function GetInstance() As FileManager
        If instance Is Nothing Then
            instance = New FileManager()
        End If
        Return instance
    End Function

End Class
