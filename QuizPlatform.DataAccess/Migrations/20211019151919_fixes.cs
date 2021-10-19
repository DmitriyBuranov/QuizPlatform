using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizPlatform.DataAccess.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "QuestionGuid",
                table: "Questions",
                newName: "QuestionTypeGuid");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("af85376b-aa45-4f0b-8f91-0549b3118060"), "Music" },
                    { new Guid("c27aba67-3fbc-4259-b458-56da8d98ad0a"), "History" }
                });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7bd2074c-a652-4905-a516-22f4336a86d6"), "With exact answer" },
                    { new Guid("b1e33469-245c-4dd6-87fd-c2ba0427b06b"), "With answer options" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af85376b-aa45-4f0b-8f91-0549b3118060"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c27aba67-3fbc-4259-b458-56da8d98ad0a"));

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("7bd2074c-a652-4905-a516-22f4336a86d6"));

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b1e33469-245c-4dd6-87fd-c2ba0427b06b"));

            migrationBuilder.RenameColumn(
                name: "QuestionTypeGuid",
                table: "Questions",
                newName: "QuestionGuid");

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
        }
    }
}
