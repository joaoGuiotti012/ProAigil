using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataEvento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tema = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QtdPessoas = table.Column<int>(type: "int", nullable: false),
                    Lote = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagemUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "DataEvento", "ImagemUrl", "Local", "Lote", "QtdPessoas", "Tema" },
                values: new object[] { 1, "30/08/2021 01:55:38", "img1.jpg", "Belo Horizonte", "1° Lote", 255, "ANGULAR" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "DataEvento", "ImagemUrl", "Local", "Lote", "QtdPessoas", "Tema" },
                values: new object[] { 2, "02/09/2021 01:55:38", "img2.jpg", "Rio de Janeiro", "2° Lote", 333, "ASPNET CORE 5" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "DataEvento", "ImagemUrl", "Local", "Lote", "QtdPessoas", "Tema" },
                values: new object[] { 3, "29/08/2021 01:55:38", "img3.jpg", "São Paulo", "Lote Unico", 543, "Python para dataScience" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
