<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_n_cliente = New System.Windows.Forms.TextBox()
        Me.TextBox_n_projeto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_desig_proj = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_n_enc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button_criar = New System.Windows.Forms.Button()
        Me.Button_limpar = New System.Windows.Forms.Button()
        Me.RadioButton_projeto = New System.Windows.Forms.RadioButton()
        Me.RadioButton_encomenda = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Cliente:"
        '
        'TextBox_n_cliente
        '
        Me.TextBox_n_cliente.Location = New System.Drawing.Point(88, 9)
        Me.TextBox_n_cliente.MaxLength = 4
        Me.TextBox_n_cliente.Name = "TextBox_n_cliente"
        Me.TextBox_n_cliente.Size = New System.Drawing.Size(65, 20)
        Me.TextBox_n_cliente.TabIndex = 1
        '
        'TextBox_n_projeto
        '
        Me.TextBox_n_projeto.Location = New System.Drawing.Point(88, 44)
        Me.TextBox_n_projeto.MaxLength = 7
        Me.TextBox_n_projeto.Name = "TextBox_n_projeto"
        Me.TextBox_n_projeto.Size = New System.Drawing.Size(115, 20)
        Me.TextBox_n_projeto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nº Projeto:"
        '
        'TextBox_desig_proj
        '
        Me.TextBox_desig_proj.Location = New System.Drawing.Point(88, 79)
        Me.TextBox_desig_proj.MaxLength = 50
        Me.TextBox_desig_proj.Name = "TextBox_desig_proj"
        Me.TextBox_desig_proj.Size = New System.Drawing.Size(302, 20)
        Me.TextBox_desig_proj.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Desig. Projeto:"
        '
        'TextBox_n_enc
        '
        Me.TextBox_n_enc.Location = New System.Drawing.Point(275, 44)
        Me.TextBox_n_enc.MaxLength = 8
        Me.TextBox_n_enc.Name = "TextBox_n_enc"
        Me.TextBox_n_enc.Size = New System.Drawing.Size(115, 20)
        Me.TextBox_n_enc.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nº Enc.:"
        '
        'Button_criar
        '
        Me.Button_criar.Location = New System.Drawing.Point(165, 121)
        Me.Button_criar.Name = "Button_criar"
        Me.Button_criar.Size = New System.Drawing.Size(75, 23)
        Me.Button_criar.TabIndex = 8
        Me.Button_criar.Text = "Criar Pasta"
        Me.Button_criar.UseVisualStyleBackColor = True
        '
        'Button_limpar
        '
        Me.Button_limpar.Location = New System.Drawing.Point(337, 121)
        Me.Button_limpar.Name = "Button_limpar"
        Me.Button_limpar.Size = New System.Drawing.Size(53, 23)
        Me.Button_limpar.TabIndex = 9
        Me.Button_limpar.Text = "Limpar"
        Me.Button_limpar.UseVisualStyleBackColor = True
        '
        'RadioButton_projeto
        '
        Me.RadioButton_projeto.AutoSize = True
        Me.RadioButton_projeto.Checked = True
        Me.RadioButton_projeto.Location = New System.Drawing.Point(5, 4)
        Me.RadioButton_projeto.Name = "RadioButton_projeto"
        Me.RadioButton_projeto.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton_projeto.TabIndex = 10
        Me.RadioButton_projeto.TabStop = True
        Me.RadioButton_projeto.Text = "Projeto"
        Me.RadioButton_projeto.UseVisualStyleBackColor = True
        '
        'RadioButton_encomenda
        '
        Me.RadioButton_encomenda.AutoSize = True
        Me.RadioButton_encomenda.Location = New System.Drawing.Point(69, 4)
        Me.RadioButton_encomenda.Name = "RadioButton_encomenda"
        Me.RadioButton_encomenda.Size = New System.Drawing.Size(82, 17)
        Me.RadioButton_encomenda.TabIndex = 11
        Me.RadioButton_encomenda.TabStop = True
        Me.RadioButton_encomenda.Text = "Encomenda"
        Me.RadioButton_encomenda.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadioButton_projeto)
        Me.Panel1.Controls.Add(Me.RadioButton_encomenda)
        Me.Panel1.Location = New System.Drawing.Point(237, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(153, 26)
        Me.Panel1.TabIndex = 12
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(396, 6)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(212, 140)
        Me.TreeView1.TabIndex = 13
        '
        'TreeView2
        '
        Me.TreeView2.Location = New System.Drawing.Point(614, 6)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(212, 140)
        Me.TreeView2.TabIndex = 14
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 158)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button_limpar)
        Me.Controls.Add(Me.Button_criar)
        Me.Controls.Add(Me.TextBox_n_enc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_desig_proj)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_n_projeto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox_n_cliente)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Criar Pasta Projeto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_n_cliente As TextBox
    Friend WithEvents TextBox_n_projeto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_desig_proj As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_n_enc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button_criar As Button
    Friend WithEvents Button_limpar As Button
    Friend WithEvents RadioButton_projeto As RadioButton
    Friend WithEvents RadioButton_encomenda As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents ToolTip3 As ToolTip
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents TreeView2 As TreeView
End Class
