using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace couvre_plancher.Migrations
{
    /// <inheritdoc />
    public partial class all_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Cin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Cin);
                });

            migrationBuilder.CreateTable(
                name: "Couvreplancher",
                columns: table => new
                {
                    Id_couvre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_couvre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    main_oeuvre = table.Column<double>(type: "float", nullable: false),
                    materieaux = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couvreplancher", x => x.Id_couvre);
                });

            migrationBuilder.CreateTable(
                name: "Superviseur",
                columns: table => new
                {
                    Id_sup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superviseur", x => x.Id_sup);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    Id_cmd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_cmd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cin = table.Column<int>(type: "int", nullable: true),
                    Id_couvre = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.Id_cmd);
                    table.ForeignKey(
                        name: "FK_Commande_Client_Cin",
                        column: x => x.Cin,
                        principalTable: "Client",
                        principalColumn: "Cin");
                    table.ForeignKey(
                        name: "FK_Commande_Couvreplancher_Id_couvre",
                        column: x => x.Id_couvre,
                        principalTable: "Couvreplancher",
                        principalColumn: "Id_couvre");
                });

            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    Id_pack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    superficie = table.Column<float>(type: "real", nullable: false),
                    reduction = table.Column<int>(type: "int", nullable: false),
                    Id_couvre = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.Id_pack);
                    table.ForeignKey(
                        name: "FK_Pack_Couvreplancher_Id_couvre",
                        column: x => x.Id_couvre,
                        principalTable: "Couvreplancher",
                        principalColumn: "Id_couvre");
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id_pro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evenement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reduction = table.Column<int>(type: "int", nullable: false),
                    Id_couvre = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id_pro);
                    table.ForeignKey(
                        name: "FK_Promotion_Couvreplancher_Id_couvre",
                        column: x => x.Id_couvre,
                        principalTable: "Couvreplancher",
                        principalColumn: "Id_couvre");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_Cin",
                table: "Commande",
                column: "Cin");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_Id_couvre",
                table: "Commande",
                column: "Id_couvre");

            migrationBuilder.CreateIndex(
                name: "IX_Pack_Id_couvre",
                table: "Pack",
                column: "Id_couvre");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_Id_couvre",
                table: "Promotion",
                column: "Id_couvre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Pack");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Superviseur");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Couvreplancher");
        }
    }
}
