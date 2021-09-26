using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class EvalParticipanteNumPregView
    {
        [Key]
        public int IdParticipante { get; set; }
        public string Participante { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public int NumeroAciertos { get; set; }
    }
}
