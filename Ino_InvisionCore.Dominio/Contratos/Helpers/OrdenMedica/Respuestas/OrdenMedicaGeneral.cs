using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas
{
    public class OrdenMedicaGeneral
    {
        public int IdOrdenMedica { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Fecha { get; set; }
        public int IdTipoAnestesia { get; set; }
        public int IdTipoUsuario { get; set; }
        public string FechaRegistro { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Medico { get; set; }
        public virtual ComboBox TipoOrdenMedica { get; set; }
        public virtual List<OrdenesMedicasCodigosGeneral> OrdenesMedicasCodigos { get; set; }
    }
}
