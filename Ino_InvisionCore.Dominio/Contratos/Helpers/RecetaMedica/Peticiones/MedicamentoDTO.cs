using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones
{
    public class MedicamentoDTO
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string ForFarm { get; set; }
        //public string UnidadMedida { get; set; } = "";
        public int Cantidad { get; set; }
        public string Ojo { get; set; }
        public string Indicacion { get; set; }
        public string Via { get; set; }
        public int IdRecetaMedica { get; set; }
    }
}
