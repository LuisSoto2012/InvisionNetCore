using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Medico;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeMedicos : IRepositorioDeMedicos
    {
        private GalenPlusContext Context;

        public RepositorioDeMedicos(GalenPlusContext context)
        {
            Context = context;
        }

        public IEnumerable<MedicoPorEspecialidad> ListarEspecialidadPorMedico(MedicoListar medico)
        {
            IEnumerable<MedicoPorEspecialidad> especialidades = null;
            if (medico.IdMedico == -1)
            {
                especialidades = Context.Query<MedicoPorEspecialidadView>().FromSql("dbo.INO_CEEspecialidadesListar")
                                        .ToList()
                                        .Select(x => Mapper.Map<MedicoPorEspecialidad>(x));
            }
            else
            {
                especialidades = Context.Query<MedicoPorEspecialidadView>().FromSql("dbo.INO_CEMedicosEspecialidad @IdMedico",
                        new SqlParameter("IdMedico", medico.IdMedico))
                                    .ToList()
                                    .Select(x => Mapper.Map<MedicoPorEspecialidad>(x))
                                    .ToList();
            }
            return especialidades;
        }

        public async Task<IEnumerable<MedicoPorEspecialidad>> ListarEspecialidadPorMedicoAsync(MedicoListar medico)
        {
            if (medico.IdMedico == -1)
            {
                return await Context.Query<MedicoPorEspecialidadView>().FromSql("dbo.INO_CEEspecialidadesListar")
                                        .Select(x => Mapper.Map<MedicoPorEspecialidad>(x))
                                        .ToListAsync();
            }
            else
            {
                return await Context.Query<MedicoPorEspecialidadView>().FromSql("dbo.INO_CEMedicosEspecialidad @IdMedico",
                        new SqlParameter("IdMedico", medico.IdMedico))
                                    .Select(x => Mapper.Map<MedicoPorEspecialidad>(x))
                                    .ToListAsync();
            }
        }

        public IEnumerable<MedicoListar> ListarMedicos(MedicoListar medico)
        {
            return Context.Query<MedicoListarView>().FromSql("dbo.Invision_MedicosListar @IdEmpleado",
                        new SqlParameter("IdEmpleado", medico.IdEmpleado)).ToList().Select(x => Mapper.Map<MedicoListar>(x)).ToList();
        }

        public async Task<IEnumerable<MedicoListar>> ListarMedicosAsync(MedicoListar medico)
        {
            return await Context.Query<MedicoListarView>().FromSql("dbo.Invision_MedicosListar @IdEmpleado",
                        new SqlParameter("IdEmpleado", medico.IdEmpleado)).Select(x => Mapper.Map<MedicoListar>(x)).ToListAsync();
        }

        public IEnumerable<MedicoListar> ListarMedicosTicket()
        {
            return Context.Query<MedicoListarView>().FromSql("dbo.Invision_MedicosTicketListar").ToList().Select(x => Mapper.Map<MedicoListar>(x)).ToList();
        }

        public async Task<IEnumerable<MedicoListar>> ListarMedicosTicketAsync()
        {
            return await Context.Query<MedicoListarView>().FromSql("dbo.Invision_MedicosTicketListar").Select(x => Mapper.Map<MedicoListar>(x)).ToListAsync();
        }
    }
}
