using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ArchivoPorFechaYUsuarioView
    {
        [Key]
        public Int64 RowId { get; set; }
        public string Fecha { get; set; }
        public string NombreArchivo { get; set; }
        public string Usuario { get; set; }
        public int Conteo { get; set; }
        public string RutaCompleta { get; set; }
        //public string ArchivoBinario { get; set; }
        public string Ruta { get; set; }
    }
}
