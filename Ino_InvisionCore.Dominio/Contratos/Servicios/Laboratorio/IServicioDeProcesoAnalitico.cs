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
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio
{
    public interface IServicioDeProcesoAnalitico
    {
        RespuestaBD AgregarPocoFrecuente(NuevoPocoFrecuente nuevoPocoFrecuente);
        RespuestaBD AgregarEmpleoReactivo(NuevoEmpleoReactivo nuevoEmpleoReactivo);
        RespuestaBD AgregarEquipoMalCalibrado(NuevoEquipoMalCalibrado nuevoEquipoMalCalibrado);
        RespuestaBD AgregarEquipoUPS(NuevoEquipoUPS nuevoEquipoUPS);
        RespuestaBD AgregarCalibracionDeficiente(NuevoCalibracionDeficiente nuevoCalibracionDeficiente);
        RespuestaBD AgregarSueroMalReferenciado(NuevoSueroMalReferenciado nuevoSueroMalReferenciado);
        RespuestaBD AgregarMaterialNoCalibrado(NuevoMaterialNoCalibrado nuevoMaterialNoCalibrado);
        RespuestaBD AgregarMuestraHemolizadaLipemica(NuevoMuestraHemolizadaLipemica nuevoMuestraHemolizadaLipemica);
        RespuestaBD EditarPocoFrecuente(ActualizarPocoFrecuente actualizarPocoFrecuente);
        RespuestaBD EditarEmpleoReactivo(ActualizarEmpleoReactivo actualizarEmpleoReactivo);
        RespuestaBD EditarEquipoMalCalibrado(ActualizarEquipoMalCalibrado actualizarEquipoMalCalibrado);
        RespuestaBD EditarEquipoUPS(ActualizarEquipoUPS actualizarEquipoUPS);
        RespuestaBD EditarCalibracionDeficiente(ActualizarCalibracionDeficiente actualizarCalibracionDeficiente);
        RespuestaBD EditarSueroMalReferenciado(ActualizarSueroMalReferenciado actualizarSueroMalReferenciado);
        RespuestaBD EditarMaterialNoCalibrado(ActualizarMaterialNoCalibrado actualizarMaterialNoCalibrado);
        RespuestaBD EditarMuestraHemolizadaLipemica(ActualizarMuestraHemolizadaLipemica actualizarMuestraHemolizadaLipemica);
        IEnumerable<PocoFrecuenteGeneral> ListarPocoFrecuente();
        IEnumerable<EmpleoReactivoGeneral> ListarEmpleoReactivo();
        IEnumerable<EquipoMalCalibradoGeneral> ListarEquipoMalCalibrado();
        IEnumerable<EquipoUPSGeneral> ListarEquipoUPS();
        IEnumerable<CalibracionDeficienteGeneral> ListarCalibracionDeficiente();
        IEnumerable<SueroMalReferenciadoGeneral> ListarSueroMalReferenciado();
        IEnumerable<MaterialNoCalibradoGeneral> ListarMaterialNoCalibrado();
        IEnumerable<MuestraHemolizadaLipemicaGeneral> ListarMuestraHemolizadaLipemica();
    }
}
