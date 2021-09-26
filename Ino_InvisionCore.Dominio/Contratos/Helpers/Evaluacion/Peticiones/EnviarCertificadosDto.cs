using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones
{
    public class EnviarCertificadosDto
    {
        public List<EvalParticipanteNumPregDto> Participantes { get; set; }
        public DateTime Fecha { get; set; }
        public string Modulo { get; set; }
    }
}
