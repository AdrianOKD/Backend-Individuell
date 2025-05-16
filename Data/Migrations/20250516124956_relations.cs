using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuell_Backend.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FolderEntity_FolderId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_FolderEntity_FolderEntity_ParentFolderId",
                table: "FolderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FolderEntity",
                table: "FolderEntity");

            migrationBuilder.RenameTable(
                name: "FolderEntity",
                newName: "Folder");

            migrationBuilder.RenameIndex(
                name: "IX_FolderEntity_ParentFolderId",
                table: "Folder",
                newName: "IX_Folder_ParentFolderId");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Folder",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folder",
                table: "Folder",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerId",
                table: "Files",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_OwnerId",
                table: "Folder",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folder_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_UserEntity_OwnerId",
                table: "Files",
                column: "OwnerId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_Folder_ParentFolderId",
                table: "Folder",
                column: "ParentFolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_UserEntity_OwnerId",
                table: "Folder",
                column: "OwnerId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Folder_FolderId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_UserEntity_OwnerId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folder_Folder_ParentFolderId",
                table: "Folder");

            migrationBuilder.DropForeignKey(
                name: "FK_Folder_UserEntity_OwnerId",
                table: "Folder");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_Files_OwnerId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folder",
                table: "Folder");

            migrationBuilder.DropIndex(
                name: "IX_Folder_OwnerId",
                table: "Folder");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Folder");

            migrationBuilder.RenameTable(
                name: "Folder",
                newName: "FolderEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Folder_ParentFolderId",
                table: "FolderEntity",
                newName: "IX_FolderEntity_ParentFolderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FolderEntity",
                table: "FolderEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FolderEntity_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "FolderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FolderEntity_FolderEntity_ParentFolderId",
                table: "FolderEntity",
                column: "ParentFolderId",
                principalTable: "FolderEntity",
                principalColumn: "Id");
        }
    }
}
