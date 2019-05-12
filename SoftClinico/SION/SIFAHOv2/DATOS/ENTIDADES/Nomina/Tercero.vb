Public Class Tercero
    Public Property idTercero As Integer
    Public Property nit As String
    Public Property dv As Integer
    Public Property codigoTipoIdentificacion As Integer
    Public Property nombre As String
    Public Property sNombre As String
    Public Property apellido As String
    Public Property sApellido As String
    Public Property razonSocial As String
    Public Property telefono1 As String
    Public Property telefono2 As String
    Public Property whatsapp As String
    Public Property codigoPais As String
    Public Property codigoDepartamento As String
    Public Property codigoMunicipio As String
    Public Property direccion As String
    Public Property email As String
    Sub New()

    End Sub

    Sub New(drTercero As DataRow)
        idTercero = Funciones.castFromDbItem(drTercero.Item("id_tercero"))
        nit = Funciones.castFromDbItem(drTercero.Item("nit"))
        dv = Funciones.castFromDbItem(drTercero.Item("dv"))
        codigoTipoIdentificacion = Funciones.castFromDbItem(drTercero.Item("codigo_tipo_identificacion"))
        nombre = Funciones.castFromDbItem(drTercero.Item("nombre"))
        sNombre = Funciones.castFromDbItem(drTercero.Item("sNombre"))
        apellido = Funciones.castFromDbItem(drTercero.Item("apellido"))
        sApellido = Funciones.castFromDbItem(drTercero.Item("sApellido"))
        razonSocial = Funciones.castFromDbItem(drTercero.Item("razonSocial"))
        telefono1 = Funciones.castFromDbItem(drTercero.Item("telefono1"))
        telefono2 = Funciones.castFromDbItem(drTercero.Item("telefono2"))
        whatsapp = Funciones.castFromDbItem(drTercero.Item("whatsapp"))
        codigoPais = Funciones.castFromDbItem(drTercero.Item("codigo_pais"))
        codigoDepartamento = Funciones.castFromDbItem(drTercero.Item("codigo_departamento"))
        codigoMunicipio = Funciones.castFromDbItem(drTercero.Item("codigo_municipio"))
        direccion = Funciones.castFromDbItem(drTercero.Item("direccion"))
        email = Funciones.castFromDbItem(drTercero.Item("email"))

    End Sub


End Class
