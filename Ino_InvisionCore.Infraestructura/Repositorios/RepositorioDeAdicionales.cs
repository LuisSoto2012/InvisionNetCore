using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Adicional;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeAdicionales : IRepositorioDeAdicionales
    {
        private GalenPlusContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeAdicionales(GalenPlusContext context)
        {
            Context = context;
        }

        public IEnumerable<Adicionales> ConsultaExternaAdicionalesPorMedicoListar(BuscarPaciente paciente)
        {
            //Log.Information("Consulta Externa - Obtener Listado de Adicionales por Medico");
            //Log.Information("RepositorioDeAdicionales : ConsultaExternaAdicionalesPorMedicoListar");

            IList<Adicionales> adicionales = new List<Adicionales>();

            try
            {
                //Log.Information("   Ejecutando SP: dbo.INO_ConsultaExternaAdicionalesPorMedicoListar");

                adicionales = Context.Query<AdicionalesView>().FromSql("dbo.INO_ConsultaExternaAdicionalesPorMedicoListar @Idmedico, @Fecha, @IdEspecialidad",
                                new SqlParameter("IdMedico", paciente.IdMedico),
                                new SqlParameter("Fecha", paciente.Fecha),
                                new SqlParameter("IdEspecialidad", paciente.IdEspecialidad))
                    .ToList().Select(x => Mapper.Map<Adicionales>(x)).ToList();

                //Log.Information("   Cantidad de resultados: ", adicionales.Count);
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }

            return adicionales;
        }

        public async Task<IEnumerable<Adicionales>> ConsultaExternaAdicionalesPorMedicoListar(string hc)
        {
            IList<Adicionales> adicionales = new List<Adicionales>();

            try
            {
                //Log.Information("   Ejecutando SP: dbo.INO_ConsultaExternaAdicionalesPorMedicoListar");

                adicionales = Context.Query<AdicionalesView>().FromSql("dbo.INO_ConsultaExternaAdicionalesPorMedicoListar_PorHc @Hc",
                    new SqlParameter("Hc", hc)).ToList().Select(x => Mapper.Map<Adicionales>(x)).ToList();

                //Log.Information("   Cantidad de resultados: ", adicionales.Count);
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }

            return adicionales;
        }

        public int ConsultaExternaAdicionalesPorMedicoRegistrar(NuevoAdicional nuevoAdicional)
        {
            //Log.Information("Consulta Externa - Registrar Adicional por Medico");
            //Log.Information("RepositorioDeAdicionales : ConsultaExternaAdicionalesPorMedicoRegitrar");

            int adicional = -1;

            try
            {
                //Log.Information("   Ejecutando SP: dbo.INO_ConsultaExternaAdicionalesPorMedicoRegistrar");

                adicional = Context.Query<ConsultaExternaAdicionalesPorMedicoRegitrarView>().FromSql("dbo.INO_ConsultaExternaAdicionalesPorMedicoRegistrar @Hc,@Paciente,@IdEspecialidad,@IdServicio,@IdMedico,@FechaAdicional,@FechaRegistro,@IdUsuario",
                        new SqlParameter("Hc", nuevoAdicional.Hc),
                        new SqlParameter("Paciente", nuevoAdicional.Paciente),
                        new SqlParameter("IdEspecialidad", nuevoAdicional.IdEspecialidad),
                        new SqlParameter("IdServicio", nuevoAdicional.IdServicio),
                        new SqlParameter("IdMedico", nuevoAdicional.IdMedico),
                        new SqlParameter("FechaAdicional", nuevoAdicional.FechaAdicional),
                        new SqlParameter("FechaRegistro", nuevoAdicional.FechaRegistro),
                        new SqlParameter("IdUsuario", nuevoAdicional.IdUsuario))
                        .FirstOrDefault()
                        .IdAdicional;
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }

            return adicional;
        }

        public async Task<RespuestaBD> ConsultaExternaAdicionalesPorMedicoEliminar(int idAdicional)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                await Context.Database.ExecuteSqlCommandAsync("dbo.INO_ConsultaExternaAdicionalesPorMedicoElimina @idAdicional",
                    new SqlParameter("idAdicional", idAdicional));

                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha eliminado el adicional correctamente!";
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }
            
            return respuesta;
        }

        public async Task<IEnumerable<Adicionales>> ConsultaExternaAdicionalesPorMedicoListarAsync(BuscarPaciente paciente)
        {
            //Log.Information("Consulta Externa - Obtener Listado de Adicionales por Medico");
            //Log.Information("RepositorioDeAdicionales : ConsultaExternaAdicionalesPorMedicoListar");

            return await Context.Query<AdicionalesView>().FromSql("dbo.INO_ConsultaExternaAdicionalesPorMedicoListar @Idmedico, @Fecha, @IdEspecialidad",
                                new SqlParameter("IdMedico", paciente.IdMedico),
                                new SqlParameter("Fecha", paciente.Fecha),
                                new SqlParameter("IdEspecialidad", paciente.IdEspecialidad)).Select(x => Mapper.Map<Adicionales>(x)).ToListAsync();
        }

        public async Task<int> ConsultaExternaAdicionalesPorMedicoRegistrarAsync(NuevoAdicional nuevoAdicional)
        {
            int adicional = -1;

            try
            {
                //Log.Information("   Ejecutando SP: dbo.INO_ConsultaExternaAdicionalesPorMedicoRegistrar");

                var result = await Context.Query<ConsultaExternaAdicionalesPorMedicoRegitrarView>().FromSql("dbo.INO_ConsultaExternaAdicionalesPorMedicoRegistrar @Hc,@Paciente,@IdEspecialidad,@IdServicio,@IdMedico,@FechaAdicional,@FechaRegistro,@IdUsuario",
                                new SqlParameter("Hc", nuevoAdicional.Hc),
                                new SqlParameter("Paciente", nuevoAdicional.Paciente),
                                new SqlParameter("IdEspecialidad", nuevoAdicional.IdEspecialidad),
                                new SqlParameter("IdServicio", nuevoAdicional.IdServicio),
                                new SqlParameter("IdMedico", nuevoAdicional.IdMedico),
                                new SqlParameter("FechaAdicional", nuevoAdicional.FechaAdicional),
                                new SqlParameter("FechaRegistro", nuevoAdicional.FechaRegistro),
                                new SqlParameter("IdUsuario", nuevoAdicional.IdUsuario))
                                .FirstOrDefaultAsync();

                adicional = result.IdAdicional;
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }

            return adicional;
        }
    }
}
