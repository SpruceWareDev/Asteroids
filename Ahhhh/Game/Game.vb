Public Class Game

    Private p_parent As Form
    Private Shared p_windowSize As Size

    Private p_renderImage As Bitmap
    Private WithEvents p_pictureBox As PictureBox
    Private p_renderDevice As Graphics
    Private WithEvents p_tickTimer As Timer

    Private Shared p_stateManager As StateManager

    Public Sub New(parent As Form, title As String, windowSize As Size)
        p_windowSize = windowSize
        p_parent = parent
        SetupForm(title)
        SetupEngine()
        SetupManagers()
    End Sub

    Private Sub SetupForm(title As String)
        p_parent.Text = title
        p_parent.Size = p_windowSize
        p_parent.MaximizeBox = False
        p_parent.MinimizeBox = False
        p_parent.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub SetupEngine()
        p_renderImage = New Bitmap(p_windowSize.Width, p_windowSize.Height)
        p_pictureBox = New PictureBox With {
            .Size = p_windowSize
        }
        p_pictureBox.Focus()
        InputManager.Initialize(p_pictureBox)
        p_parent.Controls.Add(p_pictureBox)
        p_renderDevice = Graphics.FromImage(p_renderImage)
    End Sub

    Private Sub SetupManagers()
        FileManager.GetInstance().Initialize()
        ' Init all managers above file manager loading and add them to the saveable list
        PointManager.GetInstance().Initialize()
        ThemeManager.GetInstance().Initialize()
        FileManager.GetInstance().Load()
        AudioSystem.GetInstance().Initzialize()
        p_stateManager = New StateManager(New MenuState())
    End Sub

    Public Sub Run()
        p_tickTimer = New Timer With {
            .Interval = 1000 / 60
        }
        p_tickTimer.Start()
    End Sub

    Private Sub GameLoop() Handles p_tickTimer.Tick
        ClearScreen()
        Tick()
        Render(p_renderDevice)
    End Sub

    Private Sub ClearScreen()
        p_renderDevice.FillRectangle(Brushes.Black, 0, 0, p_windowSize.Width, p_windowSize.Height)
        p_pictureBox.Image = p_renderImage
    End Sub

    Private Sub Tick()
        p_stateManager.Tick()
    End Sub

    Private Sub Render(device As Graphics)
        p_stateManager.Render(device)
    End Sub

    Public Shared ReadOnly Property WindowSize As Size
        Get
            Return p_windowSize
        End Get
    End Property

    Public Shared ReadOnly Property StateManager As StateManager
        Get
            Return p_stateManager
        End Get
    End Property
End Class
