using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeToken : IServicioDeToken
    {
        //private string SECRET_KEY = ConfigurationManager.AppSettings["LLaveSecreta"] ?? "ThisIsMySecreTT";
        private static string secretKey { get; set; }

        private readonly static IJsonSerializer serializer = new JsonNetSerializer();
        private readonly static IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        private readonly static IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        private readonly static IDateTimeProvider provider = new UtcDateTimeProvider();

        private IJwtEncoder encoder;
        private IJwtDecoder decoder;

        private IConfiguration Configuration;

        public ServicioDeToken(IConfiguration configuration)
        {
            Configuration = configuration;
            IJwtValidator validator = new JwtValidator(serializer, provider);
            this.decoder = new JwtDecoder(serializer, validator, urlEncoder);
            this.encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            secretKey = Configuration.GetValue<string>("LLaveSecreta") ?? "ThisIsMySecreTT";

        }

        public string GenerarToken(UsuarioLogin usuarioGeneral)
        {
            return encoder.Encode(usuarioGeneral, secretKey);
        }

        public UsuarioLogin RecuperarInformacionDeUsuario(string token)
        {
            return decoder.DecodeToObject<UsuarioLogin>(token, secretKey, verify: true);
        }
    }
}
