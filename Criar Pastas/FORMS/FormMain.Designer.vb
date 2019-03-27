<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_n_cliente = New System.Windows.Forms.TextBox()
        Me.LabelNproj = New System.Windows.Forms.Label()
        Me.TextBox_desig_proj = New System.Windows.Forms.TextBox()
        Me.LabelDesigProj = New System.Windows.Forms.Label()
        Me.TextBox_n_enc = New System.Windows.Forms.TextBox()
        Me.LabelNenc = New System.Windows.Forms.Label()
        Me.Button_criar = New System.Windows.Forms.Button()
        Me.Button_limpar = New System.Windows.Forms.Button()
        Me.ToolTipNprojExists = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipNprojFormat = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipNenc = New System.Windows.Forms.ToolTip(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ButtonPreview = New System.Windows.Forms.Button()
        Me.ToolTipDesigProj = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.ComboBox_n_projeto = New System.Windows.Forms.ComboBox()
        Me.GroupBoxPastas = New System.Windows.Forms.GroupBox()
        Me.TextBoxPastaID = New System.Windows.Forms.TextBox()
        Me.LabelPastaID = New System.Windows.Forms.Label()
        Me.TextBoxPastaProd = New System.Windows.Forms.TextBox()
        Me.LabelPastaProd = New System.Windows.Forms.Label()
        Me.ComboBoxRespProj = New System.Windows.Forms.ComboBox()
        Me.LabelRespProj = New System.Windows.Forms.Label()
        Me.CheckBoxProdutoVerto = New System.Windows.Forms.CheckBox()
        Me.TextBox_nome_cliente = New System.Windows.Forms.TextBox()
        Me.TextBoxRespProjBorder = New System.Windows.Forms.TextBox()
        Me.TextBoxNprojBorder = New System.Windows.Forms.TextBox()
        Me.CheckBoxSnmrCliente = New System.Windows.Forms.CheckBox()
        Me.ComboBox_nome_cliente = New System.Windows.Forms.ComboBox()
        Me.TextBoxProjGen = New System.Windows.Forms.TextBox()
        Me.CheckBoxProjGen = New System.Windows.Forms.CheckBox()
        Me.ComboBoxRespAP = New System.Windows.Forms.ComboBox()
        Me.LabelRespAP = New System.Windows.Forms.Label()
        Me.TextBoxRespAPborder = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBoxProjeto = New System.Windows.Forms.TextBox()
        Me.LabelProjeto = New System.Windows.Forms.Label()
        Me.PanelButtons.SuspendLayout()
        Me.GroupBoxPastas.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Cliente:"
        '
        'TextBox_n_cliente
        '
        Me.TextBox_n_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_n_cliente.Location = New System.Drawing.Point(85, 12)
        Me.TextBox_n_cliente.MaxLength = 4
        Me.TextBox_n_cliente.Name = "TextBox_n_cliente"
        Me.TextBox_n_cliente.Size = New System.Drawing.Size(39, 20)
        Me.TextBox_n_cliente.TabIndex = 0
        '
        'LabelNproj
        '
        Me.LabelNproj.AutoSize = True
        Me.LabelNproj.Location = New System.Drawing.Point(27, 50)
        Me.LabelNproj.Name = "LabelNproj"
        Me.LabelNproj.Size = New System.Drawing.Size(58, 13)
        Me.LabelNproj.TabIndex = 2
        Me.LabelNproj.Text = "Nº Projeto:"
        '
        'TextBox_desig_proj
        '
        Me.TextBox_desig_proj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_desig_proj.Location = New System.Drawing.Point(85, 81)
        Me.TextBox_desig_proj.MaxLength = 50
        Me.TextBox_desig_proj.Name = "TextBox_desig_proj"
        Me.TextBox_desig_proj.Size = New System.Drawing.Size(402, 20)
        Me.TextBox_desig_proj.TabIndex = 2
        '
        'LabelDesigProj
        '
        Me.LabelDesigProj.AutoSize = True
        Me.LabelDesigProj.Location = New System.Drawing.Point(9, 85)
        Me.LabelDesigProj.Name = "LabelDesigProj"
        Me.LabelDesigProj.Size = New System.Drawing.Size(76, 13)
        Me.LabelDesigProj.TabIndex = 4
        Me.LabelDesigProj.Text = "Desig. Projeto:"
        '
        'TextBox_n_enc
        '
        Me.TextBox_n_enc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_n_enc.Location = New System.Drawing.Point(85, 115)
        Me.TextBox_n_enc.MaxLength = 8
        Me.TextBox_n_enc.Name = "TextBox_n_enc"
        Me.TextBox_n_enc.Size = New System.Drawing.Size(65, 20)
        Me.TextBox_n_enc.TabIndex = 3
        '
        'LabelNenc
        '
        Me.LabelNenc.AutoSize = True
        Me.LabelNenc.Location = New System.Drawing.Point(38, 119)
        Me.LabelNenc.Name = "LabelNenc"
        Me.LabelNenc.Size = New System.Drawing.Size(47, 13)
        Me.LabelNenc.TabIndex = 6
        Me.LabelNenc.Text = "Nº Enc.:"
        '
        'Button_criar
        '
        Me.Button_criar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button_criar.Enabled = False
        Me.Button_criar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_criar.Location = New System.Drawing.Point(247, 10)
        Me.Button_criar.Name = "Button_criar"
        Me.Button_criar.Size = New System.Drawing.Size(75, 23)
        Me.Button_criar.TabIndex = 1
        Me.Button_criar.Text = "Criar Pastas"
        Me.Button_criar.UseVisualStyleBackColor = True
        '
        'Button_limpar
        '
        Me.Button_limpar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button_limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_limpar.Location = New System.Drawing.Point(418, 13)
        Me.Button_limpar.Name = "Button_limpar"
        Me.Button_limpar.Size = New System.Drawing.Size(53, 23)
        Me.Button_limpar.TabIndex = 2
        Me.Button_limpar.Text = "Limpar"
        Me.Button_limpar.UseVisualStyleBackColor = True
        '
        'ToolTipNprojExists
        '
        Me.ToolTipNprojExists.UseAnimation = False
        Me.ToolTipNprojExists.UseFading = False
        '
        'ToolTipNprojFormat
        '
        Me.ToolTipNprojFormat.UseAnimation = False
        Me.ToolTipNprojFormat.UseFading = False
        '
        'ToolTipNenc
        '
        Me.ToolTipNenc.UseAnimation = False
        Me.ToolTipNenc.UseFading = False
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Indent = 10
        Me.TreeView1.ItemHeight = 14
        Me.TreeView1.Location = New System.Drawing.Point(492, 6)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(435, 374)
        Me.TreeView1.TabIndex = 6
        Me.TreeView1.TabStop = False
        '
        'ButtonPreview
        '
        Me.ButtonPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonPreview.Enabled = False
        Me.ButtonPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPreview.Location = New System.Drawing.Point(156, 10)
        Me.ButtonPreview.Name = "ButtonPreview"
        Me.ButtonPreview.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPreview.TabIndex = 0
        Me.ButtonPreview.Text = "Preview"
        Me.ButtonPreview.UseVisualStyleBackColor = True
        '
        'ToolTipDesigProj
        '
        Me.ToolTipDesigProj.UseAnimation = False
        Me.ToolTipDesigProj.UseFading = False
        '
        'PanelButtons
        '
        Me.PanelButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelButtons.Controls.Add(Me.LabelVersion)
        Me.PanelButtons.Controls.Add(Me.Button_limpar)
        Me.PanelButtons.Controls.Add(Me.Button_criar)
        Me.PanelButtons.Controls.Add(Me.ButtonPreview)
        Me.PanelButtons.Location = New System.Drawing.Point(7, 337)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(479, 42)
        Me.PanelButtons.TabIndex = 4
        '
        'LabelVersion
        '
        Me.LabelVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelVersion.Location = New System.Drawing.Point(-1, 28)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(68, 13)
        Me.LabelVersion.TabIndex = 3
        Me.LabelVersion.Text = "LabelVersion"
        '
        'ComboBox_n_projeto
        '
        Me.ComboBox_n_projeto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBox_n_projeto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox_n_projeto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox_n_projeto.FormattingEnabled = True
        Me.ComboBox_n_projeto.Location = New System.Drawing.Point(86, 46)
        Me.ComboBox_n_projeto.MaxLength = 7
        Me.ComboBox_n_projeto.Name = "ComboBox_n_projeto"
        Me.ComboBox_n_projeto.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox_n_projeto.TabIndex = 1
        '
        'GroupBoxPastas
        '
        Me.GroupBoxPastas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxPastas.Controls.Add(Me.TextBoxPastaID)
        Me.GroupBoxPastas.Controls.Add(Me.LabelPastaID)
        Me.GroupBoxPastas.Controls.Add(Me.TextBoxPastaProd)
        Me.GroupBoxPastas.Controls.Add(Me.LabelPastaProd)
        Me.GroupBoxPastas.Enabled = False
        Me.GroupBoxPastas.Location = New System.Drawing.Point(7, 247)
        Me.GroupBoxPastas.Name = "GroupBoxPastas"
        Me.GroupBoxPastas.Size = New System.Drawing.Size(479, 85)
        Me.GroupBoxPastas.TabIndex = 8
        Me.GroupBoxPastas.TabStop = False
        Me.GroupBoxPastas.Text = "Pastas"
        '
        'TextBoxPastaID
        '
        Me.TextBoxPastaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPastaID.Location = New System.Drawing.Point(84, 52)
        Me.TextBoxPastaID.MaxLength = 50
        Me.TextBoxPastaID.Name = "TextBoxPastaID"
        Me.TextBoxPastaID.Size = New System.Drawing.Size(387, 20)
        Me.TextBoxPastaID.TabIndex = 7
        '
        'LabelPastaID
        '
        Me.LabelPastaID.AutoSize = True
        Me.LabelPastaID.Location = New System.Drawing.Point(20, 55)
        Me.LabelPastaID.Name = "LabelPastaID"
        Me.LabelPastaID.Size = New System.Drawing.Size(64, 13)
        Me.LabelPastaID.TabIndex = 8
        Me.LabelPastaID.Text = "Desenvolv.:"
        '
        'TextBoxPastaProd
        '
        Me.TextBoxPastaProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPastaProd.Location = New System.Drawing.Point(84, 20)
        Me.TextBoxPastaProd.MaxLength = 50
        Me.TextBoxPastaProd.Name = "TextBoxPastaProd"
        Me.TextBoxPastaProd.Size = New System.Drawing.Size(387, 20)
        Me.TextBoxPastaProd.TabIndex = 5
        '
        'LabelPastaProd
        '
        Me.LabelPastaProd.AutoSize = True
        Me.LabelPastaProd.Location = New System.Drawing.Point(28, 24)
        Me.LabelPastaProd.Name = "LabelPastaProd"
        Me.LabelPastaProd.Size = New System.Drawing.Size(56, 13)
        Me.LabelPastaProd.TabIndex = 6
        Me.LabelPastaProd.Text = "Produção:"
        '
        'ComboBoxRespProj
        '
        Me.ComboBoxRespProj.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxRespProj.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxRespProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRespProj.FormattingEnabled = True
        Me.ComboBoxRespProj.Location = New System.Drawing.Point(86, 149)
        Me.ComboBoxRespProj.Name = "ComboBoxRespProj"
        Me.ComboBoxRespProj.Size = New System.Drawing.Size(190, 21)
        Me.ComboBoxRespProj.TabIndex = 9
        '
        'LabelRespProj
        '
        Me.LabelRespProj.AutoSize = True
        Me.LabelRespProj.Location = New System.Drawing.Point(11, 153)
        Me.LabelRespProj.Name = "LabelRespProj"
        Me.LabelRespProj.Size = New System.Drawing.Size(74, 13)
        Me.LabelRespProj.TabIndex = 10
        Me.LabelRespProj.Text = "Resp. Projeto:"
        '
        'CheckBoxProdutoVerto
        '
        Me.CheckBoxProdutoVerto.AutoSize = True
        Me.CheckBoxProdutoVerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxProdutoVerto.Location = New System.Drawing.Point(185, 48)
        Me.CheckBoxProdutoVerto.Name = "CheckBoxProdutoVerto"
        Me.CheckBoxProdutoVerto.Size = New System.Drawing.Size(88, 17)
        Me.CheckBoxProdutoVerto.TabIndex = 11
        Me.CheckBoxProdutoVerto.Text = "Produto Verto"
        Me.CheckBoxProdutoVerto.UseVisualStyleBackColor = True
        '
        'TextBox_nome_cliente
        '
        Me.TextBox_nome_cliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_nome_cliente.Enabled = False
        Me.TextBox_nome_cliente.Location = New System.Drawing.Point(129, 11)
        Me.TextBox_nome_cliente.Multiline = True
        Me.TextBox_nome_cliente.Name = "TextBox_nome_cliente"
        Me.TextBox_nome_cliente.Size = New System.Drawing.Size(170, 23)
        Me.TextBox_nome_cliente.TabIndex = 12
        '
        'TextBoxRespProjBorder
        '
        Me.TextBoxRespProjBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRespProjBorder.Enabled = False
        Me.TextBoxRespProjBorder.Location = New System.Drawing.Point(85, 148)
        Me.TextBoxRespProjBorder.MaxLength = 4
        Me.TextBoxRespProjBorder.Multiline = True
        Me.TextBoxRespProjBorder.Name = "TextBoxRespProjBorder"
        Me.TextBoxRespProjBorder.Size = New System.Drawing.Size(192, 23)
        Me.TextBoxRespProjBorder.TabIndex = 13
        '
        'TextBoxNprojBorder
        '
        Me.TextBoxNprojBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNprojBorder.Enabled = False
        Me.TextBoxNprojBorder.Location = New System.Drawing.Point(85, 45)
        Me.TextBoxNprojBorder.MaxLength = 4
        Me.TextBoxNprojBorder.Multiline = True
        Me.TextBoxNprojBorder.Name = "TextBoxNprojBorder"
        Me.TextBoxNprojBorder.Size = New System.Drawing.Size(87, 23)
        Me.TextBoxNprojBorder.TabIndex = 14
        '
        'CheckBoxSnmrCliente
        '
        Me.CheckBoxSnmrCliente.AutoSize = True
        Me.CheckBoxSnmrCliente.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBoxSnmrCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxSnmrCliente.Location = New System.Drawing.Point(191, 48)
        Me.CheckBoxSnmrCliente.Name = "CheckBoxSnmrCliente"
        Me.CheckBoxSnmrCliente.Size = New System.Drawing.Size(109, 17)
        Me.CheckBoxSnmrCliente.TabIndex = 15
        Me.CheckBoxSnmrCliente.Text = "Sem Nº de Cliente"
        Me.CheckBoxSnmrCliente.UseVisualStyleBackColor = False
        Me.CheckBoxSnmrCliente.Visible = False
        '
        'ComboBox_nome_cliente
        '
        Me.ComboBox_nome_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBox_nome_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox_nome_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox_nome_cliente.FormattingEnabled = True
        Me.ComboBox_nome_cliente.Location = New System.Drawing.Point(130, 12)
        Me.ComboBox_nome_cliente.Name = "ComboBox_nome_cliente"
        Me.ComboBox_nome_cliente.Size = New System.Drawing.Size(168, 21)
        Me.ComboBox_nome_cliente.TabIndex = 16
        Me.ComboBox_nome_cliente.Visible = False
        '
        'TextBoxProjGen
        '
        Me.TextBoxProjGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxProjGen.Enabled = False
        Me.TextBoxProjGen.Location = New System.Drawing.Point(290, 115)
        Me.TextBoxProjGen.MaxLength = 50
        Me.TextBoxProjGen.Name = "TextBoxProjGen"
        Me.TextBoxProjGen.Size = New System.Drawing.Size(196, 20)
        Me.TextBoxProjGen.TabIndex = 17
        '
        'CheckBoxProjGen
        '
        Me.CheckBoxProjGen.AutoSize = True
        Me.CheckBoxProjGen.BackColor = System.Drawing.SystemColors.Control
        Me.CheckBoxProjGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxProjGen.Location = New System.Drawing.Point(185, 117)
        Me.CheckBoxProjGen.Name = "CheckBoxProjGen"
        Me.CheckBoxProjGen.Size = New System.Drawing.Size(105, 17)
        Me.CheckBoxProjGen.TabIndex = 18
        Me.CheckBoxProjGen.Text = "Projeto Genérico:"
        Me.CheckBoxProjGen.UseVisualStyleBackColor = False
        '
        'ComboBoxRespAP
        '
        Me.ComboBoxRespAP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxRespAP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxRespAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxRespAP.FormattingEnabled = True
        Me.ComboBoxRespAP.Location = New System.Drawing.Point(86, 184)
        Me.ComboBoxRespAP.Name = "ComboBoxRespAP"
        Me.ComboBoxRespAP.Size = New System.Drawing.Size(190, 21)
        Me.ComboBoxRespAP.TabIndex = 19
        '
        'LabelRespAP
        '
        Me.LabelRespAP.AutoSize = True
        Me.LabelRespAP.Location = New System.Drawing.Point(0, 188)
        Me.LabelRespAP.Name = "LabelRespAP"
        Me.LabelRespAP.Size = New System.Drawing.Size(85, 13)
        Me.LabelRespAP.TabIndex = 20
        Me.LabelRespAP.Text = "Resp. Processo:"
        '
        'TextBoxRespAPborder
        '
        Me.TextBoxRespAPborder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxRespAPborder.Enabled = False
        Me.TextBoxRespAPborder.Location = New System.Drawing.Point(85, 183)
        Me.TextBoxRespAPborder.MaxLength = 4
        Me.TextBoxRespAPborder.Multiline = True
        Me.TextBoxRespAPborder.Name = "TextBoxRespAPborder"
        Me.TextBoxRespAPborder.Size = New System.Drawing.Size(192, 23)
        Me.TextBoxRespAPborder.TabIndex = 21
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(305, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(181, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'TextBoxProjeto
        '
        Me.TextBoxProjeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxProjeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxProjeto.Location = New System.Drawing.Point(84, 220)
        Me.TextBoxProjeto.MaxLength = 200
        Me.TextBoxProjeto.Name = "TextBoxProjeto"
        Me.TextBoxProjeto.ReadOnly = True
        Me.TextBoxProjeto.Size = New System.Drawing.Size(402, 18)
        Me.TextBoxProjeto.TabIndex = 22
        '
        'LabelProjeto
        '
        Me.LabelProjeto.AutoSize = True
        Me.LabelProjeto.Location = New System.Drawing.Point(40, 223)
        Me.LabelProjeto.Name = "LabelProjeto"
        Me.LabelProjeto.Size = New System.Drawing.Size(43, 13)
        Me.LabelProjeto.TabIndex = 23
        Me.LabelProjeto.Text = "Projeto:"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 388)
        Me.Controls.Add(Me.TextBoxProjeto)
        Me.Controls.Add(Me.LabelProjeto)
        Me.Controls.Add(Me.ComboBoxRespAP)
        Me.Controls.Add(Me.LabelRespAP)
        Me.Controls.Add(Me.CheckBoxProjGen)
        Me.Controls.Add(Me.TextBoxProjGen)
        Me.Controls.Add(Me.ComboBox_nome_cliente)
        Me.Controls.Add(Me.CheckBoxSnmrCliente)
        Me.Controls.Add(Me.TextBox_nome_cliente)
        Me.Controls.Add(Me.CheckBoxProdutoVerto)
        Me.Controls.Add(Me.ComboBoxRespProj)
        Me.Controls.Add(Me.LabelRespProj)
        Me.Controls.Add(Me.GroupBoxPastas)
        Me.Controls.Add(Me.ComboBox_n_projeto)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PanelButtons)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.TextBox_n_enc)
        Me.Controls.Add(Me.LabelNenc)
        Me.Controls.Add(Me.TextBox_desig_proj)
        Me.Controls.Add(Me.LabelDesigProj)
        Me.Controls.Add(Me.LabelNproj)
        Me.Controls.Add(Me.TextBox_n_cliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxRespProjBorder)
        Me.Controls.Add(Me.TextBoxNprojBorder)
        Me.Controls.Add(Me.TextBoxRespAPborder)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(845, 357)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criar Pasta de Projeto"
        Me.PanelButtons.ResumeLayout(False)
        Me.PanelButtons.PerformLayout()
        Me.GroupBoxPastas.ResumeLayout(False)
        Me.GroupBoxPastas.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_n_cliente As TextBox
    Friend WithEvents LabelNproj As Label
    Friend WithEvents TextBox_desig_proj As TextBox
    Friend WithEvents LabelDesigProj As Label
    Friend WithEvents TextBox_n_enc As TextBox
    Friend WithEvents LabelNenc As Label
    Friend WithEvents Button_criar As Button
    Friend WithEvents Button_limpar As Button
    Friend WithEvents ToolTipNprojExists As ToolTip
    Friend WithEvents ToolTipNprojFormat As ToolTip
    Friend WithEvents ToolTipNenc As ToolTip
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ButtonPreview As Button
    Friend WithEvents ToolTipDesigProj As ToolTip
    Friend WithEvents PanelButtons As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox_n_projeto As ComboBox
    Friend WithEvents GroupBoxPastas As GroupBox
    Friend WithEvents TextBoxPastaID As TextBox
    Friend WithEvents LabelPastaID As Label
    Friend WithEvents TextBoxPastaProd As TextBox
    Friend WithEvents LabelPastaProd As Label
    Friend WithEvents ComboBoxRespProj As ComboBox
    Friend WithEvents LabelRespProj As Label
    Friend WithEvents CheckBoxProdutoVerto As CheckBox
    Friend WithEvents LabelVersion As Label
    Friend WithEvents TextBox_nome_cliente As TextBox
    Friend WithEvents TextBoxRespProjBorder As TextBox
    Friend WithEvents TextBoxNprojBorder As TextBox
    Friend WithEvents CheckBoxSnmrCliente As CheckBox
    Friend WithEvents ComboBox_nome_cliente As ComboBox
    Friend WithEvents TextBoxProjGen As TextBox
    Friend WithEvents CheckBoxProjGen As CheckBox
    Friend WithEvents ComboBoxRespAP As ComboBox
    Friend WithEvents LabelRespAP As Label
    Friend WithEvents TextBoxRespAPborder As TextBox
    Friend WithEvents TextBoxProjeto As TextBox
    Friend WithEvents LabelProjeto As Label
End Class
