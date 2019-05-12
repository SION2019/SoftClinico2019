Public Class Tercero
    Public Property idTercero
    Public Property nit
    Public Property dv
    Public Property codigoTipoIdentificacion
    Public Property nombre
    Public Property sNombre
    Public Property apellido
    Public Property sApellido
    Public Property razonSocial
    Public Property telefono1
    Public Property telefono2
    Public Property whatsapp
    Public Property codigoPais
    Public Property codigoDepartamento
    Public Property codigoMunicipio
    Public Property direccion
    Public Property email
    Sub New()

    End Sub

    Sub New(drTercero As DataRow)
        idTercero = Funciones.castDBItem(drTercero.Item("id_tercero"))
        nit = Funciones.castDBItem(drTercero.Item("nit"))
        dv = Funciones.castDBItem(drTercero.Item("dv"))
        codigoTipoIdentificacion = Funciones.castDBItem(drTercero.Item("codigo_tipo_identificacion"))
        nombre = Funciones.castDBItem(drTercero.Item("nombre"))
        sNombre = Funciones.castDBItem(drTercero.Item("sNombre"))
        apellido = Funciones.castDBItem(drTercero.Item("apellido"))
        sApellido = Funciones.castDBItem(drTercero.Item("sApellido"))
        razonSocial = Funciones.castDBItem(drTercero.Item("razonSocial"))
        telefono1 = Funciones.castDBItem(drTercero.Item("telefono1"))
        telefono2 = Funciones.castDBItem(drTercero.Item("telefono2"))
        whatsapp = Funciones.castDBItem(drTercero.Item("whatsapp"))
        codigoPais = Funciones.castDBItem(drTercero.Item("codigo_pais"))
        codigoDepartamento = Funciones.castDBItem(drTercero.Item("codigo_departamento"))
        codigoMunicipio = Funciones.castDBItem(drTercero.Item("codigo_municipio"))
        direccion = Funciones.castDBItem(drTercero.Item("direccion"))
        email = Funciones.castDBItem(drTercero.Item("email"))

    End Sub


End Class
