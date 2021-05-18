using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsTK.Migrations.News
{
    public partial class PendingNewsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReporterUserName",
                table: "PendingNews",
                newName: "JournalistUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JournalistUserName",
                table: "PendingNews",
                newName: "ReporterUserName");
        }
    }
}
