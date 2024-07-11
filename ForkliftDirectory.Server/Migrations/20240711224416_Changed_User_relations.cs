using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ForkliftDirectory.Server.Migrations
{
    /// <inheritdoc />
    public partial class Changed_User_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Users_ForkliftId",
                table: "Forklifts");

            migrationBuilder.AlterColumn<int>(
                name: "ForkliftId",
                table: "Forklifts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_UserId",
                table: "Forklifts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Users_UserId",
                table: "Forklifts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Users_UserId",
                table: "Forklifts");

            migrationBuilder.DropIndex(
                name: "IX_Forklifts_UserId",
                table: "Forklifts");

            migrationBuilder.AlterColumn<int>(
                name: "ForkliftId",
                table: "Forklifts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Users_ForkliftId",
                table: "Forklifts",
                column: "ForkliftId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
