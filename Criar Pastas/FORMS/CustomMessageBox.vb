Imports System.Windows.Forms
Imports System.Drawing

Public Class CustomMessageBox

    Public Sub New(ByVal message As String, ByVal buttonNOtext As String, Optional ByVal buttonYEStext As String = "", Optional ByVal title As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Label1.Text = message
        Dim g As Graphics = Label1.CreateGraphics()
        Label1.Width = CInt(g.MeasureString(Label1.Text, Label1.Font).Width)
        Label1.Height = CInt(g.MeasureString(Label1.Text, Label1.Font).Height)

        If title = "" Then title = FormMain.Text
        Me.Text = title
        Me.Icon = FormMain.Icon
        Me.Size = New Size(Label1.Width + 40, Me.Height + Label1.Height - 13)
        Label1.Dock = DockStyle.Fill
        NO_Button.Text = buttonNOtext
        If buttonYEStext = "" Then
            YES_Button.Visible = False
        Else
            YES_Button.Text = buttonYEStext
        End If
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub


    Private Sub YES_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YES_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub


    Private Sub NO_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NO_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

End Class
