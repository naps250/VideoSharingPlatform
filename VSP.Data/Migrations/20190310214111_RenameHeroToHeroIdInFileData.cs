using Microsoft.EntityFrameworkCore.Migrations;

namespace VSP.Data.Migrations
{
    public partial class RenameHeroToHeroIdInFileData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hero",
                table: "FileDatas",
                newName: "HeroId");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "FileDatas",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "FileDatas",
                newName: "Hero");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "FileDatas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
