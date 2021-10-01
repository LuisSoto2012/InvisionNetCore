// ReenviarCertificadoDto.cs00:0500:05

using System.Collections.Generic;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones
{
    public class ReenviarCertificadoDto
    {
        public IList<EvalPartCertDto> participantes { get; set; }
    }
}