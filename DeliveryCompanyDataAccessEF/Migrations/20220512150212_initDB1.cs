using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryCompanyDataAccessEF.Migrations
{
    public partial class initDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Application",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Объем груза, по формуле Length * Width * Height (м^3)",
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Объем груза, по формуле Length * Width * Height (м^3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Application",
                type: "float",
                nullable: false,
                comment: "Объем груза, по формуле Length * Width * Height (м^3)",
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0,
                oldComment: "Объем груза, по формуле Length * Width * Height (м^3)");
        }
    }
}
