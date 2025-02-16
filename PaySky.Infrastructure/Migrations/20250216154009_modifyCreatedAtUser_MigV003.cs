using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyCreatedAtUser_MigV003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "CreatedDate");
        }
    }
}
