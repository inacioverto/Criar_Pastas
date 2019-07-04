Imports System.Windows.Forms
Imports System.Drawing


' <DECLARATION>
' Public msg as CustomMessageBox
' dim answer as integer
'</DECLARATION>

' <USAGE>
' msg = New CustomMessageBox(message, buttonNOtext, buttonYEStext, title)
' answer = msg.ShowDialog()
'</USAGE>

' <PARAMS>
' <Message> Message to show on form
' <ButtonNOtext> Text for button that will return VbNo
' <ButtonYEStext> text for button that will return VbYes - if empty the button is hidden
' <Title> Message form title - if empty will assume the same of the MAINFORM
' <Icon> Message form icon - if empty will assume the same of the MAINFORM
' </PARAMS>

Public Class CustomMessageBox



    Public Sub New(ByVal Message As String, ByVal ButtonNOtext As String, Optional ByVal ButtonYEStext As String = "", Optional ByVal Title As String = "", Optional ByVal Icon As Drawing.Icon = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If Title = "" Then Title = FormMain.Text
        If Title = "" Then Title = FormMain.Text
        Me.Text = Title
        Label1.Text = Message
        If Icon IsNot Nothing Then
            Me.Icon = Icon
        Else
            Me.Icon = FormMain.Icon
        End If
        Me.Size = New Size(Label1.Width + 40, Label1.Height + 110)
        Label1.Dock = DockStyle.Fill
        NO_Button.Text = ButtonNOtext
        If ButtonYEStext = "" Then
            YES_Button.Visible = False
        Else
            YES_Button.Text = ButtonYEStext
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


