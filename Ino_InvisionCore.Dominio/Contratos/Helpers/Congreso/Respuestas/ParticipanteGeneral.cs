using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas
{
    public class ParticipanteGeneral
    {
        public int IdParticipante { get; set; }
        public string Participante { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Profesion { get; set; }
        public string RegionOrigen { get; set; }
    }
}
