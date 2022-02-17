using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stloumustdo.Migrations
{
    public partial class removednull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileViewModel_BucketList_BucketId",
                table: "UserProfileViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "BucketId",
                table: "UserProfileViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileViewModel_BucketList_BucketId",
                table: "UserProfileViewModel",
                column: "BucketId",
                principalTable: "BucketList",
                principalColumn: "BucketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileViewModel_BucketList_BucketId",
                table: "UserProfileViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "BucketId",
                table: "UserProfileViewModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileViewModel_BucketList_BucketId",
                table: "UserProfileViewModel",
                column: "BucketId",
                principalTable: "BucketList",
                principalColumn: "BucketId");
        }
    }
}
