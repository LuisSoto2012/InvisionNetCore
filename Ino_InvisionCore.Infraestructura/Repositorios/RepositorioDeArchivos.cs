using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Archivo;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeArchivos : IRepositorioDeArchivos
    {
        private readonly InoContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeArchivos(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD Agregar(NuevoArchivo nuevoArchivo)
        {
            //Log.Information("RepositorioDeArchivos : Agregar Archivo");
            //Log.Information("   RepositorioDeArchivos : Se desea agregar ---> " + JsonConvert.SerializeObject(nuevoArchivo));

            RespuestaBD respuesta = new RespuestaBD();

            Archivo archivo = Mapper.Map<Archivo>(nuevoArchivo);
            Archivo archivoEncontrado = Context.Archivos.Where(x => x.IdEspecialidad == nuevoArchivo.IdEspecialidad && x.IdServicio == nuevoArchivo.IdServicio && x.NroDocumento == nuevoArchivo.NroDocumento && x.NombreArchivo == nuevoArchivo.NombreArchivo).FirstOrDefault();
            if (archivoEncontrado == null)
            {
                Context.Archivos.Add(archivo);
                try
                {
                    //Log.Information("   RepositorioDeArchivos: SaveChanges()");
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = archivo.IdArchivo;
                    respuesta.Mensaje = "Se subió el archivo correctamente.";
                    //Log.Information("   RepositorioDeArchivos: Se subió el archivo correctamente.");
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 1;
                respuesta.Mensaje = "Se subió el archivo correctamente.";
                //Log.Information("   RepositorioDeArchivos : Se subió el archivo correctamente.");
            }

            return respuesta;
        }

        public string Eliminar(EliminarArchivo archivoEliminado)
        {
            //Log.Information("RepositorioDeArchivos : Eliminar Archivo");

            string rutaCompleta = "";
            Archivo archivo = Context.Archivos.Where(x => x.IdArchivo == archivoEliminado.IdArchivo).FirstOrDefault();

            //Log.Information("   RepositorioDeArchivos : Se desea eliminar ---> " + JsonConvert.SerializeObject(archivo));

            if (archivo != null)
            {
                Context.Archivos.Remove(archivo);
                rutaCompleta = archivo.RutaCompleta;
                try
                {
                    //Log.Information("   RepositorioDeArchivos: SaveChanges()");
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Log.Information(ex.Message, "Error");
                }
            }

            return rutaCompleta;
        }

        public Archivo EncontrarArchivo(int Id)
        {
            return Context.Archivos.Where(x => x.IdArchivo == Id).FirstOrDefault();
        }

        public IEnumerable<ArchivoGeneral> Listar(ArchivoGeneral archivoGeneral)
        {
            var query = (from a in Context.Archivos
                         where (a.NroDocumento == archivoGeneral.NroDocumento) &&
                               (archivoGeneral.IdServicio == 0 || a.IdServicio == archivoGeneral.IdServicio) &&
                               (archivoGeneral.TipoArchivo == "" || a.TipoArchivo == archivoGeneral.TipoArchivo) &&
                               (a.EsActivo == true)
                         select new
                         {
                             IdArchivo = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? 0 : a.IdArchivo,
                             TipoArchivo = a.TipoArchivo,
                             IdServicio = a.IdServicio,
                             HistoriaClinica = a.HistoriaClinica,
                             Ruta = a.Ruta,
                             NombreArchivo = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? string.Empty : a.NombreArchivo,
                             RutaCompleta = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? string.Empty : a.RutaCompleta,
                             EsActivo = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? true : a.EsActivo,
                             FechaCreacion = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? DateTime.Now : a.FechaCreacion,
                             NroDocumento = a.NroDocumento
                         }
                            ).Distinct().OrderByDescending(x => x.FechaCreacion).ToList();

            return query.Select(x => new ArchivoGeneral
            {
                IdArchivo = x.IdArchivo,
                TipoArchivo = x.TipoArchivo,
                IdServicio = x.IdServicio,
                HistoriaClinica = x.HistoriaClinica,
                NombreArchivo = x.NombreArchivo,
                ArchivoBinario = (string.IsNullOrEmpty(x.RutaCompleta)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes((@Path.GetFullPath(x.Ruta + "\\" + x.NombreArchivo.Replace("\"", string.Empty))).Substring(1))),
                EsActivo = x.EsActivo,
                Fecha = x.FechaCreacion.ToString("dd/MM/yyyy"),
                NroDocumento = x.NroDocumento
            }).ToList();
        }

        public IEnumerable<ArchivoPorFechaYUsuario> ListarArchivoPorFechaYUsuario(ConsultarArchivoPor archivoPor)
        {

            return Context.Query<ArchivoPorFechaYUsuarioView>().FromSql("dbo.Invision_MonitoreoReferencia @FechaDesde, @FechaHasta, @IdEmpleado, @Usuario",
                            new SqlParameter("FechaDesde", archivoPor.FechaDesde),
                            new SqlParameter("FechaHasta", archivoPor.FechaHasta),
                            new SqlParameter("IdEmpleado", archivoPor.IdUsuario),
                            new SqlParameter("Usuario", "Usuario")
                        ).ToList()
                        .Select(x => new ArchivoPorFechaYUsuario
                        {
                            Fecha = x.Fecha,
                            NombreArchivo = x.NombreArchivo,
                            Usuario = x.Usuario,
                            Conteo = x.Conteo,
                            Ruta = x.Ruta,
                            //ArchivoBinario = (string.IsNullOrEmpty(x.RutaCompleta)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes(x.RutaCompleta))
                            ArchivoBinario = (string.IsNullOrEmpty(x.RutaCompleta)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes((@Path.GetFullPath(x.Ruta + "\\" + x.NombreArchivo.Replace("\"", string.Empty))).Substring(1)))
                        }).ToList();
        }

        public async Task<RespuestaBD> AgregarAsync(NuevoArchivo nuevoArchivo)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Archivo archivo = Mapper.Map<Archivo>(nuevoArchivo);
            Archivo archivoEncontrado = await Context.Archivos
                                                .Where(x => x.IdEspecialidad == nuevoArchivo.IdEspecialidad && x.IdServicio == nuevoArchivo.IdServicio && x.HistoriaClinica == nuevoArchivo.HistoriaClinica && x.NombreArchivo == nuevoArchivo.NombreArchivo)
                                                .FirstOrDefaultAsync();
            if (archivoEncontrado == null)
            {
                await Context.Archivos.AddAsync(archivo);
                try
                {
                    //Log.Information("   RepositorioDeArchivos: SaveChanges()");
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = archivo.IdArchivo;
                    respuesta.Mensaje = "Se subió el archivo correctamente.";
                    //Log.Information("   RepositorioDeArchivos: Se subió el archivo correctamente.");
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }


            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 1;
                respuesta.Mensaje = "Se subió el archivo correctamente.";
                //Log.Information("   RepositorioDeArchivos : Se subió el archivo correctamente.");
            }

            return respuesta;
        }

        public async Task<IEnumerable<ArchivoGeneral>> ListarAsync(ArchivoGeneral archivoGeneral)
        {
            var query = await (from a in Context.Archivos
                         where (a.HistoriaClinica == archivoGeneral.HistoriaClinica) &&
                               (archivoGeneral.IdServicio == 0 || a.IdServicio == archivoGeneral.IdServicio) &&
                               (archivoGeneral.TipoArchivo == "" || a.TipoArchivo == archivoGeneral.TipoArchivo) &&
                               (a.EsActivo == true)
                         select new
                         {
                             IdArchivo = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? 0 : a.IdArchivo,
                             TipoArchivo = a.TipoArchivo,
                             IdServicio = a.IdServicio,
                             HistoriaClinica = a.HistoriaClinica,
                             Ruta = a.Ruta,
                             NombreArchivo = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? string.Empty : a.NombreArchivo,
                             RutaCompleta = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? string.Empty : a.RutaCompleta,
                             EsActivo = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? true : a.EsActivo,
                             FechaCreacion = (archivoGeneral.IdServicio == 0 && archivoGeneral.TipoArchivo == "jpg") ? DateTime.Now : a.FechaCreacion
                         }
                            ).Distinct().OrderByDescending(x => x.FechaCreacion).ToListAsync();

            return query.Select(x => new ArchivoGeneral
            {
                IdArchivo = x.IdArchivo,
                TipoArchivo = x.TipoArchivo,
                IdServicio = x.IdServicio,
                HistoriaClinica = x.HistoriaClinica,
                NombreArchivo = x.NombreArchivo,
                ArchivoBinario = (string.IsNullOrEmpty(x.RutaCompleta)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes((@Path.GetFullPath(x.Ruta + "\\" + x.NombreArchivo.Replace("\"", string.Empty))).Substring(1))),
                EsActivo = x.EsActivo,
                Fecha = x.FechaCreacion.ToString("dd/MM/yyyy")
            }).ToList();
        }

        public async Task<string> EliminarAsync(EliminarArchivo archivoEliminado)
        {
            string rutaCompleta = "";
            Archivo archivo = await Context.Archivos.Where(x => x.IdArchivo == archivoEliminado.IdArchivo).FirstOrDefaultAsync();

            //Log.Information("   RepositorioDeArchivos : Se desea eliminar ---> " + JsonConvert.SerializeObject(archivo));

            if (archivo != null)
            {
                Context.Archivos.Remove(archivo);
                rutaCompleta = archivo.RutaCompleta;
                try
                {
                    //Log.Information("   RepositorioDeArchivos: SaveChanges()");
                    await Context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    //Log.Information(ex.Message, "Error");
                }
            }

            return rutaCompleta;
        }

        public async Task<IEnumerable<ArchivoPorFechaYUsuario>> ListarArchivoPorFechaYUsuarioAsync(ConsultarArchivoPor archivoPor)
        {
            var query = await Context.Query<ArchivoPorFechaYUsuarioView>().FromSql("dbo.Invision_MonitoreoReferencia @FechaDesde, @FechaHasta, @IdEmpleado, @Usuario",
                                    new SqlParameter("FechaDesde", archivoPor.FechaDesde),
                                    new SqlParameter("FechaHasta", archivoPor.FechaHasta),
                                    new SqlParameter("IdEmpleado", archivoPor.IdUsuario),
                                    new SqlParameter("Usuario", "Usuario")
                                ).ToListAsync();

            return query.Select(x => new ArchivoPorFechaYUsuario
                                {
                                    Fecha = x.Fecha,
                                    NombreArchivo = x.NombreArchivo,
                                    Usuario = x.Usuario,
                                    Conteo = x.Conteo,
                                    Ruta = x.Ruta,
                                    ArchivoBinario = (string.IsNullOrEmpty(x.RutaCompleta)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes((@Path.GetFullPath(x.Ruta + "\\" + x.NombreArchivo.Replace("\"", string.Empty))).Substring(1)))
                                }).ToList();

        }

        public async Task<Archivo> EncontrarArchivoAsync(int Id)
        {
            return await Context.Archivos.Where(x => x.IdArchivo == Id).FirstOrDefaultAsync();
        }
    }
}
