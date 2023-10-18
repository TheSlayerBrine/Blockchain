using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blockchain.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSmartContractAndNftLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnSale",
                table: "Nfts");

            migrationBuilder.AddColumn<int>(
                name: "FirstAvailableNftId",
                table: "SmartContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Funds",
                table: "SmartContracts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstAvailableNftId",
                table: "SmartContracts");

            migrationBuilder.DropColumn(
                name: "Funds",
                table: "SmartContracts");

            migrationBuilder.AddColumn<bool>(
                name: "OnSale",
                table: "Nfts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
