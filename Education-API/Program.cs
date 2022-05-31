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

app.Run();
