Public Class OptionsState : Inherits State

    Private nutVar As Integer = 360
    Private position As Integer = 10
    Private forward As Boolean = False

    Public Overrides Sub Init()

    End Sub

    Public Overrides Sub Tick()
        position += 10
        If forward Then
            nutVar += 2
            If nutVar > 360 Then
                forward = Not forward
            End If
        Else
            nutVar -= 2
            If nutVar <= 320 Then
                forward = Not forward
            End If
        End If

        Utils.WrapCoordinates(position, 0, position, 0)
    End Sub

    Public Overrides Sub Render(ByVal device As System.Drawing.Graphics)
        device.FillRectangle(Brushes.Black, New Rectangle(New Point(0, 0), Game.WindowSize))
        For i As Integer = 0 To 10
            If position > i * 100 Then
                Continue For
            End If
            device.FillPie(Brushes.LightGoldenrodYellow, New Rectangle(i * 100, 140, 20, 20), 0, 360)
        Next
        device.FillPie(Brushes.Yellow, New Rectangle(position, 100, 100, 100), 0, nutVar)
        device.DrawString(nutVar.ToString, Fonts.MAIN_FONT, Brushes.Black, New Point(6, 6))
    End Sub

    Public Overrides Sub Clean()

    End Sub
End Class
