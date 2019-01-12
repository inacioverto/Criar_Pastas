Imports System.Xml
Imports Excel = Microsoft.Office.Interop.Excel

Module VARS

    Public document As New XmlDocument()
    Public PastaID, PastaProd, PastaModelo As String
    Public nProj, desProj, nCliente, nEnc, CnCliente, anoProd, respProj, nomeCliente As String
    Public novoProj, SEMnCliente As Boolean
    Public ProjectFolders(,) As String ' 0 - Nº proj | 1 - Desig. Proj | 2 - Nº cliente | 3 - Pasta Prod.
    Public Projetistas() As String
    Public check_textbox As Boolean = True
    Public pastaClienteProd, pastaClienteID As String
    Public TipoPasta As Integer ' 0 - projeto | 1 - análise de projeto

    Public nProjOK, nClienteOK, nEncOK, desProjOK, nomeClienteOK As Boolean

    Public Const folderTreeXMLproj As String = "G:\informatica\Software\CRIAR PASTAS ID\Application Files\CONFIG\folderTreeProj.xml"
    Public Const folderTreeXMLap As String = "G:\informatica\Software\CRIAR PASTAS ID\Application Files\CONFIG\folderTreeAP.xml"
    Public Const SybusDB As String = "Data Source=srv02;Database=SGN_VRT_PRD;User ID=sa;Password=Verto2017!"
End Module
