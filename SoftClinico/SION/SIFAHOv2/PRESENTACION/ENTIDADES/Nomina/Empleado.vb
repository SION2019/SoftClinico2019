Public Class Empleado
    Public Property idEmpresa As Integer
    Public Property idEmpleado As Integer
    Public Property iniciales As String
    Public Property codigoGenero As Integer
    Public Property fechaExpedicion As Date
    Public Property fechaNacimiento As Date
    Public Property codigoCargo As Integer
    Public Property idSalario As Integer
    Public Property idTurno As Integer
    Public Property estado As Integer
    Public Property fechaIngreso As DateTime
    Public Property fechaRetiro As DateTime
    Public Property estadoUsuario As Integer
    Public Property codigoPaisNac As String
    Public Property codigoDepartamentoNac As String
    Public Property codigoMunicipioNac As String
    Public Property codigoPaisExp As String
    Public Property codigoDepartamentoExp As String
    Public Property codigoMunicipioExp As String
    Public Property codigoEspecialidad As Integer
    Public Property codigoProfesion As Integer
    Public Property idCuentaBancaria As Integer
    Public Property idEps As Integer
    Public Property codigoArp As Integer
    Public Property codigoCaja As Integer
    Public Property codigoPension As Integer
    Public Property tipoRH As String
    Public Property tipoempleado As String
    Public Property registroMedico As String
    Public Property idAuxTransporte As Integer
    Public Property IdViaticos As Integer

    Dim _listapunto As List(Of String)
    Dim _listaarea As List(Of String)
    Dim _listacomites As List(Of String)

    Sub New()

    End Sub

    Sub New(drEmpleado As DataRow)

        idEmpresa = Funciones.castDBItem(drEmpleado.Item("id_empresa"))
        idEmpleado = Funciones.castDBItem(drEmpleado.Item("id_empleado"))
        iniciales = Funciones.castDBItem(drEmpleado.Item("iniciales"))
        codigoGenero = Funciones.castDBItem(drEmpleado.Item("codigo_genero"))
        fechaExpedicion = Funciones.castDBItem(drEmpleado.Item("fecha_expedicion"))
        fechaNacimiento = Funciones.castDBItem(drEmpleado.Item("fecha_nacimiento"))
        codigoCargo = Funciones.castDBItem(drEmpleado.Item("codigo_cargo"))
        idSalario = Funciones.castDBItem(drEmpleado.Item("id_salario"))
        idTurno = Funciones.castDBItem(drEmpleado.Item("id_turno"))
        estado = Funciones.castDBItem(drEmpleado.Item("estado"))
        fechaIngreso = Funciones.castDBItem(drEmpleado.Item("fecha_ingreso"))
        fechaRetiro = Funciones.castDBItem(drEmpleado.Item("fecha_retiro"))
        estadoUsuario = Funciones.castDBItem(drEmpleado.Item("estado_usuario"))
        codigoPaisNac = Funciones.castDBItem(drEmpleado.Item("codigo_pais_nac"))
        codigoDepartamentoNac = Funciones.castDBItem(drEmpleado.Item("codigo_departamento_nac"))
        codigoMunicipioNac = Funciones.castDBItem(drEmpleado.Item("codigo_municipio_nac"))
        codigoPaisExp = Funciones.castDBItem(drEmpleado.Item("codigo_pais_exp"))
        codigoDepartamentoExp = Funciones.castDBItem(drEmpleado.Item("codigo_departamento_exp"))
        codigoMunicipioExp = Funciones.castDBItem(drEmpleado.Item("codigo_municipio_exp"))
        codigoEspecialidad = Funciones.castDBItem(drEmpleado.Item("codigo_especialidad"))
        codigoProfesion = Funciones.castDBItem(drEmpleado.Item("codigo_profesion"))
        idCuentaBancaria = Funciones.castDBItem(drEmpleado.Item("Id_Cuenta_Bancaria"))
        idEps = Funciones.castDBItem(drEmpleado.Item("id_eps"))
        codigoArp = Funciones.castDBItem(drEmpleado.Item("codigo_arp"))
        codigoCaja = Funciones.castDBItem(drEmpleado.Item("codigo_caja"))
        codigoPension = Funciones.castDBItem(drEmpleado.Item("codigo_pension"))
        tipoRH = Funciones.castDBItem(drEmpleado.Item("tipo_RH"))
        tipoempleado = Funciones.castDBItem(drEmpleado.Item("tipo_empleado"))
        registroMedico = Funciones.castDBItem(drEmpleado.Item("registro_medico"))
        idAuxTransporte = Funciones.castDBItem(drEmpleado.Item("id_Aux_Transporte"))
        IdViaticos = Funciones.castDBItem(drEmpleado.Item("Id_Viaticos"))

    End Sub

    Public Property ListaPunto
        Get
            Return _listapunto
        End Get
        Set(value)
            _listapunto = New List(Of String)
            For Each item In value
                _listapunto.Add(item)
            Next
        End Set
    End Property
    Public Property ListaArea
        Get
            Return _listaarea
        End Get
        Set(value)
            _listaarea = New List(Of String)
            For Each item In value
                _listaarea.Add(item)
            Next
        End Set
    End Property
    Public Property ListaComites
        Get
            Return _listacomites
        End Get
        Set(value)
            _listacomites = New List(Of String)
            For Each item In value
                _listacomites.Add(item)
            Next
        End Set
    End Property

    Property id_retd_sueldo As String = ""
    Property id_retd_turno As String = ""
    Property id_retd_viatico As String = ""
    Property id_retd_cuenta As String = ""

End Class
