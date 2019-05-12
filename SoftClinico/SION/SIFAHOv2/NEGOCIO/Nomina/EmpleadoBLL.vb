Public Class EmpleadoBLL
    Public Shared Function tomarHuella(txtcodigo As String, ByRef huella1 As DPFP.Template) As Boolean
        Return EmpleadoDAL.tomarHuella(txtcodigo, huella1)
    End Function
    Public Shared Function guardarDocumento(txtcodigo As String, descripcion1 As Object, ByRef documento1 As Byte()) As Boolean
        Return EmpleadoDAL.guardarDocumento(txtcodigo, descripcion1, documento1)
    End Function

    Public Shared Function consultarDatosTercero(tercero As Tercero) As Tercero
        Dim drTercero As DataRow
        Dim params As New List(Of String)

        params.Add(tercero.idTercero)
        drTercero = General.cargarItem(Consultas.CARGAR_EMPLEADO_TERCERO, params)

        tercero = New Tercero(drTercero)
        Return tercero
    End Function

    Public Shared Function consultarTerceroCuenta(tercero As Tercero) As TerceroDetalle
        Dim drTerceroCuenta As DataRow
        Dim params As New List(Of String)
        params.Add(SesionActual.idEmpresa)
        params.Add(tercero.idTercero)
        drTerceroCuenta = General.cargarItem("PROC_TERCERO_DETALLE_CARGAR", params)

        Dim terceroCuenta As New TerceroDetalle(drTerceroCuenta)
        Return terceroCuenta
    End Function

    Public Shared Sub guardarCambiosEmpleado(adminEmpleado As AdminEmpleado)
        Dim empleados As New EmpleadoCollection
        Dim cuenta As New CuentaBancariaCollection
        Dim salario As New SalarioCollection
        Dim turno As New TurnoCollection
        Dim foto As New FotoCollection
        Dim firma As New FirmaCollection
        Dim viatico As New ViaticoCollection
        Dim auxilioTrans As New AuxilioTransporteCollection
        Dim usuario As New TerceroUsuarioCollection
        Dim terceroCuenta As New TerceroDetalleCollection
        Dim areasServicio As New AreaServicioCollection
        Dim empresaPuntos As New EmpresaPuntoCollection

        empleados.Add(adminEmpleado.empleado)
        cuenta.Add(adminEmpleado.cuentaBancaria)
        salario.Add(adminEmpleado.salario)
        turno.Add(adminEmpleado.turno)
        foto.Add(adminEmpleado.foto)
        firma.add(adminEmpleado.firma)

        viatico.Add(adminEmpleado.viatico)
        auxilioTrans.Add(adminEmpleado.auxilio)
        usuario.Add(adminEmpleado.usuario)
        terceroCuenta.Add(adminEmpleado.terceroCuenta)

        For Each item In adminEmpleado.puntosAsignados
            empresaPuntos.Add(item)
        Next

        For Each item In adminEmpleado.areasAsignadas
            areasServicio.Add(item)
        Next


        EmpleadoDAL.guardarEmpleado(empleados,
                                    cuenta,
                                    salario,
                                    turno,
                                    foto,
                                    firma,
                                    viatico,
                                    auxilioTrans,
                                    usuario,
                                    terceroCuenta,
                                    IIf(adminEmpleado.puntosAsignados.Count = 0, Nothing, empresaPuntos),
                                    IIf(adminEmpleado.areasAsignadas.Count = 0, Nothing, areasServicio),
                                    adminEmpleado)
    End Sub



End Class
