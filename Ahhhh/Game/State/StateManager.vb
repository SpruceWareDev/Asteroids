Public Class StateManager

    Private p_CurrentState As State

    Public Sub New(startState As State)
        p_CurrentState = startState
        p_CurrentState.Init()
    End Sub

    Public Sub Tick()
        p_CurrentState.Tick()
    End Sub

    Public Sub Render(device As Graphics)
        p_CurrentState.Render(device)
    End Sub

    Public Sub ChangeState(ByVal newState As State)
        p_CurrentState.Clean()
        p_CurrentState = newState
        p_CurrentState.Init()
    End Sub
End Class
