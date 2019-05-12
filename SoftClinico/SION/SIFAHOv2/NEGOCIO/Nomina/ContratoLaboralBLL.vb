Public Class ContratoLaboralBLL
    Dim objContratoDAL As New ContratoLaboralDAL
    Dim doc, doc2 As Word.Document
    Dim wd, wd2 As Word.ApplicationClass
    Public Function guardar_contrato(ByRef contrato As Contrato)
        If String.IsNullOrEmpty(contrato.codigo) Then
            objContratoDAL.guardarContrato(contrato)
        Else
            objContratoDAL.actualizarContrato(contrato)
        End If
        Return contrato
    End Function
    'Public Function terminarContrato(ByVal codigo As String) As Boolean
    '    Return cmd.terminarContrato(codigo)
    'End Function

    'Public Function cargarSalarios() As DataTable
    '    Return cmd.CargarSalarios()
    'End Function

    'Public Function cargarAuxTransporte() As DataTable
    '    Return cmd.cargarAuxTransporte()
    'End Function

    'Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String
    '    Dim strAux As String
    '    Dim strComas As String
    '    Dim strPuntos As String
    '    Dim intX As Integer
    '    Dim bolMenos As Boolean = False

    '    strComas = ""
    '    strValor = strValor.Replace(".", "")
    '    If InStr(strValor, ",") > 0 Then
    '        strAux = Mid(strValor, 1, InStr(strValor, ",") - 1)
    '        strComas = Mid(strValor, InStr(strValor, ","))
    '    Else
    '        strAux = strValor
    '    End If
    '    If Mid(strAux, 1, 1) = "-" Then
    '        bolMenos = True
    '        strAux = Mid(strAux, 2)
    '    End If
    '    strPuntos = strAux
    '    strAux = ""
    '    While strPuntos.Length > 3
    '        strAux = "." & Mid(strPuntos, strPuntos.Length - 2, 3) & strAux
    '        strPuntos = Mid(strPuntos, 1, strPuntos.Length - 3)
    '    End While
    '    If intNumDecimales <> 0 Then
    '        If strComas = "" Then strComas = ","
    '        For intX = Len(strComas) - 1 To intNumDecimales - 1
    '            strComas = strComas & "0"
    '        Next
    '    End If
    '    strAux = strPuntos & strAux & strComas
    '    If Mid(strAux, 1, 1) = "." Then strAux = Mid(strAux, 2)
    '    If bolMenos Then strAux = "-" & strAux
    '    Return strAux
    'End Function
    Public Function calcularPruebaDias(fechaInicio As Date, fechaFin As Date) As Integer
        Dim valor As Integer
        Dim cantidad_meses As Integer

        cantidad_meses = DateDiff(DateInterval.Month, fechaInicio, fechaFin.AddDays(1))

        If CInt(cantidad_meses * 6) > 60 Then
            valor = 60
        ElseIf cantidad_meses = 0 Then
            valor = 2
        ElseIf cantidad_meses < 0 Then
            valor = 0
        Else
            valor = CInt(cantidad_meses * 6)
        End If

        Return valor

    End Function
    Public Sub cargarComboTipoContrato(combotipo As ComboBox)
        Dim dtTabla As New DataTable
        dtTabla.Columns.Add("Valor")
        dtTabla.Columns.Add("Descripcion")
        Dim drFila As DataRow = dtTabla.NewRow()

        drFila.Item(0) = "-1"
        drFila.Item(1) = " - - - Seleccione - - - "
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = Constantes.CONTRATO_lABORAL
        drFila.Item(1) = "Laboral"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = Constantes.CONTRATO_PRESTACION_SERVICIO
        drFila.Item(1) = "Prestación de servicio"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = Constantes.CONTRATO_APREDIZAJE
        drFila.Item(1) = "Aprendizaje"
        dtTabla.Rows.Add(drFila)

        drFila = dtTabla.NewRow()
        drFila.Item(0) = Constantes.CONTRATO_VALUNTARIO
        drFila.Item(1) = "Voluntario"
        dtTabla.Rows.Add(drFila)

        combotipo.DataSource = dtTabla
        combotipo.DisplayMember = "Descripcion"
        combotipo.ValueMember = "Valor"
        combotipo.SelectedIndex = 0
    End Sub
    Public Sub llenar_minuta(objContrato As Contrato)
        Dim dtdatoscontratante As New DataTable("DATOS_CONTRATANTE")
        Dim dtDatosContratista As New DataTable("DATOS_CONTRATISTA")
        Dim duracionMeses As Integer
        Dim fConvertirNumeros As New ConvertirNumeros
        Dim dw As DataRow
        Dim dwEmpleado As DataRow
        Dim fechaFin As Date

        objContrato.llenarDatosContratante(dtdatoscontratante)
        objContrato.llenarDatosContratista(dtDatosContratista)

        wd = New Word.ApplicationClass
        doc = wd.Documents.Open(objContrato.tempfileurl + ".docx", False, False, False)

        dw = dtdatoscontratante.Rows(0)
        dwEmpleado = dtDatosContratista.Rows(0)

        fechaFin = objContrato.fin.AddDays(objContrato.inicio.Day)
        duracionMeses = ((fechaFin.Year - objContrato.inicio.Year) * 12) + fechaFin.Month - objContrato.fin.Month

        remp("{NUMERO-CONTRATO}", objContrato.codigo)
        remp("{CONTRATANTE}", SesionActual.nombreEmpresa)

        If Not IsNothing(dw) Then
            remp("{EMPLEADOR}", dw("Razon_Social"))
            remp("{IDENTIFICACION-EMPLEADOR}", Val(dw("Nit")).ToString("N0"))
            remp("{DIRECCION-EMPLEADOR}", dw("Direccion"))
            remp("{IDENTIFICACION-CONTRATANTE}", Val(dw("Nit")).ToString("N0"))
            remp("{DIRECCION-CONTRATANTE}", dw("Direccion"))
            remp("{REPRESENTANTE}", dw("Razon_Representante"))
            remp("{IDENTIFICACION-REPRESENTANTE}", Val(dw("Nit_Representante")).ToString("N0") +
            " DE " + dw("Municipio_Representante") + " - " + dw("Departamento_Representante"))
            remp("{CIUDAD_DEPARTAMENTO}", dw("Ciudad") + " " + dw("Departamento"), True)
        End If
        If Not IsNothing(dwEmpleado) Then
            remp("{EMPLEADO}", dwEmpleado("Empleado"))
            remp("{DIRECCION-EMPLEADO}", dwEmpleado("Direccion"))
            remp("{DIRECCION-CONTRATISTA}", dwEmpleado("Direccion").ToString)
            remp("{IDENTIFICACION-CONTRATISTA}", Val(dwEmpleado("Nit")).ToString("N0"))
            remp("{CEDULA}", Val(dwEmpleado("Nit")).ToString("N0"))
            remp("{CIUDADEXPCC}", dwEmpleado("CiudadExp"))
            remp("{PAIS-NACIMIENTO}", dwEmpleado("PaisNac"))
            remp("{TIPO-CONTRATO}", gtContrato(objContrato))
            remp("{FECHA-NACIMIENTO}", Format(dwEmpleado("Fecha_Nacimiento"), "dd MMMM yyyy").ToString)
            remp("{CIUDAD-NACIMIENTO}", dwEmpleado("CiudadNac"))
            remp("{CARGO}", dwEmpleado("Cargo"))
            remp("{PENSION}", dwEmpleado("Pension"))
            remp("{EPS}", dwEmpleado("EPS"))
            remp("{ARP}", dwEmpleado("Arl"))
            remp("{CONTRATISTA}", dwEmpleado("Empleado"))
        End If

        remp("{Numero_Grupo}", objContrato.numeroGrupo)
        remp("{Especialidad}", objContrato.nombreEspecilidad)
        remp("{NitFormacion}", objContrato.nitCentro)
        remp("{DVFormacion}", objContrato.dvCentro)
        remp("{CentroFormacion}", objContrato.centro)

        remp("{PUNTOS-ASIGANADOS}", getpuntos(objContrato))

        remp("{TURNO}", Exec.ToDbl(dwEmpleado("Turno")).ToString("C"))
        remp("{SALARIO}", Exec.ToDbl(objContrato.salario).ToString("C"))
        remp("{FECHA-CONTRATO}", objContrato.inicio.ToString("dd MMMM yyyy"))
        remp("{FECHA-TERMINACION}", objContrato.fin.ToString("dd MMMM yyyy"))
        remp("{FECHA-CONTRATO-INICIO}", String.Format("{0:%d} de {0:MMMM} del {0:yyyy}", objContrato.inicio), True)                                          'datetimefechainicio.Value.ToString("dd MMMM yyyy"))
        remp("{FECHA-CONTRATO-FIN}", String.Format("{0:%d} de {0:MMMM} del {0:yyyy}", objContrato.fin), True)
        remp("{DURACION-MESES-LETRA}", duracionMeses.ToString + " (" + fConvertirNumeros.Num2Text(duracionMeses) + ")", True)

        remp("{DIAS_LETRAS}", fConvertirNumeros.Num2Text(objContrato.fin.ToString("dd")) +
              " (" + objContrato.inicio.ToString("dd") + ")", True)

        remp("{MES_LETRAS}", objContrato.inicio.ToString("MMMM"), True)

        remp("{AÑO}", objContrato.inicio.ToString("yyyy"))
        Try
            cargarFirmaContrato(objContrato, If(IsDBNull(dw("Firma")), Nothing, dw("Firma")))

            doc.Close(True, False, False)
        Catch
        Finally
            cerrar_doc()
        End Try

    End Sub
    Private Sub cargarFirmaContrato(objContrato As Contrato, firma As Byte())
        Dim ruta As String = crearImagen(If(IsNothing(firma), ConvertToByteArray(My.Resources.blanco), firma))
        Try
            rempfirma("{FIRMA-REPRESENTANTE}", ruta)
            rempfirma("{FIRMA}", generarFirma(objContrato.pictImagen))
        Catch ex As Exception
            rempfirma("{FIRMA}", crearImagen(ConvertToByteArray(My.Resources.blanco)))
        End Try
    End Sub

    Private Function crearImagen(imagen As Byte()) As String
        Dim ima As New PictureBox
        Dim ruta As String = Nothing
        If Not IsNothing(imagen) Then
            If (imagen IsNot DBNull.Value AndAlso imagen.Length > 0) Then
                Dim ms As New MemoryStream(DirectCast(imagen, Byte()))
                ima.Image = Image.FromStream(ms)
                ms.Dispose()
                imagen = Nothing
            End If
            ruta = generarFirma(ima)
        End If
        Return ruta
    End Function
    Private Function generarFirma(pictImagen As PictureBox) As String
        Dim ruta As String
        ruta = IO.Path.GetTempPath & Replace(Replace(Format(DateTime.Now, Constantes.FORMATO_FECHA_HORA_GEN2), ":", String.Empty), " ", String.Empty) & ".png"
        pictImagen.Image.Save(ruta)
        Return ruta
    End Function
    Public Shared Function ConvertToByteArray(ByVal value As Bitmap) As Byte()
        Dim bitmapBytes As Byte()

        Using stream As New System.IO.MemoryStream

            value.Save(stream, value.RawFormat)
            bitmapBytes = stream.ToArray

        End Using

        Return bitmapBytes

    End Function
    Sub remp(ByVal bus As String, ByVal por As Object, Optional ProperCase As Boolean = False)
        If por Is DBNull.Value Then Return
        Try
            With doc.Range.Find
                .Text = bus
                .Replacement.Text = If(ProperCase, StrConv(por, VbStrConv.ProperCase), por.ToString.ToUpper)
                .Wrap = Word.WdFindWrap.wdFindContinue
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            End With
        Catch
        End Try
    End Sub
    Sub rempfirma(ByVal bus As String, ByVal path As String)
        Try
            Dim rango As Word.Range = Me.doc.Range
            With rango.Find
                .Text = bus
                .Execute()
                Dim ob As Object = rango.InlineShapes.AddPicture(path)
                ob.Height = CInt(ob.Height * (150 / ob.Width))
                ob.Width = 150
                .Replacement.Text = ""
                .Execute(Replace:=Word.WdReplace.wdReplaceOne)
            End With
        Catch
        End Try
    End Sub
    Public Sub cerrar_doc()
        Try
            doc.Close(False, False, False)
        Catch
        End Try
        Try
            wd.Quit(False, False, False)
        Catch
        End Try
    End Sub
    Sub bytes_to_rtf(objContrato As Contrato, textminuta As RichTextBox)
        wd = New Word.ApplicationClass
        Try
            doc = wd.Documents.Open(objContrato.tempfileurl + ".docx", False, False, False)
            doc.SaveAs(objContrato.tempfileurl + ".rtf", Word.WdSaveFormat.wdFormatRTF)

            If objContrato.bndraImprimir = True Then
                objContrato.bndraImprimir = False
                wd.Visible = True
                wd.Activate()
                wd.PrintPreview = True
            Else
                Call cerrar_doc()
                textminuta.LoadFile(objContrato.tempfileurl + ".rtf")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function getpuntos(objContrato As Contrato) As String
        Dim pp As String = ""
        For Each i As DataRow In objContrato.dtPunto.Select
            pp += i.Item("Nombre").ToString + ", "
        Next
        Return pp.TrimEnd(" ").TrimEnd(",").ToUpper
    End Function
    Private Function gtContrato(objContrato As Contrato) As String
        Dim resultado As String = Nothing
        Select Case objContrato.tipo
            Case Constantes.CONTRATO_lABORAL
                resultado = "Labotal"
            Case Constantes.CONTRATO_PRESTACION_SERVICIO
                resultado = "Prestación de servicio"
            Case Constantes.CONTRATO_APREDIZAJE
                resultado = "Aprendizaje"
            Case Constantes.CONTRATO_VALUNTARIO
                resultado = "Voluntario"
        End Select
        Return resultado
    End Function
End Class
