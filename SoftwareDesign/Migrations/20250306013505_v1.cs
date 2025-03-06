using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareDesign.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Units = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "varchar(150)", nullable: false),
                    Degree = table.Column<string>(type: "varchar(50)", nullable: false, defaultValue: "CpE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semester = table.Column<string>(type: "varchar(50)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseLinkCourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionNo);
                    table.ForeignKey(
                        name: "FK_Section_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_Course_CourseLinkCourseId",
                        column: x => x.CourseLinkCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateQualified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    FacultyLinkFacultyId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseLinkCourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.CertificationId);
                    table.ForeignKey(
                        name: "FK_Certification_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certification_Course_CourseLinkCourseId",
                        column: x => x.CourseLinkCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certification_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certification_Faculty_FacultyLinkFacultyId",
                        column: x => x.FacultyLinkFacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SectionNo = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncodedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registration_Section_SectionNo",
                        column: x => x.SectionNo,
                        principalTable: "Section",
                        principalColumn: "SectionNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certification_CourseId",
                table: "Certification",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_CourseLinkCourseId",
                table: "Certification",
                column: "CourseLinkCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_FacultyId",
                table: "Certification",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_FacultyLinkFacultyId",
                table: "Certification",
                column: "FacultyLinkFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_SectionNo",
                table: "Registration",
                column: "SectionNo");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_StudentId",
                table: "Registration",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseLinkCourseId",
                table: "Section",
                column: "CourseLinkCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
