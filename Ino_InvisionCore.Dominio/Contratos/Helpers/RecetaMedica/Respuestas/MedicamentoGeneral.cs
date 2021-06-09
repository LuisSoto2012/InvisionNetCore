using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas
{
    public class MedicamentoGeneral
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string ForFarm { get; set; }
        //public string UnidadMedida { get; set; }
        public int Stock { get; set; }
    }
}
