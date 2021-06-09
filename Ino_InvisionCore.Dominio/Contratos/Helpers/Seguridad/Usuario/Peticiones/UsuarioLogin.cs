using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones
{
    public class UsuarioLogin
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public List<RolGeneral> Roles { get; set; }
        public List<ModuloMenu> Modulo { get; set; }
        //public string ArchivoRostro { get; set; }
        public bool LoginEstado { get; set; }
    }
}
