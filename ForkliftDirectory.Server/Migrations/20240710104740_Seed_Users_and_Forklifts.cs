using ForkliftDirectory.Server.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForkliftDirectory.Server.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Users_and_Forklifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $"INSERT INTO public.\"User\"(\"UserId\", \"UserName\") " +
                $"VALUES (1, 'Иванов И.И.')," +
                $"(2, 'Петров П.П.')," +
                $"(3, 'Сидоров С.С.');" +
                $"INSERT INTO public.\"Forklifts\"(\"ForkliftId\", \"Model\", \"Number\", \"LiftCapacity\", \"UserId\")" +
                $"VALUES (1, 'Амкадор', '45-65-PH-1', 5, 1)," +
                $"(2, 'CAT', '22-33-JH-2', 3, 2)," +
                $"(3, 'Tesla', '55-66-LS-3', 6, 3);"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
