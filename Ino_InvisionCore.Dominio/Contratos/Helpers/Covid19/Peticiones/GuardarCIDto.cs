using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones
{
    public class GuardarCIDto
    {
        public int IdPersonalINO { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }

        public bool? ExpCI_P1 { get; set; }
        public bool? ExpCI_P2 { get; set; }
        public bool? ExpCI_P3 { get; set; }

        public bool? DetCV19_P1 { get; set; }
        public bool? DetCV19_P2 { get; set; }
        public bool? DetCV19_P3 { get; set; }

        public bool? DetPrevInm_P1 { get; set; }
        public bool? DetPrevInm_P2 { get; set; }
        public bool? DetPrevInm_P3 { get; set; }
        public bool? DetPrevInm_P4 { get; set; }
        public bool? DetPrevInm_P5 { get; set; }
        public bool? DetPrevInm_P6 { get; set; }
        public bool? DetPrevInm_P7 { get; set; }
        public bool? DetPrevInm_P8 { get; set; }
        public bool? DetPrevInm_P9 { get; set; }

        public string Pulso { get; set; }
        public string Saturacion { get; set; }
        public string PresionArterial { get; set; }

        public int IdUsuarioRegistro { get; set; }

        public int? IdMedico { get; set; }

        public bool EsTicket { get; set; }
    }
}
