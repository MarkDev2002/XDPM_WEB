using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetails_OrderDetailorderID_OrderDetailproID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderDetailorderID_OrderDetailproID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_orderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderDetailorderID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderDetailproID",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ee05aa-8246-4d1c-8f6d-9895ae976bc9", "AQAAAAIAAYagAAAAEKL+ByAqf95327A5EggFsJui0SyYESzKH9iRJDnLnnmtvGka1t0mc+AVynk48FaVnQ==", "68144837-06e0-438d-b57e-6c1491d8c939" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_proID",
                table: "OrderDetails",
                column: "proID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_proID",
                table: "OrderDetails",
                column: "proID",
                principalTable: "Products",
                principalColumn: "proID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_proID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_proID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailorderID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailproID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dea0ad5-1ab0-44bb-b40f-91d6627c1532", "AQAAAAIAAYagAAAAEErqy+ypJC2nNoJG6B6KayboRy5uIIFnvOZK+s/WyQ+oIZP0z+q3HS4hybSA9mqcJA==", "c111c848-29d5-4e49-b19b-15b670a1b7fd" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderDetailorderID_OrderDetailproID",
                table: "Products",
                columns: new[] { "OrderDetailorderID", "OrderDetailproID" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderID",
                table: "OrderDetails",
                column: "orderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderDetails_OrderDetailorderID_OrderDetailproID",
                table: "Products",
                columns: new[] { "OrderDetailorderID", "OrderDetailproID" },
                principalTable: "OrderDetails",
                principalColumns: new[] { "orderID", "proID" });
        }
    }
}
