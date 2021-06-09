using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas
{
    public class RecetaMedicaPorDocDto
    {
        public int IdRecetaMedica { get; set; }
        public string FechaCreacion { get; set; }
        public string Medico { get; set; }
    }
}
