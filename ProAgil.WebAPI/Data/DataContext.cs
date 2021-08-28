using System;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .Property(e => e.Tema)
                    .HasMaxLength(80);

            modelBuilder.Entity<Evento>()
                .Property(e => e.Local)
                    .HasMaxLength(80);

            modelBuilder.Entity<Evento>()
                .Property(e => e.Lote)
                    .HasMaxLength(40);

            //         modelBuilder.Entity<Evento>()
            //    .Property(e => e.Local)
            //        .HasPrecision(10, 2);

            modelBuilder.Entity<Evento>()
                .HasData(
                    new Evento
                    {
                        EventoId = 1,
                        DataEvento = DateTime.Now.AddDays(2).ToString(),
                        Local = "Belo Horizonte",
                        Lote = "1° Lote",
                        QtdPessoas = 255,
                        Tema = "ANGULAR + ASPNET CORE 5"
                    },
                    new Evento
                    {
                        EventoId = 2,
                        DataEvento = DateTime.Now.AddDays(5).ToString(),
                        Local = "Belo Horizonte",
                        Lote = "2° Lote",
                        QtdPessoas = 255,
                        Tema = "ANGULAR + ASPNET CORE 5"
                    }
                );
        }
    }
}