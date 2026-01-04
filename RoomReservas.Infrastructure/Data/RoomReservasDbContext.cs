using Microsoft.EntityFrameworkCore;
using RoomReservas.Domain.Entities;

namespace RoomReservas.Infrastructure.Data
{
    public class RoomReservasDbContext(DbContextOptions<RoomReservasDbContext> options) : DbContext(options)
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================
            // SALA
            // ============================
            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("sala");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Capacidade)
                      .HasColumnName("capacidade")
                      .IsRequired();

                entity.Property(e => e.Ativa)
                      .HasColumnName("ativa")
                      .IsRequired();
            });

            // ============================
            // USUARIO
            // ============================
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnName("email")
                      .HasMaxLength(150)
                      .IsRequired();
            });

            // ============================
            // RESERVA
            // ============================
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("reserva");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.SalaId)
                      .HasColumnName("sala_id")
                      .IsRequired();

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("usuario_id")
                      .IsRequired();

                entity.Property(e => e.Inicio)
                      .HasColumnName("inicio")
                      .IsRequired();

                entity.Property(e => e.Fim)
                      .HasColumnName("fim")
                      .IsRequired();

                entity.Property(e => e.DataCriacao)
                      .HasColumnName("data_criacao")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ValorTotal)
                      .HasColumnName("valor_total")
                      .IsRequired();

                entity.Property(e => e.Status)
                      .HasColumnName("status")
                      .HasConversion<int>() // enum <-> int
                      .IsRequired();

                // FK Sala
                entity.HasOne<Sala>()
                      .WithMany()
                      .HasForeignKey(e => e.SalaId);

                // FK Usuario
                entity.HasOne<Usuario>()
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId);

                // Índice importante
                entity.HasIndex(e => new { e.SalaId, e.Inicio, e.Fim });
            });
        }
    }
}
