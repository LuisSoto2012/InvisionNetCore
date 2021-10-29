using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones
{
    public class GuardarVacDto
    {
        public int IdPersonalINO { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string Actividad { get; set; }
        public string Telefono { get; set; }
        //public string PrimeraDosisReaccionesAdversas { get; set; }
        //public string SegundaDosisReaccionesAdversas { get; set; }
        public string RA1D_Pulso { get; set; }
        public string RA1D_PresionArterial { get; set; }
        public string RA1D_Saturacion { get; set; }
        public string RA1D_Diagnosticos { get; set; }
        public string RA1D_Observaciones { get; set; }
        public List<DxDto> RA1D_ListaDx { get; set; }

        public string RA2D_Pulso { get; set; }
        public string RA2D_PresionArterial { get; set; }
        public string RA2D_Saturacion { get; set; }
        public string RA2D_Diagnosticos { get; set; }
        public string RA2D_Observaciones { get; set; }
        public List<DxDto> RA2D_ListaDx { get; set; }
        
        public string RA3D_Pulso { get; set; }
        public string RA3D_PresionArterial { get; set; }
        public string RA3D_Saturacion { get; set; }
        public string RA3D_Diagnosticos { get; set; }
        public string RA3D_Observaciones { get; set; }
        public List<DxDto> RA3D_ListaDx { get; set; }

        public int IdDosis { get; set; }
        public int IdReaccionAdversa { get; set; }
        public int IdUsuarioRegistro { get; set; }
    }
}
