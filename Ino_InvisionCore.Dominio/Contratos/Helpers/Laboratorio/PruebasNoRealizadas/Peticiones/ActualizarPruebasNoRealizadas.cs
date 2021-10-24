using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Peticiones
{
    public class ActualizarPruebasNoRealizadas
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
        public DateTime FechaOcurrencia { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public bool GramPP { get; set; }
        public bool PasPP { get; set; }
        public bool GiemsaPP { get; set; }
        public bool Kinyoun { get; set; }
        public bool BacterianoAntibiogramaPP { get; set; }
        public bool MicoticoPP { get; set; }
        public bool Amebas { get; set; }
        public bool Chlamydia { get; set; }
        public bool Pestana { get; set; }
        public string Origen { get; set; }
    }
}
