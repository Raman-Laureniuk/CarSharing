using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharing.Repository.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo.Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Clients", x => x.ClientId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Tariffs",
                columns: table => new
                {
                    TariffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerHour = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Tariffs", x => x.TariffId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EncryptedWalletData = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Wallets", x => x.WalletId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_dbo.Wallets_dbo.Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "dbo.Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TariffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Cars", x => x.CarId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_dbo.Cars_dbo.Tariffs_TariffId",
                        column: x => x.TariffId,
                        principalTable: "dbo.Tariffs",
                        principalColumn: "TariffId");
                });

            migrationBuilder.CreateTable(
                name: "dbo.CarCoordinates",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CarCoordinates", x => x.CarId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_dbo.CarCoordinates_dbo.Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "dbo.Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Rides",
                columns: table => new
                {
                    RideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDateUtc = table.Column<DateTime>(type: "datetime2(7)", precision: 7, nullable: false),
                    EndDateUtc = table.Column<DateTime>(type: "datetime2(7)", precision: 7, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Rides", x => x.RideId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_dbo.Rides_dbo.Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "dbo.Cars",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK_dbo.Rides_dbo.Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "dbo.Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_dbo.Rides_dbo.Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "dbo.Wallets",
                        principalColumn: "WalletId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.CarCoordinates_Latitude_Longitude",
                table: "dbo.CarCoordinates",
                columns: new[] { "Latitude", "Longitude" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Cars_TariffId",
                table: "dbo.Cars",
                column: "TariffId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Clients_Email",
                table: "dbo.Clients",
                column: "Email")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Clients_IsActive",
                table: "dbo.Clients",
                column: "IsActive")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Clients_LicenseNumber",
                table: "dbo.Clients",
                column: "LicenseNumber")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Clients_PhoneNumber",
                table: "dbo.Clients",
                column: "PhoneNumber")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Clients_Surname",
                table: "dbo.Clients",
                column: "Surname")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Rides_CarId",
                table: "dbo.Rides",
                column: "CarId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Rides_ClientId",
                table: "dbo.Rides",
                column: "ClientId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Rides_WalletId",
                table: "dbo.Rides",
                column: "WalletId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Wallets_ClientId",
                table: "dbo.Wallets",
                column: "ClientId")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo.CarCoordinates");

            migrationBuilder.DropTable(
                name: "dbo.Rides");

            migrationBuilder.DropTable(
                name: "dbo.Cars");

            migrationBuilder.DropTable(
                name: "dbo.Wallets");

            migrationBuilder.DropTable(
                name: "dbo.Tariffs");

            migrationBuilder.DropTable(
                name: "dbo.Clients");
        }
    }
}
