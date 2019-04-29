Public Class FlatCombo
    Inherits ComboBox

    Private Const WM_PAINT As Integer = 15
    Private buttonWidth As Integer = SystemInformation.HorizontalScrollBarArrowWidth

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        If m.Msg = WM_PAINT Then

            Using g = Graphics.FromHwnd(Handle)

                Using p = New Pen(Me.ForeColor)
                    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1)
                    g.DrawLine(p, Width - buttonWidth, 0, Width - buttonWidth, Height)
                End Using
            End Using
        End If
    End Sub

    Public Sub New()
        MyBase.New()
        Me.FlatStyle = FlatStyle.Flat
    End Sub
End Class
