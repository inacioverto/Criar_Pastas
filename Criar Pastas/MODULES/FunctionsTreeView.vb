Option Explicit On

Imports System.Xml
Imports System.IO

Module FunctionsTreeView


    Sub CreateSubDirectoriesTreeview(ByVal PARENTpath As String, ByVal xNodes As XmlNodeList, ByVal TparentNode As TreeNode, ByVal produtoVerto As Boolean)
        If Strings.Right(PARENTpath, 1) <> "\" Then PARENTpath = PARENTpath & "\"

        For Each xNode As XmlNode In xNodes

            If xNode.Name = "directory" Then
                Dim projGenOnly As Boolean
                Try
                    projGenOnly = xNode.Attributes("projGenOnly").Value
                Catch 'ex As Exception
                    projGenOnly = False
                End Try

                If Not projGenOnly Or projGen Then 'não faz nada se for verdadeiro projGenOnly e falso projGen
                    Dim CXXX As Boolean
                    Try
                        CXXX = xNode.Attributes("CXXXX").Value
                    Catch 'ex As Exception
                        CXXX = False
                    End Try

                    Dim tNode As TreeNode

                    If CXXX And SEMnCliente Then
                        PARENTpath = PARENTpath & nomeCliente & "\"

                        tNode = New TreeNode(nomeCliente)

                        If CreateNodeTreeview(PARENTpath, xNode.ChildNodes) Then
                            TparentNode.Nodes.Add(tNode)
                        End If
                        TparentNode = tNode
                    End If

                    Dim name As String = xNode.Attributes("name").Value

                    If projGen Then
                        Dim projGenValue As String
                        Try
                            projGenValue = xNode.Attributes("projGenValue").Value
                        Catch 'ex As Exception
                            projGenValue = ""
                        End Try
                        name = name + projGenValue
                    End If

                    replaceVars(name)

                    Dim fullPath As String = PARENTpath & name

                    tNode = New TreeNode(name)

                    If CreateNodeTreeview(fullPath, xNode.ChildNodes) Then
                        TparentNode.Nodes.Add(tNode)
                    End If

                    If xNode.HasChildNodes Then
                        CreateSubDirectoriesTreeview(fullPath, xNode.ChildNodes, tNode, produtoVerto)
                    End If
                End If

            ElseIf xNode.Name = "file" Then
                Dim projGenOnly As Boolean
                Try
                    projGenOnly = xNode.Attributes("projGenOnly").Value
                Catch 'ex As Exception
                    projGenOnly = False
                End Try

                If Not projGenOnly Or projGen Then 'não faz nada se for verdadeiro projGenOnly e falso projGen
                    Dim fileName As String = xNode.Attributes("name").Value
                    Dim origFile As String = xNode.Attributes("path").Value
                    Dim ext As String = Strings.Right(origFile, Len(origFile) - InStrRev(origFile, ".") + 1)
                    Dim destFile As String = fileName

                    If projGen Then
                        Dim projGenValue As String
                        Try
                            projGenValue = xNode.Attributes("projGenValue").Value
                        Catch 'ex As Exception
                            projGenValue = ""
                        End Try
                        destFile = destFile + projGenValue
                    End If

                    destFile = destFile + ext
                    replaceVars(destFile)

                    Dim fullPath As String = PARENTpath & destFile

                    If Not File.Exists(fullPath) Then
                        Dim tNode As TreeNode
                        tNode = New TreeNode(destFile)
                        TparentNode.Nodes.Add(tNode)
                    End If
                End If

            ElseIf xNode.Name = "shortcut" Then
                    Dim name As String = xNode.Attributes("name").Value
                ' orig As String = xNode.Attributes("orig").Value
                'Dim dest As String = node.Attributes("dest").Value
                replaceVars(name)
                'replaceVars(orig)
                'replaceVars(dest)

                Dim fullPath As String = PARENTpath & name & ".lnk"

                If Not File.Exists(fullPath) Then
                    Dim tNode As TreeNode
                    tNode = New TreeNode(name & " [atalho]")
                    TparentNode.Nodes.Add(tNode)
                End If
            End If
        Next
    End Sub

    Sub getFiles(ByVal PARENTpath As String, ByVal xNodes As XmlNodeList)
        'For Each xNode As XmlNode In xNodes
        '    If xNode.Name = "directory" Then
        '        Dim name As String = xNode.Attributes("name").Value
        '        replaceVars(name)

        '        Dim fullPath As String = PARENTpath & name

        '        If xNode.HasChildNodes Then
        '            getFiles(fullPath, xNode.ChildNodes)
        '        End If

        '    ElseIf xNode.Name = "file" Then
        '        Dim fileName As String = xNode.Attributes("name").Value
        '        Dim origFile As String = xNode.Attributes("path").Value
        '        Dim ext As String = Strings.Right(origFile, Len(origFile) - InStrRev(origFile, ".") + 1)
        '        Dim destFile As String = fileName + ext
        '        replaceVars(destFile)

        '        Dim fullPath As String = PARENTpath & destFile

        '        If Not File.Exists(fullPath) Then
        '            DocumentSelector.ListViewDocuments.Items.Add(destFile)
        '        End If
        '    End If
        'Next
    End Sub

    Function CreateNodeTreeview(ByVal PARENTpath As String, ByVal xNodes As XmlNodeList) As Boolean
        CreateNodeTreeview = False

        If Strings.Right(PARENTpath, 1) <> "\" Then PARENTpath = PARENTpath & "\"

        If Not Directory.Exists(PARENTpath) Then
            CreateNodeTreeview = True
        ElseIf xNodes.Count > 0 Then
            For Each xNode As XmlNode In xNodes
                Dim testPath As String = PARENTpath & xNode.Attributes("name").Value
                replaceVars(testPath)

                If xNode.Name = "directory" Then
                    'If Not ChildExistsTreeview(testPath, xNode.ChildNodes) Then
                    If CreateNodeTreeview(testPath, xNode.ChildNodes) Then
                        CreateNodeTreeview = True
                    End If
                Else
                    Dim ext As String
                    If xNode.Name = "file" Then
                        ext = Path.GetExtension(xNode.Attributes("path").Value)
                    Else
                        ext = ".lnk"
                    End If

                    If Not File.Exists(testPath & ext) Then CreateNodeTreeview = True
                End If
            Next
        End If
    End Function

End Module
