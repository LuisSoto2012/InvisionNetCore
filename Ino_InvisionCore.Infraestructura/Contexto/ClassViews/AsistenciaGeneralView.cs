using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class AsistenciaGeneralView
    {
        [Key]
        public Int64 RowId { get; set; }
        public string Dni { get; set; }
        public string Participante { get; set; }
        public string NombreHorario { get; set; }
        public string FechaRegistro { get; set; }
    }
}
