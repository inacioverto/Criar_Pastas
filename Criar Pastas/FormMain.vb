Imports System.IO
Imports System.Xml




Public Class FormMain

    Private Sub ComboBox_n_projeto_Leave(sender As Object, e As EventArgs) Handles ComboBox_n_projeto.Leave
        Dim x As Integer = ComboBox_n_projeto.Width - 20
        Dim y As Integer = 10

        ComboBox_n_projeto.Text = UCase(ComboBox_n_projeto.Text)

        nProj = ComboBox_n_projeto.Text

        If nProj <> Nothing Then
            If checkNprojExists(nProj) Then
                ComboBox_n_projeto.ForeColor = Color.Crimson
                'ToolTipNprojExists.Active = True
                'ToolTipNprojExists.Show("O nº de projeto já existe.", ComboBox_n_projeto, x, y)
            End If
        Else
            ToolTipNprojExists.Active = False
            ToolTipNprojExists.Hide(ComboBox_n_projeto)
        End If

        If nProj = Nothing Then
            nProjOK = False
        ElseIf checkNprojFormat(nProj) Then
            ComboBox_n_projeto.ForeColor = Color.Crimson
            ToolTipNprojFormat.Active = True
            ToolTipNprojFormat.Show("O formato não está correto.", ComboBox_n_projeto, x, y)
            nProjOK = False
        Else
            ToolTipNprojFormat.Active = False
            ToolTipNprojFormat.Hide(ComboBox_n_projeto)
            anoProd = "20" & Strings.Left(nProj, 2)
            nProjOK = True
            ComboBox_n_projeto.ForeColor = Color.Black
        End If

        If nClienteOK And nProjOK And nEncOK And nomeClienteOK Then
            GroupBox1.Enabled = True
            TextboxPastasFill()
            If desProjOK Then
                ButtonPreview.Enabled = True
            Else
                ButtonPreview.Enabled = False
            End If
        Else
            GroupBox1.Enabled = False
            TextBoxPastaID.Text = ""
            TextBoxPastaProd.Text = ""
        End If

    End Sub


    Private Sub TextBox_n_enc_Leave(sender As Object, e As EventArgs) Handles TextBox_n_enc.Leave
        Dim x As Integer = TextBox_n_enc.Width - 20
        Dim y As Integer = 10

        If TextBox_n_enc.Text = Nothing Then
            nEncOK = False
        ElseIf checkNenc(TextBox_n_enc.Text, CheckBoxProdutoVerto.Checked) Then

            TextBox_n_enc.ForeColor = Color.Crimson
            ToolTipNenc.Active = True
            ToolTipNenc.Show("O nº de encomenda não está no formato correto.", TextBox_n_enc, x, y)
        Else
            ToolTipNenc.Active = False
            ToolTipNenc.Hide(TextBox_n_enc)
            nEnc = TextBox_n_enc.Text
            nEncOK = True
            TextBox_n_enc.ForeColor = Color.Black
        End If

        If nProjOK And nClienteOK And nEncOK Then
            GroupBox1.Enabled = True
            TextboxPastasFill()
            If desProjOK Then
                ButtonPreview.Enabled = True
            Else
                ButtonPreview.Enabled = False
            End If
        Else
            GroupBox1.Enabled = False
            TextBoxPastaID.Text = ""
            TextBoxPastaProd.Text = ""
        End If
    End Sub


    Private Sub TextBox_n_cliente_Leave(sender As Object, e As EventArgs) Handles TextBox_n_cliente.Leave
        Dim i As Integer
        nCliente = TextBox_n_cliente.Text
        nClienteOK = False

        If nCliente <> "" Then
            CnCliente = nCliente
            For i = 1 To 4 - Len(nCliente)
                CnCliente = "0" & CnCliente
            Next
            CnCliente = "C" & CnCliente
            nClienteOK = True
            If CnCliente = "C0000" Then
                CheckBoxProdutoVerto.Enabled = True
            Else
                CheckBoxProdutoVerto.Enabled = False
                CheckBoxProdutoVerto.Checked = False
            End If
        Else
            CheckBoxProdutoVerto.Enabled = False
            CheckBoxProdutoVerto.Checked = False
        End If

        If nClienteOK And nProjOK And nEncOK Then
            GroupBox1.Enabled = True
            TextboxPastasFill()
            If desProjOK Then
                ButtonPreview.Enabled = True
            Else
                ButtonPreview.Enabled = False
            End If
        Else
            GroupBox1.Enabled = False
            TextBoxPastaID.Text = ""
            TextBoxPastaProd.Text = ""
        End If
    End Sub


    Private Sub TextboxPastasFill(Optional ByVal ID As Boolean = True, Optional ByVal PROD As Boolean = True)
        Dim xNodes As XmlNodeList = document.SelectNodes("modeldirectory/rootdirectory")
        Dim folderPath As String

        For Each xNode As XmlNode In xNodes
            folderPath = xNode.Attributes("path").Value
            If Strings.Right(folderPath, 1) <> "\" Then folderPath = folderPath & "\"

            replaceVars(folderPath)

            If UCase(xNode.Attributes("name").Value) = "DESENVOLVIMENTO" And ID Then TextBoxPastaID.Text = folderPath

            If UCase(xNode.Attributes("name").Value) = "PRODUÇÃO" And PROD Then

                If Not CheckBoxProdutoVerto.Checked Then
                    TextBoxPastaProd.Text = folderPath
                Else
                    TextBoxPastaProd.Text = folderPath & "Produtos Verto\"
                End If
            End If
        Next
    End Sub


    Private Sub Button_criar_Click(sender As Object, e As EventArgs) Handles Button_criar.Click
        CreateDirectories(document.SelectNodes("modeldirectory/rootdirectory"))
        MsgBox("Criação de pastas terminada.")
        Button_criar.Enabled = False
    End Sub
	

	Private Sub TextBox_n_cliente_TextChanged(sender As Object, e As EventArgs) Handles TextBox_n_cliente.TextChanged
        If Not SEMnCliente Then TextBox_n_cliente.Text = OnlyNumbers(TextBox_n_cliente.Text)
        previewClean()
        If TextBox_n_cliente.Text <> "" Then
            CBnProjFill(ComboBox_n_projeto, TextBox_n_cliente.Text)
        Else
            ComboBox_n_projeto.Items.Clear()
            ComboBox_n_projeto.Text = ""
        End If
    End Sub
	

    Private Sub ComboBox_n_projeto_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_n_projeto.TextChanged
        If TipoPasta = 0 Then ComboBox_n_projeto.Text = check_double(ComboBox_n_projeto.Text)
        TextBox_desig_proj.Text = ""
        TextBox_desig_proj.Enabled = True
        If Not TextBox_nome_cliente.Enabled Then TextBox_nome_cliente.Text = ""
        TextBox_nome_cliente.Enabled = True
        previewClean()
        If (ComboBox_n_projeto.Text.Length = 7 And TipoPasta = 0) Or (ComboBox_n_projeto.Text.Length = 10 And TipoPasta = 1) Then
            ComboBox_n_projeto_Leave(sender, e)
        End If
    End Sub


    Private Sub TextBox_n_enc_TextChanged(sender As Object, e As EventArgs) Handles TextBox_n_enc.TextChanged
        'TextBox_n_enc.Text = check_double(TextBox_n_enc.Text)
        previewClean()
        If (Not CheckBoxProdutoVerto.Checked And TextBox_n_enc.Text.Length = 8) Or
           (CheckBoxProdutoVerto.Checked And TextBox_n_enc.Text.Length > 9) Then TextBox_n_enc_Leave(sender, e)
    End Sub


    Private Sub TextBox_desig_proj_TextChanged(sender As Object, e As EventArgs) Handles TextBox_desig_proj.TextChanged
        previewClean()

        Dim x As Integer = TextBox_desig_proj.Width - 20
        Dim y As Integer = 40
        Dim erro As String = ""

        desProj = UCase(TextBox_desig_proj.Text)
        desProjOK = False

        If desProj <> "" And TextBox_desig_proj.Enabled = True Then
            desProjOK = True

            If checkDesigProj(desProj, erro) Then
                TextBox_desig_proj.ForeColor = Color.Crimson
                ToolTipDesigProj.Active = True
                ToolTipDesigProj.Show(erro, TextBox_desig_proj, x, y)
                desProjOK = False
            Else
                TextBox_desig_proj.ForeColor = Color.Black
                ToolTipDesigProj.Active = False
                ToolTipDesigProj.Hide(TextBox_desig_proj)
                'desProjOK = True
            End If
        End If

        If nProjOK And nClienteOK And nEncOK And desProjOK Then
            ButtonPreview.Enabled = True
        Else
            ButtonPreview.Enabled = False
        End If
    End Sub


    Private Sub TextBox_n_cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_n_cliente.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or (ModifierKeys = Keys.Control AndAlso e.KeyChar = "v"))
    End Sub


    Private Sub TextBox_n_enc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_n_enc.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
    End Sub


    Private Sub ComboBox_n_projeto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox_n_projeto.KeyPress
        If TipoPasta = 0 Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8)
        Else
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Or Char.IsLetter(e.KeyChar))
        End If
    End Sub


    Private Sub TextBox_n_cliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_n_cliente.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            TextBox_n_cliente.Text = Clipboard.GetText()
        End If
    End Sub


    Private Sub ComboBox_n_projeto_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox_n_projeto.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            ComboBox_n_projeto.Text = Clipboard.GetText()
        End If
    End Sub


    Private Sub TextBox_n_enc_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_n_enc.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            TextBox_n_enc.Text = Clipboard.GetText()
        End If
    End Sub


    Private Sub Button_limpar_Click(sender As Object, e As EventArgs) Handles Button_limpar.Click
        check_textbox = False
        TextBox_n_cliente.Text = Nothing
        TextBox_n_enc.Text = Nothing
        ComboBox_n_projeto.Items.Clear()
        ComboBox_n_projeto.Text = ""
        TextBox_desig_proj.Text = Nothing
        check_textbox = True
        previewClean()
    End Sub


    Private Sub ButtonPreview_Click(sender As Object, e As EventArgs) Handles ButtonPreview.Click

        If Not CheckBoxSnmrCliente.Checked Then TextBox_nome_cliente.Text = NomeClienteSybus(TextBox_n_cliente.Text)

        nomeCliente = TextBox_nome_cliente.Text

        TreeView1.Nodes.Clear()
        Dim folderPath As String
        Dim tNode As TreeNode = Nothing
        Dim xNodes As XmlNodeList = document.SelectNodes("modeldirectory/rootdirectory")

        For Each xNode As XmlNode In xNodes
            'folderPath = xNode.Attributes("path").Value
            'If Strings.Right(folderPath, 1) <> "\" Then folderPath = folderPath & "\"

            'replaceVars(folderPath)

            If UCase(xNode.Attributes("name").Value) = "DESENVOLVIMENTO" Then           '-----
                folderPath = TextBoxPastaID.Text
            ElseIf UCase(xNode.Attributes("name").Value) = "PRODUÇÃO" Then
                folderPath = TextBoxPastaProd.Text
            Else
                MsgBox("Erro nas pastas")
                Exit Sub
            End If

            If Strings.Right(folderPath, 1) <> "\" Then folderPath = folderPath & "\"   '-----

            tNode = New TreeNode(folderPath)
            TreeView1.Nodes.Add(tNode)

            If xNode.HasChildNodes Then
                getFiles(folderPath, xNode.ChildNodes)
                'DocumentSelector.ShowDialog()
                CreateSubDirectoriesTreeview(folderPath, xNode.ChildNodes, tNode, CheckBoxProdutoVerto.Checked)
            End If
            tNode = New TreeNode("")
            TreeView1.Nodes.Add(tNode)
        Next

        TreeView1.ExpandAll()

        If ComboBoxRespProj.Text = "" Then
            Dim txt As String
            If TipoPasta = 0 Then
                txt = "O campo Responsável do Projeto não está preenchido."
            Else
                txt = "O campo Orçamentista não está preenchido."
            End If
            MsgBox(txt)
        End If
        Button_criar.Enabled = True
    End Sub

    Private Sub TextBoxPastaProd_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPastaProd.TextChanged
        TreeView1.Nodes.Clear()
        Button_criar.Enabled = False
    End Sub

    Private Sub TextBoxPastaID_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPastaID.TextChanged
        TextBoxPastaProd_TextChanged(sender, e)
    End Sub

    Private Sub TextBoxPastaID_Leave(sender As Object, e As EventArgs) Handles TextBoxPastaID.Leave
        If TextBoxPastaID.Text = "" Then

            TextboxPastasFill(True, False)

        Else
            Try
                Path.GetDirectoryName(TextBoxPastaID.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
                TextboxPastasFill(True, False)
            End Try
        End If
    End Sub

    Private Sub TextBoxPastaProd_Leave(sender As Object, e As EventArgs) Handles TextBoxPastaProd.Leave
        If TextBoxPastaProd.Text = "" Then

            TextboxPastasFill(False, True)

        Else
            Try
                Path.GetDirectoryName(TextBoxPastaProd.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
                TextboxPastasFill(False, True)
            End Try
        End If

    End Sub

    Private Sub ComboBoxRespProj_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxRespProj.TextChanged
        respProj = ComboBoxRespProj.Text
    End Sub


    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Splash.Show()

        SEMnCliente = False
        nomeClienteOK = True

        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                LabelVersion.Text = .Major & "." & .Minor & "." & .Build & "." & .Revision
            End With
        End If

        Dim NodeName As String
        Try
            If TipoPasta = 0 Then
                document.Load(folderTreeXMLproj)
            Else
                document.Load(folderTreeXMLap)
            End If
        Catch
            If TipoPasta = 0 Then
                document.Load("e:\Users\Inacio\Documents\Seafile\VERTO\PROGRAMACAO\Criar_Pastas\IGNORE\folderTree_I.xml")
            Else
                document.Load("e:\Users\Inacio\Documents\Seafile\VERTO\PROGRAMACAO\Criar_Pastas\IGNORE\folderTreeAP_I.xml")
            End If
            MsgBox("O ficheiro xml com a árvore de pastas não foi encontrado.", MsgBoxStyle.MsgBoxSetForeground)
            'End
        End Try

        PastaModelo = document.SelectNodes("modeldirectory")(0).Attributes("path").Value

        Dim node As XmlNode = document.SelectSingleNode("modeldirectory/projetistas")
        Dim y As Integer = 0

        ReDim Projetistas(node.ChildNodes.Count - 1)
        For Each chNode As XmlNode In node.ChildNodes
            Projetistas(y) = chNode.Attributes("name").Value
            y += 1
        Next

        For y = 0 To Projetistas.GetUpperBound(0)
            ComboBoxRespProj.Items.Add(Projetistas(y))
        Next

        For Each node In document.SelectNodes("modeldirectory/rootdirectory")
            NodeName = UCase(node.Attributes("name").Value)
            If NodeName = "DESENVOLVIMENTO" Then PastaID = node.Attributes("path").Value
            PastaID = Strings.Left(PastaID, InStrRev(PastaID, "\"))
            If PastaID <> "" And Strings.Right(PastaID, 1) <> "\" Then
                PastaID = PastaID & "\"
            End If

            If NodeName = "PRODUÇÃO" Then PastaProd = node.Attributes("path").Value
            If PastaProd <> "" And Strings.Right(PastaProd, 1) <> "\" Then
                PastaProd = PastaProd & "\"
            End If
        Next

        If TipoPasta = 0 Then
            getAllFoldersPROJ(PastaID, ProjectFolders)
        Else
            getAllFoldersAP(PastaID, ProjectFolders)
            Me.Text = "Criar Pasta de Análise de Projeto"
            CheckBoxProdutoVerto.Visible = False
            LabelNenc.Visible = False
            TextBox_n_enc.Visible = False
            LabelResp.Text = "Orçamentista:"
            ComboBoxRespProj.Location = New Point(80, 117)
            LabelResp.Location = New Point(5, 121)
            TextBoxRespBorder.Location = New Point(79, 116)
            LabelPastaProd.Visible = False
            TextBoxPastaProd.Visible = False
            LabelPastaDesenv.Location = New Point(9, 36)
            TextBoxPastaID.Location = New Point(72, 32)
            LabelNproj.Text = "Nº A.P.:"
            LabelNproj.Location = New Point(34, 51)
            nEncOK = True
            TextBox_nome_cliente.Visible = True
            CheckBoxSnmrCliente.Visible = True
        End If

        Splash.Close()
        Me.Show()
    End Sub

    Private Sub CheckBoxProdutoVerto_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProdutoVerto.CheckedChanged
        If CheckBoxProdutoVerto.Checked Then
            TextBox_n_enc.MaxLength = 12
            TextBox_n_enc.Width = 77
            previewClean()
        Else
            TextBox_n_enc.MaxLength = 8
            TextBox_n_enc.Width = 65
            If TextBox_n_enc.Text.Length > 8 Then TextBox_n_enc.Text = Strings.Left(TextBox_n_enc.Text, 8)
        End If
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub CheckBoxSnmrCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSnmrCliente.CheckedChanged
        If CheckBoxSnmrCliente.Checked Then
            TextBox_n_cliente.Enabled = False
            SEMnCliente = True
            TextBox_n_cliente.Text = "XXXX"
            CBnomeClienteFill(ComboBox_nome_cliente)
            ComboBox_nome_cliente.visible = True
            nClienteOK = True
            TextBox_n_cliente_Leave(sender, e)
        Else
            TextBox_n_cliente.Enabled = True
            SEMnCliente = False
            TextBox_n_cliente.Text = ""
            TextBox_nome_cliente.Text = ""
            Combobox_nome_cliente.visible = False
            TextBox_nome_cliente.Enabled = False
        End If
    End Sub

    Private Sub TextBox_nome_cliente_TextChanged(sender As Object, e As EventArgs) Handles TextBox_nome_cliente.TextChanged
        previewClean()
        Dim x As Integer = TextBox_nome_cliente.Width - 20
        Dim y As Integer = 40
        Dim erro As String = ""

        nomeCliente = UCase(TextBox_nome_cliente.Text)
            nomeClienteOK = False

        If nomeCliente <> "" And TextBox_nome_cliente.Enabled = True Then
            nomeClienteOK = True

            If checkNomeCliente(nomeCliente, erro) Then
                TextBox_nome_cliente.ForeColor = Color.Crimson
                ToolTipDesigProj.Active = True
                ToolTipDesigProj.Show(erro, TextBox_nome_cliente, x, y)
                nomeClienteOK = False
            Else
                TextBox_nome_cliente.ForeColor = Color.Black
                ToolTipDesigProj.Active = False
                ToolTipDesigProj.Hide(TextBox_nome_cliente)
                'desProjOK = True
            End If
        End If
    End Sub

    Private Sub ComboBox_nome_cliente_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_nome_cliente.TextChanged
        If CheckBoxSnmrCliente.Checked Then TextBox_nome_cliente.Text = ComboBox_nome_cliente.Text
    End Sub
End Class
