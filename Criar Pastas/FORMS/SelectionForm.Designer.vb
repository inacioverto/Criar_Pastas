<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectionForm))
        Me.ButtonAP = New System.Windows.Forms.Button()
        Me.ButtonProj = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAP
        '
        Me.ButtonAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAP.Location = New System.Drawing.Point(26, 158)
        Me.ButtonAP.Name = "ButtonAP"
        Me.ButtonAP.Size = New System.Drawing.Size(113, 42)
        Me.ButtonAP.TabIndex = 0
        Me.ButtonAP.TabStop = False
        Me.ButtonAP.Text = "Análise de Projeto"
        Me.ButtonAP.UseVisualStyleBackColor = True
        '
        'ButtonProj
        '
        Me.ButtonProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonProj.Location = New System.Drawing.Point(155, 158)
        Me.ButtonProj.Name = "ButtonProj"
        Me.ButtonProj.Size = New System.Drawing.Size(113, 42)
        Me.ButtonProj.TabIndex = 1
        Me.ButtonProj.TabStop = False
        Me.ButtonProj.Text = "Projeto"
        Me.ButtonProj.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Criar_Pastas.My.Resources.Resources.logo_verto
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(269, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CRIAÇÃO DE PASTAS I&&D"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SelectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 217)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonProj)
        Me.Controls.Add(Me.ButtonAP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criar Pastas I&D"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonAP As Button
    Friend WithEvents ButtonProj As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
End Class
