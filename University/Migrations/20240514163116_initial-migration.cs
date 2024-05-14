using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Lecture",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.LectureId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentLastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentAge = table.Column<long>(type: "bigint", nullable: false),
                    StudentHeight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StudentWeight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StudentGender = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLecture",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLecture", x => new { x.DepartmentId, x.LectureId });
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureStudent",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureStudent", x => new { x.LectureId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_LectureStudent_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Exact science" },
                    { 2, "Social science" }
                });

            migrationBuilder.InsertData(
                table: "Lecture",
                columns: new[] { "LectureId", "LectureName" },
                values: new object[,]
                {
                    { 1, "Math" },
                    { 2, "Informatics" },
                    { 3, "Biology" },
                    { 4, "Geography" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentLecture",
                columns: new[] { "DepartmentId", "LectureId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "DepartmentId", "StudentAge", "StudentGender", "StudentHeight", "StudentLastname", "StudentName", "StudentWeight" },
                values: new object[,]
                {
                    { 1, 2, 18L, "Male", 1.85m, "Matrix", "Ted", 90m },
                    { 2, 2, 19L, "Male", 1.88m, "Collay", "Steve", 93.51m },
                    { 3, 1, 55L, "Male", 1.73m, "Parry", "Mathew", 100.01m },
                    { 4, 1, 18L, "Female", 1.69m, "Wanvooren", "Lisa", 52m },
                    { 5, 2, 20L, "Female", 1.72m, "Wilde", "Olivia", 55m },
                    { 6, 1, 25L, "Male", 2.01m, "Ogust", "Natan", 100.5m },
                    { 7, 2, 65L, "Male", 1.88m, "Carrey", "Jim", 93m },
                    { 8, 1, 22L, "Other", 2m, "Cyprus", "Ashlun", 100m }
                });

            migrationBuilder.InsertData(
                table: "LectureStudent",
                columns: new[] { "LectureId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 2 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLecture_LectureId",
                table: "DepartmentLecture",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudent_StudentId",
                table: "LectureStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLecture");

            migrationBuilder.DropTable(
                name: "LectureStudent");

            migrationBuilder.DropTable(
                name: "Lecture");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
