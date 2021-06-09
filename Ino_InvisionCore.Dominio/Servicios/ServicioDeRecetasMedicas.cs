using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.RecetaMedica;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.RecetaMedica;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeRecetasMedicas : IServicioDeRecetasMedicas
    {
        public IRepositorioDeRecetasMedicas _repositorioDeRecetasMedicas { get; set; }
        public IServicioDeAuditoria _servicioDeAuditoria { get; set; }

        public ServicioDeRecetasMedicas(IRepositorioDeRecetasMedicas repositorioDeRecetasMedicas, IServicioDeAuditoria servicioDeAuditoria)
        {
            _repositorioDeRecetasMedicas = repositorioDeRecetasMedicas;
            _servicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarRecetaMedicaEstandar(NuevaRecetaMedicaEstandar parametros)
        {
            RespuestaBD respuesta = _repositorioDeRecetasMedicas.AgregarRecetaMedicaEstandar(parametros);

            if (respuesta.Id > 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = string.Concat("RecetaMedicaGeneral|", parametros.IdAtencion),
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(parametros),
                    IdUsuario = parametros.IdUsuarioCreacion
                };
                _servicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<MedicamentoGeneral> ListarMedicamentos(bool sisFlag)
        {
            return _repositorioDeRecetasMedicas.ListarMedicamentos(sisFlag);
        }

        public IEnumerable<RecetaMedicaEstandarDTO> ListarRecetaMedicaEstandar(string historiaClinica)
        {
            return _repositorioDeRecetasMedicas.ListarRecetaMedicaEstandar(historiaClinica);
        }

        public RecetaMedicaEstandarImprimirDTO ImprimirRecetaMedicaEstandar(int idRecetaMedica)
        {
            return _repositorioDeRecetasMedicas.ImprimirRecetaMedicaEstandar(idRecetaMedica);
        }

        public async Task<RecetaMedicaEstandarDTO> ObtenerRecetaMedicaPorAtencion(int idAtencion)
        {
            return await _repositorioDeRecetasMedicas.ObtenerRecetaMedicaPorAtencion(idAtencion);
        }

        public async Task<RespuestaBD> ModificarRecetaMedicaEstandar(ModificarRecetaMedicaEstandarDto dto)
        {
            return await _repositorioDeRecetasMedicas.ModificarRecetaMedicaEstandar(dto);
        }

        public Task<IEnumerable<RecetaMedicaPorDocDto>> ListarRecetasPorDocumento(string numeroDocumento)
        {
            return _repositorioDeRecetasMedicas.ListarRecetasPorDocumento(numeroDocumento);
        }
    }
}
