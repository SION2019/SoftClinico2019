Public Class ParametroVentilacion
    Inherits Sabana
    Public Property editado As Integer
    Public Sub New()
        sqlDetalleCarga = ConsultasHC.PARAMETRO_VENTILACION_CARGAR
        sqlDatoPacienteCarga = ConsultasHC.SABANA_PACIENTE_CARGAR
        sqlCodigoSabanaCarga = ConsultasHC.PARAMETRO_VENTILACION_CODIGO_SABANA_CARGAR
        nombreReporte = ConstantesHC.NOMBRE_PDF_PARAMETRO_VENTI
        vistaReporte = "VISTA_PARAMETROS_DIAS"
        objReporte = New rptParametroVentilacion
        moduloReporte = Constantes.REPORTE_HC
    End Sub
    Public Overrides Sub cargarDetalle()
        Dim params As New List(Of String)
        params.Add(ConstantesHC.CODIGO_DESCRIPCION_PARAMETROS)
        params.Add(codigoSabana)
        General.llenarTabla(sqlDetalleCarga, params, dtHorasabana)
    End Sub
    Public Overrides Sub cargarCodigoSabana()
        Dim params As New List(Of String)
        Dim dr As DataRow
        params.Add(nRegistro)
        params.Add(fechaReal.Date)
        dr = General.cargarItem(sqlCodigoSabanaCarga, params)
        If Not IsNothing(dr) Then
            codigoSabana = dr.Item(0)
        Else
            codigoSabana = ""
        End If
        If IsNothing(usuarioReal) Then
            usuarioReal = usuario
        End If
    End Sub
    Public Overrides Sub guardarDetalle()
        If String.IsNullOrEmpty(codigoSabana) Then
            ParametroVentilacionDAL.guardarParametroVentilacionHC(Me)
        Else
            ParametroVentilacionDAL.actualizarParametroVentilacionHC(Me)
        End If
    End Sub
End Class
