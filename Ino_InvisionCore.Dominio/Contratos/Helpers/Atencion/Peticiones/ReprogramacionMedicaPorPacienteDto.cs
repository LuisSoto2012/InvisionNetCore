// ReprogramacionMedicaPorPacienteDto.cs01:0301:03

using System;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones
{
    public class ReprogramacionMedicaPorPacienteDto
    {
        public ComboBoxMedico IdMedico { get; set; }
        public int IdProgramacion { get; set; }
        public int IdAtencion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string HInicio { get; set; }
        public string HFin { get; set; }
        public int IdCuentaAtencion { get; set; }
        public int IdUsuario { get; set; }
        public int IdNuevoServicio { get; set; }
    }
}