using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigV002ISActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vacancies");
        }
    }
}
