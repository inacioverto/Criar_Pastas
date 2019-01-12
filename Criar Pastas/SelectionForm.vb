Public Class SelectionForm
    Private Sub ButtonAP_Click(sender As Object, e As EventArgs) Handles ButtonAP.Click
        Splash.Label1.Text = "CRIAÇÃO DE PASTAS DE PROJETO"
        Me.Hide()
        TipoPasta = 1
        FormMain.Show()
    End Sub

    Private Sub ButtonProj_Click(sender As Object, e As EventArgs) Handles ButtonProj.Click
        Splash.Label1.Text = "CRIAÇÃO DE PASTAS DE ANÁLISE DE PROJETO"
        Me.Hide()
        TipoPasta = 0
        FormMain.Show()
    End Sub
End Class