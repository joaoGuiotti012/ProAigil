using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Domain.Identity;

namespace ProAgil.Repository
{
    public class ProAgilContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
                                                    UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(url => new { url.UserId, url.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
               
                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.eventoId, PE.palestranteId });

            modelBuilder.Entity<Evento>()
                .Property(e => e.tema)
                    .HasMaxLength(80);

            modelBuilder.Entity<Evento>()
                .Property(e => e.local)
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