using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Peticiones
{
    public class ActualizarEquipoMalCalibrado
    {
        public int IdEquipoMalCalibrado { get; set; }
        public int TotalDeEquipos { get; set; }
        public int NumeroMes { get; set; }
        public int Inadecuados { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string Origen { get; set; }
    }
}
