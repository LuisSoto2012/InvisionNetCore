using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones
{
    public class RegistroInvestigacionDto
    {
        public string NombreResponsable_RegistroInvestigacion { get; set; }
        public string CargoResponsable_RegistroInvestigacion { get; set; }
        public DateTime Fecha_RegistroInvestigacion { get; set; }
    }
}
