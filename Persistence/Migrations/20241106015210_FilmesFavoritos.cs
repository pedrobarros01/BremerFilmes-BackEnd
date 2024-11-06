using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FilmesFavoritos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmesFavoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFilmeTMDB = table.Column<int>(type: "integer", nullable: false),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    IdUserCreate = table.Column<int>(type: "integer", nullable: true),
                    IdUserDelete = table.Column<int>(type: "integer", nullable: true),
                    IdUserUpdate = table.Column<int>(type: "integer", nullable: true),
                    DtUserCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DtUserDelete = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DtUserUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmesFavoritos_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmesFavoritos_UsuarioId",
                table: "FilmesFavoritos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmesFavoritos");
        }
    }
}
