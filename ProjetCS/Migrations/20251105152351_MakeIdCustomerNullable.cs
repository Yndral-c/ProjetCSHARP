using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetCS.Migrations
{
    /// <inheritdoc />
    public partial class MakeIdCustomerNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_IdCustomer",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCustomer",
                table: "Cars",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_IdCustomer",
                table: "Cars",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_IdCustomer",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCustomer",
                table: "Cars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_IdCustomer",
                table: "Cars",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
