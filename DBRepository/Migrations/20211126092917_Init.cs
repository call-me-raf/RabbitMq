using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderSaga",
                columns: table => new
                {
                    CorrelationId = table.Column<Guid>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    CurrentState = table.Column<short>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerSurname = table.Column<string>(nullable: true),
                    ShippedDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSaga", x => x.CorrelationId);
                });

            migrationBuilder.CreateTable(
                name: "OrderSagaItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderCorrelationId = table.Column<Guid>(nullable: false),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    OrderSagaCorrelationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSagaItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderSagaItems_OrderSaga_OrderSagaCorrelationId",
                        column: x => x.OrderSagaCorrelationId,
                        principalTable: "OrderSaga",
                        principalColumn: "CorrelationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSagaItems_OrderSagaCorrelationId",
                table: "OrderSagaItems",
                column: "OrderSagaCorrelationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSagaItems");

            migrationBuilder.DropTable(
                name: "OrderSaga");
        }
    }
}
