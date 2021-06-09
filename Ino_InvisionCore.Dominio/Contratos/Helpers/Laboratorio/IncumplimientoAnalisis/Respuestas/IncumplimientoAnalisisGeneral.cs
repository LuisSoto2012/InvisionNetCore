using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Repuestas
{
    public class IncumplimientoAnalisisGeneral
    {
        public int IdIncumplimientoAnalisis { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool ElisaHIV { get; set; }
        public bool AnaIFI { get; set; }
        public bool FtaAbsorcion { get; set; }
        public bool ToxoplasmaIggIgm { get; set; }
        public string FechaOcurrencia { get; set; }
        public bool EsActivo { get; set; }
        public string FechaCreacion { get; set; }
    }
}
