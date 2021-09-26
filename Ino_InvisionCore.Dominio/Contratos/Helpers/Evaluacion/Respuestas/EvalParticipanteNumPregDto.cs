using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas
{
    public class EvalParticipanteNumPregDto
    {
        public int IdParticipante { get; set; }
        public string Participante { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public int NumeroAciertos { get; set; }
    }
}
