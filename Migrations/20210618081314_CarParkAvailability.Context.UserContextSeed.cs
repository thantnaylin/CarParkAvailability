using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParkAvailability.Migrations
{
    public partial class CarParkAvailabilityContextUserContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ContactNumber", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "642946", "bobthecat@email.com", "Bob", "The Cat", BCrypt.Net.BCrypt.HashPassword("123456") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ContactNumber", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "642949", "aslan@email.com", "Aslan", "The Ginger", BCrypt.Net.BCrypt.HashPassword("123456") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ContactNumber", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 3, "642943", "tartee@email.com", "Tartee", "The Shorthair", BCrypt.Net.BCrypt.HashPassword("123456") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
