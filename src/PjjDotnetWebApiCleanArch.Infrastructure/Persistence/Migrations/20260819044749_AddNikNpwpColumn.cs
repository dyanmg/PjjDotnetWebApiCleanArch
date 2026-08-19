using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PjjDotnetWebApiCleanArch.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNikNpwpColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nik",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Npwp",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nik",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Npwp",
                table: "AspNetUsers");
        }
    }
}
