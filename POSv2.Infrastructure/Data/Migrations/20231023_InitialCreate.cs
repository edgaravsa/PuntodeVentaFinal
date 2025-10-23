using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSv2.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            // ... otras tablas aquí

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeNumber", "Name", "Username", "PasswordHash", "Role" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000001"), 1, "Admin", "Admin", BCrypt.Net.BCrypt.HashPassword("Admin123"), 2 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Employees");
            // ... otras tablas aquí
        }
    }
}