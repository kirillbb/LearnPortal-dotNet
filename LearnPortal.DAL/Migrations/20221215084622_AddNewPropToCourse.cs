using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnPortal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UserId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId1",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Courses",
                newName: "InProgressUsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Courses",
                newName: "FinishedUsersId");

            migrationBuilder.AddColumn<Guid>(
                name: "FinishedCourseId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InProgressCoursesId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedCourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InProgressCoursesId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "InProgressUsersId",
                table: "Courses",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "FinishedUsersId",
                table: "Courses",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId1",
                table: "Courses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UserId1",
                table: "Courses",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
