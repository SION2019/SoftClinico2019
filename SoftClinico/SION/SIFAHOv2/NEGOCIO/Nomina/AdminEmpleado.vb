Public Class AdminEmpleado
    Public Property idEmpresa As Integer
    Public Property empleado As Empleado
    Public Property tercero As Tercero
    Public Property cuentaBancaria As EmpleadoCuentaBancaria
    Public Property perfil As TerceroPerfil
    Public Property salario As EmpleadoSalario
    Public Property turno As EmpleadoTurno
    Public Property foto As EmpleadoFoto
    Public Property huella As EmpleadoHuella
    Public Property firma As EmpleadoFirma
    Public Property viatico As EmpleadoViatico
    Public Property auxilio As EmpleadoAuxilio
    Public Property usuario As TerceroUsuario
    Public Property terceroCuenta As TerceroDetalle

    Public Property esOtraCuenta As Boolean
    Public Property esOtroSalario As Boolean
    Public Property esOtroTurno As Boolean
    Public Property esOtraFoto As Boolean
    Public Property esOtraHuella As Boolean
    Public Property esOtraFirma As Boolean
    Public Property esOtroViatico As Boolean
    Public Property esOtroAuxilio As Boolean
    Public Property esOtroUsuario As Boolean
    Public Function esNuevoEmpleado() As Boolean
        Return empleado Is Nothing
    End Function


    Public Property puntosAsignados As List(Of EmpresaPunto)
    Public Property areasAsignadas As List(Of EmpleadoAreaServicio)

    Public Property puntosDisponibles As List(Of EmpresaPunto)
    Public Property areasDisponibles As List(Of EmpleadoAreaServicio)

    Sub New()

    End Sub

    Public Sub inicializarNuevoEmpleado()

        'Carga diferida
        empleado = IIf(empleado Is Nothing, New Empleado(tercero, idEmpresa), empleado)
        cuentaBancaria = IIf(cuentaBancaria Is Nothing, New EmpleadoCuentaBancaria(tercero, idEmpresa), cuentaBancaria)
        perfil = IIf(perfil Is Nothing, New TerceroPerfil(tercero, idEmpresa), perfil)
        salario = IIf(salario Is Nothing, New EmpleadoSalario(tercero, idEmpresa), salario)
        turno = IIf(turno Is Nothing, New EmpleadoTurno(tercero, idEmpresa), turno)
        foto = IIf(foto Is Nothing, New EmpleadoFoto(tercero), foto)
        huella = IIf(huella Is Nothing, New EmpleadoHuella(tercero), huella)
        firma = IIf(firma Is Nothing, New EmpleadoFirma(tercero), firma)
        viatico = IIf(viatico Is Nothing, New EmpleadoViatico(tercero, idEmpresa), viatico)
        auxilio = IIf(auxilio Is Nothing, New EmpleadoAuxilio(tercero, idEmpresa), auxilio)
        usuario = IIf(usuario Is Nothing, New TerceroUsuario(tercero, idEmpresa), usuario)
        terceroCuenta = IIf(terceroCuenta Is Nothing, New TerceroDetalle(tercero, idEmpresa), terceroCuenta)

    End Sub
    Sub New(drAdminEmpleado As DataRow)

        idEmpresa = Funciones.castFromDbItem(drAdminEmpleado.Item("id_empresa"))
        empleado = New Empleado(drAdminEmpleado)
        tercero = New Tercero(drAdminEmpleado)
        cuentaBancaria = New EmpleadoCuentaBancaria(drAdminEmpleado)
        perfil = New TerceroPerfil(drAdminEmpleado)
        salario = New EmpleadoSalario(drAdminEmpleado)
        turno = New EmpleadoTurno(drAdminEmpleado)
        foto = New EmpleadoFoto(drAdminEmpleado)
        firma = New EmpleadoFirma(drAdminEmpleado)
        viatico = New EmpleadoViatico(drAdminEmpleado)
        auxilio = New EmpleadoAuxilio(drAdminEmpleado)
        usuario = New TerceroUsuario(drAdminEmpleado)
        terceroCuenta = New TerceroDetalle(drAdminEmpleado)

        puntosAsignados = obtenerPuntosServicioEmpleado(empleado)
        areasAsignadas = obtenerAreasEmpleado(empleado)
        puntosDisponibles = obtenerPuntosDisponbiles(empleado)
        areasDisponibles = obtenerAreasDisponibles(empleado)
    End Sub

    Public Function tieneSalario() As Boolean
        If salario.valor > 0 Then
            Return True
        End If

        Return False
    End Function

    Public Function tieneCuentaBancaria() As Boolean
        If cuentaBancaria IsNot Nothing Then
            Return True
        End If

        Return False
    End Function

    Public Function obtenerPuntosServicioEmpleado(ByRef empleado As Empleado) As List(Of EmpresaPunto)
        Dim params As New List(Of String)
        Dim dtEmpresaPunto As New DataTable
        params.Add(empleado.idEmpleado)
        params.Add(empleado.idEmpresa)

        General.llenarTabla(Consultas.CARGAR_CONTRATO_PUNTO_S_EMP, params, dtEmpresaPunto)

        Dim empleadoPuntos As New List(Of EmpresaPunto)
        For Each fila As DataRow In dtEmpresaPunto.Rows
            Dim punto As New EmpresaPunto()

            punto.codigoEP = Funciones.castFromDbItem(fila.Item("codigo_ep"))
            punto.nombre = Funciones.castFromDbItem(fila.Item("nombre"))
            empleadoPuntos.Add(punto)
        Next

        Return empleadoPuntos
    End Function
    Public Shared Function obtenerPuntosDisponbiles(ByRef empleado As Empleado) As List(Of EmpresaPunto)
        Dim params As New List(Of String)
        Dim dtEmpresaPunto As New DataTable
        params.Add(empleado.idEmpleado)
        params.Add(empleado.idEmpresa)

        General.llenarTabla(Consultas.CARGAR_CONTRATO_PUNTO_S_DISPONIBLE_EMP, params, dtEmpresaPunto)

        Dim empleadoPuntos As New List(Of EmpresaPunto)
        For Each fila As DataRow In dtEmpresaPunto.Rows
            Dim punto As New EmpresaPunto()

            punto.codigoEP = Funciones.castFromDbItem(fila.Item("codigo_ep"))
            punto.nombre = Funciones.castFromDbItem(fila.Item("nombre"))
            empleadoPuntos.Add(punto)
        Next

        Return empleadoPuntos
    End Function


    Public Shared Function obtenerAreasEmpleado(ByRef empleado As Empleado) As List(Of EmpleadoAreaServicio)
        Dim params As New List(Of String)
        Dim dtEmpresaArea As New DataTable
        params.Add(empleado.idEmpleado)
        params.Add(empleado.idEmpresa)

        General.llenarTabla(Consultas.LISTAR_AREAS_EMPLEADO, params, dtEmpresaArea)

        Dim empleadoAreas As New List(Of EmpleadoAreaServicio)
        For Each fila As DataRow In dtEmpresaArea.Rows
            Dim area As New EmpleadoAreaServicio()

            area.idEmpleado = empleado.idEmpleado
            area.idEmpresa = empleado.idEmpresa
            area.codigoAreaServicio = Funciones.castFromDbItem(fila.Item("codigo_area_servicio"))
            area.descripcion = Funciones.castFromDbItem(fila.Item("descripcion_area_servicio"))
            empleadoAreas.Add(area)
        Next

        Return empleadoAreas
    End Function

    Public Shared Function obtenerAreasDisponibles(ByRef empleado As Empleado) As List(Of EmpleadoAreaServicio)
        Dim params As New List(Of String)
        Dim dtEmpresaArea As New DataTable
        params.Add(empleado.idEmpleado)
        params.Add(SesionActual.codigoEP)

        General.llenarTabla(Consultas.LISTAR_AREAS_DISPONIBLES_EMPLEADO, params, dtEmpresaArea)

        Dim empleadoAreas As New List(Of EmpleadoAreaServicio)
        For Each fila As DataRow In dtEmpresaArea.Rows
            Dim area As New EmpleadoAreaServicio()

            area.idEmpleado = empleado.idEmpleado
            area.idEmpresa = empleado.idEmpresa
            area.codigoAreaServicio = Funciones.castFromDbItem(fila.Item("codigo_area_servicio"))
            area.descripcion = Funciones.castFromDbItem(fila.Item("descripcion_area_servicio"))
            empleadoAreas.Add(area)
        Next

        Return empleadoAreas
    End Function

End Class
