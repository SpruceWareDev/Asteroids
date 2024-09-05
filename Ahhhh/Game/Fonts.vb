Public Class Fonts

    Private Shared privateFonts As New System.Drawing.Text.PrivateFontCollection()
    Public Shared MAIN_FONT As Font = LoadFont("assets\fonts\easvhs.ttf", 22)
    Public Shared TITLE_FONT As Font = LoadFont("assets\fonts\easvhs.ttf", 48)

    Private Shared Function LoadFont(ByVal path As String, ByVal size As Integer) As Font
        privateFonts.AddFontFile(path)
        Return New System.Drawing.Font(privateFonts.Families(0), size)
    End Function
End Class
