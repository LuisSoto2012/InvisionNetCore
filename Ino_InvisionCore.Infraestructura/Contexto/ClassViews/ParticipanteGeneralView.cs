using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ParticipanteGeneralView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdParticipante { get; set; }
        public string Participante { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Profesion { get; set; }
        public string RegionOrigen { get; set; }
    }
}
