using Education_API.Data;
using Education_API.Helpers;
using Education_API.Interfaces;
using Education_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Skapa databaskoppling
builder.Services.AddDbContext<EducationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))
);

// builder.Services.AddDbContext<EducationContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
// );

// Dependency Injection för våra egna Interface och klasser
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
  var context = services.GetRequiredService<EducationContext>();
  await context.Database.MigrateAsync();
  await LoadData.LoadCategories(context);
  await LoadData.LoadCompetences(context);
  await LoadData.LoadCourses(context);
  await LoadData.LoadStudents(context);
  await LoadData.LoadTeachers(context);
}
catch (Exception ex)
{
  var logger = services.GetRequiredService<ILogger<Program>>();
  logger.LogError(ex, "An error occured when the migration executed");
}

app.Run();
