Public Class PlataformaDoc
    Public Property SqlGuardarPlataformaDoc As String
    Public Property sqlBuscarPDPerfil As String
    Public Property SqlCargarPlataformaDoc As String
    Public Property SqlCargarPDFPlataformaDoc As String
    Public Property SqlGuardarPlataformaDocDesc As String
    Public Property DtMenu As DataTable
    Public Property DtMenuManual As DataTable
    Public Property DtPerfilMenu As DataTable
    Public Property DtPerfil As DataTable
    Public Property DtPerfilAux As DataTable
    Public Property DtPlatformaDoc As DataTable
    Public Property DtEliminar As DataTable
    Public Property Dtauxel As DataTable
    Public Property NodoPadre As Integer
    Public Property NodoHijo As Integer
    Public Property NombrePDF As String
    Public Property NomCategoria As String
    Public Property BdIndex As Integer
    Public Property BdAceptar As Integer
    Public Property codCont As Integer
    Public Property codPerfil As Integer
    Public Property codMenu As Integer


    Public Sub New()
        DtPlatformaDoc = New DataTable
        DtPlatformaDoc.Columns.Add("NivelPadre", Type.GetType("System.String"))
        DtPlatformaDoc.Columns.Add("NivelHijo", Type.GetType("System.String"))
        DtPlatformaDoc.Columns.Add("Codigo_Doc", Type.GetType("System.String"))
        DtPlatformaDoc.Columns.Add("Nombre", Type.GetType("System.String"))
        DtPlatformaDoc.Columns.Add("Archivo", Type.GetType("System.Byte[]"))
        DtPlatformaDoc.Columns.Add("Usuario_Creacion", Type.GetType("System.Int32"))
        DtPlatformaDoc.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        DtPerfil = New DataTable

        DtPerfilAux = New DataTable
        DtPerfilAux.Columns.Add("Codigo_Perfil", Type.GetType("System.Int32"))
        DtPerfilAux.Columns.Add("Codigo_Doc", Type.GetType("System.String"))
        DtPerfilAux.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        DtMenu = New DataTable
        DtMenu.Columns.Add("Codigo_Menu", Type.GetType("System.String"))
        DtMenu.Columns.Add("Descripcion_Menu", Type.GetType("System.String"))
        DtMenu.Columns.Add("Formulario", Type.GetType("System.String"))
        DtMenu.Columns.Add("Padre_Menu", Type.GetType("System.String"))
        DtMenu.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        DtMenuManual = New DataTable
        DtMenuManual.Columns.Add("Codigo_Menu", Type.GetType("System.String"))
        DtMenuManual.Columns.Add("Archivo", Type.GetType("System.Byte[]"))
        DtMenuManual.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        DtPerfilMenu = New DataTable
        DtPerfilMenu.Columns.Add("Codigo_Perfil", Type.GetType("System.Int32"))
        DtPerfilMenu.Columns.Add("id_empresa", Type.GetType("System.Int32"))
        DtPerfilMenu.Columns.Add("Codigo_MENU", Type.GetType("System.String"))
        DtPerfilMenu.Columns.Add("Anulado", Type.GetType("System.Boolean"))

        DtEliminar = New DataTable
        DtEliminar.Columns.Add("NivelPadre", Type.GetType("System.String"))
        DtEliminar.Columns.Add("NivelHijo", Type.GetType("System.String"))
        DtEliminar.Columns.Add("Codigo_Doc", Type.GetType("System.String"))
        DtEliminar.Columns.Add("Nombre", Type.GetType("System.String"))
        DtEliminar.Columns.Add("Archivo", Type.GetType("System.Byte[]"))
        DtEliminar.Columns.Add("Usuario_Creacion", Type.GetType("System.Int32"))
        DtEliminar.Columns.Add("Codigo_Perfil", Type.GetType("System.Int32"))
        DtEliminar.Columns.Add("Codigo_Menu", Type.GetType("System.String"))

        Dtauxel = New DataTable

        SqlGuardarPlataformaDoc = Consultas.PLATAFORMA_DOC_CREAR
        sqlBuscarPDPerfil = Consultas.PLATAFORMADOC_PERFIL_USUARIO_CARGAR
        SqlCargarPlataformaDoc = Consultas.PLATAFORMA_DOC_CARGAR
        SqlCargarPDFPlataformaDoc = Consultas.PLATAFORMA_DOC_CARGAR_PDF
        SqlGuardarPlataformaDocDesc = Consultas.PLATAFORMA_DOC_DESC_CREAR
    End Sub
End Class
