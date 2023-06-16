using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteMentoria.Migrations
{
    public partial class UpdateAtividades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Atividade");

            migrationBuilder.AddColumn<string>(
                name: "AcAprendizado",
                table: "Atividade",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AtividadeCodigo",
                table: "Atividade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Atividade",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMensuracao",
                table: "Atividade",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FormMensuracao",
                table: "Atividade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpAprendizado",
                table: "Atividade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Atividade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Atividade",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcAprendizado",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "AtividadeCodigo",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "DataMensuracao",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "FormMensuracao",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "OpAprendizado",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Atividade");

            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Atividade");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Atividade",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
