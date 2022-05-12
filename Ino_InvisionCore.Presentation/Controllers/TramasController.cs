using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Comunes;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Tramas;
using Ino_InvisionCore.Presentacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TramasController : ControllerBase
    {
        private IServicioDeTramas _servicioDeTramas;
        private IServicioDeComunes _servicioDeComunes;
        private readonly AppSettings _appSettings;

        public TramasController(IServicioDeTramas servicioDeTramas, IServicioDeComunes servicioDeComunes ,IOptions<AppSettings> appSettings)
        {
            _servicioDeTramas = servicioDeTramas;
            _servicioDeComunes = servicioDeComunes;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IEnumerable<TramaHISMINSADto> ListarTramasHISMINSA([FromQuery]FiltroTramaHISMINSA filtro)
        {
            return _servicioDeTramas.ListarTramasHISMINSA(filtro);
        }

        [HttpPost]
        public async Task<IList<TramaHISMINSANoValida>> EnviarTramasHISMINSA([FromBody]FiltroTramaHISMINSA datos)
        {
            TokenResponse tokenResponse = await ObtenerToken();
            IEnumerable<TramaHISMINSADto> listaTrama = _servicioDeTramas.ListarTramasHISMINSA(datos);
            IList<TramaHISMINSANoValida> tramasNoValidas = new List<TramaHISMINSANoValida>();
            foreach (TramaHISMINSADto trama in listaTrama)
            {
                RespuestaTrama respuestaTrama = await RegistrarTrama(tokenResponse, trama);
                if (respuestaTrama.codigo_respuesta != "0000")
                {
                    ComboBox codigoRepuesta = _servicioDeComunes.ListarRespuestaIndicadoresDesempeno(respuestaTrama.codigo_respuesta);
                    tramasNoValidas.Add(new TramaHISMINSANoValida
                    {
                        IdAtencion = trama.idatencion,
                        MensajeError = codigoRepuesta.Descripcion,
                        FormatoTrama = trama
                    });
                }
            }
            return tramasNoValidas;
        }

        [AllowAnonymous]
        private async Task<TokenResponse> ObtenerToken()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            using (HttpClient client = new HttpClient())
            {
                string urlToken = _appSettings.UrlToken;
                string username = _appSettings.UserName;
                string password = _appSettings.Password;
                string authorization = _appSettings.Authorization;

                client.BaseAddress = new Uri(urlToken);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });
                var result = await client.PostAsync("/token", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenResponse>(resultContent);
            }
        }

        [AllowAnonymous]
        private async Task<RespuestaTrama> RegistrarTrama(TokenResponse tokenResponse, TramaHISMINSADto trama)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (var client = new HttpClient())
            {
                string urlRegistro = _appSettings.UrlRegistro;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenResponse.token_type, tokenResponse.access_token);
                using (var request = new HttpRequestMessage(HttpMethod.Post, urlRegistro))
                {
                    var json = JsonConvert.SerializeObject(trama);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                        {
                            string resultContent = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<RespuestaTrama>(resultContent);
                        }
                    }
                }
            }
        }
    }
}