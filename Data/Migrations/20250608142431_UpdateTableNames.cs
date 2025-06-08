using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuell_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_File_AspNetUsers_OwnerId", table: "File");

            migrationBuilder.DropForeignKey(name: "FK_File_Folder_FolderId", table: "File");

            migrationBuilder.DropForeignKey(name: "FK_Folder_AspNetUsers_OwnerId", table: "Folder");

            migrationBuilder.DropPrimaryKey(name: "PK_Folder", table: "Folder");

            migrationBuilder.DropPrimaryKey(name: "PK_File", table: "File");

            migrationBuilder.RenameTable(name: "Folder", newName: "Folders");

            migrationBuilder.RenameTable(name: "File", newName: "Files");

            migrationBuilder.RenameIndex(
                name: "IX_Folder_OwnerId",
                table: "Folders",
                newName: "IX_Folders_OwnerId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_File_OwnerId",
                table: "Files",
                newName: "IX_Files_OwnerId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_File_FolderId",
                table: "Files",
                newName: "IX_Files_FolderId"
            );

            migrationBuilder.AddPrimaryKey(name: "PK_Folders", table: "Folders", column: "Id");

            migrationBuilder.AddPrimaryKey(name: "PK_Files", table: "Files", column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_OwnerId",
                table: "Files",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_AspNetUsers_OwnerId",
                table: "Folders",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Files_AspNetUsers_OwnerId", table: "Files");

            migrationBuilder.DropForeignKey(name: "FK_Files_Folders_FolderId", table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_AspNetUsers_OwnerId",
                table: "Folders"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Folders", table: "Folders");

            migrationBuilder.DropPrimaryKey(name: "PK_Files", table: "Files");

            migrationBuilder.RenameTable(name: "Folders", newName: "Folder");

            migrationBuilder.RenameTable(name: "Files", newName: "File");

            migrationBuilder.RenameIndex(
                name: "IX_Folders_OwnerId",
                table: "Folder",
                newName: "IX_Folder_OwnerId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_Files_OwnerId",
                table: "File",
                newName: "IX_File_OwnerId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_Files_FolderId",
                table: "File",
                newName: "IX_File_FolderId"
            );

            migrationBuilder.AddPrimaryKey(name: "PK_Folder", table: "Folder", column: "Id");

            migrationBuilder.AddPrimaryKey(name: "PK_File", table: "File", column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_File_AspNetUsers_OwnerId",
                table: "File",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_File_Folder_FolderId",
                table: "File",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_AspNetUsers_OwnerId",
                table: "Folder",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
