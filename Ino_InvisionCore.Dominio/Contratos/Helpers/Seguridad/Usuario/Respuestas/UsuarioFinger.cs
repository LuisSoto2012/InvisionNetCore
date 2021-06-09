using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas
{
    public class UsuarioFinger
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FingerPath { get; set; }
        public string FacePath { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
