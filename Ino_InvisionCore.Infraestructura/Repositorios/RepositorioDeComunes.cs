using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Comunes;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeComunes : IRepositorioDeComunes
    {
        private readonly GalenPlusContext GalenPlusContext;
        private readonly InoContext InoContext;

        public RepositorioDeComunes(GalenPlusContext galenPlusContext, InoContext inoContext)
        {
            GalenPlusContext = galenPlusContext;
            InoContext = inoContext;
        }

        public IEnumerable<ComboBox> ListarAlmacenes()
        {
            //return GalenPlusContext.Database.SqlQuery<ComboBox>("dbo.Invision_AlmacenesListar").ToList();

            return GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_AlmacenesListar").ToList().Select(x => Mapper.Map<ComboBox>(x));
        }

        public async Task<IEnumerable<ComboBox>> ListarAlmacenesAsync()
        {
            return await GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_AlmacenesListar").Select(x => Mapper.Map<ComboBox>(x)).ToListAsync();
        }

        public IEnumerable<ComboBox> ListarAreaLaboratorio(int? Id)
        {
            return InoContext.SubModulo.Where(x => Id == null || x.IdSubModulo == Id)
                                   .Include(x => x.SubModuloAreaLaboratorios)
                                   .ThenInclude(sa => sa.AreaLaboratorio)
                                   .FirstOrDefault()
                                   //.AreaLaboratorios
                                   .SubModuloAreaLaboratorios
                                   .Select(x => x.AreaLaboratorio)
                                   .Where(x => x.EsActivo == true)
                                   .ToList()
                                   .Select(x => Mapper.Map<ComboBox>(x))
                                   .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarAreaLaboratorioAsync(int? Id)
        {
            var subModulo = await InoContext.SubModulo.Where(x => Id == null || x.IdSubModulo == Id)
                                   .Include(x => x.SubModuloAreaLaboratorios)
                                   .ThenInclude(sa => sa.AreaLaboratorio)
                                   .FirstOrDefaultAsync();
            return subModulo
                            .SubModuloAreaLaboratorios
                            .Select(x => x.AreaLaboratorio)
                            .Where(x => x.EsActivo == true)
                            .ToList()
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarBifocales()
        {
            return await InoContext.Bifocales
                                            .Select(x => Mapper.Map<ComboBox>(x))
                                            .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarCajeros()
        {
            return GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_CajerosSeleccionarTodos").ToList().Select(x => Mapper.Map<ComboBox>(x));
        }

        public async Task<IEnumerable<ComboBox>> ListarCajerosAsync()
        {
            return await GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_CajerosSeleccionarTodos")
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarCondicionTrabajo()
        {
            return InoContext.CondicionTrabajo.Where(x => x.EsActivo == true)
                                          .ToList()
                                          .Select(x => Mapper.Map<ComboBox>(x))
                                          .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarCondicionTrabajoAsync()
        {
            return await InoContext.CondicionTrabajo.Where(x => x.EsActivo == true)
                                          .Select(x => Mapper.Map<ComboBox>(x))
                                          .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarEscalafonDeLegajos()
        {
            return InoContext.EscalafonDeLegajos.Where(x => x.EsActivo == true)
                                            .ToList()
                                            .Select(x => Mapper.Map<ComboBox>(x))
                                            .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarEscalafonDeLegajosAsync()
        {
            return await InoContext.EscalafonDeLegajos.Where(x => x.EsActivo == true)
                                            .Select(x => Mapper.Map<ComboBox>(x))
                                            .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarEspecialidades()
        {
            //return GalenPlusContext.Database.SqlQuery<ComboBox>("dbo.Invision_EspecialidadesListar").ToList();

            return GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_EspecialidadesListar").ToList().Select(x => Mapper.Map<ComboBox>(x));
        }

        public async Task<IEnumerable<ComboBox>> ListarEspecialidadesAsync()
        {
            return await GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_EspecialidadesListar")
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToListAsync();
        }

        public async Task<IEnumerable<ComboBox>> ListarEspecificaciones()
        {
            return await InoContext.Especificaciones
                                            .Select(x => Mapper.Map<ComboBox>(x))
                                            .ToListAsync();
        }

        public async Task<IEnumerable<ComboBox>> ListarMateriales()
        {
            return await InoContext.Materiales
                                            .Select(x => Mapper.Map<ComboBox>(x))
                                            .ToListAsync();
        }

        public async Task<IEnumerable<ComboBox>> ListarMedicamentosFarmacia()
        {
            return await GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_ListarMedicamentos")
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarPruebaLabotario(string Codigo)
        {
            //return GalenPlusContext.Database.SqlQuery<PruebaLaboratorio>("dbo.Invision_PruebasLaboratorioPorAreaListar @Codigo",
            //            new SqlParameter("Codigo", Codigo)).ToList()
            //            .Select(x => Mapper.Map<ComboBox>(x))
            //            .ToList();

            return GalenPlusContext.Query<PruebaLaboratorioView>().FromSql("dbo.Invision_PruebasLaboratorioPorAreaListar @Codigo",
                        new SqlParameter("Codigo", Codigo)).ToList()
                        .Select(x => Mapper.Map<PruebaLaboratorio>(x))
                        .Select(x => Mapper.Map<ComboBox>(x))
                        .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarPruebaLabotarioAsync(string Codigo)
        {
            return await GalenPlusContext.Query<PruebaLaboratorioView>().FromSql("dbo.Invision_PruebasLaboratorioPorAreaListar @Codigo",
                            new SqlParameter("Codigo", Codigo))
                            .Select(x => Mapper.Map<PruebaLaboratorio>(x))
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToListAsync();
        }

        public ComboBox ListarRespuestaIndicadoresDesempeno(string codigo)
        {
            var codigoRespuesta = InoContext.CodigosRespuestaIndicadoresDesempeno.Where(x => x.EsActivo == true && x.Codigo == codigo).FirstOrDefault();
            return Mapper.Map<ComboBox>(codigoRespuesta);
        }

        public async Task<ComboBox> ListarRespuestaIndicadoresDesempenoAsync(string codigo)
        {
            var codigoRespuesta = await InoContext.CodigosRespuestaIndicadoresDesempeno.Where(x => x.EsActivo == true && x.Codigo == codigo).FirstOrDefaultAsync();
            return Mapper.Map<ComboBox>(codigoRespuesta);
        }

        public IEnumerable<ComboBox> ListarServicioEspecialidad(int? Id)
        {
            //return GalenPlusContext.Database.SqlQuery<ComboBox>("dbo.Invision_ServicioEspecialidadListar @IdServicio",
            //            new SqlParameter("IdServicio", Id)).ToList();

            return GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_ServicioEspecialidadListar @IdServicio",
                        new SqlParameter("IdServicio", Id)).ToList().Select(x => Mapper.Map<ComboBox>(x)).ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarCallCenterUsuariosAsync()
        {
            var list = await InoContext.Query<ComboBoxView>().FromSql("dbo.Invision_CallCenterUsuarios").ToListAsync();

            return list.Select(x => Mapper.Map<ComboBox>(x));
        }

        public async Task<IEnumerable<ComboBox>> ListarServicioEspecialidadAsync(int? Id)
        {
            return await GalenPlusContext.Query<ComboBoxView>().FromSql("dbo.Invision_ServicioEspecialidadListar @IdServicio",
                            new SqlParameter("IdServicio", Id))
                                .Select(x => Mapper.Map<ComboBox>(x))
                                .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarTipoDocumentoIdentidad()
        {
            return InoContext.TipoDocumentoIdentidad.Where(x => x.EsActivo == true)
                                                .ToList()
                                                .Select(x => Mapper.Map<ComboBox>(x))
                                                .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarTipoDocumentoIdentidadAsync()
        {
            return await InoContext.TipoDocumentoIdentidad.Where(x => x.EsActivo == true)
                                                .Select(x => Mapper.Map<ComboBox>(x))
                                                .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarTipoEmpleado()
        {
            return InoContext.TipoEmpleado.Where(x => x.EsActivo == true)
                                      .ToList()
                                      .Select(x => Mapper.Map<ComboBox>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarTipoEmpleadoAsync()
        {
            return await InoContext.TipoEmpleado.Where(x => x.EsActivo == true)
                                      .Select(x => Mapper.Map<ComboBox>(x))
                                      .ToListAsync();
        }

        public IEnumerable<ComboBox> ListarUsuarioPorRol(int? Id)
        {
            return InoContext.Roles.Where(x => Id == null || x.IdRol == Id)
                                   .Include(x => x.EmpleadoRoles)
                                   .ThenInclude(er => er.Empleado)
                                   .FirstOrDefault()
                                   //.Empleado
                                   .EmpleadoRoles
                                   .Select(x => x.Empleado)
                                   .Where(x => x.EsActivo == true)
                                   .ToList()
                                   .Select(x => Mapper.Map<ComboBox>(x))
                                   .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarUsuarioPorRolAsync(int? Id)
        {
            var roles = await InoContext.Roles.Where(x => Id == null || x.IdRol == Id)
                                   .Include(x => x.EmpleadoRoles)
                                   .ThenInclude(er => er.Empleado)
                                   .FirstOrDefaultAsync();


            return roles.EmpleadoRoles
                        .Select(x => x.Empleado)
                        .Where(x => x.EsActivo == true)
                        .ToList()
                        .Select(x => Mapper.Map<ComboBox>(x))
                        .ToList();
        }

        public async Task<IEnumerable<ComboBox>> ListarMedicosReporte()
        {
            return await InoContext.Query<ComboBoxView>().FromSql("dbo.Invision_ListarMedicosReporte")
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToListAsync();
        }
    }
}
