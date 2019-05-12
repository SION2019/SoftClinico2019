Public Class Oxigeno
    Public Property empresa As Integer
    Public Property codigoOrden As Integer
    Public Property fechaOrden As DateTime
    Public Property editado As Boolean
    Public Property usuario As Integer
    Public Property usuarioReal As Integer
    Public Property nRegistro As Integer
    Public Property codigoEP As Integer
    Public Property totalLitrosOxigeno As Integer
    Public Property totalPrecioOxigeno As Double
    Public Property oxigenoCargarGuardados As String
    Public Property fechaEgreso As DateTime
    Public Property tablaOxigeno As DataTable
    Public Property modulo As Integer
    Public Property oxiegenReporte As String
    Sub New()
        modulo = Constantes.REPORTE_HC
        oxigenoCargarGuardados = ConsultasHC.OXIGENO_CARGAR_PRIMERA_VEZ
        tablaOxigeno = New DataTable
        tablaOxigeno.Columns.Add("Id_oxigeno", Type.GetType("System.Int32"))
        tablaOxigeno.Columns.Add("Codigo_Orden", Type.GetType("System.Int32"))
        tablaOxigeno.Columns.Add("Fecha_Inicio", Type.GetType("System.String"))
        tablaOxigeno.Columns.Add("Fecha_Fin", Type.GetType("System.String"))
        tablaOxigeno.Columns.Add("Codigo", Type.GetType("System.String"))
        tablaOxigeno.Columns.Add("Descripcion", Type.GetType("System.String"))
        tablaOxigeno.Columns.Add("Porcentaje", Type.GetType("System.Double"))
        tablaOxigeno.Columns.Add("Factor", Type.GetType("System.Double"))
        tablaOxigeno.Columns.Add("Litro", Type.GetType("System.Double"))
        tablaOxigeno.Columns.Add("Hora", Type.GetType("System.Double"))
        tablaOxigeno.Columns.Add("Valor", Type.GetType("System.Double"))
        tablaOxigeno.Columns.Add("Total", Type.GetType("System.Double"), "Valor*Litro")
        tablaOxigeno.Columns.Add("ident_fila", Type.GetType("System.Int32"))
        tablaOxigeno.Columns.Add("Usuario", Type.GetType("System.Int32"))
        tablaOxigeno.Columns.Add("Estado", Type.GetType("System.Int32"))
    End Sub
    Public Sub cargarListaOxigenoOrdenados()
        Dim params As New List(Of String)
        params.Add(nRegistro)
        General.llenarTabla(oxigenoCargarGuardados, params, tablaOxigeno)
    End Sub
    Public Sub totalizarLitrosOxigeno()
        totalLitrosOxigeno = If(IsDBNull(tablaOxigeno.Compute("SUM(Litro)", "Litro > 0")), 0, tablaOxigeno.Compute("SUM(Litro)", "Litro > 0"))
    End Sub
    Public Sub totaliarPrecioOxigeno()
        totalPrecioOxigeno = If(IsDBNull(tablaOxigeno.Compute("SUM(Total)", "Litro > 0")), 0, tablaOxigeno.Compute("SUM(Total)", "Litro > 0"))
    End Sub
    Public Sub colocarFechaFinal()
        getFechaEgreso()
        If tablaOxigeno.Rows.Count = 1 Then
            tablaOxigeno.Rows(0).Item("Fecha_Fin") = Format(Convert.ToDateTime(tablaOxigeno.Rows(0).Item("Fecha_Inicio")).AddDays(1), Constantes.FORMATO_FECHA_OXIGENO)
            calcularMinutos(0)
            Exit Sub
        End If
        For j = 0 To tablaOxigeno.Rows.Count - 1
            If j < tablaOxigeno.Rows.Count - 1 Then
                If tablaOxigeno.Rows(j).Item("Fecha_Fin").ToString = "" Then
                    tablaOxigeno.Rows(j).Item("Fecha_Fin") = tablaOxigeno.Rows(j + 1).Item("Fecha_Inicio")
                End If
            Else
                tablaOxigeno.Rows(j).Item("Fecha_Fin") = Format(fechaEgreso, Constantes.FORMATO_FECHA_OXIGENO_MASCARA)
            End If
            calcularMinutos(j)
        Next
    End Sub
    Public Overridable Sub getFechaEgreso()
        Dim params As New List(Of String)
        params.Add(nRegistro)
        Dim fila As DataRow
        fila = General.cargarItem(ConsultasHC.OXIGENO_FECHA_EGRESO, params)

        If Not IsNothing(fila(0)) Then
            fechaEgreso = fila(0)
        Else
            fechaEgreso = Funciones.Fecha(Constantes.FORMATO_FECHA_HORA_NUMERICA)
        End If
    End Sub
    Public Sub calcularMinutos(ByVal fila As Integer)
        tablaOxigeno.Rows(fila).Item("Hora") = DateDiff(DateInterval.Minute, CDate(tablaOxigeno.Rows(fila).Item("Fecha_Inicio")), CDate(tablaOxigeno.Rows(fila).Item("Fecha_Fin")))
        calcularLitros(fila)
    End Sub
    Public Sub calcularLitros(ByVal fila As Integer)
        tablaOxigeno.Rows(fila).Item("Litro") = (tablaOxigeno.Rows(fila).Item("Factor") * (DateDiff(DateInterval.Minute, tablaOxigeno.Rows(fila).Item("Fecha_Inicio"), tablaOxigeno.Rows(fila).Item("Fecha_Fin")) / 60)) * 1000 'SE DIVIDE ENTRE 60 PARA SABER CUANTO EN HORA Y 100O PARA LLEVARLO A LA UNIDAD DE LITROS
    End Sub
    Public Function agregarOxigeno(ByVal indiceFila As Integer) As Boolean
        getFechaEgreso()
        If compararFechaEgreso(tablaOxigeno.Rows(indiceFila).Item("Fecha_Fin"), fechaEgreso) = False Then
            Dim filaNueva As DataRow = tablaOxigeno.NewRow
            filaNueva("Codigo_Orden") = tablaOxigeno.Rows(indiceFila).Item("Codigo_Orden")
            filaNueva("Fecha_Inicio") = tablaOxigeno.Rows(indiceFila).Item("Fecha_Inicio")
            filaNueva("Fecha_Fin") = tablaOxigeno.Rows(indiceFila).Item("Fecha_Fin")
            filaNueva("Codigo") = tablaOxigeno.Rows(indiceFila).Item("Codigo")
            filaNueva("Descripcion") = tablaOxigeno.Rows(indiceFila).Item("Descripcion")
            filaNueva("Porcentaje") = tablaOxigeno.Rows(indiceFila).Item("Porcentaje")
            filaNueva("Factor") = tablaOxigeno.Rows(indiceFila).Item("Factor")
            filaNueva("Litro") = tablaOxigeno.Rows(indiceFila).Item("Litro")
            filaNueva("Hora") = tablaOxigeno.Rows(indiceFila).Item("Hora")
            filaNueva("Valor") = tablaOxigeno.Rows(indiceFila).Item("Valor")
            filaNueva("ident_fila") = tablaOxigeno.Rows(indiceFila).Item("ident_fila")
            filaNueva("Usuario") = tablaOxigeno.Rows(indiceFila).Item("Usuario")
            filaNueva("Estado") = tablaOxigeno.Rows(indiceFila).Item("Estado")
            tablaOxigeno.Rows.InsertAt(filaNueva, indiceFila + 1)
        Else
            Return False
        End If
        Return True
    End Function
    Public Function compararFechaEgreso(ByVal fechaComprada As DateTime, ByVal fechaEgreso As DateTime) As Boolean
        Return HistoriaClinicaBLL.isFechaMayor(fechaComprada, fechaEgreso)
    End Function
    Public Overridable Sub imprimirOxigeno()
        Try
            Dim nombreArchivo, ruta, codigoNombre As String
            codigoNombre = nRegistro
            nombreArchivo = ConstantesHC.NOMBRE_PDF_OXIGENO_FISIO & ConstantesHC.NOMBRE_PDF_SEPARADOR & codigoNombre & ConstantesHC.EXTENSION_ARCHIVO_PDF
            ruta = Path.GetTempPath() & nombreArchivo
            ftp_reportes.llamarArchivo(ruta, ConstantesHC.NOMBRE_PDF_OXIGENO_FISIO, nRegistro, oxiegenReporte)
            Process.Start(ruta)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
