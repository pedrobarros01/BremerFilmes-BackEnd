using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReviewFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewFilmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFilmeTMDB = table.Column<int>(type: "integer", nullable: false),
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Comentario = table.Column<string>(type: "text", nullable: false),
                    Nota = table.Column<decimal>(type: "numeric", nullable: false),
                    Curtidas = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_ReviewFilmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewFilmes_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewFilmes_UsuarioId",
                table: "ReviewFilmes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewFilmes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
