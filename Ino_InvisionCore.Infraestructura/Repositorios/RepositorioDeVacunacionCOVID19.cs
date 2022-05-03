using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.COVID19;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.VacunacionCOVID19;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeVacunacionCOVID19 : IRepositorioDeVacunacionCOVID19
    {
        private readonly InoContext Context;

        public RepositorioDeVacunacionCOVID19(InoContext context)
        {
            Context = context;
        }

        public async Task<RespuestaBD> GuardarConsentimientoInformado(GuardarCIDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                ConsentimientoInformadoCOVID19 consentimiento = Mapper.Map<ConsentimientoInformadoCOVID19>(solicitud);
                Context.ConsentimientosInformadosCOVID19.Add(consentimiento);
                await Context.SaveChangesAsync();

                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado el consentimiento informado correctamente!";

            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor.";
            }

            return respuesta;
        }

        public async Task<IEnumerable<DataCIDto>> ListarConsentimientosInformadosDosis4(DateTime fechaDesde, DateTime fechaHasta, bool vacunacion)
        {
            IList<DataCIDto> list = new List<DataCIDto>();
            IList<ConsentimientoInformadoCOVID19> listCI = new List<ConsentimientoInformadoCOVID19>();

            listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.FechaRegistro >= fechaDesde && x.FechaRegistro <= fechaHasta.Add(new TimeSpan(23, 59, 59)))
                                                                       //.OrderByDescending(x => x.FechaRegistro)
                                                                       .ToListAsync();
            foreach (var e in listCI)
            {
                DataCIDto dto = new DataCIDto();
                dto.IdCI = e.IdCI;
                dto.AceptaCI = e.ExpCI_P3.HasValue ? e.ExpCI_P3.Value ? true : false : false;
                dto.IdPersonalINO = e.IdPersonalINO;
                dto.Nombre = e.Nombre;
                dto.ApellidoMaterno = e.ApellidoMaterno;
                dto.ApellidoPaterno = e.ApellidoPaterno;
                dto.NumeroDocumento = e.NumeroDocumento;
                dto.FechaNacimiento = e.FechaNacimiento.HasValue ? e.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "";
                dto.Telefono = e.Telefono;
                dto.Edad = e.FechaNacimiento.HasValue ? CalculateAge(e.FechaNacimiento.Value) : 0;
                dto.FechaRegistroCI = e.FechaRegistro.ToString("yyyy-MM-dd");
                dto.IdUsuarioRegistroCI = e.IdUsuarioRegistro;
                dto.FechaConsentimiento = e.FechaRegistro.ToString("dd/MM/yyyy HH:mm");
                dto.EsTicket = e.esTicket;
                dto.Pulso = e.Pulso;
                dto.PresionArterial = e.PresionArterial;
                dto.Saturacion = e.Saturacion;
                dto.IdDosis = 4;
                if (vacunacion)
                {
                    //Ver si tiene vacuacion

                    VacunacionCOVID19 vacCOVID19 = await Context.VacunacionesCOVID19.Where(x => x.NumeroDocumento == e.NumeroDocumento).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    if (vacCOVID19 != null)
                    {
                        //dto.PrimeraDosisReaccionesAdversas = vacCOVID19.PrimeraDosisReaccionesAdversas ?? "";
                        dto.PrimeraDosisFecha = vacCOVID19.PrimeraDosisFecha.HasValue ? vacCOVID19.PrimeraDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        dto.RA1D_Pulso = vacCOVID19.RA1D_Pulso;
                        dto.RA1D_Saturacion = vacCOVID19.RA1D_Saturacion;
                        dto.RA1D_PresionArterial = vacCOVID19.RA1D_PresionArterial;
                        //dto.RA1D_Diagnosticos = vacCOVID19.RA1D_Diagnosticos;
                        dto.RA1D_Observaciones = vacCOVID19.RA1D_Observaciones;
                        dto.RA1D_ListaDx = ParseStrToListDx(vacCOVID19.RA1D_Diagnosticos);
                        //if (!string.IsNullOrEmpty(vacCOVID19.RA1D_Observaciones))
                        //    dto.IdReaccionAdversa = 4;
                        dto.IdReaccionAdversa = vacCOVID19.FechaRegistroPrimeraDosisReaccionesAdversas.HasValue ? 4 : dto.IdReaccionAdversa;
                    }

                    dto.RevCI_P1 = e.RevCI_P1;
                    dto.RevCI_P2 = e.RevCI_P2;
                    dto.RevCI_P3 = e.RevCI_P3;
                    dto.FechaRegistroRevocatoria = e.FechaRegistroRevocatoria.HasValue ? e.FechaRegistroRevocatoria.Value.ToString("dd/MM/yyyy HH:mm") : "";
                    dto.IdUsuarioRegistroRevocatoria = e.IdUsuarioRegistroRevocatoria;
                    dto.Revocatoria = e.FechaRegistroRevocatoria.HasValue ? true : false;
                    dto.FechaRegistro = e.FechaRegistro;

                }
                list.Add(dto);
            }

            var nuevaLista = list
                                    .Where(x => x.AceptaCI)
                                    .OrderBy(x => x.FechaRegistro).GroupBy(x => x.FechaRegistro.Date)
                                        .SelectMany(g => g.Select((j, i) => new DtoCIAux { IdCI = j.IdCI, Order = i + 1 }));

            foreach (var e in list)
            {
                var nuevoE = nuevaLista.FirstOrDefault(x => x.IdCI == e.IdCI);
                if (nuevoE != null)
                {
                    e.Ticket = "V" + nuevoE.Order;
                }
            }

            return list.OrderByDescending(x => x.FechaRegistro);
        }

        public async Task<IEnumerable<DataCIDto>> ListarConsentimientosInformados(DateTime fechaDesde, DateTime fechaHasta, bool vacunacion)
        {
            IList<DataCIDto> list = new List<DataCIDto>();
            IList<ConsentimientoInformadoCOVID19> listCI = new List<ConsentimientoInformadoCOVID19>();

            listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.FechaRegistro >= fechaDesde && x.FechaRegistro <= fechaHasta.Add(new TimeSpan(23, 59, 59)))
                                                                    //.OrderByDescending(x => x.FechaRegistro)
                                                                       .ToListAsync();

            foreach (var e in listCI)
            {
                
                var nCI = await Context.ConsentimientosInformadosCOVID19.CountAsync(x => x.NumeroDocumento == e.NumeroDocumento);
                if (!vacunacion || (vacunacion && nCI > 1 && e.DetPrevInm_P9.HasValue && e.DetPrevInm_P9.Value) || (vacunacion && nCI == 1 && e.DetPrevInm_P9.HasValue &&!e.DetPrevInm_P9.Value))
                {
                    DataCIDto dto = new DataCIDto();
                    dto.IdCI = e.IdCI;
                    dto.AceptaCI = e.ExpCI_P1.HasValue ? e.ExpCI_P1.Value ? true : false : false;
                    dto.IdPersonalINO = e.IdPersonalINO;
                    dto.Nombre = e.Nombre;
                    dto.ApellidoMaterno = e.ApellidoMaterno;
                    dto.ApellidoPaterno = e.ApellidoPaterno;
                    dto.NumeroDocumento = e.NumeroDocumento;
                    dto.FechaNacimiento = e.FechaNacimiento.HasValue ? e.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "";
                    dto.Telefono = e.Telefono;
                    dto.Edad = e.FechaNacimiento.HasValue ? CalculateAge(e.FechaNacimiento.Value) : 0;
                    dto.FechaRegistroCI = e.FechaRegistro.ToString("yyyy-MM-dd");
                    dto.IdUsuarioRegistroCI = e.IdUsuarioRegistro;
                    dto.IdDosis = 2;
                    dto.IdUsuarioRegistroCI = 0;
                    dto.FechaConsentimiento = e.FechaRegistro.ToString("dd/MM/yyyy HH:mm");
                    dto.NumeroDosis = e.DetPrevInm_P9.HasValue ? (e.DetPrevInm_P9.Value ? 2 : 1) : 0;
                    dto.EsTicket = e.esTicket;
                    dto.Pulso = e.Pulso;
                    dto.PresionArterial = e.PresionArterial;
                    dto.Saturacion = e.Saturacion;

                    //Ver si tiene vacuacion

                    VacunacionCOVID19 vacCOVID19 = await Context.VacunacionesCOVID19.Where(x => x.NumeroDocumento == e.NumeroDocumento).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    if (vacCOVID19 != null)
                    {
                        dto.IdDosis = vacCOVID19.PrimeraDosisFecha.HasValue ? 1 : dto.IdDosis;
                        dto.PrimeraDosisFecha = vacCOVID19.PrimeraDosisFecha.HasValue ? vacCOVID19.PrimeraDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        //dto.PrimeraDosisReaccionesAdversas = vacCOVID19.PrimeraDosisReaccionesAdversas ?? "";
                        dto.RA1D_Pulso = vacCOVID19.RA1D_Pulso;
                        dto.RA1D_Saturacion = vacCOVID19.RA1D_Saturacion;
                        dto.RA1D_PresionArterial = vacCOVID19.RA1D_PresionArterial;
                        //dto.RA1D_Diagnosticos = vacCOVID19.RA1D_Diagnosticos;
                        dto.RA1D_Observaciones = vacCOVID19.RA1D_Observaciones;
                        dto.RA1D_ListaDx = ParseStrToListDx(vacCOVID19.RA1D_Diagnosticos);


                        dto.IdDosis = vacCOVID19.SegundaDosisFecha.HasValue ? 2 : dto.IdDosis;
                        dto.SegundaDosisFecha = vacCOVID19.SegundaDosisFecha.HasValue ? vacCOVID19.SegundaDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        //dto.SegundaDosisReaccionesAdversas = vacCOVID19.SegundaDosisReaccionesAdversas ?? "";
                        dto.RA2D_Pulso = vacCOVID19.RA2D_Pulso;
                        dto.RA2D_Saturacion = vacCOVID19.RA2D_Saturacion;
                        dto.RA2D_PresionArterial = vacCOVID19.RA2D_PresionArterial;
                        //dto.RA2D_Diagnosticos = vacCOVID19.RA2D_Diagnosticos;
                        dto.RA2D_Observaciones = vacCOVID19.RA2D_Observaciones;
                        dto.RA2D_ListaDx = ParseStrToListDx(vacCOVID19.RA2D_Diagnosticos);
                        
                        dto.IdDosis = vacCOVID19.TerceraDosisFecha.HasValue ? 3 : dto.IdDosis;
                        dto.TerceraDosisFecha = vacCOVID19.TerceraDosisFecha.HasValue ? vacCOVID19.TerceraDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        //dto.SegundaDosisReaccionesAdversas = vacCOVID19.SegundaDosisReaccionesAdversas ?? "";
                        dto.RA3D_Pulso = vacCOVID19.RA3D_Pulso;
                        dto.RA3D_Saturacion = vacCOVID19.RA3D_Saturacion;
                        dto.RA3D_PresionArterial = vacCOVID19.RA3D_PresionArterial;
                        //dto.RA3D_Diagnosticos = vacCOVID19.RA3D_Diagnosticos;
                        dto.RA3D_Observaciones = vacCOVID19.RA3D_Observaciones;
                        dto.RA3D_ListaDx = ParseStrToListDx(vacCOVID19.RA3D_Diagnosticos);

                        dto.IdReaccionAdversa = vacCOVID19.FechaRegistroPrimeraDosisReaccionesAdversas.HasValue ? 1 : dto.IdReaccionAdversa;
                        dto.IdReaccionAdversa = vacCOVID19.FechaRegistroSegundaDosisReaccionesAdversas.HasValue ? 2 : dto.IdReaccionAdversa;
                        dto.IdReaccionAdversa = vacCOVID19.FechaRegistroTerceraDosisReaccionesAdversas.HasValue ? 3 : dto.IdReaccionAdversa;

                        dto.FechaRegistroPrimeraDosisReaccionesAdversas = vacCOVID19.FechaRegistroPrimeraDosisReaccionesAdversas.HasValue ? vacCOVID19.FechaRegistroPrimeraDosisReaccionesAdversas.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        dto.FechaRegistroSegundaDosisReaccionesAdversas = vacCOVID19.FechaRegistroSegundaDosisReaccionesAdversas.HasValue ? vacCOVID19.FechaRegistroSegundaDosisReaccionesAdversas.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        dto.FechaRegistroTerceraDosisReaccionesAdversas = vacCOVID19.FechaRegistroTerceraDosisReaccionesAdversas.HasValue ? vacCOVID19.FechaRegistroTerceraDosisReaccionesAdversas.Value.ToString("dd/MM/yyyy HH:mm") : "";
                        dto.FechaRA1 = vacCOVID19.FechaRegistroPrimeraDosisReaccionesAdversas.HasValue ? vacCOVID19.FechaRegistroPrimeraDosisReaccionesAdversas.Value.ToString("yyyy-MM-dd") : "";
                        dto.FechaRA2 = vacCOVID19.FechaRegistroSegundaDosisReaccionesAdversas.HasValue ? vacCOVID19.FechaRegistroSegundaDosisReaccionesAdversas.Value.ToString("yyyy-MM-dd") : "";
                        dto.FechaRA3 = vacCOVID19.FechaRegistroTerceraDosisReaccionesAdversas.HasValue ? vacCOVID19.FechaRegistroTerceraDosisReaccionesAdversas.Value.ToString("yyyy-MM-dd") : "";

                        dto.IdUsuarioRegistroPrimeraDosis = vacCOVID19.IdUsuarioRegistroPrimeraDosis;
                        dto.IdUsuarioRegistroSegundaDosis = vacCOVID19.IdUsuarioRegistroSegundaDosis ?? 0;
                        dto.IdUsuarioRegistroTerceraDosis = vacCOVID19.IdUsuarioRegistroTerceraDosis ?? 0;
                        dto.IdUsuarioRegistroPrimeraDosisReaccionesAdversas = vacCOVID19.IdUsuarioRegistroPrimeraDosisReaccionesAdversas ?? 0;
                        dto.IdUsuarioRegistroSegundaDosisReaccionesAdversas = vacCOVID19.IdUsuarioRegistroSegundaDosisReaccionesAdversas ?? 0;
                        dto.IdUsuarioRegistroTerceraDosisReaccionesAdversas = vacCOVID19.IdUsuarioRegistroTerceraDosisReaccionesAdversas ?? 0;
                    }
                    dto.RevCI_P1 = e.RevCI_P1;
                    dto.RevCI_P2 = e.RevCI_P2;
                    dto.RevCI_P3 = e.RevCI_P3;
                    dto.FechaRegistroRevocatoria = e.FechaRegistroRevocatoria.HasValue ? e.FechaRegistroRevocatoria.Value.ToString("dd/MM/yyyy HH:mm") : "";
                    dto.IdUsuarioRegistroRevocatoria = e.IdUsuarioRegistroRevocatoria;
                    dto.Revocatoria = e.FechaRegistroRevocatoria.HasValue ? true : false;
                    dto.FechaRegistro = e.FechaRegistro;
                    list.Add(dto);
                }  
            }

            var nuevaLista = list
                                    //.Where(x => x.EsTicket)
                                    .OrderBy(x => x.FechaRegistro).GroupBy(x => x.FechaRegistro.Date)
                                        .SelectMany(g => g.Select((j, i) => new DtoCIAux { IdCI = j.IdCI, Order = i + 1 }));

            foreach (var e in list)
            {
                var nuevoE = nuevaLista.FirstOrDefault(x => x.IdCI == e.IdCI);
                if (nuevoE != null)
                {
                    e.Ticket = "V" + nuevoE.Order;
                }
            }

            return list.OrderByDescending(x => x.FechaRegistro);
        }

        private List<DxDto> ParseStrToListDx(string strDx)
        {
            List<DxDto> list = new List<DxDto>();

            if (string.IsNullOrEmpty(strDx)) return list;

            var listSplit = strDx.Split("|");
            
            foreach (var e in listSplit)
            {
                var codCIE10 = e.Split("-")[0];
                var desc = e.Split("-")[1];
                list.Add(new DxDto { Codigo = codCIE10, Descripcion = desc });
            }

            return list;
        }

        private int CalculateAge(DateTime birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }

        public async Task<ConsultaDataDto> ObtenerDatosPorDocumentoDosis4(string numeroDocumento)
        {
            ConsultaDataDto dto = new ConsultaDataDto();

            PersonalINO personalINO = await Context.PersonalDelINO.FirstOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento && x.Estado);

            if (personalINO == null)
                return null;
            else
            {
                //Verificar cuantas dosis tiene - Consentimiento informado

                var listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.NumeroDocumento == numeroDocumento)
                                          .ToListAsync();

                if (listCI.Count() > 0)
                {
                    dto.TieneCI = true;
                    return dto;
                }

                dto.IdPersonalINO = personalINO.Id;
                dto.Nombre = personalINO.Nombre;
                dto.ApellidoPaterno = personalINO.ApellidoPaterno;
                dto.ApellidoMaterno = personalINO.ApellidoMaterno;
                dto.FechaNacimiento = personalINO.FechaNacimiento.HasValue ? personalINO.FechaNacimiento.Value.ToString("yyyy-MM-dd") : "";
                dto.Telefono = personalINO.Telefono;
                dto.TieneCI = false;
            }

            return dto;
        }

        public async Task<ConsultaDataDto> ObtenerDatosPorDocumento(string numeroDocumento)
        {
            ConsultaDataDto dto = new ConsultaDataDto();

            PersonalINO personalINO = await Context.PersonalDelINO.FirstOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento && x.Estado);

            if (personalINO == null)
                return null;
            else
            {
                //Verificar cuantas dosis tiene - Consentimiento informado

                var listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.NumeroDocumento == numeroDocumento)
                                          .ToListAsync() ;

                dto.IdPersonalINO = personalINO.Id;
                dto.Nombre = personalINO.Nombre;
                dto.ApellidoPaterno = personalINO.ApellidoPaterno;
                dto.ApellidoMaterno = personalINO.ApellidoMaterno;
                dto.FechaNacimiento = personalINO.FechaNacimiento.HasValue ? personalINO.FechaNacimiento.Value.ToString("yyyy-MM-dd") : "";
                dto.Telefono = personalINO.Telefono;
                dto.NumeroDosis = listCI.Count();

                var vac = await Context.VacunacionesCOVID19.Where(x => x.NumeroDocumento == numeroDocumento).FirstOrDefaultAsync();
                if (vac != null)
                {
                    dto.FechaPrimeraDosis = vac.PrimeraDosisFecha.HasValue ? vac.PrimeraDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                    dto.FechaSegundaDosis = vac.SegundaDosisFecha.HasValue ? vac.SegundaDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                    dto.FechaTerceraDosis = vac.TerceraDosisFecha.HasValue ? vac.TerceraDosisFecha.Value.ToString("dd/MM/yyyy HH:mm") : "";
                }
            }

            return dto;
        }

        public async Task<RespuestaBD> GuardarVacunacion(GuardarVacDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                if (solicitud.IdDosis == 0)
                {
                    //Obtener primer consentimiento informado
                    var listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.NumeroDocumento == solicitud.NumeroDocumento).ToListAsync();

                    if (listCI.Count() == 0)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "La persona no cuenta con consentimiento informado para esta dosis.";
                        return respuesta;
                    }

                    //1ra Dosis
                    VacunacionCOVID19 vacunacion = Mapper.Map<VacunacionCOVID19>(solicitud);
                    vacunacion.PrimeraDosisFecha = DateTime.Now;
                    vacunacion.IdUsuarioRegistroPrimeraDosis = solicitud.IdUsuarioRegistro;
                    Context.VacunacionesCOVID19.Add(vacunacion);
                    await Context.SaveChangesAsync();

                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha registrado la 1ra dosis de vacunación correctamente!";
                    return respuesta;
                }
                else if (solicitud.IdDosis == 1 && string.IsNullOrEmpty(solicitud.RA1D_Observaciones))
                {
                    //Obtener primer consentimiento informado
                    var listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.NumeroDocumento == solicitud.NumeroDocumento).ToListAsync();

                    if (listCI.Count() < 2)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "La persona no cuenta con consentimiento informado para esta dosis.";
                        return respuesta;
                    }

                    VacunacionCOVID19 vacunacion = await Context.VacunacionesCOVID19.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento);
                    if (vacunacion != null)
                    {
                        vacunacion.SegundaDosisFecha = DateTime.Now;
                        vacunacion.SegundaDosisFecha = DateTime.Now;
                        vacunacion.IdUsuarioRegistroSegundaDosis = solicitud.IdUsuarioRegistro;
                        await Context.SaveChangesAsync();

                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la 2da dosis de vacunación correctamente!";
                        return respuesta;
                    }
                }
                else if (solicitud.IdDosis == 2 && string.IsNullOrEmpty(solicitud.RA2D_Observaciones))
                {
                    //Obtener primer consentimiento informado
                    var listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.NumeroDocumento == solicitud.NumeroDocumento).ToListAsync();

                    if (listCI.Count() > 0)
                    {
                        //VacunacionCOVID19 vacunacion = await Context.VacunacionesCOVID19.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento);
                        //3ra Dosis
                        VacunacionCOVID19 vacunacion = Mapper.Map<VacunacionCOVID19>(solicitud);
                        vacunacion.TerceraDosisFecha = DateTime.Now;
                        vacunacion.IdUsuarioRegistroTerceraDosis = solicitud.IdUsuarioRegistro;
                        Context.VacunacionesCOVID19.Add(vacunacion);
                        await Context.SaveChangesAsync();
                        await Context.SaveChangesAsync();

                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la 3da dosis de vacunación correctamente!";
                        return respuesta;
                    }
                }
                else if (solicitud.IdDosis == 4 && string.IsNullOrEmpty(solicitud.RA1D_Observaciones))
                {
                    //Obtener primer consentimiento informado
                    var listCI = await Context.ConsentimientosInformadosCOVID19.Where(x => x.NumeroDocumento == solicitud.NumeroDocumento).ToListAsync();

                    if (listCI.Count() > 0)
                    {
                        //VacunacionCOVID19 vacunacion = await Context.VacunacionesCOVID19.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento);
                        //3ra Dosis
                        VacunacionCOVID19 vacunacion = Mapper.Map<VacunacionCOVID19>(solicitud);
                        vacunacion.PrimeraDosisFecha = DateTime.Now;
                        vacunacion.IdUsuarioRegistroPrimeraDosis = solicitud.IdUsuarioRegistro;
                        Context.VacunacionesCOVID19.Add(vacunacion);
                        await Context.SaveChangesAsync();

                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la 4ta dosis de vacunación correctamente!";
                        return respuesta;
                    }
                }


                if (!string.IsNullOrEmpty(solicitud.RA1D_Observaciones) || !string.IsNullOrEmpty(solicitud.RA2D_Observaciones))
                {
                    VacunacionCOVID19 vacunacion = await Context.VacunacionesCOVID19.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento);

                    //Formateo de string lsita
                    solicitud.RA1D_Diagnosticos = "";
                    solicitud.RA2D_Diagnosticos = "";
                    solicitud.RA3D_Diagnosticos = "";

                    for (int i=0; i<solicitud.RA1D_ListaDx.Count(); i++)
                    {
                        string str = solicitud.RA1D_ListaDx.ElementAt(i).Codigo + "-" + solicitud.RA1D_ListaDx.ElementAt(i).Descripcion;
                        solicitud.RA1D_Diagnosticos += str;
                        if (i != solicitud.RA1D_ListaDx.Count() - 1)
                            solicitud.RA1D_Diagnosticos += "|";
                    }

                    for (int i = 0; i < solicitud.RA2D_ListaDx.Count(); i++)
                    {
                        string str = solicitud.RA2D_ListaDx.ElementAt(i).Codigo + "-" + solicitud.RA2D_ListaDx.ElementAt(i).Descripcion;
                        solicitud.RA2D_Diagnosticos += str;
                        if (i != solicitud.RA2D_ListaDx.Count() - 1)
                            solicitud.RA2D_Diagnosticos += "|";
                    }
                    
                    for (int i = 0; i < solicitud.RA3D_ListaDx.Count(); i++)
                    {
                        string str = solicitud.RA3D_ListaDx.ElementAt(i).Codigo + "-" + solicitud.RA3D_ListaDx.ElementAt(i).Descripcion;
                        solicitud.RA3D_Diagnosticos += str;
                        if (i != solicitud.RA3D_ListaDx.Count() - 1)
                            solicitud.RA3D_Diagnosticos += "|";
                    }

                    if (vacunacion != null)
                    {
                        //vacunacion.RA1D_Diagnosticos = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1)  || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? solicitud.RA1D_Diagnosticos : vacunacion.RA1D_Diagnosticos;
                        //vacunacion.RA1D_Observaciones = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? solicitud.RA1D_Observaciones : vacunacion.RA1D_Observaciones;
                        //vacunacion.RA1D_PresionArterial = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? solicitud.RA1D_PresionArterial : vacunacion.RA1D_PresionArterial;
                        //vacunacion.RA1D_Pulso = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? solicitud.RA1D_Pulso : vacunacion.RA1D_Pulso;
                        //vacunacion.RA1D_Saturacion = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? solicitud.RA1D_Saturacion : vacunacion.RA1D_Saturacion;
                        //vacunacion.FechaRegistroPrimeraDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? DateTime.Now : vacunacion.FechaRegistroPrimeraDosisReaccionesAdversas;
                        //vacunacion.IdUsuarioRegistroPrimeraDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 1) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 1) ? solicitud.IdUsuarioRegistro : vacunacion.IdUsuarioRegistroPrimeraDosisReaccionesAdversas;

                        //vacunacion.RA2D_Diagnosticos = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? solicitud.RA2D_Diagnosticos : vacunacion.RA2D_Diagnosticos;
                        //vacunacion.RA2D_Observaciones = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? solicitud.RA2D_Observaciones : vacunacion.RA2D_Observaciones;
                        //vacunacion.RA2D_PresionArterial = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? solicitud.RA2D_PresionArterial : vacunacion.RA2D_PresionArterial;
                        //vacunacion.RA2D_Pulso = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? solicitud.RA2D_Pulso : vacunacion.RA2D_Pulso;
                        //vacunacion.RA2D_Saturacion = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? solicitud.RA2D_Saturacion : vacunacion.RA2D_Saturacion;
                        //vacunacion.FechaRegistroSegundaDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? DateTime.Now : vacunacion.FechaRegistroSegundaDosisReaccionesAdversas;
                        //vacunacion.IdUsuarioRegistroSegundaDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 2) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 2) ? solicitud.IdUsuarioRegistro : vacunacion.IdUsuarioRegistroSegundaDosisReaccionesAdversas;

                        //vacunacion.RA3D_Diagnosticos = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? solicitud.RA3D_Diagnosticos : vacunacion.RA3D_Diagnosticos;
                        //vacunacion.RA3D_Observaciones = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? solicitud.RA3D_Observaciones : vacunacion.RA3D_Observaciones;
                        //vacunacion.RA3D_PresionArterial = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? solicitud.RA3D_PresionArterial : vacunacion.RA3D_PresionArterial;
                        //vacunacion.RA3D_Pulso = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? solicitud.RA3D_Pulso : vacunacion.RA3D_Pulso;
                        //vacunacion.RA3D_Saturacion = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? solicitud.RA3D_Saturacion : vacunacion.RA3D_Saturacion;
                        //vacunacion.FechaRegistroTerceraDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? DateTime.Now : vacunacion.FechaRegistroTerceraDosisReaccionesAdversas;
                        //vacunacion.IdUsuarioRegistroTerceraDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 1 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 2 && solicitud.IdDosis == 3) || (solicitud.IdReaccionAdversa == 3 && solicitud.IdDosis == 3) ? solicitud.IdUsuarioRegistro : vacunacion.IdUsuarioRegistroTerceraDosisReaccionesAdversas;

                        vacunacion.RA1D_Diagnosticos = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4) ? solicitud.RA1D_Diagnosticos : vacunacion.RA1D_Diagnosticos;
                        vacunacion.RA1D_Observaciones = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4) ? solicitud.RA1D_Observaciones : vacunacion.RA1D_Observaciones;
                        vacunacion.RA1D_PresionArterial = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4)? solicitud.RA1D_PresionArterial : vacunacion.RA1D_PresionArterial;
                        vacunacion.RA1D_Pulso = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4) ? solicitud.RA1D_Pulso : vacunacion.RA1D_Pulso;
                        vacunacion.RA1D_Saturacion = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4) ? solicitud.RA1D_Saturacion : vacunacion.RA1D_Saturacion;
                        vacunacion.FechaRegistroPrimeraDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4) ? DateTime.Now : vacunacion.FechaRegistroPrimeraDosisReaccionesAdversas;
                        vacunacion.IdUsuarioRegistroPrimeraDosisReaccionesAdversas = (solicitud.IdReaccionAdversa == 0 && solicitud.IdDosis == 4)  ? solicitud.IdUsuarioRegistro : vacunacion.IdUsuarioRegistroPrimeraDosisReaccionesAdversas;

                        await Context.SaveChangesAsync();

                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la reacción adversa correctamente!";
                        return respuesta;
                    }
                }
                

            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> GuardarRevocatoria(GuardarRevocatoriaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                ConsentimientoInformadoCOVID19 consentimiento = await Context.ConsentimientosInformadosCOVID19.FirstOrDefaultAsync(x => x.IdCI == solicitud.IdCI);

                if (consentimiento == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado el consentimiento en la base de datos.";
                    return respuesta;
                }
                else
                {
                    consentimiento.RevCI_P1 = solicitud.RevCI_P1;
                    consentimiento.RevCI_P2 = solicitud.RevCI_P2;
                    consentimiento.RevCI_P3 = solicitud.RevCI_P3;
                    consentimiento.FechaRegistroRevocatoria = DateTime.Now;
                    consentimiento.IdUsuarioRegistroRevocatoria = solicitud.IdUsuarioRegistro;

                    await Context.SaveChangesAsync();

                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha registrado la revocatoria del consentimiento correctamente!";
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }
    }
}

