Imports System.Xml
Imports Excel = Microsoft.Office.Interop.Excel

Module VARS

    Public document As New XmlDocument()
    Public PastaID, PastaProd, PastaModelo As String
    Public nProj, desProj, nCliente, nEnc, CnCliente, anoProd, respProj, nomeCliente As String
    Public novoProj As Boolean
    Public ProjectFolders(,) As String ' 0 - Nº proj | 1 - Desig. Proj | 2 - Nº cliente | 3 - Pasta Prod.
    Public Projetistas() As String
    Public check_textbox As Boolean = True
    Public pastaClienteProd, pastaClienteID As String

    Public nProjOK, nClienteOK, nEncOK, desProjOK As Boolean

    Public Const folderTreeXML As String = "G:\informatica\Software\CRIAR PASTAS ID\Application Files\CONFIG\folderTree.xml"
    Public Const SybusDB As String = "Data Source=srv02;Database=SGN_VRT_PRD;User ID=sa;Password=Verto2017!"
End Module
