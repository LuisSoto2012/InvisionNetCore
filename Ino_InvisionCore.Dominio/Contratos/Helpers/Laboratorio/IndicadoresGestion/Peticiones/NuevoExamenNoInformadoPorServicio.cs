using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones
{
    public class NuevoExamenNoInformadoPorServicio
    {
        public DateTime FechaOcurrencia { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int TotalPacientes { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string Origen { get; set; }
    }
}
