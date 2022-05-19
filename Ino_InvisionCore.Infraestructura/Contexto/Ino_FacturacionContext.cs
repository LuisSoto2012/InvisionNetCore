using System;
using Ino_InvisionCore.Dominio.Entidades.Facturacion;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ino_InvisionCore.Infraestructura.Contexto
{
    public partial class Ino_FacturacionContext : DbContext
    {
        public Ino_FacturacionContext()
        {
        }

        public Ino_FacturacionContext(DbContextOptions<Ino_FacturacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FactComprobantesPago> FactComprobantesPago { get; set; }
        public virtual DbSet<FactComprobantesPagoDetalle> FactComprobantesPagoDetalle { get; set; }
        public virtual DbSet<FactEstadosComprobantes> FactEstadosComprobantes { get; set; }
        public virtual DbSet<FactTipoDocumento> FactTipoDocumento { get; set; }
        public virtual DbSet<FactTipoOperacion> FactTipoOperacion { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ClassView
            //Facturacion
            modelBuilder.Query<ComprobantePagoGalenosView>();
            
            modelBuilder.Entity<FactComprobantesPago>(entity =>
            {
                entity.HasKey(e => e.IdComprobantePago);

                entity.Property(e => e.Concepto).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.DocumentoSeleccionado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaEmision).HasColumnType("date");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Igv)
                    .HasColumnName("IGV")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.IgvCalc)
                    .HasColumnName("IGV_Calc")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.NombreProveedor)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumento)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumentoProv)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NroHistoriaClinica)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NroSerie)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Paciente)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.TotalComprobante).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.TotalLetras).IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.FactComprobantesPago)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__FactCompr__Estad__403A8C7D");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.FactComprobantesPago)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK__FactCompr__IdTip__3E52440B");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.FactComprobantesPago)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .HasConstraintName("FK__FactCompr__IdTip__3F466844");
            });

            modelBuilder.Entity<FactComprobantesPagoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdComprobantePagoDetalle);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Importe).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.IdComprobantePagoNavigation)
                    .WithMany(p => p.FactComprobantesPagoDetalle)
                    .HasForeignKey(d => d.IdComprobantePago)
                    .HasConstraintName("FK__FactCompr__IdCom__4316F928");
            });

            modelBuilder.Entity<FactEstadosComprobantes>(entity =>
            {
                entity.HasKey(e => e.IdEstadoComprobante);

                entity.Property(e => e.IdEstadoComprobante).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FactNroDocumento>(entity =>
            {
                entity.HasKey(e => e.IdFactNroDocumento);

                entity.Property(e => e.NroDocumento)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumentoFinal)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumentoInicial)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NroSerie).HasMaxLength(4);

                entity.HasOne(d => d.IdTipoComprobanteNavigation)
                    .WithMany(p => p.FactNroDocumento)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FactNroDo__IdTip__47DBAE45");
            });

            modelBuilder.Entity<FactTipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.Property(e => e.IdTipoDocumento).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FactTipoOperacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.FactTipoOperacion)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK__FactTipoO__IdTip__398D8EEE");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.IdDistrito)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .IsRequired()
                    .HasColumnName("RUC")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioModificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
