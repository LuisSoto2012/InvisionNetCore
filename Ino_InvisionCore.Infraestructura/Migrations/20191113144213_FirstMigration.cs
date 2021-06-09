using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ino_InvisionCore.Infraestructura.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Aplicacion",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdAplicacion = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Aplicacion", x => x.IdAplicacion);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Archivo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdArchivo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        TipoArchivo = table.Column<string>(maxLength: 3, nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        IdServicio = table.Column<int>(nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        Ruta = table.Column<string>(nullable: false),
            //        NombreArchivo = table.Column<string>(maxLength: 200, nullable: false),
            //        RutaCompleta = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Archivo", x => x.IdArchivo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AreaLaboratorio",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 200, nullable: false),
            //        Codigo = table.Column<string>(maxLength: 5, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AreaLaboratorio", x => x.IdAreaLaboratorio);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AtencionTrabajador",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdAtencionTrabajador = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        TipoAtencion = table.Column<string>(maxLength: 50, nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        Presion = table.Column<string>(maxLength: 50, nullable: true),
            //        Temperatura = table.Column<int>(nullable: true),
            //        Peso = table.Column<int>(nullable: true),
            //        Talla = table.Column<int>(nullable: true),
            //        Pulso = table.Column<int>(nullable: true),
            //        Motivo = table.Column<string>(nullable: true),
            //        CantidadDias = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AtencionTrabajador", x => x.IdAtencionTrabajador);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Auditoria",
            //    columns: table => new
            //    {
            //        IdAuditoria = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Accion = table.Column<string>(maxLength: 200, nullable: true),
            //        NombreTabla = table.Column<string>(maxLength: 200, nullable: true),
            //        ValoresAntiguos = table.Column<string>(nullable: true),
            //        ValoresNuevos = table.Column<string>(nullable: true),
            //        Fecha = table.Column<DateTime>(nullable: false),
            //        IdUsuario = table.Column<int>(nullable: false),
            //        IpLogueo = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Auditoria", x => x.IdAuditoria);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CodigosRespuestaIndicadoresDesempeno",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Codigo = table.Column<string>(maxLength: 4, nullable: false),
            //        Descripcion = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CodigosRespuestaIndicadoresDesempeno", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CondicionTrabajo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdCondicionTrabajo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CondicionTrabajo", x => x.IdCondicionTrabajo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EscalafonDeLegajos",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdEscalafonDeLegajos = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Codigo = table.Column<string>(maxLength: 3, nullable: false),
            //        Seccion = table.Column<string>(maxLength: 20, nullable: false),
            //        Descripcion = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EscalafonDeLegajos", x => x.IdEscalafonDeLegajos);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IncidentesPacientes",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdIncidentesPacientes = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        Incidentes = table.Column<string>(nullable: true),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IncidentesPacientes", x => x.IdIncidentesPacientes);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IncumplimientoAnalisis",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdIncumplimientoAnalisis = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 50, nullable: false),
            //        ElisaHIV = table.Column<bool>(nullable: false),
            //        AnaIFI = table.Column<bool>(nullable: false),
            //        FtaAbsorcion = table.Column<bool>(nullable: false),
            //        ToxoplasmaIggIgm = table.Column<bool>(nullable: false),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IncumplimientoAnalisis", x => x.IdIncumplimientoAnalisis);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Modulo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdModulo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 100, nullable: false),
            //        Orden = table.Column<int>(nullable: false),
            //        Icono = table.Column<string>(maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Modulo", x => x.IdModulo);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OpcionesOrdenMedica",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdOpcionOrdenMedica = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OpcionesOrdenMedica", x => x.IdOpcionOrdenMedica);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PacienteSinResultado",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdPacienteSinResultado = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        MuestraNoTomada = table.Column<bool>(nullable: false),
            //        ResultadoNoIngresado = table.Column<bool>(nullable: false),
            //        PruebaNoRegistrada = table.Column<bool>(nullable: false),
            //        ResultadoNoRegistrado = table.Column<bool>(nullable: false),
            //        ResultadoNoImpreso = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PacienteSinResultado", x => x.IdPacienteSinResultado);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Procedimiento",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdProcedimiento = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Codigo = table.Column<string>(maxLength: 20, nullable: false),
            //        Descripcion = table.Column<string>(nullable: false),
            //        DescripcionCorta = table.Column<string>(nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Procedimiento", x => x.IdProcedimiento);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PruebasNoRealizadas",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdPruebasNoRealizadas = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        Anca = table.Column<bool>(nullable: false),
            //        AntiCpp = table.Column<bool>(nullable: false),
            //        AntiDna = table.Column<bool>(nullable: false),
            //        AntifenosFebriles = table.Column<bool>(nullable: false),
            //        BartonellaIgg = table.Column<bool>(nullable: false),
            //        BartonellaIggIgm = table.Column<bool>(nullable: false),
            //        BkEsputo = table.Column<bool>(nullable: false),
            //        Cortisol = table.Column<bool>(nullable: false),
            //        ElisaToxoplasma = table.Column<bool>(nullable: false),
            //        HlaB27 = table.Column<bool>(nullable: false),
            //        Htlv = table.Column<bool>(nullable: false),
            //        Mercaptoetanol = table.Column<bool>(nullable: false),
            //        PerfilTiroideo = table.Column<bool>(nullable: false),
            //        Ppd = table.Column<bool>(nullable: false),
            //        Parasitologico = table.Column<bool>(nullable: false),
            //        Comentario = table.Column<string>(nullable: true),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PruebasNoRealizadas", x => x.IdPruebasNoRealizadas);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RecoleccionMuestra",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdRecoleccionMuestra = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        RecoleccionInapropiada = table.Column<bool>(nullable: false),
            //        MuestrasPerdidas = table.Column<bool>(nullable: false),
            //        MuestrasMalRotuladas = table.Column<bool>(nullable: false),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        Comentario = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RecoleccionMuestra", x => x.IdRecoleccionMuestra);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reporte",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdReporte = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 200, nullable: false),
            //        NombreSSRS = table.Column<string>(maxLength: 200, nullable: false),
            //        Imagen = table.Column<string>(maxLength: 200, nullable: false),
            //        Descripcion = table.Column<string>(nullable: false),
            //        Ancho = table.Column<int>(nullable: false),
            //        TamanoDialog = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reporte", x => x.IdReporte);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rol",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdRol = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rol", x => x.IdRol);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SolicitudDatosIncompletos",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdSolicitudDatosIncompletos = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        FaltaDatos = table.Column<bool>(nullable: false),
            //        SinMovimiento = table.Column<bool>(nullable: false),
            //        MovimientoIncorrecto = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SolicitudDatosIncompletos", x => x.IdSolicitudDatosIncompletos);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TicketConsultaExterna",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTicketConsultaExterna = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdPaciente = table.Column<int>(nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        NroBoletaFua = table.Column<string>(maxLength: 30, nullable: false),
            //        IdImpresion = table.Column<int>(nullable: false),
            //        IdMedico = table.Column<int>(nullable: false),
            //        Medico = table.Column<string>(maxLength: 500, nullable: true),
            //        IdImpresionRevision = table.Column<int>(nullable: false),
            //        IdTurno = table.Column<int>(nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        Prioridad = table.Column<int>(nullable: false),
            //        Contador = table.Column<int>(nullable: false),
            //        Edad = table.Column<int>(nullable: false),
            //        AtencionEspecial = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TicketConsultaExterna", x => x.IdTicketConsultaExterna);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoDocumentoIdentidad",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTipoDocumentoIdentidad = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoDocumentoIdentidad", x => x.IdTipoDocumentoIdentidad);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoEmpleado",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTipoEmpleado = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(maxLength: 200, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoEmpleado", x => x.IdTipoEmpleado);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoOrdenMedica",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTipoOrdenMedica = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Descripcion = table.Column<string>(maxLength: 100, nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        TamanoFormulario = table.Column<int>(nullable: false),
            //        TituloFormulario = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoOrdenMedica", x => x.IdTipoOrdenMedica);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TranscripcionErronea",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTranscripcionErronea = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        NoCobrado = table.Column<bool>(nullable: false),
            //        Erroneo = table.Column<bool>(nullable: false),
            //        SinMovimiento = table.Column<bool>(nullable: false),
            //        MovimientoIncorrecto = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TranscripcionErronea", x => x.IdTranscripcionErronea);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VenopunturasFallidas",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdVenopunturasFallidas = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        PacientesAdultosMayoresONinos = table.Column<bool>(nullable: false),
            //        VenasDificiles = table.Column<bool>(nullable: false),
            //        PacienteConPatologiaSubyacente = table.Column<bool>(nullable: false),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        Comentario = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VenopunturasFallidas", x => x.IdVenopunturasFallidas);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CalibracionDeficiente",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdCalibracionDeficiente = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        EstaCalibrado = table.Column<bool>(nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Observaciones = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CalibracionDeficiente", x => x.IdCalibracionDeficiente);
            //        table.ForeignKey(
            //            name: "FK_CalibracionDeficiente_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EmpleoReactivo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdEmpleoReactivo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        TotalDeReactivos = table.Column<int>(nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Vencidos = table.Column<int>(nullable: false),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EmpleoReactivo", x => x.IdEmpleoReactivo);
            //        table.ForeignKey(
            //            name: "FK_EmpleoReactivo_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipoMalCalibrado",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdEquipoMalCalibrado = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        TotalDeEquipos = table.Column<int>(nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Inadecuados = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipoMalCalibrado", x => x.IdEquipoMalCalibrado);
            //        table.ForeignKey(
            //            name: "FK_EquipoMalCalibrado_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EquipoUPS",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdEquipoUPS = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        TieneUPS = table.Column<bool>(nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Observaciones = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EquipoUPS", x => x.IdEquipoUPS);
            //        table.ForeignKey(
            //            name: "FK_EquipoUPS_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MaterialNoCalibrado",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdMaterialNoCalibrado = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Calibrado = table.Column<int>(nullable: false),
            //        NoCalibrado = table.Column<int>(nullable: false),
            //        Inoperativo = table.Column<int>(nullable: false),
            //        Total = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MaterialNoCalibrado", x => x.IdMaterialNoCalibrado);
            //        table.ForeignKey(
            //            name: "FK_MaterialNoCalibrado_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MuestraHemolizadaLipemica",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdMuestraHemolizadaLipemica = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        TipoPrueba = table.Column<string>(maxLength: 20, nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MuestraHemolizadaLipemica", x => x.IdMuestraHemolizadaLipemica);
            //        table.ForeignKey(
            //            name: "FK_MuestraHemolizadaLipemica_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PocoFrecuente",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdPocoFrecuente = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        IdPrueba = table.Column<int>(nullable: false),
            //        NombrePrueba = table.Column<string>(maxLength: 200, nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Total = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PocoFrecuente", x => x.IdPocoFrecuente);
            //        table.ForeignKey(
            //            name: "FK_PocoFrecuente_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RendimientoHoraTrabajador",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdRendimientoHoraTrabajador = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Horas = table.Column<int>(nullable: false),
            //        ExamenesProcesados = table.Column<int>(nullable: false),
            //        NumeroTrabajadores = table.Column<int>(nullable: false),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RendimientoHoraTrabajador", x => x.IdRendimientoHoraTrabajador);
            //        table.ForeignKey(
            //            name: "FK_RendimientoHoraTrabajador_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SueroMalReferenciado",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdSueroMalReferenciado = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false),
            //        TieneReferencia = table.Column<bool>(nullable: false),
            //        NumeroMes = table.Column<int>(nullable: false),
            //        Observaciones = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SueroMalReferenciado", x => x.IdSueroMalReferenciado);
            //        table.ForeignKey(
            //            name: "FK_SueroMalReferenciado_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TranscripcionErroneaInoportuna",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTranscripcionErroneaInoportuna = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FechaOcurrencia = table.Column<DateTime>(nullable: false),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        CuadernoOrden = table.Column<bool>(nullable: false),
            //        OrdenSistema = table.Column<bool>(nullable: false),
            //        EquipoCuaderno = table.Column<bool>(nullable: false),
            //        Inoportuna = table.Column<bool>(nullable: false),
            //        Comentario = table.Column<string>(nullable: true),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TranscripcionErroneaInoportuna", x => x.IdTranscripcionErroneaInoportuna);
            //        table.ForeignKey(
            //            name: "FK_TranscripcionErroneaInoportuna_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AtencionTrabajador_Diagnostico",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdAtencionTrabajador = table.Column<int>(nullable: false),
            //        IdDiagnostico = table.Column<int>(nullable: false),
            //        TipoDiagnostico = table.Column<string>(maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AtencionTrabajador_Diagnostico", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AtencionTrabajador_Diagnostico_AtencionTrabajador_IdAtencionTrabajador",
            //            column: x => x.IdAtencionTrabajador,
            //            principalTable: "AtencionTrabajador",
            //            principalColumn: "IdAtencionTrabajador",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubModulo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdSubModulo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Nombre = table.Column<string>(maxLength: 100, nullable: false),
            //        Orden = table.Column<int>(nullable: false),
            //        Ruta = table.Column<string>(maxLength: 500, nullable: false),
            //        IdModulo = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubModulo", x => x.IdSubModulo);
            //        table.ForeignKey(
            //            name: "FK_SubModulo_Modulo_IdModulo",
            //            column: x => x.IdModulo,
            //            principalTable: "Modulo",
            //            principalColumn: "IdModulo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Empleado",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdEmpleado = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ApellidoPaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        ApellidoMaterno = table.Column<string>(maxLength: 200, nullable: false),
            //        Nombres = table.Column<string>(maxLength: 200, nullable: false),
            //        Correo = table.Column<string>(maxLength: 500, nullable: false),
            //        IdCondicionTrabajo = table.Column<int>(nullable: false),
            //        IdTipoEmpleado = table.Column<int>(nullable: false),
            //        IdTipoDocumento = table.Column<int>(nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: false),
            //        CodigoPlanilla = table.Column<string>(maxLength: 20, nullable: true),
            //        Usuario = table.Column<string>(maxLength: 50, nullable: false),
            //        Contrasena = table.Column<string>(maxLength: 50, nullable: false),
            //        LoginEstado = table.Column<bool>(nullable: false),
            //        LoginIp = table.Column<string>(nullable: true),
            //        FechaNacimiento = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
            //        table.ForeignKey(
            //            name: "FK_Empleado_CondicionTrabajo_IdCondicionTrabajo",
            //            column: x => x.IdCondicionTrabajo,
            //            principalTable: "CondicionTrabajo",
            //            principalColumn: "IdCondicionTrabajo",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Empleado_TipoDocumentoIdentidad_IdTipoDocumento",
            //            column: x => x.IdTipoDocumento,
            //            principalTable: "TipoDocumentoIdentidad",
            //            principalColumn: "IdTipoDocumentoIdentidad",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Empleado_TipoEmpleado_IdTipoEmpleado",
            //            column: x => x.IdTipoEmpleado,
            //            principalTable: "TipoEmpleado",
            //            principalColumn: "IdTipoEmpleado",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdenesMedicas",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdOrdenMedica = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        HistoriaClinica = table.Column<string>(maxLength: 10, nullable: false),
            //        NumeroDocumento = table.Column<string>(maxLength: 10, nullable: true),
            //        Paciente = table.Column<string>(maxLength: 500, nullable: false),
            //        Fecha = table.Column<DateTime>(nullable: false),
            //        IdTipoOrdenMedica = table.Column<int>(nullable: false),
            //        IdAtencion = table.Column<int>(nullable: false),
            //        IdTipoAnestesia = table.Column<int>(nullable: false),
            //        IdTipoUsuario = table.Column<int>(nullable: false),
            //        IdEspecialidad = table.Column<int>(nullable: false),
            //        NombreEspecialidad = table.Column<string>(maxLength: 100, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdenesMedicas", x => x.IdOrdenMedica);
            //        table.ForeignKey(
            //            name: "FK_OrdenesMedicas_TipoOrdenMedica_IdTipoOrdenMedica",
            //            column: x => x.IdTipoOrdenMedica,
            //            principalTable: "TipoOrdenMedica",
            //            principalColumn: "IdTipoOrdenMedica",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoOrdenMedica_Procedimiento",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdTipoOrdenMedica = table.Column<int>(nullable: false),
            //        IdProcedimiento = table.Column<int>(nullable: false),
            //        Orden = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoOrdenMedica_Procedimiento", x => new { x.IdTipoOrdenMedica, x.IdProcedimiento });
            //        table.UniqueConstraint("AK_TipoOrdenMedica_Procedimiento_Id", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TipoOrdenMedica_Procedimiento_Procedimiento_IdProcedimiento",
            //            column: x => x.IdProcedimiento,
            //            principalTable: "Procedimiento",
            //            principalColumn: "IdProcedimiento",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_TipoOrdenMedica_Procedimiento_TipoOrdenMedica_IdTipoOrdenMedica",
            //            column: x => x.IdTipoOrdenMedica,
            //            principalTable: "TipoOrdenMedica",
            //            principalColumn: "IdTipoOrdenMedica",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipoOrdenMedicaRangos",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdTipoOrdenMedicaRangos = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Inicial = table.Column<int>(nullable: false),
            //        Final = table.Column<int>(nullable: false),
            //        Condicionales = table.Column<string>(maxLength: 500, nullable: true),
            //        IdTipoOrdenMedica = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoOrdenMedicaRangos", x => x.IdTipoOrdenMedicaRangos);
            //        table.ForeignKey(
            //            name: "FK_TipoOrdenMedicaRangos_TipoOrdenMedica_IdTipoOrdenMedica",
            //            column: x => x.IdTipoOrdenMedica,
            //            principalTable: "TipoOrdenMedica",
            //            principalColumn: "IdTipoOrdenMedica",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RolSubModulo",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdRolSubModulo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdRol = table.Column<int>(nullable: false),
            //        IdSubModulo = table.Column<int>(nullable: false),
            //        Ver = table.Column<bool>(nullable: false),
            //        Agregar = table.Column<bool>(nullable: false),
            //        Editar = table.Column<bool>(nullable: false),
            //        Eliminar = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RolSubModulo", x => x.IdRolSubModulo);
            //        table.ForeignKey(
            //            name: "FK_RolSubModulo_Rol_IdRol",
            //            column: x => x.IdRol,
            //            principalTable: "Rol",
            //            principalColumn: "IdRol",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_RolSubModulo_SubModulo_IdSubModulo",
            //            column: x => x.IdSubModulo,
            //            principalTable: "SubModulo",
            //            principalColumn: "IdSubModulo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubModulo_AreaLaboratorio",
            //    columns: table => new
            //    {
            //        IdSubModulo = table.Column<int>(nullable: false),
            //        IdAreaLaboratorio = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubModulo_AreaLaboratorio", x => new { x.IdAreaLaboratorio, x.IdSubModulo });
            //        table.ForeignKey(
            //            name: "FK_SubModulo_AreaLaboratorio_AreaLaboratorio_IdAreaLaboratorio",
            //            column: x => x.IdAreaLaboratorio,
            //            principalTable: "AreaLaboratorio",
            //            principalColumn: "IdAreaLaboratorio",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SubModulo_AreaLaboratorio_SubModulo_IdSubModulo",
            //            column: x => x.IdSubModulo,
            //            principalTable: "SubModulo",
            //            principalColumn: "IdSubModulo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SubModulo_Reporte",
            //    columns: table => new
            //    {
            //        IdSubModulo = table.Column<int>(nullable: false),
            //        IdReporte = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubModulo_Reporte", x => new { x.IdSubModulo, x.IdReporte });
            //        table.ForeignKey(
            //            name: "FK_SubModulo_Reporte_Reporte_IdReporte",
            //            column: x => x.IdReporte,
            //            principalTable: "Reporte",
            //            principalColumn: "IdReporte",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_SubModulo_Reporte_SubModulo_IdSubModulo",
            //            column: x => x.IdSubModulo,
            //            principalTable: "SubModulo",
            //            principalColumn: "IdSubModulo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AplicacionEmpleado",
            //    columns: table => new
            //    {
            //        IdAplicacion = table.Column<int>(nullable: false),
            //        IdEmpleado = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AplicacionEmpleado", x => new { x.IdAplicacion, x.IdEmpleado });
            //        table.ForeignKey(
            //            name: "FK_AplicacionEmpleado_Aplicacion_IdAplicacion",
            //            column: x => x.IdAplicacion,
            //            principalTable: "Aplicacion",
            //            principalColumn: "IdAplicacion",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AplicacionEmpleado_Empleado_IdEmpleado",
            //            column: x => x.IdEmpleado,
            //            principalTable: "Empleado",
            //            principalColumn: "IdEmpleado",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UsuarioRol",
            //    columns: table => new
            //    {
            //        IdEmpleado = table.Column<int>(nullable: false),
            //        IdRol = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UsuarioRol", x => new { x.IdEmpleado, x.IdRol });
            //        table.ForeignKey(
            //            name: "FK_UsuarioRol_Empleado_IdEmpleado",
            //            column: x => x.IdEmpleado,
            //            principalTable: "Empleado",
            //            principalColumn: "IdEmpleado",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UsuarioRol_Rol_IdRol",
            //            column: x => x.IdRol,
            //            principalTable: "Rol",
            //            principalColumn: "IdRol",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdenesMedicasCodigos",
            //    columns: table => new
            //    {
            //        IdUsuarioCreacion = table.Column<int>(nullable: false),
            //        IdUsuarioModificacion = table.Column<int>(nullable: true),
            //        FechaCreacion = table.Column<DateTime>(nullable: false),
            //        FechaModificacion = table.Column<DateTime>(nullable: true),
            //        EsActivo = table.Column<bool>(nullable: false),
            //        IdOrdenesMedicasCodigos = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IdProcedimiento = table.Column<int>(nullable: false),
            //        Descripcion = table.Column<string>(nullable: true),
            //        IdOrdenMedica = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdenesMedicasCodigos", x => x.IdOrdenesMedicasCodigos);
            //        table.ForeignKey(
            //            name: "FK_OrdenesMedicasCodigos_OrdenesMedicas_IdOrdenMedica",
            //            column: x => x.IdOrdenMedica,
            //            principalTable: "OrdenesMedicas",
            //            principalColumn: "IdOrdenMedica",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrdenesMedicasCodigos_Procedimiento_IdProcedimiento",
            //            column: x => x.IdProcedimiento,
            //            principalTable: "Procedimiento",
            //            principalColumn: "IdProcedimiento",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdenesMedicasCodigos_OpcionesOrdenMedica",
            //    columns: table => new
            //    {
            //        IdOrdenesMedicasCodigos = table.Column<int>(nullable: false),
            //        IdOpcionOrdenMedica = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdenesMedicasCodigos_OpcionesOrdenMedica", x => new { x.IdOpcionOrdenMedica, x.IdOrdenesMedicasCodigos });
            //        table.ForeignKey(
            //            name: "FK_OrdenesMedicasCodigos_OpcionesOrdenMedica_OpcionesOrdenMedica_IdOpcionOrdenMedica",
            //            column: x => x.IdOpcionOrdenMedica,
            //            principalTable: "OpcionesOrdenMedica",
            //            principalColumn: "IdOpcionOrdenMedica",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrdenesMedicasCodigos_OpcionesOrdenMedica_OrdenesMedicasCodigos_IdOrdenesMedicasCodigos",
            //            column: x => x.IdOrdenesMedicasCodigos,
            //            principalTable: "OrdenesMedicasCodigos",
            //            principalColumn: "IdOrdenesMedicasCodigos",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AplicacionEmpleado_IdEmpleado",
            //    table: "AplicacionEmpleado",
            //    column: "IdEmpleado");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AtencionTrabajador_Diagnostico_IdAtencionTrabajador",
            //    table: "AtencionTrabajador_Diagnostico",
            //    column: "IdAtencionTrabajador");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesMedicasCodigos_IdOrdenMedica",
            //    table: "OrdenesMedicasCodigos",
            //    column: "IdOrdenMedica");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdenesMedicasCodigos_OpcionesOrdenMedica_IdOrdenesMedicasCodigos",
            //    table: "OrdenesMedicasCodigos_OpcionesOrdenMedica",
            //    column: "IdOrdenesMedicasCodigos");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RolSubModulo_IdRol",
            //    table: "RolSubModulo",
            //    column: "IdRol");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RolSubModulo_IdSubModulo",
            //    table: "RolSubModulo",
            //    column: "IdSubModulo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubModulo_IdModulo",
            //    table: "SubModulo",
            //    column: "IdModulo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubModulo_AreaLaboratorio_IdSubModulo",
            //    table: "SubModulo_AreaLaboratorio",
            //    column: "IdSubModulo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubModulo_Reporte_IdReporte",
            //    table: "SubModulo_Reporte",
            //    column: "IdReporte");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TipoOrdenMedica_Procedimiento_IdProcedimiento",
            //    table: "TipoOrdenMedica_Procedimiento",
            //    column: "IdProcedimiento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TipoOrdenMedicaRangos_IdTipoOrdenMedica",
            //    table: "TipoOrdenMedicaRangos",
            //    column: "IdTipoOrdenMedica");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UsuarioRol_IdRol",
            //    table: "UsuarioRol",
            //    column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AplicacionEmpleado");

            //migrationBuilder.DropTable(
            //    name: "Archivo");

            //migrationBuilder.DropTable(
            //    name: "AtencionTrabajador_Diagnostico");

            //migrationBuilder.DropTable(
            //    name: "Auditoria");

            //migrationBuilder.DropTable(
            //    name: "CalibracionDeficiente");

            //migrationBuilder.DropTable(
            //    name: "CodigosRespuestaIndicadoresDesempeno");

            //migrationBuilder.DropTable(
            //    name: "EmpleoReactivo");

            //migrationBuilder.DropTable(
            //    name: "EquipoMalCalibrado");

            //migrationBuilder.DropTable(
            //    name: "EquipoUPS");

            //migrationBuilder.DropTable(
            //    name: "EscalafonDeLegajos");

            //migrationBuilder.DropTable(
            //    name: "IncidentesPacientes");

            //migrationBuilder.DropTable(
            //    name: "IncumplimientoAnalisis");

            //migrationBuilder.DropTable(
            //    name: "MaterialNoCalibrado");

            //migrationBuilder.DropTable(
            //    name: "MuestraHemolizadaLipemica");

            //migrationBuilder.DropTable(
            //    name: "OrdenesMedicasCodigos_OpcionesOrdenMedica");

            //migrationBuilder.DropTable(
            //    name: "PacienteSinResultado");

            //migrationBuilder.DropTable(
            //    name: "PocoFrecuente");

            //migrationBuilder.DropTable(
            //    name: "PruebasNoRealizadas");

            //migrationBuilder.DropTable(
            //    name: "RecoleccionMuestra");

            //migrationBuilder.DropTable(
            //    name: "RendimientoHoraTrabajador");

            //migrationBuilder.DropTable(
            //    name: "RolSubModulo");

            //migrationBuilder.DropTable(
            //    name: "SolicitudDatosIncompletos");

            //migrationBuilder.DropTable(
            //    name: "SubModulo_AreaLaboratorio");

            //migrationBuilder.DropTable(
            //    name: "SubModulo_Reporte");

            //migrationBuilder.DropTable(
            //    name: "SueroMalReferenciado");

            //migrationBuilder.DropTable(
            //    name: "TicketConsultaExterna");

            //migrationBuilder.DropTable(
            //    name: "TipoOrdenMedica_Procedimiento");

            //migrationBuilder.DropTable(
            //    name: "TipoOrdenMedicaRangos");

            //migrationBuilder.DropTable(
            //    name: "TranscripcionErronea");

            //migrationBuilder.DropTable(
            //    name: "TranscripcionErroneaInoportuna");

            //migrationBuilder.DropTable(
            //    name: "UsuarioRol");

            //migrationBuilder.DropTable(
            //    name: "VenopunturasFallidas");

            //migrationBuilder.DropTable(
            //    name: "Aplicacion");

            //migrationBuilder.DropTable(
            //    name: "AtencionTrabajador");

            //migrationBuilder.DropTable(
            //    name: "OpcionesOrdenMedica");

            //migrationBuilder.DropTable(
            //    name: "OrdenesMedicasCodigos");

            //migrationBuilder.DropTable(
            //    name: "Reporte");

            //migrationBuilder.DropTable(
            //    name: "SubModulo");

            //migrationBuilder.DropTable(
            //    name: "AreaLaboratorio");

            //migrationBuilder.DropTable(
            //    name: "Empleado");

            //migrationBuilder.DropTable(
            //    name: "Rol");

            //migrationBuilder.DropTable(
            //    name: "OrdenesMedicas");

            //migrationBuilder.DropTable(
            //    name: "Procedimiento");

            //migrationBuilder.DropTable(
            //    name: "Modulo");

            //migrationBuilder.DropTable(
            //    name: "CondicionTrabajo");

            //migrationBuilder.DropTable(
            //    name: "TipoDocumentoIdentidad");

            //migrationBuilder.DropTable(
            //    name: "TipoEmpleado");

            //migrationBuilder.DropTable(
            //    name: "TipoOrdenMedica");
        }
    }
}
