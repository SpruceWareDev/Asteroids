Public Class Theme

    Private name As String
    Private asteroidColour As Brush
    Private asteroidVertexCount As Integer
    Private radiusRandomness As Single

    Public Sub New(ByVal name As String, ByVal asteroidColour As Brush, ByVal asteroidVertexCount As Integer, ByVal radiusRandomness As Single)
        Me.name = name
        Me.asteroidColour = asteroidColour
        Me.asteroidVertexCount = asteroidVertexCount
        Me.radiusRandomness = radiusRandomness
    End Sub

    Public Function GetAsteroidColour() As Brush
        Return asteroidColour
    End Function

    Public Function GetAsteroidVertexCount() As Integer
        Return asteroidVertexCount
    End Function

    Public Function GetRadiusRandomness() As Single
        Return radiusRandomness
    End Function

    Public Function GetName() As String
        Return name
    End Function
End Class
