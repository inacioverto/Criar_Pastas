Imports System.IO
Imports System.Xml




Public Class FormMain

    Private Sub ComboBox_n_projeto_Leave(sender As Object, e As EventArgs) Handles ComboBox_n_projeto.Leave
        Call validateALL() 'nProjetoValidation()
    End Sub


    Private Sub TextBox_n_enc_Leave(sender As Object, e As EventArgs) Handles TextBox_n_enc.Leave
        Call validateALL() 'nEncValidation
    End Sub


    Private Sub TextBox_n_cliente_Leave(sender As Object, e As EventArgs) Handles TextBox_n_cliente.Leave
        Call validateALL() 'nClienteValidation()
    End Sub

    Private Sub Button_criar_Click(sender As Object, e As EventArgs) Handles Button_criar.Click
        CreateDirectories(ModelNode.ChildNodes) 'document.SelectNodes("modeldirectory/rootdirectory"))
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
        If TipoPasta = 0 Then
            ComboBox_n_projeto.Text = check_double(ComboBox_n_projeto.Text)
        End If

        TextBox_desig_proj.Text = ""
        TextBox_desig_proj.Enabled = True

        If Not TextBox_nome_cliente.Enabled And Not SEMnCliente Then
            TextBox_nome_cliente.Text = ""
        End If

        'TextBox_nome_cliente.Enabled = True
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
        Call validateALL() 'desigProjValidation
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
        TextBox_n_cliente.Clear()
        TextBox_n_enc.Clear()
        ComboBox_n_projeto.Items.Clear()
        ComboBox_n_projeto.Text = Nothing
        TextBox_desig_proj.Clear()
        TextBoxPastaProd.Clear()
        TextBoxPastaID.Clear()
        ComboBoxRespProj.Text = Nothing
        TextBox_nome_cliente.Clear()
        ComboBoxRespAP.Text = Nothing
        CheckBoxProdutoVerto.Checked = False
        CheckBoxProjGen.Checked = False
        check_textbox = True
        previewClean()
    End Sub


    Private Sub ButtonPreview_Click(sender As Object, e As EventArgs) Handles ButtonPreview.Click

        If Not CheckBoxSnmrCliente.Checked Then TextBox_nome_cliente.Text = NomeClienteSybus(TextBox_n_cliente.Text)

        nomeCliente = TextBox_nome_cliente.Text

        TreeView1.Nodes.Clear()
        Dim folderPath As String
        Dim tNode As TreeNode = Nothing
        Dim xNodes As XmlNodeList = ModelNode.ChildNodes 'document.SelectNodes("modeldirectory/rootdirectory")

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


        Dim txt As String = ""
        If TipoPasta = 0 Then
            If ComboBoxRespProj.Text = "" And ComboBoxRespAP.Text = "" Then
                txt = "Os campos Responsável do Projeto e Responsável do Processo não estão preenchidos."
            ElseIf ComboBoxRespProj.Text = "" Then
                txt = "O campo Responsável do Projeto não está preenchido."
            ElseIf ComboBoxRespap.Text = "" Then
                txt = "O campo Responsável do Processo não está preenchido."
            End If
        Else
            If ComboBoxRespAP.Text = "" Then txt = "O campo Responsável de A.P. não está preenchido."
        End If

        If txt <> "" Then MsgBox(txt)

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


    Private Sub ComboBoxRespAP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRespAP.SelectedIndexChanged
        respAP = ComboBoxRespAP.Text
    End Sub

    Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Visible = False
        SplashScreen.Show(Me)

        SEMnCliente = False
        nomeClienteOK = True

        If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                LabelVersion.Text = .Major & "." & .Minor & "." & .Build & "." & .Revision
            End With
        End If

        Try
            'If TipoPasta = 0 Then
            document.Load(folderTreeXMLproj)
            'Else
            '    document.Load(folderTreeXMLap)
            'End If
        Catch
            If My.Computer.FileSystem.GetDirectoryInfo("e:\Users\Inacio\Documents\Seafile\VERTO\PROGRAMACAO\Criar_Pastas\IGNORE\").Exists Then
                document.Load("e:\Users\Inacio\Documents\Seafile\VERTO\PROGRAMACAO\Criar_Pastas\IGNORE\folderTree_I.xml")
                debug = True
            Else
                MsgBox("O ficheiro xml com a árvore de pastas não foi encontrado.", MsgBoxStyle.MsgBoxSetForeground)
                End
            End If
        End Try

        Dim node As XmlNode
        Dim y As Integer = 0

        node = document.SelectSingleNode("foldertree/projetistas")
        ReDim Projetistas(node.ChildNodes.Count - 1)
        For Each chNode As XmlNode In node.ChildNodes
            Projetistas(y) = chNode.Attributes("name").Value
            y = y + 1
        Next

        y = 0
        node = document.SelectSingleNode("foldertree/orcamentistas")
        ReDim Orcamentistas(node.ChildNodes.Count - 1)
        For Each chNode As XmlNode In node.ChildNodes
            Orcamentistas(y) = chNode.Attributes("name").Value
            y = y + 1
        Next

        For y = 0 To Projetistas.GetUpperBound(0)
            ComboBoxRespProj.Items.Add(Projetistas(y))
        Next

        For y = 0 To Orcamentistas.GetUpperBound(0)
            ComboBoxRespAP.Items.Add(Orcamentistas(y))
        Next

        node = document.SelectSingleNode("foldertree")

        ModelNode = baseFoldersReading(node.ChildNodes, TipoPasta)

        If TipoPasta = 0 Then
            getAllFoldersPROJ(PastaID, ProjectFolders)
        Else
            Dim yOffset As Integer = 70
            getAllFoldersAP(PastaID, ProjectFolders)
            Me.Text = "Criar Pasta de Análise de Projeto"
            CheckBoxProdutoVerto.Visible = False

            LabelNenc.Visible = False
            TextBox_n_enc.Visible = False

            LabelRespProj.Visible = False
            ComboBoxRespProj.Visible = False
            LabelRespProj.Visible = False
            TextBoxRespProjBorder.Visible = False

            ComboBoxRespAP.Location = New Point(ComboBoxRespAP.Location.X, ComboBoxRespAP.Location.Y - yOffset)
            LabelRespAP.Location = New Point(24, LabelRespAP.Location.Y - yOffset)
            LabelRespAP.Text = "Resp.A.P.:"
            TextBoxRespAPborder.Location = New Point(TextBoxRespAPborder.Location.X, TextBoxRespAPborder.Location.Y - yOffset)

            LabelPastaProd.Visible = False
            TextBoxPastaProd.Visible = False

            LabelPastaID.Location = New Point(LabelPastaID.Location.X, 36)
            TextBoxPastaID.Location = New Point(TextBoxPastaID.Location.X, 32)

            LabelNproj.Text = "Nº A.P.:"
            LabelNproj.Location = New Point(39, LabelNproj.Location.Y)
            ComboBox_n_projeto.MaxLength = 10

            LabelDesigProj.Text = "Desig. A.P.:"
            LabelDesigProj.Location = New Point(22, LabelDesigProj.Location.Y)

            Me.Height = Me.Height - yOffset

            TextBox_nome_cliente.Visible = True

            CheckBoxSnmrCliente.Visible = True

            CheckBoxProjGen.Visible = False
            TextBoxProjGen.Visible = False


            nEncOK = True
        End If

        SplashScreen.Close()
        Me.Visible = True
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
            Call validateALL()
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
            ComboBox_nome_cliente.Visible = True
            TextBox_n_cliente_Leave(sender, e)
        Else
            TextBox_n_cliente.Enabled = True
            SEMnCliente = False
            TextBox_n_cliente.Clear()
            TextBox_nome_cliente.Clear()
            ComboBox_nome_cliente.visible = False
            TextBox_nome_cliente.Enabled = False
        End If
        Call previewClean()
        Call nClienteValidation()
    End Sub


    Private Sub TextBox_nome_cliente_TextChanged(sender As Object, e As EventArgs) Handles TextBox_nome_cliente.TextChanged
        previewClean()
        Call validateALL() 'nomeClienteValidation()
    End Sub


    Private Sub TextBox_nome_cliente_Leave(sender As Object, e As EventArgs) Handles TextBox_nome_cliente.Leave
        TextBox_nome_cliente.Text = UCase(TextBox_nome_cliente.Text)
    End Sub


    Private Sub ComboBox_nome_cliente_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_nome_cliente.TextChanged
        If CheckBoxSnmrCliente.Checked Then TextBox_nome_cliente.Text = ComboBox_nome_cliente.Text
    End Sub


    Private Sub CheckBoxProjGen_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProjGen.CheckedChanged
        If CheckBoxProjGen.Checked Then
            TextBoxProjGen.Enabled = True
            projGen = True
        Else
            TextBoxProjGen.Enabled = False
            TextBoxProjGen.Clear()
            projGen = False
        End If
        Call previewClean()
        Call validateALL() 'desigProjGenValidation()
    End Sub

    Private Sub TextBoxProjGen_Leave(sender As Object, e As EventArgs) Handles TextBoxProjGen.Leave
        TextBoxProjGen.Text = UCase(TextBoxProjGen.Text)
    End Sub


    Private Sub TextBoxProjGen_TextChanged(sender As Object, e As EventArgs) Handles TextBoxProjGen.TextChanged
        previewClean()
        Call validateALL()
    End Sub

    Private Sub FormMain_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Call validateALL()
    End Sub

    Private Sub PanelButtons_Click(sender As Object, e As EventArgs) Handles PanelButtons.Click
        Call validateALL()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Call validateALL()
    End Sub

    Private Sub TextBox_desig_proj_Leave(sender As Object, e As EventArgs) Handles TextBox_desig_proj.Leave
        TextBox_desig_proj.Text = UCase(TextBox_desig_proj.Text)
    End Sub

    Private Sub ComboBox_nome_cliente_Leave(sender As Object, e As EventArgs) Handles ComboBox_nome_cliente.Leave
        ComboBox_nome_cliente.Text = UCase(ComboBox_nome_cliente.Text)
    End Sub

End Class
