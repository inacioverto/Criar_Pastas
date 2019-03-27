Module FunctionsFieldsValidation

    Sub validateALL()
        Call nClienteValidation(False)
        Call nProjetoValidation(False)
        Call nEncValidation(False)
        Call desigProjValidation(False)
        Call desigProjGenValidation(False)
        Call nomeClienteValidation(False)
        Call fieldActivation()
    End Sub

    Private Sub fieldActivation()
        If nClienteOK And nProjOK Then 'nproj 'nenc 'ncliente 'desigproj
            FormMain.TextBoxProjeto.Text = nProj + " - " + desProj
            If desProjGenOK And projGen Then
                FormMain.TextBoxProjeto.Text = FormMain.TextBoxProjeto.Text + " | " + desProjGen
            End If
            If nEncOK Then
                FormMain.TextBoxProjeto.Text = FormMain.TextBoxProjeto.Text + " | " + nEnc
            End If

            If nEncOK And desProjOK Then
                FormMain.GroupBoxPastas.Enabled = True
                TextboxPastasFill()
                If desProjOK And desProjGenOK Then
                    FormMain.ButtonPreview.Enabled = True
                Else
                    FormMain.ButtonPreview.Enabled = False
                End If
            End If

        ElseIf Not nEncOK Or Not nomeClienteOK Then
            FormMain.GroupBoxPastas.Enabled = False
            FormMain.TextBoxPastaID.Text = ""
            FormMain.TextBoxPastaProd.Text = ""
        End If
    End Sub


    Sub nClienteValidation(Optional ByVal activateFields As Boolean = True)
        If SEMnCliente Then
            nClienteOK = True
        Else
            Dim i As Integer
            nCliente = FormMain.TextBox_n_cliente.Text
            nClienteOK = False

            If nCliente <> "" Then
                CnCliente = nCliente
                For i = 1 To 4 - Len(nCliente)
                    CnCliente = "0" & CnCliente
                Next
                CnCliente = "C" & CnCliente
                nClienteOK = True
                If CnCliente = "C0000" Then
                    FormMain.CheckBoxProdutoVerto.Enabled = True
                Else
                    FormMain.CheckBoxProdutoVerto.Enabled = False
                    FormMain.CheckBoxProdutoVerto.Checked = False
                End If
            Else
                FormMain.CheckBoxProdutoVerto.Enabled = False
                FormMain.CheckBoxProdutoVerto.Checked = False
            End If
        End If

        If activateFields Then Call fieldActivation()
    End Sub


    Sub nProjetoValidation(Optional ByVal activateFields As Boolean = True)
        Dim x As Integer = FormMain.ComboBox_n_projeto.Width - 20
        Dim y As Integer = 10

        FormMain.ComboBox_n_projeto.Text = UCase(FormMain.ComboBox_n_projeto.Text)

        nProj = FormMain.ComboBox_n_projeto.Text
        nProjOK = False
        FormMain.ToolTipNprojExists.Active = False
        FormMain.ToolTipNprojExists.Hide(FormMain.ComboBox_n_projeto)
        FormMain.ToolTipNprojFormat.Active = False
        FormMain.ToolTipNprojFormat.Hide(FormMain.ComboBox_n_projeto)
        FormMain.ComboBox_n_projeto.ForeColor = Color.Black

        If nProj <> Nothing Then
            If checkNprojFormat(nProj) Then
                FormMain.ComboBox_n_projeto.ForeColor = Color.Crimson
                FormMain.ToolTipNprojFormat.Active = True
                FormMain.ToolTipNprojFormat.Show("O formato não está correto.", FormMain.ComboBox_n_projeto, x, y)
            Else
                If checkNprojExists(nProj) Then FormMain.ComboBox_n_projeto.ForeColor = Color.DarkOrange
                anoProd = "20" & Strings.Left(nProj, 2)
                nProjOK = True
            End If
        End If

        If activateFields Then Call fieldActivation()

    End Sub


    Sub nEncValidation(Optional ByVal activateFields As Boolean = True)
        If TipoPasta = 1 Then 'AP
            nEncOK = True
        Else
            Dim x As Integer = FormMain.TextBox_n_enc.Width - 20
            Dim y As Integer = 10
            Dim nEncAux As String = FormMain.TextBox_n_enc.Text

            If nEncAux = Nothing Then
                nEncOK = False
            ElseIf checkNenc(FormMain.TextBox_n_enc.Text, FormMain.CheckBoxProdutoVerto.Checked) Then
                FormMain.TextBox_n_enc.ForeColor = Color.Crimson
                FormMain.ToolTipNenc.Active = True
                FormMain.ToolTipNenc.Show("O nº de encomenda não está no formato correto.", FormMain.TextBox_n_enc, x, y)
                nEncOK = False
            Else
                FormMain.ToolTipNenc.Active = False
                FormMain.ToolTipNenc.Hide(FormMain.TextBox_n_enc)
                nEnc = nEncAux
                nEncOK = True
                FormMain.TextBox_n_enc.ForeColor = Color.Black
            End If
        End If

        If activateFields Then Call fieldActivation()
    End Sub


    Sub desigProjValidation(Optional ByVal activateFields As Boolean = True)
        Dim x As Integer = FormMain.TextBox_desig_proj.Width - 20
        Dim y As Integer = 10
        Dim erro As String = ""

        desProj = UCase(FormMain.TextBox_desig_proj.Text)
        desProjOK = False

        If desProj <> "" Then
            If checkDesigProj(desProj, nProj, erro) Then
                FormMain.TextBox_desig_proj.ForeColor = Color.Crimson
                FormMain.ToolTipDesigProj.Active = True
                FormMain.ToolTipDesigProj.Show(erro, FormMain.TextBox_desig_proj, x, y)
            Else
                FormMain.TextBox_desig_proj.ForeColor = Color.Black
                FormMain.ToolTipDesigProj.Active = False
                FormMain.ToolTipDesigProj.Hide(FormMain.TextBox_desig_proj)
                desProjOK = True
            End If
        End If

        If activateFields Then Call fieldActivation()

    End Sub

    Sub desigProjGenValidation(Optional ByVal activateFields As Boolean = True)

        If Not projGen Then
            desProjGenOK = True
        Else
            Dim x As Integer = FormMain.TextBoxProjGen.Width - 20
            Dim y As Integer = 10
            Dim erro As String = ""

            desProjGen = UCase(FormMain.TextBoxProjGen.Text)
            desProjGenOK = False

            If desProjGen <> "" And FormMain.TextBoxProjGen.Enabled = True Then
                If checkNomeCliente(desProjGen, erro) Then
                    FormMain.TextBoxProjGen.ForeColor = Color.Crimson
                    FormMain.ToolTipDesigProj.Active = True
                    FormMain.ToolTipDesigProj.Show(erro, FormMain.TextBoxProjGen, x, y)
                Else
                    FormMain.TextBoxProjGen.ForeColor = Color.Black
                    FormMain.ToolTipDesigProj.Active = False
                    FormMain.ToolTipDesigProj.Hide(FormMain.TextBoxProjGen)
                    desProjGenOK = True
                End If
            End If
        End If

        If activateFields Then Call fieldActivation()
    End Sub


    Sub nomeClienteValidation(Optional ByVal activateFields As Boolean = True)
        If Not SEMnCliente Then
            nomeClienteOK = True
        Else
            Dim x As Integer = FormMain.TextBox_nome_cliente.Width - 20
            Dim y As Integer = 10
            Dim erro As String = ""

            nomeCliente = UCase(FormMain.TextBox_nome_cliente.Text)
            nomeClienteOK = False

            If nomeCliente <> "" Then
                If checkNomeCliente(nomeCliente, erro) Then
                    FormMain.TextBox_nome_cliente.ForeColor = Color.Crimson
                    FormMain.ToolTipDesigProj.Active = True
                    FormMain.ToolTipDesigProj.Show(erro, FormMain.TextBox_nome_cliente, x, y)
                Else
                    FormMain.TextBox_nome_cliente.ForeColor = Color.Black
                    FormMain.ToolTipDesigProj.Active = False
                    FormMain.ToolTipDesigProj.Hide(FormMain.TextBox_nome_cliente)
                    nomeClienteOK = True
                End If
            End If
        End If
        If activateFields Then Call fieldActivation()
    End Sub


    Private Function checkNprojExists(ByVal nProj As String) As Boolean 'FALSE - OK  |  TRUE - NOK
        Dim i As Integer
        Dim nmrAux As String
        Dim DesigAux, NomeClienteAux As String

        checkNprojExists = False

        For i = 0 To ProjectFolders.GetUpperBound(1)
            nmrAux = ProjectFolders(0, i)
            DesigAux = ProjectFolders(1, i)
            NomeClienteAux = ProjectFolders(3, i)
            If nmrAux = nProj Then
                checkNprojExists = True
                i = ProjectFolders.Length
                FormMain.TextBox_desig_proj.Enabled = False
                FormMain.TextBox_desig_proj.Text = DesigAux
                If FormMain.CheckBoxSnmrCliente.Checked Then
                    FormMain.TextBox_nome_cliente.Text = NomeClienteAux
                    FormMain.TextBox_nome_cliente.Enabled = False
                End If
                'desProjOK = True
            End If
        Next
        If checkNprojExists = False Then FormMain.TextBox_desig_proj.Enabled = True
    End Function


    Private Function checkNprojFormat(ByVal nProj As String) As Boolean 'FALSE - OK  |  TRUE - NOK

        checkNprojFormat = False

        If nProj <> Nothing Then
            If TipoPasta = 0 Then
                If nProj.Length > 3 Then
                    If nProj(2) <> "." Or nProj.Length <> 7 Then
                        checkNprojFormat = True
                    End If
                Else
                    checkNprojFormat = True
                End If
            Else 'TipoPasta = 1
                If nProj.Length > 6 Then
                    If Strings.Right(Strings.Left(nProj, 6), 4) <> ".AP." Or nProj.Length <> 10 Then
                        checkNprojFormat = True
                    End If
                Else
                    checkNprojFormat = True
                End If
            End If
        End If
    End Function


    Private Function checkNenc(ByVal nEnc As String, ByVal ProdutoVerto As Boolean) As Boolean 'FALSE - OK  |  TRUE - NOK

        checkNenc = True

        If (Strings.Left(nEnc, 4) = CStr(Year(Now)) Or Strings.Left(nEnc, 4) = CStr(Year(Now) - 1)) Then
            If Not ProdutoVerto And nEnc.Length = 8 Then
                checkNenc = False
            ElseIf ProdutoVerto And nEnc.Length > 9 Then
                If nEnc(8) = "." Then
                    checkNenc = False
                End If
            End If
        End If

    End Function

    Private Function checkNomeCliente(ByVal nomeCli As String, ByRef erro As String) As Boolean 'FALSE - OK  |  TRUE - NOK

        checkNomeCliente = False

        If Not IsValidFileNameOrPath(nomeCli) Then
            checkNomeCliente = True
            erro = "O campo contém caracteres inválidos."
            Exit Function
        End If

        If Replace(nomeCli, " ", "") = "" Then
            checkNomeCliente = True
            erro = "O campo está vazio."
        End If
    End Function


    Private Function checkDesigProj(ByVal DesigProj As String, ByVal NmrProj As String, ByRef erro As String) As Boolean 'FALSE - OK  |  TRUE - NOK
        Dim i As Integer
        Dim DesigAux, nmrProjAux As String

        checkDesigProj = False

        If Not IsValidFileNameOrPath(DesigProj) Then
            checkDesigProj = True
            erro = "O campo contém caracteres inválidos."
            Exit Function
        End If

        For i = 0 To ProjectFolders.GetUpperBound(1)
            DesigAux = ProjectFolders(1, i)
            nmrProjAux = ProjectFolders(0, i)
            If UCase(DesigAux) = UCase(DesigProj) And nmrProjAux <> NmrProj Then
                checkDesigProj = True
                erro = "Já existe um projeto com esta designação."
                Exit Function
            End If
        Next

        If Replace(DesigProj, " ", "") = "" Then
            checkDesigProj = True
            erro = "O campo está vazio."
        End If
    End Function

End Module
