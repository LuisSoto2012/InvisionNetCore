using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio
{
    public interface IServicioDeIndicadoresGestion
    {
        RespuestaBD AgregarRendimientoHoraTrabajador(NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador);
        RespuestaBD EditarRendimientoHoraTrabajador(ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador);
        IEnumerable<RendimientoHoraTrabajadorGeneral> ListarRendimientoHoraTrabajador();

        RespuestaBD AgregarExamenAtendidoPorServicio(NuevoExamenAtendidoPorServicio request);
        RespuestaBD EditarExamenAtendidoPorServicio(ActualizarExamenAtendidoPorServicio request);
        IEnumerable<ExamenAtendidoPorServicioDto> ListarExamenAtendidoPorServicio();

        RespuestaBD AgregarExamenNoInformadoPorServicio(NuevoExamenNoInformadoPorServicio request);
        RespuestaBD EditarExamenNoInformadoPorServicio(ActualizarExamenNoInformadoPorServicio request);
        IEnumerable<ExamenNoInformadoPorServicioDto> ListarExamenNoInformadoPorServicio();
    }
}
