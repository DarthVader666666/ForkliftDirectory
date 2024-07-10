using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForkliftDirectory.Server.Migrations
{
    /// <inheritdoc />
    public partial class Added_field_Active_to_Forklift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Forklifts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Forklifts");
        }
    }
}
