using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentation.Models
{
    public class ConsultaRapidaFormData
    {
        public IList<IFormFile> Imagen { get; set; }
        public int IdPacienteGalenos { get; set; }
        public string MotivoConsulta { get; set; }
        public string NumeroReferencia { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
