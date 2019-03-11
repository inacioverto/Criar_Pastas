Public Class SelectionForm
    Private Sub ButtonAP_Click(sender As Object, e As EventArgs) Handles ButtonAP.Click
        SplashScreen.Label1.Text = "CRIAÇÃO DE PASTAS DE ANÁLISE DE PROJETO"
        TipoPasta = 1
        Me.Hide()
        FormMain.Show()
    End Sub

    Private Sub ButtonProj_Click(sender As Object, e As EventArgs) Handles ButtonProj.Click
        SplashScreen.Label1.Text = "CRIAÇÃO DE PASTAS DE PROJETO"
        TipoPasta = 0
        Me.Hide()
        FormMain.Show()
    End Sub
End Class