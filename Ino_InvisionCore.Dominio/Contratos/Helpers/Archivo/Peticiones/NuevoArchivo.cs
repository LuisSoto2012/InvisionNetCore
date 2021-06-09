using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones
{
    public class NuevoArchivo
    {
        public string TipoArchivo { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdServicio { get; set; }
        public string HistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string Ruta { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaCompleta { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
