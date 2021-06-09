using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeAuditoria : IRepositorioDeAuditoria
    {
        private readonly InoContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeAuditoria(InoContext context)
        {
            Context = context;
        }

        public void AgregarAuditoria(AuditoriaGeneral auditoriaGeneral)
        {
            //Log.Information("RepositorioDeAuditoria: Agregar Auditoria");
            Auditoria auditoria = Mapper.Map<Auditoria>(auditoriaGeneral);
            auditoria.IpLogueo = Context.Empleados.Where(x => x.IdEmpleado == auditoriaGeneral.IdUsuario).FirstOrDefault().LoginIp;
            //Log.Information("       RepositorioDeAuditoria: Auditoria a agregar -->" + JsonConvert.SerializeObject(auditoria));
            Context.Auditoria.Add(auditoria);
            try
            {
                Context.SaveChanges();
                //Log.Information("       RepositorioDeAuditoria: Context.SaveChanges()");
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }
        }

        public async Task AgregarAuditoriaAsync(AuditoriaGeneral auditoriaGeneral)
        {
            Auditoria auditoria = Mapper.Map<Auditoria>(auditoriaGeneral);
            var empleado = await Context.Empleados.Where(x => x.IdEmpleado == auditoriaGeneral.IdUsuario).FirstOrDefaultAsync();
            auditoria.IpLogueo = empleado.LoginIp;
            //Log.Information("       RepositorioDeAuditoria: Auditoria a agregar -->" + JsonConvert.SerializeObject(auditoria));
            Context.Auditoria.Add(auditoria);
            try
            {
                await Context.SaveChangesAsync();
                //Log.Information("       RepositorioDeAuditoria: Context.SaveChanges()");
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }
        }
    }
}
