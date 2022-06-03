using Education_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Data
{
    public class DbInitializer
    {
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
            _modelBuilder.Entity<Student>().HasData(
            new Student
                {
                    Id = 1,
                    FirstName = "Conny",
                    LastName = "Forsling",
                    Email = "connyforsling@gmail.com",
                    PhoneNumber = "0735123583",
                    AddressId = 1
                },
            new Student
                {
                    Id = 2,
                    FirstName = "Deseré",
                    LastName = "Gullberg Husberg",
                    Email = "deseregh@gmail.com",
                    PhoneNumber = "0704004951",
                    AddressId = 2 
                },
            new Student
                {
                    Id = 3,
                    FirstName = "Rolf",
                    LastName = "Husberg",
                    Email = "rolfhusberg@gmail.com",
                    PhoneNumber = "0709119459",
                    AddressId = 3 
                }
            );
            _modelBuilder.Entity<Teacher>().HasData(
            new Teacher
                {
                    Id = 1,
                    FirstName = "Anna",
                    LastName = "Pettersson",
                    Email = "annapettersson@gmail.com",
                    PhoneNumber = "0705123583",
                    AddressId = 4
                },
            new Teacher
                {
                    Id = 2,
                    FirstName = "Lisa",
                    LastName = "Karlsson",
                    Email = "lisakarlsson@gmail.com",
                    PhoneNumber = "0734054951",
                    AddressId = 5
                },
            new Teacher
                {
                    Id = 3,
                    FirstName = "Olle",
                    LastName = "Svensson",
                    Email = "ollesvensson@gmail.com",
                    PhoneNumber = "0737119458",
                    AddressId = 6
                }
            );
            _modelBuilder.Entity<Course>().HasData(
            new Course
                {
                    Id = 1,
                    CourseNumber = 1179,
                    Title = "C# For Beginners",
                    Duration = 410,
                    CategoryId = 1,
                    Description = "Learn C# for total beginners",
                    Details = "Syntax, Variables, Arrays, Lists"
                },
            new Course
                {
                    Id = 2,
                    CourseNumber = 1180,
                    Title = "JavaScript Programming",
                    Duration = 320,
                    CategoryId = 2,
                    Description = "Become a skilled JavaScript programmer",
                    Details = "Asynchronous Programming, Writing Cross-Browser Code, JavaScript Instantiation Patterns"
                },
            new Course
                {
                    Id = 3,
                    CourseNumber = 1181,
                    Title = "Learn Python",
                    Duration = 180,
                    CategoryId = 3,
                    Description = "Basics of Python",
                    Details = "Data Types, Dictionaries, Functions"
                }
            );
            _modelBuilder.Entity<Competence>().HasData(
            new Competence
                {
                    Id = 1,
                    Title = "ASP.NET Core",
                },
            new Competence
                {
                    Id = 2,
                    Title = "REST APIs",
                },
            new Competence
                {
                    Id = 3,
                    Title = "SQL",
                }
            );
            _modelBuilder.Entity<Category>().HasData(
            new Category
                {
                    Id = 1,
                    Title = ".NET",
                },
            new Category
                {
                    Id = 2,
                    Title = "JavaScript",
                },
            new Category
                {
                    Id = 3,
                    Title = "Python",
                }
            );
                _modelBuilder.Entity<Address>().HasData(
            new Address
                {
                    Id = 1,
                    StreetAddress = "Havsörnsgränd 3", 
                    PostalCode = "12349", 
                    City = "Farsta", 
                    Country = "Sweden"
                },
            new Address
                {
                    Id = 2,
                    StreetAddress = "Diligensvägen 46", 
                    PostalCode = "13148", 
                    City = "Nacka", 
                    Country = "Sweden"
                },
            new Address
                {
                    Id = 3,
                    StreetAddress = "Kölnavägen 5", 
                    PostalCode = "13243", 
                    City = "Nacka", 
                    Country = "Sweden"
                },
            new Address
                {
                    Id = 4,
                    StreetAddress = "Storgatan 5", 
                    PostalCode = "12325", 
                    City = "Stockholm", 
                    Country = "Sweden"
                },
            new Address
                {
                    Id = 5,
                    StreetAddress = "Långvägen 12", 
                    PostalCode = "15247", 
                    City = "Enköping", 
                    Country = "Sweden"
                },
            new Address
                {
                    Id = 6,
                    StreetAddress = "Västra allén 48", 
                    PostalCode = "24856", 
                    City = "Norrköping", 
                    Country = "Sweden"
                }
            );
    }
    }
}