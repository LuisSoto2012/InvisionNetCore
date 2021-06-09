using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class DiagnosticoView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdDiagnostico { get; set; }
        public string CodigoCIE10 { get; set; }
        public string Descripcion { get; set; }
    }
}
