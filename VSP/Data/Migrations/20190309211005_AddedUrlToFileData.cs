using Microsoft.EntityFrameworkCore.Migrations;

namespace VSP.Data.Migrations
{
    public partial class AddedUrlToFileData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "FileDatas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "FileDatas");
        }
    }
}
