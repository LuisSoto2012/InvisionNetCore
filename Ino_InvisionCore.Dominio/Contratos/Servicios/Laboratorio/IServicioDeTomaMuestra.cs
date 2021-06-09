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
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio
{
    public interface IServicioDeTomaMuestra
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
    }
}
