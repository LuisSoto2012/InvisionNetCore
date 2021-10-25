using System;
using Ino_InvisionCore.Dominio.Entidades.EvaluacionEscrita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ino_InvisionCore.Infraestructura.Contexto
{
    public partial class EvaluacionEscritaContext : DbContext
    {
        public EvaluacionEscritaContext()
        {
        }

        public EvaluacionEscritaContext(DbContextOptions<EvaluacionEscritaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<TestModules> TestModules { get; set; }
        public virtual DbSet<TestParts> TestParts { get; set; }
        public virtual DbSet<TestResultDetails> TestResultDetails { get; set; }
        public virtual DbSet<TestResults> TestResults { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasIndex(e => e.QuestionId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasIndex(e => e.TestPartId);

                entity.HasOne(d => d.TestPart)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TestPartId);
            });

            modelBuilder.Entity<TestParts>(entity =>
            {
                entity.HasIndex(e => e.TestModuleId);

                entity.HasOne(d => d.TestModule)
                    .WithMany(p => p.TestParts)
                    .HasForeignKey(d => d.TestModuleId);
            });

            modelBuilder.Entity<TestResultDetails>(entity =>
            {
                entity.HasIndex(e => e.QuestionId);

                entity.HasIndex(e => e.SelectedAnswerId);

                entity.HasIndex(e => e.TestResultId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TestResultDetails)
                    .HasForeignKey(d => d.QuestionId);

                entity.HasOne(d => d.SelectedAnswer)
                    .WithMany(p => p.TestResultDetails)
                    .HasForeignKey(d => d.SelectedAnswerId);

                entity.HasOne(d => d.TestResult)
                    .WithMany(p => p.TestResultDetails)
                    .HasForeignKey(d => d.TestResultId);
            });

            modelBuilder.Entity<TestResults>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Finish)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestResults)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}
