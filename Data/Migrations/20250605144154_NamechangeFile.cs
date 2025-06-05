using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Individuell_Backend.Migrations
{
    /// <inheritdoc />
    public partial class NamechangeFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Folder_FolderId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_UserEntity_OwnerId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Folder");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "File");

            migrationBuilder.RenameIndex(
                name: "IX_Files_OwnerId",
                table: "File",
                newName: "IX_File_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_FolderId",
                table: "File",
                newName: "IX_File_FolderId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "File",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Folder_FolderId",
                table: "File",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_File_UserEntity_OwnerId",
                table: "File",
                column: "OwnerId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Folder_FolderId",
                table: "File");

            migrationBuilder.DropForeignKey(
                name: "FK_File_UserEntity_OwnerId",
                table: "File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "Files");

            migrationBuilder.RenameIndex(
                name: "IX_File_OwnerId",
                table: "Files",
                newName: "IX_Files_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_File_FolderId",
                table: "Files",
                newName: "IX_Files_FolderId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Folder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Files",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

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
        }
    }
}
