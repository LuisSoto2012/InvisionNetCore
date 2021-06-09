using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class MedicamentoView
    {
        [Key]
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string ForFarm { get; set; }
        //public string UnidadMedida { get; set; }
        public int Stock { get; set; }
    }
}
