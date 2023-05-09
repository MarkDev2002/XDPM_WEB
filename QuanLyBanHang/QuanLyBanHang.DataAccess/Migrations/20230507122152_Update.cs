using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21d24192-ad36-4d2d-8a33-d555fabc54d0", "AQAAAAIAAYagAAAAEG5VMPKscM2KxR5W0GL1rO2OZYjYkitkZcrGN2lHee/jIDaKP9MCQ5lzwHjeR8CRDA==", "35fb3544-a02c-4564-aed8-d7b753b5a7e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "UserName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfd9e814-c807-4f00-8004-41e3d6dce1f2", "AQAAAAIAAYagAAAAEFlTA3AwcuF3rrweD6Ni8TtyL15Yd04+YDk3NebyFh7zv6u6S5A8/Bkfus8xPOYTyw==", "510e0ee8-f407-44ab-964b-9e5ad8fdc8aa" });
        }
    }
}
