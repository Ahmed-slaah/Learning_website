using Microsoft.EntityFrameworkCore.Migrations;

namespace lab1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTopic_Courses_CourseID",
                table: "CourseTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTopic_Topic_TopicId",
                table: "CourseTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTopic",
                table: "CourseTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.RenameTable(
                name: "CourseTopic",
                newName: "courseTopic");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "topics");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTopic_TopicId",
                table: "courseTopic",
                newName: "IX_courseTopic_TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courseTopic",
                table: "courseTopic",
                columns: new[] { "CourseID", "TopicId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_topics",
                table: "topics",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseTopic_Courses_CourseID",
                table: "courseTopic",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courseTopic_topics_TopicId",
                table: "courseTopic",
                column: "TopicId",
                principalTable: "topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseTopic_Courses_CourseID",
                table: "courseTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_courseTopic_topics_TopicId",
                table: "courseTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courseTopic",
                table: "courseTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_topics",
                table: "topics");

            migrationBuilder.RenameTable(
                name: "courseTopic",
                newName: "CourseTopic");

            migrationBuilder.RenameTable(
                name: "topics",
                newName: "Topic");

            migrationBuilder.RenameIndex(
                name: "IX_courseTopic_TopicId",
                table: "CourseTopic",
                newName: "IX_CourseTopic_TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTopic",
                table: "CourseTopic",
                columns: new[] { "CourseID", "TopicId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTopic_Courses_CourseID",
                table: "CourseTopic",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTopic_Topic_TopicId",
                table: "CourseTopic",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
