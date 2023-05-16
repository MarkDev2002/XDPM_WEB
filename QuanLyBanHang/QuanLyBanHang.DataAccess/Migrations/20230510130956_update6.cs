using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130", "f139186b-6419-4cb1-8c80-32755a3f7c01" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130");

            migrationBuilder.DropColumn(
                name: "pdcID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "typeID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Carts",
                newName: "nameofUser");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "nameofUser",
                table: "Carts",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "pdcID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "typeID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomernameofUser",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130", null, "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7144d54e-ffb6-48bd-871f-337e97a42ed0", "AQAAAAIAAYagAAAAEAjYfEQACs1rZgEkxLpQe7+MQjdf1u92VjvY1Z/wKldb1gScxN2xk+VpgsDRnbM33g==", "d5e3f42e-e56b-4042-a180-e922de6d4b63" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130", "f139186b-6419-4cb1-8c80-32755a3f7c01" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomernameofUser",
                table: "Carts",
                column: "CustomernameofUser",
                principalTable: "Customers",
                principalColumn: "nameofUser");
        }
    }
}
