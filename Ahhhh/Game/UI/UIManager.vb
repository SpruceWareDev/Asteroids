Public Class UIManager

    Private _components As New List(Of UIComponent)

    Public Sub AddComponent(ByVal comp As UIComponent)
        _components.Add(comp)
    End Sub

    Public Sub Update()
        For Each component As UIComponent In Components
            component.Update()
        Next
    End Sub

    Public Sub Render(ByVal device As Graphics)
        For Each component As UIComponent In Components
            component.Render(device)
        Next
    End Sub

    Public Sub Clean()
        ' TODO: Make UIComponent implement IInput instead of individual components

        'For Each comp As UIComponent In Components
        '    InputManager.Unsubscribe(comp)
        'Next
    End Sub

    Public ReadOnly Property Components As List(Of UIComponent)
        Get
            Return _components
        End Get
    End Property
End Class
