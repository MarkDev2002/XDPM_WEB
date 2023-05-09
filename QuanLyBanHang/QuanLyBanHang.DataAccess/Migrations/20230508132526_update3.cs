using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cusAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "paymentMethod",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dea0ad5-1ab0-44bb-b40f-91d6627c1532", "AQAAAAIAAYagAAAAEErqy+ypJC2nNoJG6B6KayboRy5uIIFnvOZK+s/WyQ+oIZP0z+q3HS4hybSA9mqcJA==", "c111c848-29d5-4e49-b19b-15b670a1b7fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentMethod",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "cusAddress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "paymentMethod",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25b9887b-b496-4404-b1e1-907d74cfec9c", "AQAAAAIAAYagAAAAEGK05NJCryGEyf4UNORoNMqBMuAJlDEvggCljrLBHs16LPsA3SLj/Yoq7PEK1eC0zg==", "8ad1cce4-ab21-4795-9ace-a6f479454360" });
        }
    }
}
