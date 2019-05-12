Public Class HistoriaClinicaBLL

    Public Shared Sub quitarProductosMayorHorario24(ByRef dt As DataTable)
        Dim borrar As Boolean
        Do
            borrar = False
            For i = 0 To dt.Rows.Count - 1
                If (IsNumeric(dt.Rows(i).Item("Horario")) AndAlso CInt(dt.Rows(i).Item("Horario")) > 24) OrElse dt.Rows(i).Item("Suspender") Then
                    dt.Rows.RemoveAt(i)
                    borrar = True
                    Exit For
                End If
            Next
        Loop While (borrar = True)


    End Sub

    Public Shared Sub calcularFrecuencia(ByRef dt As DataTable)
        If IsNothing(dt.Columns("Cantidad")) Then
            For I = 0 To dt.Rows.Count - 1
                If dt.Rows(I).Item("Código").ToString <> "" Then
                    If dt.Rows(I).Item("Horario").ToString = Constantes.ITEM_dgv_SELECCIONE Then
                        dt.Rows(I).Item("Frecuencia") = 0
                    ElseIf dt.Rows(I).Item("Horario").ToString = "AH" OrElse dt.Rows(I).Item("Horario").ToString = "RN" OrElse dt.Rows(I).Item("Horario").ToString = "CA" OrElse dt.Rows(I).Item("Horario") > 24 Then
                        dt.Rows(I).Item("Frecuencia") = 1
                    Else
                        dt.Rows(I).Item("Frecuencia") = Math.Floor(24 / dt.Rows(I).Item("Horario"))
                    End If
                End If
            Next
        Else
            For I = 0 To dt.Rows.Count - 1
                If dt.Rows(I).Item("Código").ToString <> "" Then
                    If dt.Rows(I).Item("Cantidad").ToString = "" Then
                        dt.Rows(I).Item("Cantidad") = 1
                    End If
                    If dt.Rows(I).Item("Cantidad") > 24 Then
                        dt.Rows(I).Item("Frecuencia") = 1
                    ElseIf dt.Rows(I).Item("Cantidad") = 0 Then
                        dt.Rows(I).Item("Frecuencia") = 0
                    Else
                        dt.Rows(I).Item("Frecuencia") = Math.Floor(24 / dt.Rows(I).Item("Cantidad"))
                    End If
                End If
            Next
        End If


    End Sub

    Public Shared Sub calcularTotalDisolvente(ByRef dt As DataTable)
        Dim vTemporal As Double ''se utiliza para calcular el total disolvente
        For I = 0 To dt.Rows.Count - 1
            If dt.Rows(I).Item("Código").ToString <> "" Then
                If dt.Rows(I).Item("CódigoDisolvente") = Constantes.VALOR_NO_APLICA Then
                    vTemporal = 0
                Else
                    vTemporal = dt.Rows(I).Item("Cantidad") * dt.Rows(I).Item("ConcentracionDisolvente")
                End If
                dt.Rows(I).Item("TotalDisolvente") = vTemporal & " " & dt.Rows(I).Item("UnidadDisolvente")
            End If
        Next

    End Sub
    Public Shared Sub calcularTotalDosis(ByRef dt As DataTable)
        Dim vTemporal As Double ''se utiliza para calcular el total dosis
        For I = 0 To dt.Rows.Count - 2
            If dt.Rows(I).Item("Dosis").ToString = "" Then
                dt.Rows(I).Item("Dosis") = 1
            End If
            If dt.Rows(I).Item("CódigoDisolvente") = Constantes.VALOR_NO_APLICA Then
                vTemporal = dt.Rows(I).Item("Dosis")
            ElseIf dt.Rows(I).Item("Velocidad") = 0 Then
                vTemporal = 0
                vTemporal = Math.Ceiling(vTemporal) ''CANTIDAD
                vTemporal = vTemporal * dt.Rows(I).Item("Dosis")
            Else
                vTemporal = 24 / Math.Ceiling(dt.Rows(I).Item("Dosis") / dt.Rows(I).Item("Velocidad"))
                vTemporal = Math.Ceiling(vTemporal) ''CANTIDAD
                vTemporal = vTemporal * dt.Rows(I).Item("Dosis")
            End If
            dt.Rows(I).Item("TotalDosis") = vTemporal & " " & dt.Rows(I).Item("Unidad")
        Next

    End Sub

    Public Shared Sub verificaEdicion(sender As DataGridView, opcionCancelar As Boolean, guardar As Boolean, primeraVez As Boolean)
        If sender.DataSource Is Nothing OrElse opcionCancelar = True OrElse guardar = False OrElse sender.CurrentRow.Index = sender.Rows.Count - 1 Then
            Exit Sub
        End If
        If IsNothing(sender.DataSource.Columns("Cantidad")) = False AndAlso sender.DataSource.Rows(sender.CurrentRow.Index).Item("Cantidad").ToString = "" Then
            sender.DataSource.Rows(sender.CurrentRow.Index).Item("Cantidad") = Constantes.VALOR_VALIDO
        End If
        sender.EndEdit()
        If sender.DataSource.Rows(sender.CurrentRow.Index).Item("Estado").ToString = Constantes.ITEM_CARGADO Then
            sender.DataSource.Rows(sender.CurrentRow.Index).Item("Estado") = Constantes.ITEM_MODIFICADO
        End If

    End Sub
    Public Shared Sub getFechaValida(modulo As String, nRegistro As Integer, fechaAColocar As Object)
        Dim dtResultado As New DataTable
        Dim consulta As String = ""
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.FECHA_VALIDA
            Case Constantes.AM
                consulta = Consultas.FECHA_VALIDAR
            Case Constantes.AF
                consulta = Consultas.FECHA_VALIDARR
        End Select
        General.llenarTablaYdgv(consulta & nRegistro, dtResultado)
        If dtResultado.Rows.Count > 0 Then
            fechaAColocar.value = dtResultado.Rows(0).Item("Fecha")
        End If
    End Sub

    Public Shared Function verificarEstanciaDia(modulo As String, nRegistro As Integer, fecha As Date) As Boolean
        Dim consulta As String = ""
        Select Case modulo
            Case Constantes.HC
                consulta = Consultas.FECHA_ESTANCIA_VERIFICAR
            Case Constantes.AM
                consulta = Consultas.FECHA_ESTANCIA_VERIFICARR
            Case Constantes.AF
                consulta = Consultas.FECHA_ESTANCIA_VERIFICARRR
        End Select
        Return General.getEstadoVF(consulta & nRegistro & ",'" & fecha & "'")
    End Function
    Public Shared Function nombreTabla(dgv As DataGridView, dt As DataTable, Optional indice As Integer = -1) As String
        Dim nombre As String
        Dim indiceFila As Integer
        If indice <> -1 Then
            indiceFila = indice
        Else
            indiceFila = dgv.CurrentRow.Index
        End If
        If dt.Rows(indiceFila).Item("Consecutivo").ToString = "" Then
            nombre = "Indice-" & indiceFila
        Else
            nombre = "Consecutivo-" & dt.Rows(indiceFila).Item("Consecutivo").ToString
        End If
        Return nombre
    End Function

    Public Shared Sub eliminarTablaMezcla(ByRef dsMezcla As DataSet, nombreTablaMezcla As String)
        If dsMezcla.Tables.Contains(nombreTablaMezcla) = True Then
            dsMezcla.Tables.Remove(nombreTablaMezcla)
        End If
    End Sub

    Public Shared Sub asignarTabla(dgvinfusion As Object, dgvMezcla As Object, dsMezcla As Object)
        Dim NombreTablaMezcla As String
        NombreTablaMezcla = nombreTabla(dgvinfusion, dgvinfusion.datasource)

        If dsMezcla.Tables.Contains(NombreTablaMezcla) = False Then
            dsMezcla.Tables.Add(NombreTablaMezcla)
            Dim colM0, colM1, colM2, colM3, colM4 As New DataColumn
            colM0.ColumnName = "Código"
            colM0.DataType = Type.GetType("System.String")
            colM0.DefaultValue = String.Empty
            dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM0)

            colM1.ColumnName = "Descripción"
            colM1.DataType = Type.GetType("System.String")
            colM1.DefaultValue = String.Empty
            dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM1)

            colM2.ColumnName = "Unidad"
            colM2.DataType = Type.GetType("System.String")
            colM2.DefaultValue = String.Empty
            dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM2)

            colM3.ColumnName = "Dosis"
            colM3.DataType = Type.GetType("System.Double")
            colM3.DefaultValue = Constantes.VALOR_VALIDO
            dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM3)

            colM4.ColumnName = "Estado"
            colM4.DataType = Type.GetType("System.String")
            colM4.DefaultValue = String.Empty
            dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM4)

        Else
            If dsMezcla.Tables(NombreTablaMezcla).Columns.Contains("Código") = False Then
                Dim colM0, colM1, colM2, colM3, colM4 As New DataColumn

                colM0.ColumnName = "Código"
                colM0.DataType = Type.GetType("System.String")
                colM0.DefaultValue = String.Empty
                dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM0)

                colM1.ColumnName = "Descripción"
                colM1.DataType = Type.GetType("System.String")
                colM1.DefaultValue = String.Empty
                dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM1)

                colM2.ColumnName = "Unidad"
                colM2.DataType = Type.GetType("System.String")
                colM2.DefaultValue = String.Empty
                dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM2)

                colM3.ColumnName = "Dosis"
                colM3.DataType = Type.GetType("System.Double")
                colM3.DefaultValue = Constantes.VALOR_VALIDO
                dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM3)

                colM4.ColumnName = "Estado"
                colM4.DataType = Type.GetType("System.String")
                colM4.DefaultValue = String.Empty
                dsMezcla.Tables(NombreTablaMezcla).Columns.Add(colM4)
            End If
        End If
        With dgvMezcla
            .Columns.Item("dgCodigoMezcla").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgCodigoMezcla").DataPropertyName = "Código"

            .Columns.Item("dgDescripcionMezcla").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDescripcionMezcla").DataPropertyName = "Descripción"
            .Columns.Item("dgDescripcionMezcla").readonly = True

            .Columns.Item("dgDosisMezcla").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgDosisMezcla").DataPropertyName = "dosis"

            .Columns.Item("dgUnidadMezcla").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgUnidadMezcla").DataPropertyName = "Unidad"
            .Columns.Item("dgUnidadMezcla").readonly = True

            .Columns.Item("dgEstadoMezcla").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns.Item("dgEstadoMezcla").DataPropertyName = "Estado"
        End With

        dgvMezcla.AutoGenerateColumns = False
        dgvMezcla.DataSource = dsMezcla.Tables(NombreTablaMezcla)
        dgvMezcla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMezcla.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        dsMezcla.Tables(NombreTablaMezcla).Rows.Add()
        dgvMezcla.rows(dgvMezcla.rowcount - 1).cells("dgDosisMezcla").readonly = True

    End Sub

    Public Shared Function eliminarDetalle(tipo As Integer, modulo As String, dt As Object, dgv As Object, Optional codigoOrden As String = "", Optional vEspecial As String = Constantes.COMBO_VALOR_PREDETERMINADO) As String
        If dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Estado").ToString = Constantes.ITEM_NUEVO AndAlso tipo <> Constantes.OM_MEZCLA_TABLA Then
            dgv.datasource.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
        ElseIf dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Estado").ToString <> "" OrElse tipo = Constantes.OM_MEZCLA_TABLA Then
            If tipo = Constantes.OM_MEZCLA_TABLA OrElse MsgBox(Mensajes.ANULAR, MsgBoxStyle.Question + MsgBoxStyle.YesNo, TitulosForm.ANULAR) = MsgBoxResult.Yes Then
                Dim consulta As String = ""
                Select Case tipo
                    Case Constantes.OM_ESTANCIA
                        Select Case modulo
                            Case Constantes.HC
                                consulta = Consultas.ANULAR_DIAESTANCIA & vEspecial & ",'" & CDate(dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Dia")).Date & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                            Case Constantes.AM
                                consulta = Consultas.ANULAR_DIAESTANCIAR & vEspecial & ",'" & CDate(dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Dia")).Date & "'," & SesionActual.codigoEP & "," & SesionActual.idUsuario
                            Case Constantes.AF
                                consulta = Consultas.ANULAR_DIAESTANCIARR & vEspecial & ",'" & CDate(dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Dia")).Date & "'," & SesionActual.idUsuario
                        End Select
                    Case Constantes.OM_COMIDA
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_COMIDA_OM & codigoOrden & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_COMIDA_OMR & codigoOrden & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_COMIDA_OMRR & codigoOrden & "," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_OXIGENO
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_OXIGENO_OM & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_OXIGENO_OMR & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_OXIGENO_OMRR & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_PARACLINICO
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_PARACLINICO_OM & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_PARACLINICO_OMR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_PARACLINICO_OMRR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_HEMODERIVADO
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_HEMODERIVADO_OM & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_HEMODERIVADO_OMR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_HEMODERIVADO_OMRR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_GLUCOMETRIA
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_GLUCOMETRIA_OM & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_GLUCOMETRIA_OMR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_GLUCOMETRIA_OMRR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_PROCEDIMIENTO
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_PROCEDIMIENTO_OM & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_PROCEDIMIENTO_OMR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_PROCEDIMIENTO_OMRR & codigoOrden & ",'" & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "'," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_MEDICAMENTO
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_MEDICAMENTO_OM & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_MEDICAMENTO_OMR & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_MEDICAMENTO_OMRR & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_IMPREGNACION
                        If codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_IMPREGNACION_OM & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_IMPREGNACION_OMR & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_IMPREGNACION_OMRR & codigoOrden & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_INFUSION
                        Dim consecutivoMezcla As String
                        consecutivoMezcla = dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Consecutivo").ToString
                        If consecutivoMezcla <> "" AndAlso codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_INFUSION_OM & codigoOrden & "," & consecutivoMezcla & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_INFUSION_OMR & codigoOrden & "," & consecutivoMezcla & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_INFUSION_OMRR & codigoOrden & "," & consecutivoMezcla & "," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_MEZCLA
                        Dim consecutivoMezcla As String
                        consecutivoMezcla = vEspecial
                        If consecutivoMezcla <> "" AndAlso codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_MEZCLA_TABLA_OM & codigoOrden & "," & consecutivoMezcla & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_MEZCLA_TABLA_OMR & codigoOrden & "," & consecutivoMezcla & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_MEZCLA_TABLA_OMRR & codigoOrden & "," & consecutivoMezcla & "," & dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Código") & "," & SesionActual.idUsuario
                            End Select
                        End If

                    Case Constantes.OM_MEZCLA_TABLA
                        Dim consecutivoMezcla As String
                        consecutivoMezcla = dgv.datasource.Rows(dgv.CurrentCell.RowIndex).Item("Consecutivo").ToString
                        If consecutivoMezcla <> "" AndAlso codigoOrden <> "" Then
                            Select Case modulo
                                Case Constantes.HC
                                    consulta = Consultas.ANULAR_MEZCLA_TABLA_OM & codigoOrden & "," & consecutivoMezcla & ",-1," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AM
                                    consulta = Consultas.ANULAR_MEZCLA_TABLA_OMR & codigoOrden & "," & consecutivoMezcla & ",-1," & SesionActual.idUsuario & "," & SesionActual.codigoEP
                                Case Constantes.AF
                                    consulta = Consultas.ANULAR_MEZCLA_TABLA_OMRR & codigoOrden & "," & consecutivoMezcla & ",-1," & SesionActual.idUsuario
                            End Select
                        End If
                        Dim nombreTablaMezcla As String
                        nombreTablaMezcla = nombreTabla(dgv, dgv.datasource)
                        eliminarTablaMezcla(dt, nombreTablaMezcla)
                End Select
                If tipo <> Constantes.OM_MEZCLA_TABLA Then
                    dgv.datasource.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
                End If
                Return consulta
            End If
        End If
        Return ""
    End Function
    Public Shared Sub cargarMezcla(pConsulta As String, ByRef dgv As DataGridView, ByRef ds As DataSet)
        Dim consulta As String = ""
        Dim nombre As String = ""
        ds.Tables.Clear()
        Dim consecutivo As Integer
        For I = 0 To dgv.RowCount - 1
            nombre = nombreTabla(dgv, dgv.DataSource, I)
            consecutivo = dgv.Rows(I).Cells("dgConsecutivoInfu").Value.ToString
            Dim dt As New DataTable
            General.llenarTablaYdgv(pConsulta & consecutivo, dt)
            If dt.Rows.Count > 0 Then
                ds.Tables.Add(nombre)
                General.llenarTablaYdgv(pConsulta & consecutivo, ds.Tables(nombre))
                For J = 0 To ds.Tables(nombre).Rows.Count - 1
                    ds.Tables(nombre).Rows(J).Item("Estado") = Constantes.ITEM_CARGADO
                Next
                dgv.Rows(I).Cells("dgMezclaInfu").Value = My.Resources.OK
                dgv.Rows(I).Cells("dgMezclaInfu").Style.BackColor = Color.LightGreen
            End If
        Next

    End Sub
    Public Shared Sub reiniciarMezcla(pConsulta As String, ByRef dgv As DataGridView, ByRef ds As DataSet)
        Dim consulta As String = ""
        Dim nombre As String = ""
        Dim dsFinal As New DataSet
        dsFinal = ds.Copy
        ds.Tables.Clear()
        For I = 0 To dgv.RowCount - 2
            nombre = "Indice-" & I
            Dim nombreM As String = nombreTabla(dgv, dgv.DataSource, I)
            dgv.Rows(I).Cells("dgConsecutivoInfu").Value = ""

            If (Not IsNothing(dsFinal.Tables(nombreM))) AndAlso dsFinal.Tables(nombreM).Rows.Count > 0 Then
                ds.Tables.Add(nombre)
                ds.Tables(nombre).Columns.Add("Código")
                ds.Tables(nombre).Columns.Add("Descripción")
                ds.Tables(nombre).Columns.Add("Unidad")
                ds.Tables(nombre).Columns.Add("Dosis")
                ds.Tables(nombre).Columns.Add("Estado")
                For J = 0 To dsFinal.Tables(nombreM).Rows.Count - 1
                    ds.Tables(nombre).Rows.Add()
                    ds.Tables(nombre).Rows(J).Item("Código") = dsFinal.Tables(nombreM).Rows(J).Item("Código")
                    ds.Tables(nombre).Rows(J).Item("Descripción") = dsFinal.Tables(nombreM).Rows(J).Item("Descripción")
                    ds.Tables(nombre).Rows(J).Item("Unidad") = dsFinal.Tables(nombreM).Rows(J).Item("Unidad")
                    ds.Tables(nombre).Rows(J).Item("Dosis") = dsFinal.Tables(nombreM).Rows(J).Item("Dosis")
                    ds.Tables(nombre).Rows(J).Item("Estado") = Constantes.ITEM_NUEVO
                Next
                dgv.Rows(I).Cells("dgMezclaInfu").Value = My.Resources.OK
                dgv.Rows(I).Cells("dgMezclaInfu").Style.BackColor = Color.LightGreen
            End If
        Next

    End Sub
    Public Shared Sub cargarDgvOM(tipo As Integer, pConsultaCargar As String, pDt As DataTable, ByRef Optional pDgv As DataGridView = Nothing, Optional parametro As Integer = -1, Optional nRegistro As Integer = -1, Optional fecha As Date = Nothing)
        Try
            Dim params As New List(Of String)
            params.Add(parametro)
            If tipo = Constantes.OM_PARACLINICO_EVO Then
                params.Add(nRegistro)
                params.Add(Format(fecha, Constantes.FORMATO_FECHA_GEN2))
            End If
            General.llenarTabla(pConsultaCargar, params, pDt)
            enlazarTabla(pDgv, pDt, tipo)
            For I = 0 To pDt.Rows.Count - 1
                pDt.Rows(I).Item("Estado") = Constantes.ITEM_MODIFICADO
            Next
            Select Case tipo
                Case Constantes.OM_ESTANCIA
                    pDgv.Columns("N_Registro").Visible = False
                Case Constantes.OM_PARACLINICO
                    pDgv.Columns("Resultado").Visible = False
                    For I = 0 To pDt.Rows.Count - 1
                        If pDt.Rows(I).Item("Resultado") = 1 Then
                            pDgv.Rows(I).Cells("dgResultadoPara").Value = My.Resources.OK
                        Else
                            pDgv.Rows(I).Cells("dgResultadoPara").Value = My.Resources._new
                        End If
                    Next
                Case Constantes.OM_PARACLINICO_EVO
                    pDgv.Columns("Resultado").Visible = False
                    For I = 0 To pDt.Rows.Count - 1
                        If pDt.Rows(I).Item("Resultado") = 1 Then
                            pDgv.Rows(I).Cells("dgResultadosParaEvo").Value = My.Resources.OK
                        Else
                            pDgv.Rows(I).Cells("dgResultadosParaEvo").Value = My.Resources._new
                        End If
                    Next
                Case Constantes.OM_HEMODERIVADO
                    pDgv.Columns("Resultado").Visible = False
                    pDgv.Columns("Formato").Visible = False
                    For I = 0 To pDt.Rows.Count - 1
                        If pDt.Rows(I).Item("Resultado") = 1 Then
                            pDgv.Rows(I).Cells("dgResultadoHemo").Value = My.Resources.OK
                        Else
                            pDgv.Rows(I).Cells("dgResultadoHemo").Value = My.Resources._new
                        End If
                        If pDt.Rows(I).Item("Formato") = 1 Then
                            pDgv.Rows(I).Cells("dgFormatoHemo").Value = My.Resources.ok2
                        Else
                            pDgv.Rows(I).Cells("dgFormatoHemo").Value = My.Resources._new
                        End If
                    Next
                Case Constantes.OM_GLUCOMETRIA
                    calcularFrecuencia(pDt)
                Case Constantes.OM_IMPREGNACION
                    calcularTotalDisolvente(pDt)
                Case Constantes.OM_INFUSION
                    calcularTotalDosis(pDt)
                Case Constantes.OM_MEDICAMENTO
                    calcularFrecuencia(pDt)
                Case Constantes.OM_PROCEDIMIENTO
                    pDgv.Columns("Resultado").Visible = False
                    pDgv.Columns("Formato").Visible = False
                    For I = 0 To pDt.Rows.Count - 1
                        If pDt.Rows(I).Item("Resultado") = 1 Then
                            pDgv.Rows(I).Cells("dgResultadoProce").Value = My.Resources.OK
                        Else
                            pDgv.Rows(I).Cells("dgResultadoProce").Value = My.Resources._new
                        End If
                        If pDt.Rows(I).Item("Formato") = 1 Then
                            pDgv.Rows(I).Cells("dgFormatoProce").Value = My.Resources.ok2
                        Else
                            pDgv.Rows(I).Cells("dgFormatoProce").Value = My.Resources._new
                        End If
                    Next
                    If pDgv.Columns.Contains("grupo") Then
                        pDgv.Columns.Remove("grupo")
                    End If
            End Select
            pDgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
        Catch ex As Exception
            General.manejoErrores(ex)
        End Try
    End Sub

    Public Shared Function verificarValorPermitido(ByRef dtg As DataGridView) As String
        'dtg.DataSource.AcceptChanges, esto está interfiriendo con los tag en las grillas.
        Dim dt As New DataTable
        dt = dtg.DataSource.copy
        dt.AcceptChanges()
        If (IsNothing(dt.Columns("Dosis")) = False AndAlso IsNothing(dt.Columns("Cantidad")) = True AndAlso dt.Select("(Dosis='0' OR CONVERT(Dosis,'System.String')='' or Dosis is null) and Código<>''", "").Count > 0) OrElse
            (IsNothing(dt.Columns("Cantidad")) = False AndAlso IsNothing(dt.Columns("CódigoDisolvente")) = True AndAlso dt.Select("Cantidad=0 and Código<>''", "").Count > 0) OrElse
            (IsNothing(dt.Columns("Cantidad")) = False AndAlso IsNothing(dt.Columns("CódigoDisolvente")) = False AndAlso dt.Select("((Cantidad=0 and CódigoDisolvente<>0) or (Dosis=0 OR CONVERT(Dosis,'System.String')='') or (Velocidad=0))  and Código<>''", "").Count > 0) Then
            dtg.Focus()
            Return Mensajes.CANTIDAD_VALIDA
        End If
        Return ""
    End Function
    Public Shared Function verificarJustificacionTerapiaFisica(ByRef dtg As DataGridView) As String
        Dim dt As New DataTable
        dt = dtg.DataSource.copy
        dt.AcceptChanges()
        If dt.Columns.Contains("grupo") Then
            If dt.Select("Justificación = '' and grupo = 6 ", "").Count > 0 Then
                dtg.Focus()
                Return Mensajes.JUSTIFICACION_TERAPIA_FISICA
            End If
        End If
        Return ""
    End Function
    Public Shared Function validarHorarioEInicio(ByRef comboHoraInicio As ComboBox) As String
        If comboHoraInicio.SelectedItem.ToString() = Constantes.ITEM_dgv_SELECCIONE Then
            Return Mensajes.HORA_INICIO_INVALIDA
        End If
        Return ""
    End Function
    Public Shared Function PesoPacienteRequerido(ByRef NDPesoPacienteNutricion As NumericUpDown) As String
        If NDPesoPacienteNutricion.Value = 0 Then
            Return Mensajes.PESO_INVALIDO
        End If
        Return ""
    End Function
    Public Shared Function volumenAguaDestiladaValida(ByRef NDAguaDestilada As NumericUpDown) As String
        If NDAguaDestilada.Value < 0 Then
            Return Mensajes.CANTIDAD_DE_AGUA_INVALIDA
        End If
        Return ""
    End Function
    Public Shared Function esPositivo(ByVal valor As Double) As String
        If valor >= 0 Then
            Return ""
        End If
        Return Mensajes.CANTIDAD_DE_AGUA_INVALIDA
    End Function
    Public Shared Function GetNumeroMedicamentosOrdenadosNutricion(ByRef tablaNutricion As DataTable) As Integer
        Dim numeroProductos As Integer
        numeroProductos = If(IsDBNull(tablaNutricion.Select("Requerimiento > 0", "").Count), 0, tablaNutricion.Select("Requerimiento > 0", "").Count)
        Return numeroProductos
    End Function

    Public Shared Function verificarNumerosSuspendidos(ByRef tablaOxigeno As DataTable) As Integer
        Return tablaOxigeno.Select("Suspender =  True", "").Count
    End Function
    Public Shared Function verificarEstancia(modulo As String, diasEstancia As Integer, dtEstancias As DataTable, dgvEstancia As Object, opcionMayor As Boolean, nRegistro As Integer) As String
        Dim cantidadDiasRegistrados As Integer
        cantidadDiasRegistrados = dtEstancias.Select("N_Registro=" & nRegistro & "").Count
        If diasEstancia > cantidadDiasRegistrados And opcionMayor = True Then
            Return Mensajes.FALTA_ESTANCIA
        ElseIf diasEstancia + Constantes.DIAS_PERMITIDO_ADELANTAR < cantidadDiasRegistrados Then
            Return Mensajes.MAYOR_REGISTRO_ESTANCIA

        Else
            Dim diaDiferencia As Integer
            For i = 0 To dtEstancias.Rows.Count - 2
                If dtEstancias.Rows(i).Item("Justificación").ToString.Trim = "" Then
                    dgvEstancia.Rows(i).Cells("dgJustificacion").Selected = True
                    Return Mensajes.JUSTIFICAR_ESTANCIA
                End If
                diaDiferencia = DateDiff(DateInterval.Day, CDate(General.fechaActualServidor).Date, CDate(dtEstancias.Rows(i).Item("Dia").ToString.Trim).Date)
                If dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 AndAlso diaDiferencia > 1 Then
                    Return Mensajes.FECHA_MAYOR_PERMITIDA
                End If
            Next

            'VALIDA LA FECHA SELECCIONADA NO SEA MAYOR A LA EPICRISIS
            Dim dtResultado As New DataTable
            Dim consulta As String = ""
            If modulo = Constantes.HC Then
                consulta = Consultas.FECHA_EPICRISIS_VERIFICAR
            ElseIf modulo = Constantes.AM Then
                consulta = Consultas.FECHA_EPICRISIS_VERIFICARR
            ElseIf modulo = Constantes.AF Then
                consulta = Consultas.FECHA_EPICRISIS_VERIFICARRR
            End If
            General.llenarTablaYdgv(consulta & nRegistro, dtResultado)
            If dtResultado.Rows.Count > 0 Then
                If dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 AndAlso CDate(dgvEstancia.rows(dgvEstancia.CurrentCell.RowIndex).cells("dgDiaEstancia").value).Date > CDate(dtResultado.Rows(0).Item("Fecha_Egreso")).Date Then
                    dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).Cells("dgDiaEstancia").Selected = True
                    Return Mensajes.FECHA_MAYOR_EPICRISIS
                End If
            End If

        End If
        Return ""
    End Function
    Public Shared Function verificarSeleccionComida(dgv As DataGridView, Optional comidaSeleccionada As Boolean = False,
                                                    Optional desayuno As Boolean = False,
                                                    Optional almuerzo As Boolean = False,
                                                    Optional cena As Boolean = False) As String
        If comidaSeleccionada = False Then
            For i = 0 To dgv.RowCount - 2
                If dgv.Rows(i).Cells("dgDesayuno").Value = False AndAlso
                    dgv.Rows(i).Cells("dgAlmuerzo").Value = False AndAlso
                    dgv.Rows(i).Cells("dgCena").Value = False Then
                    Return Mensajes.COMIDA_NO_SELECCIONADA
                End If
            Next

        ElseIf comidaSeleccionada = True AndAlso dgv.CurrentCell.RowIndex <> dgv.RowCount - 1 Then
            Dim dr As DataRow
            Dim params As New List(Of String)
            params.Add(SesionActual.codigoEP)
            dr = General.cargarItem(ConsultasHC.ORDEN_MEDICA_HORA_COMIDA_VERIFICAR, params)

            If (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgDesayuno").Selected = True AndAlso
                desayuno = True AndAlso
                General.fechaActualServidor.Hour > dr.Item(0)) OrElse
                (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgAlmuerzo").Selected = True AndAlso
                almuerzo = True AndAlso
                General.fechaActualServidor.Hour > dr.Item(1)) OrElse
                (dgv.Rows(dgv.CurrentCell.RowIndex).Cells("dgCena").Selected = True AndAlso
                cena = True AndAlso
                General.fechaActualServidor.Hour > dr.Item(2)) Then
                Dim mensje As String
                mensje = "Horario limite: " & vbCrLf & "Desayuno: " & dr.Item(3) & vbCrLf & "Almuerzo: " & dr.Item(4) & vbCrLf & "Cena: " & dr.Item(5)
                Return Mensajes.COMIDA_HORA_NO_PERMITIDA & vbCrLf & mensje
            End If
        End If
        Return ""
    End Function

    Public Shared Function verificarEstanciaPost(modulo As String, nRegistro As Integer, fechaAdmision As Date, dgvEstancia As Object, fechaOrden As Date, Optional diaSeleccionado As Boolean = False) As String

        'VALIDA LA FECHA SELECCIONADA NO MENOR AL INGRESO DEL PACIENTE
        If dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 AndAlso
            CDate(fechaAdmision).Date > CDate(dgvEstancia.rows(dgvEstancia.CurrentCell.RowIndex).cells("dgDiaEstancia").value).Date AndAlso
                    String.IsNullOrEmpty(dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).cells("N_Registro").value.ToString) = False AndAlso
                                         dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).cells("N_Registro").value.ToString = nRegistro Then
            Return Mensajes.FECHA_MENOR_INGRESO
        End If
        'VALIDA LA FECHA SELECCIONADA NO MAYOR A 1 DIA DE DIFERENCIA A PARTIR DE HOY
        If dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 Then
            Dim diaDiferencia As Integer
            diaDiferencia = DateDiff(DateInterval.Day, CDate(General.fechaActualServidor).Date, CDate(dgvEstancia.rows(dgvEstancia.CurrentCell.RowIndex).cells("dgDiaEstancia").value).Date)
            If dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 AndAlso diaDiferencia > 1 Then
                Return Mensajes.FECHA_MAYOR_PERMITIDA
            End If
        End If

        'VALIDA LA FECHA SELECCIONADA NO EXISTA 
        For i = 0 To dgvEstancia.RowCount - 2
            If diaSeleccionado = True Then
                Exit For
            End If
            If i <> dgvEstancia.CurrentCell.RowIndex And dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 Then
                If CDate(dgvEstancia.rows(dgvEstancia.CurrentCell.RowIndex).cells("dgDiaEstancia").value).Date = CDate(dgvEstancia.rows(i).cells("dgDiaEstancia").value).Date AndAlso
                    String.IsNullOrEmpty(dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).cells("N_Registro").value.ToString) = False AndAlso
                                         dgvEstancia.Rows(dgvEstancia.CurrentCell.RowIndex).cells("N_Registro").value.ToString = nRegistro Then
                    Return Mensajes.EXISTE_ESTANCIA & Format(CDate(dgvEstancia.rows(i).cells("dgDiaEstancia").value).Date, Constantes.FORMATO_FECHA_GEN)
                End If
            End If
        Next
        'VALIDA NO HAGA FALTA ESTANCIA
        Dim dtEstancia As New DataTable
        dtEstancia = dgvEstancia.datasource.Copy

        If diaSeleccionado = False AndAlso dtEstancia.Select("N_Registro =" & nRegistro & " and CONVERT(Dia,'System.String') LIKE '" & Replace(Format(fechaOrden, Constantes.FORMATO_FECHA_ACTUAL), "-", "/") & "%'", "").Count = 0 Then
            Return Mensajes.FALTA_ESTANCIA & Format(fechaOrden, Constantes.FORMATO_FECHA_ACTUAL)
        End If
        'VALIDA LA FECHA SELECCIONADA NO SEA MAYOR A LA EPICRISIS
        Dim dtResultado As New DataTable
        Dim consulta As String = ""
        If modulo = Constantes.HC Then
            consulta = Consultas.FECHA_EPICRISIS_VERIFICAR
        ElseIf modulo = Constantes.AM Then
            consulta = Consultas.FECHA_EPICRISIS_VERIFICARR
        ElseIf modulo = Constantes.AF Then
            consulta = Consultas.FECHA_EPICRISIS_VERIFICARRR
        End If
        General.llenarTablaYdgv(consulta & nRegistro, dtResultado)
        If dtResultado.Rows.Count > 0 Then
            If dgvEstancia.CurrentCell.RowIndex <> dgvEstancia.RowCount - 1 AndAlso
                CDate(dgvEstancia.rows(dgvEstancia.CurrentCell.RowIndex).cells("dgDiaEstancia").value).Date > Replace(Format(CDate(dtResultado.Rows(0).Item("Fecha_Egreso")).Date, Constantes.FORMATO_FECHA_GEN), "-", "/") Then
                Return Mensajes.FECHA_MAYOR_EPICRISIS & Format(CDate(dtResultado.Rows(0).Item("Fecha_Egreso")).Date, Constantes.FORMATO_FECHA_GEN)
            End If
        End If

        Return ""
    End Function


    Public Shared Sub enlazarTabla(dgv As DataGridView, dt As DataTable, tipo As Integer)
        Select Case tipo
            Case Constantes.OM_ESTANCIA
                With dgv
                    .Columns("dgCodigo").DataPropertyName = "Código"
                    .Columns("dgDescripcion").DataPropertyName = "Descripción"
                    .Columns("dgDiaEstancia").DataPropertyName = "Dia"
                    .Columns("dgJustificacion").DataPropertyName = "Justificación"
                    .Columns("dgEstado").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_COMIDA
                With dgv
                    .Columns("dgCodigoComida").DataPropertyName = "Código"
                    .Columns("dgDescripcionComida").DataPropertyName = "Descripción"
                    .Columns("dgDesayuno").DataPropertyName = "Desayuno"
                    .Columns("dgAlmuerzo").DataPropertyName = "Almuerzo"
                    .Columns("dgCena").DataPropertyName = "Cena"
                    .Columns("dgJustificacionComida").DataPropertyName = "Justificación"
                    .Columns("dgVirtual").DataPropertyName = "Virtual"
                    .Columns("dgEstadoComida").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_OXIGENO
                With dgv
                    .Columns("dgCodigoOxigeno").DataPropertyName = "Código"
                    .Columns("dgDescripcionOxigeno").DataPropertyName = "Descripción"
                    .Columns("dgPorcentaje").DataPropertyName = "Porcentaje"
                    .Columns("dgJustificacionOxigeno").DataPropertyName = "Justificación"
                    .Columns("dgEstadoOxigeno").DataPropertyName = "Estado"
                    .Columns("SuspenderOx").DataPropertyName = "Suspender"
                End With
            Case Constantes.OM_PARACLINICO
                With dgv
                    .Columns("dgCodigoTipoParaclinicoOM").DataPropertyName = "CodigoTipoExamen"
                    .Columns("dgCodigoPara").DataPropertyName = "Código"
                    .Columns("dgDescripcionPara").DataPropertyName = "Descripción"
                    .Columns("dgCantidadPara").DataPropertyName = "Cantidad"
                    .Columns("dgIndicacionPara").DataPropertyName = "Indicación"
                    .Columns("dgJustificacionPara").DataPropertyName = "Justificación"
                    .Columns("dgEstadoPara").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_PARACLINICO_EVO
                With dgv
                    .Columns("dgCodigoTipoParaclinicoOMEvo").DataPropertyName = "CodigoTipoExamen"
                    .Columns("dgCodigoParaEvo").DataPropertyName = "Código"
                    .Columns("dgDescripcionParaEvo").DataPropertyName = "Descripción"
                    .Columns("dgCantidadParaEvo").DataPropertyName = "Cantidad"
                    .Columns("dgInterpretacionParaEvo").DataPropertyName = "Interpretación"
                    .Columns("dgJustificacionParaEvo").DataPropertyName = "Justificación"
                    .Columns("dgEstadoParaEvo").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_HEMODERIVADO
                With dgv
                    .Columns("dgCodigoHemo").DataPropertyName = "Código"
                    .Columns("dgDescripcionHemo").DataPropertyName = "Descripción"
                    .Columns("dgCantidadHemo").DataPropertyName = "Cantidad"
                    .Columns("dgIndicacionHemo").DataPropertyName = "Indicación"
                    .Columns("dgJustificacionHemo").DataPropertyName = "Justificación"
                    .Columns("dgEstadoHemo").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_GLUCOMETRIA
                With dgv
                    .Columns("dgCodigoGlu").DataPropertyName = "Código"
                    .Columns("dgDescripcionGlu").DataPropertyName = "Descripción"
                    .Columns("dgCantidadGlu").DataPropertyName = "Cantidad"
                    .Columns("dgInicioGlu").DataPropertyName = "Inicio"
                    .Columns("dgFrecuenciaGlu").DataPropertyName = "Frecuencia"
                    .Columns("dgEstadoGlu").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_PROCEDIMIENTO
                With dgv
                    .Columns("dgCodigoProce").DataPropertyName = "Código"
                    .Columns("dgDescripcionProce").DataPropertyName = "Descripción"
                    .Columns("dgCantidadProce").DataPropertyName = "Cantidad"
                    .Columns("dgIndicacionProce").DataPropertyName = "Indicación"
                    .Columns("dgJustificacionProce").DataPropertyName = "Justificación"
                    .Columns("dgEstadoProce").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_MEDICAMENTO
                With dgv
                    .Columns("dgCodigoMed").DataPropertyName = "Código"
                    .Columns("dgDescripcionMed").DataPropertyName = "Descripción"
                    .Columns("dgDosisMed").DataPropertyName = "Dosis"
                    .Columns("dgUnidadMed").DataPropertyName = "Unidad"
                    .Columns("dgCodigoViaMed").DataPropertyName = "CódigoVia"
                    .Columns("dgViaMed").DataPropertyName = "DescripciónVia"
                    .Columns("dgHorarioMed").DataPropertyName = "Horario"
                    .Columns("dgInicioMed").DataPropertyName = "Inicio"
                    .Columns("dgFrecuenciaMed").DataPropertyName = "Frecuencia"
                    .Columns("dgDiaMed").DataPropertyName = "Dias"
                    .Columns("dgSuspenderMed").DataPropertyName = "Suspender"
                    .Columns("dgEstadoMed").DataPropertyName = "Estado"
                End With
            Case Constantes.OM_IMPREGNACION
                With dgv
                    .Columns("dgCodigoImpre").DataPropertyName = "Código"
                    .Columns("dgDescripcionImpre").DataPropertyName = "Descripción"
                    .Columns("dgDosisImpre").DataPropertyName = "Dosis"
                    .Columns("dgUnidadImpre").DataPropertyName = "Unidad"
                    .Columns("dgVelocidadImpre").DataPropertyName = "Velocidad"
                    .Columns("dgCodigoDisolventeImpre").DataPropertyName = "CódigoDisolvente"
                    .Columns("dgDisolventeImpre").DataPropertyName = "DescripciónDisolvente"
                    .Columns("dgCantidadImpre").DataPropertyName = "Cantidad"
                    .Columns("dgTotalDisolventeImpre").DataPropertyName = "TotalDisolvente"
                    .Columns("dgInicioImpre").DataPropertyName = "Inicio"
                    .Columns("dgDiasImpre").DataPropertyName = "Dias"
                    .Columns("dgSuspenderImpre").DataPropertyName = "Suspender"
                    .Columns("dgConcentracionDisolImpre").DataPropertyName = "ConcentracionDisolvente"
                    .Columns("dgUnidadDisolImpre").DataPropertyName = "UnidadDisolvente"
                    .Columns("dgEstadoImpre").DataPropertyName = "Estado"
                End With

            Case Constantes.OM_INFUSION
                With dgv
                    .Columns("dgCodigoInfu").DataPropertyName = "Código"
                    .Columns("dgDescripcionInfu").DataPropertyName = "Descripción"
                    .Columns("dgDosisInfu").DataPropertyName = "Dosis"
                    .Columns("dgUnidadInfu").DataPropertyName = "Unidad"
                    .Columns("dgVelocidadInfu").DataPropertyName = "Velocidad"
                    .Columns("dgCodigoDisolventeInfu").DataPropertyName = "CódigoDisolvente"
                    .Columns("dgDisolventeInfu").DataPropertyName = "DescripciónDisolvente"
                    .Columns("dgTotalDosisInfu").DataPropertyName = "TotalDosis"
                    .Columns("dgInicioInfu").DataPropertyName = "Inicio"
                    .Columns("dgDiasInfu").DataPropertyName = "Dias"
                    .Columns("dgSuspenderInfu").DataPropertyName = "Suspender"
                    .Columns("dgConsecutivoInfu").DataPropertyName = "Consecutivo"
                    .Columns("dgEstadoInfu").DataPropertyName = "Estado"

                End With
        End Select
        Select Case tipo
            Case Constantes.OM_GLUCOMETRIA
                For I = 0 To dt.Rows.Count - 1
                    If IsNothing(dt.Rows(I).Item("Inicio")) = False AndAlso dt.Rows(I).Item("Inicio") = Constantes.ITEM_DGV_SELECCIONE_VALOR Then
                        dt.Rows(I).Item("Inicio") = Constantes.ITEM_dgv_SELECCIONE
                    End If
                Next
            Case Constantes.OM_MEDICAMENTO
                For I = 0 To dt.Rows.Count - 1
                    If dt.Rows(I).Item("Horario") = Constantes.ITEM_DGV_SELECCIONE_VALOR Then
                        dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_SELECCIONE
                    ElseIf dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_AH_VALOR Then
                        dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_AH
                    ElseIf dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_RN_VALOR Then
                        dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_RN
                    ElseIf dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_CA_VALOR Then
                        dt.Rows(I).Item("Horario") = Constantes.ITEM_dgv_CA
                    End If
                    If dt.Rows(I).Item("Inicio") = Constantes.ITEM_DGV_SELECCIONE_VALOR Then
                        dt.Rows(I).Item("Inicio") = Constantes.ITEM_dgv_SELECCIONE
                    End If
                Next
            Case Constantes.OM_IMPREGNACION
                For I = 0 To dt.Rows.Count - 1
                    If dt.Rows(I).Item("Inicio") = Constantes.ITEM_DGV_SELECCIONE_VALOR Then
                        dt.Rows(I).Item("Inicio") = Constantes.ITEM_dgv_SELECCIONE
                    End If
                Next
            Case Constantes.OM_INFUSION
                For I = 0 To dt.Rows.Count - 1
                    If dt.Rows(I).Item("Inicio") = Constantes.ITEM_DGV_SELECCIONE_VALOR Then
                        dt.Rows(I).Item("Inicio") = Constantes.ITEM_dgv_SELECCIONE
                    End If
                Next
        End Select
        dgv.AllowUserToResizeColumns = False
        dgv.DataSource = dt
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
    End Sub
    Public Shared Sub agregaMedicamentoAutomaticoAuditoria(objOrdenMedica As OrdenMedica, ByRef paramsDgv As DataGridView)
        Dim NombreTablaMezcla As String
        Dim dtMezcla As New DataTable
        dtMezcla.Columns.Add("Codigo")
        dtMezcla.Columns.Add("Descripcion")
        dtMezcla.Columns.Add("Unidad")
        dtMezcla.Columns.Add("Dosis")
        dtMezcla.Columns.Add("Estado")
        For I = 0 To paramsDgv.Rows.Count - 2
            NombreTablaMezcla = HistoriaClinicaBLL.nombreTabla(paramsDgv, paramsDgv.DataSource, I)
            If objOrdenMedica.dsMezcla.Tables.Contains(NombreTablaMezcla) = True Then
                For J = 0 To objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows.Count - 1
                    dtMezcla.Rows.Add()
                    dtMezcla.Rows(dtMezcla.Rows.Count - 1).Item("Codigo") = objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(J).Item("Código")
                    dtMezcla.Rows(dtMezcla.Rows.Count - 1).Item("Descripcion") = objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(J).Item("Descripción")
                    dtMezcla.Rows(dtMezcla.Rows.Count - 1).Item("Unidad") = objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(J).Item("Unidad")
                    dtMezcla.Rows(dtMezcla.Rows.Count - 1).Item("Dosis") = objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(J).Item("Dosis")
                    dtMezcla.Rows(dtMezcla.Rows.Count - 1).Item("Estado") = objOrdenMedica.dsMezcla.Tables(NombreTablaMezcla).Rows(J).Item("Estado")
                Next
            End If

        Next
        HistoriaClinicaDAL.agregaMedicamentoAutomaticoAuditoria(objOrdenMedica, dtMezcla)

    End Sub
    Public Shared Sub guardarOrdenMedica(objOrdenMedica As OrdenMedica, ByRef paramsDgv As List(Of DataGridView))
        Try
            Dim dtEstanciaNueva, dtComidaNueva, dtOxigenoNueva, dtParaclinicoNueva, dtHemoderivadoNueva,
           dtGlucometriaNueva, dtProcedimientoNueva, dtMedicamentoNueva, dtImpregnacionNueva As New DataTable

            filasEditada(objOrdenMedica.dtEstancias, dtEstanciaNueva)
            filasEditada(objOrdenMedica.dtComidas, dtComidaNueva)
            filasEditada(objOrdenMedica.dtOxigenos, dtOxigenoNueva)
            filasEditada(objOrdenMedica.dtParaclinicos, dtParaclinicoNueva)
            filasEditada(objOrdenMedica.dtHemoderivados, dtHemoderivadoNueva)
            filasEditada(objOrdenMedica.dtGlucometrias, dtGlucometriaNueva)
            filasEditada(objOrdenMedica.dtProcedimientos, dtProcedimientoNueva)
            filasEditada(objOrdenMedica.dtMedicamentos, dtMedicamentoNueva)
            filasEditada(objOrdenMedica.dtImpregnaciones, dtImpregnacionNueva)
            Dim paramsDt As New List(Of DataTable)

            paramsDt.Add(dtEstanciaNueva)
            paramsDt.Add(dtComidaNueva)
            paramsDt.Add(dtOxigenoNueva)
            paramsDt.Add(dtParaclinicoNueva)
            paramsDt.Add(dtHemoderivadoNueva)
            paramsDt.Add(dtGlucometriaNueva)
            paramsDt.Add(dtProcedimientoNueva)
            paramsDt.Add(dtMedicamentoNueva)
            paramsDt.Add(dtImpregnacionNueva)
            HistoriaClinicaDAL.guardarOrdenMedica(objOrdenMedica, paramsDgv, paramsDt)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Public Shared Sub filasEditada(dt As DataTable, ByRef dtNueva As DataTable)
        Dim filas As DataRow()
        dtNueva = dt.Clone
        filas = dt.Select("Estado = '" & Constantes.ITEM_NUEVO & "' OR Estado = '" & Constantes.ITEM_MODIFICADO & "'")
        For Each row As DataRow In filas
            dtNueva.ImportRow(row)
        Next
    End Sub

    Public Shared Sub filasNuevas(dt As DataTable, ByRef dtNueva As DataTable)
        Dim filas As DataRow()
        dtNueva = dt.Clone
        filas = dt.Select("Estado = '" & Constantes.ITEM_NUEVO & "' ")
        For Each row As DataRow In filas
            dtNueva.ImportRow(row)
        Next
    End Sub

    Public Shared Sub guardar_evolucion(ByRef pEvolucionMedica As EvolucionMedica)

        If String.IsNullOrEmpty(pEvolucionMedica.codigoEvolucion) Then
            HistoriaClinicaDAL.guardarEvolucionMedica(pEvolucionMedica)
        Else
            HistoriaClinicaDAL.actualizarEvolucionMedica(pEvolucionMedica)
        End If

    End Sub
    Public Shared Sub guardar_evolucionR(ByRef pEvolucionMedica As EvolucionMedicaR)
        If String.IsNullOrEmpty(pEvolucionMedica.codigoEvolucion) Then
            HistoriaClinicaDAL.guardarEvolucionMedicaR(pEvolucionMedica)
        Else
            HistoriaClinicaDAL.actualizarEvolucionMedicaR(pEvolucionMedica)
        End If

    End Sub
    Public Shared Sub guardar_evolucionRR(ByRef pEvolucionMedica As EvolucionMedicaRR)
        If String.IsNullOrEmpty(pEvolucionMedica.codigoEvolucion) Then
            HistoriaClinicaDAL.guardarEvolucionMedicaRR(pEvolucionMedica)
        Else
            HistoriaClinicaDAL.actualizarEvolucionMedicaRR(pEvolucionMedica)
        End If

    End Sub



    Public Shared Sub guardarRemision(ByRef pRemision As Remision)

        If String.IsNullOrEmpty(pRemision.codigoRemision) Then
            HistoriaClinicaDAL.guardarRemision(pRemision)
        Else
            pRemision.editado = ConstantesHC.VALOR_EDITADO
            HistoriaClinicaDAL.actualizarRemision(pRemision)
        End If

    End Sub
    Public Shared Sub guardarRemisionR(ByRef pRemision As RemisionR)

        If String.IsNullOrEmpty(pRemision.codigoRemision) Then
            HistoriaClinicaDAL.guardarRemisionR(pRemision)
        Else
            pRemision.editado = ConstantesHC.VALOR_EDITADO
            HistoriaClinicaDAL.actualizarRemisionR(pRemision)
        End If

    End Sub

    Public Shared Sub guardarRemisionRR(ByRef pRemision As RemisionRR)

        If String.IsNullOrEmpty(pRemision.codigoRemision) Then
            HistoriaClinicaDAL.guardarRemisionRR(pRemision)
        Else
            HistoriaClinicaDAL.actualizarRemisionRR(pRemision)
        End If

    End Sub
    Public Shared Sub guardarInfoIngreso(ByRef objInfoIngreso As InfoIngresoAdulto)

        Dim dtDiagImpresionNuevo As New DataTable
        Dim filas As DataRow()

        dtDiagImpresionNuevo = objInfoIngreso.dtDiagImpresion.Clone
        filas = objInfoIngreso.dtDiagImpresion.Select("Estado = '" & Constantes.ITEM_NUEVO & "'")

        For Each row As DataRow In filas
            dtDiagImpresionNuevo.ImportRow(row)
        Next

        HistoriaClinicaDAL.guardarInfoIngreso(objInfoIngreso, dtDiagImpresionNuevo)

    End Sub
    Public Shared Sub guardarInfoIngresoR(ByRef objInfoIngreso As InfoIngresoAdultoR)

        Dim dtDiagImpresionNuevo As New DataTable
        Dim filas As DataRow()

        dtDiagImpresionNuevo = objInfoIngreso.dtDiagImpresion.Clone
        filas = objInfoIngreso.dtDiagImpresion.Select("Estado = '" & Constantes.ITEM_NUEVO & "'")

        For Each row As DataRow In filas
            dtDiagImpresionNuevo.ImportRow(row)
        Next

        HistoriaClinicaDAL.guardarInfoIngresoR(objInfoIngreso, dtDiagImpresionNuevo)

    End Sub
    Public Shared Sub guardarInfoIngresoRR(ByRef objInfoIngreso As InfoIngresoAdultoRR)

        Dim dtDiagImpresionNuevo As New DataTable
        Dim filas As DataRow()

        dtDiagImpresionNuevo = objInfoIngreso.dtDiagImpresion.Clone
        filas = objInfoIngreso.dtDiagImpresion.Select("Estado = '" & Constantes.ITEM_NUEVO & "'")

        For Each row As DataRow In filas
            dtDiagImpresionNuevo.ImportRow(row)
        Next

        HistoriaClinicaDAL.guardarInfoIngresoRR(objInfoIngreso, dtDiagImpresionNuevo)

    End Sub

    Public Shared Sub guardarInfoIngresoN(ByRef objInfoIngreso As InfoIngresoNeonato)

        Dim dtDiagImpresionNuevo As New DataTable
        Dim filas As DataRow()

        dtDiagImpresionNuevo = objInfoIngreso.dtDiagImpresion.Clone
        filas = objInfoIngreso.dtDiagImpresion.Select("Estado = '" & Constantes.ITEM_NUEVO & "'")

        For Each row As DataRow In filas
            dtDiagImpresionNuevo.ImportRow(row)
        Next

        HistoriaClinicaDAL.guardarInfoIngresoN(objInfoIngreso, dtDiagImpresionNuevo)

    End Sub
    Public Shared Sub guardarInfoIngresoNR(ByRef objInfoIngreso As InfoIngresoNeonatoR)

        Dim dtDiagImpresionNuevo As New DataTable
        Dim filas As DataRow()

        dtDiagImpresionNuevo = objInfoIngreso.dtDiagImpresion.Clone
        filas = objInfoIngreso.dtDiagImpresion.Select("Estado = '" & Constantes.ITEM_NUEVO & "'")

        For Each row As DataRow In filas
            dtDiagImpresionNuevo.ImportRow(row)
        Next

        HistoriaClinicaDAL.guardarInfoIngresoNR(objInfoIngreso, dtDiagImpresionNuevo)

    End Sub

    Public Shared Sub guardarInfoIngresoNRR(ByRef objInfoIngreso As InfoIngresoNeonatoRR)

        Dim dtDiagImpresionNuevo As New DataTable
        Dim filas As DataRow()

        dtDiagImpresionNuevo = objInfoIngreso.dtDiagImpresion.Clone
        filas = objInfoIngreso.dtDiagImpresion.Select("Estado = '" & Constantes.ITEM_NUEVO & "'")

        For Each row As DataRow In filas
            dtDiagImpresionNuevo.ImportRow(row)
        Next

        HistoriaClinicaDAL.guardarInfoIngresoNRR(objInfoIngreso, dtDiagImpresionNuevo)

    End Sub

    Public Shared Sub calcularTasaHidrica(ByRef NDTotalesAlimentacion As NumericUpDown,
                                          ByRef NDAlimentacion As NumericUpDown,
                                          ByRef TextFrecuencia As TextBox,
                                          ByRef NDTotalesMedicacion As NumericUpDown,
                                          ByRef NDMedicacion As NumericUpDown,
                                          ByRef NDTotalesOtros As NumericUpDown,
                                          ByRef NDOtros As NumericUpDown,
                                          ByRef NDTasaHidricasAlimentacion As NumericUpDown,
                                          ByRef NDPesoPacienteNutricion As Double,
                                          ByRef NDTasaHidricaMedicacion As NumericUpDown,
                                          ByRef NDTasaHidricaOtros As NumericUpDown,
                                          ByRef NDTasaHidricaTHLEV As NumericUpDown,
                                          ByRef NDTasaHidrica As NumericUpDown,
                                          ByRef NDTasaHidricaTotal As NumericUpDown,
                                          ByRef NDTasaHidricaTHT As NumericUpDown,
                                          ByRef NDVolumenTotal As NumericUpDown,
                                          ByRef NDRasarRazon As NumericUpDown,
                                          ByRef NDDuracion As NumericUpDown)

        NDTotalesAlimentacion.Value = NDAlimentacion.Value * TextFrecuencia.Text
        NDTotalesMedicacion.Value = NDMedicacion.Value
        NDTotalesOtros.Value = NDOtros.Value

        NDTasaHidricasAlimentacion.Value = If(NDPesoPacienteNutricion > 0, NDTotalesAlimentacion.Value / NDPesoPacienteNutricion, 0)
        NDTasaHidricaMedicacion.Value = If(NDTotalesMedicacion.Value > 0, NDTotalesMedicacion.Value / NDPesoPacienteNutricion, 0)
        NDTasaHidricaOtros.Value = If(NDTotalesOtros.Value > 0, NDTotalesOtros.Value / NDPesoPacienteNutricion, 0)
        NDTasaHidricaTHLEV.Value = NDTasaHidricasAlimentacion.Value + NDTasaHidricaMedicacion.Value + NDTasaHidricaOtros.Value
        NDTasaHidrica.Value = Math.Round(NDTasaHidricaTotal.Value - NDTasaHidricaTHLEV.Value, 1)
        NDTasaHidricaTHT.Value = NDTasaHidricasAlimentacion.Value + NDTasaHidricaMedicacion.Value + NDTasaHidricaOtros.Value + NDTasaHidrica.Value
        NDVolumenTotal.Value = Math.Round(NDPesoPacienteNutricion * NDTasaHidrica.Value, 1)
        NDRasarRazon.Value = Math.Round(NDVolumenTotal.Value / NDDuracion.Value, 1)
    End Sub
    Public Shared Sub calcularProcentajeGlucosa(ByRef NDPesoPacienteNutricion As Double,
                                                ByRef NDPorcentajeGlucosa As NumericUpDown,
                                                ByVal tabla As DataTable)
        If NDPesoPacienteNutricion = 0 Then
            NDPorcentajeGlucosa.Value = 0
        Else
            Dim dextrosa1, dextrosa2 As Double
            If Not IsDBNull(tabla.Compute("Sum(Volumenes)", "codigo_interno='4'")) Then
                dextrosa1 = tabla.Compute("Sum(Volumenes)", "codigo_interno='4'")
            Else
                dextrosa1 = 0
            End If
            If Not IsDBNull(tabla.Compute("Sum(Volumenes)", "codigo_interno='746'")) Then
                dextrosa2 = tabla.Compute("Sum(Volumenes)", "codigo_interno='746'")
            Else
                dextrosa2 = 0
            End If

            NDPorcentajeGlucosa.Value = (((dextrosa1 * 0.1) + (dextrosa2 * 0.5)) / NDPesoPacienteNutricion)
            dextrosa1 = Nothing : dextrosa2 = Nothing
        End If
    End Sub
    Public Shared Sub calcularOsmolalidadTotal(ByRef tabala As DataTable,
                                               ByRef NDOsmolaridad As NumericUpDown)
        NDOsmolaridad.Value = 0
        For j = 0 To tabala.Rows.Count - 1
            NDOsmolaridad.Value += tabala.Rows(j).Item("Volumenes") * tabala.Rows(j).Item("Osmolalidad")
        Next
    End Sub
    Public Shared Sub calcularKilosCalorias(ByRef NDPesoPacienteNutricion As Double,
                                            ByRef textcaloriasporkilo As TextBox,
                                            ByRef NDTotalesKCALAportados As NumericUpDown)
        If NDPesoPacienteNutricion > 0 Then
            textcaloriasporkilo.Text = CDbl(NDTotalesKCALAportados.Value) / CDbl(NDPesoPacienteNutricion)
        End If
    End Sub
    Public Shared Sub calcularVolumenes(ByRef tabla As DataTable,
                                        ByRef NDPesoPacienteNutricion As Double,
                                        ByRef NDVolumenTotal As NumericUpDown,
                                        ByRef NDAguaDestilada As NumericUpDown)
        For h = 0 To tabla.Rows.Count - 1
            Select Case CInt(tabla.Rows(h).Item("Formula"))
                Case 1
                    tabla.Rows(h).Item("Volumenes") = Format((NDPesoPacienteNutricion * CDbl(tabla.Rows(h).Item("Requerimiento")) * 144) / CInt(tabla.Rows(h).Item("Divisor")), "##.0")
                Case 2
                    tabla.Rows(h).Item("Volumenes") = Format((NDPesoPacienteNutricion * CDbl(tabla.Rows(h).Item("Requerimiento"))) / CInt(tabla.Rows(h).Item("Divisor")), "##.0")
                Case 3
                    tabla.Rows(h).Item("Volumenes") = Format(NDPesoPacienteNutricion * CDbl(tabla.Rows(h).Item("Requerimiento")) * CInt(tabla.Rows(h).Item("Divisor")), "##.0")
            End Select
        Next
        NDAguaDestilada.Value = Math.Round(NDVolumenTotal.Value - tabla.Compute("Sum(Volumenes)", ""), 1)
    End Sub
    Public Shared Sub calcularAporteEnergeticoDetallado(ByRef NDCarbohidratosKCALAportados As NumericUpDown,
                                                        ByRef NDAminoacidosKCALAportados As NumericUpDown,
                                                        ByRef NDLipidosKCALAportados As NumericUpDown,
                                                        ByRef NDTotalesKCALAportados As NumericUpDown,
                                                        ByRef NDPorcentajeAporte As NumericUpDown,
                                                        ByRef NDAminoacidosPorcentajeAporte As NumericUpDown,
                                                        ByRef NDLipidosPorcentajeAporte As NumericUpDown,
                                                        ByRef NDTotalesPorcentajeAporte As NumericUpDown,
                                                        ByRef NDTotalesGrNitrogeno As NumericUpDown,
                                                        ByRef NDAminoacidosGramos As NumericUpDown,
                                                        ByRef NDKCALNP As NumericUpDown,
                                                        ByRef NDKCALNPN2 As NumericUpDown,
                                                        ByRef NDKCALNPP As NumericUpDown,
                                                        ByRef NDCarbohidratosGramos As NumericUpDown,
                                                        ByRef NDLipidosGramos As NumericUpDown)

        NDCarbohidratosKCALAportados.Value = ConstantesHC.CARBOHIDRATOS_APORTADOS * NDCarbohidratosGramos.Value
        NDAminoacidosKCALAportados.Value = ConstantesHC.AMINOACIDOS_APORTADOS * NDAminoacidosGramos.Value
        NDLipidosKCALAportados.Value = ConstantesHC.LIPIDOS_APORTADOS * NDLipidosGramos.Value
        NDTotalesKCALAportados.Value = NDCarbohidratosKCALAportados.Value + NDAminoacidosKCALAportados.Value + NDLipidosKCALAportados.Value

        NDPorcentajeAporte.Value = If(NDTotalesKCALAportados.Value = 0, 0, (NDCarbohidratosKCALAportados.Value * 100) / NDTotalesKCALAportados.Value)
        NDAminoacidosPorcentajeAporte.Value = If(NDTotalesKCALAportados.Value = 0, 0, (NDAminoacidosKCALAportados.Value * 100) / NDTotalesKCALAportados.Value)
        NDLipidosPorcentajeAporte.Value = If(NDTotalesKCALAportados.Value = 0, 0, (NDLipidosKCALAportados.Value * 100) / NDTotalesKCALAportados.Value)

        NDTotalesPorcentajeAporte.Value = NDPorcentajeAporte.Value + NDAminoacidosPorcentajeAporte.Value + NDLipidosPorcentajeAporte.Value


        NDTotalesGrNitrogeno.Value = NDAminoacidosGramos.Value / ConstantesHC.TOTALES_GRAMOS_NITROGENO
        NDKCALNP.Value = NDCarbohidratosKCALAportados.Value + NDLipidosKCALAportados.Value
        NDKCALNPN2.Value = If(NDTotalesGrNitrogeno.Value = 0, 0, NDKCALNP.Value / NDTotalesGrNitrogeno.Value)
        NDKCALNPP.Value = If(NDAminoacidosKCALAportados.Value = 0, 0, NDKCALNP.Value / NDAminoacidosKCALAportados.Value)
    End Sub
    Public Shared Sub enlazarNutricion(ByRef dgvNutricion As DataGridView,
                                       ByVal tabla As DataTable)
        If dgvNutricion.DataSource Is Nothing Then
            With dgvNutricion
                .Columns("Descripcion").DataPropertyName = "Descripcion"
                .Columns("Requerimientos").DataPropertyName = "Requerimiento"
                .Columns("Volumenes").DataPropertyName = "Volumenes"
                .AutoGenerateColumns = False
                .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If
        dgvNutricion.DataSource = tabla
    End Sub

    Public Shared Function calcularAporteEnergetico(ByRef obj As HistoriaClinica) As Double()
        Dim vectorResultados(3) As Double

        Dim gramos, lipidos, aminoacidos As Double
        For i = 0 To obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows.Count - 1
            If obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows(i).Item("tipo").ToString = ConstantesHC.CONSULTA_TIPO_C And obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows(i).Item("Requerimiento") <> 0 Then
                gramos += obj.objOrdenMedica.objetoNutricion.calcularGramos(i)
            ElseIf obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows(i).Item("tipo").ToString = ConstantesHC.CONSULTA_TIPO_A And obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows(i).Item("Requerimiento") > 0 Then
                aminoacidos += obj.objOrdenMedica.objetoNutricion.calcularAminoacidos(i)
            ElseIf obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows(i).Item("tipo").ToString = ConstantesHC.CONSULTA_TIPO_L And obj.objOrdenMedica.objetoNutricion.dtNutricion.Rows(i).Item("Requerimiento") <> 0 Then
                lipidos += obj.objOrdenMedica.objetoNutricion.calcularlipidos(i)
            End If
        Next

        vectorResultados(0) = gramos
        vectorResultados(1) = aminoacidos
        vectorResultados(2) = lipidos
        Return vectorResultados
    End Function

    Public Shared Sub algunaValidaciones(dgv As DataGridView, objGlucometria As HistoriaClinica, idColumna As Integer, pFila As Integer, fecha As DateTime)
        Dim Hora As String = Format(fecha, "HH:mm:ss")
        If dgv.RowCount > 0 Then
            If idColumna = 2 Then
                If dgv.Rows(pFila).Cells(idColumna).Value < Hora Then
                    MsgBox("Formato u hora no permitida ", MsgBoxStyle.Critical)
                    dgv.Rows(pFila).Cells(idColumna).Value = Hora
                End If
            ElseIf idColumna = 3 _
                And Not IsDBNull(dgv.Rows(pFila).Cells("dgGlicemia").Value) Then
                dgv.Rows(pFila).Cells("dgIniciales").Value = objGlucometria.objEnfermeria.objGlucomEnfer.cargarIniciales()
                dgv.Rows(pFila).Cells("dgUsuario").Value = If(IsNothing(objGlucometria.objEnfermeria.objGlucomEnfer.usuarioReal), SesionActual.idUsuario,
                                                              objGlucometria.objEnfermeria.objGlucomEnfer.usuarioReal)
            End If
        End If
    End Sub
    Public Shared Sub configurarDgvoxigeno(ByRef dgv As DataGridView,
                                           ByRef tablaOxigeno As DataTable)

        If dgv.DataSource Is Nothing Then
            With dgv
                .Columns("Fecha_Inicio").DataPropertyName = "Fecha_Inicio"
                .Columns("Fecha_Inicio").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Fecha_Fin").DataPropertyName = "Fecha_Fin"
                .Columns("Fecha_Fin").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("DescripcionOxigeno").DataPropertyName = "Descripcion"
                .Columns("DescripcionOxigeno").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Porcentaje").DataPropertyName = "Porcentaje"
                .Columns("Porcentaje").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Minutos").DataPropertyName = "Hora"
                .Columns("Minutos").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Litros").DataPropertyName = "Litro"
                .Columns("Litros").SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns("Total_dia").DataPropertyName = "Total"
                .Columns("Total_dia").SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoGenerateColumns = False
                .DataSource = tablaOxigeno
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Font = New Font(Constantes.TIPO_LETRA_ELEMENTO, 9)
            End With
        End If
    End Sub
    Public Shared Sub mostrarAdvertenciaNutricion(ByRef tablanutricion As DataTable,
                                                  ByVal indiceFila As Integer)

        Dim swt As Boolean = True
        Dim codigoEquivalnecia As Integer
        Dim Requerimineto As Double

        codigoEquivalnecia = tablanutricion.Rows(indiceFila).Item("Codigo_interno")
        Requerimineto = tablanutricion.Rows(indiceFila).Item("Requerimiento")

        Select Case codigoEquivalnecia
            Case 17
                If Requerimineto >= ConstantesHC.ALARMA_CLORURO_POTASIO Then
                    swt = False
                End If
            Case 20, 18
                If tablanutricion.Compute("Sum(Requerimiento)", "Codigo_Interno='20' or Codigo_Interno='18'") >= ConstantesHC.ALARMA_DEXTROSA Then
                    swt = False
                End If
            Case 19
                If Requerimineto >= ConstantesHC.ALARMA_CLORURO_SODIO Then
                    swt = False
                End If
            Case 21
                If Requerimineto >= ConstantesHC.ALARMA_GLUCONATO Then
                    swt = False
                End If
            Case 22
                If Requerimineto >= ConstantesHC.ALARMA_AMINOACIDO Then
                    swt = False
                End If
            Case 23
                If Requerimineto >= ConstantesHC.ALARMA_ELEMENTOS_TRAZA Then
                    swt = False
                End If
            Case 24
                If Requerimineto >= ConstantesHC.ALARMA_MICRONUTRIENTES Then
                    swt = False
                End If
            Case 25
                If Requerimineto >= ConstantesHC.ALARMA_ACIDOS_GRASOS Then
                    swt = False
                End If
            Case 26
                If Requerimineto >= ConstantesHC.ALARMA_SULFATO Then
                    swt = False
                End If
        End Select
        If swt = False Then
            If MsgBox("Esta seguro(a) de que desea ordenar " & tablanutricion.Rows(indiceFila).Item("Descripcion").ToString.ToLower & " con requerimiento de " & tablanutricion.Rows(indiceFila).Item("Requerimiento") & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SIFAHO") = MsgBoxResult.No Then
                tablanutricion.Rows(indiceFila).Item("Requerimiento") = 0
                tablanutricion.AcceptChanges()
            End If
        End If
    End Sub
    Public Shared Function isFechaMayor(ByVal fechaInicio As DateTime,
                                        ByVal fechaFin As DateTime) As Boolean

        If DateDiff(DateInterval.Minute, fechaInicio, fechaFin) <= 0 Then
            Return True
        End If
        Return False
    End Function

End Class
