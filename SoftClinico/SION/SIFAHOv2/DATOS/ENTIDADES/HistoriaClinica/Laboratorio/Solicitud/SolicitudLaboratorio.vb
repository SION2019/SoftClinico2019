Public Class SolicitudLaboratorio
    Public Property codigoSolicitud As String
    Public Property modulo As String
    Public Property codigoOrden As String
    Public Property codigoEp As Integer
    Public Property editado As Integer
    Public Property codigoLab As Integer
    Public Property Usuario As Integer
    Public Property UsuarioReal As Integer
    Public Property sqlCargarExamen As String
    Public Property sqlCargarComboLaboratorio As String

    Public Property sqlGenerarLaboratorio As String
    Public Property sqlBuscarSolicitud As String
    Public Property sqlCargarSolicitud As String
    Public Property sqlAnularSolicitud As String
    Public Property IdTercero As Integer
    Public Property IdEmpresa As Integer
    Public Property dtExamen As DataTable
    Public Property nRegistro As Integer
    Public Property tipoExamen As String

    Public Sub New()
        dtExamen = New DataTable
        dtExamen.Columns.Add("Codigo", Type.GetType("System.String"))
        dtExamen.Columns.Add("Examen", Type.GetType("System.String"))
        dtExamen.Columns.Add("Seleccionado", Type.GetType("System.Boolean"))
        dtExamen.Columns.Add("Estado", Type.GetType("System.String"))

        sqlGenerarLaboratorio = ConsultasHC.EXAMEN_LABORATORIO_GUARDAR
        sqlCargarExamen = ConsultasHC.EXAMEN_LABORATORIO_CARGAR
        sqlBuscarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_BUSCAR
        sqlCargarComboLaboratorio = ConsultasHC.LISTA_LABORATORIO_CARGAR
        sqlCargarSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_CARGAR
        sqlAnularSolicitud = ConsultasHC.SOLICITUD_LABORATORIO_ANULAR
    End Sub
    Public Sub cargarDatatableExamen(posicion As Integer)
        If posicion <> 0 Then
            Dim params As New List(Of String)
            params.Add(codigoOrden)
            params.Add(IdTercero)
            params.Add(IdEmpresa)
            General.llenarTabla(sqlCargarExamen, params, dtExamen)
        Else
            dtExamen.Clear()
        End If
    End Sub
    Public Overridable Sub asignarValores(objPadre As Object)
        codigoOrden = objPadre.objenfermeria.objParaclinico.codigoOrden
        nRegistro = objPadre.nregistro
        tipoExamen = Constantes.TipoEXAM
    End Sub

    Public Sub cargarDatosSolicitud(codigo As Integer)
        Dim params As New List(Of String)
        params.Add(ConstantesHC.DETALLE)
        params.Add(codigo)
        General.llenarTabla(sqlCargarSolicitud, params, dtExamen)
    End Sub
    Public Sub anulaSolicitud()
        General.anularRegistro(sqlAnularSolicitud & codigoSolicitud &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & Usuario &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & codigoEp &
             ConstantesHC.NOMBRE_PDF_SEPARADOR3 & editado)
    End Sub
End Class
