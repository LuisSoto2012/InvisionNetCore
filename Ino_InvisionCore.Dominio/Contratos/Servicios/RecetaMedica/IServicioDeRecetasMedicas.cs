using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.RecetaMedica;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.RecetaMedica
{
    public interface IServicioDeRecetasMedicas
    {
        RespuestaBD AgregarRecetaMedicaEstandar(NuevaRecetaMedicaEstandar parametros);
        IEnumerable<RecetaMedicaEstandarDTO> ListarRecetaMedicaEstandar(string historiaClinica);
        IEnumerable<MedicamentoGeneral> ListarMedicamentos(bool sisFlag);
        RecetaMedicaEstandarImprimirDTO ImprimirRecetaMedicaEstandar(int idRecetaMedica);
        Task<RecetaMedicaEstandarDTO> ObtenerRecetaMedicaPorAtencion(int idAtencion);
        Task<RespuestaBD> ModificarRecetaMedicaEstandar(ModificarRecetaMedicaEstandarDto dto);
        Task<IEnumerable<RecetaMedicaPorDocDto>> ListarRecetasPorDocumento(string numeroDocumento);
    }
}
