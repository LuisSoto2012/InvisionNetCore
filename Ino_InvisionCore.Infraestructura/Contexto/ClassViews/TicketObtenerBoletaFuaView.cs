using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class TicketObtenerBoletaFuaView
    {
        [Key]
        public string NroBoletaFua { get; set; }
    }
}
