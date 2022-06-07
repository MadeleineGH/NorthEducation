using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_API.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
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
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
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
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
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
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCompetences",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCompetences", x => new { x.TeacherId, x.CompetenceId });
                    table.ForeignKey(
                        name: "FK_TeacherCompetences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TeacherCompetences_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 1, "Farsta", "Sweden", "12349", "Havsörnsgränd 3" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 2, "Nacka", "Sweden", "13148", "Diligensvägen 46" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 3, "Nacka", "Sweden", "13243", "Kölnavägen 5" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 4, "Stockholm", "Sweden", "12325", "Storgatan 5" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 5, "Enköping", "Sweden", "15247", "Långvägen 12" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "StreetAddress" },
                values: new object[] { 6, "Norrköping", "Sweden", "24856", "Västra allén 48" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, ".NET" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "JavaScript" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Python" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Java" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5, "HTML" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6, "CSS" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 7, "TypeScript" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "React" });

            migrationBuilder.InsertData(
                table: "Competences",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "ASP.NET Core" });

            migrationBuilder.InsertData(
                table: "Competences",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "REST APIs" });

            migrationBuilder.InsertData(
                table: "Competences",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "SQL" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "ImageUrl", "Title" },
                values: new object[] { 1, 1, 1179, "Learn C# for total beginners", "Syntax, Variables, Arrays, Lists", 410, "https://unsplash.com/photos/hSODeSbvzE0", "C# For Beginners" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "ImageUrl", "Title" },
                values: new object[] { 2, 2, 1180, "Become a skilled JavaScript programmer", "Asynchronous Programming, Writing Cross-Browser Code, JavaScript Instantiation Patterns", 320, "https://unsplash.com/photos/hSODeSbvzE0", "JavaScript Programming" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "ImageUrl", "Title" },
                values: new object[] { 3, 3, 1181, "Basics of Python", "Data Types, Dictionaries, Functions", 180, "https://unsplash.com/photos/hSODeSbvzE0", "Learn Python" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "ImageUrl", "Title" },
                values: new object[] { 4, 1, 1180, "Learn how to code with C#", "OOP, Database, REST Api", 270, "https://unsplash.com/photos/hSODeSbvzE0", "Programming with C# 2" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CourseNumber", "Description", "Details", "Duration", "ImageUrl", "Title" },
                values: new object[] { 5, 2, 1180, "Learn more about JavaScript", "Hybrid Application Development", 410, "https://unsplash.com/photos/hSODeSbvzE0", "JavaScript Programming 2" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 1, "connyforsling@gmail.com", "Conny", "Forsling", "0735123583" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, 2, "deseregh@gmail.com", "Deseré", "Gullberg Husberg", "0704004951" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, 3, "rolfhusberg@gmail.com", "Rolf", "Husberg", "0709119459" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, 4, "annapettersson@gmail.com", "Anna", "Pettersson", "0705123583" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, 5, "lisakarlsson@gmail.com", "Lisa", "Karlsson", "0734054951" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, 6, "ollesvensson@gmail.com", "Olle", "Svensson", "0737119458" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCompetences_CompetenceId",
                table: "TeacherCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AddressId",
                table: "Teachers",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "TeacherCompetences");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
