using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.EntidadesView
{
    public class OrdenMedicaView : BaseGeneral
    {
        public int IdOrdenMedica { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Fecha { get; set; }
        public int IdTipoAnestesia { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdAtencion { get; set; }
        public string FechaRegistro { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Medico { get; set; }
        public virtual TipoOrdenMedica TipoOrdenMedica { get; set; }
        public virtual List<OrdenesMedicasCodigosView> OrdenesMedicasCodigos { get; set; }
        public string TiempoCita { get; set; }
    }
}
