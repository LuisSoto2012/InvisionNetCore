using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class AplicacionEmpleado
    {
        public int IdAplicacion { get; set; }
        public Aplicacion Aplicacion { get; set; }

        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }
    }
}
