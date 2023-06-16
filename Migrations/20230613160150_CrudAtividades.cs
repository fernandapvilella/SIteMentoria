using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteMentoria.Migrations
{
    public partial class CrudAtividades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividade_Pessoa_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Atividade_Pessoa_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_AlunoId",
                table: "Atividade",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_ProfessorId",
                table: "Atividade",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");
        }
    }
}
