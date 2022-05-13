using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryCompanyDataAccessEF.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор отделения")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Наименование отделения")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Номер заявки"),
                    ReceivingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Адрес, где забрать"),
                    ReceivingTown = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Город, где забрать"),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Адрес доставки"),
                    DeliveryTown = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Город доставки"),
                    Weight = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Вес груза (кг)"),
                    Length = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Длина груза (см)"),
                    Width = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Ширина груза (см)"),
                    Height = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Высота груза (см)"),
                    Volume = table.Column<double>(type: "float", nullable: false, comment: "Объем груза, по формуле Length * Width * Height (м^3)"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true, comment: "Контактный номер телефона"),
                    Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, defaultValue: "Новая", comment: "Статус заявки, возможные значения: 'Новая', 'Передано на выполнение', 'Выполнена', 'Отменена'"),
                    Message = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true, defaultValue: "OK", comment: "Комментарий к заказу"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false, comment: "Ссылка на id-отделение")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_DepartmentId",
                table: "Application",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
