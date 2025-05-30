using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuell_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedParentFolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folder_Folder_ParentFolderId",
                table: "Folder");

            migrationBuilder.DropIndex(
                name: "IX_Folder_ParentFolderId",
                table: "Folder");

            migrationBuilder.DropColumn(
                name: "ParentFolderId",
                table: "Folder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentFolderId",
                table: "Folder",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folder_ParentFolderId",
                table: "Folder",
                column: "ParentFolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_Folder_ParentFolderId",
                table: "Folder",
                column: "ParentFolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
