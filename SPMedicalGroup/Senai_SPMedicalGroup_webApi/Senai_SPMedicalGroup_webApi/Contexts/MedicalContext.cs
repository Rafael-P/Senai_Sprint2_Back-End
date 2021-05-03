using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_SPMedicalGroup_webApi.Domains;

#nullable disable

// Documentação EF Core
// https://docs.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding

/*
    Dependências do EF Core

    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.SqlServer.Design
    Microsoft.EntityFrameworkCore.Tools
 */

/* Comando do DataBaseFirst
    
   Scaffold-DbContext "Data Source=RAFAEL; initial catalog=SP_Medical_Group; user id=sa; pwd=1199...;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context MedicalContext

    Comando:                                        Scaffold-DbContext
    String de Conexão:                              "Data Source=RAFAEL; initial catalog=SP_Medical_Group; user id=sa; pwd=1199...;"
    Provedor utilizado:                             Microsoft.EntityFrameworkCore.SqlServer
    Nome da pastaonde ficarão os domínios:          -OutputDir Domains
    Nome da pasta onde ficarão os contextos:        -ContextDir Contexts
    Nome do arquivo de contexto:                    -Context MedicalContext
*/

namespace Senai_SPMedicalGroup_webApi.Contexts
{
    public partial class MedicalContext : DbContext
    {
        public MedicalContext()
        {
        }

        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<StatusConsulta> StatusConsultas { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=RAFAEL; initial catalog=SP_Medical_Group; user id=sa; pwd=1199700265Ra;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinicas__52A90951FE949CB8");

                entity.HasIndex(e => e.RazaoSocial, "UQ__Clinicas__448779F06626944C")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__Clinicas__4DF3E1FF52520036")
                    .IsUnique();

                entity.HasIndex(e => e.Site, "UQ__Clinicas__A325DDCEBA39776A")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Clinicas__AA57D6B469B74294")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__9B2AD1D8A87EFD51");

                entity.Property(e => e.DataConsulta).HasColumnType("date");

                entity.Property(e => e.DescricaoAtendimento)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consultas__IdMed__534D60F1");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consultas__IdPac__52593CB8");

                entity.HasOne(d => d.IdStatusConsultaNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdStatusConsulta)
                    .HasConstraintName("FK__Consultas__IdSta__5441852A");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__5676CEFFD2B0485D");

                entity.Property(e => e.Especialidade1)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Especialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__C326E652E589FCF6");

                entity.HasIndex(e => e.Crm, "UQ__Medicos__C1F887FF25FC0EB3")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medicos__IdClini__4CA06362");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medicos__IdEspec__4D94879B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medicos__IdUsuar__4BAC3F29");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49B8CB8D12C");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8C87FB7BD")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone, "UQ__Paciente__4EC504B6A75D8C88")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F89731C3D53E99")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pacientes__IdUsu__403A8C7D");
            });

            modelBuilder.Entity<StatusConsulta>(entity =>
            {
                entity.HasKey(e => e.IdStatusConsulta)
                    .HasName("PK__StatusCo__C9D56A2F9E73F618");

                entity.Property(e => e.StatusConsulta1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StatusConsulta");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposUsu__CA04062BABA4A51F");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__TiposUsu__37BBE07E247000D5")
                    .IsUnique();

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF971F367BC8");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105340B477EC3")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
