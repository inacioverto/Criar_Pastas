Imports System.Xml
'Imports Excel = Microsoft.Office.Interop.Excel

Module VARS

    Public document As New XmlDocument()
    Public ModelNode As XmlNode
    Public PastaID, PastaProd, PastaModelo As String
    Public nProj, desProj, nCliente, nEnc, CnCliente, anoProd, respProj, respAP, nomeCliente, desProjGen As String
    Public novoProj, SEMnCliente, projGen As Boolean
    Public ProjectFolders(,) As String ' 0 - Nº proj | 1 - Desig. Proj | 2 - Nº cliente | 3 - Pasta Prod.
    Public Projetistas() As String
    Public Orcamentistas() As String
    Public check_textbox As Boolean = True
    Public pastaClienteProd, pastaClienteID As String
    Public TipoPasta As Integer ' 0 - projeto | 1 - análise de projeto

    Public nProjOK, nClienteOK, nEncOK, desProjOK, nomeClienteOK, desProjGenOK As Boolean

    Public Const folderTreeXMLproj As String = "G:\informatica\Software\CRIAR PASTAS ID\Application Files\CONFIG\folderTree.xml"
    'Public Const folderTreeXMLap As String = "G:\informatica\Software\CRIAR PASTAS ID\Application Files\CONFIG\folderTreeAP.xml"

    Public debug As Boolean = False
End Module
