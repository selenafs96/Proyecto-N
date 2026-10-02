using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoNApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPathologyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientPathology",
                table: "PatientPathology");

            migrationBuilder.DropIndex(
                name: "IX_PatientPathology_PatientId",
                table: "PatientPathology");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PatientPathology");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PatientPathology",
                newName: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "PathologyId",
                table: "PatientPathology",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DiagnosedDate",
                table: "PatientPathology",
                type: "date",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientPathology",
                table: "PatientPathology",
                columns: new[] { "PatientId", "PathologyId" });

            migrationBuilder.CreateTable(
                name: "Pathology",
                columns: table => new
                {
                    PathologyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathology", x => x.PathologyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientPathology_PathologyId",
                table: "PatientPathology",
                column: "PathologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientPathology_Pathology_PathologyId",
                table: "PatientPathology",
                column: "PathologyId",
                principalTable: "Pathology",
                principalColumn: "PathologyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientPathology_Pathology_PathologyId",
                table: "PatientPathology");

            migrationBuilder.DropTable(
                name: "Pathology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientPathology",
                table: "PatientPathology");

            migrationBuilder.DropIndex(
                name: "IX_PatientPathology_PathologyId",
                table: "PatientPathology");

            migrationBuilder.DropColumn(
                name: "DiagnosedDate",
                table: "PatientPathology");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "PatientPathology",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "PathologyId",
                table: "PatientPathology",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PatientPathology",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientPathology",
                table: "PatientPathology",
                column: "PathologyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPathology_PatientId",
                table: "PatientPathology",
                column: "PatientId");
        }
    }
}
