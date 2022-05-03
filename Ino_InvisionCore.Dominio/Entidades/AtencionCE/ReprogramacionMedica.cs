using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public class ReprogramacionMedica
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string Servicio { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaReprogramacion { get; set; }
    }
}
