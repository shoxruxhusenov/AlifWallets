using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace alifwallet.DataAccess.Migrations
{
    public partial class EntitiesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    SecretKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recharges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    WalletId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recharges_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "IsVerified", "SecretKey" },
                values: new object[,]
                {
                    { 1L, 75000.0, true, "" },
                    { 2L, 8000.0, false, "" },
                    { 3L, 80000.0, true, "" },
                    { 4L, 10000.0, false, "" },
                    { 5L, 50000.0, true, "" },
                    { 6L, 10000.0, false, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recharges_WalletId",
                table: "Recharges",
                column: "WalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recharges");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
