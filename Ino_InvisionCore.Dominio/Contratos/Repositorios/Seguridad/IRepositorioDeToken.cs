using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad
{
    public interface IRepositorioDeToken
    {
        string GenerarToken(UsuarioLogin usuarioGeneral);
        UsuarioLogin RecuperarInformacionDeUsuario(string token);
    }
}
