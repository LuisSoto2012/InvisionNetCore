using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Respuestas
{
    public class DataCIDto
    {
        public int IdCI { get; set; }
        public int IdPersonalINO { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }

        public string Pulso { get; set; }
        public string Saturacion { get; set; }
        public string PresionArterial { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string FechaRegistroCI { get; set; }
        public int IdUsuarioRegistroCI { get; set; }

        public string PrimeraDosisFecha { get; set; }
        public string PrimeraDosisHora { get; set; }
        public string SegundaDosisFecha { get; set; }
        public string SegundaDosisHora { get; set; }
        public string TerceraDosisFecha { get; set; }
        public string TerceraDosisHora { get; set; }

        public string FechaRegistroPrimeraDosis { get; set; }
        public string FechaRegistroSegundaDosis { get; set; }
        public string FechaRegistroTerceraDosis { get; set; }

        public string RA1D_Pulso { get; set; }
        public string RA1D_PresionArterial { get; set; }
        public string RA1D_Saturacion { get; set; }
        //public string RA1D_Diagnosticos { get; set; }
        public string RA1D_Observaciones { get; set; }
        public List<DxDto> RA1D_ListaDx { get; set; }

        public string RA2D_Pulso { get; set; }
        public string RA2D_PresionArterial { get; set; }
        public string RA2D_Saturacion { get; set; }
        //public string RA2D_Diagnosticos { get; set; }
        public string RA2D_Observaciones { get; set; }
        public List<DxDto> RA2D_ListaDx { get; set; }
        
        public string RA3D_Pulso { get; set; }
        public string RA3D_PresionArterial { get; set; }
        public string RA3D_Saturacion { get; set; }
        //public string RA3D_Diagnosticos { get; set; }
        public string RA3D_Observaciones { get; set; }
        public List<DxDto> RA3D_ListaDx { get; set; }

        public string FechaRegistroPrimeraDosisReaccionesAdversas { get; set; }
        public string FechaRA1 { get; set; }
        public string FechaRegistroSegundaDosisReaccionesAdversas { get; set; }
        public string FechaRA2 { get; set; }
        public string FechaRegistroTerceraDosisReaccionesAdversas { get; set; }
        public string FechaRA3 { get; set; }

        public int IdUsuarioRegistroPrimeraDosis { get; set; }
        public int IdUsuarioRegistroSegundaDosis { get; set; }
        public int IdUsuarioRegistroTerceraDosis { get; set; }
        public int IdUsuarioRegistroPrimeraDosisReaccionesAdversas { get; set; }
        public int IdUsuarioRegistroSegundaDosisReaccionesAdversas { get; set; }
        public int IdUsuarioRegistroTerceraDosisReaccionesAdversas { get; set; }

        public int IdDosis { get; set; }
        public int IdReaccionAdversa { get; set; }

        public string FechaConsentimiento { get; set; }
        public int NumeroDosis { get; set; }

        public bool AceptaCI { get; set; }

        public bool Revocatoria { get; set; }
        public bool? RevCI_P1 { get; set; }
        public bool? RevCI_P2 { get; set; }
        public bool? RevCI_P3 { get; set; }
        public string FechaRegistroRevocatoria { get; set; }
        public int? IdUsuarioRegistroRevocatoria { get; set; }

        public string Ticket { get; set; }
        public bool EsTicket { get; set; }
    }
}
