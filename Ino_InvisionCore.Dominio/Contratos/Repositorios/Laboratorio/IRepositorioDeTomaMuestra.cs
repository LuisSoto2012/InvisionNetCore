using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio
{
    public interface IRepositorioDeTomaMuestra
    {
        RespuestaBD AgregarRecoleccionMuestra(NuevoRecoleccionMuestra nuevoRecoleccionMuestra);
        RespuestaBD AgregarVenopunturasFallidas(NuevoVenopunturasFallidas nuevoVenopunturasFallidas);
        RespuestaBD AgregarIncidentesPacientes(NuevoIncidentesPacientes nuevoIncidentesPacientes);
        RespuestaBD AgregarIncumplimientoAnalisis(NuevoIncumplimientoAnalisis nuevoIncumplimientoAnalisis);
        RespuestaBD AgregarPruebasNoRealizadas(NuevoPruebasNoRealizadas nuevoPruebasNoRealizadas);
        RespuestaBD EditarRecoleccionMuestra(ActualizarRecoleccionMuestra actualizarRecoleccionMuestra);
        RespuestaBD EditarVenopunturasFallidas(ActualizarVenopunturasFallidas actualizarVenopunturasFallidas);
        RespuestaBD EditarIncidentesPacientes(ActualizarIncidentesPacientes actualizarIncidentesPacientes);
        RespuestaBD EditarIncumplimientoAnalisis(ActualizarIncumplimientoAnalisis actualizarIncumplimientoAnalisis);
        RespuestaBD EditarPruebasNoRealizadas(ActualizarPruebasNoRealizadas actualizarPruebasNoRealizadas);
        IEnumerable<RecoleccionMuestraGeneral> ListarRecoleccionMuestra();
        IEnumerable<VenopunturasFallidasGeneral> ListarVenopunturasFallidas();
        IEnumerable<IncidentesPacientesGeneral> ListarIncidentesPacientes();
        IEnumerable<IncumplimientoAnalisisGeneral> ListarIncumplimientoAnalisis();
        IEnumerable<PruebasNoRealizadasGeneral> ListarPruebasNoRealizadas();
        IncidentesPacientes EncontrarIncidentesPacientes(int Id);
        RecoleccionMuestra EncontrarRecoleccionMuestra(int Id);
        VenopunturasFallidas EncontrarVenopunturasFallidas(int Id);
        IncumplimientoAnalisis EncontrarIncumplimientoAnalisis(int Id);
        PruebasNoRealizadas EncontrarPruebasNoRealizadas(int Id);

        Task<RespuestaBD> AgregarRecoleccionMuestraAsync(NuevoRecoleccionMuestra nuevoRecoleccionMuestra);
        Task<RespuestaBD> AgregarVenopunturasFallidasAsync(NuevoVenopunturasFallidas nuevoVenopunturasFallidas);
        Task<RespuestaBD> AgregarIncidentesPacientesAsync(NuevoIncidentesPacientes nuevoIncidentesPacientes);
        Task<RespuestaBD> AgregarIncumplimientoAnalisisAsync(NuevoIncumplimientoAnalisis nuevoIncumplimientoAnalisis);
        Task<RespuestaBD> AgregarPruebasNoRealizadasAsync(NuevoPruebasNoRealizadas nuevoPruebasNoRealizadas);
        Task<RespuestaBD> EditarRecoleccionMuestraAsync(ActualizarRecoleccionMuestra actualizarRecoleccionMuestra);
        Task<RespuestaBD> EditarVenopunturasFallidasAsync(ActualizarVenopunturasFallidas actualizarVenopunturasFallidas);
        Task<RespuestaBD> EditarIncidentesPacientesAsync(ActualizarIncidentesPacientes actualizarIncidentesPacientes);
        Task<RespuestaBD> EditarIncumplimientoAnalisisAsync(ActualizarIncumplimientoAnalisis actualizarIncumplimientoAnalisis);
        Task<RespuestaBD> EditarPruebasNoRealizadasAsync(ActualizarPruebasNoRealizadas actualizarPruebasNoRealizadas);
        Task<IEnumerable<RecoleccionMuestraGeneral>> ListarRecoleccionMuestraAsync(int? Id);
        Task<IEnumerable<VenopunturasFallidasGeneral>> ListarVenopunturasFallidasAsync(int? Id);
        Task<IEnumerable<IncidentesPacientesGeneral>> ListarIncidentesPacientesAsync(int? Id);
        Task<IEnumerable<IncumplimientoAnalisisGeneral>> ListarIncumplimientoAnalisisAsync(int? Id);
        Task<IEnumerable<PruebasNoRealizadasGeneral>> ListarPruebasNoRealizadasAsync(int? Id);
        Task<IncidentesPacientes> EncontrarIncidentesPacientesAsync(int Id);
        Task<RecoleccionMuestra> EncontrarRecoleccionMuestraAsync(int Id);
        Task<VenopunturasFallidas> EncontrarVenopunturasFallidasAsync(int Id);
        Task<IncumplimientoAnalisis> EncontrarIncumplimientoAnalisisAsync(int Id);
        Task<PruebasNoRealizadas> EncontrarPruebasNoRealizadasAsync(int Id);
    }
}
