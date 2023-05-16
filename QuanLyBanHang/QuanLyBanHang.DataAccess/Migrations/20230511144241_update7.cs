using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CustomernameofUser",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66d8bc8c-dd8e-4830-a22d-b7b19d6ed95b", "AQAAAAIAAYagAAAAEKDgAzCGgy/PZBLO9ACv/slYXTBEtmHCBVEdN8YBeOblDUTzfUdXQBU1zSifq082VA==", "9f1a69fa-619c-4181-ab7a-759e05ce1285" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts",
                column: "CustomernameofUser",
                principalTable: "Customers",
                principalColumn: "nameofUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "Products",
                type: "real",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomernameofUser",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "687d3fbc-1126-433d-b958-637a64f5c34a", "AQAAAAIAAYagAAAAEI+zTdRNWJYeY8iWhc42HfIPIJHDeLp+itDYDe6vZDQpJMlOtCaxmzMqnJ+SYlVrfA==", "9897407a-f35d-4348-82a1-f810c74c41b0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts",
                column: "CustomernameofUser",
                principalTable: "Customers",
                principalColumn: "nameofUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
