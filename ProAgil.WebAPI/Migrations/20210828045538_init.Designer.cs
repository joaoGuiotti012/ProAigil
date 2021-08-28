﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProAgil.WebAPI.Data;

namespace ProAgil.WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210828045538_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ProAgil.WebAPI.Model.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DataEvento")
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Local")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Lote")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            EventoId = 1,
                            DataEvento = "30/08/2021 01:55:38",
                            ImagemUrl = "img1.jpg",
                            Local = "Belo Horizonte",
                            Lote = "1° Lote",
                            QtdPessoas = 255,
                            Tema = "ANGULAR"
                        },
                        new
                        {
                            EventoId = 2,
                            DataEvento = "02/09/2021 01:55:38",
                            ImagemUrl = "img2.jpg",
                            Local = "Rio de Janeiro",
                            Lote = "2° Lote",
                            QtdPessoas = 333,
                            Tema = "ASPNET CORE 5"
                        },
                        new
                        {
                            EventoId = 3,
                            DataEvento = "29/08/2021 01:55:38",
                            ImagemUrl = "img3.jpg",
                            Local = "São Paulo",
                            Lote = "Lote Unico",
                            QtdPessoas = 543,
                            Tema = "Python para dataScience"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}