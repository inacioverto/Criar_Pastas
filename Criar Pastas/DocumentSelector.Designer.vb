<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentSelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListViewDocuments = New System.Windows.Forms.ListView()
        Me.ButtonOkDocuments = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListViewDocuments
        '
        Me.ListViewDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewDocuments.CheckBoxes = True
        Me.ListViewDocuments.FullRowSelect = True
        Me.ListViewDocuments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewDocuments.Location = New System.Drawing.Point(12, 12)
        Me.ListViewDocuments.Name = "ListViewDocuments"
        Me.ListViewDocuments.ShowGroups = False
        Me.ListViewDocuments.Size = New System.Drawing.Size(418, 150)
        Me.ListViewDocuments.TabIndex = 0
        Me.ListViewDocuments.UseCompatibleStateImageBehavior = False
        Me.ListViewDocuments.View = System.Windows.Forms.View.List
        '
        'ButtonOkDocuments
        '
        Me.ButtonOkDocuments.Location = New System.Drawing.Point(184, 174)
        Me.ButtonOkDocuments.Name = "ButtonOkDocuments"
        Me.ButtonOkDocuments.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOkDocuments.TabIndex = 1
        Me.ButtonOkDocuments.Text = "Ok"
        Me.ButtonOkDocuments.UseVisualStyleBackColor = True
        '
        'DocumentSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(442, 211)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonOkDocuments)
        Me.Controls.Add(Me.ListViewDocuments)
        Me.Name = "DocumentSelector"
        Me.Text = "Selecionar Documentos"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewDocuments As ListView
    Friend WithEvents ButtonOkDocuments As Button
End Class
