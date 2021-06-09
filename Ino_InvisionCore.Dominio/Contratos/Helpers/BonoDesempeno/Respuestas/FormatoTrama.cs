using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas
{
    public class FormatoTrama
    {
        public int id_referencia { get; set; }
        public int id_cita { get; set; }
        public int tipo { get; set; }
        public object ipress { get; set; }
        public object paciente { get; set; }
        public object registro { get; set; }
    }
}
