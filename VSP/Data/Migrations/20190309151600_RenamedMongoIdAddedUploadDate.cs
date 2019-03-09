using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoSharingPlatform.Data.Migrations
{
    public partial class RenamedMongoIdAddedUploadDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MongoId",
                table: "FileDatas",
                newName: "GridFsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GridFsId",
                table: "FileDatas",
                newName: "MongoId");
        }
    }
}
