using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class TicketObtenerEdadPacienteView
    {
        [Key]
        [Column("EDAD_PACIENTE")]
        public int Edad { get; set; }
    }
}
