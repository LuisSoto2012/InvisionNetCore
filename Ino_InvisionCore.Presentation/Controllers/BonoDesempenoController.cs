using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.BonoDesempeno;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Comunes;
using Ino_InvisionCore.Presentacion.Filters;
using Ino_InvisionCore.Presentacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    //[Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BonoDesempenoController : ControllerBase
    {
        private IServicioDeBonoDesempeno _servicioDeBonoDesempeno;
        private IServicioDeComunes _servicioDeComunes;
        private readonly AppSettings _appSettings;

        public BonoDesempenoController(IServicioDeBonoDesempeno servicioDeBonoDesempeno, IServicioDeComunes servicioDeComunes, IOptions<AppSettings> appSettings)
        {
            _servicioDeBonoDesempeno = servicioDeBonoDesempeno;
            _servicioDeComunes = servicioDeComunes;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IList<TramasNoValidas>> EnviarTramaDiferimientoCitas([FromBody]DatosTramaBono datosTramaBono)
        {
            TokenResponse tokenResponse = await ObtenerToken();
            IEnumerable<FormatoTrama> listaDiferimientoCitas = _servicioDeBonoDesempeno.ListarDiferimientoCitas(datosTramaBono);
            IList<TramasNoValidas> tramasNoValidas = new List<TramasNoValidas>();
            foreach (FormatoTrama diferimiento in listaDiferimientoCitas)
            {
                RespuestaTrama respuestaTrama = await RegistrarTrama(tokenResponse, diferimiento);
                if (respuestaTrama.codigo_respuesta != "0000")
                {
                    ComboBox codigoRepuesta = _servicioDeComunes.ListarRespuestaIndicadoresDesempeno(respuestaTrama.codigo_respuesta);
                    tramasNoValidas.Add(new TramasNoValidas
                    {
                        IdCita = diferimiento.id_cita,
                        MensajeError = codigoRepuesta.Descripcion,
                        FormatoTrama = diferimiento
                    });
                }
            }
            return tramasNoValidas;
        }

        [HttpGet]
        public IEnumerable<TiempoEsperaAtencion> ListarTiempoEsperaAtencion([FromQuery]DatosTramaBono datosTramaBono)
        {
            return _servicioDeBonoDesempeno.ListarTiempoEsperaAtencion(datosTramaBono);
        }

        [HttpGet]
        public IEnumerable<FormatoTrama> ListarDiferimientoCitas([FromQuery]DatosTramaBono datosTramaBono)
        {
            return _servicioDeBonoDesempeno.ListarDiferimientoCitas(datosTramaBono);
        }

        [HttpGet]
        public IEnumerable<FormatoTramaConDias> ListarDiferimientoCitasConDias([FromQuery]DatosTramaBono datosTramaBono)
        {
            return _servicioDeBonoDesempeno.ListarDiferimientoCitasConDias(datosTramaBono);
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
        private async Task<RespuestaTrama> RegistrarTrama(TokenResponse tokenResponse, FormatoTrama diferimiento)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (var client = new HttpClient())
            {
                string urlRegistro = _appSettings.UrlRegistro;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenResponse.token_type, tokenResponse.access_token);
                using (var request = new HttpRequestMessage(HttpMethod.Post, urlRegistro))
                {
                    var json = JsonConvert.SerializeObject(diferimiento);
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