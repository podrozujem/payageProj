using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class ImeMigracije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HolderName = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    CardHolderNumber = table.Column<string>(type: "text", nullable: true),
                    ExpirationMonth = table.Column<int>(type: "integer", nullable: false),
                    ExpirationYear = table.Column<int>(type: "integer", nullable: false),
                    CVV = table.Column<int>(type: "integer", nullable: false),
                    OrderReference = table.Column<string>(type: "text", nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RequirePasswordChange = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "Password", "RequirePasswordChange", "Type" },
                values: new object[,]
                {
                    { 7, "Manager", "jelena@gmail.com", "Jelena", "Dinic", "1234", false, 2 },
                    { 8, "Manager", "jjj@gmail.com", "Neko", "Blabla", "4321", false, 2 },
                    { 1, "User", "manager@email.com", null, null, "password", false, 2 },
                    { 2, "User", "mihailoveljic3010@gmail.com", null, null, "password", true, 3 }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "Id", "Amount", "CVV", "CardHolderNumber", "Currency", "ExpirationMonth", "ExpirationYear", "HolderName", "OrderReference", "PaymentStatus" },
                values: new object[,]
                {
                    { "1", 10000.0, 99, "09099980777", "EUR", 9, 2025, "Mika Mikic", "Neka referenca", 0 },
                    { "2", 20900.0, 123, "34776899909", "RSD", 4, 2024, "Pera Peric", "Neka referenca", 1 },
                    { "3", 34999.0, 456, "342221567899", "EUR", 2, 2025, "Ana Anic", "Neka refernca", 1 },
                    { "4", 6000.0, 234, "12345678999", "EUR", 4, 2025, "Milica Milic", "Neka refernca", 1 },
                    { "5", 34999.0, 987, "234567345", "RSD", 6, 2023, "Marko Markovic", "Neka refernca", 1 },
                    { "6", 8999.0, 456, "764434567", "USD", 5, 2025, "Toma Tomic", "Neka refernca", 2 },
                    { "7", 44449.0, 444, "55556666", "RSD", 8, 2024, "Sara Saric", "Neka refernca", 1 },
                    { "8", 31200.0, 124, "999999999", "USD", 11, 2026, "Ankica Anci", "Neka refernca", 0 },
                    { "9", 36799.0, 432, "8888888", "RSD", 11, 2026, "Elez Elezovic", "Neka refernca", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
