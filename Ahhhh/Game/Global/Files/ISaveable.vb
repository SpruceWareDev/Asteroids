Public Interface ISaveable
    Function GetSaveableName() As String
    Function Save() As String
    Sub Load(data As String)
End Interface
