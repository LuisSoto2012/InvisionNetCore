using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Tramas;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeTramas : IRepositorioDeTramas
    {
        private readonly GalenPlusContext Context;

        public RepositorioDeTramas(GalenPlusContext context)
        {
            Context = context;
        }

        public IEnumerable<TramaHISMINSADto> ListarTramasHISMINSA(FiltroTramaHISMINSA filtro)
        {
            var list = Context.Query<TramaHISMINSAView>().ToList()
                        .Where(x => x.fechaatencion >= filtro.FechaDesde && x.fechaatencion <= filtro.FechaHasta
                                && x.idespecialidad == filtro.IdEspecialidad)
                         .Select(x => new TramaHISMINSADto
                         {
                             idatencion = x.idatencion,
                             cita = new CitaObjectHISMINSA
                             {
                                 numeroafiliacion = x.c_numeroafiliacion,
                                 fechaatencion = x.c_fechaatencion,
                                 estadoregistro = x.c_estadoregistro,
                                 items = new CitaItemObjectHISMINSA[]
                                 {
                                     new CitaItemObjectHISMINSA{
                                         labs = new object []{ },
                                         tipodiagnostico = x.c_dx1_t,
                                         codigo = x.c_dx1,
                                     },
                                     new CitaItemObjectHISMINSA{
                                         labs = new object []{ },
                                         tipodiagnostico = x.c_dx1_t,
                                         codigo = x.c_dx1
                                     },
                                     new CitaItemObjectHISMINSA{
                                         labs = new object []{ },
                                         tipodiagnostico = x.c_dx1_t,
                                         codigo = x.c_dx1
                                     },
                                     new CitaItemObjectHISMINSA{
                                         labs = new object []{ },
                                         tipodiagnostico = x.c_dx1_t,
                                         codigo = x.c_dx1
                                     },
                                     new CitaItemObjectHISMINSA{
                                         labs = new object []{ },
                                         tipodiagnostico = x.c_dx1_t,
                                         codigo = x.c_dx1
                                     },
                                     new CitaItemObjectHISMINSA{
                                         labs = new object []{ },
                                         tipodiagnostico = x.c_dx1_t,
                                         codigo = x.c_dx1
                                     }
                                 },
                                 idups = x.c_idups,
                                 idestablecimiento = x.c_idestablecimiento,
                                 edadregistro = x.c_edadregistro,
                                 idturno = x.c_idturno,
                                 idtipedadregistro = x.c_tipedadregistro,
                                 fgdiag = x.c_fgdiag,
                                 componente = x.c_componente,
                                 idfinanciador = x.c_idfinanciador,
                                 examenfisico = new
                                 {
                                     peso = "",
                                     talla = "",
                                     hemoglobina = ""
                                 }
                             },
                             personal_registra = new
                             {
                                 nrodocumento = x.pr_nrodocumento,
                                 apematerno = x.pr_apematerno,
                                 idpais = x.pr_idpais,
                                 idprofesion = x.pr_idprofesion,
                                 fechanacimiento = x.pr_fechanacimiento,
                                 nombres = x.pr_nombres,
                                 idtipodoc = x.pr_idtipodoc,
                                 apepaterno = x.pr_apepaterno,
                                 idsexo = x.pr_idsexo,
                                 idcondicion = x.pr_idcondicion
                             },
                             personal_atiende = new
                             {
                                 nrodocumento = x.pa_nrodocumento,
                                 apematerno = x.pa_apematerno,
                                 idpais = x.pa_idpais,
                                 idprofesion = x.pa_idprofesion,
                                 fechanacimiento = x.pa_fechanacimiento,
                                 nombres = x.pa_nombres,
                                 idtipodoc = x.pa_idtipodoc,
                                 apepaterno = x.pa_apepaterno,
                                 idsexo = x.pa_idsexo,
                                 idcondicion = x.pa_idcondicion
                             },
                             paciente = new
                             {
                                 nrodocumento = x.p_nrodocumento,
                                 apematenro = x.p_apematerno,
                                 idflag = x.p_idflag,
                                 nombres = x.p_nombres,
                                 nrohistoriaclinica = x.p_nrohistoriaclinica,
                                 idtipodoc = x.p_idtipodoc,
                                 apepaterno = x.p_apepaterno,
                                 idetnia = x.p_idetnia,
                                 fechanacimiento = x.p_fechanacimiento,
                                 idestablecimiento = x.p_idestablecimiento,
                                 idpais = x.p_idpais,
                                 idsexo = x.p_idsexo
                             }
                         }).ToList();

            foreach (var o in list)
            {
                var cita = o.cita;

                cita.items = cita.items.Where(x => x.codigo != "").ToArray();
            }

            return list;
        }
    }
}
