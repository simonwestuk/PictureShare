using Microsoft.EntityFrameworkCore.Migrations;

namespace PictureShare.Data.Migrations
{
    public partial class DBSetComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Picture_PictureModelId",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_PictureModelId",
                table: "Comment",
                newName: "IX_Comment_PictureModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Picture_PictureModelId",
                table: "Comment",
                column: "PictureModelId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Picture_PictureModelId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "CommentModel");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_PictureModelId",
                table: "CommentModel",
                newName: "IX_CommentModel_PictureModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Picture_PictureModelId",
                table: "CommentModel",
                column: "PictureModelId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
