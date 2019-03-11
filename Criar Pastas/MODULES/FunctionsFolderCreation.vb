Option Explicit On

Imports System.Xml
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Module FunctionsFolderCreation

    Dim exlApp As Excel.Application
    Dim newExlApp As Integer = True

    Sub CreateDirectories(ByVal nodes As XmlNodeList)
        Dim currentPath As String
        Dim proj As String = nProj & " - " & desProj

        For Each node As XmlNode In nodes
            'currentPath = node.Attributes("path").Value
            'If Strings.Right(currentPath, 1) <> "\" Then currentPath = currentPath & "\"
            'replaceVars(currentPath)

            If UCase(node.Attributes("name").Value) = "DESENVOLVIMENTO" Then            '-----
                currentPath = FormMain.TextBoxPastaID.Text
                pastaClienteID = currentPath
            ElseIf UCase(node.Attributes("name").Value) = "PRODUÇÃO" Then
                currentPath = FormMain.TextBoxPastaProd.Text
                pastaClienteProd = currentPath
            Else
                MsgBox("Erro nas pastas")
                Exit Sub
            End If

            If Strings.Right(currentPath, 1) <> "\" Then currentPath = currentPath & "\" '-----

            If My.Computer.FileSystem.GetDirectoryInfo(currentPath).Exists = False Then
                Directory.CreateDirectory(currentPath)
            End If

            If node.HasChildNodes Then
                CreateSubDirectories(currentPath, node.ChildNodes)
            End If
        Next
        If Not newExlApp Then
            exlApp.Quit()
            releaseObject(exlApp)
            newExlApp = True
        End If
    End Sub


    Sub CreateSubDirectories(ByVal currentPath As String, ByVal nodes As XmlNodeList)
        For Each node As XmlNode In nodes

            If node.Name = "directory" Then
                Dim projGenOnly As Boolean
                Try
                    projGenOnly = node.Attributes("projGenOnly").Value
                Catch 'ex As Exception
                    projGenOnly = False
                End Try

                If Not projGenOnly Or projGen Then 'não faz nada se for verdadeiro projGenOnly e falso projGen
                    Dim CXXX As Boolean
                    Try
                        CXXX = node.Attributes("CXXXX").Value
                    Catch 'ex As Exception
                        CXXX = False
                    End Try

                    If CXXX And SEMnCliente Then
                        currentPath = currentPath & nomeCliente & "\"

                        If My.Computer.FileSystem.GetDirectoryInfo(currentPath).Exists = False Then
                            Directory.CreateDirectory(currentPath)
                            'Debug.Print(currentPath)
                        End If
                    End If

                    Dim directoryName As String = node.Attributes("name").Value
                    Dim fullPath As String = currentPath + directoryName

                    If projGen Then
                        Dim projGenValue As String
                        Try
                            projGenValue = node.Attributes("projGenValue").Value
                        Catch 'ex As Exception
                            projGenValue = ""
                        End Try
                        fullPath = fullPath + projGenValue
                    End If

                    fullPath = fullPath + "\"
                    replaceVars(fullPath)

                    If My.Computer.FileSystem.GetDirectoryInfo(fullPath).Exists = False Then
                        Directory.CreateDirectory(fullPath)
                        'Debug.Print(fullPath)
                    End If

                    If node.HasChildNodes Then
                        CreateSubDirectories(fullPath, node.ChildNodes)
                    End If
                End If

            ElseIf node.Name = "file" Then
                Dim projGenOnly As Boolean
                Try
                    projGenOnly = node.Attributes("projGenOnly").Value
                Catch 'ex As Exception
                    projGenOnly = False
                End Try

                If Not projGenOnly Or projGen Then 'não faz nada se for verdadeiro projGenOnly e falso projGen
                    Dim fileName As String = node.Attributes("name").Value
                    Dim origFile As String = PastaModelo & node.Attributes("path").Value
                    Dim ext As String = Path.GetExtension(origFile) 'Strings.Right(origFile, Len(origFile) - InStrRev(origFile, ".") + 1)
                    Dim destFile As String = currentPath + fileName

                    If projGen Then
                        Dim projGenValue As String
                        Try
                            projGenValue = node.Attributes("projGenValue").Value
                        Catch 'ex As Exception
                            projGenValue = ""
                        End Try
                        destFile = destFile + projGenValue
                    End If

                    destFile = destFile + ext
                    replaceVars(destFile)

                    If File.Exists(destFile) = False Then
                        FileCopy(origFile, destFile)
                        If node.HasChildNodes Then
                            editExcelFile(destFile, node)
                        End If
                    End If
                End If

            ElseIf node.Name = "shortcut" Then
                Dim name As String = node.Attributes("name").Value
                Dim orig As String = pastaClienteProd & "\$numProj - $desProj\"    'node.Attributes("orig").Value 
                'Dim dest As String = node.Attributes("dest").Value
                replaceVars(name)
                replaceVars(orig)
                'replaceVars(dest)

                If Strings.Right(orig, 1) <> "\" Then orig = orig & "\"

                CreateShortCut(orig, currentPath, name)
                Process.Start("explorer.exe", currentPath)
            End If
        Next
    End Sub


    Sub CreateShortCut(ByVal TargetPath As String, ByVal ShortCutPath As String, ByVal ShortCutName As String)
        Dim objShell, objLink
        Dim LNKname As String

        If Strings.Right(ShortCutPath, 1) <> "\" Then ShortCutPath = ShortCutPath & "\"

        LNKname = ShortCutPath & ShortCutName & ".lnk"

        If Strings.Right(TargetPath, 1) <> "\" Then
            TargetPath = TargetPath & "\"
        End If

        If Not File.Exists(LNKname) Then
            objShell = CreateObject("WScript.Shell")
            objLink = objShell.CreateShortcut(LNKname)
            objLink.TargetPath = TargetPath
            objLink.Save
        End If
    End Sub

    Sub editExcelFile(ByVal filePath As String, node As XmlNode)
        If newExlApp Then
            exlApp = New Excel.Application
            exlApp.Visible = False
            newExlApp = False
        End If

        Dim worksheet As Excel.Worksheet
        Dim workbook As Excel.Workbook
        Dim sheetname, cell, cellValue As String
        Dim keep As Boolean
        Dim projGenOnly As Boolean

        workbook = exlApp.Workbooks.Open(filePath, IgnoreReadOnlyRecommended:=True, ReadOnly:=False)
        Try
            keep = node.Attributes("keep").Value
        Catch 'ex As Exception
            keep = False
        End Try

        For Each shtNode As XmlNode In node.ChildNodes
            sheetname = shtNode.Attributes("name").Value
            worksheet = workbook.Worksheets(sheetname)
            For Each cellNode As XmlNode In shtNode.ChildNodes
                Try
                    projGenOnly = cellNode.Attributes("projGenOnly").Value
                Catch 'ex As Exception
                    projGenOnly = False
                End Try
                If Not projGenOnly Or projGen Then 'não faz nada se for verdadeiro projGenOnly e falso projGen
                    cell = cellNode.Attributes("name").Value
                    cellValue = cellNode.Attributes("value").Value
                    If projGen Then
                        Dim projGenValue As String
                        Try
                            projGenValue = cellNode.Attributes("projGenValue").Value
                        Catch 'ex As Exception
                            projGenValue = ""
                        End Try
                        cellValue = cellValue + projGenValue
                    End If
                    replaceVars(cellValue)
                    worksheet.Range(cell).Value = cellValue
                End If
            Next
        Next
        workbook.Save()

        If keep Then
            exlApp.Visible = True
            newExlApp = True
            'exlApp = New Excel.Application
            'exlApp.Visible = True
        Else
            newExlApp = False
            workbook.Close()
            releaseObject(workbook)
        End If
    End Sub

End Module
