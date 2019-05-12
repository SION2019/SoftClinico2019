Public Class ConstantesAm
    Public Const ADMISIONISTA = 0
    Public Const MEDICO = 37
    Public Const MEDICOES = 38
    Public Const FISIO = 24
    Public Const PARAMEDICO = 43
    Public Const PARAMEDICOENF = 7
    Public Const CONDUCTOR = 15
    Public Const CONTACTO = 12
    Public Const DIA_FESTIVO = "F"
    Public Const DIA_HABIL = "H"
    Public Const ATENDIDO = "ATENDIDO"

    Public Const FILTRO_DGVMANUALTARIFARIO = "Descripcion_Pais_origen LIKE '%'$'%' OR Descripcion_Dpto_origen LIKE '%'$'" &
                                         "%' OR  Descripcion_Municipio_origen LIKE '%'$'%' OR  Descripcion_Pais_Destino LIKE '%'$'" &
                                         "%' OR  Descripcion_Dpto_Destino LIKE '%'$'%' OR  Descripcion_Municipio_Destino LIKE '%'$'" &
                                         "%' OR  Descripcion_Institucion_Origen LIKE '%'$'% ' OR  Descripcion_Institucion_Origen LIKE '%'$'" &
                                         "%' OR  Descripcion_Institucion_Destino LIKE '%'$'%' OR  Descripcion_Procedimiento LIKE '%'$'%'"

End Class
