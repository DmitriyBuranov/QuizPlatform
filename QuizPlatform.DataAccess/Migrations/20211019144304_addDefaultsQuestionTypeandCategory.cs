using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizPlatform.DataAccess.Migrations
{
    public partial class addDefaultsQuestionTypeandCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionType_QuestionTypeId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionType",
                table: "QuestionType");

            migrationBuilder.RenameTable(
                name: "QuestionType",
                newName: "QuestionTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QuestionTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionTypes",
                table: "QuestionTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("da2daf11-07ef-43f3-b768-bac2d52fe604"), "Music" },
                    { new Guid("24a5a4a2-76ad-43a9-a100-26f74f0567e4"), "History" }
                });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a675b11-641c-4de7-a317-84337ad0aeae"), "With exact answer" },
                    { new Guid("96133875-66fd-4979-81a8-e13f5a510cdc"), "With answer options" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionTypes_QuestionTypeId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionTypes",
                table: "QuestionTypes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24a5a4a2-76ad-43a9-a100-26f74f0567e4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("da2daf11-07ef-43f3-b768-bac2d52fe604"));

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("2a675b11-641c-4de7-a317-84337ad0aeae"));

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("96133875-66fd-4979-81a8-e13f5a510cdc"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QuestionTypes");

            migrationBuilder.RenameTable(
                name: "QuestionTypes",
                newName: "QuestionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionType",
                table: "QuestionType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionType_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
