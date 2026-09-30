using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoNApi.Migrations
{
    /// <inheritdoc />
    public partial class RenamedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "User",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "User_Id");
        }
    }
}
