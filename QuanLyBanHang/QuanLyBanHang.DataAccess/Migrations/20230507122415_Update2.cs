using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25b9887b-b496-4404-b1e1-907d74cfec9c", "AQAAAAIAAYagAAAAEGK05NJCryGEyf4UNORoNMqBMuAJlDEvggCljrLBHs16LPsA3SLj/Yoq7PEK1eC0zg==", "8ad1cce4-ab21-4795-9ace-a6f479454360" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f139186b-6419-4cb1-8c80-32755a3f7c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21d24192-ad36-4d2d-8a33-d555fabc54d0", "AQAAAAIAAYagAAAAEG5VMPKscM2KxR5W0GL1rO2OZYjYkitkZcrGN2lHee/jIDaKP9MCQ5lzwHjeR8CRDA==", "35fb3544-a02c-4564-aed8-d7b753b5a7e4" });
        }
    }
}
