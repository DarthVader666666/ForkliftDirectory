using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForkliftDirectory.Server.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Malfunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $"INSERT INTO public.\"Malfunctions\"(\"MalfunctionId\", \"ForkliftId\", \"StartTime\", \"EndTime\", \"TimeSpan\", \"Describtion\")" +
                $"VALUES (1, 1, '7/10/2024 10:00:00', '7/10/2024 12:00:00', '2:00:00', 'сломался')," +
                $"(2, 1, '8/10/2024 10:00:00', '8/10/2024 12:00:00', '2:00:00', 'сломался')," +
                $"(3, 1, '9/10/2024 10:00:00', '9/10/2024 12:00:00', '2:00:00', 'водитель заболел')," +
                $"(4, 2, '7/10/2024 10:00:00', '7/10/2024 12:00:00', '2:00:00', 'сломался')," +
                $"(5, 2, '8/10/2024 10:00:00', '8/10/2024 12:00:00', '2:00:00', 'разрядился')," +
                $"(6, 2, '9/10/2024 10:00:00', '9/10/2024 12:00:00', '2:00:00', 'сломался')," +
                $"(7, 3, '7/10/2024 10:00:00', '7/10/2024 12:00:00', '2:00:00', 'развалился')," +
                $"(8, 3, '8/10/2024 10:00:00', '8/10/2024 12:00:00', '2:00:00', 'украли')," +
                $"(9, 3, '9/10/2024 10:00:00', '9/10/2024 12:00:00', '2:00:00', 'сломался');"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
