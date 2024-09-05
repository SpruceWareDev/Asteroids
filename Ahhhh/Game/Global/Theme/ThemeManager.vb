Public Class ThemeManager : Implements ISaveable

    Private Shared instance As ThemeManager

    Private themes As List(Of Theme)
    Private unlockedThemes As List(Of String)
    Private selectedTheme As String

    Public Sub Initialize()
        themes = New List(Of Theme)
        unlockedThemes = New List(Of String)
        InitThemes()
        FileManager.GetInstance().AddSaveableObject(Me)
    End Sub

    Private Sub InitThemes()
        themes.Add(New Theme("Default", Brushes.White, 14, 0.8))
        unlockedThemes.Add("Default")
        selectedTheme = "Crazy"

        themes.Add(New Theme("Penta", Brushes.White, 5, 0))
        themes.Add(New Theme("Hexa", Brushes.White, 6, 0))
        themes.Add(New Theme("Crazy", Brushes.Orange, 32, 0.8))
    End Sub

    Public Function GetSaveableName() As String Implements ISaveable.GetSaveableName
        Return "themes"
    End Function

    Public Function Save() As String Implements ISaveable.Save
        Dim data As String = ""
        For Each unlockedTheme As String In unlockedThemes
            data += $"{unlockedTheme},"
        Next
        data = data.Substring(0, data.Length - 1)
        Return data
    End Function

    Public Sub Load(data As String) Implements ISaveable.Load
        Dim unlockedThemesArray As String() = data.Split(",")
        For Each unlockedTheme As String In unlockedThemesArray
            If unlockedTheme.Equals("Default") Then
                Continue For
            End If
            unlockedThemes.Add(unlockedTheme)
        Next
    End Sub

    Public Function GetSelectedTheme() As Theme
        For Each theme As Theme In themes
            If theme.GetName().Equals(selectedTheme) Then
                Return theme
            End If
        Next
        Throw New Exception("Theme does not exists")
    End Function

    Public Shared Function GetInstance() As ThemeManager
        If instance Is Nothing Then
            instance = New ThemeManager()
        End If
        Return instance
    End Function
End Class
