Public Class DocumentSelector
    Private Sub DocumentSelector_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        For i = 0 To ListViewDocuments.Items.Count - 1
            ListViewDocuments.Items(i).Checked = True
        Next
    End Sub

    Private Sub ButtonOkDocuments_Click(sender As Object, e As EventArgs) Handles ButtonOkDocuments.Click
        ListViewDocuments.Clear()
        Me.Close()
    End Sub
End Class