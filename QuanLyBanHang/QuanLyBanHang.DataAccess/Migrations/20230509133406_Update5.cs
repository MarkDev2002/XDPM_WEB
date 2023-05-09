using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cusAddress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7144d54e-ffb6-48bd-871f-337e97a42ed0", "AQAAAAIAAYagAAAAEAjYfEQACs1rZgEkxLpQe7+MQjdf1u92VjvY1Z/wKldb1gScxN2xk+VpgsDRnbM33g==", "d5e3f42e-e56b-4042-a180-e922de6d4b63" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cusAddress",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ee05aa-8246-4d1c-8f6d-9895ae976bc9", "AQAAAAIAAYagAAAAEKL+ByAqf95327A5EggFsJui0SyYESzKH9iRJDnLnnmtvGka1t0mc+AVynk48FaVnQ==", "68144837-06e0-438d-b57e-6c1491d8c939" });
        }
    }
}
