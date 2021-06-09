using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ServicioPorEspecialidadView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
    }
}
