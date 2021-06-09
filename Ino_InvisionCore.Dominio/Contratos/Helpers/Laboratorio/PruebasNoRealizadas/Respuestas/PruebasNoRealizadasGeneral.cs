using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Repuestas
{
    public class PruebasNoRealizadasGeneral
    {
        public int IdPruebasNoRealizadas { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool Anca { get; set; }
        public bool AntiCpp { get; set; }
        public bool AntiDna { get; set; }
        public bool AntifenosFebriles { get; set; }
        public bool BartonellaIgg { get; set; }
        public bool BartonellaIggIgm { get; set; }
        public bool BkEsputo { get; set; }
        public bool Cortisol { get; set; }
        public bool ElisaToxoplasma { get; set; }
        public bool HlaB27 { get; set; }
        public bool Htlv { get; set; }
        public bool Mercaptoetanol { get; set; }
        public bool PerfilTiroideo { get; set; }
        public bool Ppd { get; set; }
        public bool Parasitologico { get; set; }
        public string Comentario { get; set; }
        public string FechaOcurrencia { get; set; }
        public bool EsActivo { get; set; }
        public string FechaCreacion { get; set; }
    }
}
