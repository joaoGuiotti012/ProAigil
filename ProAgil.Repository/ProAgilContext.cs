using System;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options)
        {

        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<Evento>()
                .Property(e => e.Tema)
                    .HasMaxLength(80);

            modelBuilder.Entity<Evento>()
                .Property(e => e.Local) 
                    .HasMaxLength(80);

            // modelBuilder.Entity<Evento>()
            //     .Property(e => e.Lote)
            //         .HasMaxLength(40);

            //         modelBuilder.Entity<Evento>()
            //    .Property(e => e.Local)
            //        .HasPrecision(10, 2);

            // modelBuilder.Entity<Evento>()
            //     .HasData(
            //         new Evento
            //         {
            //             Id = 1,
            //             DataEvento = DateTime.Now.AddDays(2).ToString(),
            //             Local = "Belo Horizonte",
            //             Lote = "1° Lote",
            //             QtdPessoas = 255,
            //             Tema = "ANGULAR",
            //             ImagemUrl = "img1.jpg"
            //         },
            //         new Evento
            //         {
            //             Id = 2,
            //             DataEvento = DateTime.Now.AddDays(5).ToString(),
            //             Local = "Rio de Janeiro",
            //             Lote = "2° Lote",
            //             QtdPessoas = 333,
            //             Tema = "ASPNET CORE 5",
            //             ImagemUrl = "img2.jpg"
            //         },
            //         new Evento
            //         {
            //             Id = 3,
            //             DataEvento = DateTime.Now.AddDays(1).ToString(),
            //             Local = "São Paulo",
            //             Lote = "Lote Unico",
            //             QtdPessoas = 543,
            //             Tema = "Python para dataScience",
            //             ImagemUrl = "img3.jpg"
            //         }
            //     );
        }
    }
}