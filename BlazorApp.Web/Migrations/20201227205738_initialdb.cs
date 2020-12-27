using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Web.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatronymicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Adatech" },
                    { 2, "Ramwellcom" },
                    { 3, "Rosko" },
                    { 4, "RinoSoft" },
                    { 5, "Totor" },
                    { 6, "Engala" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "FirstName", "LastName", "PatronymicName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Яков", "Хохорин", "Андриянович", "+79025873827" },
                    { 10, 1, "Людмила", "Яцкевича", "Кузьмевна", "+79024714458" },
                    { 3, 2, "Галина", "Сутулина", "Владиленовна", "+79024708102" },
                    { 8, 2, "Евстигней", "Александрин", "Андриянович", "+79022032307" },
                    { 11, 2, "Григорий", "Петров", "Потапович", "+79022839322" },
                    { 2, 3, "Светлана", "Зарубина", "Захаровна", "+79023675410" },
                    { 5, 3, "Авдей", "Расторгуев", "Евгениевич", "+79022480750" },
                    { 7, 3, "Кир", "Бысов", "Миронович", "+79024425555" },
                    { 4, 4, "Никита", "Рощин", "Еремеевич", "+79029648037" },
                    { 6, 5, "Онуфрий", "Эрнет", "Леонович", "+79022756964" },
                    { 12, 5, "Инесса", "Сайтахметова", "Тимофеевна", "+79029903421" },
                    { 9, 6, "Кир", "Жиленков", "Миронович", "+79024661261" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companys");
        }
    }
}
