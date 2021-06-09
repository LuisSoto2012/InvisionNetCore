using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones
{
    public class AuditoriaGeneral
    {
        public string Accion { get; set; }
        public string NombreTabla { get; set; }
        public string ValoresAntiguos { get; set; }
        public string ValoresNuevos { get; set; }
        public int IdUsuario { get; set; }
    }
}
