using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_API.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetAddress = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCompetence",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCompetence", x => new { x.TeacherId, x.CompetenceId });
                    table.ForeignKey(
                        name: "FK_TeacherCompetence_Competence_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TeacherCompetence_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 1, "Farsta", "Sweden", "12349", "Havsörnsgränd 3" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 2, "Nacka", "Sweden", "13148", "Diligensvägen 46" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 3, "Nacka", "Sweden", "13243", "Kölnavägen 5" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 4, "Stockholm", "Sweden", "12325", "Storgatan 5" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 5, "Enköping", "Sweden", "15247", "Långvägen 12" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 6, "Norrköping", "Sweden", "24856", "Västra allén 48" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, ".NET" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "JavaScript" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Python" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Java" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "HTML" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6, "CSS" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 7, "TypeScript" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "React" });

            migrationBuilder.InsertData(
                table: "Competence",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "ASP.NET Core" });

            migrationBuilder.InsertData(
                table: "Competence",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "REST APIs" });

            migrationBuilder.InsertData(
                table: "Competence",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "SQL" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "Title" },
                values: new object[] { 1, 1, 1179, "Learn C# for total beginners", "Syntax, Variables, Arrays, Lists", 410, "C# For Beginners" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "Title" },
                values: new object[] { 2, 2, 1180, "Become a skilled JavaScript programmer", "Asynchronous Programming, Writing Cross-Browser Code, JavaScript Instantiation Patterns", 320, "JavaScript Programming" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "Title" },
                values: new object[] { 3, 3, 1181, "Basics of Python", "Data Types, Dictionaries, Functions", 180, "Learn Python" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "Title" },
                values: new object[] { 4, 1, 1180, "Learn how to code with C#", "OOP, Database, REST Api", 270, "Programming with C# 2" });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "Title" },
                values: new object[] { 5, 2, 1180, "Learn more about JavaScript", "Hybrid Application Development", 410, "JavaScript Programming 2" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 1, "connyforsling@gmail.com", "Conny", "Forsling", "0735123583" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, 2, "deseregh@gmail.com", "Deseré", "Gullberg Husberg", "0704004951" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, 3, "rolfhusberg@gmail.com", "Rolf", "Husberg", "0709119459" });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 4, "annapettersson@gmail.com", "Anna", "Pettersson", "0705123583" });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, 5, "lisakarlsson@gmail.com", "Lisa", "Karlsson", "0734054951" });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, 6, "ollesvensson@gmail.com", "Olle", "Svensson", "0737119458" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                table: "Student",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AddressId",
                table: "Teacher",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCompetence_CompetenceId",
                table: "TeacherCompetence",
                column: "CompetenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "TeacherCompetence");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Competence");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
