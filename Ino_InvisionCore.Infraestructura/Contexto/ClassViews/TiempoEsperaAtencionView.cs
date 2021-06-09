using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class TiempoEsperaAtencionView
    {
        [Key]
        public Int64 RowId { get; set; }
        public string NumeroDocumento { get; set; }
        public string FuenteFinanciamiento { get; set; }
        public string FechaTicket { get; set; }
        public string FechaAtencion { get; set; }
        public string TipoPaciente { get; set; }
        public string Especialidad { get; set; }
    }
}
