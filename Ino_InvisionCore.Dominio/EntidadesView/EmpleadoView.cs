
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.EntidadesView
{
    public class EmpleadoView : BaseGeneral
    {
        public int IdEmpleado { get; set; } 
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public int IdCondicionTrabajo { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string CodigoPlanilla { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool LoginEstado { get; set; }
        public string LoginIp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Rol> Roles { get; set; }
        public ICollection<Rol> Modulo { get; set; }
        public ICollection<Aplicacion> Aplicaciones { get; set; }
        public CondicionTrabajo CondicionTrabajo { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
        public TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }

        public EmpleadoView()
        {
            this.Roles = new HashSet<Rol>();
            this.Aplicaciones = new HashSet<Aplicacion>();
        }
    }
}
