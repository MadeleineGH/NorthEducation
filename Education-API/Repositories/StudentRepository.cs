using AutoMapper;
using AutoMapper.QueryableExtensions;
using Education_API.Data;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Repositories
{
  public class StudentRepository : IStudentRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;
    public StudentRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task AddStudentAsync(PostStudentViewModel model)
    {
      var studentToAdd = _mapper.Map<Student>(model);
      await _context.Student.AddAsync(studentToAdd);
    }

    public async Task DeleteStudentAsync(int id)
    {
      var response = await _context.Student.FindAsync(id);

      if(response is not null)
      {
        _context.Student.Remove(response);
      }
    }

    public async Task<StudentViewModel?> GetStudentAsync(int id)
    {
      return await _context.Student.Where(c => c.Id == id)
      .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }

    public async Task<List<StudentViewModel>> GetStudentByEmailAsync(string email)
    {
      return await _context.Student
        .Where(s => s.Email!.ToLower() == email.ToLower())
        .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<List<StudentViewModel>> ListAllStudentsAsync()
    {
        return await _context.Student.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateStudentAsync(int id, PostStudentViewModel model)
    {
      var student = await _context.Student.FindAsync(id);

      if(student is null)
      {
        throw new Exception($"Couldn't find any student with id {id}.");
      }

        student.FirstName = model.FirstName;
        student.LastName = model.LastName;
        student.Email = model.Email;
        student.PhoneNumber = model.PhoneNumber;

        _context.Student.Update(student);
    }

    public async Task UpdateStudentAsync(int id, PatchStudentViewModel model)
    {
      var student = await _context.Student.FindAsync(id);

      if(student is null)
      {
        throw new Exception($"Couldn't find any student with id {id}.");
      }
  
        student.Email = model.Email;
        student.PhoneNumber = model.PhoneNumber;

        _context.Student.Update(student);
    }
  }
} 