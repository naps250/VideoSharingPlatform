using Microsoft.EntityFrameworkCore.Migrations;

namespace VSP.Data.Migrations
{
    public partial class AddContentTypeToFileData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FileDatas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FileDatas");
        }
    }
}
