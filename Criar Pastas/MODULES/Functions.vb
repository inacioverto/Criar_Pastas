Option Explicit On

Imports System.Xml
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Module Functions

    Function baseFoldersReading(ByVal nodes As XmlNodeList, ByVal folderType As Integer) As XmlNode
        baseFoldersReading = Nothing
        Dim node As XmlNode = Nothing
        For Each node In nodes 'document.SelectNodes("modeldirectory/rootdirectory")
            If node.Name = "modeldirectory" Then
                Dim nodeType As String = node.Attributes("type").Value

                Select Case folderType
                    Case 0
                        If UCase(nodeType) = "PROJETO" Then
                            Exit For
                        End If
                    Case 1
                        If UCase(nodeType) = "AP" Then
                            Exit For
                        End If
                End Select
            End If
        Next

        If node IsNot Nothing Then
            Dim NodeName As String
            baseFoldersReading = node
            PastaModelo = node.Attributes("path").Value

            Dim childnode As XmlNode

            For Each childnode In node.ChildNodes
                If childnode.Name = "rootdirectory" Then
                    NodeName = UCase(childnode.Attributes("name").Value)
                    If NodeName = "DESENVOLVIMENTO" Then
                        PastaID = childnode.Attributes("path").Value
                        PastaID = Strings.Left(PastaID, InStrRev(PastaID, "\"))
                        If PastaID <> "" And Strings.Right(PastaID, 1) <> "\" Then PastaID = PastaID & "\"
                    End If

                    If NodeName = "PRODUÇÃO" Then
                        PastaProd = childnode.Attributes("path").Value
                        If PastaProd <> "" And Strings.Right(PastaProd, 1) <> "\" Then PastaProd = PastaProd & "\"
                    End If
                End If
            Next
        Else
            MsgBox("Erro no ficheiro xml: secççao 'modeldirectory' não encontrada.", MsgBoxStyle.MsgBoxSetForeground)
            End
        End If
    End Function


    Function NomeClienteSybus(ByVal nmrcliente As Integer) As String
        NomeClienteSybus = "TESTE"
        If Not debug Then
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
                MsgBox(ex.ToString)
            End Try
            con.Close()
        End If
    End Function


    Sub getAllFoldersPROJ(ByVal directory As String, ByRef pathArray(,) As String)

        If System.IO.Directory.Exists(directory) Then
            Dim folderCount As Integer = 0
            Dim table As New DataTable
            table.Columns.Add("nmrProj", GetType(String))
            table.Columns.Add("desigProj", GetType(String))
            table.Columns.Add("nmrCliente", GetType(String))
            table.Columns.Add("pastaProd", GetType(String))

            Dim DesenvDir As New IO.DirectoryInfo(directory) 'Create object
            Dim ClientesDirArr() As DirectoryInfo = DesenvDir.GetDirectories() 'Array to store paths

            For Each ClientesDir In ClientesDirArr
                Application.DoEvents()
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


    Sub getAllFoldersAP(ByVal directory As String, ByRef pathArray(,) As String)

        If System.IO.Directory.Exists(directory) Then
            Dim folderCount As Integer = 0
            Dim table As New DataTable
            table.Columns.Add("nmrProj", GetType(String))
            table.Columns.Add("desigProj", GetType(String))
            table.Columns.Add("nmrCliente", GetType(String))
            table.Columns.Add("nomeCliente", GetType(String))

            Dim DesenvDir As New IO.DirectoryInfo(directory) 'Create object
            Dim ClientesDirArr() As DirectoryInfo = DesenvDir.GetDirectories() 'Array to store paths

            For Each ClientesDir In ClientesDirArr
                Application.DoEvents()
                Dim DirCliente, nomeCliente As String

                DirCliente = ClientesDir.Name
                If UCase(Strings.Left(DirCliente, 1)) = "C" Then DirCliente = Strings.Right(DirCliente, DirCliente.Length - 1)

                If UCase(DirCliente) = "XXXX" Then
                    Dim NomesClientesDirArr As DirectoryInfo() = ClientesDir.GetDirectories()
                    For Each NomesClientesDir In NomesClientesDirArr
                        Dim ProjetosDirArr As DirectoryInfo() = NomesClientesDir.GetDirectories()
                        nomeCliente = NomesClientesDir.Name
                        addTableAP(ProjetosDirArr, DirCliente, nomeCliente, table, folderCount)
                    Next
                ElseIf IsNumeric(DirCliente) Then
                    Dim ProjetosDirArr As DirectoryInfo() = ClientesDir.GetDirectories() 'Array to store paths
                    nomeCliente = ""
                    addTableAP(ProjetosDirArr, CStr(CInt(DirCliente)), nomeCliente, table, folderCount)
                End If

            Next ClientesDir

            ReDim pathArray(3, folderCount - 1)
            Dim i As Integer = 0
            For Each tableRow In table.Rows
                pathArray(0, i) = tableRow.Item("nmrProj").ToString
                pathArray(1, i) = tableRow.Item("desigProj").ToString
                pathArray(2, i) = tableRow.Item("nmrCliente").ToString
                pathArray(3, i) = tableRow.Item("nomeCliente").ToString
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


    Sub addTableAP(ByVal ProjetosDirArr As DirectoryInfo(), ByVal nmrCliente As String, ByVal nomeCliente As String, ByRef table As DataTable, ByRef folderCount As Integer)
        For Each ProjetosDir In ProjetosDirArr
            Dim DirProjeto As String
            Dim separatorPOS As Integer = 0

            DirProjeto = ProjetosDir.Name
            DirProjeto = Replace(DirProjeto, "–", "-")

            separatorPOS = InStr(DirProjeto, " - ")

            If separatorPOS > 0 Then
                Dim nProjAux As String = Strings.Left(DirProjeto, separatorPOS - 1)
                If nProjAux <> "" Then
                    table.Rows.Add(nProjAux, Strings.Right(DirProjeto, DirProjeto.Length - separatorPOS - 2), nmrCliente, nomeCliente)
                    folderCount = folderCount + 1
                End If
            End If
        Next ProjetosDir
    End Sub


    'Sub getAllFoldersOld(ByVal directory As String, ByRef pathArray(,) As String)
    '    Dim diFather As New IO.DirectoryInfo(directory) 'Create object
    '    Dim diFatherArr() As DirectoryInfo 'Array to store paths
    '    Dim driFather As DirectoryInfo
    '    Dim Pfolder, Cfolder As String
    '    Dim files() As String
    '    Dim ShortcutPath As String = ""
    '    Dim ShortcutTarget As String = ""
    '    Dim folderCount As Integer = 0
    '    Dim i As Integer = 0
    '    Dim separatorPOS As Integer = 0

    '    If System.IO.Directory.Exists(directory) Then
    '        diFatherArr = diFather.GetDirectories()

    '        For Each driFather In diFatherArr
    '            Dim diChild As New IO.DirectoryInfo(driFather.FullName) 'Create object
    '            Dim diChildArr As DirectoryInfo() = diChild.GetDirectories() 'Array to store paths
    '            Dim driChild As DirectoryInfo
    '            For Each driChild In diChildArr
    '                folderCount = folderCount + 1
    '            Next
    '        Next
    '    End If

    '    ReDim pathArray(3, folderCount - 1)

    '    If System.IO.Directory.Exists(directory) Then
    '        diFatherArr = diFather.GetDirectories()

    '        For Each driFather In diFatherArr
    '            Dim diChild As New IO.DirectoryInfo(driFather.FullName) 'Create object
    '            Dim diChildArr As DirectoryInfo() = diChild.GetDirectories() 'Array to store paths
    '            Dim driChild As DirectoryInfo
    '            For Each driChild In diChildArr
    '                Pfolder = driFather.Name
    '                If UCase(Strings.Left(Pfolder, 1)) = "C" Then Pfolder = Strings.Right(Pfolder, Pfolder.Length - 1)

    '                Cfolder = driChild.Name
    '                Cfolder = Replace(Cfolder, "–", "-")

    '                files = IO.Directory.GetFiles(driChild.FullName)
    '                For Each file As String In files
    '                    If UCase(Path.GetExtension(file)) = ".LNK" Then
    '                        ShortcutPath = file
    '                    End If
    '                Next

    '                If ShortcutPath <> "" Then
    '                    Dim shell = CreateObject("WScript.Shell")
    '                    ShortcutTarget = shell.CreateShortcut(ShortcutPath).TargetPath
    '                End If

    '                'ReDim Preserve pathArray(3, i) ' 0 - Nº proj | 1 - Desig. Proj | 2 - Nº cliente | 3 - Pasta Prod.

    '                separatorPOS = InStr(Cfolder, " - ")

    '                If separatorPOS > 0 Then
    '                    Dim nProjAux As String = Strings.Left(Cfolder, separatorPOS - 1)
    '                    If nProjAux <> "" Then
    '                        pathArray(0, i) = nProjAux
    '                        pathArray(1, i) = Strings.Right(Cfolder, Cfolder.Length - separatorPOS - 2)
    '                        pathArray(2, i) = CInt(Pfolder)
    '                        pathArray(3, i) = ShortcutTarget
    '                        i = i + 1
    '                    End If
    '                End If
    '            Next driChild
    '        Next driFather
    '    Else
    '        MsgBox("Não foi possível obter a listagem dos projetos existentes!")
    '        ReDim pathArray(3, 0)
    '        pathArray(0, 0) = ""
    '        pathArray(1, 0) = ""
    '        pathArray(2, 0) = ""
    '        pathArray(3, 0) = ""
    '    End If
    'End Sub


    Sub replaceVars(ByRef text As String)
        text = Replace(text, "$data", Now.ToString("yyyy-MM-dd"))
        text = Replace(text, "$pastaProd", PastaProd)
        text = Replace(text, "$CnumCliente", CnCliente)
        text = Replace(text, "$numProj", nProj)
        text = Replace(text, "$desProj", desProj)
        text = Replace(text, "$projGen", desProjGen)
        text = Replace(text, "$numEnc", nEnc)
        text = Replace(text, "$numCliente", nCliente)
        text = Replace(text, "$nomeCliente", nomeCliente)
        text = Replace(text, "$prodAno", anoProd)
        text = Replace(text, "$respProj", respProj)
        text = Replace(text, "$respAP", respAP)
        text = Replace(text, "\\", "\")
    End Sub


    Sub CBnProjFill(ByVal CB As ComboBox, ByVal nCliente As String)
        Dim i As Integer
        Dim nClienteAux As String

        CB.Items.Clear()
        CB.Text = ""

        For i = 0 To ProjectFolders.GetUpperBound(1)
            nClienteAux = ProjectFolders(2, i)
            If Not SEMnCliente And IsNumeric(nClienteAux) Then
                If nClienteAux <> "" And CInt(nClienteAux) = CInt(nCliente) Then
                    CB.Items.Add(ProjectFolders(0, i))
                End If
            Else
                If nClienteAux <> "" And UCase(nClienteAux) = UCase(nCliente) Then
                    CB.Items.Add(ProjectFolders(0, i))
                End If
            End If
        Next

    End Sub


    Sub CBnomeClienteFill(ByVal CB As ComboBox)
        Dim i, j As Integer
        Dim nClienteAux As String
        Dim nomeClienteAux As String

        CB.Items.Clear()
        CB.Text = ""

        For i = 0 To ProjectFolders.GetUpperBound(1)
            nClienteAux = ProjectFolders(2, i)
            If UCase(nClienteAux) = "XXXX" Then
                nomeClienteAux = ProjectFolders(3, i)
                Dim adicionar As Boolean = True
                For j = 0 To CB.Items.Count - 1
                    If CB.Items(j) = nomeClienteAux Then
                        adicionar = False
                        Exit For
                    End If
                Next
                If adicionar Then CB.Items.Add(nomeClienteAux)
            End If
        Next

    End Sub


    Sub TextboxPastasFill(Optional ByVal ID As Boolean = True, Optional ByVal PROD As Boolean = True)
        Dim xNodes As XmlNodeList = ModelNode.ChildNodes 'document.SelectNodes("modeldirectory/rootdirectory")
        Dim folderPath As String

        For Each xNode As XmlNode In xNodes
            folderPath = xNode.Attributes("path").Value
            If Strings.Right(folderPath, 1) <> "\" Then folderPath = folderPath & "\"

            replaceVars(folderPath)

            If UCase(xNode.Attributes("name").Value) = "DESENVOLVIMENTO" And ID Then FormMain.TextBoxPastaID.Text = folderPath

            If UCase(xNode.Attributes("name").Value) = "PRODUÇÃO" And PROD Then

                If Not FormMain.CheckBoxProdutoVerto.Checked Then
                    FormMain.TextBoxPastaProd.Text = folderPath
                Else
                    FormMain.TextBoxPastaProd.Text = folderPath & "Produtos Verto\"
                End If
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

    Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Module
