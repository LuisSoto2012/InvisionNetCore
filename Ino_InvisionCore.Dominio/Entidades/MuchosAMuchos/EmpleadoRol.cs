using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class EmpleadoRol
    {
        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
