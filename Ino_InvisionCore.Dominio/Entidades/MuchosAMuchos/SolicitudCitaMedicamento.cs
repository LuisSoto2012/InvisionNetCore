using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class SolicitudCitaMedicamento
    {
        [Key]
        public int IdSolicitudMedicamento { get; set; }
        public int IdSolicitudCita { get; set; }
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string ForFarm { get; set; }
        public int Cantidad { get; set; }
        public string Ojo { get; set; }
        public string Indicacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public SolicitudCitaMedicamento()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
