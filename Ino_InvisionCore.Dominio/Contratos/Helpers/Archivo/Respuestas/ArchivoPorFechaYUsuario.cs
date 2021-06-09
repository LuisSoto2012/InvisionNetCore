using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas
{
    public class ArchivoPorFechaYUsuario
    {
        public string Fecha { get; set; }
        public string NombreArchivo { get; set; }
        public string Usuario { get; set; }
        public int Conteo { get; set; }
        public string RutaCompleta { get; set; }
        public string ArchivoBinario { get; set; }
        public string Ruta { get; set; }
    }
}
