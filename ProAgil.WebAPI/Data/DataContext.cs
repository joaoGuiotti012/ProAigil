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
                        Tema = "ANGULAR",
                        ImagemUrl = "img1.jpg"
                    },
                    new Evento
                    {
                        EventoId = 2,
                        DataEvento = DateTime.Now.AddDays(5).ToString(),
                        Local = "Rio de Janeiro",
                        Lote = "2° Lote",
                        QtdPessoas = 333,
                        Tema = "ASPNET CORE 5",
                        ImagemUrl = "img2.jpg"
                    },
                    new Evento
                    {
                        EventoId = 3,
                        DataEvento = DateTime.Now.AddDays(1).ToString(),
                        Local = "São Paulo",
                        Lote = "Lote Unico",
                        QtdPessoas = 543,
                        Tema = "Python para dataScience",
                        ImagemUrl = "img3.jpg"
                    }
                );
        }
    }
}