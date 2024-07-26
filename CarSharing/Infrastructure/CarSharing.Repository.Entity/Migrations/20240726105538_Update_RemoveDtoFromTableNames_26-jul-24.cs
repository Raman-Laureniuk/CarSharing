using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharing.Repository.Entity.Migrations
{
    /// <inheritdoc />
    public partial class Update_RemoveDtoFromTableNames_26jul24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.CarCoordinates_dbo.Cars_CarId",
                table: "dbo.CarCoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Cars_dbo.Tariffs_TariffId",
                table: "dbo.Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Rides_dbo.Cars_CarId",
                table: "dbo.Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Rides_dbo.Clients_ClientId",
                table: "dbo.Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Rides_dbo.Wallets_WalletId",
                table: "dbo.Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Wallets_dbo.Clients_ClientId",
                table: "dbo.Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Wallets",
                table: "dbo.Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Tariffs",
                table: "dbo.Tariffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Rides",
                table: "dbo.Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Clients",
                table: "dbo.Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Cars",
                table: "dbo.Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.CarCoordinates",
                table: "dbo.CarCoordinates");

            migrationBuilder.RenameTable(
                name: "dbo.Wallets",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "dbo.Tariffs",
                newName: "Tariffs");

            migrationBuilder.RenameTable(
                name: "dbo.Rides",
                newName: "Rides");

            migrationBuilder.RenameTable(
                name: "dbo.Clients",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "dbo.Cars",
                newName: "Cars");

            migrationBuilder.RenameTable(
                name: "dbo.CarCoordinates",
                newName: "CarCoordinates");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Wallets_ClientId",
                table: "Wallets",
                newName: "IX_Wallets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Rides_WalletId",
                table: "Rides",
                newName: "IX_Rides_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Rides_ClientId",
                table: "Rides",
                newName: "IX_Rides_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Rides_CarId",
                table: "Rides",
                newName: "IX_Rides_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Clients_Surname",
                table: "Clients",
                newName: "IX_Clients_Surname");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Clients_PhoneNumber",
                table: "Clients",
                newName: "IX_Clients_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Clients_LicenseNumber",
                table: "Clients",
                newName: "IX_Clients_LicenseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Clients_IsActive",
                table: "Clients",
                newName: "IX_Clients_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Clients_Email",
                table: "Clients",
                newName: "IX_Clients_Email");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Cars_TariffId",
                table: "Cars",
                newName: "IX_Cars_TariffId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.CarCoordinates_Latitude_Longitude",
                table: "CarCoordinates",
                newName: "IX_CarCoordinates_Latitude_Longitude");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "WalletId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tariffs",
                table: "Tariffs",
                column: "TariffId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rides",
                table: "Rides",
                column: "RideId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "CarId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarCoordinates",
                table: "CarCoordinates",
                column: "CarId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCoordinates_Cars_CarId",
                table: "CarCoordinates",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Tariffs_TariffId",
                table: "Cars",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Clients_ClientId",
                table: "Rides",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Wallets_WalletId",
                table: "Rides",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Clients_ClientId",
                table: "Wallets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCoordinates_Cars_CarId",
                table: "CarCoordinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Tariffs_TariffId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Clients_ClientId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Wallets_WalletId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Clients_ClientId",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tariffs",
                table: "Tariffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rides",
                table: "Rides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarCoordinates",
                table: "CarCoordinates");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "dbo.Wallets");

            migrationBuilder.RenameTable(
                name: "Tariffs",
                newName: "dbo.Tariffs");

            migrationBuilder.RenameTable(
                name: "Rides",
                newName: "dbo.Rides");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "dbo.Clients");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "dbo.Cars");

            migrationBuilder.RenameTable(
                name: "CarCoordinates",
                newName: "dbo.CarCoordinates");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_ClientId",
                table: "dbo.Wallets",
                newName: "IX_dbo.Wallets_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_WalletId",
                table: "dbo.Rides",
                newName: "IX_dbo.Rides_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_ClientId",
                table: "dbo.Rides",
                newName: "IX_dbo.Rides_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Rides_CarId",
                table: "dbo.Rides",
                newName: "IX_dbo.Rides_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_Surname",
                table: "dbo.Clients",
                newName: "IX_dbo.Clients_Surname");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_PhoneNumber",
                table: "dbo.Clients",
                newName: "IX_dbo.Clients_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_LicenseNumber",
                table: "dbo.Clients",
                newName: "IX_dbo.Clients_LicenseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_IsActive",
                table: "dbo.Clients",
                newName: "IX_dbo.Clients_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_Email",
                table: "dbo.Clients",
                newName: "IX_dbo.Clients_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_TariffId",
                table: "dbo.Cars",
                newName: "IX_dbo.Cars_TariffId");

            migrationBuilder.RenameIndex(
                name: "IX_CarCoordinates_Latitude_Longitude",
                table: "dbo.CarCoordinates",
                newName: "IX_dbo.CarCoordinates_Latitude_Longitude");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Wallets",
                table: "dbo.Wallets",
                column: "WalletId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Tariffs",
                table: "dbo.Tariffs",
                column: "TariffId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Rides",
                table: "dbo.Rides",
                column: "RideId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Clients",
                table: "dbo.Clients",
                column: "ClientId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Cars",
                table: "dbo.Cars",
                column: "CarId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.CarCoordinates",
                table: "dbo.CarCoordinates",
                column: "CarId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.CarCoordinates_dbo.Cars_CarId",
                table: "dbo.CarCoordinates",
                column: "CarId",
                principalTable: "dbo.Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Cars_dbo.Tariffs_TariffId",
                table: "dbo.Cars",
                column: "TariffId",
                principalTable: "dbo.Tariffs",
                principalColumn: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Rides_dbo.Cars_CarId",
                table: "dbo.Rides",
                column: "CarId",
                principalTable: "dbo.Cars",
                principalColumn: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Rides_dbo.Clients_ClientId",
                table: "dbo.Rides",
                column: "ClientId",
                principalTable: "dbo.Clients",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Rides_dbo.Wallets_WalletId",
                table: "dbo.Rides",
                column: "WalletId",
                principalTable: "dbo.Wallets",
                principalColumn: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Wallets_dbo.Clients_ClientId",
                table: "dbo.Wallets",
                column: "ClientId",
                principalTable: "dbo.Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
