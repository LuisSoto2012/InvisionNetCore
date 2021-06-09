using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Models
{
    public class TramasNoValidas
    {
        public int IdCita { get; set; }
        public string MensajeError { get; set; }
        public FormatoTrama FormatoTrama { get; set; }
    }
}
