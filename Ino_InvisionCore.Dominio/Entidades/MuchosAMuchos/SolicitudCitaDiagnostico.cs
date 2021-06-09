using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class SolicitudCitaDiagnostico
    {
        [Key]
        public int IdSolicitudDiagnostico { get; set; }
        public int IdSolicitudCita { get; set; }
        public int IdDiagnostico { get; set; }
        public string CodigoCIE10 { get; set; }
        public string Descripcion { get; set; }
        public string TipoDX { get; set; }
        public string Ojo { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public SolicitudCitaDiagnostico()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}
