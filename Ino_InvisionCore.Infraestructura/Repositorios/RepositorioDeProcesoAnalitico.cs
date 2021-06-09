using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeProcesoAnalitico : IRepositorioDeProcesoAnalitico
    {
        private readonly InoContext Context;

        public RepositorioDeProcesoAnalitico(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD AgregarCalibracionDeficiente(NuevoCalibracionDeficiente nuevoCalibracionDeficiente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            CalibracionDeficiente calibracionDeficiente = Mapper.Map<CalibracionDeficiente>(nuevoCalibracionDeficiente);
            Context.CalibracionDeficiente.Add(calibracionDeficiente);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = calibracionDeficiente.IdCalibracionDeficiente;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarCalibracionDeficienteAsync(NuevoCalibracionDeficiente nuevoCalibracionDeficiente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            CalibracionDeficiente calibracionDeficiente = Mapper.Map<CalibracionDeficiente>(nuevoCalibracionDeficiente);
            await Context.CalibracionDeficiente.AddAsync(calibracionDeficiente);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = calibracionDeficiente.IdCalibracionDeficiente;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD AgregarEmpleoReactivo(NuevoEmpleoReactivo nuevoEmpleoReactivo)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EmpleoReactivo empleoReactivo = Mapper.Map<EmpleoReactivo>(nuevoEmpleoReactivo);
            Context.EmpleoReactivo.Add(empleoReactivo);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = empleoReactivo.IdEmpleoReactivo;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarEmpleoReactivoAsync(NuevoEmpleoReactivo nuevoEmpleoReactivo)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EmpleoReactivo empleoReactivo = Mapper.Map<EmpleoReactivo>(nuevoEmpleoReactivo);
            await Context.EmpleoReactivo.AddAsync(empleoReactivo);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = empleoReactivo.IdEmpleoReactivo;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD AgregarEquipoMalCalibrado(NuevoEquipoMalCalibrado nuevoEquipoMalCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoMalCalibrado equipoMalCalibrado = Mapper.Map<EquipoMalCalibrado>(nuevoEquipoMalCalibrado);
            Context.EquipoMalCalibrado.Add(equipoMalCalibrado);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = equipoMalCalibrado.IdEquipoMalCalibrado;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarEquipoMalCalibradoAsync(NuevoEquipoMalCalibrado nuevoEquipoMalCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoMalCalibrado equipoMalCalibrado = Mapper.Map<EquipoMalCalibrado>(nuevoEquipoMalCalibrado);
            await Context.EquipoMalCalibrado.AddAsync(equipoMalCalibrado);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = equipoMalCalibrado.IdEquipoMalCalibrado;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD AgregarEquipoUPS(NuevoEquipoUPS nuevoEquipoUPS)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoUPS equipoUPS = Mapper.Map<EquipoUPS>(nuevoEquipoUPS);
            Context.EquipoUPS.Add(equipoUPS);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = equipoUPS.IdEquipoUPS;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarEquipoUPSAsync(NuevoEquipoUPS nuevoEquipoUPS)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoUPS equipoUPS = Mapper.Map<EquipoUPS>(nuevoEquipoUPS);
            await Context.EquipoUPS.AddAsync(equipoUPS);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = equipoUPS.IdEquipoUPS;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD AgregarMaterialNoCalibrado(NuevoMaterialNoCalibrado nuevoMaterialNoCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MaterialNoCalibrado materialNoCalibrado = Mapper.Map<MaterialNoCalibrado>(nuevoMaterialNoCalibrado);
            Context.MaterialNoCalibrado.Add(materialNoCalibrado);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = materialNoCalibrado.IdMaterialNoCalibrado;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarMaterialNoCalibradoAsync(NuevoMaterialNoCalibrado nuevoMaterialNoCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MaterialNoCalibrado materialNoCalibrado = Mapper.Map<MaterialNoCalibrado>(nuevoMaterialNoCalibrado);
            await Context.MaterialNoCalibrado.AddAsync(materialNoCalibrado);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = materialNoCalibrado.IdMaterialNoCalibrado;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD AgregarMuestraHemolizadaLipemica(NuevoMuestraHemolizadaLipemica nuevoMuestraHemolizadaLipemica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MuestraHemolizadaLipemica pacienteEncontrado = Context.MuestraHemolizadaLipemica.Where(x => x.HistoriaClinica == nuevoMuestraHemolizadaLipemica.HistoriaClinica && x.NumeroMes == nuevoMuestraHemolizadaLipemica.NumeroMes).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                MuestraHemolizadaLipemica muestraHemolizadaLipemica = Mapper.Map<MuestraHemolizadaLipemica>(nuevoMuestraHemolizadaLipemica);
                Context.MuestraHemolizadaLipemica.Add(muestraHemolizadaLipemica);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = muestraHemolizadaLipemica.IdMuestraHemolizadaLipemica;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarMuestraHemolizadaLipemicaAsync(NuevoMuestraHemolizadaLipemica nuevoMuestraHemolizadaLipemica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MuestraHemolizadaLipemica pacienteEncontrado = await Context.MuestraHemolizadaLipemica
                                                                        .Where(x => x.HistoriaClinica == nuevoMuestraHemolizadaLipemica.HistoriaClinica && x.NumeroMes == nuevoMuestraHemolizadaLipemica.NumeroMes)
                                                                        .FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                MuestraHemolizadaLipemica muestraHemolizadaLipemica = Mapper.Map<MuestraHemolizadaLipemica>(nuevoMuestraHemolizadaLipemica);
                await Context.MuestraHemolizadaLipemica.AddAsync(muestraHemolizadaLipemica);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = muestraHemolizadaLipemica.IdMuestraHemolizadaLipemica;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
            }

            return respuesta;
        }

        public RespuestaBD AgregarPocoFrecuente(NuevoPocoFrecuente nuevoPocoFrecuente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PocoFrecuente pocoFrecuente = Mapper.Map<PocoFrecuente>(nuevoPocoFrecuente);
            Context.PocoFrecuente.Add(pocoFrecuente);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = pocoFrecuente.IdPocoFrecuente;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarPocoFrecuenteAsync(NuevoPocoFrecuente nuevoPocoFrecuente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PocoFrecuente pocoFrecuente = Mapper.Map<PocoFrecuente>(nuevoPocoFrecuente);
            await Context.PocoFrecuente.AddAsync(pocoFrecuente);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = pocoFrecuente.IdPocoFrecuente;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD AgregarSueroMalReferenciado(NuevoSueroMalReferenciado nuevoSueroMalReferenciado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SueroMalReferenciado sueroMalReferenciado = Mapper.Map<SueroMalReferenciado>(nuevoSueroMalReferenciado);
            Context.SueroMalReferenciado.Add(sueroMalReferenciado);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = sueroMalReferenciado.IdSueroMalReferenciado;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarSueroMalReferenciadoAsync(NuevoSueroMalReferenciado nuevoSueroMalReferenciado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SueroMalReferenciado sueroMalReferenciado = Mapper.Map<SueroMalReferenciado>(nuevoSueroMalReferenciado);
            await Context.SueroMalReferenciado.AddAsync(sueroMalReferenciado);
            await Context.SaveChangesAsync();

            //Mensaje de respuesta
            respuesta.Id = sueroMalReferenciado.IdSueroMalReferenciado;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD EditarCalibracionDeficiente(ActualizarCalibracionDeficiente actualizarCalibracionDeficiente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            CalibracionDeficiente calibracionDeficiente = Context.CalibracionDeficiente.Where(x => x.IdCalibracionDeficiente == actualizarCalibracionDeficiente.IdCalibracionDeficiente).FirstOrDefault();
            if (calibracionDeficiente != null)
            {
                Context.Entry(calibracionDeficiente).CurrentValues.SetValues(actualizarCalibracionDeficiente);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = calibracionDeficiente.IdCalibracionDeficiente;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarCalibracionDeficienteAsync(ActualizarCalibracionDeficiente actualizarCalibracionDeficiente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            CalibracionDeficiente calibracionDeficiente = await Context.CalibracionDeficiente
                                                                    .Where(x => x.IdCalibracionDeficiente == actualizarCalibracionDeficiente.IdCalibracionDeficiente)
                                                                    .FirstOrDefaultAsync();
            if (calibracionDeficiente != null)
            {
                Context.Entry(calibracionDeficiente).CurrentValues.SetValues(actualizarCalibracionDeficiente);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = calibracionDeficiente.IdCalibracionDeficiente;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarEmpleoReactivo(ActualizarEmpleoReactivo actualizarEmpleoReactivo)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EmpleoReactivo empleoReactivo = Context.EmpleoReactivo.Where(x => x.IdEmpleoReactivo == actualizarEmpleoReactivo.IdEmpleoReactivo).FirstOrDefault();
            if (empleoReactivo != null)
            {
                Context.Entry(empleoReactivo).CurrentValues.SetValues(actualizarEmpleoReactivo);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = empleoReactivo.IdEmpleoReactivo;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarEmpleoReactivoAsync(ActualizarEmpleoReactivo actualizarEmpleoReactivo)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EmpleoReactivo empleoReactivo = await Context.EmpleoReactivo
                                                    .Where(x=> x.IdEmpleoReactivo == actualizarEmpleoReactivo.IdEmpleoReactivo)
                                                    .FirstOrDefaultAsync();
            if (empleoReactivo != null)
            {
                Context.Entry(empleoReactivo).CurrentValues.SetValues(actualizarEmpleoReactivo);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = empleoReactivo.IdEmpleoReactivo;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarEquipoMalCalibrado(ActualizarEquipoMalCalibrado actualizarEquipoMalCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoMalCalibrado equipoMalCalibrado = Context.EquipoMalCalibrado.Where(x => x.IdEquipoMalCalibrado == actualizarEquipoMalCalibrado.IdEquipoMalCalibrado).FirstOrDefault();
            if (equipoMalCalibrado != null)
            {
                Context.Entry(equipoMalCalibrado).CurrentValues.SetValues(actualizarEquipoMalCalibrado);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = equipoMalCalibrado.IdEquipoMalCalibrado;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarEquipoMalCalibradoAsync(ActualizarEquipoMalCalibrado actualizarEquipoMalCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoMalCalibrado equipoMalCalibrado = await Context.EquipoMalCalibrado
                                                                .Where(x => x.IdEquipoMalCalibrado == actualizarEquipoMalCalibrado.IdEquipoMalCalibrado)
                                                                .FirstOrDefaultAsync();
            if (equipoMalCalibrado != null)
            {
                Context.Entry(equipoMalCalibrado).CurrentValues.SetValues(actualizarEquipoMalCalibrado);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = equipoMalCalibrado.IdEquipoMalCalibrado;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarEquipoUPS(ActualizarEquipoUPS actualizarEquipoUPS)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoUPS equipoUPS = Context.EquipoUPS.Where(x => x.IdEquipoUPS == actualizarEquipoUPS.IdEquipoUPS).FirstOrDefault();
            if (equipoUPS != null)
            {
                Context.Entry(equipoUPS).CurrentValues.SetValues(actualizarEquipoUPS);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = equipoUPS.IdEquipoUPS;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarEquipoUPSAsync(ActualizarEquipoUPS actualizarEquipoUPS)
        {
            RespuestaBD respuesta = new RespuestaBD();

            EquipoUPS equipoUPS = await Context.EquipoUPS
                                                    .Where(x => x.IdEquipoUPS == actualizarEquipoUPS.IdEquipoUPS)
                                                    .FirstOrDefaultAsync();
            if (equipoUPS != null)
            {
                Context.Entry(equipoUPS).CurrentValues.SetValues(actualizarEquipoUPS);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = equipoUPS.IdEquipoUPS;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarMaterialNoCalibrado(ActualizarMaterialNoCalibrado actualizarMaterialNoCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MaterialNoCalibrado materialNoCalibrado = Context.MaterialNoCalibrado.Where(x => x.IdMaterialNoCalibrado == actualizarMaterialNoCalibrado.IdMaterialNoCalibrado).FirstOrDefault();
            if (materialNoCalibrado != null)
            {
                Context.Entry(materialNoCalibrado).CurrentValues.SetValues(actualizarMaterialNoCalibrado);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = materialNoCalibrado.IdMaterialNoCalibrado;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarMaterialNoCalibradoAsync(ActualizarMaterialNoCalibrado actualizarMaterialNoCalibrado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MaterialNoCalibrado materialNoCalibrado = await Context.MaterialNoCalibrado
                                                                .Where(x => x.IdMaterialNoCalibrado == actualizarMaterialNoCalibrado.IdMaterialNoCalibrado)
                                                                .FirstOrDefaultAsync();
            if (materialNoCalibrado != null)
            {
                Context.Entry(materialNoCalibrado).CurrentValues.SetValues(actualizarMaterialNoCalibrado);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = materialNoCalibrado.IdMaterialNoCalibrado;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarMuestraHemolizadaLipemica(ActualizarMuestraHemolizadaLipemica actualizarMuestraHemolizadaLipemica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MuestraHemolizadaLipemica muestraHemolizadaLipemica = Context.MuestraHemolizadaLipemica.Where(x => x.IdMuestraHemolizadaLipemica == actualizarMuestraHemolizadaLipemica.IdMuestraHemolizadaLipemica).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(muestraHemolizadaLipemica);
            if (muestraHemolizadaLipemica != null)
            {
                MuestraHemolizadaLipemica pacienteEncontrado = Context.MuestraHemolizadaLipemica.Where(x => x.HistoriaClinica == actualizarMuestraHemolizadaLipemica.HistoriaClinica && x.NumeroMes == actualizarMuestraHemolizadaLipemica.NumeroMes && x.IdMuestraHemolizadaLipemica != actualizarMuestraHemolizadaLipemica.IdMuestraHemolizadaLipemica).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(muestraHemolizadaLipemica).CurrentValues.SetValues(actualizarMuestraHemolizadaLipemica);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = muestraHemolizadaLipemica.IdMuestraHemolizadaLipemica;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarMuestraHemolizadaLipemicaAsync(ActualizarMuestraHemolizadaLipemica actualizarMuestraHemolizadaLipemica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            MuestraHemolizadaLipemica muestraHemolizadaLipemica = await Context.MuestraHemolizadaLipemica
                                                                                .Where(x => x.IdMuestraHemolizadaLipemica == actualizarMuestraHemolizadaLipemica.IdMuestraHemolizadaLipemica)
                                                                                .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(muestraHemolizadaLipemica);
            if (muestraHemolizadaLipemica != null)
            {
                MuestraHemolizadaLipemica pacienteEncontrado = await Context.MuestraHemolizadaLipemica
                                                                                .Where(x => x.HistoriaClinica == actualizarMuestraHemolizadaLipemica.HistoriaClinica && x.NumeroMes == actualizarMuestraHemolizadaLipemica.NumeroMes && x.IdMuestraHemolizadaLipemica != actualizarMuestraHemolizadaLipemica.IdMuestraHemolizadaLipemica)
                                                                                .FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(muestraHemolizadaLipemica).CurrentValues.SetValues(actualizarMuestraHemolizadaLipemica);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = muestraHemolizadaLipemica.IdMuestraHemolizadaLipemica;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarPocoFrecuente(ActualizarPocoFrecuente actualizarPocoFrecuente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PocoFrecuente pocoFrecuente = Context.PocoFrecuente.Where(x => x.IdPocoFrecuente == actualizarPocoFrecuente.IdPocoFrecuente).FirstOrDefault();
            if (pocoFrecuente != null)
            {
                Context.Entry(pocoFrecuente).CurrentValues.SetValues(actualizarPocoFrecuente);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = pocoFrecuente.IdPocoFrecuente;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarPocoFrecuenteAsync(ActualizarPocoFrecuente actualizarPocoFrecuente)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PocoFrecuente pocoFrecuente = await Context.PocoFrecuente.Where(x => x.IdPocoFrecuente == actualizarPocoFrecuente.IdPocoFrecuente).FirstOrDefaultAsync();
            if (pocoFrecuente != null)
            {
                Context.Entry(pocoFrecuente).CurrentValues.SetValues(actualizarPocoFrecuente);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = pocoFrecuente.IdPocoFrecuente;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarSueroMalReferenciado(ActualizarSueroMalReferenciado actualizarSueroMalReferenciado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SueroMalReferenciado sueroMalReferenciado = Context.SueroMalReferenciado.Where(x => x.IdSueroMalReferenciado == actualizarSueroMalReferenciado.IdSueroMalReferenciado).FirstOrDefault();
            if (sueroMalReferenciado != null)
            {
                Context.Entry(sueroMalReferenciado).CurrentValues.SetValues(actualizarSueroMalReferenciado);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = sueroMalReferenciado.IdSueroMalReferenciado;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarSueroMalReferenciadoAsync(ActualizarSueroMalReferenciado actualizarSueroMalReferenciado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SueroMalReferenciado sueroMalReferenciado = await Context.SueroMalReferenciado.Where(x => x.IdSueroMalReferenciado == actualizarSueroMalReferenciado.IdSueroMalReferenciado).FirstOrDefaultAsync();
            if (sueroMalReferenciado != null)
            {
                Context.Entry(sueroMalReferenciado).CurrentValues.SetValues(actualizarSueroMalReferenciado);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = sueroMalReferenciado.IdSueroMalReferenciado;
                respuesta.Mensaje = "Se modificó los datos correctamente.";
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public CalibracionDeficiente EncontrarCalibracionDeficiente(int Id)
        {
            return Context.CalibracionDeficiente.Where(x => x.IdCalibracionDeficiente == Id).FirstOrDefault();
        }

        public async Task<CalibracionDeficiente> EncontrarCalibracionDeficienteAsync(int Id)
        {
            return await Context.CalibracionDeficiente.Where(x => x.IdCalibracionDeficiente == Id).FirstOrDefaultAsync();
        }

        public EmpleoReactivo EncontrarEmpleoReactivo(int Id)
        {
            return Context.EmpleoReactivo.Where(x => x.IdEmpleoReactivo == Id).FirstOrDefault();
        }

        public async Task<EmpleoReactivo> EncontrarEmpleoReactivoAsync(int Id)
        {
            return await Context.EmpleoReactivo.Where(x => x.IdEmpleoReactivo == Id).FirstOrDefaultAsync();
        }

        public EquipoMalCalibrado EncontrarEquipoMalCalibrado(int Id)
        {
            return Context.EquipoMalCalibrado.Where(x => x.IdEquipoMalCalibrado == Id).FirstOrDefault();
        }

        public async Task<EquipoMalCalibrado> EncontrarEquipoMalCalibradoAsync(int Id)
        {
            return await Context.EquipoMalCalibrado.Where(x => x.IdEquipoMalCalibrado == Id).FirstOrDefaultAsync();
        }

        public EquipoUPS EncontrarEquipoUPS(int Id)
        {
            return Context.EquipoUPS.Where(x => x.IdEquipoUPS == Id).FirstOrDefault();
        }

        public async Task<EquipoUPS> EncontrarEquipoUPSAsync(int Id)
        {
            return await Context.EquipoUPS.Where(x => x.IdEquipoUPS == Id).FirstOrDefaultAsync();
        }

        public MaterialNoCalibrado EncontrarMaterialNoCalibrado(int Id)
        {
            return Context.MaterialNoCalibrado.Where(x => x.IdMaterialNoCalibrado == Id).FirstOrDefault();
        }

        public async Task<MaterialNoCalibrado> EncontrarMaterialNoCalibradoAsync(int Id)
        {
            return await Context.MaterialNoCalibrado.Where(x => x.IdMaterialNoCalibrado == Id).FirstOrDefaultAsync();
        }

        public MuestraHemolizadaLipemica EncontrarMuestraHemolizaadaLipemica(int Id)
        {
            return Context.MuestraHemolizadaLipemica.Where(x => x.IdMuestraHemolizadaLipemica == Id).FirstOrDefault();
        }

        public async Task<MuestraHemolizadaLipemica> EncontrarMuestraHemolizaadaLipemicaAsync(int Id)
        {
            return await Context.MuestraHemolizadaLipemica.Where(x => x.IdMuestraHemolizadaLipemica == Id).FirstOrDefaultAsync();
        }

        public PocoFrecuente EncontrarPocoFrecuente(int Id)
        {
            return Context.PocoFrecuente.Where(x => x.IdPocoFrecuente == Id).FirstOrDefault();
        }

        public async Task<PocoFrecuente> EncontrarPocoFrecuenteAsync(int Id)
        {
            return await Context.PocoFrecuente.Where(x => x.IdPocoFrecuente == Id).FirstOrDefaultAsync();
        }

        public SueroMalReferenciado EncontrarSueroMalReferenciado(int Id)
        {
            return Context.SueroMalReferenciado.Where(x => x.IdSueroMalReferenciado == Id).FirstOrDefault();
        }

        public async Task<SueroMalReferenciado> EncontrarSueroMalReferenciadoAsync(int Id)
        {
            return await Context.SueroMalReferenciado.Where(x => x.IdSueroMalReferenciado == Id).FirstOrDefaultAsync();
        }

        public IEnumerable<CalibracionDeficienteGeneral> ListarCalibracionDeficiente()
        {
            var list = Context.CalibracionDeficiente
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList();
            return Context.CalibracionDeficiente
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<CalibracionDeficienteGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<CalibracionDeficienteGeneral>> ListarCalibracionDeficienteAsync(int? Id)
        {
            return await Context.CalibracionDeficiente
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<CalibracionDeficienteGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<EmpleoReactivoGeneral> ListarEmpleoReactivo()
        {
            return Context.EmpleoReactivo
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<EmpleoReactivoGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<EmpleoReactivoGeneral>> ListarEmpleoReactivoAsync(int? Id)
        {
            return await Context.EmpleoReactivo
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<EmpleoReactivoGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<EquipoMalCalibradoGeneral> ListarEquipoMalCalibrado()
        {
            return Context.EquipoMalCalibrado
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<EquipoMalCalibradoGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<EquipoMalCalibradoGeneral>> ListarEquipoMalCalibradoAsync(int? Id)
        {
            return await Context.EquipoMalCalibrado
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<EquipoMalCalibradoGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<EquipoUPSGeneral> ListarEquipoUPS()
        {
            return Context.EquipoUPS.Include(x => x.AreaLaboratorio)
                                    .Select(x => Mapper.Map<EquipoUPSGeneral>(x))
                                    .ToList();
        }

        public async Task<IEnumerable<EquipoUPSGeneral>> ListarEquipoUPSAsync(int? Id)
        {
            return await Context.EquipoUPS
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<EquipoUPSGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<MaterialNoCalibradoGeneral> ListarMaterialNoCalibrado()
        {
            return Context.MaterialNoCalibrado
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<MaterialNoCalibradoGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<MaterialNoCalibradoGeneral>> ListarMaterialNoCalibradoAsync(int? Id)
        {
            return await Context.MaterialNoCalibrado
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<MaterialNoCalibradoGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<MuestraHemolizadaLipemicaGeneral> ListarMuestraHemolizadaLipemica()
        {
            return Context.MuestraHemolizadaLipemica
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<MuestraHemolizadaLipemicaGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<MuestraHemolizadaLipemicaGeneral>> ListarMuestraHemolizadaLipemicaAsync(int? Id)
        {
            return await Context.MuestraHemolizadaLipemica
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<MuestraHemolizadaLipemicaGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<PocoFrecuenteGeneral> ListarPocoFrecuente()
        {
            return Context.PocoFrecuente
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<PocoFrecuenteGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<PocoFrecuenteGeneral>> ListarPocoFrecuenteAsync(int? Id)
        {
            return await Context.PocoFrecuente
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<PocoFrecuenteGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<SueroMalReferenciadoGeneral> ListarSueroMalReferenciado()
        {
            return Context.SueroMalReferenciado
                                      .Include(x => x.AreaLaboratorio)
                                      .ToList()
                                      .Select(x => Mapper.Map<SueroMalReferenciadoGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<SueroMalReferenciadoGeneral>> ListarSueroMalReferenciadoAsync(int? Id)
        {
            return await Context.SueroMalReferenciado
                                      .Include(x => x.AreaLaboratorio)
                                      .Select(x => Mapper.Map<SueroMalReferenciadoGeneral>(x))
                                      .ToListAsync();
        }
    }
}
