using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones
{
    public class ReprogramacionMedicaPorMedicoDto
    {
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdProgramacion { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public int IdUsuario { get; set; }
        public int IdProgramacionNuevo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
