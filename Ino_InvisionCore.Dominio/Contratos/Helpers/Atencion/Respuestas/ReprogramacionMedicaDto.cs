using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class ReprogramacionMedicaDto
    {
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string Servicio { get; set; }
        public int IdUsuario { get; set; }
        public string FechaReprogramacion { get; set; }
    }
}
