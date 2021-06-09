using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentation.Models
{
    public class FileFormData
    {
        public IList<IFormFile> Imagen { get; set; }
        public string TipoArchivo { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdServicio { get; set; }
        public string HistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
