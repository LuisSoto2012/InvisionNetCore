using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.IndicadoresGestion;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio
{
    public interface IRepositorioDeIndicadoresGestion
    {
        RespuestaBD AgregarRendimientoHoraTrabajador(NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador);
        RespuestaBD EditarRendimientoHoraTrabajador(ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador);
        IEnumerable<RendimientoHoraTrabajadorGeneral> ListarRendimientoHoraTrabajador();
        RendimientoHoraTrabajador EncontrarRendimientoHoraTrabajador(int Id);

        RespuestaBD AgregarExamenAtendidoPorServicio(NuevoExamenAtendidoPorServicio request);
        RespuestaBD EditarExamenAtendidoPorServicio(ActualizarExamenAtendidoPorServicio request);
        IEnumerable<ExamenAtendidoPorServicio> ListarExamenAtendidoPorServicio();
        ExamenAtendidoPorServicio EncontrarExamenAtendidoPorServicio(int Id);
        RespuestaBD AgregarExamenNoInformadoPorServicio(NuevoExamenNoInformadoPorServicio request);
        RespuestaBD EditarExamenNoInformadoPorServicio(ActualizarExamenNoInformadoPorServicio request);
        IEnumerable<ExamenNoInformadoPorServicio> ListarExamenNoInformadoPorServicio();
        ExamenNoInformadoPorServicio EncontrarExamenNoInformadoPorServicio(int Id);

        Task<RespuestaBD> AgregarRendimientoHoraTrabajadorAsync(NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador);
        Task<RespuestaBD> EditarRendimientoHoraTrabajadorAsync(ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador);
        Task<IEnumerable<RendimientoHoraTrabajadorGeneral>> ListarRendimientoHoraTrabajadorAsync(int? Id);
        Task<RendimientoHoraTrabajador> EncontrarRendimientoHoraTrabajadorAsync(int Id);
    }
}
