using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_DaiLy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daily",
                columns: table => new
                {
                    MaDaiLy = table.Column<string>(type: "TEXT", nullable: false),
                    MaHTPP = table.Column<string>(type: "TEXT", nullable: true),
                    TenDaiLy = table.Column<string>(type: "TEXT", nullable: true),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: true),
                    NguoiDaiDien = table.Column<string>(type: "TEXT", nullable: true),
                    DienThoai = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily", x => x.MaDaiLy);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily");
        }
    }
}
