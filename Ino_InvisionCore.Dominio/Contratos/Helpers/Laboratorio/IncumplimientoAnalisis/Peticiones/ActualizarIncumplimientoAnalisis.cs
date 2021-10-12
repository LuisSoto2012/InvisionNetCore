using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Peticiones
{
    public class ActualizarIncumplimientoAnalisis
    {
        public int IdIncumplimientoAnalisis { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public bool ElisaHIV { get; set; }
        public bool AnaIFI { get; set; }
        public bool FtaAbsorcion { get; set; }
        public bool ToxoplasmaIggIgm { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public bool BacterianoAntibiograma { get; set; }
        public bool Giemsa { get; set; }
        public bool Gram { get; set; }
        public bool Micotico { get; set; }
        public bool Pas { get; set; }
    }
}
