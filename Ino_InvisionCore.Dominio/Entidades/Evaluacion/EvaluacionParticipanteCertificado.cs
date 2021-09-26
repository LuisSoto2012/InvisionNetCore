using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.Evaluacion
{
    public class EvaluacionParticipanteCertificado
    {
        [Key]
        public int Id { get; set; }
        public int IdParticipante { get; set; }
        public string Participante { get; set; }
        public string NumeroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Modulo { get; set; }
        public DateTime FechaCertificado { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
