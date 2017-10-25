Imports System.IO
Imports System.Xml

Public Class Form1
    Dim document As New XmlDocument()
    Dim PastaID, PastaProd, PastaModelo As String
    Dim nProj, desProj, nCliente, nEnc, CnCliente, anoProd As String
    Dim Enc As Boolean
    Dim ProjectFolders() As String = {}
    Dim check_textbox As Boolean = True


    Private Sub TextBox_n_cliente_TextChanged(sender As Object, e As EventArgs) Handles TextBox_n_cliente.TextChanged
        OnlyNumbers()
    End Sub


    Private Sub TextBox_n_projeto_TextChanged(sender As Object, e As EventArgs) Handles TextBox_n_projeto.TextChanged
        check_double()
    End Sub


    Private Sub TextBox_n_enc_TextChanged(sender As Object, e As EventArgs) Handles TextBox_n_enc.TextChanged
        OnlyNumbers()
    End Sub


    Private Sub RadioButton_projeto_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_projeto.CheckedChanged
        If RadioButton_projeto.Checked Then RadioButton_encomenda.Checked = False
    End Sub


    Private Sub TextBox_n_projeto_Leave(sender As Object, e As EventArgs) Handles TextBox_n_projeto.Leave
        Dim x As Integer = 0
        If checkNproj(nProj) Then
            x = 50
            TextBox_n_projeto.ForeColor = Color.Crimson
            ToolTip1.ToolTipTitle = "O nº de projeto já existe."
            ToolTip1.Active = True
            ToolTip1.Show(vbNewLine, TextBox_n_projeto, x, 20)
            ToolTip1.Show(vbNewLine, TextBox_n_projeto, x, 20)
        Else
            ToolTip1.Active = False
            ToolTip1.Hide(TextBox_n_projeto)
        End If
        If checkNproj(nProj) Then
            TextBox_n_projeto.ForeColor = Color.Crimson
            ToolTip2.ToolTipTitle = "O formato não está correto."
            ToolTip2.Active = True
            ToolTip2.Show(vbNewLine, TextBox_n_projeto, 50 + x, 20)
            ToolTip2.Show(vbNewLine, TextBox_n_projeto, 50 + x, 20)
        Else
            ToolTip2.Active = False
            ToolTip2.Hide(TextBox_n_projeto)
        End If
    End Sub


    Private Sub RadioButton_encomenda_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_encomenda.CheckedChanged
        If RadioButton_encomenda.Checked Then RadioButton_projeto.Checked = False
    End Sub


    Private Sub Button_criar_Click(sender As Object, e As EventArgs) Handles Button_criar.Click
        nProj = TextBox_n_projeto.Text
        desProj = UCase(TextBox_desig_proj.Text)
        nCliente = TextBox_n_cliente.Text
        nEnc = TextBox_n_enc.Text
        Enc = RadioButton_encomenda.Checked
        CnCliente = nCliente
        anoProd = "20" & Strings.Left(nProj, 2)

        For i = 1 To 4 - Len(nCliente)
            CnCliente = "0" & CnCliente
        Next

        CnCliente = "C" & CnCliente

        CreateDirectories(document.SelectNodes("modeldirectory/rootdirectory"))
    End Sub


    Private Function getAllFolders(ByVal directory As String) As String()
        Dim diFather As New IO.DirectoryInfo(directory) 'Create object
        Dim diFatherArr() As DirectoryInfo 'Array to store paths
        Dim path() As String = {}
        Dim driFather As DirectoryInfo
        Dim i As Integer = 0

        If System.IO.Directory.Exists(directory) Then
            diFatherArr = diFather.GetDirectories()
        Else
            MsgBox("Não foi possível obter a listagem dos projetos existentes!")
            End
        End If

        For Each driFather In diFatherArr
            Dim diChild As New IO.DirectoryInfo(driFather.FullName) 'Create object
            Dim diChildArr As DirectoryInfo() = diChild.GetDirectories() 'Array to store paths
            Dim driChild As DirectoryInfo
            For Each driChild In diChildArr
                Array.Resize(path, i + 1)
                path(i) = driChild.Name
                i = i + 1
            Next driChild
        Next driFather
            getAllFolders = path
    End Function


    Private Function checkNproj(ByVal nProj As String) As Boolean
        checkNproj = False
        For i As Integer = 0 To ProjectFolders.Length - 1
            If ProjectFolders(i) = nProj Then checkNproj = True
            i = ProjectFolders.Length - 1
        Next
    End Function

    Private Sub Button_limpar_Click(sender As Object, e As EventArgs) Handles Button_limpar.Click
        check_textbox = False
        TextBox_n_cliente.Text = Nothing
        TextBox_n_enc.Text = Nothing
        TextBox_n_projeto.Text = Nothing
        TextBox_desig_proj.Text = Nothing
        RadioButton_projeto.Checked = True
        check_textbox = True
    End Sub

    Private Sub TextBox_n_enc_Leave(sender As Object, e As EventArgs) Handles TextBox_n_enc.Leave
        If Len(TextBox_n_enc.Text) <> 7 Or (Strings.Left(TextBox_n_enc.Text, 4) <> CStr(Year(Now)) And Strings.Left(TextBox_n_enc.Text, 4) <> CStr(Year(Now) - 1)) Then
            TextBox_n_enc.ForeColor = Color.Crimson
            ToolTip3.ToolTipTitle = "O nº de encomenda não está no formato correto."
            ToolTip3.Active = True
            ToolTip3.Show(vbNewLine, TextBox_n_enc, 50, 20)
            ToolTip3.Show(vbNewLine, TextBox_n_enc, 50, 20)
        Else
            ToolTip3.Active = False
            ToolTip3.Hide(TextBox_n_enc)
        End If
    End Sub


    Private Sub replace_vars(ByRef text As String)
        text = Replace(text, "CnCliente", CnCliente)
        text = Replace(text, "numEnc", nEnc)
        text = Replace(text, "numProj", nProj)
        text = Replace(text, "numEnc", nEnc)
        text = Replace(text, "numCliente", nCliente)
        text = Replace(text, "prodAno", anoProd)
    End Sub


    Private Sub CreateDirectories(ByVal nodes As XmlNodeList)
        Dim pasta As String
        Dim proj As String = nProj & " - " & desProj
        For Each node As XmlNode In nodes
            pasta = node.Attributes("path").Value & proj & "\"
            replace_vars(pasta)
            Debug.Print(pasta)
            'Directory.CreateDirectory(pasta)
            If node.HasChildNodes Then
                CreateSubDirectories(pasta, node.ChildNodes)
            End If
        Next
    End Sub


    Private Sub CreateSubDirectories(ByVal pasta As String, ByVal nodes As XmlNodeList)
        For Each node As XmlNode In nodes
            If node.Name = "directory" Then
                Dim directoryName As String = node.Attributes("name").Value
                Dim fullPath As String = pasta + directoryName + "\"
                replace_vars(fullPath)
                Debug.Print(fullPath)
                'Directory.CreateDirectory(fullPath)
                If node.HasChildNodes Then
                    CreateSubDirectories(fullPath, node.ChildNodes)
                End If
            ElseIf node.Name = "file" Then
                Dim fileName As String = node.Attributes("name").Value
                Dim origFile As String = node.Attributes("path").Value
                Dim ext As String = Strings.Right(origFile, Len(origFile) - InStrRev(origFile, "."))
                Dim destFile As String = pasta + fileName + ext
                replace_vars(destFile)
                Debug.Print(destFile)
                'FileCopy(origFile, destFile)
            Else

            End If
        Next
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim NodeName As String
        MsgBox(My.Application.Info.DirectoryPath)
        document.Load("d:\Inacio\Documents\Seafile\VERTO\PROGRAMAÇÃO\DESENVOLVIMENTO\Criar_Pastas\teste.xml")
        PastaModelo = document.SelectNodes("modeldirectory")(0).Attributes("path").Value
        For Each node As XmlNode In document.SelectNodes("modeldirectory/rootdirectory")
            NodeName = node.Attributes("name").Value
            If NodeName = "Desenvolvimento" Then PastaID = node.Attributes("path").Value '"d:\Inacio\Documents\Seafile\VERTO\SOLIDWORKS\"
            If NodeName = "Produção" Then PastaProd = node.Attributes("path").Value
        Next
        ProjectFolders = getAllFolders(PastaID)
    End Sub

    Private Sub OnlyNumbers()
        If TypeName(Me.ActiveControl) = "TextBox" Then
            With Me.ActiveControl
                If Not IsNumeric(.Text) And .Text <> vbNullString Then
                    MsgBox("Sorry, only numbers allowed")
                    .Text = Strings.Left(Me.ActiveControl.Text, Len(Me.ActiveControl.Text) - 1)
                End If
            End With
        End If
    End Sub



    Private Sub check_double()
        Dim KeyAscii As Integer
        Dim texto As String
        Dim validacao As Boolean
        Dim textbox As Object

        If check_textbox = True Then
            validacao = True

            textbox = Me.ActiveControl
            texto = textbox.Value

            If texto <> "" Then
                KeyAscii = Asc(Strings.Right(texto, 1))
                Select Case KeyAscii
                    Case Keys.D0 To Keys.D9
                    Case 44 '~~> Check to see if there is already a decimal | 44 --> "," 46 --> "."
                        If InStr(1, Strings.Left(texto, Len(texto) - 1), ",") Or InStr(1, Strings.Left(texto, Len(texto) - 1), ".") Then validacao = False
                    Case 46 '~~> Check to see if there is already a decimal | 44 --> "," 46 --> "."
                        If InStr(1, Strings.Left(texto, Len(texto) - 1), ",") Or InStr(1, Strings.Left(texto, Len(texto) - 1), ".") Then validacao = False
                    Case Else
                        validacao = False
                End Select
            End If

            If validacao = False Then
                textbox.Value = Strings.Left(texto, Len(texto) - 1)
                'MsgBox "Sorry, only numbers allowed"
            End If
        End If
    End Sub
End Class
