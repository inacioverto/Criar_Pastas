Option Explicit On

Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Module Functions

    Function NomeClienteSybus(ByVal nmrcliente As Integer) As String
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim Sdr As SqlDataReader
        Dim dt As DataTable = New DataTable
        con = New SqlConnection(SybusDB)

        NomeClienteSybus = ""

        Try
            con.Open()
            cmd = New SqlCommand("select nome1 from clientes where num_cliente ='" + nmrcliente.ToString + "'", con)
            Sdr = cmd.ExecuteReader
            dt.Load(Sdr)
            NomeClienteSybus = dt.Rows(0)("nome1").ToString()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        con.Close()
    End Function


    Sub getAllFolders(ByVal directory As String, ByRef pathArray(,) As String)

        If System.IO.Directory.Exists(directory) Then
            Dim folderCount As Integer = 0
            Dim table As New DataTable
            table.Columns.Add("nmrProj", GetType(String))
            table.Columns.Add("desigProj", GetType(String))
            table.Columns.Add("nmrCliente", GetType(String))
            table.Columns.Add("pastaProd", GetType(String))

            Dim ProjetosDir As New IO.DirectoryInfo(directory) 'Create object
            Dim ClientesDirArr() As DirectoryInfo = ProjetosDir.GetDirectories() 'Array to store paths

            For Each ClientesDir In ClientesDirArr
                Dim ProjetosDirArr As DirectoryInfo() = ClientesDir.GetDirectories() 'Array to store paths

                For Each ProjetosDir In ProjetosDirArr
                    Dim DirCliente, DirProjeto As String
                    Dim ShortcutPath As String = ""
                    Dim ShortcutTarget As String = ""
                    Dim separatorPOS As Integer = 0

                    DirCliente = ClientesDir.Name
                    If UCase(Strings.Left(DirCliente, 1)) = "C" Then DirCliente = Strings.Right(DirCliente, DirCliente.Length - 1)

                    DirProjeto = ProjetosDir.Name
                    DirProjeto = Replace(DirProjeto, "–", "-")

                    Dim filesArr() As FileInfo = ProjetosDir.GetFiles()
                    For Each file In filesArr
                        If UCase(file.Extension) = ".LNK" Then
                            ShortcutPath = file.FullName
                        End If
                    Next

                    If ShortcutPath <> "" Then
                        Dim shell = CreateObject("WScript.Shell")
                        ShortcutTarget = shell.CreateShortcut(ShortcutPath).TargetPath
                    End If

                    'ReDim Preserve pathArray(3, i) ' 0 - Nº proj | 1 - Desig. Proj | 2 - Nº cliente | 3 - Pasta Prod.

                    separatorPOS = InStr(DirProjeto, " - ")

                    If separatorPOS > 0 Then
                        Dim nProjAux As String = Strings.Left(DirProjeto, separatorPOS - 1)
                        If nProjAux <> "" Then
                            table.Rows.Add(nProjAux, Strings.Right(DirProjeto, DirProjeto.Length - separatorPOS - 2), CStr(CInt(DirCliente)), ShortcutTarget)
                            folderCount = folderCount + 1
                        End If
                    End If
                Next ProjetosDir
            Next ClientesDir

            ReDim pathArray(3, folderCount - 1)
            Dim i As Integer = 0
            For Each tableRow In table.Rows
                pathArray(0, i) = tableRow.Item("nmrProj").ToString
                pathArray(1, i) = tableRow.Item("desigProj").ToString
                pathArray(2, i) = tableRow.Item("nmrCliente").ToString
                pathArray(3, i) = tableRow.Item("pastaProd").ToString
                i = i + 1
            Next tableRow

            table.Clear()

        Else
            MsgBox("Não foi possível obter a listagem dos projetos existentes!")
            ReDim pathArray(3, 0)
            pathArray(0, 0) = ""
            pathArray(1, 0) = ""
            pathArray(2, 0) = ""
            pathArray(3, 0) = ""
        End If
    End Sub


    Sub getAllFoldersOld(ByVal directory As String, ByRef pathArray(,) As String)
        Dim diFather As New IO.DirectoryInfo(directory) 'Create object
        Dim diFatherArr() As DirectoryInfo 'Array to store paths
        Dim driFather As DirectoryInfo
        Dim Pfolder, Cfolder As String
        Dim files() As String
        Dim ShortcutPath As String = ""
        Dim ShortcutTarget As String = ""
        Dim folderCount As Integer = 0
        Dim i As Integer = 0
        Dim separatorPOS As Integer = 0

        If System.IO.Directory.Exists(directory) Then
            diFatherArr = diFather.GetDirectories()

            For Each driFather In diFatherArr
                Dim diChild As New IO.DirectoryInfo(driFather.FullName) 'Create object
                Dim diChildArr As DirectoryInfo() = diChild.GetDirectories() 'Array to store paths
                Dim driChild As DirectoryInfo
                For Each driChild In diChildArr
                    folderCount = folderCount + 1
                Next
            Next
        End If

        ReDim pathArray(3, folderCount - 1)

        If System.IO.Directory.Exists(directory) Then
            diFatherArr = diFather.GetDirectories()

            For Each driFather In diFatherArr
                Dim diChild As New IO.DirectoryInfo(driFather.FullName) 'Create object
                Dim diChildArr As DirectoryInfo() = diChild.GetDirectories() 'Array to store paths
                Dim driChild As DirectoryInfo
                For Each driChild In diChildArr
                    Pfolder = driFather.Name
                    If UCase(Strings.Left(Pfolder, 1)) = "C" Then Pfolder = Strings.Right(Pfolder, Pfolder.Length - 1)

                    Cfolder = driChild.Name
                    Cfolder = Replace(Cfolder, "–", "-")

                    files = IO.Directory.GetFiles(driChild.FullName)
                    For Each file As String In files
                        If UCase(Path.GetExtension(file)) = ".LNK" Then
                            ShortcutPath = file
                        End If
                    Next

                    If ShortcutPath <> "" Then
                        Dim shell = CreateObject("WScript.Shell")
                        ShortcutTarget = shell.CreateShortcut(ShortcutPath).TargetPath
                    End If

                    'ReDim Preserve pathArray(3, i) ' 0 - Nº proj | 1 - Desig. Proj | 2 - Nº cliente | 3 - Pasta Prod.

                    separatorPOS = InStr(Cfolder, " - ")

                    If separatorPOS > 0 Then
                        Dim nProjAux As String = Strings.Left(Cfolder, separatorPOS - 1)
                        If nProjAux <> "" Then
                            pathArray(0, i) = nProjAux
                            pathArray(1, i) = Strings.Right(Cfolder, Cfolder.Length - separatorPOS - 2)
                            pathArray(2, i) = CInt(Pfolder)
                            pathArray(3, i) = ShortcutTarget
                            i = i + 1
                        End If
                    End If
                Next driChild
            Next driFather
        Else
            MsgBox("Não foi possível obter a listagem dos projetos existentes!")
            ReDim pathArray(3, 0)
            pathArray(0, 0) = ""
            pathArray(1, 0) = ""
            pathArray(2, 0) = ""
            pathArray(3, 0) = ""
        End If
    End Sub


    Sub replaceVars(ByRef text As String)
        text = Replace(text, "$pastaProd", PastaProd)
        text = Replace(text, "$CnumCliente", CnCliente)
        text = Replace(text, "$numEnc", nEnc)
        text = Replace(text, "$numProj", nProj)
        text = Replace(text, "$desProj", desProj)
        text = Replace(text, "$numEnc", nEnc)
        text = Replace(text, "$numCliente", nCliente)
        text = Replace(text, "$nomeCliente", nomeCliente)
        text = Replace(text, "$prodAno", anoProd)
        text = Replace(text, "$respProj", respProj)
        text = Replace(text, "\\", "\")
    End Sub


    Function checkNprojExists(ByVal nProj As String) As Boolean 'FALSE - OK  |  TRUE - NOK
        Dim i As Integer
        Dim nmrAux As String
        Dim DesigAux As String

        checkNprojExists = False

        For i = 0 To ProjectFolders.GetUpperBound(1)
            nmrAux = ProjectFolders(0, i)
            DesigAux = ProjectFolders(1, i)
            If nmrAux = nProj Then
                checkNprojExists = True
                i = ProjectFolders.Length
                FormMain.TextBox_desig_proj.Enabled = False
                FormMain.TextBox_desig_proj.Text = DesigAux
                desProjOK = True
            End If
        Next
        If checkNprojExists = False Then FormMain.TextBox_desig_proj.Enabled = True
    End Function


    Function checkNprojFormat(ByVal nProj As String) As Boolean 'FALSE - OK  |  TRUE - NOK

        checkNprojFormat = False

        If nProj <> Nothing Then
            If nProj.Length > 3 Then
                If nProj(2) <> "." Or nProj.Length <> 7 Then
                    checkNprojFormat = True
                End If
            Else
                checkNprojFormat = True
            End If
        End If
    End Function


    Function checkNenc(ByVal nEnc As String, ByVal ProdutoVerto As Boolean) As Boolean 'FALSE - OK  |  TRUE - NOK

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


    Function checkDesigProj(ByVal DesigProj As String, ByRef erro As String) As Boolean 'FALSE - OK  |  TRUE - NOK
        Dim i As Integer
        Dim DesigAux As String

        checkDesigProj = False

        If Not IsValidFileNameOrPath(desProj) Then
            checkDesigProj = True
            erro = "A designação do projeto contém caracteres inválidos."
            Exit Function
        End If

        For i = 0 To ProjectFolders.GetUpperBound(1)
            DesigAux = ProjectFolders(1, i)
            If UCase(DesigAux) = UCase(DesigProj) Then
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


    Sub CBnProjFill(ByVal CB As ComboBox, ByVal nCliente As String)
        Dim i As Integer
        Dim nClienteAux As String

        CB.Items.Clear()
        CB.Text = ""

        For i = 0 To ProjectFolders.GetUpperBound(1)
            nClienteAux = ProjectFolders(2, i)
            If nClienteAux <> "" And CInt(nClienteAux) = CInt(nCliente) Then
                CB.Items.Add(ProjectFolders(0, i))
            End If
        Next

    End Sub


    Function OnlyNumbers(ByVal texto As String) As String
        OnlyNumbers = texto
        If Not IsNumeric(texto) And texto <> vbNullString Then
            MsgBox("Sorry, only numbers allowed")
            OnlyNumbers = Strings.Left(texto, Len(texto) - 1)
        End If

    End Function


    Function check_double(ByVal texto As String) As String
        Dim KeyAscii As Integer
        Dim validacao As Boolean

        check_double = texto

        If check_textbox = True Then
            validacao = True

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
                check_double = Strings.Left(texto, Len(texto) - 1)
                MsgBox("Sorry, only numbers allowed")
            End If
        End If
    End Function


    Sub previewClean()
        FormMain.TreeView1.Nodes.Clear()
        FormMain.Button_criar.Enabled = False
        FormMain.ButtonPreview.Enabled = False
    End Sub


    Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        Dim invalidChars As List(Of String) = New List(Of String) From {"\", "/"}

        'If name Is Nothing Then
        '    Return False
        'End If

        For Each badChar As Char In System.IO.Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        For Each badChar As Char In invalidChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        Return True
    End Function

End Module
