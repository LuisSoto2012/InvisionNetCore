using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas
{
    public class TipoOrdenMedicaRangosDto
    {
        public int IdTipoOrdenMedicaRangos { get; set; }
        public int Inicial { get; set; }
        public int Final { get; set; }
        public List<string> Condicionales { get; set; }
    }
}
