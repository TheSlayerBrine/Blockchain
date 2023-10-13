using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blockchain.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PublicKey = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateKey = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PublicKey);
                });

            migrationBuilder.CreateTable(
                name: "SmartContracts",
                columns: table => new
                {
                    PublicKey = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    MaxSupply = table.Column<int>(type: "int", nullable: false),
                    SuppySold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartContracts", x => x.PublicKey);
                    table.ForeignKey(
                        name: "FK_SmartContracts_Accounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Accounts",
                        principalColumn: "PublicKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nfts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    CollectionKey = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    OwnerKey = table.Column<string>(type: "nvarchar(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nfts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nfts_Accounts_OwnerKey",
                        column: x => x.OwnerKey,
                        principalTable: "Accounts",
                        principalColumn: "PublicKey");
                    table.ForeignKey(
                        name: "FK_Nfts_SmartContracts_CollectionKey",
                        column: x => x.CollectionKey,
                        principalTable: "SmartContracts",
                        principalColumn: "PublicKey");
                });

            migrationBuilder.CreateTable(
                name: "TransactionContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromAddress = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    ToAddress = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionContracts_Accounts_FromAddress",
                        column: x => x.FromAddress,
                        principalTable: "Accounts",
                        principalColumn: "PublicKey");
                    table.ForeignKey(
                        name: "FK_TransactionContracts_SmartContracts_ToAddress",
                        column: x => x.ToAddress,
                        principalTable: "SmartContracts",
                        principalColumn: "PublicKey");
                });

            migrationBuilder.CreateTable(
                name: "TransactionPurchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromAddress = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    ToAddress = table.Column<string>(type: "nvarchar(26)", nullable: false),
                    AmountExchanged = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionPurchases_Accounts_ToAddress",
                        column: x => x.ToAddress,
                        principalTable: "Accounts",
                        principalColumn: "PublicKey");
                    table.ForeignKey(
                        name: "FK_TransactionPurchases_SmartContracts_FromAddress",
                        column: x => x.FromAddress,
                        principalTable: "SmartContracts",
                        principalColumn: "PublicKey");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nfts_CollectionKey",
                table: "Nfts",
                column: "CollectionKey");

            migrationBuilder.CreateIndex(
                name: "IX_Nfts_OwnerKey",
                table: "Nfts",
                column: "OwnerKey");

            migrationBuilder.CreateIndex(
                name: "IX_SmartContracts_OwnerId",
                table: "SmartContracts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionContracts_FromAddress",
                table: "TransactionContracts",
                column: "FromAddress");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionContracts_ToAddress",
                table: "TransactionContracts",
                column: "ToAddress");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPurchases_FromAddress",
                table: "TransactionPurchases",
                column: "FromAddress");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPurchases_ToAddress",
                table: "TransactionPurchases",
                column: "ToAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nfts");

            migrationBuilder.DropTable(
                name: "TransactionContracts");

            migrationBuilder.DropTable(
                name: "TransactionPurchases");

            migrationBuilder.DropTable(
                name: "SmartContracts");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
